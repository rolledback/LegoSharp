using System;
using System.Collections.Generic;
using System.Text;

namespace LegoSharp
{
    public interface IPickABrickFilter
    {
        IEnumerable<string> getValues();
        string getKey();
    }
}
