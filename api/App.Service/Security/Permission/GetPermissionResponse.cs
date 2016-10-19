using App.Common.Data;
using App.Common.Mapping;

namespace App.Service.Security.Permission
{
    public class GetPermissionResponse : BaseContent, IMappedFrom<App.Entity.Security.Permission>
    {
        public GetPermissionResponse(): base()
        {
        }
    }
}
