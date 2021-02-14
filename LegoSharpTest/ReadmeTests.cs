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
    public class ReadmeTests
    {
        [TestMethod]
        public async Task pickABrickExample()
        {
            LegoGraphClient graphClient = new LegoGraphClient();

            PickABrickQuery query = new PickABrickQuery();
            query.addFilter(new BrickColorFilter()
                .addValue(BrickColor.Black)
            );
            query.query = "wheel";

            PickABrickResult result = await graphClient.pickABrick(query);
            foreach (Brick brick in result.elements)
            {
                // do something with each brick
            }
        }

        [TestMethod]
        public async Task productSearchExample()
        {
            LegoGraphClient graphClient = new LegoGraphClient();

            ProductSearchQuery query = new ProductSearchQuery();
            query.addFilter(new ProductTypeFilter()
                .addValue(ProductType.Sets)
            );
            query.addFilter(new ProductPriceFilter()
                .fromTo(1000, 2500)
            );
            query.query = "train";

            ProductSearchResult result = await graphClient.productSearch(query);
            foreach (Product product in result.products)
            {
                // do something with each product
            }
        }

        [TestMethod]
        public async Task facetScrapingExample()
        {
            FacetScraper<ProductSearchQuery, ProductSearchResult> facetScraper = new FacetScraper<ProductSearchQuery, ProductSearchResult>(new List<ProductSearchQuery> { new ProductSearchQuery() }, new ProductSearchFacetExtractor());
            ISet<FacetLabel> facetLabels = await facetScraper.scrapeFacet("variants.attributes.flags.key", "product.facet.flags");
            IDictionary<string, ISet<FacetLabel>> facets = await facetScraper.scrapeFacets();
        }
    }
}
