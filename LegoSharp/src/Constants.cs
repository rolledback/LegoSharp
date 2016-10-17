using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoSharp
{
    internal class Constants
    {
        public static readonly string baseAddress = "https://shop.lego.com/";

        public static readonly string oAuthUri = "oauth/accessToken?api_version=1&accept_language=en-US";
        public static readonly string elementsUri = "sh/rest/products/pab/elements?api_version=1&accept_language=en-US";

        public static readonly Dictionary<string, int> stringToCategoryId = new Dictionary<string, int>()
        {
            {"bricks", 1},
            {"bricks, special", 2},
            {"bricks, special circles and angles", 3},
            {"bricks, special ø4.85 hole and connecting bush", 4},
            {"bricks, with slope", 5},
            {"bricks with bows and arches", 7},
            {"bricks with special bows and angles", 8},
            {"beams", 10},
            {"beams, special", 11},
            {"beams w/ ball and ball cup", 13},
            {"plates", 15},
            {"plates, special", 16},
            {"plates, special circles and angles", 17},
            {"half beams", 20},
            {"half beams, special", 21},
            {"frames, windows, walls and doors", 25},
            {"gates and roofs", 26},
            {"interior", 27},
            {"botanic", 28},
            {"fences and ladders", 35},
            {"signs, flags and poles", 36},
            {"figure parts", 40},
            {"figure, heads and masks", 42},
            {"figure, wigs", 43},
            {"figure, head clothing", 44},
            {"figure accessories, upper and lower part", 45},
            {"figure accessories in hand", 46},
            {"figure, weapons", 47},
            {"foodstuff", 49},
            {"figure accessories, upper and lower body", 53},
            {"animals and creatures", 59},
            {"tyres and rims for snap ø3,2", 65},
            {"tyres and rims for/to snap ø4,85 w. cross", 66},
            {"tyres and rims, special", 67},
            {"wheel base", 68},
            {"transportation means, vehicles", 72},
            {"transportation means, trains", 74},
            {"transportation means, aviation", 75},
            {"crains and scaffold", 76},
            {"windscreens and cockpits", 77},
            {"decoration elements", 81},
            {"connectors", 85},
            {"functional elements", 86},
            {"functional elements, others", 87},
            {"functional elements, gear wheels and racks", 88},
            {"rubbers and strings", 90},
            {"tubes", 91}
        };

        public static readonly Dictionary<int, string> categoryIdToString = stringToCategoryId.ToDictionary(x => x.Value, x => x.Key);

        public static readonly Dictionary<string, int> stringToExactColorId = new Dictionary<string, int>
        {
            {"white", 1},
            {"brick yellow", 5},
            {"bright red", 21},
            {"bright blue", 23},
            {"bright yellow", 24},
            {"black", 26},
            {"dark green", 28},
            {"1.multicombination", 30},
            {"bright green", 37},
            {"dark orange", 38},
            {"transparent", 40},
            {"tr. red", 41},
            {"tr. light blue", 42},
            {"tr. blue", 43},
            {"tr. yellow", 44},
            {"tr. fluore.redd. orange", 47},
            {"tr. green", 48},
            {"tr. fluore. green", 49},
            {"medium blue", 102},
            {"bright orange", 106},
            {"tr. brown", 111},
            {"tr.medium reddish violet", 113},
            {"bright yellowish green", 119},
            {"bright reddish violet", 124},
            {"sand yellow", 138},
            {"earth blue", 140},
            {"earth green", 141},
            {"tr.fluore. blue", 143},
            {"sand green", 151},
            {"new dark red", 154},
            {"tr. bright orange", 182},
            {"flame yellowish orange", 191},
            {"reddish brown", 192},
            {"medium stone grey", 194},
            {"dark stone grey", 199},
            {"bright purple", 221},
            {"light purple", 222},
            {"cool yellow", 226},
            {"medium lilac", 268},
            {"warm gold", 297},
            {"dark brown", 308},
            {"medium nougat", 312},
            {"silver metallic", 315},
            {"titanium metallic", 316},
            {"dark azur", 321},
            {"medium azur", 322},
            {"medium lavendel", 324},
            {"spring yellowish green", 326},
            {"olive green", 330}
        };

        public static readonly Dictionary<int, string> exactColorIdToString = stringToExactColorId.ToDictionary(x => x.Value, x => x.Key);

        public static readonly Dictionary<string, int> stringToColorFamilyId = new Dictionary<string, int>
        {
            {"white", 1},
            {"brown", 12},
            {"red", 21},
            {"blue", 23},
            {"yellow", 24},
            {"black", 26},
            {"dark green", 28},
            {"bright orange", 106},
            {"reddish brown", 192},
            {"grey", 194},
            {"purple", 221},
            {"lilac", 268},
            {"warm gold", 297},
            {"silver", 315}
        };

        public static readonly Dictionary<int, string> colorFamilyIdToString = stringToExactColorId.ToDictionary(x => x.Value, x => x.Key);
    }
}
