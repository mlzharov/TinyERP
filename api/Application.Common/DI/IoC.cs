namespace App.Common.DI
{
    public class IoC
    {
        public static IBaseContainer Container { get; set; }
        public static void CreateInstance(IBaseContainer baseContainer)
        {
            IoC.Container = baseContainer;
        }
    }
}
