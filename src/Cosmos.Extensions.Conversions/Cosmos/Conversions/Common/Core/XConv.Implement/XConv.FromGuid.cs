using System;
using Cosmos.Reflection;

// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Cosmos.Conversions.Common.Core
{
    internal static partial class XConv
    {
        public static X FromGuidTo<X>(Guid guid, CastingContext context, Type xType, bool xTypeNullableFlag, X defaultVal = default)
        {
            object result;

            var valueUpdated = xTypeNullableFlag 
                ? FromGuidToNullableTypeProxy(guid, context, xType, out result) 
                : FromGuidToTypeProxy(guid, defaultVal, context, xType, out result);

            return valueUpdated
                ? (X) result
                : xTypeNullableFlag
                    ? default
                    : defaultVal;
        }

        public static object FromGuidTo(Guid guid, CastingContext context, Type xType, bool xTypeNullableFlag, object defaultVal = default)
        {
            object result;

            var valueUpdated = xTypeNullableFlag 
                ? FromGuidToNullableTypeProxy(guid, context, xType, out result) 
                : FromGuidToTypeProxy(guid, defaultVal, context, xType, out result);

            return valueUpdated
                ? result
                : xTypeNullableFlag
                    ? default
                    : defaultVal;
        }

        public static X FromNullableGuidTo<X>(Guid? guid, CastingContext context, Type xType, bool xTypeNullableFlag, X defaultVal = default)
        {
            if (guid.HasValue)
            {
                return FromGuidTo(guid.Value, context, xType, xTypeNullableFlag, defaultVal);
            }

            return xTypeNullableFlag
                ? default
                : defaultVal;
        }

        public static object FromNullableGuidTo(Guid? guid, CastingContext context, Type xType, bool xTypeNullableFlag, object defaultVal = default)
        {
            if (guid.HasValue)
            {
                return FromGuidTo(guid.Value, context, xType, xTypeNullableFlag, defaultVal);
            }

            return xTypeNullableFlag
                ? default
                : defaultVal;
        }

        private static bool FromGuidToTypeProxy<X>(Guid from, X defaultVal, CastingContext context, Type xType, out object result)
        {
            if (defaultVal is string defaultStr)
                return FromGuidToString(from, context, defaultStr, out result);
            if (TypeDeterminer.IsOriginObject(xType))
            {
                result = from;
                return true;
            }

            result = defaultVal;
            return false;
        }

        private static bool FromGuidToTypeProxy(Guid from, object defaultVal, CastingContext context, Type xType, out object result)
        {
            if (defaultVal is string defaultStr)
                return FromGuidToString(from, context, defaultStr, out result);
            if (TypeDeterminer.IsOriginObject(xType))
            {
                result = from;
                return true;
            }

            result = defaultVal;
            return false;
        }

        private static bool FromGuidToNullableTypeProxy(Guid from, CastingContext context, Type xType, out object result)
        {
            var innerType = TypeConv.GetNonNullableType(xType);
            if (innerType == TypeClass.StringClazz)
                return FromGuidToString(from, context, string.Empty, out result);
            if (TypeDeterminer.IsOriginObject(innerType))
            {
                result = from;
                return true;
            }

            result = null;
            return false;
        }
    }
}