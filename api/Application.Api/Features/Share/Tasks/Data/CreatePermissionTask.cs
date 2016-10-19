using App.Common.Tasks;
using System.Collections.Generic;
using System.Web;
using App.Common;
using App.Common.DI;
using App.Service.Security;
using App.Entity.Security;
using System;
using App.Common.Helpers;

namespace App.Api.Features.Share.Tasks
{
    public class CreatePermissionTask : BaseTask<TaskArgument<System.Web.HttpApplication>>, IApplicationReadyTask<TaskArgument<System.Web.HttpApplication>>
    {
        public CreatePermissionTask() : base(ApplicationType.All)
        {
        }
        public override void Execute(TaskArgument<HttpApplication> context)
        {
            IPermissionService perService = IoC.Container.Resolve<IPermissionService>();
            IList<Permission> pers = GetPermissions();
            perService.CreateIfNotExist(pers);
        }

        private IList<Permission> GetPermissions()
        {
            return new List<Permission>()
            {
                new Permission("View User","common.permissions.user.view","common.permissions.user.viewDesc"),
                new Permission("Edit User","common.permissions.user.edit","common.permissions.user.editDesc"),
                new Permission("Add User","common.permissions.user.add","common.permissions.user.addDesc"),
            };
        }
    }
}