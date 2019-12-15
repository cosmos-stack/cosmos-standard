using System.IO;
using System.Threading.Tasks;
using Cosmos.Serialization.Json.Swifter;
using Swifter.Json;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Json {
    using S = SwifterHelper;

    /// <summary>
    /// SwiftJson extensions
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// To SwifterJson
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string ToSwifterJson<T>(this T obj, JsonFormatterOptions? options = null) => S.Serialize(obj, options);

        /// <summary>
        /// To SwifterJson
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="textWriter"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        public static void ToSwifterJson<T>(this T obj, TextWriter textWriter, JsonFormatterOptions? options = null) => S.Serialize(obj, textWriter, options);

        /// <summary>
        /// To SwifterJson
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<string> ToSwifterJsonAsync<T>(this T obj, JsonFormatterOptions? options = null) => S.SerializeAsync(obj, options);

        /// <summary>
        /// To SwifterJson
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="textWriter"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        public static Task ToSwifterJsonAsync<T>(this T obj, TextWriter textWriter, JsonFormatterOptions? options = null) => S.SerializeAsync(obj, textWriter, options);
    }
}