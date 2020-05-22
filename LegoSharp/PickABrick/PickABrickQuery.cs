using System;
using System.Collections.Generic;
using System.Text;

namespace LegoSharp
{
    public class PickABrickQuery
    {
        public string query;

        public Dictionary<string, IPickABrickFilter> _filters;

        public PickABrickQuery()
        {
            this._filters = new Dictionary<string, IPickABrickFilter>();
        }

        public void addFilter(IPickABrickFilter filter)
        {
            this._filters[filter.getKey()] = filter;
        }

        public dynamic[] getFiltersInQL()
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
    }
}
