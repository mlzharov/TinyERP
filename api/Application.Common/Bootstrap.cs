using App.Common.DI;
using App.Common.Logging;
using App.Common.Tasks;

namespace App.Common
{
    public class Bootstrap :BaseTask<IBaseContainer>, IBootstrapper
    {
        public Bootstrap() : base(ApplicationType.All) { }
        public override void Execute(IBaseContainer context)
        {
            context.RegisterSingleton<ILogger, DefaultLogger>();
        }
    }
}
