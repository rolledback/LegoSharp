using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LegoSharp
{
    public class BrickColorFamilyFilter : PickABrickValuesFilter<BrickColorFamily>
    {
        public BrickColorFamilyFilter() : base("variants.attributes.colourFamily.en-US", "element.facet.colourFamily")
        {
        }
    }

    public class BrickColorFamily : ValuesFilterValue
    {
        public BrickColorFamily(string value, string name) : base(value, name)
        {
        }

        public static readonly BrickColorFamily Black = new BrickColorFamily("Black", "Black");
        public static readonly BrickColorFamily Blue = new BrickColorFamily("Blue", "Blue");
        public static readonly BrickColorFamily BrightOrange = new BrickColorFamily("Bright Orange", "Bright Orange");
        public static readonly BrickColorFamily DarkGreen = new BrickColorFamily("Dark Green", "Dark Green");
        public static readonly BrickColorFamily Grey = new BrickColorFamily("Grey", "Grey");
        public static readonly BrickColorFamily Lilac = new BrickColorFamily("Lilac", "Lilac");
        public static readonly BrickColorFamily Purple = new BrickColorFamily("Purple", "Purple");
        public static readonly BrickColorFamily Red = new BrickColorFamily("Red", "Red");
        public static readonly BrickColorFamily ReddishBrown = new BrickColorFamily("Reddish Brown", "Reddish Brown");
        public static readonly BrickColorFamily Silver = new BrickColorFamily("Silver", "Silver");
        public static readonly BrickColorFamily WarmGold = new BrickColorFamily("Warm Gold", "Warm Gold");
        public static readonly BrickColorFamily White = new BrickColorFamily("White", "White");
        public static readonly BrickColorFamily Yellow = new BrickColorFamily("Yellow", "Yellow");
    }
}
