using System.Threading.Tasks;
using Newtonsoft.Json;
using Cosmos.Serialization.Json.Newtonsoft;

/*
 * Reference to:
 *      Mutuduxf/Zaabee.Serializers
 *          Author: Mutuduxf
 *          Url:    https://github.com/Mutuduxf/Zaabee.Serializers
 *          MIT
 */

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Json {
    /// <summary>
    /// Newtonsoft Json Extensions
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// To Json
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="settings"></param>
        /// <param name="withNodaTime"></param>
        /// <returns></returns>
        public static string ToJson(this object obj, JsonSerializerSettings settings = null, bool withNodaTime = false) {
            return JsonHelper.Serialize(obj, settings, withNodaTime);
        }

        /// <summary>
        /// To json async
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="settings"></param>
        /// <param name="withNodaTime"></param>
        /// <returns></returns>
        public static Task<string> ToJsonAsync(this object obj, JsonSerializerSettings settings = null, bool withNodaTime = false) {
            return JsonHelper.SerializeAsync(obj, settings, withNodaTime);
        }
    }
}