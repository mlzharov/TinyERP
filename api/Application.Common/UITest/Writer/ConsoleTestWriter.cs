using App.Common.UITest.Environment;
using App.Common.UITest.UI;
namespace App.Common.UITest.Writer
{
    public class ConsoleTestWriter : BaseTestWriter
    {
        public ConsoleTestWriter(IEnvironment environtment): base(environtment) {}
        public override void Write(Environment.Environment environment)
        {
            string str = string.Format("Environment :{0}-{1}-{2}", environment.Name, environment.Browser.Type, environment.Description);
            System.Console.WriteLine(str);
        }

        public override void Write(Suite.ITestSuite testSuite)
        {
            string str = string.Format("Running test suite:{0}-{1}", testSuite.Name, testSuite.Description);
            System.Console.WriteLine(str);
        }

        public override void Write(Suite.TestCaseCollection testCaseCollection)
        {
            string str = string.Format("testCaseCollection:{0}", testCaseCollection.TestCaseCollectionRef.Path);
            System.Console.WriteLine(str);
        }

        public override void Write(Suite.TestCaseRef testCaseRef, System.Collections.Generic.IList<Suite.TestCaseAction> actions)
        {
            string str = string.Format("TestCaseRef :{0}-{1}-{2}-{3}", testCaseRef.Name, testCaseRef.Key, testCaseRef.Description, testCaseRef.Status);
            System.Console.WriteLine(str);
        }

        public override void Write(Suite.TestCaseAction action)
        {
            string str = string.Format("TestCaseAction :{0}-{1}", action.ActionRef.Action, action.Status);
            System.Console.WriteLine(str);
            foreach (IUIAction uiAction in action.UIActions) {
                Write(uiAction);
            }
        }
        public override void Write(IUIAction uiAction)
        {
            string str = string.Format("IUIAction:{0}-{1}-{2}", uiAction.Type.ToString(), uiAction.Element, uiAction.Status.ToString());
            System.Console.WriteLine(str);
        }
    }
}
