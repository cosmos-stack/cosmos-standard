using Cosmos.Reflection;

// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Cosmos.Conversions.Common.Core;

internal static partial class XConv
{
    public static X FromNumericTo<X>(
        Type oType, bool oTypeNullableFlag, object oVal, CastingContext context,
        Type xType, bool xTypeNullableFlag, X defaultVal = default)
    {
        object result;

        var valueUpdated = oTypeNullableFlag
            ? FromNullableNumericTypeToTypeProxy(oType, oVal, context, xType, out result)
            : FromNumericTypeToTypeProxy(oVal, defaultVal, context, xType, out result);

        return valueUpdated
            ? (X) result
            : xTypeNullableFlag
                ? default
                : defaultVal;
    }

    public static object FromNumericTo(
        Type oType, bool oTypeNullableFlag, object oVal, CastingContext context,
        Type xType, bool xTypeNullableFlag, object defaultVal = default)
    {
        object result;

        var valueUpdated = oTypeNullableFlag
            ? FromNullableNumericTypeToTypeProxy(oType, oVal, context, xType, out result)
            : FromNumericTypeToTypeProxy(oVal, defaultVal, context, xType, out result);

        return valueUpdated
            ? result
            : xTypeNullableFlag
                ? default
                : defaultVal;
    }

    private static bool FromNumericTypeToTypeProxy<X>(object oVal, X defaultVal, CastingContext context, Type xType, out object result)
    {
        if (TypeDeterminer.IsStringType(defaultVal, out var defaultStr))
            return FromNumericTypeToString(oVal, context, defaultStr, out result);
        if (TypeDeterminer.IsNumericType(xType))
            return FromNumericTypeToNumericType(oVal, defaultVal, xType, out result);
        if (TypeDeterminer.IsOriginObject(xType))
        {
            result = oVal;
            return true;
        }

        result = defaultVal;
        return false;
    }

    private static bool FromNullableNumericTypeToTypeProxy(Type oType, object oVal, CastingContext context, Type xType, out object result)
    {
        var innerType = TypeConv.GetNonNullableType(xType);
        if (TypeDeterminer.IsStringType(innerType))
            return FromNullableNumericTypeToString(oVal, oType, context, out result);
        if (TypeDeterminer.IsNumericType(innerType))
            return FromNumericTypeToNullableNumericType(oVal, innerType, out result);
        if (TypeDeterminer.IsOriginObject(innerType))
        {
            result = oVal;
            return true;
        }

        result = null;
        return false;
    }
}