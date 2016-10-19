using System.Xml.Serialization;
namespace App.Common.UITest.Suite
{
    [System.Serializable()]
    [XmlType("include")]
    public class TestIncludeRef
    {
        [XmlAttribute("path")]
        public string Path { get; set; }
        [XmlAttribute("alias")]
        public string Alias { get; set; }
    }
}
