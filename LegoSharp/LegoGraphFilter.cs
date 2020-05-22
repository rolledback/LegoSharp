using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LegoSharp
{
    public abstract class LegoGraphFilter<FilterEnumT> : ILegoGraphFilter
    {
        private string _key;

        protected List<FilterEnumT> _values;

        public LegoGraphFilter(string key)
        {
            this._values = new List<FilterEnumT>();
            this._key = key;
        }

        public string getKey()
        {
            return this._key;
        }

        public LegoGraphFilter<FilterEnumT> addValue(FilterEnumT value)
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
