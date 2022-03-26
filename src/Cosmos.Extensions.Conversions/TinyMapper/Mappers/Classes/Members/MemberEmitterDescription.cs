using TinyMapper.CodeGenerators.Emitters;
using TinyMapper.Core.DataStructures;
using TinyMapper.Core.Extensions;
using TinyMapper.Mappers.Caches;

namespace TinyMapper.Mappers.Classes.Members;

internal sealed class MemberEmitterDescription
{
    public MemberEmitterDescription(IEmitter emitter, MapperCache mappers)
    {
        Emitter = emitter;
        MapperCache = new Option<MapperCache>(mappers, mappers.IsEmpty);
    }

    public IEmitter Emitter { get; }
    public Option<MapperCache> MapperCache { get; private set; }

    public void AddMapper(MapperCache value)
    {
        MapperCache = value.ToOption();
    }
}