using Castle.Windsor;
using App.Common.Tasks;
using System.Web.Http.Dispatcher;
using System.Web.Http.Controllers;
using App.Common.Extensions;
namespace App.Common.DI.Castle
{
    public class ConfigServicesContainerTask : BaseTask<TaskArgument<ServicesContainer>>, IServiceContainerConfiguredTask<TaskArgument<ServicesContainer>>
    {
        public ConfigServicesContainerTask() : base(ApplicationType.MVC | ApplicationType.WebApi) { }
        public override void Execute(TaskArgument<ServicesContainer> arg)
        {
            if (!this.IsValid(arg.Type)) { return; }
            ServicesContainer servicesContainer = arg.Data;
            servicesContainer.Replace(typeof(IHttpControllerActivator), new App.Common.DI.Castle.HttpControllerActivator(IoC.Container.Instance as IWindsorContainer));
            
        }
    }
}
