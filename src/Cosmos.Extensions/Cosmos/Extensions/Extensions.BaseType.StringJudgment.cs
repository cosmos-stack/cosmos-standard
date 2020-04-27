using System;
using System.Globalization;
using System.Net;
using System.Text;
using Cosmos.Conversions;
using Cosmos.Conversions.Internals;
using Cosmos.Conversions.StringDeterminers;
using Cosmos.Judgments;

// ReSharper disable once CheckNamespace
namespace Cosmos {
    /// <summary>
    /// String extensions
    /// </summary>
    public static partial class StringExtensions {

        /// <summary>
        /// Is
        /// </summary>
        /// <param name="str"></param>
        /// <param name="action"></param>
        /// <param name="ignoreCase"></param>
        /// <param name="format"></param>
        /// <param name="numberStyle"></param>
        /// <param name="dateTimeStyle"></param>
        /// <param name="formatProvider"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool Is<T>(
            this string str,
            IgnoreCase ignoreCase = IgnoreCase.FALSE,
            Action<T> action = null,
            string format = null,
            NumberStyles? numberStyle = null,
            DateTimeStyles? dateTimeStyle = null,
            IFormatProvider formatProvider = null) where T : struct {
            return str.Is(
                typeof(T),
                ignoreCase,
                _Helper.ConvertAct(action),
                format,
                numberStyle,
                dateTimeStyle,
                formatProvider);
        }

        /// <summary>
        /// Is
        /// </summary>
        /// <param name="str"></param>
        /// <param name="action"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool Is<T>(this string str, Action<T> action = null) where T : class => str.Is(typeof(T), IgnoreCase.FALSE, o => action?.Invoke(o.As<T>()));

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
        public static bool Is(
            this string s,
            Type type,
            IgnoreCase ignoreCase = IgnoreCase.FALSE,
            Action<object> action = null,
            string format = null,
            NumberStyles? numberStyle = null,
            DateTimeStyles? dateTimeStyle = null,
            IFormatProvider provider = null) {

            if (type is null) {
                throw new ArgumentNullException(nameof(type));
            }

            var typeIsAssignableFromEncoding = typeof(Encoding).IsAssignableFrom(type);

            if (!type.IsValueType &&
                type == typeof(Version) &&
                type == typeof(IPAddress) &&
                !typeIsAssignableFromEncoding) {
                throw new ArgumentException("Unsupported type");
            }

            return type.IsEnum && StringEnumDeterminer.Is(s, type, ignoreCase.X(), action) ||
                   type == typeof(byte) && StringByteDeterminer.Is(s, numberStyle ?? NumberStyles.Integer, provider, _Helper.ConvertAct<byte>(action)) ||
                   type == typeof(sbyte) && StringSByteDeterminer.Is(s, numberStyle ?? NumberStyles.Integer, provider, _Helper.ConvertAct<sbyte>(action)) ||
                   type == typeof(char) && StringCharDeterminer.Is(s, _Helper.ConvertAct<char>(action)) ||
                   type == typeof(short) && StringShortDeterminer.Is(s, numberStyle ?? NumberStyles.Integer, provider, _Helper.ConvertAct<short>(action)) ||
                   type == typeof(ushort) && StringUShortDeterminer.Is(s, numberStyle ?? NumberStyles.Integer, provider, _Helper.ConvertAct<ushort>(action)) ||
                   type == typeof(int) && StringIntDeterminer.Is(s, numberStyle ?? NumberStyles.Integer, provider, _Helper.ConvertAct<int>(action)) ||
                   type == typeof(uint) && StringUIntDeterminer.Is(s, numberStyle ?? NumberStyles.Integer, provider, _Helper.ConvertAct<uint>(action)) ||
                   type == typeof(long) && StringLongDeterminer.Is(s, numberStyle ?? NumberStyles.Integer, provider, _Helper.ConvertAct<long>(action)) ||
                   type == typeof(ulong) && StringULongDeterminer.Is(s, numberStyle ?? NumberStyles.Integer, provider, _Helper.ConvertAct<ulong>(action)) ||
                   type == typeof(float) && StringFloatDeterminer.Is(s, numberStyle ?? NumberStyle, provider, _Helper.ConvertAct<float>(action)) ||
                   type == typeof(double) && StringDoubleDeterminer.Is(s, numberStyle ?? NumberStyle, provider, _Helper.ConvertAct<double>(action)) ||
                   type == typeof(decimal) && StringDecimalDeterminer.Is(s, numberStyle ?? NumberStyles.Number, provider, _Helper.ConvertAct<decimal>(action)) ||
                   type == typeof(bool) && StringBooleanDeterminer.Is(s, _Helper.ConvertAct<bool>(action)) ||
                   type == typeof(DateTime) && (format is null
                       ? StringDateTimeDeterminer.Is(s, dateTimeStyle ?? DateTimeStyles.None, provider, _Helper.ConvertAct<DateTime>(action))
                       : StringDateTimeDeterminer.Exact.Is(s, format, dateTimeStyle ?? DateTimeStyles.None, provider, _Helper.ConvertAct<DateTime>(action))) ||
                   type == typeof(DateTimeOffset) && (format is null
                       ? StringDateTimeOffsetDeterminer.Is(s, dateTimeStyle ?? DateTimeStyles.None, provider, _Helper.ConvertAct<DateTimeOffset>(action))
                       : StringDateTimeOffsetDeterminer.Exact.Is(s, format, dateTimeStyle ?? DateTimeStyles.None, provider, _Helper.ConvertAct<DateTimeOffset>(action))) ||
                   type == typeof(TimeSpan) && (format is null
                       ? StringTimeSpanDeterminer.Is(s, provider, _Helper.ConvertAct<TimeSpan>(action))
                       : StringTimeSpanDeterminer.Exact.Is(s, format, provider, _Helper.ConvertAct<TimeSpan>(action))) ||
                   type == typeof(Guid) && (format is null
                       ? StringGuidDeterminer.Is(s, _Helper.ConvertAct<Guid>(action))
                       : StringGuidDeterminer.Exact.Is(s, format, _Helper.ConvertAct<Guid>(action))) ||
                   type == typeof(Version) && StringVersionDeterminer.Is(s, action) ||
                   type == typeof(IPAddress) && StringIpAddressDeterminer.Is(s, action) ||
                   typeIsAssignableFromEncoding && StringEncodingDeterminer.Is(s, action);
        }

