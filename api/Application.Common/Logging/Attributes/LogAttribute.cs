using System.Security.Policy;
using System.Web.Mvc;

namespace App.Common.Logging.Attributes
{
    using System;
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class LogAttribute : FilterAttribute, IActionFilter
    {
        private ILogger logger;

        public string Message { get; set; }
        public LogType Type { get; set; }

        public LogAttribute(string message, LogType type = LogType.Warn)
        {
            this.logger = new DefaultLogger();
            this.Message = message;
            this.Type = type;
            
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (this.Type == LogType.Info) { this.logger.Info(this.Message); }
            if (this.Type == LogType.Warn) { this.logger.Warn(this.Message); }
            if (this.Type == LogType.Error) { this.logger.Error(this.Message); }
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }
    }
}
