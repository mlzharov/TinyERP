using App.Common.Helpers;
namespace App.Common.UITest.UI
{
    public class UIActionFactory
    {
        public static IUIAction Create(System.Xml.XmlNode node, App.Common.UITest.Runner.IWebDriver webDriver)
        {
            string tagName = node.Name;
            UIActionType actionType = EnumHelper.Convert<UIActionType>(tagName);
            switch (actionType) {
                case UIActionType.Assert:
                    return new UIAssertAction(node, webDriver);
                case UIActionType.Navigate:
                    return new UINavigateAction(node, webDriver);
                case UIActionType.Click:
                    return new UIClickAction(node, webDriver);
                case UIActionType.Input:
                default:
                    return new UIInputAction(node, webDriver);
            }
        }
    }
}
