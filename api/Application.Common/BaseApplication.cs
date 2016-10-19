namespace App.Common
{
    using App.Common.Helpers;
    using App.Common.Tasks;
    using System.Web;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    using System.Web.Routing;

    public class BaseApplication<TContext> : IApplication
    {
        public TContext Context { get; private set; }
        public ApplicationType Type { get; private set; }
        public BaseApplication(TContext context, ApplicationType type)
        {
            this.Context = context;
            this.Type = type;
        }

        public void OnApplicationStarted()
        {
            TaskArgument<TContext> taskArg = new TaskArgument<TContext>(this.Context, this.Type);
            AssemblyHelper.ExecuteTasks<IApplicationStartedTask<TaskArgument<TContext>>, TaskArgument<TContext>>(taskArg);
            AssemblyHelper.ExecuteTasks<IApplicationReadyTask<TaskArgument<TContext>>, TaskArgument<TContext>>(taskArg, true);
        }

        public void OnApplicationEnded()
        {
            //AssemblyHelper.ExecuteTasks<IApplicationEndedTask, TContext>(this.Context);
        }

        public void OnRouteConfigured()
        {
            //AssemblyHelper.ExecuteTasks<IRouteConfiguredTask, RouteCollection>(RouteTable.Routes);
            TaskArgument<RouteCollection> taskArg = new TaskArgument<RouteCollection>(RouteTable.Routes, this.Type);
            AssemblyHelper.ExecuteTasks<IRouteConfiguredTask, TaskArgument<RouteCollection>>(taskArg);
        }

        public void OnApplicationRequestStarted()
        {
            TaskArgument<TContext> taskArg = new TaskArgument<TContext>(this.Context, this.Type);
            AssemblyHelper.ExecuteTasks<IApplicationRequestStartedTask<TaskArgument<TContext>>, TaskArgument<TContext>>(taskArg);
            //AssemblyHelper.ExecuteTasks<IApplicationRequestStartedTask, HttpContext>(httpContext);
        }

        public void OnApplicationRequestEnded()
        {
            TaskArgument<TContext> taskArg = new TaskArgument<TContext>(this.Context, this.Type);
            AssemblyHelper.ExecuteTasks<IApplicationRequestEndedTask<TaskArgument<TContext>>, TaskArgument<TContext>>(taskArg);
            //AssemblyHelper.ExecuteTasks<IApplicationRequestEndedTask, HttpContext>(httpContext);
        }

        public void OnUnHandledError()
        {
            TaskArgument<TContext> taskArg = new TaskArgument<TContext>(this.Context, this.Type);
            AssemblyHelper.ExecuteTasks<IUnHandledErrorTask<TaskArgument<TContext>>, TaskArgument<TContext>>(taskArg);
            //AssemblyHelper.ExecuteTasks<IUnHandledErrorTask, HttpContext>(httpContext);
        }

        public void OnApplicationRequestExecuting()
        {
            TaskArgument<TContext> taskArg = new TaskArgument<TContext>(this.Context, this.Type);
            AssemblyHelper.ExecuteTasks<IApplicationRequestExecutingTask<TaskArgument<TContext>>, TaskArgument<TContext>>(taskArg);
            //AssemblyHelper.ExecuteTasks<IApplicationRequestExecutingTask, HttpContext>(httpContext);
        }
        /// <summary>
        /// this method must call after App.Common.Application.OnApplicationStarted(HttpContext.Current) called
        /// </summary>
        /// <param name="servicesContainer"></param>
        public void ConfigServiceContainer()
        {
            TaskArgument<ServicesContainer> taskArg = new TaskArgument<ServicesContainer>(GlobalConfiguration.Configuration.Services, this.Type);
            AssemblyHelper.ExecuteTasks<IServiceContainerConfiguredTask<TaskArgument<ServicesContainer>>, TaskArgument<ServicesContainer>>(taskArg);

            //AssemblyHelper.ExecuteTasks<IServiceContainerConfiguredTask, System.Web.Http.Controllers.ServicesContainer>(servicesContainer);
        }
    }
}
