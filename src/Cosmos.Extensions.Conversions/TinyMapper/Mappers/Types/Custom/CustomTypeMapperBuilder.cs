using Cosmos.Reflection;
using TinyMapper.Core.DataStructures;
using TinyMapper.Mappers.Classes.Members;

namespace TinyMapper.Mappers.Types.Custom;

internal sealed class CustomTypeMapperBuilder : MapperBuilder
{
    public CustomTypeMapperBuilder(IMapperBuilderConfig config) : base(config) { }

    protected override string ScopeName => "CustomTypeMapper";

    public bool IsSupported(TypePairInfo parentTypePair, MappingMember mappingMember)
    {
        var bindingConfig = _config.GetBindingConfig(parentTypePair);
        if (bindingConfig.HasNoValue)
        {
            return false;
        }

        return bindingConfig.Value.HasCustomTypeConverter(mappingMember.Target.Name);
    }

    protected override Mapper BuildCore(TypePairInfo typePair)
    {
        throw new NotSupportedException();
    }

    protected override Mapper BuildCore(TypePairInfo parentTypePair, MappingMember mappingMember)
    {
        var bindingConfig = _config.GetBindingConfig(parentTypePair);
        var converter = bindingConfig.Value.GetCustomTypeConverter(mappingMember.Target.Name).Value;
        return new CustomTypeMapper(converter);
    }

    protected override bool IsSupportedCore(TypePairInfo typePair)
    {
        throw new NotSupportedException();
    }
}