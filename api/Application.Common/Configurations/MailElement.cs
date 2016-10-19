using System.Configuration;

namespace App.Common.Configurations
{
    public class MailElement : ConfigurationElement
    {
        [ConfigurationProperty("server")]
        public string Server
        {
            get { return (string)this["server"]; }
        }

        [ConfigurationProperty("port")]
        public int Port
        {
            get { return (int)this["port"]; }
        }

        [ConfigurationProperty("ssl")]
        public bool Ssl
        {
            get { return (bool)this["ssl"]; }
        }

        [ConfigurationProperty("username")]
        public string Username
        {
            get { return (string)this["username"]; }
        }

        [ConfigurationProperty("password")]
        public string Password
        {
            get { return (string)this["password"]; }
        }

        [ConfigurationProperty("displayName")]
        public string DisplayName
        {
            get { return (string)this["displayName"]; }
        }

        [ConfigurationProperty("defaultSender")]
        public string DefaultSender
        {
            get { return (string)this["defaultSender"]; }
        }
    }
}
