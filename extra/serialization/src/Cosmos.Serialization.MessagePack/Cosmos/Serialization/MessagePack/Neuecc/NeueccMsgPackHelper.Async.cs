using System;
using System.IO;
using System.Threading.Tasks;
using MessagePack;

namespace Cosmos.Serialization.MessagePack.Neuecc
{
    /// <summary>
    /// Neuecc's MessagePack helper
    /// </summary>
    public static partial class NeueccMsgPackHelper
    {
        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="t"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<byte[]> SerializeAsync<T>(T t)
        {
            if (t == null)
                return new byte[0];

            using (var ms = new MemoryStream())
            {
                await MessagePackSerializer.SerializeAsync(ms, t);
                return await StreamToBytesAsync(ms);
            }
        }

        /// <summary>
        /// Serialize
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static async Task<byte[]> SerializeAsync(object obj, Type type)
        {
            if (obj is null)
                return new byte[0];

            return await Task.Run(() => MessagePackSerializer.NonGeneric.Serialize(type, obj));
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="data"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static async Task<T> DeserializeAsync<T>(byte[] data)
        {
            if (data is null || data.Length == 0)
                return default;

            using (var ms = new MemoryStream(data))
            {
                return await MessagePackSerializer.DeserializeAsync<T>(ms);
            }
        }

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static async Task<object> DeserializeAsync(byte[] data, Type type)
        {
            if (data is null || data.Length == 0)
                return null;

            return await Task.Run(() => MessagePackSerializer.NonGeneric.Deserialize(type, data));
        }
    }
}