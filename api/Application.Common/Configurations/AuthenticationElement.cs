using System.Configuration;
namespace App.Common.Configurations
{
    public class AuthenticationElement : ConfigurationElement
    {
        [ConfigurationProperty("tokenExpiredAfterInMinute")]
        public double TokenExpiredAfterInMinute
        {
            get { return (double)this["tokenExpiredAfterInMinute"]; }
        }
    }
}
