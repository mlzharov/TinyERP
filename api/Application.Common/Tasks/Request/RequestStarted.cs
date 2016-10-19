using App.Common.Logging;
using System.Web;

namespace App.Common.Tasks.Request
{
    public class RequestStarted : BaseTask<TaskArgument<HttpApplication>>, IApplicationRequestStartedTask<TaskArgument<HttpApplication>>
    {
        public RequestStarted()
            : base(ApplicationType.MVC | ApplicationType.WebApi)
        {

        }
        public override void Execute(TaskArgument<HttpApplication> arg)
        {
            if (!this.IsValid(arg.Type)) { return; }
            new DefaultLogger().Info("New request started: {0}", arg.Data.Context.Request.RawUrl);
        }
    }
}
