using System.Threading.Tasks;
using Cosmos.Serialization.Json.Lit;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Json
{
    /// <summary>
    /// LitJson extensions
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// To LitJson
        /// </summary>
        /// <param name="o"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static string ToLitJson<T>(this T o) => LitHelper.Serialize(o);

        /// <summary>
        /// To LitJson async
        /// </summary>
        /// <param name="o"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<string> ToLitJsonAsync<T>(this T o) => LitHelper.SerializeAsync(o);
    }
}