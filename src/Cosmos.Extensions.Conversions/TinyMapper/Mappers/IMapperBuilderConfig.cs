﻿using Cosmos.Reflection;
using TinyMapper.Bindings;
using TinyMapper.Core.DataStructures;
using TinyMapper.Mappers.Classes.Members;
using TinyMapper.Reflection;

namespace TinyMapper.Mappers;

internal interface IMapperBuilderConfig
{
    IDynamicAssembly Assembly { get; }
    Func<string, string, bool> NameMatching { get; }
    Option<BindingConfig> GetBindingConfig(TypePairInfo typePair);
    MapperBuilder GetMapperBuilder(TypePairInfo typePair);
    MapperBuilder GetMapperBuilder(TypePairInfo parentTypePair, MappingMember mappingMember);
}