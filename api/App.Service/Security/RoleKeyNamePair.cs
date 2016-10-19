using App.Common.Data;
using App.Common.Mapping;

namespace App.Service.Security
{
    public class RoleKeyNamePair: BaseEntity, IMappedFrom<App.Entity.Security.Role>
    {
        public string Name { get; set; }
    }
}
