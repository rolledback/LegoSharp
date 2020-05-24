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
    public class LegoSharpTests
    {
        [TestMethod]
        public async Task readmeTestOne()
        {
            LegoGraphClient graphClient = new LegoGraphClient();
            await graphClient.authenticateAsync();

            PickABrickQuery query = new PickABrickQuery();
            query.addFilter(new BrickColorFilter()
                .addValue(BrickColor.Black)
            );
            query.query = "wheel";

            PickABrickQueryResult result = await graphClient.pickABrick(query);
            foreach (Brick brick in result.elements)
            {
                // do something with each brick
            }
        }

        [TestMethod]
        public async Task readmeTestTwo()
        {
            LegoGraphClient graphClient = new LegoGraphClient();
            await graphClient.authenticateAsync();

            ProductSearchQuery query = new ProductSearchQuery();
            query.addFilter(new ProductCategoryFilter()
                .addValue(ProductCategory.Sets)
            );
            query.query = "train";

            await graphClient.productSearch(query);
        }
    }
}
