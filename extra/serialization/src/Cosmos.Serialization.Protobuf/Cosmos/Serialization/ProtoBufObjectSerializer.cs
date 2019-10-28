using System;
using System.Threading.Tasks;
using Cosmos.Serialization.ProtoBuf;

namespace Cosmos.Serialization
{
    /// <summary>
    /// Google Protobuf object serializer
    /// </summary>
    public class ProtoBufObjectSerializer : IObjectSerializer<byte[]>
    {
        /// <inheritdoc />
        public byte[] Serialize<T>(T o) => ProtobufHelper.Serialize(o);

        /// <inheritdoc />
        public T Deserialize<T>(byte[] data) => ProtobufHelper.Deserialize<T>(data);

        /// <inheritdoc />
        public object Deserialize(byte[] data, Type type) => ProtobufHelper.Deserialize(data, type);

        /// <inheritdoc />
        public Task<byte[]> SerializeAsync<T>(T o) => ProtobufHelper.SerializeAsync(o);

        /// <inheritdoc />
        public Task<T> DeserializeAsync<T>(byte[] data) => ProtobufHelper.DeserializeAsync<T>(data);

        /// <inheritdoc />
        public Task<object> DeserializeAsync(byte[] data, Type type) => ProtobufHelper.DeserializeAsync(data, type);
    }
}