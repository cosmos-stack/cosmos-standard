using Cosmos.Conversions.Common.Core.FallbackMappings.Core.DataStructures;
using Cosmos.Conversions.Common.Core.FallbackMappings.Core.Extensions;
using Cosmos.Reflection;

namespace Cosmos.Conversions.Common.Core.FallbackMappings.Mappers.Caches;

internal sealed class MapperCache
{
    private readonly Dictionary<TypePairOf, MapperCacheItem> _cache = new();

    public bool IsEmpty => _cache.Count == 0;

    public List<Mapper> Mappers
    {
        get { return _cache.Values.OrderBy(x => x.Id).ConvertAll(x => x.Mapper); }
    }

    public List<MapperCacheItem> MapperCacheItems => _cache.Values.ToList();

    public MapperCacheItem AddStub(TypePairOf key)
    {
        if (_cache.ContainsKey(key))
        {
            return _cache[key];
        }

        var mapperCacheItem = new MapperCacheItem {Id = GetId()};
        _cache[key] = mapperCacheItem;
        return mapperCacheItem;
    }

    public void ReplaceStub(TypePairOf key, Mapper mapper)
    {
        _cache[key].Mapper = mapper;
    }

    public MapperCacheItem Add(TypePairOf key, Mapper mapper)
    {
        if (_cache.TryGetValue(key, out var result))
        {
            return result;
        }

        result = new MapperCacheItem
        {
            Id = GetId(),
            Mapper = mapper
        };
        _cache[key] = result;
        return result;
    }

    public Option<MapperCacheItem> Get(TypePairOf key)
    {
        if (_cache.TryGetValue(key, out var result))
        {
            return new Option<MapperCacheItem>(result);
        }

        return Option<MapperCacheItem>.Empty;
    }

    private int GetId()
    {
        return _cache.Count;
    }
}