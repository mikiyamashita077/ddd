using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.ValueObject
{
    public sealed class AreaId : ValueObejct<AreaId>
    {
        public AreaId(int value)
        {
            Value = value;
        }

        public int Value { get; set; }

        public string DisplayValue
        {
            get => Value.ToString().PadLeft(4,'0');
        }

        protected override bool EqualsCore(AreaId other)
        {
            return Value.Equals(other.Value);
        }

        protected override int GetHashCode(AreaId other)
        {
            return other.Value.GetHashCode();
        }
    }
}
