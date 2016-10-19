using App.Common.Data;
using System.Collections.Generic;

namespace App.Entity.Security
{
    public class UserGroup: BaseContent
    {
        public IList<Permission> Permissions { get; set; }
        public UserGroup():base()
        {
            this.Permissions = new List<Permission>();
        }
        public UserGroup(string name, string desc, IList<Permission> permissions): this() {
            this.Name = name;
            this.Key = App.Common.Helpers.UtilHelper.ToKey(name);
            this.Description = desc;
            if (permissions == null) { return; }
            this.Permissions = permissions;
        }
    }
}
