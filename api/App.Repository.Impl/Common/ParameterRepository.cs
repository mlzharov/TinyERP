using App.Common;
using App.Common.Data;
using App.Common.Data.MSSQL;
using App.Context;
using App.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App.Repository.Impl.Common
{
    public class ParameterRepository : BaseContentRepository<App.Entity.Common.Parameter>, IParameterRepository
    {
        public ParameterRepository() : base(new AppDbContext()) { }
        public ParameterRepository(IUnitOfWork uow) : base(uow.Context as IMSSQLDbContext) { }
        public IList<App.Entity.Common.Parameter> GetByParentId(Guid id, ParameterParentType parentType)
        {
            return this.DbSet.AsQueryable().Where(item => item.ParentId == id && item.ParentType == parentType).ToList();
        }
    }
}
