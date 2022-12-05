using Cosmos.Conversions.Common.Core.FallbackMappings.Bindings;
using Cosmos.Conversions.Common.Core.FallbackMappings.Core.DataStructures;
using Cosmos.Conversions.Common.Core.FallbackMappings.Mappers.Classes.Members;
using Cosmos.Conversions.Common.Core.FallbackMappings.Reflection;
using Cosmos.Reflection;

namespace Cosmos.Conversions.Common.Core.FallbackMappings.Mappers;

internal interface IMapperBuilderConfig
{
    IDynamicAssembly Assembly { get; }
    Func<string, string, bool> NameMatching { get; }
    Option<BindingConfig> GetBindingConfig(TypePairOf typePair);
    MapperBuilder GetMapperBuilder(TypePairOf typePair);
    MapperBuilder GetMapperBuilder(TypePairOf parentTypePair, MappingMember mappingMember);
}