using System;
using AspectCore.Extensions.Reflection;
using Cosmos.Judgments;
using Cosmos.Reflection;

namespace Cosmos.Conversions.Core
{
    internal static class TypeHelper
    {
        public static object GetDefaultValue(Type type)
        {
            return type.GetDefaultValue();
        }

        public static bool IsNumericType(Type type) =>
            type == TypeClass.ByteClass
         || type == TypeClass.Int16Class
         || type == TypeClass.Int32Class
         || type == TypeClass.Int64Class
         || type == TypeClass.SByteClass
         || type == TypeClass.UInt16Class
         || type == TypeClass.UInt32Class
         || type == TypeClass.UInt64Class
         || type == TypeClass.DecimalClass
         || type == TypeClass.DoubleClass
         || type == TypeClass.FloatClass;

        public static bool IsNullableNumericType(Type type)
        {
            return TypeJudgment.IsNullableType(type) && IsNumericType(Nullable.GetUnderlyingType(type));
        }

        public static bool IsDateTimeTypes(Type type)
        {
            return type == TypeClass.DateTimeClass
                || type == TypeClass.DateTimeOffsetClass
                || type == TypeClass.TimeSpanClass;
        }

        public static bool IsEnumType(Type type)
        {
            return type.IsEnum;
        }

        public static bool IsNullableGuidType(Type type)
        {
            return TypeJudgment.IsNullableType(type) && IsGuidType(Nullable.GetUnderlyingType(type));
        }

        public static bool IsGuidType(Type type)
        {
            return type == TypeClass.GuidClass;
        }
    }
}