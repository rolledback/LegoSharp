using System;
using System.Collections.Generic;
using System.Text;

namespace LegoSharp
{
    public class Product
    {
        public string id { get; set; }
        public string productCode { get; set; }
        public string name { get; set; }
        public string primaryImage { get; set; }
        public ProductVariant variant { get; set; }
    }

    public class ProductVariant
    {
        public string id { get; set; }
        public ProductVariantAttributes attributes { get; set; }
        public ProductVariantPrice price { get; set; }
    }

    public class ProductVariantAttributes
    {
        public string availabilityStatus { get; set; }
        public string vipAvailabilityStatus { get; set; }
    }

    public class ProductVariantPrice
    {
        public int centAmount { get; set; }
        public string currencyCode { get; set; }
    }
}
