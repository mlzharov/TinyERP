using App.Common.DI;
using App.Common.Http;
using App.Common.MVC.Attributes;
using App.Common.Validation;
using App.Service.Registration.User;
using System.Web.Http;

namespace App.Api.Features.Registration
{
    [RoutePrefix("api/users")]
    public class UsersController : ApiController
    {
        [HttpPost]
        [Route("signin")]
        public IResponseData<UserSignInResponse> SignIn([FromBody]UserSignInRequest request) {
            IResponseData<UserSignInResponse> response = new ResponseData<UserSignInResponse>();
            try
            {
                IUserService userService = IoC.Container.Resolve<IUserService>();
                UserSignInResponse signInResponse = userService.SignIn(request);
                response.SetData(signInResponse);
            }
            catch (ValidationException ex)
            {
                response.SetErrors(ex.Errors);
                response.SetStatus(System.Net.HttpStatusCode.PreconditionFailed);
            }
            return response;
        }
        [HttpPost]
        [Route("{token}/signout")]
        public IResponseData<string> SignOut([FromUri]string token)
        {
            IResponseData<string> response = new ResponseData<string>();
            try
            {
                IUserService userService = IoC.Container.Resolve<IUserService>();
                userService.SignOut(token);
            }
            catch (ValidationException ex)
            {
                response.SetErrors(ex.Errors);
                response.SetStatus(System.Net.HttpStatusCode.PreconditionFailed);
            }
            return response;
        }
    }
}
