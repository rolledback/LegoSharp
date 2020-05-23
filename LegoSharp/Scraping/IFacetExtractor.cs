using System;
using System.Collections.Generic;
using System.Text;

namespace LegoSharp
{
    public interface IFacetExtractor<IGraphQuery>
    {
        IEnumerable<Facet> extractFacets(string responseBody);
    }
}
