using Cosmos.Conversions.Common.Core;

namespace Cosmos.Conversions;

/// <summary>
/// Object Conversion Utilities
/// </summary>
public static class ObjectConv
{
    static ObjectConv()
    {
        NatashaInitializer.Preheating();
    }

    #region 0

    /// <summary>
    /// Convert from sourceType to targetType
    /// </summary>
    /// <param name="sourceType"></param>
    /// <param name="targetType"></param>
    /// <param name="source"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public static object To(Type sourceType, Type targetType, object source, CastingContext context = default)
    {
        var handler = XConvFuncAccessor.GetCachedConvert(sourceType, targetType);
        return handler(source, default, context, null);
        // return XConv.To(source, sourceType, targetType, context: context);
    }

    /// <summary>
    /// Convert from sourceType to targetType
    /// </summary>
    /// <param name="sourceType"></param>
    /// <param name="targetType"></param>
    /// <param name="source"></param>
    /// <param name="defaultVal"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public static object To(Type sourceType, Type targetType, object source, object defaultVal, CastingContext context = default)
    {
        var handler = XConvFuncAccessor.GetCachedConvert(sourceType, targetType);
        return handler(source, defaultVal, context, null);
        // return XConv.To(source, sourceType, targetType, defaultVal, context);
    }

    #endregion

    #region 1

    /// <summary>
    /// Convert from sourceType to targetType
    /// </summary>
    /// <param name="source"></param>
    /// <param name="context"></param>
    /// <typeparam name="TTo"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TTo To<TTo>(object source, CastingContext context = default)
    {
        var handler = XConvFuncAccessor.GetCachedConvert<TTo>(source.GetType());
        return handler(source, default, context, null);
        // return XConv.To(source, source.GetType(), typeof(TTo), context: context).As<TTo>();
    }

    /// <summary>
    /// Convert from sourceType to targetType
    /// </summary>
    /// <param name="source"></param>
    /// <param name="defaultVal"></param>
    /// <param name="context"></param>
    /// <typeparam name="TTo"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TTo To<TTo>(object source, TTo defaultVal, CastingContext context = default)
    {
        var handler = XConvFuncAccessor.GetCachedConvert<TTo>(source.GetType());
        return handler(source, defaultVal, context, null);
        // return XConv.To(source, source.GetType(), typeof(TTo), defaultVal, context).As<TTo>();
    }

    #endregion

    #region 2

    /// <summary>
    /// Convert from TFrom to TTo
    /// </summary>
    /// <param name="source"></param>
    /// <param name="context"></param>
    /// <typeparam name="TFrom"></typeparam>
    /// <typeparam name="TTo"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TTo To<TFrom, TTo>(TFrom source, CastingContext context = default)
    {
        var handler = XConvFuncAccessor.GetCachedConvert<TFrom, TTo>();
        return handler(source, default, context, null);
        //return XConv.To<TFrom, TTo>(source, context: context);
    }

    /// <summary>
    /// Convert from TFrom to TTo
    /// </summary>
    /// <param name="source"></param>
    /// <param name="defaultVal"></param>
    /// <param name="context"></param>
    /// <typeparam name="TFrom"></typeparam>
    /// <typeparam name="TTo"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TTo To<TFrom, TTo>(TFrom source, TTo defaultVal, CastingContext context = default)
    {
        var handler = XConvFuncAccessor.GetCachedConvert<TFrom, TTo>();
        return handler(source, defaultVal, context, null);
        // return XConv.To(source, defaultVal, context);
    }

    #endregion

    #region List

    /// <summary>
    /// Convert from string to a TTo instances list.
    /// </summary>
    /// <typeparam name="TTo"></typeparam>
    /// <param name="listStr"></param>
    /// <param name="splitChar"></param>
    /// <returns></returns>
    public static IEnumerable<TTo> ToList<TTo>(string listStr, char splitChar = ',')
    {
        var results = new List<TTo>();

        if (string.IsNullOrWhiteSpace(listStr))
            return results;

        var array = listStr.Split(splitChar);
        results.AddRange(from each in array where !string.IsNullOrWhiteSpace(each) select each.CastTo<TTo>());

        return results;
    }

    #endregion
}