using System;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class BaseTypeExtensions
    {
        public static void IfTrue(this bool @this, Action action)
        {
            if (@this)
            {
                action?.Invoke();
            }
        }

        public static void IfFalse(this bool @this, Action action)
        {
            if (!@this)
            {
                action?.Invoke();
            }
        }

        public static void Ifttt(this bool condition, Action @this, Action that)
        {
            if (condition)
            {
                @this?.Invoke();
            }
            else
            {
                that?.Invoke();
            }
        }

        public static TValue Ifttt<TValue>(this bool condition, Func<TValue> @this, Func<TValue> @that)
        {
            if (condition)
            {
                if (@this == null)
                    return default;
                return @this.Invoke();
            }
            else
            {
                if (that == null)
                    return default;
                return that.Invoke();
            }
        }


        public static byte ToBinary(this bool @this)
        {
            return Convert.ToByte(@this);
        }

        public static string ToString(this bool @this, string trueString, string falseString)
        {
            return @this ? trueString : falseString;
        }

        public static void IfNullOrWhiteSpace(this string @string, Action action)
        {
            if (string.IsNullOrWhiteSpace(@string))
            {
                action?.Invoke();
            }
        }

        public static void IfNotNullNorSpace(this string @string, Action action)
        {
            if (!string.IsNullOrWhiteSpace(@string))
            {
                action?.Invoke();
            }
        }
    }
}