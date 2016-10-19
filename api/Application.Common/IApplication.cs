using System.Web.Routing;
namespace App.Common
{
    public interface IApplication
    {
        void OnApplicationStarted();
        void OnApplicationEnded();
        void OnRouteConfigured();
        void OnApplicationRequestStarted();
        void OnApplicationRequestEnded();
        void OnUnHandledError();
        void OnApplicationRequestExecuting();
        void ConfigServiceContainer();
    }
}
