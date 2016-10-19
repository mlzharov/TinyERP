using System;
using System.Collections.Generic;
using System.Linq;
namespace App.Common.Data.MSSQL
{
    public class MSSQLDbContext : System.Data.Entity.DbContext, IMSSQLDbContext
    {
        IList<OnContextSaveChange> saveChangeEvents;
        System.Data.Entity.DbContext context;
        protected IOMode Mode { get; private set; }
        public MSSQLDbContext(IConnectionString connection, IOMode mode = IOMode.Read) : base(connection.ToString())
        {
            this.Mode = mode;
            saveChangeEvents = new List<OnContextSaveChange>();
            this.context = this;// new System.Data.Entity.DbContext(connection.ToString());
        }
        //public MSSQLDbContext(IConnectionString connection, IOMode mode = IOMode.Read): base(connection.Name)
        //{
        //    this.Mode = mode;
        //    saveChangeEvents = new List<OnContextSaveChange>();
        //    this.context = this;// new System.Data.Entity.DbContext(connection.ToString());
        //}

        //public override int SaveChanges()
        //{
        //    return this.context.SaveChanges();
        //    //return this.context.SaveChanges();
        //}
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


        public IDbSet<TEntity> GetDbSet<TEntity>() where TEntity : class, IBaseEntity<System.Guid>
        {
            IDbSet<TEntity> dbset = new App.Common.Data.MSSQL.MSSQLDbSet<TEntity>(this, this.context, this.Mode);
            return dbset;
        }

    }
}
