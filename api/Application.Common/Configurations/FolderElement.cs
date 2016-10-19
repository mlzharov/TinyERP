using System.Configuration;

namespace App.Common.Configurations
{
    public class FolderElement : ConfigurationElement
    {
        [ConfigurationProperty("mailTemplate")]
        public string MailTemplate
        {
            get { return System.IO.Path.Combine(this.BaseResourceFolder, (string)this["mailTemplate"]); }
        }
        [ConfigurationProperty("baseResourceFolder")]
        public string BaseResourceFolder
        {
            get { return (string)this["baseResourceFolder"]; }
        }
    }
}
