using App.Common.Data;
using System.Collections.Generic;
using System;
using App.Common.Mapping;
using App.Entity.Security;
namespace App.Service.Security
{
    public class CreateRoleRequest: BaseContent, IMappedFrom<Role>
    {
        public IList<Guid> Permissions { get; set; }
        public CreateRoleRequest(): base()
        {
            this.Permissions = new List<Guid>();
        }
    }
}
