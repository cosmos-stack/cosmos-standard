using System;
using System.Globalization;
using System.Net;
using System.Text;
using Cosmos.Conversions;
using Cosmos.Conversions.Core;
using Cosmos.Conversions.Determiners;
using Cosmos.Judgments;
using Cosmos.Numeric;

namespace Cosmos.Text
{
    /// <summary>
    /// Cosmos <see cref="string"/> extensions
    /// </summary>
    public static class CosmosStringExtensions
    {
        #region Is

        /// <summary>
        /// Determine whether the given string is char. <br />
        /// 判断给定的字符串是否是 char。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsChar(this string str) => StringCharDeterminer.Is(str);

        /// <summary>
        /// Determine whether the given string is boolean. <br />
        /// 判断给定的字符串是否是 boolean。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsBoolean(this string str) => StringBooleanDeterminer.Is(str);

        /// <summary>
        /// Determine whether the given string is <see cref="Encoding"/>. <br />
        /// 判断给定的字符串是否是 <see cref="Encoding"/>。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsEncoding(this string str) => StringEncodingDeterminer.Is(str);

        /// <summary>
        /// Determine whether the given string is a URL path. <br />
        /// 判断给定的字符串是否是 Url 路径。
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool IsWebUrl(this string target) => StringJudgment.IsWebUrl(target);

        /// <summary>
        /// Determine whether the given string is an email address. <br />
        /// 判断给定的字符串是否是电子邮件路径。
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static bool IsEmail(this string target) => StringJudgment.IsEmail(target);

        /// <summary>
        /// Determine whether the given string is a version number. <br />
        /// 判断给定的字符串是否是版本号。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsVersion(this string str) => StringVersionDeterminer.Is(str);

        /// <summary>
        /// Determine whether the given string is an IP address. <br />
        /// 判断给定的字符串是否是 IP 地址。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsIpAddress(this string str) => StringIpAddressDeterminer.Is(str);

        #endregion

        #region Is `0

        /// <summary>
        /// Determine whether the given string can be of the given type. <br />
        /// 判断给定的字符串是否能成为给定的类型。
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

            // ReSharper disable once InconsistentNaming
            void __unsupportedTypeCheck(Type t, out bool flag)
            {
                flag = typeof(Encoding).IsAssignableFrom(t);
                if (!t.IsValueType && !flag && t == typeof(Version) && t == typeof(IPAddress))
                    throw new ArgumentException("Unsupported type");
            }
        }

        #endregion

        #region Is `1

        /// <summary>
        /// Determine whether the given string can be of the given type. <br />
        /// 判断给定的字符串是否能成为给定的类型。
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
        public static bool Is<T>(this string str, IgnoreCase ignoreCase = IgnoreCase.FALSE, Action<T> action = null,
            string format = null, NumberStyles? numberStyle = null, DateTimeStyles? dateTimeStyle = null, IFormatProvider formatProvider = null) where T : struct
        {
            return str.Is(typeof(T), ignoreCase, ValueConverter.ConvertAct(action), format, numberStyle, dateTimeStyle, formatProvider);
        }

        /// <summary>
        /// Determine whether the given string can be of the given type. <br />
        /// 判断给定的字符串是否能成为给定的类型。
        /// </summary>
        /// <param name="str"></param>
        /// <param name="action"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool Is<T>(this string str, Action<T> action = null) where T : class =>
            str.Is(typeof(T), IgnoreCase.FALSE, o => action?.Invoke(o.As<T>()));

        #endregion

        #region Is DateTime

        /// <summary>
        /// Determine whether the given string is DateTime. <br />
        /// 判断给定的字符串是否为 DateTime。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsDateTime(this string str) => StringDateTimeDeterminer.Is(str);

        /// <summary>
        /// Determine whether the given string is DateTimeOffset. <br />
        /// 判断给定的字符串是否为 DateTimeOffset。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsDateTimeOffset(this string str) => StringDateTimeOffsetDeterminer.Is(str);

        /// <summary>
        /// Determine whether the given string is TimeSpan. <br />
        /// 判断给定的字符串是否为 TimeSpan。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsTimeSpan(this string str) => StringTimeSpanDeterminer.Is(str);

