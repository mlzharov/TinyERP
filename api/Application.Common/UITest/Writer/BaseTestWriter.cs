using App.Common.UITest.Environment;

namespace App.Common.UITest.Writer
{
    public class BaseTestWriter: ITestWriter
    {
        public IEnvironment Environment { get; protected set; }

        public BaseTestWriter(IEnvironment environment)
        {
            this.Environment = environment;
        }
        public virtual void Write(Suite.ITestSuite testSuite)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Write(Suite.TestCaseCollection testCaseCollection)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Write(Suite.TestCaseRef testCaseRef, System.Collections.Generic.IList<Suite.TestCaseAction> actions)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Write(Environment.Environment environment)
        {
            throw new System.NotImplementedException();
        }

        public virtual void Write(Suite.TestCaseAction action)
        {
            throw new System.NotImplementedException();
        }
        public virtual void Write(UI.IUIAction uiAction)
        {
            throw new System.NotImplementedException();
        }
        public virtual void Dispose()
        {
        }
    }
}
