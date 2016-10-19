using System;

namespace App.Common.Extensions
{
    public static partial class StringExtension
    {
        public static int AsInt(this string str)
        {
            int result = 0;
            return int.TryParse(str, out result) ? result : 0;
        }
    }
}
