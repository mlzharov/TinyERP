using App.Common.UITest.Environment;
namespace App.Common.UITest.Runner
{
    public class TestRunnerFactory
    {
        public static ITestRunner Create(IEnvironment environment)
        {
            return new App.Common.UITest.Runner.Selenium.SeleniumTestRunner(environment);
        }
    }
}
