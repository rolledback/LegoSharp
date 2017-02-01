using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoSharp
{
    public class LegoClientManager
    {
        public LegoSession legoSession { get; }
        public LegoShopClient legoShopClient { get; }
        public LegoAccountClient legoAccountClient { get; }

        public LegoClientManager()
        {
            legoSession = new LegoSession();
            legoShopClient = new LegoShopClient(legoSession);
            legoAccountClient = new LegoAccountClient(legoSession);
        }
    }
}
