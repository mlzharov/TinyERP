using OpenQA.Selenium;
namespace App.Common.UITest.Runner.Selenium
{
    public class SeleniumUIHelper
    {
        public static By GetBy(string element)
        {
            string[] values = element.Split(':');
            string by = values[0];
            element = values[1];

            switch (by.ToLower())
            {
                case "classname":
                    return By.ClassName(element);
                case "cssselector":
                    return By.CssSelector(element);
                case "linktext":
                    return By.LinkText(element);
                case "name":
                    return By.Name(element);
                case "partiallinktext":
                    return By.PartialLinkText(element);
                case "tagname":
                    return By.TagName(element);
                case "xpath":
                    return By.XPath(element);
                case "custom":
                    return null;
                default:
                case "id":
                    return By.Id(element);
            }
        }

        public static IWebElement GetElement(OpenQA.Selenium.IWebDriver webDriver, By selector, int maxRetry = 4, int interval = 2)
        {
            if (selector == null) { return null; }
            int currentRetry = 0;
            IWebElement element = null;
            do
            {
                try
                {
                    element = webDriver.FindElement(selector);
                }
                catch (System.Exception)
                {
                    webDriver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(interval));
                    System.Threading.Thread.Sleep(interval * 1000);
                }
                //if (element == null)
                //{
                //    webDriver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(interval));
                //    System.Threading.Thread.Sleep(interval * 1000);
                //}

            } while (element == null && currentRetry++ < maxRetry);

            return element;
        }
        public static System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> GetElements(OpenQA.Selenium.IWebDriver webDriver, By selector, int maxRetry = 2, int interval = 700)
        {
            int currentRetry = 0;
            System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> elements = null;
            do
            {
                try
                {
                    elements = webDriver.FindElements(selector);
                }
                catch (System.Exception) { }
                if (elements == null)
                {
                    webDriver.Manage().Timeouts().ImplicitlyWait(System.TimeSpan.FromSeconds(10));
                    System.Threading.Thread.Sleep(interval);
                }

            } while (elements == null && currentRetry++ < maxRetry);

            return elements;
        }

        #region Assert
        public static bool Assert(UI.UIAssertAction action, OpenQA.Selenium.IWebDriver webDriver)
        {
            By locator = SeleniumUIHelper.GetBy(action.Element);
            OpenQA.Selenium.IWebElement element = SeleniumUIHelper.GetElement(webDriver, locator);

            switch (action.AssertType)
            {
                case UIActionSeertType.Text:
                    return CheckTextAssert(element, action);
                    break;
                case UIActionSeertType.CssClass:
                    return CheckCssClassAssert(element, action);
                    break;
                case UIActionSeertType.Count:
                    System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> elements = SeleniumUIHelper.GetElements(webDriver, locator);
                    return CheckCountElementAssert(elements, action);
                    break;
                case UIActionSeertType.Browser:
                    return CheckBrowserAssert(webDriver, action);
                    break;
                case UIActionSeertType.Exist:
                default:
                    return CheckExistAssert(element, action);
            }
        }
        private static bool CheckBrowserAssert(OpenQA.Selenium.IWebDriver webDriver, UI.UIAssertAction action)
        {
            return webDriver.Url.ToLower() == action.Value.ToLower();
        }
        private static bool CheckExistAssert(IWebElement element, UI.UIAssertAction action)
        {
            return element != null;
        }

        private static bool CheckCountElementAssert(System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> elements, UI.UIAssertAction action)
        {
            int count = int.Parse(action.Value);
            return elements != null && elements.Count == count;
        }

        private static bool CheckCssClassAssert(IWebElement element, UI.UIAssertAction action)
        {
            return element != null && element.GetAttribute("class").ToLower() == action.Value.ToLower();
        }

        private static bool CheckTextAssert(IWebElement element, UI.UIAssertAction action)
        {
            return element != null && element.Text.ToLower() == action.Value.ToLower();
        }
        #endregion
    }
}