        private static NumberStyles NumberStyle = NumberStyles.AllowLeadingWhite | NumberStyles.AllowTrailingWhite | NumberStyles.AllowLeadingSign |
                                                  NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands | NumberStyles.AllowExponent;

        /// <summary>
        /// Is nullable
        /// </summary>
        /// <param name="s"></param>
        /// <param name="action"></param>
        /// <param name="isNullAction"></param>
        /// <param name="ignoreCase"></param>
        /// <param name="format"></param>
        /// <param name="numberStyle"></param>
        /// <param name="dateTimeStyle"></param>
        /// <param name="provider"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsNullable<T>(this string s, Action<T> action = null, Action isNullAction = null, bool ignoreCase = false, string format = null,
            NumberStyles? numberStyle = null, DateTimeStyles? dateTimeStyle = null, IFormatProvider provider = null) where T : struct {
            return (s == null && NullableFunc()(isNullAction)) || Is(s, ignoreCase.X(), action, format, numberStyle, dateTimeStyle, provider);
        }

        /// <summary>
        /// Is nullable
        /// </summary>
        /// <param name="s"></param>
        /// <param name="type"></param>
        /// <param name="action"></param>
        /// <param name="isNullAction"></param>
        /// <param name="ignoreCase"></param>
        /// <param name="format"></param>
        /// <param name="numberStyle"></param>
        /// <param name="dateTimeStyle"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static bool IsNullable(this string s, Type type, Action<object> action = null, Action isNullAction = null, bool ignoreCase = false, string format = null,
            NumberStyles? numberStyle = null, DateTimeStyles? dateTimeStyle = null, IFormatProvider provider = null) {
            return (s == null && NullableFunc()(isNullAction)) || Is(s, type, ignoreCase.X(), action, format, numberStyle, dateTimeStyle, provider);
        }

        private static Func<Action, bool> NullableFunc() => act => {
            act?.Invoke();
            return true;
        };

        /// <summary>
        /// 检查字符串是 null 还是 System.String.Empty 字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string str) => string.IsNullOrEmpty(str);

        /// <summary>
        /// 检查字符串不是 null 或 System.String.Empty 字符串
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNotNullNorEmpty(this string str) => !str.IsNullOrEmpty();

        /// <summary>
        /// 检查字符串是 null、空还是仅由空白字符组成
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string str) => string.IsNullOrWhiteSpace(str);

        /// <summary>
        /// 检查字符串不是 null、空或由空白字符串组成
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsNotNullNorWhiteSpace(this string str) => !str.IsNullOrWhiteSpace();

        /// <summary>
        /// Is char
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsChar(this string str) => StringCharDeterminer.Is(str);

        /// <summary>
        /// Is boolean
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsBoolean(this string str) => StringBooleanDeterminer.Is(str);

        /// <summary>
        /// Is encoding
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsEncoding(this string str) => StringEncodingDeterminer.Is(str);

        /// <summary>
        /// 判断是否为 Url 路径
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool IsWebUrl(this string target) => StringJudgment.IsWebUrl(target);

        /// <summary>
        /// 判断是否为 Email 地址
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool IsEmail(this string target) => StringJudgment.IsEmail(target);

        /// <summary>
        /// Is version
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsVersion(this string str) => StringVersionDeterminer.Is(str);

        /// <summary>
        /// Is IpAddress
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsIpAddress(this string str) => StringIpAddressDeterminer.Is(str);

        /// <summary>
        /// One Absent Char
        /// </summary>
        /// <param name="text"></param>
        /// <param name="toCheck"></param>
        /// <returns></returns>
        public static bool OneAbsentChar(this string text, string toCheck) {
            if (text.Length > 1
             && toCheck.Length > 1
             && Math.Abs(text.Length - toCheck.Length) != 1) //las long deben diferir en 1, y ambas ser mayor que 1
                return false;

            var textWithChar = (text.Length > toCheck.Length ? text : toCheck);
            var textNoChar = (text.Length > toCheck.Length ? toCheck : text);

            //chequear si es el ultimo
            if (textWithChar[textWithChar.Length - 1] != textNoChar[textNoChar.Length - 1])
                return textWithChar.Substring(0, textWithChar.Length - 1).EqualsIgnoreCase(textNoChar);

            for (int i = 0; i < textNoChar.Length; i++) {
                if (textWithChar[i] != textNoChar[i]) {
                    //a partir del car distinto, el resto debe coincidir
                    return textWithChar.Substring(i + 1).EqualsIgnoreCase(textNoChar.Substring(i));
                }
            }

            return false;
        }
    }
}