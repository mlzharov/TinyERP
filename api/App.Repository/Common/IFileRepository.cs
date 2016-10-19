using System;
using System.Collections.Generic;
using App.Common.Data;
using App.Entity.Common;

namespace App.Repository.Common
{
    public interface IFileRepository : IBaseRepository<FileUpload>
    {
        //IList<TEntity> GetByParentId<TEntity>(Guid parentId) where TEntity: IMappedFrom<FileUpload>;
        IList<TEntity> GetByIds<TEntity>(IList<Guid> ids);
    }
}
