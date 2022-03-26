using Cosmos.Reflection;

// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Cosmos.Conversions.Common.Core;

internal static partial class XConv
{
    private static bool FromStringToDateTimeType<D>(string from, D defaultVal, Type xType, out object result)
    {
        var valueUpdated = true;
        result = defaultVal;

        if (xType == TypeClass.DateTimeClazz)
            result = DtConvX.StringToDateTime(from, DtConvX.ObjectToDateTime(defaultVal));
        else if (xType == TypeClass.DateTimeOffsetClazz)
            result = DtConvX.StringToDateTimeOffset(from, DtConvX.ObjectToDateTimeOffset(defaultVal));
        else if (xType == TypeClass.TimeSpanClazz)
            result = DtConvX.StringToTimeSpan(from, DtConvX.ObjectToTimeSpan(defaultVal));
        else
            valueUpdated = false;

        return valueUpdated;
    }

    private static bool FromStringToNullableDateTimeType(string from, Type innerType, out object result)
    {
        var valueUpdated = true;
        result = null;

        if (innerType == TypeClass.DateTimeClazz)
            result = DtConvX.StringToNullableDateTime(from);
        else if (innerType == TypeClass.DateTimeOffsetClazz)
            result = DtConvX.StringToNullableDateTimeOffset(from);
        else if (innerType == TypeClass.TimeSpanClazz)
            result = DtConvX.StringToNullableTimeSpan(from);
        else
            valueUpdated = false;

        return valueUpdated;
    }
}