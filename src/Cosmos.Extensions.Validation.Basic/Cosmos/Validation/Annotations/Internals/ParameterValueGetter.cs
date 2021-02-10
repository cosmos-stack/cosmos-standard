using AspectCore.DynamicProxy.Parameters;

namespace Cosmos.Validation.Annotations.Internals
{
    internal static class ParameterValueGetter
    {
        public static TValue TryTo<TValue>(this Parameter parameter)
        {
            return parameter.TryTo(default(TValue));
        }

        public static TValue TryTo<TValue>(this decimal numericValue)
        {
            return numericValue.TryTo(default(TValue));
        }

        public static TValue TryTo<TValue>(this Parameter parameter, TValue defaultValue)
        {
            try
            {
                return parameter.Value.As<TValue>();
            }
            catch
            {
                return defaultValue;
            }
        }
        
        public static TValue TryTo<TValue>(this decimal numericValue, TValue defaultValue)
        {
            try
            {
                return numericValue.As<TValue>();
            }
            catch
            {
                return defaultValue;
            }
        }
    }
}