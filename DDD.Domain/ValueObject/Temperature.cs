using DDD.Domain.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.ValueObject
{
    public sealed class Temperature : ValueObejct<Temperature>
    {
        public const string UnitName = "℃";

        public const int DecimalPoint = 2;


        public Temperature(float temp)
        {
            Value = temp;
        }

        public float Value { get; }
        public string DisplayValue 
        { 
            get => Value.RoundString(DecimalPoint); 
        }

        public string DisplayValueWithUnit
        {
            get => DisplayValue + UnitName;
        }

        protected override bool EqualsCore(Temperature other)
        {
            return Value == other.Value;
        }

        protected override int GetHashCode(Temperature other)
        {
            return other.Value.GetHashCode();
        }
    }
}
