using System.Collections.Concurrent;
using Cosmos.Conversions.ObjectMappingServices;

namespace Cosmos.Conversions.Common.Core;

internal static class XConvFuncCache<X>
{
    private static readonly ConcurrentDictionary<Type, Func<object, X, CastingContext, IObjectMapper, X>> _funcs = new();

    public static Func<object, X, CastingContext, IObjectMapper, X> GetConvert(Type typeOfSource) => _funcs[typeOfSource];

    public static bool HasInitialized(Type typeOfSource) => _funcs.ContainsKey(typeOfSource);

    public static void CacheOnce(Type typeOfSource, Func<object, X, CastingContext, IObjectMapper, X> func)
    {
        _funcs.TryAdd(typeOfSource, func);
    }
}