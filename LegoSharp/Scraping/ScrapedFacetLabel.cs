using System;
using System.Collections.Generic;
using System.Text;

namespace LegoSharp
{
    public struct ScrapedFacetLabel
    {
        public string value;
        public string name;
    }

    public class ScrapedFacetLabelComparaer : IEqualityComparer<ScrapedFacetLabel>
    {
        public bool Equals(ScrapedFacetLabel a, ScrapedFacetLabel b)
        {
            return a.value == b.value && a.name == b.name;
        }
        public int GetHashCode(ScrapedFacetLabel t)
        {
            string code = t.value + "," + t.name;
            return code.GetHashCode();
        }
    }
}
