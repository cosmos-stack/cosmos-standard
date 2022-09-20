namespace Cosmos.Serialization;

/// <summary>
/// An interface of configuration entry for toml serializer.
/// </summary>
public interface ITomlSerializerConfigureEntry
{
    /// <summary>
    /// To config / use a toml serializer
    /// </summary>
    /// <param name="serializer"></param>
    void ConfigureTomlSerializer(ITomlSerializer serializer);

    /// <summary>
    /// To config / use a toml serializer
    /// </summary>
    /// <param name="serializerFactory"></param>
    void ConfigureTomlSerializer(Func<ITomlSerializer> serializerFactory);
}