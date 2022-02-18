using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace PROTELCase.Domain.Serializer
{
    public class XMLSerializer : IXMLSerializer
    {
        public T Deserializer<T>(string value)
        {
            var serializer = new XmlSerializer(typeof(T));

            var dataReader = new StringReader(value);

            return (T)serializer.Deserialize(dataReader);

        }

        public string Serializer(object value)
        {
            var nameSpace = new XmlSerializerNamespaces();

            nameSpace.Add("", "");
            var writer = new StringWriter();
            var xmlSettings = new XmlWriterSettings
            {
                OmitXmlDeclaration = true

            };

            using var xmlWriter = XmlWriter.Create(writer, xmlSettings);
            var serializer = new XmlSerializer(value.GetType());
            serializer.Serialize(xmlWriter, value, nameSpace);
            return writer.ToString();
        }
    }
}
