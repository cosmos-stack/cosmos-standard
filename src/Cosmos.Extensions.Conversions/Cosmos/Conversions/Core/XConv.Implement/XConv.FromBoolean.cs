using System;

// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Cosmos.Conversions.Core {
    internal static partial class XConv {
        public static X FromBooleanTo<X>(bool oVal, CastingContext context, Type xType, bool xTypeNullableFlag, X defaultVal = default) {
            bool valueUpdated;
            object result;

            if (xTypeNullableFlag) {
                valueUpdated = FromBooleanToNullableTypeProxy(oVal, context, xType, out result);
            } else {
                valueUpdated = FromBooleanToTypeProxy(oVal, defaultVal, context, xType, out result);
            }

            return valueUpdated
                ? (X) result
                : xTypeNullableFlag
                    ? default
                    : defaultVal;
        }

        public static object FromBooleanTo(bool oVal, CastingContext context, Type xType, bool xTypeNullableFlag, object defaultVal = default) {
            bool valueUpdated;
            object result;

            if (xTypeNullableFlag) {
                valueUpdated = FromBooleanToNullableTypeProxy(oVal, context, xType, out result);
            } else {
                valueUpdated = FromBooleanToTypeProxy(oVal, defaultVal, context, xType, out result);
            }

            return valueUpdated
                ? result
                : xTypeNullableFlag
                    ? default
                    : defaultVal;
        }

        private static bool FromBooleanToTypeProxy<X>(bool oVal, X defaultVal, CastingContext context, Type xType, out object result) {
            if (xType == TypeClass.StringClass)
                return FromBooleanToString(oVal, context, out result);
            if (TypeHelper.IsNumericType(xType))
                return FromBooleanToNumericType<X>(oVal, context, xType, out result);
            if (xType == TypeClass.ObjectClass) {
                result = oVal;
                return true;
            }

            result = defaultVal;
            return false;
        }

        private static bool FromBooleanToTypeProxy(bool oVal, object defaultVal, CastingContext context, Type xType, out object result) {
            if (xType == TypeClass.StringClass)
                return FromBooleanToString(oVal, context, out result);
            if (TypeHelper.IsNumericType(xType))
                return FromBooleanToNumericType(oVal, context, xType, out result);
            if (xType == TypeClass.ObjectClass) {
                result = oVal;
                return true;
            }

            result = defaultVal;
            return false;
        }

        private static bool FromBooleanToNullableTypeProxy(bool oVal, CastingContext context, Type xType, out object result) {
            var innerType = Nullable.GetUnderlyingType(xType);
            if (innerType == TypeClass.StringClass)
                return FromBooleanToString(oVal, context, out result);
            if (TypeHelper.IsNumericType(innerType))
                return FromBooleanToNullableNumericType(oVal, context, innerType, out result);
            if (innerType == TypeClass.ObjectClass) {
                result = oVal;
                return true;
            }

            result = null;
            return false;
        }
    }
}