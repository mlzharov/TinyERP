namespace App.Common.Data
{
    public interface IDbSet<TEntity>
    {
        TEntity Get(string id, string includes="");

        void Add(TEntity item);

        void Delete(string id);

        void Update(TEntity item);

        void OnContextSaveChange(IDbContext context);

        System.Linq.IQueryable<TEntity> AsQueryable(string include = "");
    }
}
