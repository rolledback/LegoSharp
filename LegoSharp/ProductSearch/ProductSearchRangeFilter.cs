using System;
using System.Collections.Generic;
using System.Text;

namespace LegoSharp
{
    public class ProductSearchRangeFilter : QueryRangeFilter
    {
        public ProductSearchRangeFilter(string facetKey) : base(facetKey)
        {

        }

        public ProductSearchRangeFilter fromTo(int from, int to)
        {
            this._fromTo(from, to);
            return this;
        }
    }
}
