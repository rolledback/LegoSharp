using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LegoSharp;
using LegoSharp.PickABrick;
using System.Linq;
using System.Reflection;

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

        [TestMethod]
        public async Task tryQueryWithEachColor()
        {
            LegoGraphClient graphClient = new LegoGraphClient();
            await graphClient.authenticateAsync();

            var colors = (BrickColor[])Enum.GetValues(typeof(BrickColor));

            for (int i = 0; i < colors.Length; i++)
            {
                BrickColor currColor = colors[i];

                PickABrickQuery query = new PickABrickQuery();
                query.addFilter(new ColorFilter()
                    .addValue(currColor)
                );

                await graphClient.pickABrick(query);
            }
        }

        [TestMethod]
        public async Task tryQueryWithEachCategory()
        {
            LegoGraphClient graphClient = new LegoGraphClient();
            await graphClient.authenticateAsync();

            var categories = (BrickCategory[])Enum.GetValues(typeof(BrickCategory));

            for (int i = 0; i < categories.Length; i++)
            {
                BrickCategory currCategory = categories[i];

                PickABrickQuery query = new PickABrickQuery();
                query.addFilter(new CategoryFilter()
                    .addValue(currCategory)
                );

                await graphClient.pickABrick(query);
            }
        }

        [TestMethod]
        public async Task noMissingColors()
        {
            LegoGraphClient graphClient = new LegoGraphClient();

            await graphClient.authenticateAsync();

            FacetScraper query = new FacetScraper();
            var facets = await graphClient.queryGraph(query);

            var colors = (BrickColor[])Enum.GetValues(typeof(BrickColor));
            var colorFilter = new ColorFilter();
            var colorFilterKey = colorFilter.key;

            var colorFacet = facets.FirstOrDefault(f => f.key == colorFilterKey);

            Assert.IsTrue(colorFacet != null, "No color facet");

            var missingCategories = new List<FacetLabel>();
            foreach (var label in colorFacet.labels)
            {
                try
                {
                    colors.First(c => colorFilter.filterEnumToName(c) == label.name && colorFilter.filterEnumToValue(c) == label.value);
                }
                catch (InvalidOperationException)
                {
                    missingCategories.Add(label);
                }
            }

            if (missingCategories.Count() > 0)
            {
                string err = "Missing colors exist:";
                foreach (var label in missingCategories)
                {
                    err += "\nname: " + label.name + ", value: " + label.value;
                }
                Assert.IsTrue(false, err);
            }
        }

        [TestMethod]
        public async Task noMissingCategories()
        {
            LegoGraphClient graphClient = new LegoGraphClient();

            await graphClient.authenticateAsync();

            FacetScraper query = new FacetScraper();
            var facets = await graphClient.queryGraph(query);

            var categories = (BrickCategory[])Enum.GetValues(typeof(BrickCategory));
            var categoryFilter = new CategoryFilter();
            var categoryFilterKey = categoryFilter.key;

            var categoriesFacet = facets.FirstOrDefault(f => f.key == categoryFilterKey);

            Assert.IsTrue(categoriesFacet != null, "No category facet");

            var missingCategories = new List<FacetLabel>();
            foreach (var label in categoriesFacet.labels)
            {
                try
                {
                    categories.First(c => categoryFilter.filterEnumToName(c) == label.name && categoryFilter.filterEnumToValue(c) == label.value);
                }
                catch (InvalidOperationException)
                {
                    missingCategories.Add(label);
                }
            }

            if (missingCategories.Count() > 0)
            {
                string err = "Missing categories exist:";
                foreach (var label in missingCategories)
                {
                    err += "\nname: " + label.name + ", value: " + label.value;
                }
                Assert.IsTrue(false, err);
            }
        }
    }
}
