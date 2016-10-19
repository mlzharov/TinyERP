using System.Configuration;
namespace App.Common.Configurations
{
    public class PagingElement : ConfigurationElement
    {
        [ConfigurationProperty("pageSize")]
        public int PageSize
        {
            get { return (int)this["pageSize"]; }
        }
    }
}
