using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoSharp
{
    public class BrickSearch: IBrickSearch
    {
        private ExactColor exactColor;
        private string designId;
        private string name;

        public BrickSearch()
        {
            exactColor = ExactColor.Undefined;
            designId = "";
            name = "";
        }

        public void setExactColor(ExactColor color)
        {
            this.exactColor = color;
        }

        public void setDesignId(string designId)
        {
            this.designId = designId;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public ExactColor getExactColor()
        {
            return exactColor;
        }

        public string getDesignId()
        {
            return designId;
        }

        public string getName()
        {
            return name;
        }
    }
}
