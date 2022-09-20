namespace Cosmos.Serialization;

/// <summary>
/// Interface of Bssom serializer<br />
/// Bssom 序列化器接口
/// </summary>
public interface IBssomSerializer : IObjectSerializer<byte[]>, IBytesSerializer, IStreamSerializerAsync { }