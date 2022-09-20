namespace Cosmos.Serialization;

/// <summary>
/// Object Serializer Meta Interface<br />
/// 对象序列化器元接口
/// </summary>
/// <typeparam name="TData">指定的目标序列化类型</typeparam>
public interface IObjectSerializer<TData> : ISerializer, ISerializerAsync
{
    #region Sync

    /// <summary>
    /// Serialize<br />
    /// 序列化
    /// </summary>
    /// <typeparam name="TValue">指定的序列化对象类型</typeparam>
    /// <param name="value">被序列化对象</param>
    /// <returns>序列化结果</returns>
    TData Serialize<TValue>(TValue value);

    /// <summary>
    /// Deserialize<br />
    /// 反序列化
    /// </summary>
    /// <typeparam name="TValue">指定的被序列化对象类型</typeparam>
    /// <param name="data">被反序列化对象</param>
    /// <returns>反序列化结果</returns>
    TValue Deserialize<TValue>(TData data);

    /// <summary>
    /// Deserialize<br />
    /// 反序列化
    /// </summary>
    /// <param name="data">被反序列化对象</param>
    /// <param name="type">指定的被序列化对象类型</param>
    /// <returns>反序列化结果</returns>
    object Deserialize(Type type, TData data);

    #endregion

    #region Async

    /// <summary>
    /// Serialize async<br />
    /// 异步序列化
    /// </summary>
    /// <typeparam name="TValue">指定的序列化对象类型</typeparam>
    /// <param name="value">被序列化对象</param>
    /// <returns>序列化结果</returns>
    Task<TData> SerializeAsync<TValue>(TValue value);

    /// <summary>
    /// Deserialize async<br />
    /// 异步反序列化
    /// </summary>
    /// <typeparam name="TValue">指定的被序列化对象类型</typeparam>
    /// <param name="data">被反序列化对象</param>
    /// <returns>反序列化结果</returns>
    Task<TValue> DeserializeAsync<TValue>(TData data);

    /// <summary>
    /// Deserialize async<br />
    /// 异步反序列化
    /// </summary>
    /// <param name="data">被反序列化对象</param>
    /// <param name="type">指定的被序列化对象类型</param>
    /// <returns>反序列化结果</returns>
    Task<object> DeserializeAsync(Type type, TData data);

    #endregion
}