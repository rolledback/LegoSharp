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
            var queries = new List<ProductSearchQuery>();
            queries.Add(new ProductSearchQuery());

            var enumValues = (ProductType[])Enum.GetValues(typeof(ProductType));
            foreach (var enumValue in enumValues)
            {
                var queryByEnumValue = new ProductSearchQuery();
                queryByEnumValue.query = new ProductTypeFilter().filterEnumToValue(enumValue);
                queries.Add(queryByEnumValue);

                var queryByEnumName = new ProductSearchQuery();
                queryByEnumName.query = new ProductTypeFilter().filterEnumToName(enumValue);
                queries.Add(queryByEnumName);
            }

            FacetScraper<ProductSearchQuery, ProductSearchResult> test = new FacetScraper<ProductSearchQuery, ProductSearchResult>(queries, new ProductSearchFacetExtractor());
            var result = await test.scrapeFacet<ProductTypeFilter>(new ProductTypeFilter().facetId, new ProductTypeFilter().facetKey);
            foreach (var label in result)
            {
                Console.WriteLine(label.name + " " + label.value);
            }
        }
    }
}
