using Cosmos.Conversions.Common.Core.FallbackMappings;

namespace Cosmos.Conversions.ObjectMappingServices;

/// <summary>
/// Cosmos.Core default mapper
/// </summary>
public class DefaultObjectMapper : IObjectMapper
{
    /// <summary>
    /// Gets a default mapper instance.
    /// </summary>
    public static IObjectMapper Instance => DefaultMapperCache.Instance;

    /// <inheritdoc />
    public TDestination MapTo<TSource, TDestination>(TSource source)
    {
        return TinyMapper.Map<TSource, TDestination>(source);
    }

    /// <inheritdoc />
    public TDestination MapTo<TSource, TDestination>(TSource source, TDestination destination)
    {
        return TinyMapper.Map(source, destination);
    }

    /// <inheritdoc />
    public object MapTo(Type sourceType, Type destinationType, object source)
    {
        return TinyMapper.Map(sourceType, destinationType, source);
    }

    /// <inheritdoc />
    public object MapTo(Type sourceType, Type destinationType, object source, object destination)
    {
        return TinyMapper.Map(sourceType, destinationType, source, destination);
    }
}