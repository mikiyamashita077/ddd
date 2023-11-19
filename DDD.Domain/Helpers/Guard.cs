using DDD.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Helpers
{
    public static class Guard
    {
        public static void IsNull(object o, string message)
        {
            if (o == null)
            {
                throw new InputException(message);
            }
        }

        public static void IsFloat(string o, string message, out string outValue)
        {
            if (!float.TryParse(o, out float inputValue))
            {
                throw new InputException(message);
                outValue = o;
            }
            outValue = inputValue.ToString();
            return;
        }
    }
}
