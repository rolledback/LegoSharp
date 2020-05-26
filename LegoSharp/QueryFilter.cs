using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LegoSharp
{
    public abstract class QueryFilter<FilterEnumT> : IQueryFilter
    {
        public string facetKey { get; }
        public string facetId { get; }

        protected List<FilterEnumT> _values;

        public QueryFilter(string facetKey, string facetId)
        {
            this._values = new List<FilterEnumT>();
            this.facetKey = facetKey;
            this.facetId = facetId;
        }

        public QueryFilter<FilterEnumT> addValue(FilterEnumT value)
        {
            this._values.Add(value);
            return this;
        }

        public IEnumerable<string> getValues()
        {
            return from v in this._values select this.filterEnumToValue(v);
        }

        public abstract string filterEnumToValue(FilterEnumT value);

        public abstract string filterEnumToName(FilterEnumT value);
    }
}
