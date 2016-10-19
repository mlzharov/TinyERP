using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using App.Common.Helpers;
using App.Common.Tasks;
using App.Common.Extensions;

namespace App.Common.DI.Castle
{
    public class MvcRegisterCastleContainerTask : BaseTask<TaskArgument<System.Web.HttpApplication>>, IApplicationStartedTask<TaskArgument<System.Web.HttpApplication>>
    {
        public MvcRegisterCastleContainerTask() : base(ApplicationType.MVC | ApplicationType.WebApi) { }
        public override void Execute(TaskArgument<System.Web.HttpApplication> taskArg)
        {
            IWindsorContainer windsorContainer = new WindsorContainer();
            RegisterInjector(windsorContainer);
            RegisterControllerFactory(windsorContainer);

            IBaseContainer baseContainer= new CastleContainer(windsorContainer);
            IoC.CreateInstance(baseContainer);

            AssemblyHelper.ExecuteTasks<IBootstrapper, IBaseContainer>(IoC.Container);
        }

        private void RegisterInjector(IWindsorContainer container)
        {
            container.Register(
                Component.For<IWindsorContainer>()
                .Instance(container));
        }

        private static void RegisterControllerFactory(IWindsorContainer container)
        {
            var controllerFactory = new ControllerFactory(container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
        }
    }
}
