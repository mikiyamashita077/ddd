using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.Helpers
{
    public static class FloatHelper
    {
        public static string RoundString(this float value, int decimalPoint)
        {
            var tempString = Convert.ToSingle(Math.Round(value, decimalPoint));
            return tempString.ToString("F" + decimalPoint);
        }
    }
}
