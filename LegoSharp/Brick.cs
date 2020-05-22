using System;
using System.Collections.Generic;
using System.Text;

namespace LegoSharp
{
    public class Brick
    {
        public string id { get; set; }
        public string name { get; set; }
        public string primaryImage { get; set; }
        public Variant variant { get; set; }
    }

    public class Variant
    {
        public string id { get; set; }
        public VariantAttributes attributes { get; set; }
        public VariantPrice price { get; set; }
    }

    public class VariantAttributes
    {
        public string colour { get; set; }
        public string colourFamily { get; set; }
    }

    public class VariantPrice
    {
        public int centAmount { get; set; }
        public string currencyCode { get; set; }
    }
}
