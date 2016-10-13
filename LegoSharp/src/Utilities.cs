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

        internal static string categoryListToString(List<Category> categoryList)
        {
            string result = "";

            categoryList.ForEach(item => result += ((int)item).ToString() + ",");

            if (result.Length > 0)
            {
                return result.Remove(result.Length - 1);
            }

            return result;
        }

        internal static string exactColorToString(ExactColor color)
        {
            return color <= 0 ? "" : ((int)color).ToString();
        }
    }
}
