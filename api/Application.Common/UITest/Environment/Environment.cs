using App.Common.Configurations;
using App.Common.Helpers;
using App.Common.UITest.Runner;
using App.Common.UITest.Suite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
namespace App.Common.UITest.Environment
{
    [Serializable()]
    [XmlType("environment")]
    public class Environment : BaseExecutable, IEnvironment
    {
        private static string outputFolder = string.Empty;
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("description")]
        public string Description { get; set; }
        [XmlElement("width")]
        public int Width { get; set; }
        [XmlElement("height")]
        public int Height { get; set; }
        [XmlElement("baseUrl")]
        public string BaseUrl { get; set; }
        [XmlElement("suite")]
        public List<TestSuiteRef> Suites { get; set; }
        [XmlElement("report")]
        public TestReport Report { get; set; }
        [XmlElement("browser")]
        public BrowserRef Browser { get; set; }

        public override void Execute()
        {
            Prepare();
            using (ITestRunner testRunner = TestRunnerFactory.Create(this))
            {
                testRunner.Writer.Write(this);
                foreach (TestSuiteRef suiteRef in this.Suites)
                {
                    IExecutable testSuite = new App.Common.UITest.Suite.TestSuite(suiteRef, this, testRunner);
                    testSuite.Execute();
                }
            }
        }

        private void Prepare()
        {
            FileHelper.CreateIfNotExist(this.OutputFolder);
        }

        public string OutputFolder
        {
            get {
                if (string.IsNullOrWhiteSpace(Environment.outputFolder))
                {
                    Environment.outputFolder = string.Format("{0}{1}\\{2}", Configuration.Current.UITest.BaseOutput, this.Browser.Type.ToString(), DateTime.Now.ToString("yyyyMMddHHmmss"));
                }
                return Environment.outputFolder;
            }
        }
    }
}
