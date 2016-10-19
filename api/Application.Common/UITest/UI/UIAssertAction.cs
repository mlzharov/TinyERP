using App.Common.Helpers;
using System.Xml;
using App.Common.UITest.Suite;
using System.Collections.Generic;

namespace App.Common.UITest.UI
{
    public class UIAssertAction : BaseUIAction
    {
        public UIActionSeertType AssertType { get; set; }
        public string Value { get; set; }
        public UIAssertAction(XmlNode node, App.Common.UITest.Runner.IWebDriver webDriver)
            : base(node, UIActionType.Assert, webDriver)
        {
            string type = node.Attributes["type"] != null ? node.Attributes["type"].Value : UIActionSeertType.Exist.ToString();
            this.AssertType = EnumHelper.Convert<UIActionSeertType>(type);
            this.Value = node.Attributes["value"] != null ? node.Attributes["value"].Value : string.Empty;
        }
        public override void ResolveParams(IList<TestDataKeyNamePair> actionParams)
        {
            base.ResolveParams(actionParams);
            this.Value = RepalceParamValue(this.Value, actionParams);
        }
        public override void Execute()
        {
            base.Execute();
            this.WebDriver.Assert(this);
            //throw new System.NotImplementedException();
        }
    }
}
