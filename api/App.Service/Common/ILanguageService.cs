using System.Collections.Generic;
using App.Entity.Common;

namespace App.Service.Common
{
    public interface ILanguageService
    {
        void Add(IList<Language> languages);
    }
}
