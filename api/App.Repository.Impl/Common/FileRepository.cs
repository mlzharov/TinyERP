using System;
using System.Collections.Generic;
using App.Common;
using App.Common.Data;
using App.Common.Data.MSSQL;
using App.Context;
using App.Entity.Common;
using App.Repository.Common;
using System.Linq;
using AutoMapper.QueryableExtensions;

namespace App.Repository.Impl.Common
{
    public class FileRepository: BaseRepository<FileUpload>, IFileRepository
    {
        public FileRepository(): base(new AppDbContext(IOMode.Read))
        {
        }
        public FileRepository(IUnitOfWork uow): base(uow.Context as IMSSQLDbContext)
        {
        }

        public IList<TEntity> GetByIds<TEntity>(IList<Guid> ids)
        {
            return this.DbSet.AsQueryable().Where(item => ids.Contains(item.Id)).ProjectTo<TEntity>().ToList();
        }

        //public IList<TEntity> GetByParentId<TEntity>(Guid parentId) where TEntity: IMappedFrom<FileUpload>
        //{
        //    return this.DbSet.AsQueryable().Where(item => item.ParentId == parentId).ProjectTo<TEntity>().ToList();
        //}
    }
}
