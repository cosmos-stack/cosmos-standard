using System.Text;
using Cosmos.Xml;

namespace Cosmos.Extensions
{
    /// <summary>
    /// Xml extensions
    /// </summary>
    public static partial class XmlExtensions
    {
        /// <summary>
        /// Serialize object to xml
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ToXml<T>(this T obj, Encoding encoding = null) where T : class
        {
            return XmlHelper.Serialize(obj, encoding);
        }
    }
}
