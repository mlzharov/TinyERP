using System.Linq;
using AutoMapper.QueryableExtensions;
namespace App.Common.Data
{
    public class BaseContentRepository<TEntity>: BaseRepository<TEntity>, IBaseContentRepository<TEntity> where TEntity: class, IBaseContent
    {
        public BaseContentRepository(App.Common.Data.MSSQL.IMSSQLDbContext context): base(context)
        {
        }
        public TEntity GetByKey(string key) {
            return this.DbSet.AsQueryable().FirstOrDefault(item => item.Key.ToLower() == key.ToLower());
        }
        public TResult GetByKey<TResult>(string key) where TResult : App.Common.Mapping.IMappedFrom<TEntity> {
            TEntity entity= this.DbSet.AsQueryable().FirstOrDefault(item => item.Key.ToLower() == key.ToLower());
            return AutoMapper.Mapper.Map<TResult>(entity);
        }
        public TEntity GetByName(string name)
        {
            return this.DbSet.AsQueryable().FirstOrDefault(item => item.Name.Trim().ToLower() == name.Trim().ToLower());
        }
        public TResult GetByName<TResult>(string name) where TResult : App.Common.Mapping.IMappedFrom<TEntity>
        {
            TEntity entity = this.DbSet.AsQueryable().FirstOrDefault(item => item.Name.Trim().ToLower() == name.Trim().ToLower());
            return AutoMapper.Mapper.Map<TResult>(entity);
        }
    }
}
