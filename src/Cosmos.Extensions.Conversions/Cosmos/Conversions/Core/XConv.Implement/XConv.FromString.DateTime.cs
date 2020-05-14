using System;

// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Cosmos.Conversions.Core {
    internal static partial class XConv {
        private static bool FromStringToDateTimeType<D>(string from, D defaultVal, Type xType, out object result) {
            var valueUpdated = true;
            result = defaultVal;

            if (xType == TypeClass.DateTimeClass) {
                result = DateTimeConv.StringToDateTime(from, DateTimeConv.ObjectToDateTime(defaultVal));
            } else if (xType == TypeClass.DateTimeOffsetClass)
                result = DateTimeConv.StringToDateTimeOffset(from, DateTimeConv.ObjectToDateTimeOffset(defaultVal));
            else if (xType == TypeClass.TimeSpanClass)
                result = DateTimeConv.StringToTimeSpan(from, DateTimeConv.ObjectToTimeSpan(defaultVal));
            else
                valueUpdated = false;

            return valueUpdated;
        }

        private static bool FromStringToNullableDateTimeType(string from, Type innerType, out object result) {
            var valueUpdated = true;
            result = null;

            if (innerType == TypeClass.DateTimeClass)
                result = DateTimeConv.StringToNullableDateTime(from);
            else if (innerType == TypeClass.DateTimeOffsetClass)
                result = DateTimeConv.StringToNullableDateTimeOffset(from);
            else if (innerType == TypeClass.TimeSpanClass)
                result = DateTimeConv.StringToNullableTimeSpan(from);
            else
                valueUpdated = false;

            return valueUpdated;
        }
    }
}