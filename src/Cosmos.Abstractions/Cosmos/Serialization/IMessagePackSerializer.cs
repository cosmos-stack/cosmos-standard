namespace Cosmos.Serialization;

/// <summary>
/// Interface of MessagePack serializer<br />
/// MessagePack 序列化器接口
/// </summary>
public interface IMessagePackSerializer : IObjectSerializer<byte[]>, IBytesSerializer, IStreamSerializerAsync { }