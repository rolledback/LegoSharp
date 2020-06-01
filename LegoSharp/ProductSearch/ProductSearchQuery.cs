using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LegoSharp
{
    public class ProductSearchQuery : GraphQuery<ProductSearchResult>
    {
        public ProductSearchQuery() : base(Constants.productSearchUri, "SearchQuery", Constants.productSearchQuery)
        {
        }

        public void addFilter<FilterEnumT>(ProductSearchValuesFilter<FilterEnumT> filter)
        {
            this._addFilter(filter);
        }

        public override ProductSearchResult parseResponse(string responseBody)
        {
            JsonElement parsedResponse = JsonSerializer.Deserialize<JsonElement>(responseBody);
            JsonElement data = parsedResponse.GetProperty("data");
            JsonElement search = data.GetProperty("search");
            JsonElement productResult = search.GetProperty("productResult");
            JsonElement results = productResult.GetProperty("results");
            JsonElement total = productResult.GetProperty("total");

            var enumerator = results.EnumerateArray();
            var productList = new List<Product>();

            while (enumerator.MoveNext())
            {
                JsonElement product = enumerator.Current;
                productList.Add(JsonSerializer.Deserialize<Product>(product.ToString()));
            }

            return new ProductSearchResult(productList, JsonSerializer.Deserialize<int>(total.ToString()));
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
