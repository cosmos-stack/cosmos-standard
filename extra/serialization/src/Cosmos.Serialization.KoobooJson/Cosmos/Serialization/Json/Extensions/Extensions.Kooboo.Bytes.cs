using System;
using System.Threading.Tasks;
using Kooboo.Json;
using Cosmos.Serialization.Json.Kooboo;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Json
{
    /// <summary>
    /// KoobooJson extensions
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// To Kooboo bytes
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static byte[] ToKoobooBytes<T>(this T obj, JsonSerializerOption options = null)
        {
            return KoobooJsonHelper.SerializeToBytes(obj, options);
        }

        /// <summary>
        /// To Kooboo bytes
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="optionsAct"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static byte[] ToKoobooBytes<T>(this T obj, Action<JsonSerializerOption> optionsAct)
        {
            return KoobooJsonHelper.SerializeToBytes(obj, optionsAct);
        }

        /// <summary>
        /// To Kooboo bytes async
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<byte[]> ToKoobooBytesAsync<T>(this T obj, JsonSerializerOption options = null)
        {
            return KoobooJsonHelper.SerializeToBytesAsync(obj, options);
        }

        /// <summary>
        /// To Kooboo bytes async
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="optionsAct"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<byte[]> ToKoobooBytesAsync<T>(this T obj, Action<JsonSerializerOption> optionsAct)
        {
            return KoobooJsonHelper.SerializeToBytesAsync(obj, optionsAct);
        }

        /// <summary>
        /// From Kooboo bytes 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromKoobooBytes<T>(this byte[] data, JsonDeserializeOption options = null)
        {
            return KoobooJsonHelper.DeserializeFromBytes<T>(data, options);
        }

        /// <summary>
        /// From Kooboo bytes 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="optionsAct"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromKoobooBytes<T>(this byte[] data, Action<JsonDeserializeOption> optionsAct)
        {
            return KoobooJsonHelper.DeserializeFromBytes<T>(data, optionsAct);
        }

        /// <summary>
        /// From Kooboo bytes 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static object FromKoobooBytes(this byte[] data, Type type, JsonDeserializeOption options = null)
        {
            return KoobooJsonHelper.DeserializeFromBytes(data, type, options);
        }

        /// <summary>
        /// From Kooboo bytes 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <param name="optionsAct"></param>
        /// <returns></returns>
        public static object FromKoobooBytes(this byte[] data, Type type, Action<JsonDeserializeOption> optionsAct)
        {
            return KoobooJsonHelper.DeserializeFromBytes(data, type, optionsAct);
        }

        /// <summary>
        /// From Kooboo bytes async
        /// </summary>
        /// <param name="data"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> FromKoobooBytesAsync<T>(this byte[] data, JsonDeserializeOption options = null)
        {
            return KoobooJsonHelper.DeserializeFromBytesAsync<T>(data, options);
        }

        /// <summary>
        /// From Kooboo bytes async
        /// </summary>
        /// <param name="data"></param>
        /// <param name="optionsAct"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> FromKoobooBytesAsync<T>(this byte[] data, Action<JsonDeserializeOption> optionsAct)
        {
            return KoobooJsonHelper.DeserializeFromBytesAsync<T>(data, optionsAct);
        }

        /// <summary>
        /// From Kooboo bytes async
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static Task<object> FromKoobooBytesAsync(this byte[] data, Type type, JsonDeserializeOption options = null)
        {
            return KoobooJsonHelper.DeserializeFromBytesAsync(data, type, options);
        }

        /// <summary>
        /// From Kooboo bytes async
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <param name="optionsAct"></param>
        /// <returns></returns>
        public static Task<object> FromKoobooBytesAsync(this byte[] data, Type type, Action<JsonDeserializeOption> optionsAct)
        {
            return KoobooJsonHelper.DeserializeFromBytesAsync(data, type, optionsAct);
        }
    }
}