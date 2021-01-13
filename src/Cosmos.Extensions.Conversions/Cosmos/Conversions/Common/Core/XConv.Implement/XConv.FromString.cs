using System;
using Cosmos.Reflection;
using Cosmos.Text;

// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Cosmos.Conversions.Common.Core
{
    internal static partial class XConv
    {
        public static X FromStringTo<X>(string @from, Type xType, bool xTypeNullableFlag, X defaultVal = default)
        {
            bool valueUpdated;
            object result;

            if (xTypeNullableFlag)
            {
                valueUpdated = FromStringToNullableTypeProxy(from, xType, out result);
            }
            else
            {
                valueUpdated = FromStringToTypeProxy(from, defaultVal, xType, out result);
            }

            return valueUpdated
                ? (X) result
                : xTypeNullableFlag
                    ? default
                    : defaultVal;
        }

        public static object FromStringTo(string @from, Type xType, bool xTypeNullableFlag, object defaultVal = default)
        {
            bool valueUpdated;
            object result;

            if (xTypeNullableFlag)
            {
                valueUpdated = FromStringToNullableTypeProxy(from, xType, out result);
            }
            else
            {
                valueUpdated = FromStringToTypeProxy(from, defaultVal, xType, out result);
            }

            return valueUpdated
                ? result
                : xTypeNullableFlag
                    ? default
                    : defaultVal;
        }

        private static bool FromStringToTypeProxy<X>(string from, X defaultVal, Type xType, out object result)
        {
            if (TypeDeterminer.IsNumericType(xType))
                return FromStringToNumericType(from, defaultVal, xType, out result);
            if (TypeDeterminer.IsGuidType(xType))
                return FromStringToGuid(from, defaultVal, out result);
            if (TypeDeterminer.IsDateTimeTypes(xType))
                return FromStringToDateTimeType(from, defaultVal, xType, out result);
            if (TypeDeterminer.IsEnumType(xType))
                return FromStringToEnum(from, defaultVal, out result);
            if (TypeDeterminer.IsOriginObject(xType))
            {
                result = defaultVal;
                return true;
            }

            object _ = default(X);
            result = from.Is(typeof(X), t => _ = t) ? _ : defaultVal;
            return false;
        }

        private static bool FromStringToTypeProxy(string from, object defaultVal, Type xType, out object result)
        {
            if (TypeDeterminer.IsNumericType(xType))
                return FromStringToNumericType(from, defaultVal, xType, out result);
            if (TypeDeterminer.IsGuidType(xType))
                return FromStringToGuid(from, defaultVal, out result);
            if (TypeDeterminer.IsDateTimeTypes(xType))
                return FromStringToDateTimeType(from, defaultVal, xType, out result);
            if (TypeDeterminer.IsEnumType(xType))
                return FromStringToEnum(from, xType, defaultVal, out result);
            if (TypeDeterminer.IsOriginObject(xType))
            {
                result = from;
                return true;
            }

            var _ = TypeDeterminer.GetDefaultValue(xType);
            result = from.Is(xType, t => _ = t) ? _ : defaultVal;
            return false;
        }

        private static bool FromStringToNullableTypeProxy(string from, Type xType, out object result)
        {
            var innerType = Nullable.GetUnderlyingType(xType);
            if (TypeDeterminer.IsNumericType(innerType))
                return FromStringToNullableNumericType(from, innerType, out result);
            if (TypeDeterminer.IsGuidType(innerType))
                return FromStringToNullableGuid(from, out result);
            if (TypeDeterminer.IsDateTimeTypes(innerType))
                return FromStringToNullableDateTimeType(from, innerType, out result);
            if (TypeDeterminer.IsEnumType(xType))
                return FromStringToNullableEnum(from, innerType, out result);
            if (TypeDeterminer.IsOriginObject(innerType))
            {
                result = from;
                return true;
            }

            var _ = TypeDeterminer.GetDefaultValue(xType);
            result = from.Is(xType, t => _ = t) ? _ : null;
            return false;
        }
    }
}