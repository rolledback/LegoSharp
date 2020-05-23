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

            PickABrickQueryResult result = await graphClient.pickABrick(query);

            foreach (Brick brick in result.elements)
            {
                Assert.IsTrue(!string.IsNullOrEmpty(brick.id));
            }
        }
    }
}
