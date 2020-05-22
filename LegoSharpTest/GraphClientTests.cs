using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LegoSharp;

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

            IEnumerable<Brick> result = await graphClient.pickABrick(query);

            foreach (Brick brick in result)
            {
                Assert.IsTrue(!string.IsNullOrEmpty(brick.id));
            }
        }

        [TestMethod]
        public async Task allColorsValid()
        {
            LegoGraphClient graphClient = new LegoGraphClient();
            await graphClient.authenticateAsync();

            var colors = (BrickColor[])Enum.GetValues(typeof(BrickColor));

            for (int i = 0; i < colors.Length; i++)
            {
                BrickColor currColor = colors[i];

                PickABrickQuery query = new PickABrickQuery();
                query.addFilter(new ColorFilter()
                    .addValue(currColor)
                );

                await graphClient.pickABrick(query);
            }
        }

        [TestMethod]
        public async Task allCategoriesValid()
        {
            LegoGraphClient graphClient = new LegoGraphClient();
            await graphClient.authenticateAsync();

            var categories = (BrickCategory[])Enum.GetValues(typeof(BrickCategory));

            for (int i = 0; i < categories.Length; i++)
            {
                BrickCategory currCategory = categories[i];

                PickABrickQuery query = new PickABrickQuery();
                query.addFilter(new CategoryFilter()
                    .addValue(currCategory)
                );

                await graphClient.pickABrick(query);
            }
        }
    }
}
