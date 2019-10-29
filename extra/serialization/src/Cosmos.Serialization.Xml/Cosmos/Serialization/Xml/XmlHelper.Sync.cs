using System;
using System.IO;
using System.Text;

namespace Cosmos.Serialization.Xml
{
    /// <summary>
    /// Xml Helper
    /// </summary>
    public static partial class XmlHelper
    {
        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="o"></param>
        /// <param name="encoding"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string Serialize<T>(T o, Encoding encoding = null)
        {
            return Serialize(o, typeof(T), encoding);
        }

        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="o"></param>
        /// <param name="type"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string Serialize(object o, Type type, Encoding encoding = null)
        {
            if (o is null)
                return string.Empty;

            encoding = encoding ?? XmlManager.DefaultEncoding;

            using (var stream = Pack(o, type))
            {
                return encoding.GetString(StreamToBytes(stream));
            }
        }

        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="o"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static byte[] SerializeToBytes<T>(T o)
        {
            return SerializeToBytes(o, typeof(T));
        }

        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="o"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static byte[] SerializeToBytes(object o, Type type)
        {
            if (o is null)
                return new byte[0];

            using (var stream = Pack(o, type))
            {
                return StreamToBytes(stream);
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
            return string.IsNullOrWhiteSpace(xml)
                ? default
                : (T) Deserialize(xml, typeof(T), encoding);
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

            encoding = encoding ?? XmlManager.DefaultEncoding;

            using (var memoryStream = new MemoryStream(encoding.GetBytes(xml)))
            {
                return Unpack(memoryStream, type);
            }
        }

        /// <summary>
        /// Deserialize from bytes
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T DeserializeFromBytes<T>(byte[] data)
        {
            return data is null || data.Length is 0
                ? default
                : (T) DeserializeFromBytes(data, typeof(T));
        }

        /// <summary>
        /// Deserialize from bytes
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object DeserializeFromBytes(byte[] data, Type type)
        {
            if (data is null || data.Length == 0)
                return null;

            using (var memoryStream = new MemoryStream(data))
            {
                return Unpack(memoryStream, type);
            }
        }
    }
}