using System;
using System.Collections.Generic;
using System.Web;
using App.Common.Extensions;

namespace App.Common.Helpers
{
    public class RoleHelper
    {
        public static bool IsUserInRole(UserRole roles)
        {
            bool isAuthenticated = false;
            IList<UserRole> userRoles = EnumHelper.ToList<UserRole>();
            System.Security.Principal.IPrincipal user = HttpContext.Current.User;

            foreach (var role in userRoles)
            {
                if (!role.IsIncludedIn(roles) || !user.IsInRole(role.ToString())){continue;}
                isAuthenticated = true;
            }
            
            return isAuthenticated;
        }
    }
}
