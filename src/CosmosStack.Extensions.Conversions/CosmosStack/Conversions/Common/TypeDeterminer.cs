using System;
using AspectCore.Extensions.Reflection;
using CosmosStack.Reflection;

namespace CosmosStack.Conversions.Common
{
    internal static class TypeDeterminer
    {
        public static object GetDefaultValue(Type type) => type.GetDefaultValue();

        public static bool IsNullableNumericType(Type type)
        {
            return Types.IsNullableType(type) &&
                   Types.IsNumericType(Nullable.GetUnderlyingType(type));
        }

        public static bool IsNumericType(Type type) => Types.IsNumericType(type);

        public static bool IsDateTimeTypes(Type type)
        {
            return type == TypeClass.DateTimeClazz
                || type == TypeClass.DateTimeOffsetClazz
                || type == TypeClass.TimeSpanClazz;
        }

        public static bool IsEnumType(Type type) => type.IsEnum;

        public static bool IsNullableGuidType(Type type) => Types.IsNullableType(type) && IsGuidType(Nullable.GetUnderlyingType(type));

        public static bool IsGuidType(Type type) => type == TypeClass.GuidClazz;

        public static bool IsStringType(Type type) => type == TypeClass.StringClazz;

        public static bool IsStringType(object that, out string ret)
        {
            if (that is string z)
            {
                ret = z;
                return true;
            }

            ret = default;
            return false;
        }

        public static bool IsOriginObject(Type type) => type == TypeClass.ObjectClazz;

        public static bool IsByteClass(Type type) => type == TypeClass.ByteClazz;
    }
}