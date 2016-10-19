using System;
using App.Common;
using App.Common.Data;

namespace App.Repository.Common
{
    public interface IParameterRepository : IBaseContentRepository<App.Entity.Common.Parameter>
    {
        System.Collections.Generic.IList<App.Entity.Common.Parameter> GetByParentId(Guid id, ParameterParentType contentType);
    }
}
