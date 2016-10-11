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

            foreach(string elementId in knownGoodElementIds) {
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
                List<Brick> result = testClient.getBricksByDesignId(designId);

                Assert.IsTrue(result.Count > 0);
                Console.WriteLine("Passed");
            }

            string[] knownBadDesignIds = { "eafaf", "@@@@@@", "99999999" };

            foreach (string designId in knownBadDesignIds)
            {
                Console.WriteLine("Getting: " + designId);
                List<Brick> result = testClient.getBricksByDesignId(designId);

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
                List<Brick> result = testClient.getBricksByName(name);

                Assert.IsTrue(result.Count > 0);
                Console.WriteLine("Passed");
            }

            string[] knownBadNames = { "eafaf", "@@@@@@", "99999999" };

            foreach (string name in knownBadNames)
            {
                Console.WriteLine("Getting: " + name);
                List<Brick> result = testClient.getBricksByName(name);

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
                List<Brick> result = testClient.getBricksByExactColor(exactColor);

                Assert.IsTrue(result.Count >= 0);
                Console.WriteLine("Passed");
            }
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
