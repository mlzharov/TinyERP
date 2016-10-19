using App.Common.Data;
using App.Common.Mapping;
using App.Entity.Security;

namespace App.Service.Security
{
    public class DeleteRoleResponse: BaseContent, IMappedFrom<Role>
    {
    }
}
