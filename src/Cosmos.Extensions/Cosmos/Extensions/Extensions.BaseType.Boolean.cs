using System;

// ReSharper disable once CheckNamespace
namespace Cosmos {
    public static partial class BaseTypeExtensions {
        /// <summary>
        /// If true...
        /// </summary>
        /// <param name="this"></param>
        /// <param name="action"></param>
        public static void IfTrue(this bool @this, Action action) {
            if (@this) {
                action?.Invoke();
            }
        }

        /// <summary>
        /// If false...
        /// </summary>
        /// <param name="this"></param>
        /// <param name="action"></param>
        public static void IfFalse(this bool @this, Action action) {
            if (!@this) {
                action?.Invoke();
            }
        }

        /// <summary>
        /// If this then that...
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="this"></param>
        /// <param name="that"></param>
        public static void Ifttt(this bool condition, Action @this, Action that) {
            if (condition) {
                @this?.Invoke();
            }
            else {
                that?.Invoke();
            }
        }

        /// <summary>
        /// If this then that...
        /// </summary>
        /// <typeparam name="TValue"></typeparam>
        /// <param name="condition"></param>
        /// <param name="this"></param>
        /// <param name="that"></param>
        /// <returns></returns>
        public static TValue Ifttt<TValue>(this bool condition, Func<TValue> @this, Func<TValue> @that) {
            if (condition) {
                if (@this == null)
                    return default;
                return @this.Invoke();
            }
            else {
                if (that == null)
                    return default;
                return that.Invoke();
            }
        }

        /// <summary>
        /// Is binary
        /// </summary>
        /// <param name="this"></param>
        /// <returns></returns>
        public static byte ToBinary(this bool @this) {
            return Convert.ToByte(@this);
        }

        /// <summary>
        /// If true then this, else that...
        /// </summary>
        /// <param name="this"></param>
        /// <param name="trueString"></param>
        /// <param name="falseString"></param>
        /// <returns></returns>
        public static string ToString(this bool @this, string trueString, string falseString) {
            return @this ? trueString : falseString;
        }

        /// <summary>
        /// If null or whitespace then...
        /// </summary>
        /// <param name="string"></param>
        /// <param name="action"></param>
        public static void IfNullOrWhiteSpace(this string @string, Action action) {
            if (string.IsNullOrWhiteSpace(@string)) {
                action?.Invoke();
            }
        }

        /// <summary>
        /// If not null nor whitespace then...
        /// </summary>
        /// <param name="string"></param>
        /// <param name="action"></param>
        public static void IfNotNullNorSpace(this string @string, Action action) {
            if (!string.IsNullOrWhiteSpace(@string)) {
                action?.Invoke();
            }
        }
    }
}