using System.Web;

namespace App.Common.Tasks
{
    public interface IApplicationStartedTask<TContext> : IBaseTask<TContext>
    {
    }
}
