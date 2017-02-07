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
            this.categories = (string[])categoryNames.Clone();
        }

        public void setColorFamilies(string[] colorFamilyNames)
        {
            this.colorFamilies = (string[])colorFamilyNames.Clone();
        }

        public void setDesignId(string designId)
        {
            this.designId = designId;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public Dictionary<string, string> toParameterMap()
        {
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters["design_id"] = designId;
            parameters["exact_color"] = Utilities.convertExactColorsToId(exactColor);
            parameters["brick_name"] = name;
            parameters["categories"] = Utilities.convertCategoriesToIds(categories);
            parameters["color_families"] = Utilities.convertColorFamiliesToIds(colorFamilies);

            return parameters;
        }
    }
}
