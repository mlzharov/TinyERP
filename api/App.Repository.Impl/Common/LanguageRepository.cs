using System;
using App.Common.Data;
using App.Entity.Common;
using App.Repository.Common;
using App.Common.Data.MSSQL;
using System.Linq;

namespace App.Repository.Impl.Common
{
    public class LanguageRepository : BaseRepository<Language>, ILanguageRepository
    {
        public LanguageRepository() : base(new App.Context.AppDbContext(App.Common.IOMode.Read))
        {
        }

        public LanguageRepository(IUnitOfWork uow) : base(uow.Context as IMSSQLDbContext)
        {
        }
        public void AddIfNotExist(Language item)
        {
            if (this.DbSet.AsQueryable().Any(languageItem => languageItem.Code == item.Code)) { return; }
            this.DbSet.Add(item);
        }

        public Language GetByCode(string languageCode)
        {
            return this.DbSet.AsQueryable().FirstOrDefault(item => item.Code == languageCode);
        }
    }
}
