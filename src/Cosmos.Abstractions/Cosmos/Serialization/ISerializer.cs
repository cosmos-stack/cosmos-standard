namespace Cosmos.Serialization;

/// <summary>
/// Object Serializer Meta Interface<br />
/// 对象序列化器元接口
/// </summary>
public interface ISerializer
{
    /// <summary>
    /// Serialize to stream.<br />
    /// 序列化
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    MemoryStream ToStream<TValue>(TValue value);

    /// <summary>
    ///Serialize to stream.<br />
    /// 序列化
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    MemoryStream ToStream(Type type, object value);

    /// <summary>
    /// Deserialize<br />
    /// 反序列化
    /// </summary>
    /// <param name="stream"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    TValue FromStream<TValue>(Stream stream);

    /// <summary>
    /// Deserialize<br />
    /// 反序列化
    /// </summary>
    /// <param name="stream"></param>
    /// <param name="type"></param>
    /// <returns></returns>
    object FromStream(Type type, Stream stream);
}