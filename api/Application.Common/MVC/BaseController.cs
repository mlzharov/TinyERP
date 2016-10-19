using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
namespace App.Common.MVC
{
    public class BaseController : Controller
    {
        public BaseController ( ) : base ( )
        {
        }

        protected override void OnActionExecuting ( ActionExecutingContext filterContext )
        {
        }

		protected ActionResult JsonResponse(object data, JsonRequestBehavior behavior = JsonRequestBehavior.DenyGet)
        {
            var serializationSettings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            var jsonResult = new ContentResult()
            {
                ContentType = "application/json",
                Content = JsonConvert.SerializeObject(data, serializationSettings)
            };
            return jsonResult;
        }
    }
}
