using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using LegoSharp;

namespace LegoSharpTest
{
    [TestClass]
    public class LegoSharpTest
    {
        static LegoClient testClient;

        [TestInitialize]
        public void setupTests()
        {
            testClient = new LegoClient();
        }

        [TestMethod]
        public void getBrickByElementIdTest()
        {
            Console.WriteLine("getBrickByElementIdTest");

            string[] knownGoodElementIds = { "301021", "4211394", "301026",
                                             "300321", "4211387", "300326",
                                             "300121", "4211385", "300126"};

            foreach(string elementId in knownGoodElementIds)
            {
                Console.WriteLine("Getting: " + elementId);

                Brick result = testClient.getBrickByElementId(elementId);
                Assert.AreNotEqual(result, null);
                Assert.AreEqual(result.elementId, elementId);

                Console.WriteLine("Passed");
            }

            string[] knownBadElementIds = { "eafaf", "@@@@@@", "99999999" };

            foreach (string elementId in knownBadElementIds)
            {
                Console.WriteLine("Getting: " + elementId);

                Brick result = testClient.getBrickByElementId(elementId);
                Assert.AreEqual(result, null);

                Console.WriteLine("Passed");
            }
        }

        [TestMethod]
        public void getBricksByDesignIdTest()
        {
            Console.WriteLine("getBricksByDesignIdTest");

            string[] knownGoodDesignIds = { "3010", "3003", "3001" };

            foreach (string designId in knownGoodDesignIds)
            {
                Console.WriteLine("Getting: " + designId);

                BrickSearch brickSearch = new BrickSearch();
                brickSearch.setDesignId(designId);
                List<Brick> result = testClient.searchForBricks(brickSearch);
                Assert.IsTrue(result.Count > 0);

                Console.WriteLine("Passed");
            }

            string[] knownBadDesignIds = { "eafaf", "@@@@@@", "99999999" };

            foreach (string designId in knownBadDesignIds)
            {
                Console.WriteLine("Getting: " + designId);

                BrickSearch brickSearch = new BrickSearch();
                brickSearch.setDesignId(designId);
                List<Brick> result = testClient.searchForBricks(brickSearch);
                Assert.IsTrue(result.Count == 0);

                Console.WriteLine("Passed");
            }
        }

        [TestMethod]
        public void getBricksByNameTest()
        {
            Console.WriteLine("getBricksByNameTest");

            string[] knownGoodNames = { "brick 1x2", "BRICK 1x2"};

            foreach (string name in knownGoodNames)
            {
                Console.WriteLine("Getting: " + name);

                BrickSearch brickSearch = new BrickSearch();
                brickSearch.setName(name);
                List<Brick> result = testClient.searchForBricks(brickSearch);
                Assert.IsTrue(result.Count > 0);

                Console.WriteLine("Passed");
            }

            string[] knownBadNames = { "eafaf", "@@@@@@", "99999999" };

            foreach (string name in knownBadNames)
            {
                Console.WriteLine("Getting: " + name);

                BrickSearch brickSearch = new BrickSearch();
                brickSearch.setName(name);
                List<Brick> result = testClient.searchForBricks(brickSearch);
                Assert.IsTrue(result.Count == 0);

                Console.WriteLine("Passed");
            }
        }

        [TestMethod]
        public void getBricksByExactColorTest()
        {
            Console.WriteLine("getBricksByExactColorTest");

            ExactColor[] exactColorValues = (ExactColor[])Enum.GetValues(typeof(ExactColor));

            foreach(ExactColor exactColor in exactColorValues)
            {
                Console.WriteLine("Getting: " + exactColor.ToString());

                BrickSearch brickSearch = new BrickSearch();
                brickSearch.setExactColor(exactColor);
                List<Brick> result = testClient.searchForBricks(brickSearch);
                Assert.IsTrue(result.Count > 0);

                Console.WriteLine("Passed");
            }
        }

        [TestMethod]
        public void getBricksByCategoryTest()
        {
            Console.WriteLine("getBricksByCategoryTest");

            Category[] categoryValues = (Category[])Enum.GetValues(typeof(Category));

            foreach (Category category in categoryValues)
            {
                Console.WriteLine("Getting: " + category.ToString());

                BrickSearch brickSearch = new BrickSearch();
                brickSearch.setCategories(new List<Category>() { category });
                List<Brick> result = testClient.searchForBricks(brickSearch);
                Assert.IsTrue(result.Count > 0);

                Console.WriteLine("Passed");
            }
        }

        [TestMethod]
        public void emptySearchTest()
        {
            Console.WriteLine("emptySearchTest");

            BrickSearch brickSearch = new BrickSearch();
            List<Brick> result = testClient.searchForBricks(brickSearch);
            Assert.IsTrue(result.Count > 0);

            Console.WriteLine("Passed");
        }

        [TestMethod]
        public void multiParameterSearchTest()
        {
            Console.WriteLine("multiParameterSearchTest");

            BrickSearch brickSearchOne = new BrickSearch();
            brickSearchOne.setExactColor(ExactColor.BrightRed);
            brickSearchOne.setName("1x2");
            List<Brick> resultOne = testClient.searchForBricks(brickSearchOne);
            Assert.IsTrue(resultOne.Count > 0);

            BrickSearch brickSearchTwo = new BrickSearch();
            brickSearchTwo.setExactColor(ExactColor.Black);
            brickSearchTwo.setDesignId("3003");
            List<Brick> resultTwo = testClient.searchForBricks(brickSearchTwo);
            Assert.IsTrue(resultTwo.Count > 0);

            BrickSearch brickSearchThree = new BrickSearch();
            brickSearchThree.setName("2x2");
            brickSearchThree.setDesignId("3003");
            List<Brick> resultThree = testClient.searchForBricks(brickSearchThree);
            Assert.IsTrue(resultThree.Count > 0);

            BrickSearch brickSearchFour = new BrickSearch();
            brickSearchFour.setExactColor(ExactColor.Black);
            brickSearchFour.setName("2x2");
            brickSearchFour.setDesignId("3003");
            List<Brick> resultFour = testClient.searchForBricks(brickSearchFour);
            Assert.IsTrue(resultFour.Count > 0);

            Console.WriteLine("Passed");
        }

        [TestMethod]
        public void resultHasViewAllLinkTest()
        {
            JsonBrickList testList = new JsonBrickList();
            testList.links["view_all"] = new Dictionary<string, string>();
            testList.links["view_all"]["href"] = "/sh/rest/products/pab/elements?offset=0&limit=353&brick_name=Brick&match_criteria=all";
            Assert.AreEqual(Utilities.resultHasViewAllLink(testList), 353);
        }
    }
}
