using System.Xml;
namespace App.Common.UITest.UI
{
    public class UIInputAction : BaseUIAction
    {
        public string Value { get; set; }
        public UIInputAction(XmlNode node, App.Common.UITest.Runner.IWebDriver webDriver)
            : base(node, UIActionType.Input, webDriver)
        {
            this.Value = node.Attributes["value"].Value;
        }
        public override void ResolveParams(System.Collections.Generic.IList<Suite.TestDataKeyNamePair> actionParams)
        {
            base.ResolveParams(actionParams);
            this.Value = RepalceParamValue(this.Value, actionParams);
        }
        public override void Execute()
        {
            base.Execute();
            this.WebDriver.Input(this);
            //throw new System.NotImplementedException();
        }
    }
}
