using App.Common.Validation;
using OpenQA.Selenium;
using App.Common.Extensions;
using System;

namespace App.Common.UITest.Runner.Selenium
{
    public class BaseSeleniumWebDriver : IWebDriver
    {
        public ITestRunner TestRunner { get; protected set; }
        public OpenQA.Selenium.IWebDriver Driver { get; protected set; }

        public BaseSeleniumWebDriver(ITestRunner testRunner)
        {
            this.TestRunner = testRunner;
        }
        public virtual void Dispose()
        {
            if (this.Driver == null) { return; }
            this.Driver.Dispose();
        }

        public void Click(UI.UIClickAction action)
        {
            try
            {
                action.Status = TestResultType.Fail;
                OpenQA.Selenium.IWebElement element = SeleniumUIHelper.GetElement(this.Driver, SeleniumUIHelper.GetBy(action.Element));
                element.Click();
                action.Status = TestResultType.Success;
            }
            catch (System.Exception ex)
            {
                action.Status = TestResultType.Fail;

                string fileName = string.Format("{0}_{1}_{2}.png", action.TestCaseAction.TestCase.TestCaseRef.Key, action.TestCaseAction.ActionRef.Action, System.DateTime.Now.ToString("yyyyMMddHHmmssms"));
                SeleniumScreenshotHelper.CreateScreenshot(this.Driver, this.TestRunner.Environment, fileName);

                action.Error = new ValidationException("Common.ElementCanNotFound", action.Element, fileName);
            }
        }

        public void Input(UI.UIInputAction action)
        {
            try
            {
                action.Status = TestResultType.Fail;
                OpenQA.Selenium.IWebElement element = SeleniumUIHelper.GetElement(this.Driver, SeleniumUIHelper.GetBy(action.Element));
                element.Clear();
                element.SendKeys(action.Value);
                action.Status = TestResultType.Success;
            }
            catch (System.Exception ex)
            {
                action.Status = TestResultType.Fail;

                string fileName = string.Format("{0}_{1}_{2}.png", action.TestCaseAction.TestCase.TestCaseRef.Key, action.TestCaseAction.ActionRef.Action, System.DateTime.Now.ToString("yyyyMMddHHmmssms"));
                SeleniumScreenshotHelper.CreateScreenshot(this.Driver, this.TestRunner.Environment, fileName);

                action.Error = new ValidationException("Common.ElementCanNotFound", action.Element, fileName);
            }
        }

        public void Assert(UI.UIAssertAction action)
        {
            try
            {
                action.Status = SeleniumUIHelper.Assert(action, this.Driver) ? TestResultType.Success : TestResultType.Fail;
            }
            catch (System.Exception ex)
            {
                action.Status = TestResultType.Fail;

                string fileName = string.Format("{0}_{1}_{2}.png", action.TestCaseAction.TestCase.TestCaseRef.Key, action.TestCaseAction.ActionRef.Action, System.DateTime.Now.ToString("yyyyMMddHHmmssms"));
                SeleniumScreenshotHelper.CreateScreenshot(this.Driver, this.TestRunner.Environment, fileName);

                action.Error = new ValidationException("Common.ElementCanNotFound", action.Element, fileName);
            }
        }

        public void Navigate(UI.UINavigateAction action)
        {
            try
            {

                action.Status = TestResultType.Fail;
                this.Driver.Navigate().GoToUrl(action.Url);
                action.Status = TestResultType.Success;
                if (action.Timeout.AsInt() > 0)
                {
                    this.Driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(action.Timeout.AsInt()));
                    System.Threading.Thread.Sleep(action.Timeout.AsInt());
                }
            }
            catch (System.Exception ex)
            {
                action.Status = TestResultType.Fail;

                string fileName = string.Format("{0}_{1}_{2}.png", action.TestCaseAction.TestCase.TestCaseRef.Key, action.TestCaseAction.ActionRef.Action, System.DateTime.Now.ToString("yyyyMMddHHmmssms"));
                SeleniumScreenshotHelper.CreateScreenshot(this.Driver, this.TestRunner.Environment, fileName);

                action.Error = new ValidationException("Common.ElementCanNotFound", action.Element, fileName);
            }
        }

        public void Sleep(int second)
        {
            this.Driver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(second));
            System.Threading.Thread.Sleep(second * 1000);
        }
    }
}
