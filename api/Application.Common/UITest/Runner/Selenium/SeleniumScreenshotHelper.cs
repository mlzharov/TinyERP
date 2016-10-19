using OpenQA.Selenium;
using System.IO;
namespace App.Common.UITest.Runner.Selenium
{
    public class SeleniumScreenshotHelper
    {
        public static void CreateScreenshot(OpenQA.Selenium.IWebDriver webDriver, Environment.IEnvironment environment, string fileName)
        {
            string filePath = Path.Combine(environment.OutputFolder, fileName);
            Screenshot screenshotInstance = ((ITakesScreenshot)webDriver).GetScreenshot();
            screenshotInstance.SaveAsFile(filePath, System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
