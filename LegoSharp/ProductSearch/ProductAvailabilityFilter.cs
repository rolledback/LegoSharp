using System;
using System.Collections.Generic;
using System.Text;

namespace LegoSharp
{
    public class ProductAvailabilityFilter : ProductSearchValuesFilter<ProductAvailability>
    {
        public ProductAvailabilityFilter() : base("variants.attributes.availabilityStatus.zxx-US", "product.facet.availability")
        {
        }
    }

    public class ProductAvailability : ValuesFilterValue
    {
        public ProductAvailability(string value, string name) : base(value, name)
        {
        }

        public static readonly ProductAvailability AvailableNow = new ProductAvailability("\"A_PRE_ORDER_FOR_DATE\",\"C_PRE_ORDER\",\"E_AVAILABLE\"", "Available Now");
        public static readonly ProductAvailability BackOrder = new ProductAvailability("\"F_BACKORDER_FOR_DATE\",\"G_BACKORDER\"", "Back Order");
        public static readonly ProductAvailability ComingSoon = new ProductAvailability("\"B_COMING_SOON_AT_DATE\",\"D_COMING_SOON\"", "Coming Soon");
        public static readonly ProductAvailability OutOfStock = new ProductAvailability("\"H_OUT_OF_STOCK\",\"K_SOLD_OUT\",\"L_READ_ONLY\"", "Out of Stock");
        public static readonly ProductAvailability RetiredProduct = new ProductAvailability("\"R_RETIRED\"", "Retired Product");

    }
}
