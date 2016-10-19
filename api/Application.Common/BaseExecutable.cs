namespace App.Common
{
    public class BaseExecutable : IExecutable
    {
        public virtual void Execute()
        {
        }

        public virtual void BeforeExecute()
        {
        }

        public virtual void AfterExecute()
        {
        }
    }
}
