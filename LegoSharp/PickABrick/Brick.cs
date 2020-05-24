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
        public BrickVariant variant { get; set; }
    }

    public class BrickVariant
    {
        public string id { get; set; }
        public BrickVariantAttributes attributes { get; set; }
        public BrickVariantPrice price { get; set; }
    }

    public class BrickVariantAttributes
    {
        public string colour { get; set; }
        public string colourFamily { get; set; }
    }

    public class BrickVariantPrice
    {
        public int centAmount { get; set; }
        public string currencyCode { get; set; }
    }
}
