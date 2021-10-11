using System;
using CosmosStack.Conversions.StringDeterminers;
using CosmosStack.Date;

namespace CosmosStack.Text
{
    /// <summary>
    /// CosmosStack <see cref="string"/> to <see cref="DateTime"/> extensions. <br />
    /// 字符串对日期时间转换扩展
    /// </summary>
    public static class StringDateTimeExtensions
    {
        /// <summary>
        /// Convert the given string to <see cref="DateInfo"/>. <br />
        /// 将给定的字符串转换为 <see cref="DateInfo"/>。
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static DateInfo CastToDateInfo(this string str, DateInfo defaultVal = default)
        {
            return StringDateInfoDeterminer.To(str, defaultVal: defaultVal);
        }

        /// <summary>
        /// Convert the given string to <see cref="DateTimeSpan"/>. <br />
        /// 将给定的字符串转换为 <see cref="DateTimeSpan"/>。
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static DateTimeSpan CastToDateTimeSpan(this string str, DateTimeSpan defaultVal = default)
        {
            return StringDateTimeSpanDeterminer.To(str, defaultVal: defaultVal);
        }

        /// <summary>
        /// Convert the given string to a nullable <see cref="DateTimeSpan"/>. <br />
        /// 将给定的字符串转换为可空的 <see cref="DateTimeSpan"/>。
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static DateTimeSpan? CastToNullableDateTimeSpan(this string str)
        {
            return StringDateTimeSpanDeterminer.Is(str)
                ? CastToDateTimeSpan(str)
                : (DateTimeSpan?)null;
        }
    }
}