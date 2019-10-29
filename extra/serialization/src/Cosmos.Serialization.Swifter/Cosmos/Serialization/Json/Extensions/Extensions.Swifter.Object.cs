using System.IO;
using System.Threading.Tasks;
using Cosmos.Serialization.Json.Swifter;
using Swifter.Json;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Json
{
    /// <summary>
    /// SwiftJson extensions
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// To SwifterJson
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string ToSwifterJson<T>(this T obj, JsonFormatterOptions? options = null)
        {
            return SwifterHelper.Serialize(obj, options);
        }

        /// <summary>
        /// To SwifterJson
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="textWriter"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        public static void ToSwifterJson<T>(this T obj, TextWriter textWriter, JsonFormatterOptions? options = null)
        {
            SwifterHelper.Serialize(obj, textWriter, options);
        }

        /// <summary>
        /// To SwifterJson
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<string> ToSwifterJsonAsync<T>(this T obj, JsonFormatterOptions? options = null)
        {
            return SwifterHelper.SerializeAsync(obj, options);
        }

        /// <summary>
        /// To SwifterJson
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="textWriter"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        public static Task ToSwifterJsonAsync<T>(this T obj, TextWriter textWriter, JsonFormatterOptions? options = null)
        {
            return SwifterHelper.SerializeAsync(obj, textWriter, options);
        }
    }
}