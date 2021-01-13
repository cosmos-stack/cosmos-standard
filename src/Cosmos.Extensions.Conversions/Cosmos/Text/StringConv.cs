using System;
using Cosmos.Conversions;
using Cosmos.Conversions.Common.Core;

namespace Cosmos.Text
{
    internal static class IgnoreCaseExtensions
    {
        public static bool X(this IgnoreCase ignoreCase)
        {
            return ignoreCase switch
            {
                IgnoreCase.TRUE => true,
                IgnoreCase.FALSE => false,
                _ => false
            };
        }

        public static IgnoreCase X(this bool b)
        {
            return b switch
            {
                true => IgnoreCase.TRUE,
                false => IgnoreCase.FALSE
            };
        }
    }
    
    /// <summary>
    /// Object converter
    /// </summary>
    public static partial class StringConv
    {
        #region Object

        /// <summary>
        /// Convert <see cref="object"/> to <see cref="string"/> safety.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static string ToString(object obj, string defaultVal = default)
        {
            return StrConvX.ObjectSafeToString(obj, defaultVal);
        }

        #endregion
    }

    /// <summary>
    /// Cosmos <see cref="string"/> casting extensions.
    /// </summary>
    public static partial class StringConvExtensions
    {
        #region Cast Object to String

        /// <summary>
        /// Cast <see cref="object"/> to <see cref="string"/>. <br />
        /// 将对象 <see cref="object"/> 转换为字符串。
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string CastToString(this object obj)
        {
            return StrConvX.ObjectSafeToString(obj);
        }

        #endregion

        #region Cast byte array to ascii string

        /// <summary>
        /// Convert from bytes to ASCII <see cref="string"/>.
        /// </summary>
        /// <example>in: new byte[] {65, 66, 67}; out: ABC</example>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string CastToString(this byte[] bytes)
        {
            return AsciiConv.BytesToAsciiString(bytes);
        }

        #endregion

        #region Cast char array to String

        /// <summary>
        /// Convert from char array to <see cref="string"/>.
        /// </summary>
        /// <param name="chars"></param>
        /// <returns></returns>
        public static string CastToString(this char[] chars)
        {
            return new(chars);
        }

        #endregion

        #region Cast String to Enum

        /// <summary>
        /// Convert the given string to an enumerated type. <br />
        /// 将给定的字符串转换为枚举类型。
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <param name="text"></param>
        /// <returns></returns>
        public static TEnum CastToEnum<TEnum>(this string text) where TEnum : struct, Enum
        {
            return EnumConvX.StringToEnum<TEnum>(text);
        }

        /// <summary>
        /// Convert the given string to an enumerated type. <br />
        /// 将给定的字符串转换为枚举类型。
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <param name="text">     </param>
        /// <param name="ignoreCase"> 是否区分大小写 </param>
        /// <returns></returns>
        public static TEnum CastToEnum<TEnum>(this string text, bool ignoreCase) where TEnum : struct, Enum
        {
            return EnumConvX.StringToEnum<TEnum>(text, ignoreCase);
        }

        /// <summary>
        /// Convert the given string to an enumerated type. <br />
        /// 将给定的字符串转换为枚举类型。
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static TEnum CastToEnum<TEnum>(this string text, TEnum defaultVal) where TEnum : struct, Enum
        {
            return EnumConvX.StringToEnum(text, defaultVal);
        }

        /// <summary>
        /// Convert the given string to an enumerated type. <br />
        /// 将给定的字符串转换为枚举类型。
        /// </summary>
        /// <typeparam name="TEnum">枚举类型</typeparam>
        /// <param name="text"></param>
        /// <param name="ignoreCase">是否区分大小写</param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static TEnum CastToEnum<TEnum>(this string text, bool ignoreCase, TEnum defaultVal) where TEnum : struct, Enum
        {
            return EnumConvX.StringToEnum(text, defaultVal, ignoreCase);
        }

        #endregion

        #region Cast String to Guid

        /// <summary>
        /// To GUID <br />
        /// 将字符串转换为 Guid。
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static Guid CastToGuid(this string text)
        {
            return GuidConvX.StringToGuid(text);
        }

        /// <summary>
        /// To GUID <br />
        /// 将字符串转换为 Guid。
        /// </summary>
        /// <param name="text"></param>
        /// <param name="defaultVal"></param>
        /// <returns></returns>
        public static Guid CastToGuid(this string text, Guid defaultVal)
        {
            return GuidConvX.StringToGuid(text, defaultVal);
        }

        /// <summary>
        /// To nullable GUID. <br />
        /// 将字符串转换为可空 Guid。
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static Guid? CastToNullableGuid(this string text)
        {
            return GuidConvX.StringToNullableGuid(text);
        }

        #endregion
    }
}