using System;
using AspectCore.DynamicProxy.Parameters;
using Cosmos.Conversions;

namespace Cosmos.Validations.Parameters.Internals
{
    internal static class ParameterTypeFastChecker
    {
        public static ParameterTypeValidation IsIntType(this Parameter parameter)
        {
            return parameter._Is(TypeClass.IntClass);
        }

        public static ParameterTypeValidation IsLongType(this Parameter parameter)
        {
            return parameter._Is(TypeClass.LongClass);
        }

        public static ParameterTypeValidation IsFloatType(this Parameter parameter)
        {
            return parameter._Is(TypeClass.FloatClass);
        }

        public static ParameterTypeValidation IsDoubleType(this Parameter parameter)
        {
            return parameter._Is(TypeClass.DoubleClass);
        }

        public static ParameterTypeValidation IsDecimalType(this Parameter parameter)
        {
            return parameter._Is(TypeClass.DecimalClass);
        }

        public static ParameterTypeValidation IsDateTimeType(this Parameter parameter)
        {
            return parameter._Is(TypeClass.DateTimeClass);
        }

        public static ParameterTypeValidation IsTimeSpanType(this Parameter parameter)
        {
            return parameter._Is(TypeClass.TimeSpanClass);
        }

        private static ParameterTypeValidation _Is(this Parameter parameter, Type targetType)
        {
            var parameterType = TypeConverter.ToSafeNonNullableType(parameter.Type);
            return new ParameterTypeValidation(parameterType.Is(targetType), parameterType);
        }
    }
}