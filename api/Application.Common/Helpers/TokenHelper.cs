using System;

namespace App.Common.Helpers
{
    public class TokenHelper
    {
        public static AuthenticationToken CreateNewAuthenticationToken()
        {
            return new AuthenticationToken(Guid.NewGuid(), DateTimeHelper.GetAuthenticationTokenExpiredUtcDateTime());
        }
    }
}
