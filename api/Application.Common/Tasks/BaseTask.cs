using App.Common.Extensions;
namespace App.Common.Tasks
{
    public class BaseTask<TArgument> : IBaseTask<TArgument>
    {
        public int Order { get; protected set; }
        public ApplicationType ApplicationType { get; private set; }
        public BaseTask(ApplicationType applicationType)
        {
            this.ApplicationType = applicationType;
        }
        public virtual void Execute(TArgument context)
        {
            throw new System.NotImplementedException();
        }
        public virtual bool IsValid(ApplicationType type)
        {
            return type.IsIncludedIn(this.ApplicationType);
        }
    }
}
