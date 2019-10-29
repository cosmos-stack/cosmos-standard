using System;
using System.Threading.Tasks;
using Cosmos.Serialization.MessagePack.Neuecc;

namespace Cosmos.Serialization
{
    /// <summary>
    /// Neuecc's MessagePack Serializer
    /// </summary>
    public class NeueccMessagePackObjectSerializer : IMessagePackSerializer
    {
        /// <inheritdoc />
        public byte[] Serialize<T>(T o) => NeueccMsgPackHelper.Serialize(o);

        /// <inheritdoc />
        public T Deserialize<T>(byte[] data) => NeueccMsgPackHelper.Deserialize<T>(data);

        /// <inheritdoc />
        public object Deserialize(byte[] data, Type type) => NeueccMsgPackHelper.Deserialize(data, type);

        /// <inheritdoc />
        public Task<byte[]> SerializeAsync<T>(T o) => NeueccMsgPackHelper.SerializeAsync(o);

        /// <inheritdoc />
        public Task<T> DeserializeAsync<T>(byte[] data) => NeueccMsgPackHelper.DeserializeAsync<T>(data);

        /// <inheritdoc />
        public Task<object> DeserializeAsync(byte[] data, Type type) => NeueccMsgPackHelper.DeserializeAsync(data, type);
    }
}