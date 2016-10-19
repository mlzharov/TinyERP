using App.Common.Configurations;
using App.Common.Helpers;
using App.Common.UITest.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml;
namespace App.Common.UITest.Suite
{
    public class TestCaseAction : BaseExecutable
    {
        public TestCaseActionRef ActionRef { get; set; }
        public IList<TestDataKeyNamePair> TestData { get; set; }
        public TestCase TestCase { get; set; }
        public System.Collections.Generic.List<TestIncludeRef> Includes { get; set; }
        public TestResultType Status { get; set; }
        public IList<IUIAction> UIActions { get; set; }

        public TestCaseAction(TestCaseActionRef actionRef, TestCase testCase, IList<TestDataKeyNamePair> testData, System.Collections.Generic.List<TestIncludeRef> includes)
        {
            this.UIActions = new List<IUIAction>();
            this.ActionRef = actionRef;
            this.TestData = testData;
            this.Includes = includes;
            this.TestCase = testCase;
        }
        public override void Execute()
        {
            IList<TestDataKeyNamePair> actionParams = this.ResolveActionData();
            IList<IUIAction> uiActions = this.GetUIActions();
            this.Status = TestResultType.Success;
            foreach (IUIAction uiAction in uiActions)
            {
                uiAction.ResolveParams(actionParams);
                uiAction.Execute();

                this.UIActions.Add(uiAction);
                if (uiAction.Status == TestResultType.Fail)
                {
                    this.Status = TestResultType.Fail;
                    break;
                }
            }
            
        }

        private IList<IUIAction> GetUIActions()
        {
            IList<IUIAction> uiActions = new List<IUIAction>();
            string alias = this.ActionRef.Action.Split('.')[0].ToLower();
            string actionName = this.ActionRef.Action.Split('.')[1];
            TestIncludeRef includeRef = this.Includes.Where(item => item.Alias.ToLower() == alias).FirstOrDefault();
            string filePath = Path.Combine(Configuration.Current.UITest.BasePath, includeRef.Path);
            XmlNode uiSteps = XmlHelper.GetNodeByXPath(filePath, String.Format("/steps/step[@name='{0}']", actionName));
            foreach (XmlNode uiStepAction in uiSteps.ChildNodes)
            {
                IUIAction uiAction = UIActionFactory.Create(uiStepAction, this.TestCase.WebDriver);
                uiAction.TestCaseAction = this;
                uiActions.Add(uiAction);
            }
            return uiActions;
        }

        private IList<TestDataKeyNamePair> ResolveActionData()
        {
            IList<TestDataKeyNamePair> actionParams = new List<TestDataKeyNamePair>();
            foreach (TestDataKeyNamePair actionRefParam in this.ActionRef.Params)
            {
                actionRefParam.Value = RepalceParamValue(actionRefParam.Value);
                actionParams.Add(actionRefParam);
            }
            return actionParams;
        }

        private string RepalceParamValue(string pattern)
        {
            MatchCollection matches = Regex.Matches(pattern, "({{(\\w+)}})");
            foreach (Match match in matches)
            {
                string paramKey = match.Value.Replace("{{", "").Replace("}}", "").ToLower();
                TestDataKeyNamePair testDataParam = this.TestData.Where(item => item.Key.ToLower() == paramKey).FirstOrDefault();
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
