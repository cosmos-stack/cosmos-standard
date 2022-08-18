﻿using Cosmos.Reflection;
using TinyMapper.Bindings;
using TinyMapper.Core.DataStructures;
using TinyMapper.Core.Extensions;
using TinyMapper.Mappers.Caches;
using TinyMapper.Mappers.Classes;
using TinyMapper.Mappers.Classes.Members;
using TinyMapper.Mappers.Collections;
using TinyMapper.Mappers.Types.Convertible;
using TinyMapper.Mappers.Types.Custom;
using TinyMapper.Reflection;

namespace TinyMapper.Mappers;

internal sealed class TargetMapperBuilder : IMapperBuilderConfig
{
    public static readonly Func<string, string, bool> DefaultNameMatching = (source, target) => string.Equals(source, target, StringComparison.Ordinal);

    private readonly Dictionary<TypePairOf, BindingConfig> _bindingConfigs = new();
    private readonly ClassMapperBuilder _classMapperBuilder;
    private readonly CollectionMapperBuilder _collectionMapperBuilder;
    private readonly ConvertibleTypeMapperBuilder _convertibleTypeMapperBuilder;
    private readonly CustomTypeMapperBuilder _customTypeMapperBuilder;

    public TargetMapperBuilder(IDynamicAssembly assembly)
    {
        Assembly = assembly;

        var mapperCache = new MapperCache();
        _classMapperBuilder = new ClassMapperBuilder(mapperCache, this);
        _collectionMapperBuilder = new CollectionMapperBuilder(mapperCache, this);
        _convertibleTypeMapperBuilder = new ConvertibleTypeMapperBuilder(this);
        _customTypeMapperBuilder = new CustomTypeMapperBuilder(this);

        NameMatching = DefaultNameMatching;
    }

    public Func<string, string, bool> NameMatching { get; private set; }

    public IDynamicAssembly Assembly { get; }

    public Option<BindingConfig> GetBindingConfig(TypePairOf typePair)
    {
        var result = _bindingConfigs.GetValue(typePair);
        return result;
    }

    public MapperBuilder GetMapperBuilder(TypePairOf parentTypePair, MappingMember mappingMember)
    {
        if (_customTypeMapperBuilder.IsSupported(parentTypePair, mappingMember))
        {
            return _customTypeMapperBuilder;
        }

        return GetTypeMapperBuilder(mappingMember.TypePair);
    }

    public MapperBuilder GetMapperBuilder(TypePairOf typePair)
    {
        return GetTypeMapperBuilder(typePair);
    }

    public void SetNameMatching(Func<string, string, bool> nameMatching)
    {
        NameMatching = nameMatching;
    }

    public Mapper Build(TypePairOf typePair, BindingConfig bindingConfig)
    {
        _bindingConfigs[typePair] = bindingConfig;
        return Build(typePair);
    }

    public Mapper Build(TypePairOf typePair)
    {
        var mapperBuilder = GetTypeMapperBuilder(typePair);
        var mapper = mapperBuilder.Build(typePair);
        return mapper;
    }

    private MapperBuilder GetTypeMapperBuilder(TypePairOf typePair)
    {
        if (_convertibleTypeMapperBuilder.IsSupported(typePair))
        {
            return _convertibleTypeMapperBuilder;
        }

        if (_collectionMapperBuilder.IsSupported(typePair))
        {
            return _collectionMapperBuilder;
        }

        return _classMapperBuilder;
    }
}