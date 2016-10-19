using App.Common.UITest.Environment;
using App.Common.UITest.Writer;
namespace App.Common.UITest.Runner.Selenium
{
    public class SeleniumTestRunner : ITestRunner
    {
        public App.Common.UITest.Writer.ITestWriter Writer { get; protected set; }
        public IEnvironment Environment { get; protected set; }
        public SeleniumTestRunner(IEnvironment environment)
        {
            this.Writer = TestWriterFactory.Create(environment);
            this.Environment = environment;
        }
        public void Dispose()
        {
            this.Writer.Dispose();
        }


        public IWebDriver CreateWebDriver()
        {
            IWebDriver webDriver = SeleniumWebDriverFactory.Create(this);
            return webDriver;
        }
    }
}
