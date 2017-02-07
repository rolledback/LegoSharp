using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoSharp
{
    class SetSearch: ISetSearch
    {
        private string searchQuery;

        Dictionary<string, string[]> searchParameters;

        public SetSearch()
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
}
