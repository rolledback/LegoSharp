using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LegoSharp
{
    public abstract class PickABrickFilter<FilterEnumT> : IQueryFilter
    {
        public string key { get; }

        protected List<FilterEnumT> _values;

        public PickABrickFilter(string key)
        {
            this._values = new List<FilterEnumT>();
            this.key = key;
        }

        public PickABrickFilter<FilterEnumT> addValue(FilterEnumT value)
        {
            this._values.Add(value);
            return this;
        }

        public IEnumerable<string> getValues()
        {
            return from v in this._values select this.filterEnumToValue(v);
        }

        public abstract string filterEnumToValue(FilterEnumT value);

        public abstract string filterEnumToName(FilterEnumT value);
    }
}
