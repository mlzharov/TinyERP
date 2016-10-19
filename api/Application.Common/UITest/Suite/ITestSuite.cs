namespace App.Common.UITest.Suite
{
    public interface ITestSuite : IExecutable
    {
        string Name { get; set; }
        string Description { get; set; }
        System.Collections.Generic.List<TestCaseCollectionRef> TestCaseCollection { get; set; }
        App.Common.UITest.Runner.ITestRunner TestRunner { get; set; }
        App.Common.UITest.Environment.IEnvironment Environment { get; set; }
        TestSuiteRef SuiteRef{get; set;}
    }
}
