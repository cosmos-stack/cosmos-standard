using System;
using System.Globalization;
using System.Net;
using System.Text;
using Cosmos.Conversions.Common;
using Cosmos.Reflection;

namespace Cosmos.Text
{
    /// <summary>
    /// Cosmos <see cref="string"/> extensions
    /// </summary>
    public static class StringConvAndJudgeExtensions
    {
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
        public static bool Is(
            this string s,
            Type type,
            IgnoreCase ignoreCase = IgnoreCase.FALSE,
            Action<object> action = null,
            string format = null,
            NumberStyles? numberStyle = null,
            DateTimeStyles? dateTimeStyle = null,
            IFormatProvider provider = null)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));

            if (Types.IsNullableType(type))
                return s is null || Is(s, TypeConv.GetNonNullableType(type), ignoreCase, action, format, numberStyle, dateTimeStyle, provider);

            if (!__unsupportedTypeCheck(type,
                out var typeIsAssignableFromEncoding,
                out var typeCanBeChecking, out var checkingHandler))
                return false;

            if (typeCanBeChecking)
                return __customChecking(checkingHandler);

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
            bool __unsupportedTypeCheck(Type t, out bool encodingFlag, out bool checkingFlag, out Func<object, bool> checker)
            {
                encodingFlag = t == typeof(Encoding) || TypeReflections.IsTypeDerivedFrom(t, typeof(Encoding), TypeDerivedOptions.CanAbstract);
                checkingFlag = CustomConvertManager.TryGetChecker(TypeClass.StringClazz, t, out checker);
                return t.IsValueType
                    || encodingFlag
                    || checkingFlag
                    || t == typeof(Version)
                    || t == typeof(IPAddress);
            }

            // ReSharper disable once InconsistentNaming
            bool __customChecking(Func<object, bool> handler)
            {
                var result = handler?.Invoke(s) ?? false;

                if (result)
                {
                    action?.Invoke(s);
                }

                return result;
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
        public static bool Is<T>(
            this string str,
            IgnoreCase ignoreCase = IgnoreCase.FALSE,
            Action<T> action = null,
            string format = null,
            NumberStyles? numberStyle = null,
            DateTimeStyles? dateTimeStyle = null,
            IFormatProvider formatProvider = null) //where T : struct
        {
            return str.Is(typeof(T), ignoreCase, ValueConverter.ConvertAct(action), format, numberStyle, dateTimeStyle, formatProvider);
        }

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
            IgnoreCase ignoreCase = IgnoreCase.FALSE,
            Action<T> action = null,
            Action isNullAction = null,
            string format = null,
            NumberStyles? numberStyle = null,
            DateTimeStyles? dateTimeStyle = null,
            IFormatProvider provider = null) //where T : struct
        {
            return s is null && NullableFunc()(isNullAction)
                || Is(s, ignoreCase, action, format, numberStyle, dateTimeStyle, provider);
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
            IgnoreCase ignoreCase = IgnoreCase.FALSE,
            Action<object> action = null,
            Action isNullAction = null,
            string format = null,
            NumberStyles? numberStyle = null,
            DateTimeStyles? dateTimeStyle = null,
            IFormatProvider provider = null)
        {
            return s is null && NullableFunc()(isNullAction)
                || Is(s, type, ignoreCase, action, format, numberStyle, dateTimeStyle, provider);
        }

        private static Func<Action, bool> NullableFunc() => act =>
        {
            act?.Invoke();
            return true;
        };

        #endregion
    }
}