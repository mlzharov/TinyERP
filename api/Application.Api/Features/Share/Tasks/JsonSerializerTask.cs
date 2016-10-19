namespace App.Api.Feature.Share.Tasks
{
    using App.Common.Tasks;
    using System.Web.Http;
    using System.Web.Routing;
    using App.Common;
    using Newtonsoft.Json.Serialization;

    public class JsonSerializerTask : BaseTask<TaskArgument<System.Web.HttpApplication>>, IApplicationStartedTask<TaskArgument<System.Web.HttpApplication>>
    {
        public JsonSerializerTask() : base(ApplicationType.MVC | ApplicationType.WebApi)
        {
        }
        public override void Execute(TaskArgument<System.Web.HttpApplication> arg)
        {
            if (!this.IsValid(arg.Type)) { return; }

            var formatters = GlobalConfiguration.Configuration.Formatters;
            var jsonFormatter = formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
        }
    }
}
