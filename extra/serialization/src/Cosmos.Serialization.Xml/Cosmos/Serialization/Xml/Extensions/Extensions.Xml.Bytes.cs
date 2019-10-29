using System;
using System.Threading.Tasks;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Xml
{
    /// <summary>
    /// Xml extensions
    /// </summary>
    public static partial class XmlExtensions
    {
        /// <summary>
        /// To xml bytes
        /// </summary>
        /// <param name="o"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static byte[] ToXmlBytes<T>(this T o)
        {
            return Serialization.Xml.XmlHelper.SerializeToBytes(o);
        }

        /// <summary>
        /// To xml bytes
        /// </summary>
        /// <param name="o"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static byte[] ToXmlBytes(this object o, Type type)
        {
            return Serialization.Xml.XmlHelper.SerializeToBytes(o, type);
        }

        /// <summary>
        /// To xml bytes async
        /// </summary>
        /// <param name="o"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<byte[]> ToXmlBytesAsync<T>(this T o)
        {
            return XmlHelper.SerializeToBytesAsync(o);
        }

        /// <summary>
        /// To xml bytes async
        /// </summary>
        /// <param name="o"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Task<byte[]> ToXmlBytesAsync(this object o, Type type)
        {
            return XmlHelper.SerializeToBytesAsync(o, type);
        }

        /// <summary>
        /// From xml bytes
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromXmlBytes<T>(this byte[] data)
        {
            return XmlHelper.DeserializeFromBytes<T>(data);
        }

        /// <summary>
        /// From xml bytes
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static object FromXmlBytes(this byte[] data, Type type)
        {
            return XmlHelper.DeserializeFromBytes(data, type);
        }

        /// <summary>
        /// From xml bytes async
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> FromXmlBytesAsync<T>(this byte[] data)
        {
            return XmlHelper.DeserializeFromBytesAsync<T>(data);
        }

        /// <summary>
        /// From xml bytes async
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Task<object> FromXmlBytesAsync(this byte[] data, Type type)
        {
            return XmlHelper.DeserializeFromBytesAsync(data, type);
        }
    }
}