using App.Common.Configurations;
using App.Common.Helpers;
using System;
using System.Xml.Serialization;
namespace App.Common.UITest.Suite
{
    [Serializable()]
    [XmlType("testcases")]
    public class TestCaseCollection :BaseExecutable, ITestCaseCollection
    {
        [XmlIgnore]
        public TestCaseCollectionRef TestCaseCollectionRef { get; set; }
        [XmlIgnore]
        public ITestSuite Suite { get; set; }
        [XmlElement("include")]
        public System.Collections.Generic.List<TestIncludeRef> Includes { get; set; }
        [XmlElement("testcase")]
        public System.Collections.Generic.List<TestCaseRef> TestCases { get; set; }
        public TestCaseCollection() { }
        public TestCaseCollection(TestCaseCollectionRef tcr, ITestSuite testSuite)
        {
            this.TestCaseCollectionRef = tcr;
            this.Suite = testSuite;
        }

        public override void Execute()
        {
            string filePath = System.IO.Path.Combine(Configuration.Current.UITest.BasePath, this.TestCaseCollectionRef.Path);
            TestCaseCollection testCaseCollection = XmlHelper.Load<TestCaseCollection>(filePath, "testcases");
            testCaseCollection.TestCaseCollectionRef = this.TestCaseCollectionRef;
            testCaseCollection.Suite = this.Suite;

            this.Suite.TestRunner.Writer.Write(testCaseCollection);
            foreach (TestCaseRef tcf in testCaseCollection.TestCases)
            {
                IExecutable tc = new TestCase(tcf, testCaseCollection);
                tc.BeforeExecute();
                tc.Execute();
                tc.AfterExecute();
            }
        }
    }
}
