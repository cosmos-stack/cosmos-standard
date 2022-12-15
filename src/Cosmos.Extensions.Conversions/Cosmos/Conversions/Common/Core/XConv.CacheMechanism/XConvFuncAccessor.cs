using Cosmos.Conversions.ObjectMappingServices;
using Natasha.CSharp.MultiDomain.Extension;

namespace Cosmos.Conversions.Common.Core;

internal static class XConvFuncAccessor
{
    static XConvFuncAccessor()
    {
        NatashaInitializer.Preheating();
    }

    public static Func<O, X, CastingContext, IObjectMapper, X> GetCachedConvert<O, X>()
    {
        if (XConvFuncCache<O, X>.HasInitialized())
            return XConvFuncCache<O, X>.GetConvert();

        var builder = new XConvFuncBuilder<O, X>();

        if (CustomConvertManager.TryGetConvertHandler(typeof(O), typeof(X), out var handler))
            builder.SetCustomConvertHandler(handler);

        var func = builder.Build();

        XConvFuncCache<O, X>.CacheOnce(func);

        return func;
    }

    public static Func<object, X, CastingContext, IObjectMapper, X> GetCachedConvert<X>(Type typeOfSource)
    {
        ArgumentNullException.ThrowIfNull(typeOfSource);
        if (XConvFuncCache<X>.HasInitialized(typeOfSource))
            return XConvFuncCache<X>.GetConvert(typeOfSource);

        var o = typeOfSource.GetDevelopName();
        var x = typeof(X).GetDevelopName();
        var c = typeof(XConvFuncAccessor).GetDevelopName();
        var script = $"""
var handler = {c}.GetCachedConvert<{o},{x}>();
return (a,b,c,d) => handler(a as {o},b,c,d);
""";
        var func = NDelegate.UseDomain(typeof(XConv).GetDomain())
                            .ConfigUsing("Cosmos.Conversions.DynamicXConvServices")
                            .Func<object, X, CastingContext, IObjectMapper, X>(script);

        XConvFuncCache<X>.CacheOnce(typeOfSource, func);

        return func;
    }

    public static Func<object, object, CastingContext, IObjectMapper, object> GetCachedConvert(Type typeOfSource, Type typeOfTarget)
    {
        ArgumentNullException.ThrowIfNull(typeOfSource);
        ArgumentNullException.ThrowIfNull(typeOfTarget);
        if (XConvFuncCache.HasInitialized(typeOfSource, typeOfTarget))
            return XConvFuncCache.GetConvert(typeOfSource, typeOfTarget);
        var o = typeOfSource.GetDevelopName();
        var x = typeOfTarget.GetDevelopName();
        var c = typeof(XConvFuncAccessor).GetDevelopName();
        var script = $"""
var handler = {c}.GetCachedConvert<{o},{x}>();
return (a,b,c,d) => handler(a as {o},b,c,d);
""";
        var func = NDelegate.UseDomain(typeof(XConv).GetDomain())
                            .ConfigUsing("Cosmos.Conversions.DynamicXConvServices")
                            .Func<object, object, CastingContext, IObjectMapper, object>(script);

        XConvFuncCache.CacheOnce(typeOfSource, typeOfTarget, func);

        return func;
    }
}