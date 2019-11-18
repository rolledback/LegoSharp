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
        public async Task testAuthenticate()
        {
            var graphClient = new LegoGraphClient();
            await graphClient.authenticateAsync();

            Assert.IsTrue(graphClient.isAuthenticated());

            var graphSearch = new LegoGraphSearch();
            graphSearch.addFilter(new ColorFilter()
                .addValue(LegoColor.Black)
                .addValue(LegoColor.Blue)
            );

            var result = await graphClient.searchForBricksAsync(graphSearch);

            foreach (var brick in result)
            {
                Assert.IsTrue(!string.IsNullOrEmpty(brick.id));
            }
        }
    }
}
