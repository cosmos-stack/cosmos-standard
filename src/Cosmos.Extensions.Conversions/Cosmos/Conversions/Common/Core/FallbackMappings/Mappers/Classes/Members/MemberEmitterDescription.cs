using Cosmos.Conversions.Common.Core.FallbackMappings.CodeGenerators.Emitters;
using Cosmos.Conversions.Common.Core.FallbackMappings.Core.DataStructures;
using Cosmos.Conversions.Common.Core.FallbackMappings.Core.Extensions;
using Cosmos.Conversions.Common.Core.FallbackMappings.Mappers.Caches;

namespace Cosmos.Conversions.Common.Core.FallbackMappings.Mappers.Classes.Members;

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