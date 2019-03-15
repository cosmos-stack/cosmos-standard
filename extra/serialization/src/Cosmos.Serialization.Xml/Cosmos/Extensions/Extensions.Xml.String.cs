using System;
using System.Text;
using Cosmos.Xml;

namespace Cosmos.Extensions
{
    public static partial class XmlExtensions
    {
        /// <summary>
        /// Deserialize the xml to generic instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="str"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static T FromXml<T>(this string str, Encoding encoding = null) where T : class
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
    }
}
