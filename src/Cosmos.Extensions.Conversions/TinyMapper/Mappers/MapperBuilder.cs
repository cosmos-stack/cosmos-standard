using System.Reflection;
using Cosmos.Reflection;
using TinyMapper.Core.DataStructures;
using TinyMapper.Mappers.Classes.Members;
using TinyMapper.Reflection;

namespace TinyMapper.Mappers;

internal abstract class MapperBuilder
{
    // ReSharper disable once InconsistentNaming
    protected const MethodAttributes OVERRIDE_PROTECTED = MethodAttributes.Family | MethodAttributes.Virtual;
    private const string AssemblyName = "DynamicTinyMapper";

    // ReSharper disable once InconsistentNaming
    protected readonly IDynamicAssembly _assembly;

    // ReSharper disable once InconsistentNaming
    protected readonly IMapperBuilderConfig _config;

    protected MapperBuilder(IMapperBuilderConfig config)
    {
        _config = config;
        _assembly = config.Assembly;
    }

    protected abstract string ScopeName { get; }

    public Mapper Build(TypePairOf typePair)
    {
        return BuildCore(typePair);
    }

    public Mapper Build(TypePairOf parentTypePair, MappingMember mappingMember)
    {
        return BuildCore(parentTypePair, mappingMember);
    }

    public bool IsSupported(TypePairOf typePair)
    {
        return IsSupportedCore(typePair);
    }

    protected abstract Mapper BuildCore(TypePairOf typePair);
    protected abstract Mapper BuildCore(TypePairOf parentTypePair, MappingMember mappingMember);

    protected MapperBuilder GetMapperBuilder(TypePairOf typePair)
    {
        return _config.GetMapperBuilder(typePair);
    }

    protected string GetMapperFullName()
    {
        var random = Guid.NewGuid().ToString("N");
        return $"{AssemblyName}.{ScopeName}.Mapper{random}";
    }

    protected abstract bool IsSupportedCore(TypePairOf typePair);
}