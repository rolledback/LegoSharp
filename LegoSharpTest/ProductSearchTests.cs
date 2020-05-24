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
        public async Task noMissingCategories()
        {
            await ScrapingTestUtils.noMissingFilterValues<ProductSearchQuery, dynamic, ProductCategory>(new ProductSearchQuery(), new ProductCategoryFilter(), new ProductSearchFacetExtractor(), "category");
        }
    }
}
