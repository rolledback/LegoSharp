using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LegoSharp;
using LegoSharp.PickABrick;
using System.Linq;
using System.Reflection;
using System.IO.MemoryMappedFiles;

namespace LegoSharpTest
{
    public class ScrapingTestUtils
    {
        public static async Task noMissingFilterValues<FilterEnumT, QureyResultT>(IGraphQuery<QureyResultT> query, QueryFilter<FilterEnumT> filter, string displayName)
        {
            LegoGraphClient graphClient = new LegoGraphClient();

            await graphClient.authenticateAsync();

            var scraper = new FacetScraper<QureyResultT>(query);
            var facets = await graphClient.queryGraph(scraper);

            var enumValues = (FilterEnumT[])Enum.GetValues(typeof(FilterEnumT));
            var filterKey = filter.key;

            var facet = facets.FirstOrDefault(f => f.key == filterKey);

            Assert.IsTrue(facet != null, "No " + displayName + " facet");

            var missingValues = new List<FacetLabel>();
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

            if (missingValues.Count() > 0)
            {
                string err = "Missing " + displayName + " values exist:";
                foreach (var label in missingValues)
                {
                    err += "\nname: " + label.name + ", value: " + label.value;
                }
                Assert.IsTrue(false, err);
            }
        }
    }
}
