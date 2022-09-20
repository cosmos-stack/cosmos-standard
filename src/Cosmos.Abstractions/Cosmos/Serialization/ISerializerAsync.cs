namespace Cosmos.Serialization;

/// <summary>
/// Object Serializer Meta Interface<br />
/// 对象序列化器元接口
/// </summary>
public interface ISerializerAsync
{
    /// <summary>
    /// Serialize async<br />
    /// 异步序列化
    /// </summary>
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    Task<MemoryStream> ToStreamAsync<TValue>(TValue value, CancellationToken cancellationToken = default);

    /// <summary>
    /// Serialize async<br />
    /// 异步序列化
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<MemoryStream> ToStreamAsync(Type type, object value, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deserialize async<br />
    /// 异步反序列化
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="cancellationToken"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    Task<T> FromStreamAsync<T>(Stream stream, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deserialize async<br />
    /// 异步反序列化
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="type"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<object> FromStreamAsync(Type type, Stream stream, CancellationToken cancellationToken = default);
}