namespace App.Common.Logging
{
    public interface ILogger
    {
        void Info(string message, params object[] args);
        void Warn(string message, params object[] args);
        void Error(string message, params object[] args);
        void Info(object arg);
        void Warn(object arg);
        void Error(object arg);
    }
}
