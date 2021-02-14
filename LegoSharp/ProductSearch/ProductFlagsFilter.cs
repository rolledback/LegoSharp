using System;
using System.Collections.Generic;
using System.Text;

namespace LegoSharp
{
    public class ProductFlagsFilter : ProductSearchValuesFilter<ProductFlag>
    {
        public ProductFlagsFilter() : base("variants.attributes.flags.key", "product.facet.flags")
        {
        }
    }

    public class ProductFlag : ValuesFilterValue
    {
        public ProductFlag(string value, string name) : base(value, name)
        {
        }

        public static readonly ProductFlag Exclusives = new ProductFlag("exclusive", "Exclusives");
        public static readonly ProductFlag HardToFind = new ProductFlag("hardToFind", "Hard to find");
        public static readonly ProductFlag LimitedEdition = new ProductFlag("limitedEdition", "Limited Edition");
        public static readonly ProductFlag New = new ProductFlag("new", "New");
        public static readonly ProductFlag RetiringSoon = new ProductFlag("retiringSoon", "Retiring soon");
    }
}
