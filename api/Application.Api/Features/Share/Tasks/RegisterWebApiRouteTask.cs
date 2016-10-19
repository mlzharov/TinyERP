using App.Common.Tasks;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using App.Common.Extensions;
using App.Common;
namespace App.Api.Feature.Share.Tasks
{
    public class RegisterWebApiRouteTask : BaseTask<TaskArgument<RouteCollection>>, IRouteConfiguredTask
    {
        public RegisterWebApiRouteTask():base(ApplicationType.MVC|ApplicationType.WebApi)
        {
        }
        public override void Execute(TaskArgument<RouteCollection> arg)
        {
            if (!this.IsValid(arg.Type)) { return; }

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
