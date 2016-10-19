using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
namespace App.Common.UITest.Suite
{
    [Serializable()]
    [System.Xml.Serialization.XmlType("step")]
    public class TestCaseActionRef
    {
        [XmlAttribute("action")]
        public string Action { get; set; }
        [XmlAttribute("sleepBefore")]
        public string SleepBefore { get; set; }

        [XmlAnyAttribute]
        public XmlAttribute[] Attributes { get; set; }

        [XmlIgnore]
        public IList<TestDataKeyNamePair> Params
        {
            get
            {
                IList<TestDataKeyNamePair> attrs = new List<TestDataKeyNamePair>();
                if (this.Attributes != null && this.Attributes.Length > 0)
                {
                    foreach (XmlAttribute attr in this.Attributes)
                    {
                        attrs.Add(new TestDataKeyNamePair(attr));
                    }
                }
                return attrs;

            }
        }
    }
}
