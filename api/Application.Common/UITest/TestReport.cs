using System.Xml.Serialization;

namespace App.Common.UITest
{
    [XmlType("report")]
    public class TestReport : ITestReport
    {
        [XmlAttribute("type")]
        public TestReportType Type { get; set; }
    }
}
