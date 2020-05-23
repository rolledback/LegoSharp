using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LegoSharp
{
    public class ProductSearchQuery : GraphQuery<dynamic>
    {
        public ProductSearchQuery() : base(Constants.productSearchUri, "SearchQuery", Constants.productSearchQuery)
        {
        }

        public override dynamic parseResponse(string responseBody)
        {
            JsonElement parsedResponse = JsonSerializer.Deserialize<JsonElement>(responseBody);
            JsonElement data = parsedResponse.GetProperty("data");

            return null;
        }

        protected override dynamic _getVariables()
        {
            return new
            {
                isPaginated = true,
                hideTargetedSelections = true,
                page = this.page,
                perPage = this.perPage,
                q = this.query,
                filters = this._getFiltersInQL(),
                sort = new
                {
                    direction = "ASC",
                    key = "RELEVANCE"
                },
                visibility = new
                {
                    includeFreeProducts = false,
                    includeRetiredProducts = true
                }
            };
        }
    }
}
