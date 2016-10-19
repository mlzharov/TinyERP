using log4net;

namespace App.Common.Logging
{
    public class DefaultLogger:ILogger
    {
        private readonly ILog logger;

        public DefaultLogger()
        {
            log4net.Config.XmlConfigurator.Configure();
            this.logger =  LogManager.GetLogger(typeof(DefaultLogger));
        }

        public void Info(string message, params object[] args)
        {
            string messageToWrite = GetMessage(message, args);
            logger.Info(messageToWrite);
        }

        public void Warn(string message, params object[] args)
        {
            string messageToWrite = GetMessage(message, args);
            logger.Warn(messageToWrite);
        }

        public void Error(string message, params object[] args)
        {
            string messageToWrite = GetMessage(message, args);
            logger.Error(messageToWrite);
        }

        public void Info(object arg)
        {
            logger.Info(arg);
        }

        public void Warn(object arg)
        {
            logger.Warn(arg);
        }

        public void Error(object arg)
        {
            logger.Error(arg);
        }

        private string GetMessage(string message, object[] args)
        {
            if (args == null || args.Length == 0)
            {
                return message;
            }
            return string.Format(message, args);
        }
    }
}
