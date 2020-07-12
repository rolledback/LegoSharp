using System;
using System.Collections.Generic;
using System.Text;

namespace LegoSharp
{
    public struct ScrapedFacetLabel
    {
        public string value;
        public string name;
        public string enumField;
    }

    public class ScrapedFacetLabelComparaer : IEqualityComparer<ScrapedFacetLabel>
    {
        public bool Equals(ScrapedFacetLabel a, ScrapedFacetLabel b)
        {
            return a.value == b.value && a.name == b.name && a.enumField == b.enumField;
        }
        public int GetHashCode(ScrapedFacetLabel t)
        {
            string code = t.value + "," + t.name + "," + t.enumField;
            return code.GetHashCode();
        }
    }
}
