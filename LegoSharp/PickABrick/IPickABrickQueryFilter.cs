using System;
using System.Collections.Generic;
using System.Text;

namespace LegoSharp
{
    public interface IPickABrickFilter
    {
        string key { get; }

        IEnumerable<string> getValues();
    }
}
