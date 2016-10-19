using App.Common.Validation;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
namespace App.Common.Helpers
{
    public class XmlHelper
    {
        public static System.Xml.XmlNodeList GetByXPath(string filePath, string xpath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);
            return xmlDoc.SelectNodes(xpath);
        }
        public static System.Xml.XmlNode GetNodeByXPath(string filePath, string xpath)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(filePath);
            return xmlDoc.SelectSingleNode(xpath);
        }

        public static TResult Load<TResult>(string filePath, string rootElement)
        {
            TResult result;
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(TResult), new XmlRootAttribute(rootElement));
            using (FileStream fileStream = new FileStream(filePath, FileMode.Open))
            {
                result= (TResult)xmlSerializer.Deserialize(fileStream);
                //fileStream.Dispose();
            }
            return result;
        }

        public static TEntity LoadNodeAsObject<TEntity>(string dataFilePath, string xpath) where TEntity: class
        {
            XmlNode node = GetNodeByXPath(dataFilePath, xpath);
            if (node == null) {
                throw new ElementNotFound(dataFilePath, xpath);
            }
            XmlSerializer serializer = new XmlSerializer(typeof(TEntity));
            return serializer.Deserialize(new StringReader(node.OuterXml)) as TEntity;
        }
    }
}
