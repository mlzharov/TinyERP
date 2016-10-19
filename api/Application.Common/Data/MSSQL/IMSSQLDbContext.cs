namespace App.Common.Data.MSSQL
{
    public interface IMSSQLDbContext : IDbContext
    {
        IDbSet<TEntity> GetDbSet<TEntity>() where TEntity: class, IBaseEntity<System.Guid>;
    }
}
