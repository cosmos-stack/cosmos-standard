using System;

namespace Cosmos
{
    public interface IObjectSerializer<TSerializedType>
    {
        TSerializedType Serialize<T>(T o);
        T Deserialize<T>(TSerializedType json);
        object Deserialize(TSerializedType json, Type type);
    }

    public interface IObjectSerializer : IObjectSerializer<string> { }
}
