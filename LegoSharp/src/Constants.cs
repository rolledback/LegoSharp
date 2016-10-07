using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoSharp
{
    internal class Constants
    {
        public const string baseAddress = "https://shop.lego.com/";

        public const string oAuthUri = "oauth/accessToken?api_version=1&accept_language=en-US";
        public const string getBrickUri = "sh/rest/products/pab/elements?api_version=1&accept_language=en-US";
    }
}
