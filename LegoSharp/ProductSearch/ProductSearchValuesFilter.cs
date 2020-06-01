using System;
using System.Collections.Generic;
using System.Text;

namespace LegoSharp
{
    public abstract class ProductSearchValuesFilter<FilterEnumT> : QueryValuesFilter<FilterEnumT>
    {
        public ProductSearchValuesFilter(string facetKey, string facetId) : base(facetKey, facetId)
        {

        }

        public ProductSearchValuesFilter<FilterEnumT> addValue(FilterEnumT value)
        {
            this.addValue(value);
            return this;
        }
    }
}
