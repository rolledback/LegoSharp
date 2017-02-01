using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Newtonsoft.Json;

namespace LegoSharp
{
    public class LegoShopper
    {
        [JsonProperty("username")]
        public string username { get; set; }

        [JsonProperty("lid_public_user_id")]
        public string legoIdUserId { get; set; }

        [JsonProperty("isVipUser")]
        public bool isVipUser { get; set; }
    }
}
