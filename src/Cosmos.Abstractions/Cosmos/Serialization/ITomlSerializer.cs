namespace Cosmos.Serialization;

/// <summary>
/// Interface of Toml serializer<br />
/// Toml 序列化器接口
/// </summary>
public interface ITomlSerializer : IObjectSerializer, ITextSerializer
{
    /// <summary>
    /// If the toml is null or white space will return the default value of T.
    /// </summary>
    /// <param name="toml"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    TValue FromToml<TValue>(string toml);

    /// <summary>
    /// If the string is null or white space will return the default value of the type.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="toml"></param>
    /// <returns></returns>
    object FromToml(Type type, string toml);

    /// <summary>
    /// Serialize to toml.
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    string ToToml<TValue>(TValue value);

    /// <summary>
    /// Serialize to toml.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    string ToToml(Type type, object value);
}