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

            LegoGraphSearch graphSearch = new LegoGraphSearch();
            graphSearch.addFilter(new ColorFilter()
                .addValue(LegoColor.Black)
            );
            graphSearch.query = "wheel";

            IEnumerable<Brick> result = await graphClient.searchForBricksAsync(graphSearch);

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

            var colors = (LegoColor[])Enum.GetValues(typeof(LegoColor));

            for (int i = 0; i < colors.Length; i++)
            {
                LegoColor currColor = colors[i];

                LegoGraphSearch graphSearch = new LegoGraphSearch();
                graphSearch.addFilter(new ColorFilter()
                    .addValue(currColor)
                );

                await graphClient.searchForBricksAsync(graphSearch);
            }
        }

        [TestMethod]
        public async Task allCategoriesValid()
        {
            LegoGraphClient graphClient = new LegoGraphClient();
            await graphClient.authenticateAsync();

            var categories = (LegoCategory[])Enum.GetValues(typeof(LegoCategory));

            for (int i = 0; i < categories.Length; i++)
            {
                LegoCategory currCategory = categories[i];

                LegoGraphSearch graphSearch = new LegoGraphSearch();
                graphSearch.addFilter(new CategoryFilter()
                    .addValue(currCategory)
                );

                await graphClient.searchForBricksAsync(graphSearch);
            }
        }
    }
}
