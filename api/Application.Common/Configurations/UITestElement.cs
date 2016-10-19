using System.Configuration;

namespace App.Common.Configurations
{
    public class UITestElement : ConfigurationElement
    {
        [ConfigurationProperty("environtmenFile")]
        public string EnvirontmenFile
        {
            get { return (string)this["environtmenFile"]; }
        }
        [ConfigurationProperty("basePath")]
        public string BasePath
        {
            get { return (string)this["basePath"]; }
        }
        [ConfigurationProperty("timeout")]
        public int Timeout
        {
            get { return (int)this["timeout"]; }
        }
        [ConfigurationProperty("baseOutput")]
        public string BaseOutput
        {
            get { return (string)this["baseOutput"]; }
        }
        [ConfigurationProperty("zipFile")]
        public string ZipFile
        {
            get { return (string)this["zipFile"]; }
        }
        [ConfigurationProperty("notificationReceiver")]
        public string NotificationReceiver
        {
            get { return (string)this["notificationReceiver"]; }
        }
        [ConfigurationProperty("reportTemplate")]
        public string ReportTemplate
        {
            get { return (string)this["reportTemplate"]; }
        }
        
    }
}
