using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LegoSharp
{
    public abstract class QueryValuesFilter<ValuesFilterValueT> : IQueryFilter where ValuesFilterValueT : ValuesFilterValue
    {
        public string facetKey { get; }
        public string facetId { get; }

        protected List<ValuesFilterValueT> _values;

        public QueryValuesFilter(string facetKey, string facetId)
        {
            this._values = new List<ValuesFilterValueT>();
            this.facetKey = facetKey;
            this.facetId = facetId;
        }

        public dynamic getQueryLangValue()
        {
            return new
            {
                key = this.facetKey,
                values = from v in this._values select v.value
            };
        }
        protected void _addValue(ValuesFilterValueT value)
        {
            this._values.Add(value);
        }
    }
}
