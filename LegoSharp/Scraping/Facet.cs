using System;
using System.Collections.Generic;
using System.Text;

namespace LegoSharp
{
    public class Facet
    {
        public string id { get; set; }
        public string key { get; set; }
        public IEnumerable<FacetLabel> labels { get; set; }
    }

    public struct FacetLabel
    {
        public string name { get; set; }
        public string value { get; set; }
    }

    public class FacetLabelComparaer : IEqualityComparer<FacetLabel>
    {
        public bool Equals(FacetLabel a, FacetLabel b)
        {
            return a.value == b.value && a.name == b.name;
        }
        public int GetHashCode(FacetLabel t)
        {
            string code = t.value + "," + t.name;
            return code.GetHashCode();
        }
    }
}
