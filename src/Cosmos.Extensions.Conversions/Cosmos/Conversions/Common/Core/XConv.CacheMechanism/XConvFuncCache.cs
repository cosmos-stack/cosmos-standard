using System.Collections.Concurrent;
using Cosmos.Conversions.ObjectMappingServices;

namespace Cosmos.Conversions.Common.Core;

internal static class XConvFuncCache
{
    private static readonly ConcurrentDictionary<(Type, Type), Func<object, object, CastingContext, IObjectMapper, object>> _funcs = new();

    public static Func<object, object, CastingContext, IObjectMapper, object> GetConvert(Type typeOfSource, Type typeOfTarget) => _funcs[(typeOfSource, typeOfTarget)];

    public static bool HasInitialized(Type typeOfSource, Type typeOfTarget) => _funcs.ContainsKey((typeOfSource, typeOfTarget));

    public static void CacheOnce(Type typeOfSource, Type typeOfTarget, Func<object, object, CastingContext, IObjectMapper, object> func)
    {
        _funcs.TryAdd((typeOfSource, typeOfTarget), func);
    }
}