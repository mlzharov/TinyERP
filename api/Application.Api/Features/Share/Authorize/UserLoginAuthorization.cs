using App.Common;
using App.Common.Authorize;
using App.Common.DI;
using App.Common.Validation;
using App.Service.Registration.User;

namespace App.Api.Features.Share.Authorize
{
    public class UserLoginAuthorization : IUserLoginAuthorization
    {
        private readonly IUserService userService;
        public UserLoginAuthorization()
        {
            this.userService = IoC.Container.Resolve<IUserService>();
        }

        public bool IsAuthorized(System.Web.HttpContextBase httpContext)
        {
            return true;
        }


        public bool IsAuthorized(string authenticationToken)
        {
            if (string.IsNullOrWhiteSpace(authenticationToken))
            {
                throw new AuthenticationException(AuthenticationType.User, "AuthenticationException.UnAuthorizedRequest");
            }

            return userService.IsValidToken(authenticationToken);
        }
    }
}