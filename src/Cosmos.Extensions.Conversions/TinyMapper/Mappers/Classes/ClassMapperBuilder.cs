using System.Reflection.Emit;
using Cosmos.Reflection;
using TinyMapper.CodeGenerators;
using TinyMapper.CodeGenerators.Emitters;
using TinyMapper.Core;
using TinyMapper.Core.DataStructures;
using TinyMapper.Core.Extensions;
using TinyMapper.Mappers.Caches;
using TinyMapper.Mappers.Classes.Members;
using CosmosTypes = Cosmos.Reflection.Types;

namespace TinyMapper.Mappers.Classes;

internal sealed class ClassMapperBuilder : MapperBuilder
{
    private readonly MapperCache _mapperCache;
    private const string CreateTargetInstanceMethod = "CreateTargetInstance";
    private const string MapClassMethod = "MapClass";
    private readonly MappingMemberBuilder _mappingMemberBuilder;
    private readonly MemberMapper _memberMapper;

    public ClassMapperBuilder(MapperCache mapperCache, IMapperBuilderConfig config) : base(config)
    {
        _mapperCache = mapperCache;
        _memberMapper = new MemberMapper(mapperCache, config);
        _mappingMemberBuilder = new MappingMemberBuilder(config);
    }

    protected override string ScopeName => "ClassMappers";

    protected override Mapper BuildCore(TypePairInfo typePair)
    {
        var parentType = typeof(ClassMapper<,>).MakeGenericType(typePair.Source, typePair.Target);
        var typeBuilder = _assembly.DefineType(GetMapperFullName(), parentType);
        EmitCreateTargetInstance(typePair.Target, typeBuilder);

        var rootMapperCacheItem = _mapperCache.AddStub(typePair);
        var mappers = EmitMapClass(typePair, typeBuilder);

        var rootMapper = (Mapper) Activator.CreateInstance(Helpers.CreateType(typeBuilder));

        UpdateMappers(mappers, rootMapperCacheItem.Id, rootMapper);

        _mapperCache.ReplaceStub(typePair, rootMapper);

        mappers.Do(x => rootMapper.AddMappers(x.Mappers));

        return rootMapper;
    }

    private static void UpdateMappers(Option<MapperCache> mappers, int rootMapperId, Mapper rootMapper)
    {
        if (mappers.HasValue)
        {
            var result = new List<Mapper>();
            foreach (var item in mappers.Value.MapperCacheItems)
            {
                if (item.Id != rootMapperId)
                {
                    result.Add(item.Mapper);
                }
                else
                {
                    result.Add(null);
                }
            }

            result[rootMapperId] = rootMapper;
            rootMapper.AddMappers(result);
            foreach (var item in mappers.Value.MapperCacheItems)
            {
                if (item.Id == rootMapperId)
                {
                    continue;
                }

                item.Mapper?.UpdateRootMapper(rootMapperId, rootMapper);
            }
        }
    }

    protected override Mapper BuildCore(TypePairInfo parentTypePair, MappingMember mappingMember)
    {
        return BuildCore(mappingMember.TypePair);
    }

    protected override bool IsSupportedCore(TypePairInfo typePair)
    {
        return true;
    }

    private static void EmitCreateTargetInstance(Type targetType, TypeBuilder typeBuilder)
    {
        var methodBuilder = typeBuilder.DefineMethod(CreateTargetInstanceMethod, OVERRIDE_PROTECTED, targetType, Type.EmptyTypes);
        var codeGenerator = new CodeGenerator(methodBuilder.GetILGenerator());

        var result = CosmosTypes.IsValueType(targetType) ? EmitValueType(targetType, codeGenerator) : EmitRefType(targetType);

        EmitReturn.Return(result, targetType).Emit(codeGenerator);
    }

    private static IEmitterType EmitRefType(Type type)
    {
        return type.HasDefaultCtor() ? EmitNewObj.NewObj(type) : EmitNull.Load();
    }

    private static IEmitterType EmitValueType(Type type, CodeGenerator codeGenerator)
    {
        var builder = codeGenerator.DeclareLocal(type);
        EmitLocalVariable.Declare(builder).Emit(codeGenerator);
        return EmitBox.Box(EmitLocal.Load(builder));
    }

    private Option<MapperCache> EmitMapClass(TypePairInfo typePair, TypeBuilder typeBuilder)
    {
        var methodBuilder = typeBuilder.DefineMethod(MapClassMethod,
            OVERRIDE_PROTECTED,
            typePair.Target,
            new[] {typePair.Source, typePair.Target});
        var codeGenerator = new CodeGenerator(methodBuilder.GetILGenerator());

        var emitterComposite = new EmitComposite();

        var emitterDescription = EmitMappingMembers(typePair);

        emitterComposite.Add(emitterDescription.Emitter);
        emitterComposite.Add(EmitReturn.Return(EmitArgument.Load(typePair.Target, 2)));
        emitterComposite.Emit(codeGenerator);
        return emitterDescription.MapperCache;
    }

    private MemberEmitterDescription EmitMappingMembers(TypePairInfo typePair)
    {
        var members = _mappingMemberBuilder.Build(typePair);
        var result = _memberMapper.Build(typePair, members);
        return result;
    }
}