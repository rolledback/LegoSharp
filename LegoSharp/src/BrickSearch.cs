using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoSharp
{
    public class BrickSearch: IBrickSearch
    {
        private string exactColor;
        private string designId;
        private string name;
        private string[] categories;
        private string[] colorFamilies;

        public BrickSearch()
        {
            exactColor = "";
            designId = "";
            name = "";
            categories = new string[0];
            colorFamilies = new string[0];
        }

        public void setExactColor(string colorName)
        {
            this.exactColor = colorName;
        }

        public void setCategories(string[] categoryNames)
        {
            this.categories = new string[categoryNames.Length];

            for (int i = 0; i < categoryNames.Length; i++)
            {
                categories[i] = categoryNames[i];
            }
        }

        public void setColorFamilies(string[] colorFamilyNames)
        {
            this.colorFamilies = new string[colorFamilyNames.Length];

            for (int i = 0; i < colorFamilyNames.Length; i++)
            {
                colorFamilies[i] = colorFamilyNames[i];
            }
        }

        public void setDesignId(string designId)
        {
            this.designId = designId;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public string getExactColor()
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

        public string[] getCategories()
        {
            return categories;
        }

        public string[] getColorFamilies()
        {
            return colorFamilies;
        }
    }
}
