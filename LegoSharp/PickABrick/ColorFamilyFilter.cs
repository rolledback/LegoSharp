using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LegoSharp
{
    public class ColorFamilyFilter : PickABrickFilter<BrickColorFamily>
    {
        public ColorFamilyFilter() : base("variants.attributes.colourFamily.en-US")
        {
        }

        public override string filterEnumToValue(BrickColorFamily color)
        {
            switch (color)
            {
                case BrickColorFamily.Black:
                    return "Black";
                case BrickColorFamily.Blue:
                    return "Blue";
                case BrickColorFamily.BrightOrange:
                    return "Bright Orange";
                case BrickColorFamily.DarkGreen:
                    return "Dark Green";
                case BrickColorFamily.Grey:
                    return "Grey";
                case BrickColorFamily.Lilac:
                    return "Lilac";
                case BrickColorFamily.Purple:
                    return "Purple";
                case BrickColorFamily.Red:
                    return "Red";
                case BrickColorFamily.ReddishBrown:
                    return "Reddish Brown";
                case BrickColorFamily.Silver:
                    return "Silver";
                case BrickColorFamily.WarmGold:
                    return "Warm Gold";
                case BrickColorFamily.White:
                    return "White";
                case BrickColorFamily.Yellow:
                    return "Yellow";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override string filterEnumToName(BrickColorFamily color)
        {
            switch (color)
            {
                case BrickColorFamily.Black:
                    return "Black";
                case BrickColorFamily.Blue:
                    return "Blue";
                case BrickColorFamily.BrightOrange:
                    return "Bright Orange";
                case BrickColorFamily.DarkGreen:
                    return "Dark Green";
                case BrickColorFamily.Grey:
                    return "Grey";
                case BrickColorFamily.Lilac:
                    return "Lilac";
                case BrickColorFamily.Purple:
                    return "Purple";
                case BrickColorFamily.Red:
                    return "Red";
                case BrickColorFamily.ReddishBrown:
                    return "Reddish Brown";
                case BrickColorFamily.Silver:
                    return "Silver";
                case BrickColorFamily.WarmGold:
                    return "Warm Gold";
                case BrickColorFamily.White:
                    return "White";
                case BrickColorFamily.Yellow:
                    return "Yellow";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public enum BrickColorFamily
    {
        Black,
        Blue,
        BrightOrange,
        DarkGreen,
        Grey,
        Lilac,
        Purple,
        Red,
        ReddishBrown,
        Silver,
        WarmGold,
        White,
        Yellow
    }
}
