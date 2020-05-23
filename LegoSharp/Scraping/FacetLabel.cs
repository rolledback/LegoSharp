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

    public class FacetLabel
    {
        public string key { get; set; }
        public string name { get; set; }
        public string value { get; set; }
    }
}
