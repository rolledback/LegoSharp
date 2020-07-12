using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LegoSharp
{
    /// <summary>
    /// Some parts from:
    /// - https://lostechies.com/jimmybogard/2008/08/12/enumeration-classes/
    /// - https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/enumeration-classes-over-enum-types
    /// </summary>
    public abstract class ValuesFilterValue : IComparable
    {
        public string value { get; }
        public string name { get; }

        protected ValuesFilterValue(string value, string name)
        {
            this.value = value;
            this.name = name;
        }

        public override string ToString()
        {
            return this.value + ", " + this.name;
        }

        public static IEnumerable<T> GetAll<T>() where T : ValuesFilterValue
        {
            var fields = typeof(T).GetFields(BindingFlags.Public |
                                             BindingFlags.Static |
                                             BindingFlags.DeclaredOnly);

            return fields.Select(f => f.GetValue(null)).Cast<T>();
        }

        public override bool Equals(object obj)
        {
            var otherValue = obj as ValuesFilterValue;

            if (otherValue == null)
            {
                return false;
            }

            var typeMatches = GetType().Equals(obj.GetType());
            var valueMatches = this.value.Equals(otherValue.value);
            var nameMatches = this.name.Equals(otherValue.name);

            return typeMatches && valueMatches && nameMatches;
        }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }

        public int CompareTo(object other)
        {
            return this.GetHashCode().CompareTo(((ValuesFilterValue)other).GetHashCode());
        }
    }
}
