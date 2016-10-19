using System;

namespace App.Common
{
    public class AuthenticationToken
    {
        public AuthenticationToken(Guid value, DateTime expiredAfter)
        {
            this.Value = value.ToString();
            this.ExpiredAfter = expiredAfter;
        }

        public AuthenticationToken(string value)
        {
            this.Value = value;
            ExpiredAfter = DateTime.Now;
        }

        public string Value { get; set; }
        public DateTime ExpiredAfter { get; set; }
    }
}
