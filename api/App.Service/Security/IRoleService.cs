using System;
using System.Collections.Generic;
using App.Entity.Security;

namespace App.Service.Security
{
    public interface IRoleService
    {
        System.Collections.Generic.IList<RoleListItemSummary> GetRoles();
        void CreateIfNotExist(IList<Role> roles);
        void Create(IList<Role> roles);
        CreateRoleResponse Create(CreateRoleRequest request);
        DeleteRoleResponse Delete(Guid id);
        GetRoleResponse Get(Guid id);
        void Update(UpdateRoleRequest request);
    }
}
