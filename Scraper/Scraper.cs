using LegoSharp;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Scraper
{
    class Scraper
    {
        static async Task Main(string[] args)
        {
            foreach (var entry in await (new FacetScraper<ProductSearchQuery, ProductSearchResult>(new List<ProductSearchQuery> { new ProductSearchQuery() }, new ProductSearchFacetExtractor())).scrapeFacets())
            {
                Console.WriteLine(entry.Key);
                foreach (var label in entry.Value)
                {
                    Console.WriteLine(label.name + " " + label.value);
                }
                Console.WriteLine();
            }

            Console.WriteLine("\n-----------------------------------------\n");

            foreach (var entry in await (new FacetScraper<PickABrickQuery, PickABrickResult>(new List<PickABrickQuery> { new PickABrickQuery() }, new PickABrickFacetExtractor())).scrapeFacets())
            {
                Console.WriteLine(entry.Key);
                foreach (var label in entry.Value)
                {
                    Console.WriteLine(label.name + " " + label.value);
                }
                Console.WriteLine();
            }
        }
    }
}
