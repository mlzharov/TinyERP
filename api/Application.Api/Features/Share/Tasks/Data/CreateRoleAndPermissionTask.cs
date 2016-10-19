using App.Common.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.Common;
using App.Common.DI;
using App.Service.Registration.User;
using App.Service.Security;
using App.Entity.Security;

namespace App.Api.Features.Share.Tasks
{
    public class CreateRoleAndPermissionTask : BaseTask<TaskArgument<System.Web.HttpApplication>>, IApplicationReadyTask<TaskArgument<System.Web.HttpApplication>>
    {
        public CreateRoleAndPermissionTask() : base(ApplicationType.All)
        {
            this.Order = 2;
        }
        public override void Execute(TaskArgument<HttpApplication> context)
        {
            IRoleService roleService = IoC.Container.Resolve<IRoleService>();
            IList<Role> roles = GetRoles();
            roleService.CreateIfNotExist(roles);
        }
        private IList<Role> GetRoles() {
            IList<Role> roles = new List<Role>();
            roles.Add(new Role() {
                Key="Role1",
                Name="Role 1",
                Description="Role 1 desc",
                Permissions=new List<Permission>() {
                    new Permission() {
                        Key="Per1",
                        Name="Per 1",
                        Description="Per description"
                    }
                }
            });
            return roles;
        }

    }
}