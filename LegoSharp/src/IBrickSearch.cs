using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegoSharp
{
    public interface IBrickSearch
    {
        void setExactColor(ExactColor color);

        void setDesignId(string designId);

        void setName(string name);

        void setCategories(List<Category> categories);

        ExactColor getExactColor();

        string getDesignId();

        string getName();

        List<Category> getCategories();
    }
}
