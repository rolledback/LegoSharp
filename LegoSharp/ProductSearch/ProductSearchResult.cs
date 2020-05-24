using System;
using System.Collections.Generic;
using System.Text;

namespace LegoSharp
{
    public class ProductSearchResult
    {
        public IEnumerable<Product> products;
        public int total;

        public ProductSearchResult(IEnumerable<Product> products, int total)
        {
            this.products = products;
            this.total = total;
        }
    }
}
