using System;
using System.Text;
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
        /// Deserialize the xml to generic instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static T FromXml<T>(this string str, Encoding encoding = null)
        {
            return XmlHelper.Deserialize<T>(str, encoding);
        }

        /// <summary>
        /// Deserialize the xml to object.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="type"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static object FromXml(this string str, Type type, Encoding encoding = null)
        {
            return XmlHelper.Deserialize(str, type, encoding);
        }

        /// <summary>
        /// Deserialize the xml to generic instance async.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static Task<T> FromXmlAsync<T>(this string str, Encoding encoding = null)
        {
            return XmlHelper.DeserializeAsync<T>(str, encoding);
        }

        /// <summary>
        /// Deserialize the xml to object async.
        /// </summary>
        /// <param name="str"></param>
        /// <param name="type"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static Task<object> FromXmlAsync(this string str, Type type, Encoding encoding = null)
        {
            return XmlHelper.DeserializeAsync(str, type, encoding);
        }
    }
}