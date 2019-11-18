using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LegoSharp
{
    public class ColorFilter : LegoGraphFilter<LegoColor>
    {
        public ColorFilter() : base("variants.attributes.colourFamily.en-US")
        {
        }

        public override IEnumerable<string> getValues()
        {
            return from v in this._values select ColorFilter._colorToString(v);
        }

        private static string _colorToString(LegoColor color)
        {
            switch(color)
            {
                case LegoColor.Black:
                    return "Black";
                case LegoColor.Blue:
                    return "Blue";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public enum LegoColor
    {
        Black = 0,
        Blue = 1
    }
}
