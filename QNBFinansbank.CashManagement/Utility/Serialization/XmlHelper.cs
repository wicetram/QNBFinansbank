using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace QNBFinansbank.CashManagement.Utility.Serialization
{
    public static class XmlHelper
    {
        /// <summary>
        /// Verilen objeyi XML string'e çevirir.
        /// </summary>
        /// <typeparam name="T">Serileştirilecek nesnenin tipi.</typeparam>
        /// <param name="obj">Serileştirilecek nesne.</param>
        /// <returns>XML string formatında serileştirilmiş nesne.</returns>
        public static string SerializeToXml<T>(T obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(nameof(obj), "Object cannot be null");
            }

            XmlSerializer xmlSerializer = new(typeof(T));

            using StringWriter stringWriter = new();
            using XmlWriter xmlWriter = XmlWriter.Create(stringWriter, new XmlWriterSettings { Encoding = Encoding.UTF8 });
            xmlSerializer.Serialize(xmlWriter, obj);
            return stringWriter.ToString();
        }

        /// <summary>
        /// Verilen XML string'i objeye çevirir.
        /// </summary>
        /// <typeparam name="T">Deserileştirilecek nesnenin tipi.</typeparam>
        /// <param name="xml">Deserileştirilecek XML string.</param>
        /// <returns>Deserileştirilmiş nesne veya null.</returns>
        public static T? DeserializeFromXml<T>(string? xml) where T : class
        {
            if (string.IsNullOrEmpty(xml))
            {
                throw new ArgumentNullException(nameof(xml), "XML string cannot be null or empty");
            }

            XmlSerializer xmlSerializer = new(typeof(T));

            using StringReader stringReader = new(xml);
            return xmlSerializer.Deserialize(stringReader) as T;
        }

        /// <summary>
        /// Verilen nesneyi belirtilen root element ismi ile XML string'e çevirir.
        /// </summary>
        /// <typeparam name="T">Serileştirilecek nesnenin tipi.</typeparam>
        /// <param name="dto">Serileştirilecek nesne.</param>
        /// <param name="rootName">XML root element ismi.</param>
        /// <returns>Belirtilen root element ismi ile XML string formatında serileştirilmiş nesne.</returns>
        public static string SerializeWithCustomRoot<T>(T dto, string rootName)
        {
            var xmlRoot = new XmlRootAttribute(rootName);
            var serializer = new XmlSerializer(typeof(T), xmlRoot);

            using var stringWriter = new StringWriter();
            serializer.Serialize(stringWriter, dto);
            return stringWriter.ToString();
        }
    }
}
