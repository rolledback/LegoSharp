using System;
using System.Collections.Generic;
using System.Text;

namespace LegoSharp
{
    public abstract class QueryRangeFilter : IQueryFilter
    {
        public string facetKey { get; }

        protected int _from;
        protected int _to;

        public QueryRangeFilter(string facetKey)
        {
            this._from = 0;
            this._to = 0;
            this.facetKey = facetKey;
        }

        protected void _fromTo(int from, int to)
        {
            this._from = from;
            this._to = to;
        }

        public dynamic getQueryLangValue()
        {
            return new
            {
                key = this.facetKey,
                ranges = new[]
                {
                    new
                    {
                        from = this._from.ToString(),
                        to = this._to.ToString()
                    }
                }
            };
        }
    }
}
