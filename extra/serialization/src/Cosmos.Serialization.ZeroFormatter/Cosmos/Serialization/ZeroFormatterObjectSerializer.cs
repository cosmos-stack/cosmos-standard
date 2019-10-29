using System;
using System.Threading.Tasks;
using Cosmos.Serialization.ZeroFormatter;

namespace Cosmos.Serialization
{
    /// <summary>
    /// ZeroFormatter serializer
    /// </summary>
    public class ZeroFormatterObjectSerializer : IZeroFormatterSerializer
    {
        /// <inheritdoc />
        public byte[] Serialize<T>(T o) => ZeroFormatterHelper.Serialize(o);

        /// <inheritdoc />
        public T Deserialize<T>(byte[] data) => ZeroFormatterHelper.Deserialize<T>(data);

        /// <inheritdoc />
        public object Deserialize(byte[] data, Type type) => ZeroFormatterHelper.Deserialize(data, type);

        /// <inheritdoc />
        public Task<byte[]> SerializeAsync<T>(T o) => ZeroFormatterHelper.SerializeAsync(o);

        /// <inheritdoc />
        public Task<T> DeserializeAsync<T>(byte[] data) => ZeroFormatterHelper.DeserializeAsync<T>(data);

        /// <inheritdoc />
        public Task<object> DeserializeAsync(byte[] data, Type type) => ZeroFormatterHelper.DeserializeAsync(data, type);
    }
}