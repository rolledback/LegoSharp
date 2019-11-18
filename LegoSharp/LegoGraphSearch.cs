using System;
using System.Collections.Generic;
using System.Text;

namespace LegoSharp
{
    public class LegoGraphSearch
    {
        public string query;

        public Dictionary<string, ILegoGraphFilter> _filters;

        public LegoGraphSearch()
        {
            this._filters = new Dictionary<string, ILegoGraphFilter>();
        }

        public void addFilter(ILegoGraphFilter filter)
        {
            this._filters[filter.getKey()] = filter;
        }

        public dynamic[] getFiltersInQL()
        {
            dynamic[] returnValue = new object[this._filters.Count];

            var i = 0;
            foreach (KeyValuePair<string, ILegoGraphFilter> entry in this._filters)
            {
                returnValue[i++] = new
                {
                    key = entry.Key,
                    values = entry.Value.getValues()
                };
            }

            return returnValue;
        }
    }
}
