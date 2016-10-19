using App.Common.Data;
using App.Common.Mapping;
using App.Entity.Security;
using System;
using System.Collections.Generic;

namespace App.Service.Security
{
    public class CreateUserGroupRequest: BaseContent, IMappedFrom<App.Entity.Security.UserGroup>
    {
        public IList<Guid> PermissionIds { get; set; }
        public CreateUserGroupRequest(): base()
        {
            this.PermissionIds = new List<Guid>();
        }
    }
}
