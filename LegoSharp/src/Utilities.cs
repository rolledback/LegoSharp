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
    }
}
