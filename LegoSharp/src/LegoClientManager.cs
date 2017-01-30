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
        public PickABrickClient pickABrickClient { get; }
        public LegoAccountClient legoAccountClient { get; }

        public LegoClientManager()
        {
            legoSession = new LegoSession();
            pickABrickClient = new PickABrickClient(legoSession);
            legoAccountClient = new LegoAccountClient(legoSession);
        }
    }
}
