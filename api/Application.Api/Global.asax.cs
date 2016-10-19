namespace App.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected App.Common.IApplication application;
        public WebApiApplication()
        {
            this.application = App.Common.ApplicationFactory.Create<System.Web.HttpApplication>(App.Common.ApplicationType.WebApi, this);
        }
        protected void Application_Start()
        {
            this.application.OnApplicationStarted();
            RegisterRoutes();
        }

        protected void Application_PreRequestHandlerExecute()
        {
           // this.application.OnApplicationRequestExecuting();
        }
        protected void RegisterRoutes()
        {
            this.application.OnRouteConfigured();
        }
/*
        private void OnError(object sender, System.EventArgs e)
        {
            this.application.OnUnHandledError(HttpContext.Current);
        }

        private void OnEndRequest(object sender, System.EventArgs e)
        {
            Omega.Common.Application.OnApplicationRequestEnded(HttpContext.Current);
        }

        private void OnBeginRequest(object sender, System.EventArgs e)
        {
            Omega.Common.Application.OnApplicationRequestStarted(HttpContext.Current);
        }
        private static void RegisterGlobalFilters ( GlobalFilterCollection filters )
        {
            filters.Add ( new HandleErrorAttribute ( ) );
        }

        private static void RegisterRoutes ( RouteCollection routes )
        {
            Omega.Common.Application.OnRouteConfigured(routes);
        }

        protected void Application_Start ( )
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Omega.Common.Application.OnApplicationStarted(HttpContext.Current);
        }

        protected void Application_PreRequestHandlerExecute()
        {
            Omega.Common.Application.OnApplicationRequestExecuting(HttpContext.Current);
        }
 */
    }
}
