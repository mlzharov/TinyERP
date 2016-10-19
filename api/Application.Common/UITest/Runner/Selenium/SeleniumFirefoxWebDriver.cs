namespace App.Common.UITest.Runner.Selenium
{
    public class SeleniumFirefoxWebDriver: BaseSeleniumWebDriver
    {
        public SeleniumFirefoxWebDriver(ITestRunner testRunner)
            : base(testRunner)
        {
            this.Driver = new OpenQA.Selenium.Firefox.FirefoxDriver();
        }
    }
}
