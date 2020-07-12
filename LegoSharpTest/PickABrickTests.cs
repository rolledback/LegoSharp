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
            await TestUtils.tryQueryWithEachFilterValue<BrickColor, PickABrickResult>((value) =>
            {
                var query = new PickABrickQuery();
                query.addFilter(new BrickColorFilter().addValue(value));
                return query;
            });
        }

        [TestMethod]
        public async Task tryQueryWithEachCategory()
        {
            await TestUtils.tryQueryWithEachFilterValue<BrickCategory, PickABrickResult>((value) =>
            {
                var query = new PickABrickQuery();
                query.addFilter(new BrickCategoryFilter().addValue(value));
                return query;
            });
        }

        [TestMethod]
        public async Task tryQueryWithEachColorFamily()
        {
            await TestUtils.tryQueryWithEachFilterValue<BrickColorFamily, PickABrickResult>((value) =>
            {
                var query = new PickABrickQuery();
                query.addFilter(new BrickColorFamilyFilter().addValue(value));
                return query;
            });
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

            await TestUtils.noMissingFilterValues<PickABrickQuery, PickABrickResult, BrickColor>(queries, filter, facetExtractor, "color");
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

            await TestUtils.noMissingFilterValues<PickABrickQuery, PickABrickResult, BrickCategory>(queries, filter, facetExtractor, "category");
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

            await TestUtils.noMissingFilterValues<PickABrickQuery, PickABrickResult, BrickColorFamily>(queries, filter, facetExtractor, "color family");
        }
    }
}
