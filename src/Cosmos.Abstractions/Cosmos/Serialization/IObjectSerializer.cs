using System;
using System.Threading.Tasks;

namespace Cosmos.Serialization
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
        /// <param name="data"></param>
        /// <returns></returns>
        T Deserialize<T>(TSerializedType data);

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        object Deserialize(TSerializedType data, Type type);
        
        /// <summary>
        /// Serialize
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="o"></param>
        /// <returns></returns>
        Task<TSerializedType> SerializeAsync<T>(T o);

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        Task<T> DeserializeAsync<T>(TSerializedType data);

        /// <summary>
        /// Deserialize
        /// </summary>
        /// <param name="data"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        Task<object> DeserializeAsync(TSerializedType data, Type type);
    }

    /// <summary>
    /// Object Serializer Meta Interface
    /// </summary>
    public interface IObjectSerializer : IObjectSerializer<string> { }
}