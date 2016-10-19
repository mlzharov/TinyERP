using App.Common.DI;
namespace App.Api.Features.Share
{
    public class Bootstrap : App.Common.Tasks.BaseTask<IBaseContainer>, IBootstrapper
    {
        public Bootstrap():base(App.Common.ApplicationType.All){}
        public void Execute(IBaseContainer context)
        {
            context.RegisterSingleton<App.Common.Authorize.IUserLoginAuthorization, App.Api.Features.Share.Authorize.UserLoginAuthorization>();
        }
    }
}