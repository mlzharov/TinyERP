using App.Common.Tasks;
using System.Collections.Generic;
using System.Web;
using App.Common;
using App.Common.DI;
using App.Service.Setting;

namespace App.Api.Features.Share.Tasks
{
    public class CreateContentTypesTask : BaseTask<TaskArgument<System.Web.HttpApplication>>, IApplicationReadyTask<TaskArgument<System.Web.HttpApplication>>
    {
        public CreateContentTypesTask() : base(ApplicationType.All)
        {
        }
        public override void Execute(TaskArgument<HttpApplication> context)
        {
            if (!this.IsValid(context.Type)) { return; }
            IList<CreateContentTypeRequest> request = new List<CreateContentTypeRequest>();
            request.Add(new CreateContentTypeRequest("Product", "product", "Product desc"));
            request.Add(new CreateContentTypeRequest("Article", "article", "Article desc"));
            request.Add(new CreateContentTypeRequest("News", "news", "News desc"));
            IContentTypeService service = IoC.Container.Resolve<IContentTypeService>();
            service.CreateIfNotExist(request);
        }
    }
}