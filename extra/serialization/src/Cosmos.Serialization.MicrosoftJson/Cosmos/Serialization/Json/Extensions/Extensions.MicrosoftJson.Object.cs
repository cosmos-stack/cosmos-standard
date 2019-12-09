using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Cosmos.Serialization.Json.MicrosoftJson;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Json {
    using MS = MicrosoftJsonHelper;

    /// <summary>
    /// Microsoft System.Text.Json extensions
    /// </summary>
    public static partial class MsJsonExtensions {
        /// <summary>
        /// To Microsoft System.Text.Json
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string ToMicrosoftJson<T>(this T obj, JsonSerializerOptions options = null) => MS.Serialize(obj, options);


        /// <summary>
        /// To Microsoft System.Text.Json
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<string> ToMicrosoftJsonAsync<T>(this T obj, JsonSerializerOptions options = null) => MS.SerializeAsync(obj, options);

    }
}