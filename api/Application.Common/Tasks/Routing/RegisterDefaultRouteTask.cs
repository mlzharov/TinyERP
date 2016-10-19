using System.Web.Mvc;
using System.Web.Routing;
using App.Common.Extensions;
namespace App.Common.Tasks.Routing
{
    public class RegisterDefaultRouteTask : BaseTask<TaskArgument<RouteCollection>>, IRouteConfiguredTask
    {
        public RegisterDefaultRouteTask()
            : base(ApplicationType.MVC | ApplicationType.WebApi)
        {

        }
        public override void Execute(TaskArgument<RouteCollection> arg)
        {
            if (!this.IsValid(arg.Type)) { return; }

            RouteCollection routes = arg.Data;
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.IgnoreRoute("favicon.ico");
        }
    }
}
