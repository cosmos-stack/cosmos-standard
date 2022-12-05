namespace Cosmos.Conversions.Common.Core.FallbackMappings.Mappers.Types.Custom;

internal sealed class CustomTypeMapper : Mapper
{
    private readonly Func<object, object> _converter;

    public CustomTypeMapper(Func<object, object> converter)
    {
        _converter = converter;
    }

    protected override object MapCore(object source, object target)
    {
        return _converter is null ? source : _converter(source);
    }
}