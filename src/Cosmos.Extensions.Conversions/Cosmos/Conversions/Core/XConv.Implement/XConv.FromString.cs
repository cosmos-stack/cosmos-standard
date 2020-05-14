using System;
using Cosmos.Text;

// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Cosmos.Conversions.Core {
    internal static partial class XConv {
        public static X FromStringTo<X>(string @from, Type xType, bool xTypeNullableFlag, X defaultVal = default) {
            bool valueUpdated;
            object result;

            if (xTypeNullableFlag) {
                valueUpdated = FromStringToNullableTypeProxy(from, xType, out result);
            } else {
                valueUpdated = FromStringToTypeProxy(from, defaultVal, xType, out result);
            }

            return valueUpdated
                ? (X) result
                : xTypeNullableFlag
                    ? default
                    : defaultVal;
        }

        public static object FromStringTo(string @from, Type xType, bool xTypeNullableFlag, object defaultVal = default) {
            bool valueUpdated;
            object result;

            if (xTypeNullableFlag) {
                valueUpdated = FromStringToNullableTypeProxy(from, xType, out result);
            } else {
                valueUpdated = FromStringToTypeProxy(from, defaultVal, xType, out result);
            }

            return valueUpdated
                ? result
                : xTypeNullableFlag
                    ? default
                    : defaultVal;
        }

        private static bool FromStringToTypeProxy<X>(string from, X defaultVal, Type xType, out object result) {
            if (TypeHelper.IsNumericType(xType))
                return FromStringToNumericType(from, defaultVal, xType, out result);
            if (xType == TypeClass.GuidClass)
                return FromStringToGuid(from, defaultVal, out result);
            if (TypeHelper.IsDateTimeTypes(xType))
                return FromStringToDateTimeType(from, defaultVal, xType, out result);
            if (TypeHelper.IsEnumType(xType))
                return FromStringToEnum(from, defaultVal, out result);
            if (xType == TypeClass.ObjectClass) {
                result = defaultVal;
                return true;
            }

            object _ = default(X);
            result = from.Is(typeof(X), IgnoreCase.FALSE, t => _ = t) ? _ : defaultVal;
            return false;
        }

        private static bool FromStringToTypeProxy(string from, object defaultVal, Type xType, out object result) {
            if (TypeHelper.IsNumericType(xType))
                return FromStringToNumericType(from, defaultVal, xType, out result);
            if (xType == TypeClass.GuidClass)
                return FromStringToGuid(from, defaultVal, out result);
            if (TypeHelper.IsDateTimeTypes(xType))
                return FromStringToDateTimeType(from, defaultVal, xType, out result);
            if (TypeHelper.IsEnumType(xType))
                return FromStringToEnum(from, xType, defaultVal, out result);
            if (xType == TypeClass.ObjectClass) {
                result = from;
                return true;
            }

            var _ = TypeDefault.Of(xType);
            result = from.Is(xType, IgnoreCase.FALSE, t => _ = t) ? _ : defaultVal;
            return false;
        }

        private static bool FromStringToNullableTypeProxy(string from, Type xType, out object result) {
            var innerType = Nullable.GetUnderlyingType(xType);
            if (TypeHelper.IsNumericType(innerType))
                return FromStringToNullableNumericType(from, innerType, out result);
            if (innerType == TypeClass.GuidClass)
                return FromStringToNullableGuid(from, out result);
            if (TypeHelper.IsDateTimeTypes(innerType))
                return FromStringToNullableDateTimeType(from, innerType, out result);
            if (TypeHelper.IsEnumType(xType))
                return FromStringToNullableEnum(from, innerType, out result);
            if (innerType == TypeClass.ObjectClass) {
                result = from;
                return true;
            }

            var _ = TypeDefault.Of(xType);
            result = from.Is(xType, IgnoreCase.FALSE, t => _ = t) ? _ : null;
            return false;
        }
    }
}