using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LegoSharp
{
    public class PickABrickQuery : GraphQuery<PickABrickResult>
    {
        public PickABrickQuery() : base(Constants.pickABrickUri, "PickABrickQuery", Constants.pickABrickQuery)
        {
        }

        public PickABrickQuery addFilter<ValuesFilterValueT>(PickABrickValuesFilter<ValuesFilterValueT> filter) where ValuesFilterValueT : ValuesFilterValue
        {
            this._addFilter(filter);
            return this;
        }

        public override PickABrickResult parseResponse(string responseBody)
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

            return new PickABrickResult(elementsList, JsonSerializer.Deserialize<int>(total.ToString()));
        }

        protected override dynamic _getVariables()
        {
            return new
            {
                page = this.page,
                perPage = this.perPage,
                query = this.query,
                filters = this._getFiltersInQL()
            };
        }
    }
}
