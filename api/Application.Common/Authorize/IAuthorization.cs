using System.Web.Http.Controllers;
namespace App.Common.Authorize
{
    public interface IAuthorization
    {
        bool IsAuthorized(System.Web.HttpContextBase httpContext);
        bool IsAuthorized(string token);
    }
}
