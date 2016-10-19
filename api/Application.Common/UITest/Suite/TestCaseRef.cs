using System.Xml.Serialization;
namespace App.Common.UITest.Suite
{
    [System.Serializable()]
    [XmlType("testcase")]
    public class TestCaseRef
    {
        [XmlElement("key")]
        public string Key { get; set; }
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("description")]
        public string Description { get; set; }
        [XmlElement("step")]
        public System.Collections.Generic.List<TestCaseActionRef> Actions { get; set; }
        [XmlIgnore]
        public TestResultType Status { get; set; }
        //[XmlArray("steps")]
        //[XmlArrayItem("step")]
        //TestCaseActionRef[] Actions { get; set; }
    }
}
