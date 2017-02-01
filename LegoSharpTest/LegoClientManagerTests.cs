using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using LegoSharp;

namespace LegoSharpTest
{
    [TestClass]
    public class LegoClientManagerTests
    {
        string username = PrivateConstants.testUsername;
        string password = PrivateConstants.testPassword;
        LegoClientManager testClientManager;

        [TestInitialize]
        public void setupTest()
        {
            testClientManager = new LegoClientManager();
        }

        [TestMethod]
        public void getAccountClientFromManager()
        {
            LegoAccount currUser = null;

            if (testClientManager.legoAccountClient.authenticate(username, password) == AuthenticationResult.Success)
            {
                currUser = testClientManager.legoAccountClient.getCurrentUser();
            }

            Assert.IsNotNull(currUser);
        }

        [TestMethod]
        public void getShopClientFromManager()
        {
            Brick brick = testClientManager.legoShopClient.getBrickByElementId("300321");

            Assert.IsNotNull(brick);
        }
    }
}
