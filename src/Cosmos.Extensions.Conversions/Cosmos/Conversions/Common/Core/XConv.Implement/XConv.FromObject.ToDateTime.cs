using Cosmos.Reflection;

// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Cosmos.Conversions.Common.Core;

internal static partial class XConv
{
    private static bool FromObjToDateTime<D>(object fromObj, D defaultVal, Type xType, out object result)
    {
        var valueUpdated = true;
        result = defaultVal;

        if (xType == TypeClass.DateTimeClazz)
            result = DtConvX.ObjectToDateTime(fromObj, DtConvX.ObjectToDateTime(defaultVal));
        else if (xType == TypeClass.DateTimeOffsetClazz)
            result = DtConvX.ObjectToDateTimeOffset(fromObj, DtConvX.ObjectToDateTimeOffset(defaultVal));
        else if (xType == TypeClass.TimeSpanClazz)
            result = DtConvX.ObjectToTimeSpan(fromObj, DtConvX.ObjectToTimeSpan(defaultVal));
        else
            valueUpdated = false;

        return valueUpdated;
    }

    private static bool FromObjToNullableDateTimeType(object fromObj, Type innerType, out object result)
    {
        var valueUpdated = true;
        result = null;

        if (innerType == TypeClass.DateTimeClazz)
            result = DtConvX.ObjectToNullableDateTime(fromObj);
        else if (innerType == TypeClass.DateTimeOffsetClazz)
            result = DtConvX.ObjectToNullableDateTimeOffset(fromObj);
        else if (innerType == TypeClass.TimeSpanClazz)
            result = DtConvX.ObjectToNullableTimeSpan(fromObj);
        else
            valueUpdated = false;

        return valueUpdated;
    }
}