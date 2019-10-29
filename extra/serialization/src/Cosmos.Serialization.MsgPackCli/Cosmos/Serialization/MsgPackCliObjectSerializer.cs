using System;
using System.Threading.Tasks;
using Cosmos.Serialization.MessagePack.MsgPackCli;

namespace Cosmos.Serialization
{
    /// <summary>
    /// MsgPack-cli object serializer
    /// </summary>
    public class MsgPackCliObjectSerializer : IObjectSerializer<byte[]>
    {

        /// <inheritdoc />
        public byte[] Serialize<T>(T o) => MsgPackCliHelper.Serialize(o);

        /// <inheritdoc />
        public T Deserialize<T>(byte[] data) => MsgPackCliHelper.Deserialize<T>(data);

        /// <inheritdoc />
        public object Deserialize(byte[] data, Type type) => MsgPackCliHelper.Deserialize(data, type);
        
        /// <inheritdoc />
        public Task<byte[]> SerializeAsync<T>(T o) => MsgPackCliHelper.SerializeAsync(o);

        /// <inheritdoc />
        public Task<T> DeserializeAsync<T>(byte[] data) => MsgPackCliHelper.DeserializeAsync<T>(data);

        /// <inheritdoc />
        public Task<object> DeserializeAsync(byte[] data, Type type) => MsgPackCliHelper.DeserializeAsync(data, type);
    }
}