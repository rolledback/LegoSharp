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
    public class ScrapingTestUtils
    {
        public static async Task noMissingFilterValues<GraphQueryT, QueryResultT, ValuesFilterValueT>(IEnumerable<GraphQueryT> queries, QueryValuesFilter<ValuesFilterValueT> filter, IFacetExtractor<GraphQueryT> facetExtractor, string displayName) where GraphQueryT: IGraphQuery<QueryResultT> where ValuesFilterValueT : ValuesFilterValue
        {
            LegoGraphClient graphClient = new LegoGraphClient();
            await graphClient.authenticateAsync();

            var missingValues = new List<FacetLabel>();

            foreach (var query in queries)
            {
                var scraper = new FacetScraperQuery<GraphQueryT, QueryResultT>(query, facetExtractor);
                var facets = await graphClient.queryGraph(scraper);

                var allValues = ValuesFilterValue.GetAll<ValuesFilterValueT>();
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
    }
}
