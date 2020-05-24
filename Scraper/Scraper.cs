using LegoSharp;
using System;
using System.Threading.Tasks;

namespace Scraper
{
    class Scraper
    {
        static async Task Main(string[] args)
        {
            LegoGraphClient client = new LegoGraphClient();
            await client.authenticateAsync();

            var scraper = new FacetScraper<ProductSearchQuery, dynamic>(new ProductSearchQuery(), new ProductSearchFacetExtractor());
            var facets = await client.queryGraph(scraper);

            foreach (var facet in facets)
            {
                Console.WriteLine(facet.key);
                foreach (var label in facet.labels)
                {
                        Console.WriteLine(label.name + "," + label.value + "," + label.key);
                }
                Console.WriteLine();
            }
        }
    }
}
