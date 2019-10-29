using System;
using System.Text.Json;
using System.Threading.Tasks;
using Cosmos.Serialization.Json.MicrosoftJson;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Json
{
    /// <summary>
    /// Microsoft System.Text.Json extensions
    /// </summary>
    public static partial class MsJsonExtensions
    {
        /// <summary>
        /// To Microsoft System.Text.Json bytes
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static byte[] ToMicrosoftJsonBytes<T>(this T obj, JsonSerializerOptions options = null)
        {
            return MicrosoftJsonHelper.SerializeToBytes(obj, options);
        }

        /// <summary>
        /// To Microsoft System.Text.Json bytes async
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<byte[]> ToMicrosoftJsonBytesAsync<T>(this T obj, JsonSerializerOptions options = null)
        {
            return MicrosoftJsonHelper.SerializeToBytesAsync(obj, options);
        }

        /// <summary>
        /// From Microsoft System.Text.Json bytes 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromMicrosoftJsonBytes<T>(this byte[] data, JsonSerializerOptions options = null)
        {
            return MicrosoftJsonHelper.DeserializeFromBytes<T>(data, options);
        }

        /// <summary>
        /// From Microsoft System.Text.Json bytes 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static object FromMicrosoftJsonBytes(this byte[] data, Type type, JsonSerializerOptions options = null)
        {
            return MicrosoftJsonHelper.DeserializeFromBytes(data, type, options);
        }

        /// <summary>
        /// From Microsoft System.Text.Json bytes async
        /// </summary>
        /// <param name="data"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> FromMicrosoftJsonBytesAsync<T>(this byte[] data, JsonSerializerOptions options = null)
        {
            return MicrosoftJsonHelper.DeserializeFromBytesAsync<T>(data, options);
        }

        /// <summary>
        /// From Microsoft System.Text.Json bytes async
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static Task<object> FromMicrosoftJsonBytesAsync(this byte[] data, Type type, JsonSerializerOptions options = null)
        {
            return MicrosoftJsonHelper.DeserializeFromBytesAsync(data, type, options);
        }
    }
}