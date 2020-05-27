using System;

// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Cosmos.Conversions.Core
{
    internal static partial class XConv
    {
        public static X FromDateTimeTo<X>(DateTime dateTime, CastingContext context, Type xType, bool xTypeNullableFlag, X defaultVal = default)
        {
            bool valueUpdated;
            object result;

            if (xTypeNullableFlag)
            {
                valueUpdated = FromDateTimeToNullableTypeProxy(dateTime, context, xType, out result);
            }
            else
            {
                valueUpdated = FromDateTimeToTypeProxy(dateTime, defaultVal, context, xType, out result);
            }

            return valueUpdated
                ? (X) result
                : xTypeNullableFlag
                    ? default
                    : defaultVal;
        }

        public static object FromDateTimeTo(DateTime dateTime, CastingContext context, Type xType, bool xTypeNullableFlag, object defaultVal = default)
        {
            bool valueUpdated;
            object result;

            if (xTypeNullableFlag)
            {
                valueUpdated = FromDateTimeToNullableTypeProxy(dateTime, context, xType, out result);
            }
            else
            {
                valueUpdated = FromDateTimeToTypeProxy(dateTime, defaultVal, context, xType, out result);
            }

            return valueUpdated
                ? result
                : xTypeNullableFlag
                    ? default
                    : defaultVal;
        }

        private static bool FromDateTimeToTypeProxy<X>(DateTime dateTime, X defaultVal, CastingContext context, Type xType, out object result)
        {
            if (defaultVal is string givenFormat)
                return FromDateTimeToString(dateTime, givenFormat, context, out result);
            if (TypeHelper.IsNumericType(xType))
                return FromDateTimeToNumericType(dateTime, defaultVal, xType, out result);
            if (xType == TypeClass.ObjectClass)
            {
                result = dateTime;
                return true;
            }

            result = defaultVal;
            return false;
        }

        private static bool FromDateTimeToTypeProxy(DateTime dateTime, object defaultVal, CastingContext context, Type xType, out object result)
        {
            if (defaultVal is string givenFormat)
                return FromDateTimeToString(dateTime, givenFormat, context, out result);
            if (TypeHelper.IsNumericType(xType))
                return FromDateTimeToNumericType(dateTime, defaultVal, xType, out result);
            if (xType == TypeClass.ObjectClass)
            {
                result = dateTime;
                return true;
            }

            result = defaultVal;
            return false;
        }

        private static bool FromDateTimeToNullableTypeProxy(DateTime dateTime, CastingContext context, Type xType, out object result)
        {
            var innerType = Nullable.GetUnderlyingType(xType);
            if (innerType == TypeClass.StringClass)
                return FromDateTimeToNullableString(dateTime, context, out result);
            if (TypeHelper.IsNumericType(innerType))
                return FromDateTimeToNullableNumericType(dateTime, innerType, out result);
            if (innerType == TypeClass.ObjectClass)
            {
                result = dateTime;
                return true;
            }

            result = null;
            return false;
        }
    }
}