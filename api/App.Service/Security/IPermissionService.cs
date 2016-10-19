using System;
using System.Collections.Generic;
using App.Common.Data;
using App.Entity.Security;
using App.Service.Security.Permission;

namespace App.Service.Security
{
    public interface IPermissionService
    {
        System.Collections.Generic.IList<PermissionAsKeyNamePair> GetPermissions();
        void CreateIfNotExist(IList<App.Entity.Security.Permission> pers);
        BaseContent CreatePermission(BaseContent permission);
        void Delete(Guid id);
        GetPermissionResponse GetPermission(Guid id);
        void UpdatePermission(UpdatePermissionRequest request);
    }
}
