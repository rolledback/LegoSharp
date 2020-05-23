using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LegoSharp
{
    public class PickABrickQuery : GraphQuery<PickABrickQueryResult>
    {
        public PickABrickQuery() : base(Constants.pickABrickUri, "PickABrickQuery", Constants.pickABrickQuery)
        {
        }

        public void addFilter(QueryFilter<BrickCategory> filter)
        {
            this._addFilter(filter);
        }

        public void addFilter(QueryFilter<BrickColorFamily> filter)
        {
            this._addFilter(filter);
        }

        public void addFilter(QueryFilter<BrickColor> filter)
        {
            this._addFilter(filter);
        }

        public void addFilter<FilterEnumT>(PickABrickFilter<FilterEnumT> filter)
        {
            this._addFilter(filter);
        }

        public override PickABrickQueryResult parseResponse(string responseBody)
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
