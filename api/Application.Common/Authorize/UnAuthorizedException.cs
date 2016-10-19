using App.Common.Validation;
namespace App.Common.Authorize
{
    public class UnAuthorizedException : AuthenticationException
    {
        public UnAuthorizedException(AuthenticationType authType, string key)
            : base(authType, key)
        {
        }
    }
}
