namespace App.Common.Logging.Attributes
{
    using System.Web.Mvc;
    public class HandleExceptionAttribute:FilterAttribute, IExceptionFilter
    {
        private ILogger logger;

        public HandleExceptionAttribute()
        {
            this.logger = new DefaultLogger();
        }
        public void OnException(ExceptionContext filterContext)
        {
            this.logger.Error(filterContext.Exception.ToString());
        }
    }
}
