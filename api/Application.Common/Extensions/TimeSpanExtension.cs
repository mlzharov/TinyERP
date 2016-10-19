using System;
using App.Common.Configurations;

namespace App.Common.Extensions
{
    public static partial class TimeSpanExtension
    {

        public static TimeSpan Value(this TimeSpan? value)
        {
            return value == null ? default(TimeSpan) : value.Value;
        }
    }
}
