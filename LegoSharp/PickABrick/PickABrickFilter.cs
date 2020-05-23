using System;
using System.Collections.Generic;
using System.Text;

namespace LegoSharp
{
    public abstract class PickABrickFilter<FilterEnumT> : QueryFilter<FilterEnumT>
    {
        public PickABrickFilter(string key) : base(key)
        {

        }
    }
}
