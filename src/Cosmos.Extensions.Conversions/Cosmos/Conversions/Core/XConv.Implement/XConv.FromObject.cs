using System;

// ReSharper disable InconsistentNaming
// ReSharper disable once CheckNamespace
namespace Cosmos.Conversions.Core {
    internal static partial class XConv {
        public static X FromObjTo<X>(object fromObj, CastingContext context, Type xType, bool xTypeNullableFlag, X defaultVal = default) {
            bool valueUpdated;
            object result;

            if (xTypeNullableFlag) {
                valueUpdated = FromObjToNullableTypeProxy(fromObj, xType, out result);
            } else {
                valueUpdated = FromObjToTypeProxy(fromObj, defaultVal, xType, out result);
            }

            if (valueUpdated) {
                return (X) result;
            }

            try {
                return Convert.ChangeType(fromObj, xType, context.FormatProvider).AsOrDefault(defaultVal);
            } catch {
                try {
                    return Mapper.DefaultMapper.Instance.MapTo<object, X>(fromObj);
                } catch {
                    return xTypeNullableFlag ? default : defaultVal;
                }
            }
        }

        public static object FromObjTo(object fromObj, Type oType, CastingContext context, Type xType, bool xTypeNullableFlag, object defaultVal = default) {
            bool valueUpdated;
            object result;

            if (xTypeNullableFlag) {
                valueUpdated = FromObjToNullableTypeProxy(fromObj, xType, out result);
            } else {
                valueUpdated = FromObjToTypeProxy(fromObj, defaultVal, xType, out result);
            }

            if (valueUpdated) {
                return result;
            }

            try {
                return Convert.ChangeType(fromObj, xType, context.FormatProvider).AsOrDefault(defaultVal);
            } catch {
                try {
                    return Mapper.DefaultMapper.Instance.MapTo(oType, xType, fromObj);
                } catch {
                    return xTypeNullableFlag ? default : defaultVal;
                }
            }
        }

        private static bool FromObjToTypeProxy<X>(object fromObj, X defaultVal, Type xType, out object result) {
            if (defaultVal is string defaultStr) {
                result = StringConv.ObjectSafeToString(fromObj, defaultStr);
                return true;
            }

            if (TypeHelper.IsNumericType(xType)) {
                return FromObjToNumericType(fromObj, defaultVal, xType, out result);
            }

            if (TypeHelper.IsEnumType(xType)) {
                result = EnumConv.ObjToEnum(fromObj, xType, defaultVal);
                return true;
            }

            if (TypeHelper.IsDateTimeTypes(xType)) {
                return FromObjToDateTime(fromObj, defaultVal, xType, out result);
            }

            if (defaultVal is Guid defaultGuid) {
                result = GuidConv.ObjToGuid(fromObj, defaultGuid);
                return true;
            }

            if (xType == TypeClass.ObjectClass) {
                result = defaultVal;
                return true;
            }

            result = defaultVal;
            return false;
        }

        private static bool FromObjToTypeProxy(object fromObj, object defaultVal, Type xType, out object result) {
            if (xType == TypeClass.StringClass) {
                result = StringConv.ObjectSafeToString(fromObj, StringConv.ObjectSafeToString(defaultVal));
                return true;
            }

            if (TypeHelper.IsNumericType(xType)) {
                return FromObjToNumericType(fromObj, defaultVal, xType, out result);
            }

            if (TypeHelper.IsEnumType(xType)) {
                result = EnumConv.ObjToEnum(fromObj, xType, defaultVal);
            }

            if (TypeHelper.IsDateTimeTypes(xType)) {
                return FromObjToDateTime(fromObj, defaultVal, xType, out result);
            }

            if (TypeHelper.IsGuidType(xType)) {
                result = GuidConv.ObjToGuid(fromObj, GuidConv.ObjToGuid(defaultVal));
                return true;
            }

            if (xType == TypeClass.ObjectClass) {
                result = fromObj;
                return true;
            }

            result = defaultVal;
            return false;
        }

        private static bool FromObjToNullableTypeProxy(object fromObj, Type xType, out object result) {
            var innerType = Nullable.GetUnderlyingType(xType);
            if (innerType == TypeClass.StringClass) {
                result = StringConv.ObjectSafeToString(fromObj);
                return true;
            }

            if (TypeHelper.IsNumericType(xType)) {
                return FromObjToNullableNumericType(fromObj, xType, out result);
            }

            if (TypeHelper.IsEnumType(innerType)) {
                result = EnumConv.ObjToNullableEnum(fromObj, innerType);
            }

            if (TypeHelper.IsDateTimeTypes(innerType)) {
                return FromObjToNullableDateTimeType(fromObj, innerType, out result);
            }

            if (TypeHelper.IsGuidType(innerType)) {
                result = GuidConv.ObjToNullableGuid(fromObj);
                return true;
            }

            if (innerType == TypeClass.ObjectClass) {
                result = fromObj;
                return true;
            }

            result = null;
            return false;
        }
    }
}