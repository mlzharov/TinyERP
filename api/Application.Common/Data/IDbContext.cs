namespace App.Common.Data
{
    public interface IDbContext
    {
        //IDbSet<TEntity> GetDbSet<TEntity>();
        int SaveChanges();
        void RegisterSaveChangeEvent(OnContextSaveChange ev);
        void OnSaveChanged();
    }
}
