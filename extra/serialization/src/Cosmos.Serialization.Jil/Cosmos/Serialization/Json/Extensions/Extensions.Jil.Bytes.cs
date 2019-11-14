using System;
using System.Threading.Tasks;
using Jil;
using Cosmos.Serialization.Json.Jil;

// ReSharper disable once CheckNamespace
namespace Cosmos.Serialization.Json
{
    /// <summary>
    /// JilJson extensions
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// To Jil bytes
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static byte[] ToJilBytes<T>(this T obj, Options options = null) => JilHelper.SerializeToBytes(obj, options);

        /// <summary>
        /// To Jil bytes
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="optionsAct"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static byte[] ToJilBytes<T>(this T obj, Action<Options> optionsAct) => JilHelper.SerializeToBytes(obj, optionsAct);

        /// <summary>
        /// To Jil bytes async
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<byte[]> ToJilBytesAsync<T>(this T obj, Options options = null) => JilHelper.SerializeToBytesAsync(obj, options);

        /// <summary>
        /// To Jil bytes async
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="optionsAct"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<byte[]> ToJilBytesAsync<T>(this T obj, Action<Options> optionsAct) => JilHelper.SerializeToBytesAsync(obj, optionsAct);

        /// <summary>
        /// From Jil bytes 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromJilBytes<T>(this byte[] data, Options options = null) => JilHelper.DeserializeFromBytes<T>(data, options);

        /// <summary>
        /// From Jil bytes 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="optionsAct"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T FromJilBytes<T>(this byte[] data, Action<Options> optionsAct) => JilHelper.DeserializeFromBytes<T>(data, optionsAct);

        /// <summary>
        /// From Jil bytes 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static object FromJilBytes(this byte[] data, Type type, Options options = null) => JilHelper.DeserializeFromBytes(data, type, options);

        /// <summary>
        /// From Jil bytes 
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <param name="optionsAct"></param>
        /// <returns></returns>
        public static object FromJilBytes(this byte[] data, Type type, Action<Options> optionsAct) => JilHelper.DeserializeFromBytes(data, type, optionsAct);

        /// <summary>
        /// From Jil bytes async
        /// </summary>
        /// <param name="data"></param>
        /// <param name="options"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> FromJilBytesAsync<T>(this byte[] data, Options options = null) => JilHelper.DeserializeFromBytesAsync<T>(data, options);

        /// <summary>
        /// From Jil bytes async
        /// </summary>
        /// <param name="data"></param>
        /// <param name="optionsAct"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Task<T> FromJilBytesAsync<T>(this byte[] data, Action<Options> optionsAct) => JilHelper.DeserializeFromBytesAsync<T>(data, optionsAct);

        /// <summary>
        /// From Jil bytes async
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static Task<object> FromJilBytesAsync(this byte[] data, Type type, Options options = null) => JilHelper.DeserializeFromBytesAsync(data, type, options);

        /// <summary>
        /// From Jil bytes async
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <param name="optionsAct"></param>
        /// <returns></returns>
        public static Task<object> FromJilBytesAsync(this byte[] data, Type type, Action<Options> optionsAct) => JilHelper.DeserializeFromBytesAsync(data, type, optionsAct);
    }
}