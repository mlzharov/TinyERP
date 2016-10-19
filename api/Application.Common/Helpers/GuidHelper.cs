using System;
using System.Collections.Generic;

namespace App.Common.Helpers
{
    public class GuidHelper
    {
        public static IList<Guid> ToGuid(string value)
        {
            if (string.IsNullOrWhiteSpace(value)) { return new List<Guid>(); }
            string[] items = value.Split(';');
            IList<Guid> itemIds = new List<Guid>();
            foreach (string item in items)
            {
                itemIds.Add(Guid.Parse(item));
            }
            return itemIds;
        }

        public static string ToString(IList<Guid> ids)
        {
            return String.Join(";", ids);
        }
    }
}
