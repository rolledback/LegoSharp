using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LegoSharp
{
    internal class Utilities
    {
        internal static string convertExactColorsToId(string exactColorName)
        {
            if (!string.IsNullOrEmpty(exactColorName))
            {
                return Constants.stringToExactColorId[exactColorName.ToLower()].ToString();
            }
            else
            {
                return "";
            }
        }

        internal static string convertCategoriesToIds(string[] categories)
        {
            string result = "";

            for (int i = 0; i < categories.Length; i++)
            {
                result += Constants.stringToCategoryId[categories[i].ToLower()].ToString() + ",";
            }

            if (result.Length > 0)
            {
                return result.Remove(result.Length - 1);
            }

            return result;
        }

        internal static string convertColorFamiliesToIds(string [] colorFamilies)
        {
            string result = "";

            for (int i = 0; i < colorFamilies.Length; i++)
            {
                result += Constants.stringToColorFamilyId[colorFamilies[i].ToLower()].ToString() + ",";
            }

            if (result.Length > 0)
            {
                return result.Remove(result.Length - 1);
            }

            return result;
        }

        internal static int resultHasViewAllLink(JsonBrickList result)
        {
            if (result.links.ContainsKey("view_all"))
            {
                Uri viewAllUri = new Uri(Constants.baseAddress + result.links["view_all"]["href"]);
                int neededLimit = int.Parse(HttpUtility.ParseQueryString(viewAllUri.Query).Get("limit"));
                return neededLimit;
            }
            else
            {
                return -1;
            }
        }
    }
}
