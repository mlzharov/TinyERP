using System.Web;

namespace App.Common.Tasks
{
    public interface IApplicationEndedTask : IBaseTask<HttpContext>
    {
    }
}
