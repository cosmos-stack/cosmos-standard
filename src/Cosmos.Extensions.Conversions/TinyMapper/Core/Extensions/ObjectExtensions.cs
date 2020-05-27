using TinyMapper.Core.DataStructures;

namespace TinyMapper.Core.Extensions
{
    internal static class ObjectExtensions
    {
        public static bool IsNotNull(this object obj)
        {
            return obj != null;
        }

        public static bool IsNull(this object obj)
        {
            return obj == null;
        }

        public static Option<T> ToOption<T>(this T value)
        {
            if (Helpers.IsValueType(typeof(T)) == false && ReferenceEquals(value, null))
            {
                return Option<T>.Empty;
            }

            return new Option<T>(value);
        }

        public static Option<TResult> ToType<TResult>(this object obj)
        {
            if (obj is TResult result)
            {
                return new Option<TResult>(result);
            }

            return Option<TResult>.Empty;
        }
    }
}