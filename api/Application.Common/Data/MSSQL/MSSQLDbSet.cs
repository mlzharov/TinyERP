
using MongoDB.Bson;
using MongoDB.Kennedy;
using System;
using System.Linq;
using System.Data.Entity.Infrastructure;
namespace App.Common.Data.MSSQL
{
    public class MSSQLDbSet<TEntity> : DbSet<TEntity> where TEntity : class ,IBaseEntity<Guid>
    {
        public System.Data.Entity.DbSet<TEntity> DbSet { get; protected set; }
        public new App.Common.Data.MSSQL.IMSSQLDbContext Context { get; protected set; }

        public IOMode Mode { get; set; }
        private System.Data.Entity.DbContext EFContext { get; set; }


        public MSSQLDbSet(App.Common.Data.MSSQL.IMSSQLDbContext mssqlDbContext, System.Data.Entity.DbContext efContext, IOMode mode = IOMode.Read)
        {
            this.Context = mssqlDbContext;
            this.EFContext = efContext;
            this.Mode = mode;
            this.DbSet = this.EFContext.Set<TEntity>();
            this.Context.RegisterSaveChangeEvent(this.OnContextSaveChange);
        }
        protected DbQuery<TEntity> GetDbSet(string includes = "")
        {
            DbQuery<TEntity> query = this.Mode==IOMode.Read?this.DbSet.AsNoTracking() : this.DbSet;
            //DbQuery<TEntity> query = this.GetDbSet();
            if (!string.IsNullOrWhiteSpace(includes))
            {
                string[] includesItems = includes.Split(',');
                foreach (string item in includesItems)
                {
                    query = query.Include(item);
                }
            }
            return query;
        }

        public override void Add(TEntity item)
        {
            this.DbSet.Add(item);
        }

        public override void Delete(string id)
        {
            TEntity entity=Get(id);
            this.DbSet.Remove(entity);
        }

        public override TEntity Get(string id, string includes="")
        {
            Guid itemId=new Guid(id);
            DbQuery<TEntity> query = this.GetDbSet();
            if (!string.IsNullOrWhiteSpace(includes))
            {
                string[] includesItems = includes.Split(',');
                foreach (string item in includesItems) {
                    query = query.Include(item);
                }
            }
            return query.FirstOrDefault(item => item.Id == itemId);
        }

        public override void Update(TEntity item)
        {
            System.Data.Entity.Infrastructure.DbEntityEntry<TEntity> dbEntityEntry = this.EFContext.Entry(item);
            if (dbEntityEntry.State == System.Data.Entity.EntityState.Detached)
            {
                var keys = GetEntityKey<TEntity>(this.EFContext, item);
                TEntity attachedItem = this.DbSet.Find(keys);
                if (attachedItem == null)
                {
                    this.DbSet.Attach(item);
                    dbEntityEntry.State = System.Data.Entity.EntityState.Modified;
                }
                else
                {
                    this.EFContext.Entry(attachedItem).CurrentValues.SetValues(item);
                }
            }
        }
        public override void OnContextSaveChange(IDbContext context)
        {
        }

        private object[] GetEntityKey<T>(System.Data.Entity.DbContext context, T entity) where T : class ,IBaseEntity<Guid>
        {

            var oc = ((IObjectContextAdapter)context).ObjectContext;
            var keys = oc.MetadataWorkspace.GetEntityContainer(oc.DefaultContainerName, System.Data.Entity.Core.Metadata.Edm.DataSpace.CSpace)
                                             .BaseEntitySets
                                             .First(meta => meta.ElementType.Name == typeof(T).Name)
                                             .ElementType
                                             .KeyMembers
                                             .Select(k => k.Name)
                                             .ToList();


            var propertys =
                entity.GetType()
                     .GetProperties().Where(prop => keys.Contains(prop.Name));
            return propertys.ToList().Select(property => property.GetValue(entity, null)).ToArray();
        }
        public override IQueryable<TEntity> AsQueryable(string include = "")
        {
            return this.GetDbSet(include);
        }
    }
}
 