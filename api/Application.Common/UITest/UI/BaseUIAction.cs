using App.Common.UITest.Suite;
using System.Text.RegularExpressions;
using System.Linq;
namespace App.Common.UITest.UI
{
    public class BaseUIAction : BaseExecutable, IUIAction
    {
        public App.Common.Validation.ValidationException Error { get; set; }
        public UIActionType Type { get; protected set; }
        public string Element { get; protected set; }
        public TestResultType Status { get; set; }
        public Suite.TestCaseAction TestCaseAction { get; set; }
        public App.Common.UITest.Runner.IWebDriver WebDriver { get; protected set; }
        public BaseUIAction(System.Xml.XmlNode node, UIActionType uIActionType, App.Common.UITest.Runner.IWebDriver webDriver)
        {
            this.WebDriver = webDriver;
            this.Type = uIActionType;
            this.Element = node.Attributes["element"] != null ? node.Attributes["element"].Value : string.Empty;
            this.Status = TestResultType.None;
        }
        public override void Execute()
        {
            this.Status = TestResultType.Success;
        }

        public virtual void ResolveParams(System.Collections.Generic.IList<Suite.TestDataKeyNamePair> actionParams)
        {
            this.Element = RepalceParamValue(this.Element, actionParams);
        }
        protected string RepalceParamValue(string pattern, System.Collections.Generic.IList<Suite.TestDataKeyNamePair> actionParams)
        {
            MatchCollection matches = Regex.Matches(pattern, "({{(\\w+)}})");
            foreach (Match match in matches)
            {
                string paramKey = match.Value.Replace("{{", "").Replace("}}", "").ToLower();
                TestDataKeyNamePair testDataParam = actionParams.Where(item => item.Key.ToLower() == paramKey).FirstOrDefault();
                if (testDataParam == null)
                {
                    continue;
                }
                pattern = Regex.Replace(pattern, match.Value, testDataParam.Value, RegexOptions.IgnoreCase);
            }
            return pattern;
        }
    }
}
