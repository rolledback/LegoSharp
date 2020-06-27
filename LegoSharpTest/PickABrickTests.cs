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
    [TestClass]
    public class PickABrickTests
    {
        [TestMethod]
        public async Task tryQueryWithEachColor()
        {
            await this.tryQueryWithEachFilterValue<BrickColorFilter, BrickColor>(() => new BrickColorFilter());
        }

        [TestMethod]
        public async Task tryQueryWithEachCategory()
        {
            await this.tryQueryWithEachFilterValue<BrickCategoryFilter, BrickCategory>(() => new BrickCategoryFilter());
        }

        [TestMethod]
        public async Task tryQueryWithEachColorFamily()
        {
            await this.tryQueryWithEachFilterValue<BrickColorFamilyFilter, BrickColorFamily>(() => new BrickColorFamilyFilter());
        }

        private async Task tryQueryWithEachFilterValue<FilterT, FilterEnumT>(Func<FilterT> newFilter) where FilterT : PickABrickValuesFilter<FilterEnumT>
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
            var queries = new List<PickABrickQuery>();
            queries.Add(new PickABrickQuery());

            var enumValues = (BrickColor[])Enum.GetValues(typeof(BrickColor));
            foreach (var enumValue in enumValues)
            {
                var queryByEnumValue = new PickABrickQuery();
                queryByEnumValue.query = new BrickColorFilter().filterEnumToValue(enumValue);
                queries.Add(queryByEnumValue);

                var queryByEnumName = new PickABrickQuery();
                queryByEnumName.query = new BrickColorFilter().filterEnumToName(enumValue);
                queries.Add(queryByEnumName);
            }

            await ScrapingTestUtils.noMissingFilterValues<PickABrickQuery, PickABrickResult, BrickColor>(queries, new BrickColorFilter(), new PickABrickFacetExtractor(), "color");
        }

        [TestMethod]
        public async Task noMissingCategories()
        {
            var queries = new List<PickABrickQuery>();
            queries.Add(new PickABrickQuery());

            var enumValues = (BrickCategory[])Enum.GetValues(typeof(BrickCategory));
            foreach (var enumValue in enumValues)
            {
                var queryByEnumValue = new PickABrickQuery();
                queryByEnumValue.query = new BrickCategoryFilter().filterEnumToValue(enumValue);
                queries.Add(queryByEnumValue);

                var queryByEnumName = new PickABrickQuery();
                queryByEnumName.query = new BrickCategoryFilter().filterEnumToName(enumValue);
                queries.Add(queryByEnumName);
            }

            await ScrapingTestUtils.noMissingFilterValues<PickABrickQuery, PickABrickResult, BrickCategory>(queries, new BrickCategoryFilter(), new PickABrickFacetExtractor(), "category");
        }

        [TestMethod]
        public async Task noMissingColorFamilies()
        {
            var queries = new List<PickABrickQuery>();
            queries.Add(new PickABrickQuery());

            var enumValues = (BrickColorFamily[])Enum.GetValues(typeof(BrickColorFamily));
            foreach (var enumValue in enumValues)
            {
                var queryByEnumValue = new PickABrickQuery();
                queryByEnumValue.query = new BrickColorFamilyFilter().filterEnumToValue(enumValue);
                queries.Add(queryByEnumValue);

                var queryByEnumName = new PickABrickQuery();
                queryByEnumName.query = new BrickColorFamilyFilter().filterEnumToName(enumValue);
                queries.Add(queryByEnumName);
            }

            await ScrapingTestUtils.noMissingFilterValues<PickABrickQuery, PickABrickResult, BrickColorFamily>(queries, new BrickColorFamilyFilter(), new PickABrickFacetExtractor(), "color family");
        }
    }
}
