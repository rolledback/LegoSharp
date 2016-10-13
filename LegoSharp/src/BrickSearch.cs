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
        private List<Category> categories;

        public BrickSearch()
        {
            exactColor = 0;
            designId = "";
            name = "";
            categories = new List<Category>();
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

        public void setCategories(List<Category> categories)
        {
            this.categories = categories;
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

        public List<Category> getCategories()
        {
            return categories;
        }
    }
}
