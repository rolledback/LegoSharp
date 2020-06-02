using System;
using System.Collections.Generic;
using System.Text;

namespace LegoSharp
{
    public class ProductPieceCountFilter : ProductSearchRangeFilter
    {
        public ProductPieceCountFilter() : base("variants.attributes.pieceCount")
        {

        }
    }
}
