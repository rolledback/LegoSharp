using System;
using System.Collections.Generic;
using System.Text;

namespace LegoSharp
{
    public class ProductPriceFilter : ProductSearchRangeFilter
    {
        public ProductPriceFilter() : base("variants.scopedPrice.currentValue.centAmount")
        {

        }
    }
}
