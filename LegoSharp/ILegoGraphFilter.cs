using System;
using System.Collections.Generic;
using System.Text;

namespace LegoSharp
{
    public interface ILegoGraphFilter
    {
        IEnumerable<string> getValues();
        string getKey();
    }
}
