using System;
using System.Collections.Generic;
using System.Linq;
using App.Common.Data;
using App.Common.Helpers;

namespace App.Common.Extensions
{
    public static class EnumExtension
    {
        public static bool IsIncludedIn(this ApplicationType first, ApplicationType second)
        {
            return (first & second) != 0;
        }
        public static bool IsIncludedIn(this UserRole first, UserRole second)
        {
            return (first & second) != 0;
        }
    }
}
