using System;
using System.Threading.Tasks;

namespace CosmosStack.Serialization
{
    /// <summary>
    /// Object Serializer Meta Interface<br />
    /// 对象序列化器元接口
    /// </summary>
    /// <typeparam name="TSerializedType">指定的目标序列化类型</typeparam>
    public interface IObjectSerializer<TSerializedType> : ISerializer
    {
        /// <summary>
        /// Serialize<br />
        /// 序列化
        /// </summary>
        /// <typeparam name="T">指定的序列化对象类型</typeparam>
        /// <param name="o">被序列化对象</param>
        /// <returns>序列化结果</returns>
        TSerializedType Serialize<T>(T o);

        /// <summary>
        /// Deserialize<br />
        /// 反序列化
        /// </summary>
        /// <typeparam name="T">指定的被序列化对象类型</typeparam>
        /// <param name="data">被反序列化对象</param>
        /// <returns>反序列化结果</returns>
        T Deserialize<T>(TSerializedType data);

        /// <summary>
        /// Deserialize<br />
        /// 反序列化
        /// </summary>
        /// <param name="data">被反序列化对象</param>
        /// <param name="type">指定的被序列化对象类型</param>
        /// <returns>反序列化结果</returns>
        object Deserialize(TSerializedType data, Type type);

        /// <summary>
        /// Serialize async<br />
        /// 异步序列化
        /// </summary>
        /// <typeparam name="T">指定的序列化对象类型</typeparam>
        /// <param name="o">被序列化对象</param>
        /// <returns>序列化结果</returns>
        Task<TSerializedType> SerializeAsync<T>(T o);

        /// <summary>
        /// Deserialize async<br />
        /// 异步反序列化
        /// </summary>
        /// <typeparam name="T">指定的被序列化对象类型</typeparam>
        /// <param name="data">被反序列化对象</param>
        /// <returns>反序列化结果</returns>
        Task<T> DeserializeAsync<T>(TSerializedType data);

        /// <summary>
        /// Deserialize async<br />
        /// 异步反序列化
        /// </summary>
        /// <param name="data">被反序列化对象</param>
        /// <param name="type">指定的被序列化对象类型</param>
        /// <returns>反序列化结果</returns>
        Task<object> DeserializeAsync(TSerializedType data, Type type);
    }
}