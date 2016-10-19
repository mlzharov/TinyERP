using System.Collections.Generic;
using App.Common.Data;
using App.Common.Data.MSSQL;
using App.Common.Mapping;
using App.Entity.Security;
using App.Repository.Secutiry;
using App.Context;
using System.Linq;
using System;

namespace App.Repository.Impl.Security
{
    public class PermissionRepository : BaseContentRepository<Permission>, IPermissionRepository
    {
        public PermissionRepository(IUnitOfWork uow) : base(uow.Context as IMSSQLDbContext){}
        public PermissionRepository(): base(new AppDbContext(App.Common.IOMode.Read)){}

        public IList<TResult> GetPermissions<TResult>() where TResult : IMappedFrom<Permission>
        {
            return this.GetItems<TResult>();
        }
        public IList<Permission> GetPermissions(IList<System.Guid> ids)
        {
            return this.DbSet.AsQueryable().Where(per => ids.Contains(per.Id)).ToList();
        }

        public IList<Permission> GetByRoleId(string roleId)
        {
            Guid roleItemId = Guid.Parse(roleId);
            return this.DbSet.AsQueryable().Where(item => item.Roles.Any(role => role.Id == roleItemId)).ToList();
        }
    }
}
