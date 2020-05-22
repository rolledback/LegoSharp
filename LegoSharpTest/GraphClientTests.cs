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
    [TestClass]
    public class GraphClientTests
    {
        [TestMethod]
        public async Task readmeTest()
        {
            LegoGraphClient graphClient = new LegoGraphClient();
            await graphClient.authenticateAsync();

            Assert.IsTrue(graphClient.isAuthenticated());

            PickABrickQuery query = new PickABrickQuery();
            query.addFilter(new ColorFilter()
                .addValue(BrickColor.Black)
            );
            query.query = "wheel";

            PickABrickQueryResult result = await graphClient.pickABrick(query);

            foreach (Brick brick in result.elements)
            {
                Assert.IsTrue(!string.IsNullOrEmpty(brick.id));
            }
        }

        [TestMethod]
        public async Task tryQueryWithEachColor()
        {
            await this.tryQueryWithEachFilterValue<ColorFilter, BrickColor>(() => new ColorFilter());
        }

        [TestMethod]
        public async Task tryQueryWithEachCategory()
        {
            await this.tryQueryWithEachFilterValue<CategoryFilter, BrickCategory>(() => new CategoryFilter());
        }

        [TestMethod]
        public async Task tryQueryWithEachColorFamily()
        {
            await this.tryQueryWithEachFilterValue<ColorFamilyFilter, BrickColorFamily>(() => new ColorFamilyFilter());
        }

        private async Task tryQueryWithEachFilterValue<FilterT, FilterEnumT>(Func<FilterT> newFilter) where FilterT : PickABrickFilter<FilterEnumT>
        {
            LegoGraphClient graphClient = new LegoGraphClient();
            await graphClient.authenticateAsync();

            var enumValues = (FilterEnumT[])Enum.GetValues(typeof(FilterEnumT));

            for (int i = 0; i < enumValues.Length; i++)
            {
                FilterEnumT currEnum = enumValues[i];

                PickABrickQuery query = new PickABrickQuery();
                FilterT filter = newFilter();
                filter.addValue(currEnum);
                query.addFilter(filter);

                await graphClient.pickABrick(query);
            }
        }

        [TestMethod]
        public async Task noMissingColors()
        {
            await this.noMissingFilterValues(new ColorFilter(), "color");
        }

        [TestMethod]
        public async Task noMissingCategories()
        {
            await this.noMissingFilterValues(new CategoryFilter(), "category");
        }

        [TestMethod]
        public async Task noMissingColorFamilies()
        {
            await this.noMissingFilterValues(new ColorFamilyFilter(), "color family");
        }

        private async Task noMissingFilterValues<FilterEnumT>(PickABrickFilter<FilterEnumT> filter, string displayName)
        {
            LegoGraphClient graphClient = new LegoGraphClient();

            await graphClient.authenticateAsync();

            FacetScraper query = new FacetScraper();
            var facets = await graphClient.queryGraph(query);

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
