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

        private async Task tryQueryWithEachFilterValue<FilterT, ValuesFilterValueT>(Func<FilterT> newFilter) where FilterT : PickABrickValuesFilter<ValuesFilterValueT> where ValuesFilterValueT : ValuesFilterValue
        {
            LegoGraphClient graphClient = new LegoGraphClient();
            await graphClient.authenticateAsync();

            var allValues = BrickColor.GetAll<ValuesFilterValueT>();

            foreach (var value in allValues)
            {
                PickABrickQuery query = new PickABrickQuery();
                FilterT filter = newFilter();
                filter.addValue(value);
                query.addFilter(filter);

                await graphClient.pickABrick(query);
            }
        }

        [TestMethod]
        public async Task noMissingColors()
        {
            var queries = new List<PickABrickQuery>();
            queries.Add(new PickABrickQuery());

            var allValues = ValuesFilterValue.GetAll<BrickColor>();
            foreach (var value in allValues)
            {
                var queryByEnumValue = new PickABrickQuery();
                queryByEnumValue.query = value.value;
                queries.Add(queryByEnumValue);

                var queryByEnumName = new PickABrickQuery();
                queryByEnumName.query = value.name;
                queries.Add(queryByEnumName);
            }

            var filter = new BrickColorFilter();

            var facetExtractor = new PickABrickFacetExtractor();

            await ScrapingTestUtils.noMissingFilterValues<PickABrickQuery, PickABrickResult, BrickColor>(queries, filter, facetExtractor, "color");
        }

        [TestMethod]
        public async Task noMissingCategories()
        {
            var queries = new List<PickABrickQuery>();
            queries.Add(new PickABrickQuery());

            var allValues = ValuesFilterValue.GetAll<BrickCategory>();
            foreach (var value in allValues)
            {
                var queryByEnumValue = new PickABrickQuery();
                queryByEnumValue.query = value.value;
                queries.Add(queryByEnumValue);

                var queryByEnumName = new PickABrickQuery();
                queryByEnumName.query = value.name;
                queries.Add(queryByEnumName);
            }

            var filter = new BrickCategoryFilter();

            var facetExtractor = new PickABrickFacetExtractor();

            await ScrapingTestUtils.noMissingFilterValues<PickABrickQuery, PickABrickResult, BrickCategory>(queries, filter, facetExtractor, "category");
        }

        [TestMethod]
        public async Task noMissingColorFamilies()
        {
            var queries = new List<PickABrickQuery>();
            queries.Add(new PickABrickQuery());

            var allValues = ValuesFilterValue.GetAll<BrickColorFamily>();
            foreach (var value in allValues)
            {
                var queryByEnumValue = new PickABrickQuery();
                queryByEnumValue.query = value.value;
                queries.Add(queryByEnumValue);

                var queryByEnumName = new PickABrickQuery();
                queryByEnumName.query = value.name;
                queries.Add(queryByEnumName);
            }

            var filter = new BrickColorFamilyFilter();

            var facetExtractor = new PickABrickFacetExtractor();

            await ScrapingTestUtils.noMissingFilterValues<PickABrickQuery, PickABrickResult, BrickColorFamily>(queries, filter, facetExtractor, "color family");
        }
    }
}
