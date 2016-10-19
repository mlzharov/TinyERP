using System.Configuration;

namespace App.Common.Configurations
{
    public class LocalizationElement: ConfigurationElement
    {
        [ConfigurationProperty("defaultLanguageCode")]
        public string DefaultLanguageCode
        {
            get { return (string)this["defaultLanguageCode"]; }
        }
    }
}
