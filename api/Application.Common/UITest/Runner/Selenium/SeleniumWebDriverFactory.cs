namespace App.Common.UITest.Runner.Selenium
{
    public class SeleniumWebDriverFactory
    {
        public static IWebDriver Create(ITestRunner testRunner)
        {
            switch (testRunner.Environment.Browser.Type) { 
                case BrowserType.Firefox:
                default:
                    return new SeleniumFirefoxWebDriver(testRunner);
            }
        }
    }
}
