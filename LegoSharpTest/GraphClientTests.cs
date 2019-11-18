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
    }
}
