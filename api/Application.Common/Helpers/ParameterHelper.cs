using System;

namespace App.Common.Helpers
{
    public class ParameterHelper
    {
        public static string ToKey(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) { return string.Empty; }
            return name.Replace(" ","");
        }
    }
}
