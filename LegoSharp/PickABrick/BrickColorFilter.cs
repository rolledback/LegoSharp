using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LegoSharp
{
    public class BrickColorFilter : PickABrickValuesFilter<BrickColor>
    {
        public BrickColorFilter() : base("variants.attributes.exactColour.en-US", "element.facet.colour")
        {
        }
    }

    public class BrickColor : ValuesFilterValue
    {

        public BrickColor(string value, string name) : base(value, name)
        {
        }

        public static readonly BrickColor Aqua = new BrickColor("Aqua", "Aqua");
        public static readonly BrickColor Black = new BrickColor("Black", "Black");
        public static readonly BrickColor BrickYellow = new BrickColor("Brick Yellow", "Brick Yellow");
        public static readonly BrickColor BrightBlue = new BrickColor("Bright Blue", "Bright Blue");
        public static readonly BrickColor BrightBluishGreen = new BrickColor("Bright Bluish Green", "Bright Bluish Green");
        public static readonly BrickColor BrightGreen = new BrickColor("Bright Green", "Bright Green");
        public static readonly BrickColor BrightOrange = new BrickColor("Bright Orange", "Bright Orange");
        public static readonly BrickColor BrightPurple = new BrickColor("Bright Purple", "Bright Purple");
        public static readonly BrickColor BrightRed = new BrickColor("Bright Red", "Bright Red");
        public static readonly BrickColor BrightReddishViolet = new BrickColor("Bright Reddish Violet", "Bright Reddish Violet");
        public static readonly BrickColor BrightYellow = new BrickColor("Bright Yellow", "Bright Yellow");
        public static readonly BrickColor BrightYellowishGreen = new BrickColor("Bright Yellowish Green", "Bright Yellowish Green");
        public static readonly BrickColor CoolYellow = new BrickColor("Cool Yellow", "Cool Yellow");
        public static readonly BrickColor DarkAzur = new BrickColor("Dark Azur", "Dark Azur");
        public static readonly BrickColor DarkBrown = new BrickColor("Dark Brown", "Dark Brown");
        public static readonly BrickColor DarkGreen = new BrickColor("Dark Green", "Dark Green");
        public static readonly BrickColor DarkOrange = new BrickColor("Dark Orange", "Dark Orange");
        public static readonly BrickColor DarkStoneGrey = new BrickColor("Dark Stone Grey", "Dark Stone Grey");
        public static readonly BrickColor EarthBlue = new BrickColor("Earth Blue", "Earth Blue");
        public static readonly BrickColor EarthGreen = new BrickColor("Earth Green", "Earth Green");
        public static readonly BrickColor FlameYellowishOrange = new BrickColor("Flame Yellowish Orange", "Flame Yellowish Orange");
        public static readonly BrickColor Lavender = new BrickColor("Lavender", "Lavender");
        public static readonly BrickColor LightPurple = new BrickColor("Light Purple", "Light Purple");
        public static readonly BrickColor LightRoyalBlue = new BrickColor("Light Royal Blue", "Light Royal Blue");
        public static readonly BrickColor MediumAzur = new BrickColor("Medium Azur", "Medium Azur");
        public static readonly BrickColor MediumBlue = new BrickColor("Medium Blue", "Medium Blue");
        public static readonly BrickColor MediumLavendel = new BrickColor("Medium Lavender", "Medium Lavender");
        public static readonly BrickColor MediumLilac = new BrickColor("Medium Lilac", "Medium Lilac");
        public static readonly BrickColor MediumNougat = new BrickColor("Medium Nougat", "Medium Nougat");
        public static readonly BrickColor MediumStoneGrey = new BrickColor("Medium Stone Grey", "Medium Stone Grey");
        public static readonly BrickColor NewDarkRed = new BrickColor("New Dark Red", "New Dark Red");
        public static readonly BrickColor OliveGreen = new BrickColor("Olive Green", "Olive Green");
        public static readonly BrickColor ReddishBrown = new BrickColor("Reddish Brown", "Reddish Brown");
        public static readonly BrickColor SandGreen = new BrickColor("Sand Green", "Sand Green");
        public static readonly BrickColor SandYellow = new BrickColor("Sand Yellow", "Sand Yellow");
        public static readonly BrickColor SilverMetallic = new BrickColor("Silver Metallic", "Silver Metallic");
        public static readonly BrickColor SpringYellowishGreen = new BrickColor("Spring Yellowish Green", "Spring Yellowish Green");
        public static readonly BrickColor TitaniumMetallic = new BrickColor("Titanium Metallic", "Titanium Metallic");
        public static readonly BrickColor Transparent = new BrickColor("Transparent", "Transparent");
        public static readonly BrickColor TrBlue = new BrickColor("Tr. Blue", "Tr. Blue");
        public static readonly BrickColor TrBrightGreen = new BrickColor("Tr. Bright Green", "Tr. Bright Green");
        public static readonly BrickColor TrBrightOrange = new BrickColor("Tr. Bright Orange", "Tr. Bright Orange");
        public static readonly BrickColor TrBrown = new BrickColor("Tr. Brown", "Tr. Brown");
        public static readonly BrickColor TrFluoreReddOrange = new BrickColor("Tr. Fluore. Redd. Orange", "Tr. Fluore. Redd. Orange");
        public static readonly BrickColor TrGreen = new BrickColor("Tr. Green", "Tr. Green");
        public static readonly BrickColor TrLightBlue = new BrickColor("Tr. Light Blue", "Tr. Light Blue");
        public static readonly BrickColor TrMediumReddishViolet = new BrickColor("Tr. Medium Reddish Violet", "Tr. Medium Reddish Violet");
        public static readonly BrickColor TrRed = new BrickColor("Tr. Red", "Tr. Red");
        public static readonly BrickColor TrYellow = new BrickColor("Tr. Yellow", "Tr. Yellow");
        public static readonly BrickColor VibrantCoral = new BrickColor("Vibrant Coral", "Vibrant Coral");
        public static readonly BrickColor WarmGold = new BrickColor("Warm Gold", "Warm Gold");
        public static readonly BrickColor White = new BrickColor("White", "White");
    }
}
