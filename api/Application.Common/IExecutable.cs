namespace App.Common
{
    public interface IExecutable
    {
        void Execute();

        void BeforeExecute();

        void AfterExecute();
    }
}
