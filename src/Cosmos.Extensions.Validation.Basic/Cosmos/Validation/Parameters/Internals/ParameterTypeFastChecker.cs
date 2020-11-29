using System;
using AspectCore.DynamicProxy.Parameters;
using Cosmos.Reflection;

namespace Cosmos.Validation.Parameters.Internals
{
    internal static class ParameterTypeFastChecker
    {
        public static ParameterTypeValidation IsIntType(this Parameter parameter)
        {
            return parameter._Is(TypeClass.IntClazz);
        }

        public static ParameterTypeValidation IsLongType(this Parameter parameter)
        {
            return parameter._Is(TypeClass.LongClazz);
        }

        public static ParameterTypeValidation IsFloatType(this Parameter parameter)
        {
            return parameter._Is(TypeClass.FloatClazz);
        }

        public static ParameterTypeValidation IsDoubleType(this Parameter parameter)
        {
            return parameter._Is(TypeClass.DoubleClazz);
        }

        public static ParameterTypeValidation IsDecimalType(this Parameter parameter)
        {
            return parameter._Is(TypeClass.DecimalClazz);
        }

        public static ParameterTypeValidation IsDateTimeType(this Parameter parameter)
        {
            return parameter._Is(TypeClass.DateTimeClazz);
        }

        public static ParameterTypeValidation IsTimeSpanType(this Parameter parameter)
        {
            return parameter._Is(TypeClass.TimeSpanClazz);
        }

        private static ParameterTypeValidation _Is(this Parameter parameter, Type targetType)
        {
            var parameterType = TypeConv.GetNonNullableType(parameter.Type);
            return new ParameterTypeValidation(parameterType.Is(targetType), parameterType);
        }
    }
}