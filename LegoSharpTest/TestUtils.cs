using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LegoSharp;
using System.Linq;
using System.Reflection;
using System.IO.MemoryMappedFiles;

namespace LegoSharpTest
{
    public class TestUtils
    {
        public static async Task noMissingFilterValues<GraphQueryT, QueryResultT, QueryValuesFilterT, ValuesFilterValueT, FacetExtractorT>(string displayName) where GraphQueryT : GraphQuery<QueryResultT> where ValuesFilterValueT : ValuesFilterValue where QueryValuesFilterT : QueryValuesFilter<ValuesFilterValueT> where FacetExtractorT : IFacetExtractor<GraphQueryT>
        {
            LegoGraphClient graphClient = new LegoGraphClient();

            var missingValues = new List<FacetLabel>();
            var filter = constructSomething<QueryValuesFilterT>();
            var facetExtractor = constructSomething<FacetExtractorT>();
            var allValues = ValuesFilterValue.GetAll<ValuesFilterValueT>();
            var queries = new List<GraphQueryT>();

            queries.Add(constructSomething<GraphQueryT>());

            foreach (var value in allValues)
            {
                var queryByValue = constructSomething<GraphQueryT>();
                queryByValue.query = value.value;
                queries.Add(queryByValue);
                var queryByName = constructSomething<GraphQueryT>();
                queryByName.query = value.name;
                queries.Add(queryByName);
            }

            foreach (var query in queries)
            {
                var scraper = new FacetScraperQuery<GraphQueryT, QueryResultT>(query, facetExtractor);
                var facets = await graphClient.queryGraph(scraper);

                var filterKey = filter.facetKey;
                var filterId = filter.facetId;

                var facet = facets.FirstOrDefault(f => f.key == filterKey && f.id == filterId);

                if (facet != null)
                {
                    foreach (var label in facet.labels)
                    {
                        try
                        {
                            allValues.First(c => c.name == label.name && c.value == label.value);
                        }
                        catch (InvalidOperationException)
                        {
                            missingValues.Add(label);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("No " + displayName + " facet found for a query.");
                }
            }

            var missingValuesStrings = new HashSet<string>();
            if (missingValues.Count() > 0)
            {
                foreach (var label in missingValues)
                {
                    missingValuesStrings.Add("\nname: " + label.name + ", value: " + label.value);
                }
            }

            if (missingValuesStrings.Count() > 0)
            {

                string err = "Missing " + displayName + " values exist:";
                foreach (var str in missingValuesStrings)
                {
                    err += str;
                }
                Assert.IsTrue(false, err);
            }
        }

        public static async Task tryQueryWithEachFilterValue<GraphQueryT, QueryResultT, QueryValuesFilterT, ValuesFilterValueT>() where GraphQueryT : GraphQuery<QueryResultT> where ValuesFilterValueT : ValuesFilterValue where QueryValuesFilterT : QueryValuesFilter<ValuesFilterValueT>
        {
            LegoGraphClient graphClient = new LegoGraphClient();

            var allValues = ValuesFilterValue.GetAll<ValuesFilterValueT>();

            foreach (var value in allValues)
            {
                await graphClient.queryGraph(constructSomething<GraphQueryT>().addFilter(constructSomething<QueryValuesFilterT>().addValue(value)));
            }
        }

        public static ObjectT constructSomething<ObjectT>()
        {
            Type myType = typeof(ObjectT);
            ConstructorInfo constructorInfoObj = myType.GetConstructor((new System.Type[] { }));
            return (ObjectT)constructorInfoObj.Invoke((new object[] { }));
        }
    }
}
