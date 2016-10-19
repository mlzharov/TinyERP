using App.Common.Data;
using System.Collections.Generic;
using System;

namespace App.Entity.Security
{
    public class Role:BaseContent
    {
        public IList<Permission> Permissions { get; set; }
        public Role():base()
        {
            this.Permissions = new List<Permission>();
        }
        public Role(string name, string desc, IList<Permission> permissions): this() {
            this.Name = name;
            this.Key = App.Common.Helpers.UtilHelper.ToKey(name);
            this.Description = desc;
            if (permissions == null) { return; }
            this.Permissions = permissions;
        }
    }
}
