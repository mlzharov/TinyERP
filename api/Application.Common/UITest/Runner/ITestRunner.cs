using App.Common.UITest.Environment;
namespace App.Common.UITest.Runner
{
    public interface ITestRunner:System.IDisposable
    {
        App.Common.UITest.Writer.ITestWriter Writer { get; }
        IEnvironment Environment { get; }
        IWebDriver CreateWebDriver();
    }
}
