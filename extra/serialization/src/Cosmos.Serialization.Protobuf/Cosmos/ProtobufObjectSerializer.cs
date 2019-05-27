using System;
using Cosmos.Protobuf;

namespace Cosmos
{
    public class ProtobufObjectSerializer : IObjectSerializer<byte[]>
    {
        public byte[] Serialize<T>(T o) => ProtobufHelper.Serialize(o);

        public T Deserialize<T>(byte[] json) => ProtobufHelper.Deserialize<T>(json);

        public object Deserialize(byte[] json, Type type) => ProtobufHelper.Deserialize(json, type);
    }
}
