namespace App.Common.Data
{
    public interface IBaseContentRepository<TEntity>: IBaseRepository<TEntity> where TEntity: IBaseContent
    {
        TEntity GetByKey(string key);
        TResult GetByKey<TResult>(string key) where TResult : App.Common.Mapping.IMappedFrom<TEntity>;
        TEntity GetByName(string name);
        TResult GetByName<TResult>(string name) where TResult : App.Common.Mapping.IMappedFrom<TEntity>;
    }
}
