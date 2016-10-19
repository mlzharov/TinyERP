using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Common.Helpers
{
    public class EnumHelper
    {
        public static IList<TEnumType> ToList<TEnumType>()
        {
            return Enum.GetValues(typeof(TEnumType)).Cast<TEnumType>().ToList();
        }

        public static TEnum Convert<TEnum>(string enumValue)
        {
            enumValue = enumValue.ToLower();
            IList<TEnum> values = EnumHelper.ToList<TEnum>();
            foreach (TEnum value in values) {
                if (value.ToString().ToLower() != enumValue) { continue; }
                return value;
            }
            throw new KeyNotFoundException();
        }
    }
}
