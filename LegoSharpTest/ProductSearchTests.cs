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
            await this.tryQueryWithEachFilterValue<ProductCategoryFilter, ProductCategory>(() => new ProductCategoryFilter());
        }

        private async Task tryQueryWithEachFilterValue<FilterT, FilterEnumT>(Func<FilterT> newFilter) where FilterT : ProductSearchFilter<FilterEnumT>
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
            await ScrapingTestUtils.noMissingFilterValues<ProductSearchQuery, ProductSearchResult, ProductCategory>(new ProductSearchQuery(), new ProductCategoryFilter(), new ProductSearchFacetExtractor(), "category");
        }
    }
}
