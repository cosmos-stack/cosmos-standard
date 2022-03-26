using Cosmos.Reflection;

// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Cosmos.Conversions.Common.Core;

internal static partial class XConv
{
    public static X FromBooleanTo<X>(bool oVal, CastingContext context, Type xType, bool xTypeNullableFlag, X defaultVal = default)
    {
        object result;

        var valueUpdated = xTypeNullableFlag
            ? FromBooleanToNullableTypeProxy(oVal, context, xType, out result)
            : FromBooleanToTypeProxy(oVal, defaultVal, context, xType, out result);

        return valueUpdated
            ? (X) result
            : xTypeNullableFlag
                ? default
                : defaultVal;
    }

    public static object FromBooleanTo(bool oVal, CastingContext context, Type xType, bool xTypeNullableFlag, object defaultVal = default)
    {
        object result;

        var valueUpdated = xTypeNullableFlag
            ? FromBooleanToNullableTypeProxy(oVal, context, xType, out result)
            : FromBooleanToTypeProxy(oVal, defaultVal, context, xType, out result);

        return valueUpdated
            ? result
            : xTypeNullableFlag
                ? default
                : defaultVal;
    }

    private static bool FromBooleanToTypeProxy<X>(bool oVal, X defaultVal, CastingContext context, Type xType, out object result)
    {
        if (TypeDeterminer.IsStringType(xType))
            return FromBooleanToString(oVal, context, out result);
        if (TypeDeterminer.IsNumericType(xType))
            return FromBooleanToNumericType<X>(oVal, context, xType, out result);
        if (TypeDeterminer.IsOriginObject(xType))
        {
            result = oVal;
            return true;
        }

        result = defaultVal;
        return false;
    }

    private static bool FromBooleanToTypeProxy(bool oVal, object defaultVal, CastingContext context, Type xType, out object result)
    {
        if (TypeDeterminer.IsStringType(xType))
            return FromBooleanToString(oVal, context, out result);
        if (TypeDeterminer.IsNumericType(xType))
            return FromBooleanToNumericType(oVal, context, xType, out result);
        if (TypeDeterminer.IsOriginObject(xType))
        {
            result = oVal;
            return true;
        }

        result = defaultVal;
        return false;
    }

    private static bool FromBooleanToNullableTypeProxy(bool oVal, CastingContext context, Type xType, out object result)
    {
        var innerType = TypeConv.GetNonNullableType(xType);
        if (TypeDeterminer.IsStringType(innerType))
            return FromBooleanToString(oVal, context, out result);
        if (TypeDeterminer.IsNumericType(innerType))
            return FromBooleanToNullableNumericType(oVal, context, innerType, out result);
        if (TypeDeterminer.IsOriginObject(innerType))
        {
            result = oVal;
            return true;
        }

        result = null;
        return false;
    }
}