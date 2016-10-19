using App.Common.Data;
using App.Entity.Common;

namespace App.Repository.Common
{
    public interface ILanguageRepository : IBaseRepository<Language>
    {
        void AddIfNotExist(Language item);
        Language GetByCode(string languageCode);
    }
}
