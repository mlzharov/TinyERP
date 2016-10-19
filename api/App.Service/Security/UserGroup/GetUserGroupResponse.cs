using App.Common.Data;
using App.Common.Mapping;
using System;
using System.Collections.Generic;

namespace App.Service.Security.UserGroup
{
    public class GetUserGroupResponse: BaseContent, IMappedFrom<App.Entity.Security.UserGroup>
    {
        public IList<Guid> PermissionIds { get; set; }
        public GetUserGroupResponse(): base()
        {
            this.PermissionIds = new List<Guid>();
        }
    }
}
