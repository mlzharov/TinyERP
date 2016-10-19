namespace App.Common
{
    public class WebApiApplication : BaseApplication<System.Web.HttpApplication>
    {
        public WebApiApplication(System.Web.HttpApplication context)
            : base(context, ApplicationType.WebApi)
        {
            this.Context.BeginRequest += this.OnBeginRequest;
            this.Context.EndRequest += this.OnEndRequest;
            this.Context.Error += this.OnError;
        }
        private void OnBeginRequest(object sender, System.EventArgs e)
        {
            this.OnApplicationRequestStarted();
        }
        private void OnEndRequest(object sender, System.EventArgs e)
        {
            //this.OnApplicationEnded();
        }
        private void OnError(object sender, System.EventArgs e)
        {
           // this.OnUnHandledError();
        }
    }
}
