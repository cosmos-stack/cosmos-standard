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
        /// Serialize object to xml
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ToXml<T>(this T obj, Encoding encoding = null)
        {
            return XmlHelper.Serialize(obj, encoding);
        }

        /// <summary>
        /// Serialize object to xml async
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="encoding"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<string> ToXmlAsync<T>(this T obj, Encoding encoding = null)
        {
            return XmlHelper.SerializeAsync(obj, encoding);
        }
    }
}