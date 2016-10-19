using App.Common.Validation;
namespace App.Common
{
    public class ApplicationFactory
    {
        public static IApplication Create<TContext>(ApplicationType type, TContext application)
        {
            switch(type){
                case ApplicationType.Console: 
                    return new ConsoleApplication<TContext>(application);
                    break;
                case ApplicationType.MVC:
                    return new MVCApplication<TContext>(application);
                    break;
                case ApplicationType.WebApi:
                    return new WebApiApplication(application as System.Web.HttpApplication);
                    break;
                default:
                    throw new ValidationException("Common.ApplicationDoesNotSupported", type);
                    break;
            }
        }
    }
}
