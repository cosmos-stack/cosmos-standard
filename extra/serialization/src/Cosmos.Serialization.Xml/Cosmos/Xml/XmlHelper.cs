using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Cosmos.Xml
{
    /// <summary>
    /// Xml Helper
    /// </summary>
    public static class XmlHelper
    {
        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="t"></param>
        /// <param name="encoding"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string Serialize<T>(T t, Encoding encoding = null)
        {
            if (t == null) return
                string.Empty;

            encoding = encoding ?? Encoding.UTF8;

            using (var memoryStream = new MemoryStream())
            {
                using (var wtr = new XmlTextWriter(memoryStream, encoding))
                {
                    var serializer = new XmlSerializer(typeof(T));
                    serializer.Serialize(wtr, t);
                    memoryStream.Position = 0;
                    using (var reader = new StreamReader(memoryStream, encoding))
                        return reader.ReadToEnd();
                }
            }
        }

        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="encoding"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Deserialize<T>(string xml, Encoding encoding = null)
        {
            if (string.IsNullOrWhiteSpace(xml))
                return default(T);

            encoding = encoding ?? Encoding.UTF8;

            using (var memoryStream = new MemoryStream(encoding.GetBytes(xml)))
            {
                var serializer = new XmlSerializer(typeof(T));
                return (T)serializer.Deserialize(memoryStream);
            }
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="xml"></param>
        /// <param name="type"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static object Deserialize(string xml, Type type, Encoding encoding = null)
        {
            if (string.IsNullOrWhiteSpace(xml))
                return null;

            encoding = encoding ?? Encoding.UTF8;

            using (var memoryStream = new MemoryStream(encoding.GetBytes(xml)))
            {
                var serializer = new XmlSerializer(type);
                return serializer.Deserialize(memoryStream);
            }
        }
    }
}
