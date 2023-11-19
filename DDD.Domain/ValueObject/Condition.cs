using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.ValueObject
{
    public sealed class Condition : ValueObejct<Condition>
    { 
        public static readonly Condition None = new Condition(0);
        public static readonly Condition Suny = new Condition(1);
        public static readonly Condition Cloudy = new Condition(2);
        public static readonly Condition Rain = new Condition(3);

        public Condition(int condition)
        {
            Value = condition;
        }

        public int Value { get; }

        public string DisplayValue
        {
            get
            {
                if (this == Suny)
                {
                    return "晴れ";
                }
                if (this == Cloudy)
                {
                    return "曇り";
                }
                if (this == Rain)
                {
                    return "雨";
                }
                return "不明";
            }
        }

        protected override bool EqualsCore(Condition other)
        {
            return Value == other.Value;
        }

        public static IList<Condition> ToList()
        {
            IList<Condition> list = new List<Condition>
            {
                Condition.Suny,
                Condition.None,
                Condition.Cloudy,
                Condition.Rain
            };
            return list;
        }

        protected override int GetHashCode(Condition other)
        {
            return other.Value.GetHashCode();
        }
    }
}