        /// <summary>
        /// Determine whether the given string is DateTime. <br />
        /// 判断给定的字符串是否为 DateTime。
        /// </summary>
        /// <param name="str"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static bool IsDateTimeExact(this string str, string format) => StringDateTimeDeterminer.Exact.Is(str, format);

        /// <summary>
        /// Determine whether the given string is DateTimeOffset. <br />
        /// 判断给定的字符串是否为 DateTimeOffset。
        /// </summary>
        /// <param name="str"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static bool IsDateTimeOffsetExact(this string str, string format) => StringDateTimeOffsetDeterminer.Exact.Is(str, format);

        /// <summary>
        /// Determine whether the given string is TimeSpan. <br />
        /// 判断给定的字符串是否为 TimeSpan。
        /// </summary>
        /// <param name="str"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static bool IsTimeSpanExact(this string str, string format) => StringTimeSpanDeterminer.Exact.Is(str, format);

        #endregion

        #region Is Enum

        /// <summary>
        /// Determine whether the given string is an enumeration of the specified type.<br />
        /// 判断给定的字符串是否为指定类型的枚举。
        /// </summary>
        /// <param name="str"></param>
        /// <param name="enumType"></param>
        /// <returns></returns>
        public static bool IsEnum(this string str, Type enumType) => StringEnumDeterminer.Is(str, enumType);

        /// <summary>
        /// Determine whether the given string is an enumeration of the specified type.<br />
        /// 判断给定的字符串是否为指定类型的枚举。
        /// </summary>
        /// <param name="str"></param>
        /// <typeparam name="TEnum"></typeparam>
        /// <returns></returns>
        public static bool IsEnum<TEnum>(this string str) where TEnum : struct => StringEnumDeterminer<TEnum>.Is(str);

        #endregion

        #region Is Guid

        /// <summary>
        /// Determine whether the given string is Guid. <br />
        /// 判断给定的字符串是否为 Guid。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsGuid(this string str) => StringGuidDeterminer.Is(str) && GuidJudgment.IsValid(str);

        /// <summary>
        /// Determine whether the given string is Guid. <br />
        /// 判断给定的字符串是否为 Guid。
        /// </summary>
        /// <param name="str"></param>
        /// <param name="format"></param>
        /// <returns></returns>
        public static bool IsGuidExact(this string str, string format) => StringGuidDeterminer.Exact.Is(str, format);

        #endregion

        #region Is Numeric

        /// <summary>
        /// Determine whether the given string is a numeric value. <br />
        /// 判断给定的字符串是否是数值。
        /// </summary>
        /// <param name="string"></param>
        /// <returns></returns>
        public static bool IsNumeric(this string @string) => NumericJudgment.IsNumeric(@string);

        /// <summary>
        /// Determine whether the given string is byte. <br />
        /// 判断给定的字符串是否是 byte。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsByte(this string str) => StringByteDeterminer.Is(str);

        /// <summary>
        /// Determine whether the given string is sbyte. <br />
        /// 判断给定的字符串是否是 sbyte。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsSByte(this string str) => StringSByteDeterminer.Is(str);

        /// <summary>
        /// Determine whether the given string is short. <br />
        /// 判断给定的字符串是否是 short。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsShort(this string str) => StringShortDeterminer.Is(str);

        /// <summary>
        /// Determine whether the given string is int. <br />
        /// 判断给定的字符串是否是 int。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsInt(this string str) => StringIntDeterminer.Is(str);

        /// <summary>
        /// Determine whether the given string is long. <br />
        /// 判断给定的字符串是否是 long。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsLong(this string str) => StringLongDeterminer.Is(str);

        /// <summary>
        /// Determine whether the given string is ushort. <br />
        /// 判断给定的字符串是否是 ushort。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsUShort(this string str) => StringUShortDeterminer.Is(str);

        /// <summary>
        /// Determine whether the given string is uint. <br />
        /// 判断给定的字符串是否是 uint。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsUInt(this string str) => StringUIntDeterminer.Is(str);

        /// <summary>
        /// Determine whether the given string is ulong. <br />
        /// 判断给定的字符串是否是 ulong。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsULong(this string str) => StringULongDeterminer.Is(str);

