namespace Cosmos.Serialization;

/// <summary>
/// An interface of configuration entry for xml serializer.
/// </summary>
public interface IXmlSerializerConfigureEntry
{
    /// <summary>
    /// To config / use a xml serializer
    /// </summary>
    /// <param name="serializer"></param>
    void ConfigureXmlSerializer(IXmlSerializer serializer);

    /// <summary>
    /// To config / use a xml serializer
    /// </summary>
    /// <param name="serializerFactory"></param>
    void ConfigureXmlSerializer(Func<IXmlSerializer> serializerFactory);
}