using System.Xml.Serialization;
namespace App.Common.UITest.Suite
{
    [System.Serializable()]
    [XmlType("suite")]
    public class TestSuiteRef
    {
        [XmlAttribute("path")]
        public string Path { get; set; }
        [XmlAttribute("dataFile")]
        public string DataFile { get; set; }
    }
}
