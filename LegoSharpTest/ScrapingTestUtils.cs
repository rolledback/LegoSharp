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
        public static async Task noMissingFilterValues<GraphQueryT, QueryResultT, FilterEnumT>(IEnumerable<GraphQueryT> queries, QueryValuesFilter<FilterEnumT> filter, IFacetExtractor<GraphQueryT> facetExtractor, string displayName) where GraphQueryT: IGraphQuery<QueryResultT>
        {
            LegoGraphClient graphClient = new LegoGraphClient();
            await graphClient.authenticateAsync();

            var missingValues = new List<FacetLabel>();

            foreach (var query in queries)
            {
                var scraper = new FacetScraper<GraphQueryT, QueryResultT>(query, facetExtractor);
                var facets = await graphClient.queryGraph(scraper);

                var enumValues = (FilterEnumT[])Enum.GetValues(typeof(FilterEnumT));
                var filterKey = filter.facetKey;
                var filterId = filter.facetId;

                var facet = facets.FirstOrDefault(f => f.key == filterKey && f.id == filterId);

                if (facet != null)
                {
                    foreach (var label in facet.labels)
                    {
                        try
                        {
                            enumValues.First(c => filter.filterEnumToName(c) == label.name && filter.filterEnumToValue(c) == label.value);
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
