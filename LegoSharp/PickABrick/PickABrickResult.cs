using System;
using System.Collections.Generic;
using System.Text;

namespace LegoSharp
{
    public class PickABrickResult
    {
        public IEnumerable<Brick> elements;
        public int total;

        public PickABrickResult(IEnumerable<Brick> elements, int total)
        {
            this.elements = elements;
            this.total = total;
        }
    }
}
