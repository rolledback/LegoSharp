using LegoSharp.PickABrick;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LegoSharp
{
    public class PickABrickQuery : IGraphQuery<PickABrickQueryResult>
    {
        public string query;
        public int page;
        public int perPage;

        public string endpoint { get; } = Constants.pickABrickUri;
        public Dictionary<string, IPickABrickFilter> _filters;

        public PickABrickQuery()
        {
            this._filters = new Dictionary<string, IPickABrickFilter>();
            this.page = 1;
            this.perPage = 12;
        }

        public void addFilter(IPickABrickFilter filter)
        {
            this._filters[filter.key] = filter;
        }

        public dynamic getPayload()
        {
            return new
            {
                operationName = "PickABrickQuery",
                variables = new
                {
                    page = 1,
                    perPage = 12,
                    query = this.query,
                    filters = this._getFiltersInQL()
                },
                query = Constants.pickABrickQuery
            };
        }

        private dynamic[] _getFiltersInQL()
        {
            dynamic[] returnValue = new object[this._filters.Count];

            var i = 0;
            foreach (KeyValuePair<string, IPickABrickFilter> entry in this._filters)
            {
                returnValue[i++] = new
                {
                    key = entry.Key,
                    values = entry.Value.getValues()
                };
            }

            return returnValue;
        }

        public PickABrickQueryResult parseResponse(string responseBody)
        {
            JsonElement parsedResponse = JsonSerializer.Deserialize<JsonElement>(responseBody);
            JsonElement data = parsedResponse.GetProperty("data");
            JsonElement elements = data.GetProperty("elements");
            JsonElement results = elements.GetProperty("results");
            JsonElement total = elements.GetProperty("total");

            var enumerator = results.EnumerateArray();
            var elementsList = new List<Brick>();

            while (enumerator.MoveNext())
            {
                JsonElement brickEl = enumerator.Current;
                elementsList.Add(JsonSerializer.Deserialize<Brick>(brickEl.ToString()));
            }

            return new PickABrickQueryResult(elementsList, JsonSerializer.Deserialize<int>(total.ToString()));
        }
    }
}
