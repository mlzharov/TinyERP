using System.Web.Routing;

namespace App.Common.Tasks
{
    public interface IRouteConfiguredTask : IBaseTask<TaskArgument<RouteCollection>>
    {
    }
}
