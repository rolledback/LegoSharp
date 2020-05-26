using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LegoSharp
{
    public class BrickColorFilter : PickABrickFilter<BrickColor>
    {
        public BrickColorFilter() : base("variants.attributes.exactColour.en-US", "element.facet.colour")
        {
        }

        public override string filterEnumToValue(BrickColor color)
        {
            switch (color)
            {
                case BrickColor.Aqua:
                    return "Aqua";
                case BrickColor.Black:
                    return "Black";
                case BrickColor.BrickYellow:
                    return "Brick Yellow";
                case BrickColor.BrightBlue:
                    return "Bright Blue";
                case BrickColor.BrightBluishGreen:
                    return "Bright Bluish Green";
                case BrickColor.BrightGreen:
                    return "Bright Green";
                case BrickColor.BrightOrange:
                    return "Bright Orange";
                case BrickColor.BrightPurple:
                    return "Bright Purple";
                case BrickColor.BrightRed:
                    return "Bright Red";
                case BrickColor.BrightReddishViolet:
                    return "Bright Reddish Violet";
                case BrickColor.BrightYellow:
                    return "Bright Yellow";
                case BrickColor.BrightYellowishGreen:
                    return "Bright Yellowish Green";
                case BrickColor.CoolYellow:
                    return "Cool Yellow";
                case BrickColor.DarkAzur:
                    return "Dark Azur";
                case BrickColor.DarkBrown:
                    return "Dark Brown";
                case BrickColor.DarkGreen:
                    return "Dark Green";
                case BrickColor.DarkOrange:
                    return "Dark Orange";
                case BrickColor.DarkStoneGrey:
                    return "Dark Stone Grey";
                case BrickColor.EarthBlue:
                    return "Earth Blue";
                case BrickColor.EarthGreen:
                    return "Earth Green";
                case BrickColor.FlameYellowishOrange:
                    return "Flame Yellowish Orange";
                case BrickColor.Lavender:
                    return "Lavender";
                case BrickColor.LightPurple:
                    return "Light Purple";
                case BrickColor.LightRoyalBlue:
                    return "Light Royal Blue";
                case BrickColor.MediumAzur:
                    return "Medium Azur";
                case BrickColor.MediumBlue:
                    return "Medium Blue";
                case BrickColor.MediumLavendel:
                    return "Medium Lavender";
                case BrickColor.MediumLilac:
                    return "Medium Lilac";
                case BrickColor.MediumNougat:
                    return "Medium Nougat";
                case BrickColor.MediumStoneGrey:
                    return "Medium Stone Grey";
                case BrickColor.NewDarkRed:
                    return "New Dark Red";
                case BrickColor.OliveGreen:
                    return "Olive Green";
                case BrickColor.ReddishBrown:
                    return "Reddish Brown";
                case BrickColor.SandGreen:
                    return "Sand Green";
                case BrickColor.SandYellow:
                    return "Sand Yellow";
                case BrickColor.SilverMetallic:
                    return "Silver Metallic";
                case BrickColor.SpringYellowishGreen:
                    return "Spring Yellowish Green";
                case BrickColor.TitaniumMetallic:
                    return "Titanium Metallic";
                case BrickColor.TrBlue:
                    return "Tr. Blue";
                case BrickColor.TrBrightGreen:
                    return "Tr. Bright Green";
                case BrickColor.TrBrightOrange:
                    return "Tr. Bright Orange";
                case BrickColor.TrBrown:
                    return "Tr. Brown";
                case BrickColor.TrFluoreReddOrange:
                    return "Tr. Fluore. Redd. Orange";
                case BrickColor.TrGreen:
                    return "Tr. Green";
                case BrickColor.TrLightBlue:
                    return "Tr. Light Blue";
                case BrickColor.TrMediumReddishViolet:
                    return "Tr. Medium Reddish Violet";
                case BrickColor.TrRed:
                    return "Tr. Red";
                case BrickColor.TrYellow:
                    return "Tr. Yellow";
                case BrickColor.Transparent:
                    return "Transparent";
                case BrickColor.WarmGold:
                    return "Warm Gold";
                case BrickColor.White:
                    return "White";
                case BrickColor.VibrantCoral:
                    return "Vibrant Coral";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override string filterEnumToName(BrickColor color)
        {
            switch (color)
            {
                case BrickColor.Aqua:
                    return "Aqua";
                case BrickColor.Black:
                    return "Black";
                case BrickColor.BrickYellow:
                    return "Brick Yellow";
                case BrickColor.BrightBlue:
                    return "Bright Blue";
                case BrickColor.BrightBluishGreen:
                    return "Bright Bluish Green";
                case BrickColor.BrightGreen:
                    return "Bright Green";
                case BrickColor.BrightOrange:
                    return "Bright Orange";
                case BrickColor.BrightPurple:
                    return "Bright Purple";
                case BrickColor.BrightRed:
                    return "Bright Red";
                case BrickColor.BrightReddishViolet:
                    return "Bright Reddish Violet";
                case BrickColor.BrightYellow:
                    return "Bright Yellow";
                case BrickColor.BrightYellowishGreen:
                    return "Bright Yellowish Green";
                case BrickColor.CoolYellow:
                    return "Cool Yellow";
                case BrickColor.DarkAzur:
                    return "Dark Azur";
                case BrickColor.DarkBrown:
                    return "Dark Brown";
                case BrickColor.DarkGreen:
                    return "Dark Green";
                case BrickColor.DarkOrange:
                    return "Dark Orange";
                case BrickColor.DarkStoneGrey:
                    return "Dark Stone Grey";
                case BrickColor.EarthBlue:
                    return "Earth Blue";
                case BrickColor.EarthGreen:
                    return "Earth Green";
                case BrickColor.FlameYellowishOrange:
                    return "Flame Yellowish Orange";
                case BrickColor.Lavender:
                    return "Lavender";
                case BrickColor.LightPurple:
                    return "Light Purple";
                case BrickColor.LightRoyalBlue:
                    return "Light Royal Blue";
                case BrickColor.MediumAzur:
                    return "Medium Azur";
                case BrickColor.MediumBlue:
                    return "Medium Blue";
                case BrickColor.MediumLavendel:
                    return "Medium Lavender";
                case BrickColor.MediumLilac:
                    return "Medium Lilac";
                case BrickColor.MediumNougat:
                    return "Medium Nougat";
                case BrickColor.MediumStoneGrey:
                    return "Medium Stone Grey";
                case BrickColor.NewDarkRed:
                    return "New Dark Red";
                case BrickColor.OliveGreen:
                    return "Olive Green";
                case BrickColor.ReddishBrown:
                    return "Reddish Brown";
                case BrickColor.SandGreen:
                    return "Sand Green";
                case BrickColor.SandYellow:
                    return "Sand Yellow";
                case BrickColor.SilverMetallic:
                    return "Silver Metallic";
                case BrickColor.SpringYellowishGreen:
                    return "Spring Yellowish Green";
                case BrickColor.TitaniumMetallic:
                    return "Titanium Metallic";
                case BrickColor.TrBlue:
                    return "Tr. Blue";
                case BrickColor.TrBrightGreen:
                    return "Tr. Bright Green";
                case BrickColor.TrBrightOrange:
                    return "Tr. Bright Orange";
                case BrickColor.TrBrown:
                    return "Tr. Brown";
                case BrickColor.TrFluoreReddOrange:
                    return "Tr. Fluore. Redd. Orange";
                case BrickColor.TrGreen:
                    return "Tr. Green";
                case BrickColor.TrLightBlue:
                    return "Tr. Light Blue";
                case BrickColor.TrMediumReddishViolet:
                    return "Tr. Medium Reddish Violet";
                case BrickColor.TrRed:
                    return "Tr. Red";
                case BrickColor.TrYellow:
                    return "Tr. Yellow";
                case BrickColor.Transparent:
                    return "Transparent";
                case BrickColor.WarmGold:
                    return "Warm Gold";
                case BrickColor.White:
                    return "White";
                case BrickColor.VibrantCoral:
                    return "Vibrant Coral";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public enum BrickColor
    {
        Aqua,
        Black,
        BrickYellow,
        BrightBlue,
        BrightBluishGreen,
        BrightGreen,
        BrightOrange,
        BrightPurple,
        BrightRed,
        BrightReddishViolet,
        BrightYellow,
        BrightYellowishGreen,
        CoolYellow,
        DarkAzur,
        DarkBrown,
        DarkGreen,
        DarkOrange,
        DarkStoneGrey,
        EarthBlue,
        EarthGreen,
        FlameYellowishOrange,
        Lavender,
        LightPurple,
        LightRoyalBlue,
        MediumAzur,
        MediumBlue,
        MediumLavendel,
        MediumLilac,
        MediumNougat,
        MediumStoneGrey,
        NewDarkRed,
        OliveGreen,
        ReddishBrown,
        SandGreen,
        SandYellow,
        SilverMetallic,
        SpringYellowishGreen,
        TitaniumMetallic,
        TrBlue,
        TrBrightGreen,
        TrBrightOrange,
        TrBrown,
        TrFluoreReddOrange,
        TrGreen,
        TrLightBlue,
        TrMediumReddishViolet,
        TrRed,
        TrYellow,
        Transparent,
        VibrantCoral,
        WarmGold,
        White
    }
}
