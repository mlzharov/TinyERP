namespace App.Common.UITest.Suite
{
    public interface ITestCaseCollection : IExecutable
    {
        System.Collections.Generic.List<TestIncludeRef> Includes { get; set; }
        System.Collections.Generic.List<TestCaseRef> TestCases { get; set; }
        TestCaseCollectionRef TestCaseCollectionRef { get; set; }
        ITestSuite Suite { get; set; }
    }
}
