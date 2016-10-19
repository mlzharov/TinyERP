using App.Common.Configurations;
using App.Common.Helpers;
using App.Common.UITest.Runner;
using System.Collections.Generic;
using System.IO;
using App.Common.Extensions;
namespace App.Common.UITest.Suite
{
    public class TestCase : BaseExecutable
    {
        public TestCaseRef TestCaseRef { get; protected set; }
        public TestCaseCollection TestCaseCollection { get; protected set; }
        public IWebDriver WebDriver { get; protected set; }

        public TestCase(TestCaseRef tcf, TestCaseCollection testCaseCollection)
        {
            this.TestCaseRef = tcf;
            this.TestCaseCollection = testCaseCollection;
        }

        public override void Execute()
        {
            //foreach (TestCaseRef tcRef in this.TestCaseCollection.TestCases)
            //{
                IList<TestCaseAction> actions = this.Execute(this.TestCaseRef);
                PrintReport(this.TestCaseRef, actions);
            //}
            //this.TestCaseCollection.Suite.TestRunner.Writer.Write(this.TestCaseRef);
        }
        public override void BeforeExecute()
        {
            base.BeforeExecute();
            this.WebDriver = this.TestCaseCollection.Suite.TestRunner.CreateWebDriver();
        }
        public override void AfterExecute()
        {
            base.AfterExecute();
            this.WebDriver.Dispose();
        }

        private void PrintReport(Suite.TestCaseRef tcRef, IList<TestCaseAction> actions)
        {
            this.TestCaseCollection.Suite.TestRunner.Writer.Write(tcRef, actions);
            foreach (TestCaseAction action in actions)
            {
                this.TestCaseCollection.Suite.TestRunner.Writer.Write(action);
            }
        }

        private IList<TestCaseAction> Execute(Suite.TestCaseRef tcRef)
        {
            IList<TestCaseAction> actions = new List<TestCaseAction>();
            IList<TestDataKeyNamePair> testData = GetTestData(tcRef.Key);
            foreach (TestCaseActionRef actionRef in tcRef.Actions)
            {
                TestCaseAction testAction = new TestCaseAction(actionRef, this, testData, this.TestCaseCollection.Includes);
                if (actionRef.SleepBefore.AsInt() > 0)
                {
                    this.WebDriver.Sleep(actionRef.SleepBefore.AsInt());
                }
                testAction.Execute();
                actions.Add(testAction);

                if (testAction.Status == TestResultType.Fail)
                {
                    tcRef.Status = TestResultType.Fail;
                    break;
                }
            }
            tcRef.Status = TestResultType.Success;
            return actions;
        }

        private IList<TestDataKeyNamePair> GetTestData(string testCaseKey)
        {
            string dataFilePath = Path.Combine(Configuration.Current.UITest.BasePath, this.TestCaseCollection.Suite.SuiteRef.DataFile);
            TestCaseData data= XmlHelper.LoadNodeAsObject<TestCaseData>(dataFilePath, @"/testcases/testcase[@key='" + testCaseKey + "']");
            IList<TestDataKeyNamePair> keyPairs = data.Values;
            TestCaseHelper.AddEnvirontmentParams(keyPairs, this.WebDriver.TestRunner.Environment);
            return keyPairs;
        }
    }
}
