using App.Common.Data;
using System.Collections.Generic;

namespace App.Entity.Security
{
    public class Permission : BaseContent
    {
        public IList<Role> Roles { get; set; }
        public IList<UserGroup> UserGroups { get; set; }
        public Permission():base(){}
        public Permission(BaseContent permission):this(permission.Name, permission.Key, permission.Description){}
        public Permission(string name, string key, string desc):base(name, key, desc){}

    }
}
