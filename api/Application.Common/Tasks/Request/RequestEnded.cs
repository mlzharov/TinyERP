using App.Common.Logging;
using System.Web;

namespace App.Common.Tasks.Request
{
    public class RequestEnded : BaseTask<TaskArgument<HttpApplication>>, IApplicationRequestEndedTask<TaskArgument<HttpApplication>>
    {
        public RequestEnded():base(ApplicationType.MVC|ApplicationType.WebApi)
        {

        }
        public override void Execute(TaskArgument<HttpApplication> arg)
        {
            if (!this.IsValid(arg.Type)) { return; }
            new DefaultLogger().Info("New request Ended: {0}", arg.Data.Context.Request.RawUrl);
        }
    }
}
