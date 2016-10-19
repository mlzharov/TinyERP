namespace App.Common.UITest.Suite
{
    public class TestDataKeyNamePair
    {
        public TestDataKeyNamePair(string key, object value)
        {
            this.Key = key;
            this.Value = value != null ? value.ToString() : string.Empty;
        }
        public TestDataKeyNamePair(System.Xml.XmlAttribute attr)
        {
            this.Key = attr.Name;
            this.Value = attr.Value;
        }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
