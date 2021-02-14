using System;
using System.Collections.Generic;
using System.Text;

namespace LegoSharp
{
    public abstract class ProductSearchValuesFilter<ValuesFilterValueT> : QueryValuesFilter<ValuesFilterValueT> where ValuesFilterValueT : ValuesFilterValue
    {
        public ProductSearchValuesFilter(string facetKey, string facetId) : base(facetKey, facetId)
        {

        }

        public new ProductSearchValuesFilter<ValuesFilterValueT> addValue(ValuesFilterValueT value)
        {
            this._addValue(value);
            return this;
        }
    }
}
