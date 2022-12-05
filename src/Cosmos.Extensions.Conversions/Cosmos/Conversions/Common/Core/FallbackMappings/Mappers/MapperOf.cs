namespace Cosmos.Conversions.Common.Core.FallbackMappings.Mappers;

internal abstract class MapperOf<TSource, TTarget> : Mapper
{
    protected override object MapCore(object source, object target)
    {
        return source is null ? default : MapCore((TSource) source, (TTarget) target);
    }

    protected abstract TTarget MapCore(TSource source, TTarget target);
}