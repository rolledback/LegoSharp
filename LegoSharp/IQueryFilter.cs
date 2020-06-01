using System;
using System.Collections.Generic;
using System.Text;

namespace LegoSharp
{
    public interface IQueryFilter
    {
        string facetKey { get; }

        dynamic getQueryLangValue();
    }
}
