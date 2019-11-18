using System;
using System.Collections.Generic;
using System.Text;

namespace LegoSharp
{
    public abstract class LegoGraphFilter<T> : ILegoGraphFilter
    {
        private string _key;

        protected List<T> _values;

        public LegoGraphFilter(string key)
        {
            this._values = new List<T>();
            this._key = key;
        }

        public string getKey()
        {
            return this._key;
        }

        public LegoGraphFilter<T> addValue(T value)
        {
            this._values.Add(value);
            return this;
        }

        public abstract IEnumerable<string> getValues();
    }
}
