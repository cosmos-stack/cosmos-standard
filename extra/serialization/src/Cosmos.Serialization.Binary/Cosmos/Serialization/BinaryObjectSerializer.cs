using System;

namespace Cosmos.Serialization
{
    /// <summary>
    /// Binary object serializer
    /// </summary>
    public class BinaryObjectSerializer: IObjectSerializer<byte[]>
    {
        public byte[] Serialize<T>(T o)
        {
            throw new NotImplementedException();
        }

        public T Deserialize<T>(byte[] json)
        {
            throw new NotImplementedException();
        }

        public object Deserialize(byte[] json, Type type)
        {
            throw new NotImplementedException();
        }
    }
}