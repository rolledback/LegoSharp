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

        private async Task tryQueryWithEachFilterValue<FilterT, FilterEnumT>(Func<FilterT> newFilter) where FilterT : ProductSearchValuesFilter<FilterEnumT>
        {
            LegoGraphClient graphClient = new LegoGraphClient();
            await graphClient.authenticateAsync();

            var enumValues = (FilterEnumT[])Enum.GetValues(typeof(FilterEnumT));

            for (int i = 0; i < enumValues.Length; i++)
            {
                FilterEnumT currEnum = enumValues[i];

                ProductSearchQuery query = new ProductSearchQuery();
                FilterT filter = newFilter();
                filter.addValue(currEnum);
                query.addFilter(filter);

                await graphClient.productSearch(query);
            }
        }

        [TestMethod]
        public async Task noMissingCategories()
        {
            var queries = new List<ProductSearchQuery>();
            queries.Add(new ProductSearchQuery());

            var enumValues = (ProductType[])Enum.GetValues(typeof(ProductType));
            foreach (var enumValue in enumValues)
            {
                var queryByEnumValue = new ProductSearchQuery();
                queryByEnumValue.query = new ProductTypeFilter().filterEnumToValue(enumValue);
                queries.Add(queryByEnumValue);

                var queryByEnumName = new ProductSearchQuery();
                queryByEnumName.query = new ProductTypeFilter().filterEnumToName(enumValue);
                queries.Add(queryByEnumName);
            }

            await ScrapingTestUtils.noMissingFilterValues<ProductSearchQuery, ProductSearchResult, ProductType>(queries, new ProductTypeFilter(), new ProductSearchFacetExtractor(), "category");
        }

        [TestMethod]
        public async Task noMissingThemes()
        {
            var queries = new List<ProductSearchQuery>();
            queries.Add(new ProductSearchQuery());

            var enumValues = (ProductTheme[])Enum.GetValues(typeof(ProductTheme));
            foreach (var enumValue in enumValues)
            {
                var queryByEnumValue = new ProductSearchQuery();
                queryByEnumValue.query = new ProductThemeFilter().filterEnumToValue(enumValue);
                queries.Add(queryByEnumValue);

                var queryByEnumName = new ProductSearchQuery();
                queryByEnumName.query = new ProductThemeFilter().filterEnumToName(enumValue);
                queries.Add(queryByEnumName);
            }

            await ScrapingTestUtils.noMissingFilterValues<ProductSearchQuery, ProductSearchResult, ProductTheme>(queries, new ProductThemeFilter(), new ProductSearchFacetExtractor(), "theme");
        }
    }
}
