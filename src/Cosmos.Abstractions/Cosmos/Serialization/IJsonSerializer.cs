namespace Cosmos.Serialization;

/// <summary>
/// Interface of Json serializer<br />
/// Json 序列化器接口
/// </summary>
public interface IJsonSerializer : IObjectSerializer, ITextSerializer
{
    #region From json...

    /// <summary>
    /// If the json is null or white space will return the default value of T.
    /// </summary>
    /// <param name="json"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    TValue FromJson<TValue>(string json);

    /// <summary>
    /// If the string is null or white space will return the default value of the type.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="json"></param>
    /// <returns></returns>
    object FromJson(Type type, string json);

    #endregion

    #region To json...

    /// <summary>
    /// Serialize to json.
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    string ToJson<TValue>(TValue value);

    /// <summary>
    /// Serialize to json.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    string ToJson(Type type, object value);

    #endregion
}