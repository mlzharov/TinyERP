using System.CodeDom.Compiler;
using System.Web;
using App.Common.Configurations;
using System.Linq;

namespace App.Common.Helpers
{
    public class SessionHelper
    {
        const string CultureKey = "Culture";
        const string RolesKey = "Roles";

        public static ExpectedType Get<ExpectedType>(string key)
        {
            if (HttpContext.Current.Session == null)
            {
                return default(ExpectedType);
            }
            object obj = HttpContext.Current.Session[key];
            if (obj == null)
            {
                return default(ExpectedType);
            }
            return (ExpectedType)obj;
        }
    }
}
