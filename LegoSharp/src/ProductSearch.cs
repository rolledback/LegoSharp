using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace LegoSharp
{
    internal class ProductSearch: IProductSearch
    {
        private string searchQuery;

        Dictionary<string, string[]> searchParameters;

        public ProductSearch()
        {
            searchParameters = new Dictionary<string, string[]>();
        }

        public void setAvailability(string[] availabilities)
        {
            searchParameters["availability"] = (string[])availabilities.Clone();
        }

        public void setAgeRange(string[] ageRanges)
        {
            searchParameters["age-range"] = (string[])ageRanges.Clone();
        }

        public void setProductFlags(string[] productFlags)
        {
            searchParameters["product-flags"] = (string[])productFlags.Clone();
        }

        public void setDeptName(string[] deptNames)
        {
            searchParameters["deptname"] = (string[])deptNames.Clone();
        }

        public void setPieceRange(string[] pieceRanges)
        {
            searchParameters["piece-range"] = (string[])pieceRanges.Clone();
        }

        public void setPriceRange(string[] priceRanges)
        {
            searchParameters["price-range"] = (string[])priceRanges.Clone();
        }

        public void setRateRange(string[] rateRanges)
        {
            searchParameters["rate-range"] = (string[])rateRanges.Clone();
        }

        public void setSearchQuery(string query)
        {
            searchQuery = query;
        }

        public Dictionary<string, string> toParameterMap()
        {
            Dictionary<string, string> formattedParameters = new Dictionary<string, string>();

            int numParams = 0;
            foreach (KeyValuePair<string, string[]> param in searchParameters)
            {
                if (param.Value != null && param.Value.Length > 0)
                {
                    formattedParameters["q" + ++numParams] = string.Join("|", param.Value.ToList().Select(i => i.Replace(' ', '+')));
                    formattedParameters["x" + numParams] = param.Key;
                }
            }

            formattedParameters["q"] = string.IsNullOrEmpty(searchQuery) ? "*" : searchQuery;

            return formattedParameters;
        }
    }

    internal class ProductSearchResult
    {
        [JsonProperty("results")]
        public List<Product> results { get; set; }
    }

    public class Product
    {
        [JsonProperty("name_html")]
        public string nameHtml { get; set; }

        [JsonProperty("_links")]
        public Dictionary<string, Dictionary<string, string>> links { get; set; }

        [JsonProperty("media")]
        public string mediaLink { get; set; }

        [JsonProperty("product_code")]
        public string productCode { get; set; }

        [JsonProperty("product_type")]
        public string productType { get; set; }

        [JsonProperty("piece_count")]
        public string pieceCount { get; set; }

        [JsonProperty("rating")]
        public string rating { get; set; }
    }
}
