using System;

// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Cosmos.Conversions.Core {
    internal static partial class XConv {
        private static bool FromObjToDateTime<D>(object fromObj, D defaultVal, Type xType, out object result) {
            var valueUpdated = true;
            result = defaultVal;

            if (xType == TypeClass.DateTimeClass) {
                result = DateTimeConv.ObjectToDateTime(fromObj, DateTimeConv.ObjectToDateTime(defaultVal));
            } else if (xType == TypeClass.DateTimeOffsetClass)
                result = DateTimeConv.ObjectToDateTimeOffset(fromObj, DateTimeConv.ObjectToDateTimeOffset(defaultVal));
            else if (xType == TypeClass.TimeSpanClass)
                result = DateTimeConv.ObjectToTimeSpan(fromObj, DateTimeConv.ObjectToTimeSpan(defaultVal));
            else
                valueUpdated = false;

            return valueUpdated;
        }

        private static bool FromObjToNullableDateTimeType(object fromObj, Type innerType, out object result) {
            var valueUpdated = true;
            result = null;

            if (innerType == TypeClass.DateTimeClass)
                result = DateTimeConv.ObjectToNullableDateTime(fromObj);
            else if (innerType == TypeClass.DateTimeOffsetClass)
                result = DateTimeConv.ObjectToNullableDateTimeOffset(fromObj);
            else if (innerType == TypeClass.TimeSpanClass)
                result = DateTimeConv.ObjectToNullableTimeSpan(fromObj);
            else
                valueUpdated = false;

            return valueUpdated;
        }
    }
}