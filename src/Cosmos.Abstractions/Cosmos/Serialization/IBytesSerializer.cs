namespace Cosmos.Serialization;

public interface IBytesSerializer : IStreamSerializer
{
    #region From bytes...

    /// <summary>
    /// If the bytes is null or empty will return the default value of T.
    /// </summary>
    /// <param name="bytes"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    TValue FromBytes<TValue>(byte[] bytes);

    /// <summary>
    /// If the bytes is null or empty will return the default value of the type.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="bytes"></param>
    /// <returns></returns>
    object FromBytes(Type type, byte[] bytes);

    #endregion

    #region To bytes...

    /// <summary>
    /// Serialize to bytes.
    /// </summary>
    /// <param name="value"></param>
    /// <typeparam name="TValue"></typeparam>
    /// <returns></returns>
    byte[] ToBytes<TValue>(TValue value);

    /// <summary>
    /// Serialize to bytes.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    byte[] ToBytes(Type type, object value);

    #endregion
}