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
    public class ProductSearchTests
    {
        [TestMethod]
        public async Task tryQueryWithEachCategory()
        {
            await this.tryQueryWithEachFilterValue<ProductTypeFilter, ProductType>(() => new ProductTypeFilter());
        }

        [TestMethod]
        public async Task tryQueryWithEachTheme()
        {
            await this.tryQueryWithEachFilterValue<ProductThemeFilter, ProductTheme>(() => new ProductThemeFilter());
        }

        [TestMethod]
        public async Task priceRangeReducesResults()
        {
            LegoGraphClient graphClient = new LegoGraphClient();
            await graphClient.authenticateAsync();

            ProductSearchQuery queryAllPrices = new ProductSearchQuery();
            ProductSearchResult resultAllPrices = await graphClient.productSearch(queryAllPrices);

            ProductSearchQuery queryFilteredPrices = new ProductSearchQuery();
            queryFilteredPrices.addFilter(new ProductPriceFilter()
                .fromTo(1000, 2500)
            );
            ProductSearchResult resultFilteredPrices = await graphClient.productSearch(queryFilteredPrices);

            Assert.IsTrue(resultFilteredPrices.total < resultAllPrices.total);
        }

        [TestMethod]
        public async Task pieceCountRangeReducesResults()
        {
            LegoGraphClient graphClient = new LegoGraphClient();
            await graphClient.authenticateAsync();

            ProductSearchQuery queryAllCounts = new ProductSearchQuery();
            ProductSearchResult resultAllCounts = await graphClient.productSearch(queryAllCounts);

            ProductSearchQuery queryFilteredCounts = new ProductSearchQuery();
            queryFilteredCounts.addFilter(new ProductPieceCountFilter()
                .fromTo(100, 200)
            );
            ProductSearchResult resultFilteredCounts = await graphClient.productSearch(queryFilteredCounts);

            Assert.IsTrue(resultFilteredCounts.total < resultAllCounts.total);
        }

        private async Task tryQueryWithEachFilterValue<FilterT, ValuesFilterValueT>(Func<FilterT> newFilter) where FilterT : ProductSearchValuesFilter<ValuesFilterValueT> where ValuesFilterValueT : ValuesFilterValue
        {
            LegoGraphClient graphClient = new LegoGraphClient();
            await graphClient.authenticateAsync();

            var allValues = ValuesFilterValue.GetAll<ValuesFilterValueT>();

            foreach (var value in allValues)
            {
                ProductSearchQuery query = new ProductSearchQuery();
                FilterT filter = newFilter();
                filter.addValue(value);
                query.addFilter(filter);

                await graphClient.productSearch(query);
            }
        }

        [TestMethod]
        public async Task noMissingCategories()
        {
            var queries = new List<ProductSearchQuery>();
            queries.Add(new ProductSearchQuery());

            var allValues = ValuesFilterValue.GetAll<ProductType>();
            foreach (var value in allValues)
            {
                var queryByEnumValue = new ProductSearchQuery();
                queryByEnumValue.query = value.value;
                queries.Add(queryByEnumValue);

                var queryByEnumName = new ProductSearchQuery();
                queryByEnumName.query = value.name;
                queries.Add(queryByEnumName);
            }

            var filter = new ProductTypeFilter();

            var facetExtractor = new ProductSearchFacetExtractor();

            await ScrapingTestUtils.noMissingFilterValues<ProductSearchQuery, ProductSearchResult, ProductType>(queries, filter, facetExtractor, "category");
        }

        [TestMethod]
        public async Task noMissingThemes()
        {
            var queries = new List<ProductSearchQuery>();
            queries.Add(new ProductSearchQuery());

            var allValues = ValuesFilterValue.GetAll<ProductTheme>();
            foreach (var value in allValues)
            {
                var queryByEnumValue = new ProductSearchQuery();
                queryByEnumValue.query = value.value;
                queries.Add(queryByEnumValue);

                var queryByEnumName = new ProductSearchQuery();
                queryByEnumName.query = value.name;
                queries.Add(queryByEnumName);
            }

            var filter = new ProductThemeFilter();

            var facetExtractor = new ProductSearchFacetExtractor();

            await ScrapingTestUtils.noMissingFilterValues<ProductSearchQuery, ProductSearchResult, ProductTheme>(queries, filter, facetExtractor, "theme");
        }
    }
}
