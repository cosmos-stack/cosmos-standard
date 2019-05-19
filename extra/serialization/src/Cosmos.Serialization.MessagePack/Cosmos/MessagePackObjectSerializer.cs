using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.MessagePack;

namespace Cosmos
{
    public class MessagePackObjectSerializer : IObjectSerializer<byte[]>
    {
        public byte[] Serialize<T>(T o) => MessagePackHelper.Serialize(o);

        public T Deserialize<T>(byte[] json) => MessagePackHelper.Deserialize<T>(json);

        public object Deserialize(byte[] json, Type type) => MessagePackHelper.Deserialize(json, type);
    }
}
