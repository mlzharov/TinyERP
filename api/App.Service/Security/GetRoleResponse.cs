using App.Common.Data;
using App.Common.Mapping;
using App.Entity.Security;
using System;
using System.Collections.Generic;

namespace App.Service.Security
{
    public class GetRoleResponse: BaseContent, IMappedFrom<Role>
    {
        public IList<Guid> Permissions { get; set; }
        public GetRoleResponse(): base()
        {
            this.Permissions = new List<Guid>();
        }
    }
}
