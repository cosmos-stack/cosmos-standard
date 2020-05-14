using System;

// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Cosmos.Conversions.Core {
    internal static partial class XConv {
        private static bool FromDateTimeToNumericType<N>(DateTime dateTime, N defaultVal, Type xType, out object result) {
            var valueUpdated = true;
            if (xType == TypeClass.Int64Class || xType == TypeClass.DecimalClass) {
                result = dateTime.Ticks;
            } else {
                result = defaultVal;
                valueUpdated = false;
            }

            return valueUpdated;
        }

        private static bool FromDateTimeToNullableNumericType(DateTime dateTime, Type innerType, out object result) {
            var valueUpdated = true;

            if (innerType == TypeClass.Int64Class || innerType == TypeClass.DecimalClass) {
                result = dateTime.Ticks;
            } else {
                result = null;
                valueUpdated = false;
            }

            return valueUpdated;
        }
    }
}