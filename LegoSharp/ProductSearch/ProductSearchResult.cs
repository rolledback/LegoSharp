using System;
using System.Collections.Generic;
using System.Text;

namespace LegoSharp
{
    public class ProductSearchResult : EnumerableQueryResult<Product>
    {

        public ProductSearchResult(IEnumerable<Product> items, int total) : base(items, total)
        {
        }
    }
}
