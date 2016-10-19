using System.Xml;
namespace App.Common.UITest.UI
{
    public class UIClickAction : BaseUIAction
    {
        public UIClickAction(XmlNode node, App.Common.UITest.Runner.IWebDriver webDriver)
            : base(node, UIActionType.Click, webDriver)
        {
        }
        public override void Execute()
        {
            base.Execute();
            this.WebDriver.Click(this);
        }
    }
}
