using System;
using System.Collections.Generic;
using System.Text;

namespace LegoSharp
{
    public class EnumerableQueryResult<ItemT>
    {
        public readonly IEnumerable<ItemT> items;
        public readonly int total;

        public EnumerableQueryResult(IEnumerable<ItemT> items, int total)
        {
            this.items = items;
            this.total = total;
        }
    }
}
