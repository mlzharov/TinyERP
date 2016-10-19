using App.Common.Configurations;
using App.Common.Helpers;
using System;
using System.IO;
using System.Xml.Serialization;
namespace App.Common.UITest.Suite
{
    [Serializable()]
    [System.Xml.Serialization.XmlType("suite")]
    public class TestSuite :BaseExecutable,  ITestSuite
    {
        [XmlIgnore]
        public TestSuiteRef SuiteRef{get; set;}
        [XmlIgnore]
        public App.Common.UITest.Environment.IEnvironment Environment { get; set; }
        [XmlIgnore]
        public App.Common.UITest.Runner.ITestRunner TestRunner { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("description")]
        public string Description { get; set; }
        [XmlElement("testcases")]
        public System.Collections.Generic.List<TestCaseCollectionRef> TestCaseCollection { get; set; }
        
        /// <summary>
        /// This construcntor should be called from serialized only
        /// </summary>
        public TestSuite() { }
        public TestSuite(TestSuiteRef suiteRef, Environment.IEnvironment environment, Runner.ITestRunner testRunner)
        {
            this.SuiteRef = suiteRef;
            this.Environment = environment;
            this.TestRunner = testRunner;
        }

        public override void Execute()
        {

            string filePath = Path.Combine(Configuration.Current.UITest.BasePath, this.SuiteRef.Path);
            ITestSuite testSuite = XmlHelper.Load<TestSuite>(filePath, "suite");
            testSuite.TestRunner = this.TestRunner;
            testSuite.Environment = this.Environment;
            testSuite.SuiteRef = this.SuiteRef;

            this.TestRunner.Writer.Write(testSuite);
            foreach (TestCaseCollectionRef tcr in testSuite.TestCaseCollection)
            {
                IExecutable testCases = new TestCaseCollection(tcr, testSuite);
                testCases.Execute();
            }


        }
    }
}
