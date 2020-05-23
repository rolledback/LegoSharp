using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LegoSharp
{
    public class ProductSearchFacetExtractor : IFacetExtractor<ProductSearchQuery>
    {
        public IEnumerable<Facet> extractFacets(string responseBody)
        {
            JsonElement parsedResponse = JsonSerializer.Deserialize<JsonElement>(responseBody);
            JsonElement data = parsedResponse.GetProperty("data");
            JsonElement elements = data.GetProperty("search");
            JsonElement productResult = elements.GetProperty("productResult");
            JsonElement facets = productResult.GetProperty("facets");

            var enumerator = facets.EnumerateArray();
            var retValue = new List<Facet>();

            while (enumerator.MoveNext())
            {
                JsonElement facetEl = enumerator.Current;
                retValue.Add(JsonSerializer.Deserialize<Facet>(facetEl.ToString()));
            }

            return retValue;
        }
    }
}
