using System;
using System.Threading.Tasks;
using Kooboo.Json;
using Cosmos.Serialization.Json.Kooboo;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Json
{
    using K = KoobooJsonHelper;

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
        public static byte[] ToKoobooBytes<T>(this T obj, JsonSerializerOption options = null) => K.SerializeToBytes(obj, options);

        /// <summary>
        /// To Kooboo bytes
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="optionsAct"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static byte[] ToKoobooBytes<T>(this T obj, Action<JsonSerializerOption> optionsAct) => K.SerializeToBytes(obj, optionsAct);

        /// <summary>
        /// To Kooboo bytes async
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<byte[]> ToKoobooBytesAsync<T>(this T obj, JsonSerializerOption options = null) => K.SerializeToBytesAsync(obj, options);

        /// <summary>
        /// To Kooboo bytes async
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="optionsAct"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<byte[]> ToKoobooBytesAsync<T>(this T obj, Action<JsonSerializerOption> optionsAct) => K.SerializeToBytesAsync(obj, optionsAct);

        /// <summary>
        /// From Kooboo bytes 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromKoobooBytes<T>(this byte[] data, JsonDeserializeOption options = null) => K.DeserializeFromBytes<T>(data, options);

        /// <summary>
        /// From Kooboo bytes 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="optionsAct"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromKoobooBytes<T>(this byte[] data, Action<JsonDeserializeOption> optionsAct) => K.DeserializeFromBytes<T>(data, optionsAct);

        /// <summary>
        /// From Kooboo bytes 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static object FromKoobooBytes(this byte[] data, Type type, JsonDeserializeOption options = null) => K.DeserializeFromBytes(data, type, options);

        /// <summary>
        /// From Kooboo bytes 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <param name="optionsAct"></param>
        /// <returns></returns>
        public static object FromKoobooBytes(this byte[] data, Type type, Action<JsonDeserializeOption> optionsAct) => K.DeserializeFromBytes(data, type, optionsAct);

        /// <summary>
        /// From Kooboo bytes async
        /// </summary>
        /// <param name="data"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> FromKoobooBytesAsync<T>(this byte[] data, JsonDeserializeOption options = null) => K.DeserializeFromBytesAsync<T>(data, options);

        /// <summary>
        /// From Kooboo bytes async
        /// </summary>
        /// <param name="data"></param>
        /// <param name="optionsAct"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> FromKoobooBytesAsync<T>(this byte[] data, Action<JsonDeserializeOption> optionsAct) => K.DeserializeFromBytesAsync<T>(data, optionsAct);

        /// <summary>
        /// From Kooboo bytes async
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static Task<object> FromKoobooBytesAsync(this byte[] data, Type type, JsonDeserializeOption options = null) => K.DeserializeFromBytesAsync(data, type, options);

        /// <summary>
        /// From Kooboo bytes async
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <param name="optionsAct"></param>
        /// <returns></returns>
        public static Task<object> FromKoobooBytesAsync(this byte[] data, Type type, Action<JsonDeserializeOption> optionsAct) => K.DeserializeFromBytesAsync(data, type, optionsAct);
    }
}