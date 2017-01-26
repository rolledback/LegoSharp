using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using LegoSharp;

namespace LegoSharpTest
{
    [TestClass]
    public class PickABrickTests
    {
        static PickABrickClient testClient;
        static int totalBricksWithCategory;
        static int totalBricksWithExactColor;
        static int totalBricksWithColorFamily;
        static Random rnd = new Random();

        [TestInitialize]
        public void setupTest()
        {
            testClient = new PickABrickClient();
        }

        [TestMethod]
        public void allBricksSearchTest()
        {
            Console.WriteLine("allBricksSearchTest");

            BrickSearch brickSearch = new BrickSearch();
            List<Brick> result = testClient.searchForBricks(brickSearch);

            totalBricksWithCategory = 0;
            totalBricksWithExactColor = 0;
            totalBricksWithColorFamily = 0;

            Assert.IsTrue(result.Count > 0);

            Console.WriteLine("Total bricks found: " + result.Count);

            foreach (Brick brick in result)
            {
                if (!brick.category.Equals(""))
                {
                    Console.WriteLine("Checking for category: " + brick.category);
                    Assert.IsTrue(Constants.stringToCategoryId.ContainsKey(brick.category.ToLower()));
                    totalBricksWithCategory += 1;
                }
                if (!brick.exactColor.Equals(""))
                {
                    Console.WriteLine("Checking for exact color: " + brick.exactColor);
                    Assert.IsTrue(Constants.stringToExactColorId.ContainsKey(brick.exactColor.ToLower()));
                    totalBricksWithExactColor += 1;
                }
                if (!brick.colorFamily.Equals(""))
                {
                    Console.WriteLine("Checking for color family: " + brick.colorFamily);
                    Assert.IsTrue(Constants.stringToColorFamilyId.ContainsKey(brick.colorFamily.ToLower()));
                    totalBricksWithColorFamily += 1;
                }
            }

            Console.WriteLine("Passed");
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
        public void getBricksByCategoryTest()
        {
            Console.WriteLine("getBricksByCategoryTest");

            var categoryValues = Constants.stringToCategoryId.Keys;
            int numBricksFound = 0;

            foreach (string category in categoryValues)
            {
                Console.WriteLine("Getting: " + category.ToString());

                BrickSearch brickSearch = new BrickSearch();
                brickSearch.setCategories(new string[] { category });
                List<Brick> result = testClient.searchForBricks(brickSearch);
                numBricksFound += result.Count;

                Console.WriteLine("Passed");
            }

            if (totalBricksWithCategory > 0)
            {
                Assert.AreEqual(totalBricksWithCategory, numBricksFound);
            }
        }


        [TestMethod]
        public void getBricksByMultiCategoryTest()
        {
            Console.WriteLine("getBricksByMultiCategoryTest");

            int numCategories = 3;
            var categoryValues = new List<string>(Constants.stringToCategoryId.Keys);
            List<string> randomCategories = new List<string>(numCategories);

            for (int i = 0; i < numCategories; i++)
            {
                randomCategories.Add(categoryValues[rnd.Next(categoryValues.Count)]);
            } 

            BrickSearch brickSearch = new BrickSearch();
            brickSearch.setCategories(randomCategories.ToArray());
            List<Brick> result = testClient.searchForBricks(brickSearch);

            foreach (Brick brick in result)
            {
                Assert.IsTrue(randomCategories.Contains(brick.category.ToLower()));
            }

            Console.WriteLine("Passed");
        }

        [TestMethod]
        public void getBricksByExactColorTest()
        {
            Console.WriteLine("getBricksByExactColorTest");

            var exactColorValues = Constants.stringToExactColorId.Keys;
            int numBricksFound = 0;

            foreach(string exactColor in exactColorValues)
            {
                Console.WriteLine("Getting: " + exactColor.ToString());

                BrickSearch brickSearch = new BrickSearch();
                brickSearch.setExactColor(exactColor);
                List<Brick> result = testClient.searchForBricks(brickSearch);
                numBricksFound += result.Count;

                Console.WriteLine("Passed");
            }

            if (totalBricksWithExactColor > 0)
            {
                Assert.AreEqual(totalBricksWithCategory, numBricksFound);
            }
        }

        [TestMethod]
        public void getBricksByColorFamilyTest()
        {
            Console.WriteLine("getBricksByColorFamilyTest");

            var colorFamilyValues = Constants.stringToColorFamilyId.Keys;
            int numBricksFound = 0;

            foreach (string colorFamily in colorFamilyValues)
            {
                Console.WriteLine("Getting: " + colorFamily.ToString());

                BrickSearch brickSearch = new BrickSearch();
                brickSearch.setColorFamilies(new string[] { colorFamily });
                List<Brick> result = testClient.searchForBricks(brickSearch);
                numBricksFound += result.Count;

                Console.WriteLine("Passed");
            }

            if (totalBricksWithColorFamily > 0)
            {
                Assert.AreEqual(totalBricksWithColorFamily, numBricksFound);
            }
        }

        [TestMethod]
        public void getBricksByMultiColorFamilyTest()
        {
            Console.WriteLine("getBricksByMultiColorFamilyTest");

            int numColorFamilies = 3;
            var colorFamilyValues = new List<string>(Constants.stringToColorFamilyId.Keys);
            List<string> randomColorFamilies = new List<string>(numColorFamilies);

            for (int i = 0; i < numColorFamilies; i++)
            {
                randomColorFamilies.Add(colorFamilyValues[rnd.Next(colorFamilyValues.Count)]);
            }

            BrickSearch brickSearch = new BrickSearch();
            brickSearch.setColorFamilies(randomColorFamilies.ToArray());
            List<Brick> result = testClient.searchForBricks(brickSearch);

            foreach (Brick brick in result)
            {
                Assert.IsTrue(randomColorFamilies.Contains(brick.colorFamily.ToLower()));
            }

            Console.WriteLine("Passed");
        }

        [TestMethod]
        public void multiParameterSearchTest()
        {
            Console.WriteLine("multiParameterSearchTest");

            BrickSearch brickSearchOne = new BrickSearch();
            brickSearchOne.setExactColor("bright red");
            brickSearchOne.setName("1x2");
            brickSearchOne.setCategories(new string[] { "bricks", "interior" });
            List<Brick> resultOne = testClient.searchForBricks(brickSearchOne);
            Assert.IsTrue(resultOne.Count > 0);

            BrickSearch brickSearchTwo = new BrickSearch();
            brickSearchTwo.setExactColor("black");
            brickSearchTwo.setDesignId("3003");
            brickSearchTwo.setColorFamilies(new string[] { "black" });
            List<Brick> resultTwo = testClient.searchForBricks(brickSearchTwo);
            Assert.IsTrue(resultTwo.Count > 0);

            BrickSearch brickSearchThree = new BrickSearch();
            brickSearchThree.setName("2x2");
            brickSearchThree.setDesignId("3003");
            brickSearchThree.setCategories(new string[] { "bricks" });
            List<Brick> resultThree = testClient.searchForBricks(brickSearchThree);
            Assert.IsTrue(resultThree.Count > 0);

            BrickSearch brickSearchFour = new BrickSearch();
            brickSearchFour.setExactColor("black");
            brickSearchFour.setName("2x2");
            brickSearchFour.setDesignId("3003");
            List<Brick> resultFour = testClient.searchForBricks(brickSearchFour);
            Assert.IsTrue(resultFour.Count > 0);

            Console.WriteLine("Passed");
        }

        [TestMethod]
        public void resultHasViewAllLinkTest()
        {
            Console.WriteLine("resultHasViewAllLinkTest");

            JsonBrickList testList = new JsonBrickList();
            testList.links["view_all"] = new Dictionary<string, string>();
            testList.links["view_all"]["href"] = "/sh/rest/products/pab/elements?offset=0&limit=353&brick_name=Brick&match_criteria=all";
            Assert.AreEqual(Utilities.resultHasViewAllLink(testList), 353);

            Console.WriteLine("Passed");
        }

        [TestMethod]
        public void readmeCode()
        {
            // create a pick a brick client
            PickABrickClient client = new PickABrickClient();

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
            List<Brick> result = testClient.searchForBricks(brickSearch);

            // get bricks with name containing "2x2"
            brickSearch = new BrickSearch();
            brickSearch.setName("2x2");
            result = testClient.searchForBricks(brickSearch);

            // get bricks with design id of 3003
            brickSearch = new BrickSearch();
            brickSearch.setDesignId("3003");
            result = testClient.searchForBricks(brickSearch);

            // get bricks with exact color black, name containing "2x2", and design id of 3003
            brickSearch = new BrickSearch();
            brickSearch.setExactColor("Black");
            brickSearch.setName("2x2");
            brickSearch.setDesignId("3003");
            result = testClient.searchForBricks(brickSearch);

            // get bricks in the black and red color families, in the plates category, and whose names contain "corner"
            brickSearch = new BrickSearch();
            brickSearch.setCategories(new string[] { "plates" });
            brickSearch.setColorFamilies(new string[] { "Red", "Blue" });
            brickSearch.setName("corner");
            result = testClient.searchForBricks(brickSearch);
        }
    }
}
