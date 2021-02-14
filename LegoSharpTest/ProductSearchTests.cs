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
        public async Task tryQueryWithEachType()
        {
            await TestUtils.tryQueryWithEachFilterValue<ProductSearchQuery, ProductSearchResult, ProductTypeFilter, ProductType>();
        }

        [TestMethod]
        public async Task tryQueryWithEachTheme()
        {
            await TestUtils.tryQueryWithEachFilterValue<ProductSearchQuery, ProductSearchResult, ProductThemeFilter, ProductTheme>();
        }

        [TestMethod]
        public async Task tryQueryWithEachFlag()
        {
            await TestUtils.tryQueryWithEachFilterValue<ProductSearchQuery, ProductSearchResult, ProductFlagsFilter, ProductFlag>();
        }

        [TestMethod]
        public async Task tryQueryWithEachAvailability()
        {
            await TestUtils.tryQueryWithEachFilterValue<ProductSearchQuery, ProductSearchResult, ProductAvailabilityFilter, ProductAvailability>();
        }

        [TestMethod]
        public async Task priceRangeReducesResults()
        {
            LegoGraphClient graphClient = new LegoGraphClient();

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

            ProductSearchQuery queryAllCounts = new ProductSearchQuery();
            ProductSearchResult resultAllCounts = await graphClient.productSearch(queryAllCounts);

            ProductSearchQuery queryFilteredCounts = new ProductSearchQuery();
            queryFilteredCounts.addFilter(new ProductPieceCountFilter()
                .fromTo(100, 200)
            );
            ProductSearchResult resultFilteredCounts = await graphClient.productSearch(queryFilteredCounts);

            Assert.IsTrue(resultFilteredCounts.total < resultAllCounts.total);
        }

        [TestMethod]
        public async Task noMissingTypes()
        {
            await TestUtils.noMissingFilterValues<ProductSearchQuery, ProductSearchResult, ProductTypeFilter, ProductType, ProductSearchFacetExtractor>("lego product - type");
        }

        [TestMethod]
        public async Task noMissingThemes()
        {
            await TestUtils.noMissingFilterValues<ProductSearchQuery, ProductSearchResult, ProductThemeFilter, ProductTheme, ProductSearchFacetExtractor>("lego product - theme");
        }

        [TestMethod]
        public async Task noMissingFlags()
        {
            await TestUtils.noMissingFilterValues<ProductSearchQuery, ProductSearchResult, ProductFlagsFilter, ProductFlag, ProductSearchFacetExtractor>("lego product - flag");
        }

        [TestMethod]
        public async Task noMissingAvailability()
        {
            await TestUtils.noMissingFilterValues<ProductSearchQuery, ProductSearchResult, ProductAvailabilityFilter, ProductAvailability, ProductSearchFacetExtractor>("lego product - availability");
        }
    }
}
