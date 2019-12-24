using System;

namespace Cosmos.Optionals {
    /// <summary>
    /// Extensions for enum
    /// </summary>
    public static class EnumExtensions {
        /// <summary>
        /// Try parse
        /// </summary>
        /// <param name="value"></param>
        /// <param name="ignoreCase"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static Maybe<TEnum> TryParse<TEnum>(this string value, bool ignoreCase = false) where TEnum : struct {
            return Enum.TryParse(value, ignoreCase, out TEnum outValue) ? Optional.Some(outValue) : Optional.None<TEnum>();
        }
    }
}