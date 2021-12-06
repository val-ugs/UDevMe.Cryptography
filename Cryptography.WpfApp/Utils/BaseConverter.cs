using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography.WpfApp.Utils
{
    public static class BaseConverter
    {
        public static string UintToString(uint value, int baseValue)
        {
            return Convert.ToString(value, baseValue);
        }

        public static uint StringToUint(string value, int baseValue)
        {
            if (String.IsNullOrEmpty(value))
                return 0;
            return Convert.ToUInt32(value, baseValue);
        }
    }
}
