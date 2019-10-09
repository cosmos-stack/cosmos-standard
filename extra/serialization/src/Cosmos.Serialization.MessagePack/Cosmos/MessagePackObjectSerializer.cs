using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.MessagePack;

namespace Cosmos
{
    /// <summary>
    /// MessagePack Serializer
    /// </summary>
    public class MessagePackObjectSerializer : IObjectSerializer<byte[]>
    {
        /// <inheritdoc />
        public byte[] Serialize<T>(T o) => MessagePackHelper.Serialize(o);

        /// <inheritdoc />
        public T Deserialize<T>(byte[] json) => MessagePackHelper.Deserialize<T>(json);

        /// <inheritdoc />
        public object Deserialize(byte[] json, Type type) => MessagePackHelper.Deserialize(json, type);
    }
}