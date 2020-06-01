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

        public void addFilter(QueryValuesFilter<BrickCategory> filter)
        {
            this._addFilter(filter);
        }

        public void addFilter(QueryValuesFilter<BrickColorFamily> filter)
        {
            this._addFilter(filter);
        }

        public void addFilter(QueryValuesFilter<BrickColor> filter)
        {
            this._addFilter(filter);
        }

        public void addFilter<FilterEnumT>(PickABrickFilter<FilterEnumT> filter)
        {
            this._addFilter(filter);
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
