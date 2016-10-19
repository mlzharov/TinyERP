using System.Configuration;
namespace App.Common.Configurations
{
    public class Configuration : System.Configuration.ConfigurationSection
    {
        private static Configuration current;
        public static Configuration Current
        {
            get
            {
                if (current == null)
                {
                    current = (Configuration)System.Configuration.ConfigurationManager.GetSection("appconfiguration");
                }
                return current;
            }
        }
        [ConfigurationProperty("authentication")]
        public AuthenticationElement Authentication
        {
            get
            {
                return (AuthenticationElement)this["authentication"];
            }
        }

        [ConfigurationProperty("paging")]
        public PagingElement Paging
        {
            get
            {
                return (PagingElement)this["paging"];
            }
        }

        [ConfigurationProperty("databases", IsDefaultCollection=false)]
        [ConfigurationCollection(typeof(DatabasesElement),
            AddItemName = "add",
            ClearItemsName = "clear",
            RemoveItemName = "remove")]
        public DatabasesElement Databases
        {
            get
            {
                return (DatabasesElement)this["databases"];
            }
        }

        [ConfigurationProperty("localization")]
        public LocalizationElement Localization
        {
            get
            {
                return (LocalizationElement)this["localization"];
            }
        }

        [ConfigurationProperty("uitest")]
        public UITestElement UITest
        {
            get
            {
                return (UITestElement)this["uitest"];
            }
        }

        [ConfigurationProperty("mail")]
        public MailElement Mail
        {
            get
            {
                return (MailElement)this["mail"];
            }
        }
        [ConfigurationProperty("folder")]
        public FolderElement Folder
        {
            get
            {
                return (FolderElement)this["folder"];
            }
        }
    }
}
