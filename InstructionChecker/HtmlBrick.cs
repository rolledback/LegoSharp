using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstructionChecker
{
    public class HtmlBrick
    {
        public string id { get; }
        public int quantity { get; }
        public string name { get; }

        public HtmlBrick(string id, int quantity, string name)
        {
            this.id = id;
            this.quantity = quantity;
            this.name = name;
        }

        public override string ToString()
        {
            return string.Format("Id: {0}, Quantity: {1}, Name: {2}", id, quantity, name);
        }
    }
}
