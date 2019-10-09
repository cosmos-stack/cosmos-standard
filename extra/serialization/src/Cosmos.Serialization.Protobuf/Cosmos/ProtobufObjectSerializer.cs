using System;
using Cosmos.Protobuf;

namespace Cosmos
{
    /// <summary>
    /// ProtoBuf serializer
    /// </summary>
    public class ProtoBufObjectSerializer : IObjectSerializer<byte[]>
    {
        /// <inheritdoc />
        public byte[] Serialize<T>(T o) => ProtoBufHelper.Serialize(o);

        /// <inheritdoc />
        public T Deserialize<T>(byte[] json) => ProtoBufHelper.Deserialize<T>(json);

        /// <inheritdoc />
        public object Deserialize(byte[] json, Type type) => ProtoBufHelper.Deserialize(json, type);
    }
}