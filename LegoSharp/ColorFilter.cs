using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LegoSharp
{
    public class ColorFilter : LegoGraphFilter<LegoColor>
    {
        public ColorFilter() : base("variants.attributes.exactColour.en-US")
        {
        }

        public override string filterEnumToValue(LegoColor color)
        {
            switch (color)
            {
                case LegoColor.Black:
                    return "Black";
                case LegoColor.BrickYellow:
                    return "Brick Yellow";
                case LegoColor.BrightBlue:
                    return "Bright Blue";
                case LegoColor.BrightBluishGreen:
                    return "Bright Bluish Green";
                case LegoColor.BrightGreen:
                    return "Bright Green";
                case LegoColor.BrightOrange:
                    return "Bright Orange";
                case LegoColor.BrightPurple:
                    return "Bright Purple";
                case LegoColor.BrightRed:
                    return "Bright Red";
                case LegoColor.BrightReddishViolet:
                    return "Bright Reddish Violet";
                case LegoColor.BrightYellow:
                    return "Bright Yellow";
                case LegoColor.BrightYellowishGreen:
                    return "Bright Yellowish Green";
                case LegoColor.CoolYellow:
                    return "Cool Yellow";
                case LegoColor.DarkAzur:
                    return "Dark Azur";
                case LegoColor.DarkBrown:
                    return "Dark Brown";
                case LegoColor.DarkGreen:
                    return "Dark Green";
                case LegoColor.DarkOrange:
                    return "Dark Orange";
                case LegoColor.DarkStoneGrey:
                    return "Dark Stone Grey";
                case LegoColor.EarthBlue:
                    return "Earth Blue";
                case LegoColor.EarthGreen:
                    return "Earth Green";
                case LegoColor.FlameYellowishOrange:
                    return "Flame Yellowish Orange";
                case LegoColor.Lavender:
                    return "Lavender";
                case LegoColor.LightPurple:
                    return "Light Purple";
                case LegoColor.LightRoyalBlue:
                    return "Light Royal Blue";
                case LegoColor.MediumAzur:
                    return "Medium Azur";
                case LegoColor.MediumBlue:
                    return "Medium Blue";
                case LegoColor.MediumLavendel:
                    return "Medium Lavendel";
                case LegoColor.MediumLilac:
                    return "Medium Lilac";
                case LegoColor.MediumNougat:
                    return "Medium Nougat";
                case LegoColor.MediumStoneGrey:
                    return "Medium Stone Grey";
                case LegoColor.NewDarkRed:
                    return "New Dark Red";
                case LegoColor.OliveGreen:
                    return "Olive Green";
                case LegoColor.ReddishBrown:
                    return "Reddish Brown";
                case LegoColor.SandGreen:
                    return "Sand Green";
                case LegoColor.SandYellow:
                    return "Sand Yellow";
                case LegoColor.SilverMetallic:
                    return "Silver Metallic";
                case LegoColor.SpringYellowishGreen:
                    return "Spring Yellowish Green";
                case LegoColor.TitaniumMetallic:
                    return "Titanium Metallic";
                case LegoColor.TrBlue:
                    return "Tr. Blue";
                case LegoColor.TrBrightOrange:
                    return "Tr. Bright Orange";
                case LegoColor.TrBrown:
                    return "Tr. Brown";
                case LegoColor.TrFluoreReddOrange:
                    return "Tr. Fluore. Redd. Orange";
                case LegoColor.TrGreen:
                    return "Tr. Green";
                case LegoColor.TrLightBlue:
                    return "Tr. Light Blue";
                case LegoColor.TrMediumReddishViolet:
                    return "Tr. Medium Reddish Violet";
                case LegoColor.TrRed:
                    return "Tr. Red";
                case LegoColor.TrYellow:
                    return "Tr. Yellow";
                case LegoColor.Transparent:
                    return "Transparent";
                case LegoColor.WarmGold:
                    return "Warm Gold";
                case LegoColor.White:
                    return "White";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public override string filterEnumToName(LegoColor color)
        {
            switch (color)
            {
                case LegoColor.Black:
                    return "Black";
                case LegoColor.BrickYellow:
                    return "Brick Yellow";
                case LegoColor.BrightBlue:
                    return "Bright Blue";
                case LegoColor.BrightBluishGreen:
                    return "Bright Bluish Green";
                case LegoColor.BrightGreen:
                    return "Bright Green";
                case LegoColor.BrightOrange:
                    return "Bright Orange";
                case LegoColor.BrightPurple:
                    return "Bright Purple";
                case LegoColor.BrightRed:
                    return "Bright Red";
                case LegoColor.BrightReddishViolet:
                    return "Bright Reddish Violet";
                case LegoColor.BrightYellow:
                    return "Bright Yellow";
                case LegoColor.BrightYellowishGreen:
                    return "Bright Yellowish Green";
                case LegoColor.CoolYellow:
                    return "Cool Yellow";
                case LegoColor.DarkAzur:
                    return "Dark Azur";
                case LegoColor.DarkBrown:
                    return "Dark Brown";
                case LegoColor.DarkGreen:
                    return "Dark Green";
                case LegoColor.DarkOrange:
                    return "Dark Orange";
                case LegoColor.DarkStoneGrey:
                    return "Dark Stone Grey";
                case LegoColor.EarthBlue:
                    return "Earth Blue";
                case LegoColor.EarthGreen:
                    return "Earth Green";
                case LegoColor.FlameYellowishOrange:
                    return "Flame Yellowish Orange";
                case LegoColor.Lavender:
                    return "Lavender";
                case LegoColor.LightPurple:
                    return "Light Purple";
                case LegoColor.LightRoyalBlue:
                    return "Light Royal Blue";
                case LegoColor.MediumAzur:
                    return "Medium Azur";
                case LegoColor.MediumBlue:
                    return "Medium Blue";
                case LegoColor.MediumLavendel:
                    return "Medium Lavendel";
                case LegoColor.MediumLilac:
                    return "Medium Lilac";
                case LegoColor.MediumNougat:
                    return "Medium Nougat";
                case LegoColor.MediumStoneGrey:
                    return "Medium Stone Grey";
                case LegoColor.NewDarkRed:
                    return "New Dark Red";
                case LegoColor.OliveGreen:
                    return "Olive Green";
                case LegoColor.ReddishBrown:
                    return "Reddish Brown";
                case LegoColor.SandGreen:
                    return "Sand Green";
                case LegoColor.SandYellow:
                    return "Sand Yellow";
                case LegoColor.SilverMetallic:
                    return "Silver Metallic";
                case LegoColor.SpringYellowishGreen:
                    return "Spring Yellowish Green";
                case LegoColor.TitaniumMetallic:
                    return "Titanium Metallic";
                case LegoColor.TrBlue:
                    return "Tr. Blue";
                case LegoColor.TrBrightOrange:
                    return "Tr. Bright Orange";
                case LegoColor.TrBrown:
                    return "Tr. Brown";
                case LegoColor.TrFluoreReddOrange:
                    return "Tr. Fluore. Redd. Orange";
                case LegoColor.TrGreen:
                    return "Tr. Green";
                case LegoColor.TrLightBlue:
                    return "Tr. Light Blue";
                case LegoColor.TrMediumReddishViolet:
                    return "Tr. Medium Reddish Violet";
                case LegoColor.TrRed:
                    return "Tr. Red";
                case LegoColor.TrYellow:
                    return "Tr. Yellow";
                case LegoColor.Transparent:
                    return "Transparent";
                case LegoColor.WarmGold:
                    return "Warm Gold";
                case LegoColor.White:
                    return "White";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public enum LegoColor
    {
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
        TrBrightOrange,
        TrBrown,
        TrFluoreReddOrange,
        TrGreen,
        TrLightBlue,
        TrMediumReddishViolet,
        TrRed,
        TrYellow,
        Transparent,
        WarmGold,
        White
    }
}
