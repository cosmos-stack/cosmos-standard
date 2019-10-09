using System;

namespace Cosmos
{
    /// <summary>
    /// Object Serializer Meta Interface
    /// </summary>
    /// <typeparam name="TSerializedType"></typeparam>
    public interface IObjectSerializer<TSerializedType>
    {
        /// <summary>
        /// Serialize
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        /// <returns></returns>
        TSerializedType Serialize<T>(T o);

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        T Deserialize<T>(TSerializedType json);

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="json"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object Deserialize(TSerializedType json, Type type);
    }

    /// <summary>
    /// Object Serializer Meta Interface
    /// </summary>
    public interface IObjectSerializer : IObjectSerializer<string> { }
}