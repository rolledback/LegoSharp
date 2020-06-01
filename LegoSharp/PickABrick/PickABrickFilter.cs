using System;
using System.Collections.Generic;
using System.Text;

namespace LegoSharp
{
    public abstract class PickABrickFilter<FilterEnumT> : QueryValuesFilter<FilterEnumT>
    {
        public PickABrickFilter(string facetKey, string facetId) : base(facetKey, facetId)
        {

        }
    }
}
