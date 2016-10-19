using System.Data.Entity;

namespace App.Common.Tasks
{
    public interface IModelCreatingInDbContext : IBaseTask<DbModelBuilder>
    {
    }
}
