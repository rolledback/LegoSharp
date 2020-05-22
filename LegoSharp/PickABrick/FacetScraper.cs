using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LegoSharp.PickABrick
{
    public class FacetScraper : IGraphQuery<IEnumerable<Facet>>
    {
        public string endpoint { get; } = Constants.pickABrickUri;

        public FacetScraper()
        {
        }

        public dynamic getPayload()
        {
            return new
            {
                operationName = "PickABrickQuery",
                variables = new
                {
                    page = 1,
                    perPage = 1,
                    query = "",
                    filters = new object[0]
                },
                query = Constants.pickABrickQuery
            };
        }

        public IEnumerable<Facet> parseResponse(string responseBody)
        {
            JsonElement parsedResponse = JsonSerializer.Deserialize<JsonElement>(responseBody);
            JsonElement data = parsedResponse.GetProperty("data");
            JsonElement elements = data.GetProperty("elements");
            JsonElement facets = elements.GetProperty("facets");

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
