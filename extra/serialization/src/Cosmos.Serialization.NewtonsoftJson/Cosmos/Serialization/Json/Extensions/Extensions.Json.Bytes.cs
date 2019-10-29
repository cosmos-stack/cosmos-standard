using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using JsonHelper = Cosmos.Serialization.Json.Newtonsoft.JsonHelper;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Json
{
    /// <summary>
    /// Newtonsoft Json Extensions
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// To json bytes
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="settings"></param>
        /// <param name="withNodaTime"></param>
        /// <returns></returns>
        public static byte[] ToJsonBytes(this object obj, JsonSerializerSettings settings = null, bool withNodaTime = false)
        {
            return JsonHelper.SerializeToBytes(obj, settings, withNodaTime);
        }

        /// <summary>
        /// To json bytes async
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="settings"></param>
        /// <param name="withNodaTime"></param>
        /// <returns></returns>
        public static Task<byte[]> ToJsonBytesAsync(this object obj, JsonSerializerSettings settings = null, bool withNodaTime = false)
        {
            return JsonHelper.SerializeToBytesAsync(obj, settings, withNodaTime);
        }

        /// <summary>
        /// From json bytes
        /// </summary>
        /// <param name="data"></param>
        /// <param name="settings"></param>
        /// <param name="withNodaTime"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromJsonBytes<T>(this byte[] data, JsonSerializerSettings settings = null, bool withNodaTime = false)
        {
            return JsonHelper.DeserializeFromBytes<T>(data, settings, withNodaTime);
        }

        /// <summary>
        /// From json bytes
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <param name="settings"></param>
        /// <param name="withNodaTime"></param>
        /// <returns></returns>
        public static object FromJsonBytes(this byte[] data, Type type, JsonSerializerSettings settings = null, bool withNodaTime = false)
        {
            return JsonHelper.DeserializeFromBytes(data, type, settings, withNodaTime);
        }

        /// <summary>
        /// From json bytes async
        /// </summary>
        /// <param name="data"></param>
        /// <param name="settings"></param>
        /// <param name="withNodaTime"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> FromJsonBytesAsync<T>(this byte[] data, JsonSerializerSettings settings = null, bool withNodaTime = false)
        {
            return JsonHelper.DeserializeFromBytesAsync<T>(data, settings, withNodaTime);
        }

        /// <summary>
        /// From json bytes async
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <param name="settings"></param>
        /// <param name="withNodaTime"></param>
        /// <returns></returns>
        public static Task<object> FromJsonBytesAsync(this byte[] data, Type type, JsonSerializerSettings settings = null, bool withNodaTime = false)
        {
            return JsonHelper.DeserializeFromBytesAsync(data, type, settings, withNodaTime);
        }
    }
}