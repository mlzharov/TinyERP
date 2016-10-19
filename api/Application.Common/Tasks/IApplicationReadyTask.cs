using System.Web;

namespace App.Common.Tasks
{
    public interface IApplicationReadyTask<TContext> : IBaseTask<TContext>
    {
    }
}
