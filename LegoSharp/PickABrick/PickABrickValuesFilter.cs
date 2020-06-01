using System;
using System.Collections.Generic;
using System.Text;

namespace LegoSharp
{
    public abstract class PickABrickValuesFilter<FilterEnumT> : QueryValuesFilter<FilterEnumT>
    {
        public PickABrickValuesFilter(string facetKey, string facetId) : base(facetKey, facetId)
        {

        }

        public PickABrickValuesFilter<FilterEnumT> addValue(FilterEnumT value)
        {
            this._addValue(value);
            return this;
        }
    }
}
