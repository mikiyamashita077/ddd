using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.ValueObject
{
    public abstract class ValueObejct<T> where T : ValueObejct<T>
    {
        public override bool Equals(object obj)
        {
            bool isEquals = true;
            if (obj is T vo)
            {
                if (vo == null)
                {
                    return false;
                }
                isEquals = EqualsCore(vo); 
            }
            return isEquals;
        }

        public override string ToString()
        {
            return base.ToString();
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(ValueObejct<T> vo1, ValueObejct<T> vo2)
        {
            return Equals(vo1, vo2);
        }

        public static bool operator !=(ValueObejct<T> vo1, ValueObejct<T> vo2)
        {
            return !Equals(vo1, vo2);
        }

        protected abstract bool EqualsCore(T other);

        protected abstract int GetHashCode(T other);

        internal class ParameterKey
        {
            public ParameterKey(string key, int id)
            {
                Key = key;
                Id = id;
            }
            public string Key { get; } 

            public int Id { get; }

            public override bool Equals(object obj)
            {
                return obj is ParameterKey key &&
                       Key == key.Key &&
                       Id == key.Id;
            }

            public override int GetHashCode()
            {
                int hashCode = 1911547884;
                hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Key);
                hashCode = hashCode * -1521134295 + Id.GetHashCode();
                return hashCode;
            }
        }
    }
}
