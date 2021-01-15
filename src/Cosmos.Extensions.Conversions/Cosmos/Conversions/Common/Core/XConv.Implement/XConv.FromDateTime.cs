using System;
using Cosmos.Reflection;

// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Cosmos.Conversions.Common.Core
{
    internal static partial class XConv
    {
        public static X FromDateTimeTo<X>(DateTime dateTime, CastingContext context, Type xType, bool xTypeNullableFlag, X defaultVal = default)
        {
            object result;

            var valueUpdated = xTypeNullableFlag 
                ? FromDateTimeToNullableTypeProxy(dateTime, context, xType, out result) 
                : FromDateTimeToTypeProxy(dateTime, defaultVal, context, xType, out result);

            return valueUpdated
                ? (X) result
                : xTypeNullableFlag
                    ? default
                    : defaultVal;
        }

        public static object FromDateTimeTo(DateTime dateTime, CastingContext context, Type xType, bool xTypeNullableFlag, object defaultVal = default)
        {
            object result;

            var valueUpdated = xTypeNullableFlag 
                ? FromDateTimeToNullableTypeProxy(dateTime, context, xType, out result)
                : FromDateTimeToTypeProxy(dateTime, defaultVal, context, xType, out result);

            return valueUpdated
                ? result
                : xTypeNullableFlag
                    ? default
                    : defaultVal;
        }

        private static bool FromDateTimeToTypeProxy<X>(DateTime dateTime, X defaultVal, CastingContext context, Type xType, out object result)
        {
            if (TypeDeterminer.IsStringType(defaultVal, out var givenFormat))
                return FromDateTimeToString(dateTime, givenFormat, context, out result);
            if (TypeDeterminer.IsNumericType(xType))
                return FromDateTimeToNumericType(dateTime, defaultVal, xType, out result);
            if (TypeDeterminer.IsOriginObject(xType))
            {
                result = dateTime;
                return true;
            }

            result = defaultVal;
            return false;
        }

        private static bool FromDateTimeToTypeProxy(DateTime dateTime, object defaultVal, CastingContext context, Type xType, out object result)
        {
            if (TypeDeterminer.IsStringType(defaultVal, out var givenFormat))
                return FromDateTimeToString(dateTime, givenFormat, context, out result);
            if (TypeDeterminer.IsNumericType(xType))
                return FromDateTimeToNumericType(dateTime, defaultVal, xType, out result);
            if (TypeDeterminer.IsOriginObject(xType))
            {
                result = dateTime;
                return true;
            }

            result = defaultVal;
            return false;
        }

        private static bool FromDateTimeToNullableTypeProxy(DateTime dateTime, CastingContext context, Type xType, out object result)
        {
            var innerType = TypeConv.GetNonNullableType(xType);
            if (TypeDeterminer.IsStringType(innerType))
                return FromDateTimeToNullableString(dateTime, context, out result);
            if (TypeDeterminer.IsNumericType(innerType))
                return FromDateTimeToNullableNumericType(dateTime, innerType, out result);
            if (TypeDeterminer.IsOriginObject(innerType))
            {
                result = dateTime;
                return true;
            }

            result = null;
            return false;
        }
    }
}