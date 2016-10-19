using App.Common.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using App.Common;
using App.Common.DI;
using App.Service.Registration.User;

namespace App.Api.Features.Share.Tasks.Data
{
    public class CreateUsersTask : BaseTask<TaskArgument<System.Web.HttpApplication>>, IApplicationReadyTask<TaskArgument<System.Web.HttpApplication>>
    {
        public CreateUsersTask() : base(ApplicationType.All)
        {
            this.Order = 2;
        }
        public override void Execute(TaskArgument<HttpApplication> context)
        {
            CreateLanguages();
            IList<Entity.Registration.User> users = new List<Entity.Registration.User>();
            users.Add(new Entity.Registration.User("tu.tran@orientsoftware.net", "123456"));
            users.Add(new Entity.Registration.User("tu.tran@yahoo.com", "123456","TU","Tran"));
            IUserService userService = IoC.Container.Resolve<IUserService>();
            userService.CreateIfNotExist(users);
        }

        private void CreateLanguages()
        {
            IList<Entity.Common.Language> languages = new List<Entity.Common.Language>();
            languages.Add(new Entity.Common.Language("Viet name","vn","VN-vn"));
            languages.Add(new Entity.Common.Language("English", "en", "EN-en"));
            Service.Common.ILanguageService languageService = IoC.Container.Resolve<Service.Common.ILanguageService>();
            languageService.Add(languages);
        }
    }
}