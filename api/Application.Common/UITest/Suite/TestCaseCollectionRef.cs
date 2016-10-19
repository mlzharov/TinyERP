using System.Xml.Serialization;
namespace App.Common.UITest.Suite
{
    [System.Serializable()]
    [XmlType("testcases")]
    public class TestCaseCollectionRef
    {
        [XmlAttribute("path")]
        public string Path { get; set; }
    }
}
