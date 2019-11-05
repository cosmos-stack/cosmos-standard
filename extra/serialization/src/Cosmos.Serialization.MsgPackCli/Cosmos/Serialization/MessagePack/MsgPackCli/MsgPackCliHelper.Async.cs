using System;
using System.IO;
using System.Threading.Tasks;

namespace Cosmos.Serialization.MessagePack.MsgPackCli
{
    /// <summary>
    /// MessagePack-Cli helper
    /// </summary>
    public static partial class MsgPackCliHelper
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

            using var stream = await PackAsync(t);
            return await StreamToBytesAsync(stream);
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

            using var stream = await PackAsync(obj, type);
            return await StreamToBytesAsync(stream);
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

            using var ms = new MemoryStream(data);
            return await UnpackAsync<T>(ms);
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

            using var ms = new MemoryStream(data);
            return await UnpackAsync(ms, type);
        }
    }
}