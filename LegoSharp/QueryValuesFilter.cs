using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LegoSharp
{
    public abstract class QueryValuesFilter<FilterEnumT> : IQueryFilter
    {
        public string facetKey { get; }
        public string facetId { get; }

        protected List<FilterEnumT> _values;

        public QueryValuesFilter(string facetKey, string facetId)
        {
            this._values = new List<FilterEnumT>();
            this.facetKey = facetKey;
            this.facetId = facetId;
        }

        public dynamic getQueryLangValue()
        {
            return new
            {
                key = this.facetKey,
                values = from v in this._values select this.filterEnumToValue(v)
            };
        }
        protected void _addValue(FilterEnumT value)
        {
            this._values.Add(value);
        }

        public abstract string filterEnumToValue(FilterEnumT value);

        public abstract string filterEnumToName(FilterEnumT value);
    }
}
