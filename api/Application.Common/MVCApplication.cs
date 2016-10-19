namespace App.Common
{
    public class MVCApplication<TContext> : BaseApplication<TContext>
    {
        public MVCApplication(TContext context) : base(context,ApplicationType.MVC) { }
    }
}
