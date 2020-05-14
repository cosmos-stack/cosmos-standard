using System;

// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Cosmos.Conversions.Core {
    internal static partial class XConv {
        public static X FromEnumTo<X>(Type enumType, object enumVal, CastingContext context, Type xType, bool xTypeNullableFlag, X defaultVal = default) {
            bool valueUpdated;
            object result;

            if (xTypeNullableFlag) {
                valueUpdated = FromEnumToNullableTypeProxy(enumType, enumVal, context, xType, out result);
            } else {
                valueUpdated = FromEnumToTypeProxy(enumType, enumVal, defaultVal, context, xType, out result);
            }

            return valueUpdated
                ? (X) result
                : xTypeNullableFlag
                    ? default
                    : defaultVal;
        }

        public static object FromEnumTo(Type enumType, object enumVal, CastingContext context, Type xType, bool xTypeNullableFlag, object defaultVal = default) {
            bool valueUpdated;
            object result;

            if (xTypeNullableFlag) {
                valueUpdated = FromEnumToNullableTypeProxy(enumType, enumVal, context, xType, out result);
            } else {
                valueUpdated = FromEnumToTypeProxy(enumType, enumVal, defaultVal, context, xType, out result);
            }

            return valueUpdated
                ? result
                : xTypeNullableFlag
                    ? default
                    : defaultVal;
        }

        private static bool FromEnumToTypeProxy<X>(Type enumType, object enumVal, X defaultVal, CastingContext context, Type xType, out object result) {
            if (defaultVal is string defaultStr)
                return FromEnumToString(enumType, enumVal, defaultStr, out result);
            if (TypeHelper.IsNumericType(xType))
                return FromEnumToNumericType(enumType, enumVal, defaultVal, xType, out result);
            if (xType == TypeClass.ObjectClass) {
                result = enumVal;
                return true;
            }

            result = defaultVal;
            return false;
        }

        private static bool FromEnumToTypeProxy(Type enumType, object enumVal, object defaultVal, CastingContext context, Type xType, out object result) {
            if (defaultVal is string defaultStr)
                return FromEnumToString(enumType, enumVal, defaultStr, out result);
            if (TypeHelper.IsNumericType(xType))
                return FromEnumToNumericType(enumType, enumVal, defaultVal, xType, out result);
            if (xType == TypeClass.ObjectClass) {
                result = enumVal;
                return true;
            }

            result = defaultVal;
            return false;
        }

        private static bool FromEnumToNullableTypeProxy(Type enumType, object enumVal, CastingContext context, Type xType, out object result) {
            var innerType = Nullable.GetUnderlyingType(xType);
            if (TypeHelper.IsNumericType(innerType))
                return FromEnumToNullableNumericType(enumType, enumVal, innerType, out result);
            if (innerType == TypeClass.StringClass)
                return FromEnumToString(enumType, enumVal, "", out result);
            if (innerType == TypeClass.ObjectClass) {
                result = enumVal;
                return true;
            }

            result = null;
            return false;
        }
    }
}