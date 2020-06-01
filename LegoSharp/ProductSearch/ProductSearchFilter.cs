using System;
using System.Collections.Generic;
using System.Text;

namespace LegoSharp
{
    public abstract class ProductSearchFilter<FilterEnumT> : QueryValuesFilter<FilterEnumT>
    {
        public ProductSearchFilter(string facetKey, string facetId) : base(facetKey, facetId)
        {

        }
    }
}
