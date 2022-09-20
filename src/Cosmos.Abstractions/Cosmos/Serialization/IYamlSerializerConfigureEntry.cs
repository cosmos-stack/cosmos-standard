namespace Cosmos.Serialization;

/// <summary>
/// An interface of configuration entry for yaml serializer.
/// </summary>
public interface IYamlSerializerConfigureEntry
{
    /// <summary>
    /// To config / use a yaml serializer
    /// </summary>
    /// <param name="serializer"></param>
    void ConfigureYamlSerializer(IYamlSerializer serializer);

    /// <summary>
    /// To config / use a yaml serializer
    /// </summary>
    /// <param name="serializerFactory"></param>
    void ConfigureYamlSerializer(Func<IYamlSerializer> serializerFactory);
}