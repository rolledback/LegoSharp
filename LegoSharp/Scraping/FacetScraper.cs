using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LegoSharp.PickABrick
{
    public class FacetScraper<GraphQueryResultT> : IGraphQuery<IEnumerable<Facet>>
    {
        public string endpoint { get; } = Constants.pickABrickUri;

        private IGraphQuery<GraphQueryResultT> _queryToScrape;

        public FacetScraper(IGraphQuery<GraphQueryResultT> queryToScrape)
        {
            this._queryToScrape = queryToScrape;
        }

        public dynamic getPayload()
        {
            return this._queryToScrape.getPayload();
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
