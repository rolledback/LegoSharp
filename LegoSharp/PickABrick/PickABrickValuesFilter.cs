using System;
using System.Collections.Generic;
using System.Text;

namespace LegoSharp
{
    public abstract class PickABrickValuesFilter<ValuesFilterValueT> : QueryValuesFilter<ValuesFilterValueT> where ValuesFilterValueT : ValuesFilterValue
    {
        public PickABrickValuesFilter(string facetKey, string facetId) : base(facetKey, facetId)
        {

        }

        public PickABrickValuesFilter<ValuesFilterValueT> addValue(ValuesFilterValueT value)
        {
            this._addValue(value);
            return this;
        }
    }
}
