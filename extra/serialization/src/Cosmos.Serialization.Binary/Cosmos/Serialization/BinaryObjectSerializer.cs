using System;
using System.Threading.Tasks;
using Cosmos.Serialization.Binary;

namespace Cosmos.Serialization
{
    /// <summary>
    /// Binary object serializer
    /// </summary>
    public class BinaryObjectSerializer : IObjectSerializer<byte[]>
    {
        /// <inheritdoc />
        public byte[] Serialize<T>(T o) => BinaryHelper.Serialize(o);

        /// <inheritdoc />
        public T Deserialize<T>(byte[] data) => BinaryHelper.Deserialize<T>(data);

        /// <inheritdoc />
        public object Deserialize(byte[] data, Type type) => BinaryHelper.Deserialize(data);

        /// <inheritdoc />
        public Task<byte[]> SerializeAsync<T>(T o) => BinaryHelper.SerializeAsync(o);

        /// <inheritdoc />
        public Task<T> DeserializeAsync<T>(byte[] data) => BinaryHelper.DeserializeAsync<T>(data);

        /// <inheritdoc />
        public Task<object> DeserializeAsync(byte[] data, Type type) => BinaryHelper.DeserializeAsync(data);
    }
}