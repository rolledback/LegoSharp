using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoSharp
{
    public interface IBrickSearch
    {
        void setExactColor(string colorName);

        void setCategories(string[] categoryNames);

        void setColorFamilies(string[] colorFamilyNames);

        void setDesignId(string designId);

        void setName(string name);

        Dictionary<string, string> toParameterMap();
    }
}