        /// <summary>
        /// Determine whether the given string is int16(short). <br />
        /// 判断给定的字符串是否是 int16(short)。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsInt16(this string str) => StringShortDeterminer.Is(str);

        /// <summary>
        /// Determine whether the given string is int32(int). <br />
        /// 判断给定的字符串是否是 int32(int)。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsInt32(this string str) => StringIntDeterminer.Is(str);

        /// <summary>
        /// Determine whether the given string is int64(long). <br />
        /// 判断给定的字符串是否是 int64(long)。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsInt64(this string str) => StringLongDeterminer.Is(str);

        /// <summary>
        /// Determine whether the given string is uint16(ushort). <br />
        /// 判断给定的字符串是否是 uint16(ushort)。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsUInt16(this string str) => StringUShortDeterminer.Is(str);

        /// <summary>
        /// Determine whether the given string is uint32(uint). <br />
        /// 判断给定的字符串是否是 uint32(uint)。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsUInt32(this string str) => StringUIntDeterminer.Is(str);

        /// <summary>
        /// Determine whether the given string is uint64(ulong). <br />
        /// 判断给定的字符串是否是 uint64(ulong)。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool UsUInt64(this string str) => StringULongDeterminer.Is(str);

        /// <summary>
        /// Determine whether the given string is float. <br />
        /// 判断给定的字符串是否是 float。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsFloat(this string str) => StringFloatDeterminer.Is(str);

        /// <summary>
        /// Determine whether the given string is double. <br />
        /// 判断给定的字符串是否是 double。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsDouble(this string str) => StringDoubleDeterminer.Is(str);

        /// <summary>
        /// Determine whether the given string is decimal. <br />
        /// 判断给定的字符串是否是 decimal。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool IsDecimal(this string str) => StringDecimalDeterminer.Is(str);

        #endregion

        #region Is Nullable

        /// <summary>
        /// Determine whether the given string is empty. If it is empty, perform the specified operation.<br />
        /// 判断给定的字符串是否为空。如果为空则执行指定的操作。
        /// </summary>
        /// <param name="s"></param>
        /// <param name="action">If the string is guessed to be empty by the string specifier, perform this operation.</param>
        /// <param name="isNullAction">If the string is empty, perform this operation.</param>
        /// <param name="ignoreCase"></param>
        /// <param name="format"></param>
        /// <param name="numberStyle"></param>
        /// <param name="dateTimeStyle"></param>
        /// <param name="provider"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsNullable<T>(
            this string s,
            Action<T> action = null,
            Action isNullAction = null,
            bool ignoreCase = false,
            string format = null,
            NumberStyles? numberStyle = null,
            DateTimeStyles? dateTimeStyle = null,
            IFormatProvider provider = null) where T : struct
        {
            return s is null && NullableFunc()(isNullAction)
                   || Is(s, ignoreCase.X(), action, format, numberStyle, dateTimeStyle, provider);
        }

        /// <summary>
        /// Determine whether the given string is empty. If it is empty, perform the specified operation.<br />
        /// 判断给定的字符串是否为空。如果为空则执行指定的操作。
        /// </summary>
        /// <param name="s"></param>
        /// <param name="type"></param>
        /// <param name="action">If the string is guessed to be empty by the string specifier, perform this operation.</param>
        /// <param name="isNullAction">If the string is empty, perform this operation.</param>
        /// <param name="ignoreCase"></param>
        /// <param name="format"></param>
        /// <param name="numberStyle"></param>
        /// <param name="dateTimeStyle"></param>
        /// <param name="provider"></param>
        /// <returns></returns>
        public static bool IsNullable(
            this string s,
            Type type,
            Action<object> action = null,
            Action isNullAction = null,
            bool ignoreCase = false,
            string format = null,
            NumberStyles? numberStyle = null,
            DateTimeStyles? dateTimeStyle = null,
            IFormatProvider provider = null)
        {
            return s is null && NullableFunc()(isNullAction)
                   || Is(s, type, ignoreCase.X(), action, format, numberStyle, dateTimeStyle, provider);
        }

        private static Func<Action, bool> NullableFunc() => act =>
        {
            act?.Invoke();
            return true;
        };

        #endregion
    }
}