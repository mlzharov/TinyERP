using System.Collections.Generic;
namespace App.Common.Data
{
    public delegate void OnContextSaveChange(IDbContext context);
    public class DbContext : IDbContext
    {
        IList<OnContextSaveChange> saveChangeEvents;
        public DbContext()
        {
            saveChangeEvents = new List<OnContextSaveChange>();
        }
        //public virtual IDbSet<TEntity> GetDbSet<TEntity>()
        //{
        //    IDbSet<TEntity> dbset = new DbSet<TEntity>(this);
        //    return dbset;
        //}

        public int SaveChanges()
        {
            return 0;
        }
        public void RegisterSaveChangeEvent(OnContextSaveChange ev)
        {
 	        this.saveChangeEvents.Add(ev);
        }
        public virtual void OnSaveChanged()
        {
            foreach (OnContextSaveChange ev in this.saveChangeEvents)
            {
                ev(this);
            }
        }
    }
}
