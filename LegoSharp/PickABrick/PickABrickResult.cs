using System;
using System.Collections.Generic;
using System.Text;

namespace LegoSharp
{
    public class PickABrickResult : EnumerableQueryResult<Brick>
    {
        public PickABrickResult(IEnumerable<Brick> items, int total) : base(items, total)
        {
        }
    }
}
