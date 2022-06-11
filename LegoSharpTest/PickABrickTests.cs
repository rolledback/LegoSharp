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
    public class PickABrickTests
    {
        [TestMethod]
        public async Task tryQueryWithEachColor()
        {
            await TestUtils.tryQueryWithEachFilterValue<PickABrickQuery, PickABrickResult, Brick, BrickColorFilter, BrickColor>();
        }

        [TestMethod]
        public async Task tryQueryWithEachCategory()
        {
            await TestUtils.tryQueryWithEachFilterValue<PickABrickQuery, PickABrickResult, Brick, BrickCategoryFilter, BrickCategory>();
        }

        [TestMethod]
        public async Task tryQueryWithEachColorFamily()
        {
            await TestUtils.tryQueryWithEachFilterValue<PickABrickQuery, PickABrickResult, Brick, BrickColorFamilyFilter, BrickColorFamily>();
        }

        [TestMethod]
        public async Task noMissingColors()
        {
            await TestUtils.noMissingFilterValues<PickABrickQuery, PickABrickResult, Brick, BrickColorFilter, BrickColor, PickABrickFacetExtractor>("pick a brick - color");
        }

        [TestMethod]
        public async Task noMissingCategories()
        {
            await TestUtils.noMissingFilterValues<PickABrickQuery, PickABrickResult, Brick, BrickCategoryFilter, BrickCategory, PickABrickFacetExtractor>("pick a brick - category");
        }

        [TestMethod]
        public async Task noMissingColorFamilies()
        {
            await TestUtils.noMissingFilterValues<PickABrickQuery, PickABrickResult, Brick, BrickColorFamilyFilter, BrickColorFamily, PickABrickFacetExtractor>("pick a brick - color family");
        }
    }
}
