using System.Web;

namespace App.Common.Tasks
{
    public interface IApplicationRequestExecutingTask<TArgument> : IBaseTask<TArgument>
    {
    }
}
