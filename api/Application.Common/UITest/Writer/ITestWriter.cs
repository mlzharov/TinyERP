using App.Common.UITest.Suite;
using App.Common.UITest.UI;
using System;
using System.Collections.Generic;

namespace App.Common.UITest.Writer
{
    public interface ITestWriter:IDisposable
    {
        void Write(Suite.ITestSuite testSuite);

        void Write(Suite.TestCaseCollection testCaseCollection);

        void Write(Suite.TestCaseRef testCaseRef, IList<TestCaseAction> actions);

        void Write(Environment.Environment environment);

        void Write(Suite.TestCaseAction action);
        void Write(IUIAction uiAction);
    }
}
