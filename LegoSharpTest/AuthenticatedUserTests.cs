using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using LegoSharp;

namespace LegoSharpTest
{
    [TestClass]
    public class AuthenticatedUserTests
    {
        string username = PrivateConstants.testUsername;
        string password = PrivateConstants.testPassword;
        LegoClientManager testClientManager;
        LegoAccountClient accountClient;
        LegoShopClient shopClient;

        [TestInitialize]
        public void setupTest()
        {
            testClientManager = new LegoClientManager();
            testClientManager.legoAccountClient.authenticate(username, password);

            accountClient = testClientManager.legoAccountClient;
            shopClient = testClientManager.legoShopClient;
        }

        [TestMethod]
        public void getShoppingBasketAuthenticated()
        {
            shopClient.getShoppingBasket();
        }

        [TestMethod]
        public void getCurrentShopperAuthenticated()
        {
            LegoShopper shopper = shopClient.getCurrentShopper();
            Assert.IsNotNull(shopper);
            Assert.IsNotNull(shopper.username);
            Assert.IsNotNull(shopper.legoIdUserId);
        }
    }
}
