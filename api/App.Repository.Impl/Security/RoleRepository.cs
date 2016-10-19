using App.Common.Data;
using App.Common.Data.MSSQL;
using App.Entity.Security;
using App.Repository.Secutiry;

namespace App.Repository.Impl.Security
{
    public class RoleRepository: BaseContentRepository<Role>, IRoleRepository
    {
        public RoleRepository() : base(new App.Context.AppDbContext(App.Common.IOMode.Read))
        {
        }

        public RoleRepository(IUnitOfWork uow) : base(uow.Context as IMSSQLDbContext)
        {
        }
    }
}
