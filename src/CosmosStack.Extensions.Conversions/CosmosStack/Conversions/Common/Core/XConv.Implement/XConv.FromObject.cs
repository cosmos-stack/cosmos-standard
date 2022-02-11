using System;
using System.Runtime.CompilerServices;
using CosmosStack.Conversions.ObjectMappingServices;
using CosmosStack.Reflection;

// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace CosmosStack.Conversions.Common.Core
{
    internal static partial class XConv
    {
        public static X FromObjTo<X>(object fromObj, CastingContext context, Type xType, bool xTypeNullableFlag, X defaultVal = default)
        {
            object result;

            var valueUpdated = xTypeNullableFlag 
                ? FromObjToNullableTypeProxy(fromObj, xType, out result) 
                : FromObjToTypeProxy(fromObj, defaultVal, xType, out result);

            if (valueUpdated)
            {
                return (X) result;
            }

            try
            {
                return Convert.ChangeType(fromObj, xType, context.FormatProvider).AsOrDefault(defaultVal);
            }
            catch
            {
                try
                {
                    return DefaultObjectMapper.Instance.MapTo<object, X>(fromObj);
                }
                catch
                {
                    return xTypeNullableFlag ? default : defaultVal;
                }
            }
        }

        public static object FromObjTo(object fromObj, Type oType, CastingContext context, Type xType, bool xTypeNullableFlag, object defaultVal = default)
        {
            object result;

            var valueUpdated = xTypeNullableFlag 
                ? FromObjToNullableTypeProxy(fromObj, xType, out result)
                : FromObjToTypeProxy(fromObj, defaultVal, xType, out result);

            if (valueUpdated)
            {
                return result;
            }

            try
            {
                return Convert.ChangeType(fromObj, xType, context.FormatProvider).AsOrDefault(defaultVal);
            }
            catch
            {
                try
                {
                    return DefaultObjectMapper.Instance.MapTo(oType, xType, fromObj);
                }
                catch
                {
                    return xTypeNullableFlag ? default : defaultVal;
                }
            }
        }

        private static bool FromObjToTypeProxy<X>(object fromObj, X defaultVal, Type xType, out object result)
        {
            if (TypeDeterminer.IsStringType(defaultVal, out var defaultStr))
            {
                result = StrConvX.ObjectSafeToString(fromObj, defaultStr);
                return true;
            }

            if (TypeDeterminer.IsNumericType(xType))
            {
                return FromObjToNumericType(fromObj, defaultVal, xType, out result);
            }

            if (TypeDeterminer.IsEnumType(xType))
            {
                result = EnumConvX.ObjToEnum(fromObj, xType, defaultVal);
                return true;
            }

            if (TypeDeterminer.IsDateTimeTypes(xType))
            {
                return FromObjToDateTime(fromObj, defaultVal, xType, out result);
            }

            if (defaultVal is Guid defaultGuid)
            {
                result = GuidConvX.ObjToGuid(fromObj, defaultGuid);
                return true;
            }
            
            if (TypeDeterminer.IsOriginObject(xType))
            {
                result = defaultVal;
                return true;
            }

            result = defaultVal;
            return false;
        }

        private static bool FromObjToTypeProxy(object fromObj, object defaultVal, Type xType, out object result)
        {
            if (TypeDeterminer.IsStringType(xType))
            {
                result = StrConvX.ObjectSafeToString(fromObj, StrConvX.ObjectSafeToString(defaultVal));
                return true;
            }

            if (TypeDeterminer.IsNumericType(xType))
            {
                return FromObjToNumericType(fromObj, defaultVal, xType, out result);
            }

            if (TypeDeterminer.IsEnumType(xType))
            {
                result = EnumConvX.ObjToEnum(fromObj, xType, defaultVal);
            }

            if (TypeDeterminer.IsDateTimeTypes(xType))
            {
                return FromObjToDateTime(fromObj, defaultVal, xType, out result);
            }

            if (TypeDeterminer.IsGuidType(xType))
            {
                result = GuidConvX.ObjToGuid(fromObj, GuidConvX.ObjToGuid(defaultVal));
                return true;
            }

            if (TypeDeterminer.IsOriginObject(xType))
            {
                result = fromObj;
                return true;
            }

            result = defaultVal;
            return false;
        }

        private static bool FromObjToNullableTypeProxy(object fromObj, Type xType, out object result)
        {
            var innerType = TypeConv.GetNonNullableType(xType);
            if (TypeDeterminer.IsStringType(innerType))
            {
                result = StrConvX.ObjectSafeToString(fromObj);
                return true;
            }

            if (TypeDeterminer.IsNumericType(innerType))
            {
                return FromObjToNullableNumericType(fromObj, innerType, out result);
            }

            if (TypeDeterminer.IsEnumType(innerType))
            {
                result = EnumConvX.ObjToNullableEnum(fromObj, innerType);
            }

            if (TypeDeterminer.IsDateTimeTypes(innerType))
            {
                return FromObjToNullableDateTimeType(fromObj, innerType, out result);
            }

            if (TypeDeterminer.IsGuidType(innerType))
            {
                result = GuidConvX.ObjToNullableGuid(fromObj);
                return true;
            }

            if (TypeDeterminer.IsOriginObject(innerType))
            {
                result = fromObj;
                return true;
            }

            result = null;
            return false;
        }
    }
}