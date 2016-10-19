using App.Common.Helpers;
namespace App.Common.UITest.Environment
{
    public class EnvironmentFactory
    {
        public static System.Collections.Generic.IList<IEnvironment> Load(string environtmentFilePath)
        {
            IEnvironment[] items = XmlHelper.Load<Environment[]>(environtmentFilePath, "environments");
            return items;
        }
    }
}
