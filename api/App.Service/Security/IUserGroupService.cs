using App.Service.Security.UserGroup;
using System;

namespace App.Service.Security
{
    public interface IUserGroupService
    {
        System.Collections.Generic.IList<UserGroupListItemSummary> GetUserGroups();
        CreateUserGroupResponse Create(CreateUserGroupRequest request);
        void Delete(Guid id);
        GetUserGroupResponse Get(Guid id);
        void Update(UpdateUserGroupRequest request);
    }
}
