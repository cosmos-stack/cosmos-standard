using System;
using System.Globalization;
using System.Net;
using System.Text;
using Cosmos.Conversions;
using Cosmos.Conversions.Core;

// ReSharper disable once CheckNamespace
namespace Cosmos.Text
{
    /// <summary>
    /// String determiner extensions
    /// </summary>
    public static partial class StringDeterminerExtensions
    {
        /// <summary>
        /// Is
        /// </summary>
        /// <param name="s"></param>
        /// <param name="type"></param>
        /// <param name="action"></param>
        /// <param name="ignoreCase"></param>
        /// <param name="format"></param>
        /// <param name="numberStyle"></param>
        /// <param name="dateTimeStyle"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static bool Is(this string s, Type type, IgnoreCase ignoreCase = IgnoreCase.FALSE, Action<object> action = null,
            string format = null, NumberStyles? numberStyle = null, DateTimeStyles? dateTimeStyle = null, IFormatProvider provider = null)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));

            __unsupportedTypeCheck(type, out var typeIsAssignableFromEncoding);

            return TypeIs.__enumIs(s, type, action, ignoreCase)
                || TypeIs.__charIs(s, type, action)
                || TypeIs.__numericIs(s, type, action, numberStyle, provider)
                || TypeIs.__booleanIs(s, type, action)
                || TypeIs.__dateTimeIs(s, type, action, format, dateTimeStyle, provider)
                || TypeIs.__dateTimeOffsetIs(s, type, action, format, dateTimeStyle, provider)
                || TypeIs.__timeSpanIs(s, type, action, format, provider)
                || TypeIs.__guidIs(s, type, action, format)
                || TypeIs.__versionIs(s, type, action)
                || TypeIs.__ipAddressIs(s, type, action)
                || TypeIs.__encodingIs(s, action, typeIsAssignableFromEncoding);

            void __unsupportedTypeCheck(Type t, out bool flag)
            {
                flag = typeof(Encoding).IsAssignableFrom(t);
                if (!t.IsValueType && !flag && t == typeof(Version) && t == typeof(IPAddress))
                    throw new ArgumentException("Unsupported type");
            }
        }
    }
}