using System;

// ReSharper disable UnusedParameter.Local
// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Cosmos.Conversions.Common.Core
{
    internal static partial class XConv
    {
        public static X FromEnumTo<X>(Type enumType, object enumVal, CastingContext context, Type xType, bool xTypeNullableFlag, X defaultVal = default)
        {
            bool valueUpdated;
            object result;

            if (xTypeNullableFlag)
            {
                valueUpdated = FromEnumToNullableTypeProxy(enumType, enumVal, context, xType, out result);
            }
            else
            {
                valueUpdated = FromEnumToTypeProxy(enumType, enumVal, defaultVal, context, xType, out result);
            }

            return valueUpdated
                ? (X) result
                : xTypeNullableFlag
                    ? default
                    : defaultVal;
        }

        public static object FromEnumTo(Type enumType, object enumVal, CastingContext context, Type xType, bool xTypeNullableFlag, object defaultVal = default)
        {
            bool valueUpdated;
            object result;

            if (xTypeNullableFlag)
            {
                valueUpdated = FromEnumToNullableTypeProxy(enumType, enumVal, context, xType, out result);
            }
            else
            {
                valueUpdated = FromEnumToTypeProxy(enumType, enumVal, defaultVal, context, xType, out result);
            }

            return valueUpdated
                ? result
                : xTypeNullableFlag
                    ? default
                    : defaultVal;
        }

        private static bool FromEnumToTypeProxy<X>(Type enumType, object enumVal, X defaultVal, CastingContext context, Type xType, out object result)
        {
            if (TypeDeterminer.IsStringType(defaultVal, out var defaultStr))
                return FromEnumToString(enumType, enumVal, defaultStr, out result);
            if (TypeDeterminer.IsNumericType(xType))
                return FromEnumToNumericType(enumType, enumVal, defaultVal, xType, out result);
            if (TypeDeterminer.IsOriginObject(xType))
            {
                result = enumVal;
                return true;
            }

            result = defaultVal;
            return false;
        }

        private static bool FromEnumToTypeProxy(Type enumType, object enumVal, object defaultVal, CastingContext context, Type xType, out object result)
        {
            if (TypeDeterminer.IsStringType(defaultVal, out var defaultStr))
                return FromEnumToString(enumType, enumVal, defaultStr, out result);
            if (TypeDeterminer.IsNumericType(xType))
                return FromEnumToNumericType(enumType, enumVal, defaultVal, xType, out result);
            if (TypeDeterminer.IsOriginObject(xType))
            {
                result = enumVal;
                return true;
            }

            result = defaultVal;
            return false;
        }

        private static bool FromEnumToNullableTypeProxy(Type enumType, object enumVal, CastingContext context, Type xType, out object result)
        {
            var innerType = Nullable.GetUnderlyingType(xType);
            if (TypeDeterminer.IsNumericType(innerType))
                return FromEnumToNullableNumericType(enumType, enumVal, innerType, out result);
            if (TypeDeterminer.IsStringType(innerType))
                return FromEnumToString(enumType, enumVal, "", out result);
            if (TypeDeterminer.IsOriginObject(innerType))
            {
                result = enumVal;
                return true;
            }

            result = null;
            return false;
        }
    }
}