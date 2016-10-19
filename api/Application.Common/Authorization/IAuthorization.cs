namespace Omega.Common.Authorization
{
    public interface IAuthorization
    {
        bool Authorize(System.Web.HttpContextBase httpContext);
    }
}
