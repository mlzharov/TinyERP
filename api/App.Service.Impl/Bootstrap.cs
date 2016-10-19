using App.Common.DI;
namespace App.Service.Impl
{
    public class Bootstrap : App.Common.Tasks.BaseTask<IBaseContainer>, IBootstrapper
    {
        public Bootstrap():base(App.Common.ApplicationType.All)
        {

        }
        public void Execute(IBaseContainer context)
        {
            context.RegisterSingleton<App.Service.Registration.User.IUserService, App.Service.Impl.Registration.UserService>();
            context.RegisterSingleton<App.Service.Common.ILanguageService, App.Service.Impl.Common.LanguageService>();
            context.RegisterSingleton<App.Service.Security.IRoleService, App.Service.Impl.Security.RoleService>();
            context.RegisterSingleton<App.Service.Security.IPermissionService, App.Service.Impl.Security.PermissionService>();
            context.RegisterSingleton<App.Service.Security.IUserGroupService, App.Service.Impl.Security.UserGroupService>();

            context.RegisterSingleton<App.Service.Common.File.IFileService, App.Service.Impl.Common.FileService>();
            context.RegisterSingleton<App.Service.Setting.IContentTypeService, App.Service.Impl.Setting.ContentTypeService>();
        }
    }
}
