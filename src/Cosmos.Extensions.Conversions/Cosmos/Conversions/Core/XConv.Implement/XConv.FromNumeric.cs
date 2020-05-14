using System;

// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Cosmos.Conversions.Core {
    internal static partial class XConv {
        public static X FromNumericTo<X>(
            Type oType, bool oTypeNullableFlag, object oVal, CastingContext context,
            Type xType, bool xTypeNullableFlag, X defaultVal = default) {
            bool valueUpdated;
            object result;

            if (oTypeNullableFlag) {
                valueUpdated = FromNullableNumericTypeToTypeProxy(oType, oVal, context, xType, out result);
            } else {
                valueUpdated = FromNumericTypeToTypeProxy(oVal, defaultVal, context, xType, out result);
            }

            return valueUpdated
                ? (X) result
                : xTypeNullableFlag
                    ? default
                    : defaultVal;
        }

        public static object FromNumericTo(
            Type oType, bool oTypeNullableFlag, object oVal, CastingContext context,
            Type xType, bool xTypeNullableFlag, object defaultVal = default) {
            bool valueUpdated;
            object result;

            if (oTypeNullableFlag) {
                valueUpdated = FromNullableNumericTypeToTypeProxy(oType, oVal, context, xType, out result);
            } else {
                valueUpdated = FromNumericTypeToTypeProxy(oVal, defaultVal, context, xType, out result);
            }

            return valueUpdated
                ? result
                : xTypeNullableFlag
                    ? default
                    : defaultVal;
        }

        private static bool FromNumericTypeToTypeProxy<X>(object oVal, X defaultVal, CastingContext context, Type xType, out object result) {
            if (defaultVal is string defaultStr)
                return FromNumericTypeToString(oVal, context, defaultStr, out result);
            if (TypeHelper.IsNumericType(xType))
                return FromNumericTypeToNumericType(oVal, defaultVal, xType, out result);
            if (xType == TypeClass.ObjectClass) {
                result = oVal;
                return true;
            }

            result = defaultVal;
            return false;
        }

        private static bool FromNullableNumericTypeToTypeProxy(Type oType, object oVal, CastingContext context, Type xType, out object result) {
            var innerType = Nullable.GetUnderlyingType(xType);
            if (innerType == TypeClass.StringClass)
                return FromNullableNumericTypeToString(oVal, oType, context, out result);
            if (TypeHelper.IsNumericType(innerType))
                return FromNumericTypeToNullableNumericType(oVal, innerType, out result);
            if (innerType == TypeClass.ObjectClass) {
                result = oVal;
                return true;
            }

            result = null;
            return false;
        }
    }
}