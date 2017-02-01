using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using LegoSharp;

namespace LegoSharpTest
{
    [TestClass]
    public class ReadmeTests
    {
        string username = PrivateConstants.testUsername;
        string password = PrivateConstants.testPassword;

        [TestMethod]
        public void LegoSessionSection()
        {
            // create a lego session
            LegoSession session = new LegoSession();
        }

        [TestMethod]
        public void LegoShopClientSection()
        {
            // create a lego shop client
            LegoShopClient client = new LegoShopClient(new LegoSession());

            // get brick with element id of 300321
            Brick brick = client.getBrickByElementId("300321");

            /*
             * For anything other than finding bricks by element Id, use a BrickSearch object
             * to search for the bricks you want. All string related searches (names, category,
             * exact color, and color family) are case insensitive.
             */

            // get bricks with exact color black
            BrickSearch brickSearch = new BrickSearch();
            brickSearch.setExactColor("Black");
            List<Brick> result = client.searchForBricks(brickSearch);

            // get bricks with name containing "2x2"
            brickSearch = new BrickSearch();
            brickSearch.setName("2x2");
            result = client.searchForBricks(brickSearch);

            // get bricks with design id of 3003
            brickSearch = new BrickSearch();
            brickSearch.setDesignId("3003");
            result = client.searchForBricks(brickSearch);

            // get bricks with exact color black, name containing "2x2", and design id of 3003
            brickSearch = new BrickSearch();
            brickSearch.setExactColor("Black");
            brickSearch.setName("2x2");
            brickSearch.setDesignId("3003");
            result = client.searchForBricks(brickSearch);

            // get bricks in the black and red color families, in the plates category, and whose names contain "corner"
            brickSearch = new BrickSearch();
            brickSearch.setCategories(new string[] { "plates" });
            brickSearch.setColorFamilies(new string[] { "Red", "Blue" });
            brickSearch.setName("corner");
            result = client.searchForBricks(brickSearch);
        }

        [TestMethod]
        public void LegoAccountClientSection()
        {
            // create an account client
            LegoAccountClient client = new LegoAccountClient(new LegoSession());

            // attempt to authenticate using your username and password
            AuthenticationResult authenticationResult = client.authenticate(username, password);

            if (authenticationResult == AuthenticationResult.Success)
            {
                // if the authentication worked, then get the current user
                LegoAccount currUser = client.getCurrentUser();
            }
        }

        [TestMethod]
        public void LegoClientManagerSection()
        {
            // create a client manager
            LegoClientManager clientManager = new LegoClientManager();

            // the client manager will have one of each type of client
            LegoShopClient pickABrickClient = clientManager.legoShopClient;
            LegoAccountClient legoAccountClient = clientManager.legoAccountClient;
        }

    }
}
