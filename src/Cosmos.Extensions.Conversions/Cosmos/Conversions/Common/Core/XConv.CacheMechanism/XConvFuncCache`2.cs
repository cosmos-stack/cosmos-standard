using Cosmos.Conversions.ObjectMappingServices;

namespace Cosmos.Conversions.Common.Core;

internal static class XConvFuncCache<O, X>
{
    private static Func<O, X, CastingContext, IObjectMapper, X> ConvertImplFunc { get; set; }

    public static Func<O, X, CastingContext, IObjectMapper, X> GetConvert() => ConvertImplFunc;

    public static bool HasInitialized() => ConvertImplFunc != null;

    public static void CacheOnce(Func<O, X, CastingContext, IObjectMapper, X> func)
    {
        if (ConvertImplFunc == null)
        {
            ConvertImplFunc = func;
        }
    }
}