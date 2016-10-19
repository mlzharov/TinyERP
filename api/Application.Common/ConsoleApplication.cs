namespace App.Common
{
    public class ConsoleApplication<TContext>:BaseApplication<TContext>
    {
        public ConsoleApplication(TContext context) : base(context,ApplicationType.Console) { }
    }
}
