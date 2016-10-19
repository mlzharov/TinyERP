using System;
using App.Common.Mapping;
using App.Entity.Registration;
using App.Repository.Registration;
using App.Common.Data;
using App.Common.Data.MSSQL;
using System.Linq;
using App.Common.Configurations;
using App.Common.DI;
using App.Repository.Common;

namespace App.Repository.Impl.Registration
{
    class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository() : base(new App.Context.AppDbContext(App.Common.IOMode.Read))
        {
        }

        public UserRepository(IUnitOfWork uow) : base(uow.Context as IMSSQLDbContext)
        {
        }

        public User GetByEmail(string email)
        {
            return this.DbSet.AsQueryable().Where(user => user.Email == email).FirstOrDefault();
        }


        public User GetByToken(string token)
        {
            return this.DbSet.AsQueryable().Where(user => user.Token == token).FirstOrDefault();
        }
        public override User GetById(string id)
        {
            User user = base.GetById(id);
            if (user != null) {
                ILanguageRepository languageRepository = IoC.Container.Resolve<ILanguageRepository>();
                string languageCode = String.IsNullOrWhiteSpace(user.LanguageCode) ? Configuration.Current.Localization.DefaultLanguageCode : user.LanguageCode;
                user.Language = languageRepository.GetByCode(languageCode);
            }
            return user;
        }
    }
}
