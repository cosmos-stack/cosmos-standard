using System;
using System.Net;
using System.Text;
using Cosmos.Conversions;
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
        /// <param name="text"></param>
        /// <param name="type"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static bool Is(this string text, Type type, Action<object> action = null)
        {
            return text.Is(type, CastingContext.DefaultContext, action);
        }

        /// <summary>
        /// Determine whether the given string can be of the given type. <br />
        /// 判断给定的字符串是否能成为给定的类型。
        /// </summary>
        /// <param name="text"></param>
        /// <param name="type"></param>
        /// <param name="action"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static bool Is(this string text, Type type, CastingContext context, Action<object> action = null)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));

            if (context is null)
                throw new ArgumentNullException(nameof(context));

            if (Types.IsNullableType(type))
                return text is null || Is(text, TypeConv.GetNonNullableType(type), context, action);

            if (!__unsupportedTypeCheck(type,
                out var typeIsAssignableFromEncoding,
                out var typeCanBeChecking, out var checkingHandler))
                return false;

            if (typeCanBeChecking)
                return __customChecking(checkingHandler);

            return TypeIs.__enumIs(text, type, action, context.IgnoreCase)
                || TypeIs.__charIs(text, type, action)
                || TypeIs.__numericIs(text, type, action, context.NumberStyles, context.FormatProvider)
                || TypeIs.__booleanIs(text, type, action)
                || TypeIs.__dateTimeIs(text, type, action, context.Format, context.DateTimeStyles, context.FormatProvider)
                || TypeIs.__dateTimeOffsetIs(text, type, action, context.Format, context.DateTimeStyles, context.FormatProvider)
                || TypeIs.__timeSpanIs(text, type, action, context.Format, context.FormatProvider)
                || TypeIs.__guidIs(text, type, action, context.Format)
                || TypeIs.__versionIs(text, type, action)
                || TypeIs.__ipAddressIs(text, type, action)
                || TypeIs.__encodingIs(text, action, typeIsAssignableFromEncoding);

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
                var result = handler?.Invoke(text) ?? false;

                if (result)
                {
                    action?.Invoke(text);
                }

                return result;
            }
        }

        /// <summary>
        /// Determine whether the given string can be of the given type. <br />
        /// 判断给定的字符串是否能成为给定的类型。
        /// </summary>
        /// <param name="text"></param>
        /// <param name="type"></param>
        /// <param name="action"></param>
        /// <param name="contextAct"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static bool Is(this string text, Type type, Action<CastingContext> contextAct, Action<object> action = null)
        {
            var context = new CastingContext();
            contextAct?.Invoke(context);
            return text.Is(type, context, action);
        }

        #endregion

        #region Is `1

        /// <summary>
        /// Determine whether the given string can be of the given type. <br />
        /// 判断给定的字符串是否能成为给定的类型。
        /// </summary>
        /// <param name="text"></param>
        /// <param name="action"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool Is<T>(this string text, Action<T> action = null)
        {
            return text.Is(typeof(T), ValueConverter.ConvertAct(action));
        }

        /// <summary>
        /// Determine whether the given string can be of the given type. <br />
        /// 判断给定的字符串是否能成为给定的类型。
        /// </summary>
        /// <param name="text"></param>
        /// <param name="action"></param>
        /// <param name="context"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool Is<T>(this string text, CastingContext context, Action<T> action = null)
        {
            return text.Is(typeof(T), context, ValueConverter.ConvertAct(action));
        }

        /// <summary>
        /// Determine whether the given string can be of the given type. <br />
        /// 判断给定的字符串是否能成为给定的类型。
        /// </summary>
        /// <param name="text"></param>
        /// <param name="action"></param>
        /// <param name="contextAct"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool Is<T>(this string text, Action<CastingContext> contextAct, Action<T> action = null)
        {
            return text.Is(typeof(T), contextAct, ValueConverter.ConvertAct(action));
        }

        #endregion

        #region Is Nullable

        /// <summary>
        /// Determine whether the given string is empty. If it is empty, perform the specified operation.<br />
        /// 判断给定的字符串是否为空。如果为空则执行指定的操作。
        /// </summary>
        /// <param name="text"></param>
        /// <param name="type"></param>
        /// <param name="action">If the string is guessed to be empty by the string specifier, perform this operation.</param>
        /// <param name="isNullAction">If the string is empty, perform this operation.</param>
        /// <returns></returns>
        public static bool IsNullable(this string text, Type type, Action<object> action = null, Action isNullAction = null)
        {
            return text is null && NullableFunc()(isNullAction) || text.Is(type, action);
        }

        /// <summary>
        /// Determine whether the given string is empty. If it is empty, perform the specified operation.<br />
        /// 判断给定的字符串是否为空。如果为空则执行指定的操作。
        /// </summary>
        /// <param name="text"></param>
        /// <param name="type"></param>
        /// <param name="context"></param>
        /// <param name="action">If the string is guessed to be empty by the string specifier, perform this operation.</param>
        /// <param name="isNullAction">If the string is empty, perform this operation.</param>
        /// <returns></returns>
        public static bool IsNullable(this string text, Type type, CastingContext context, Action<object> action = null, Action isNullAction = null)
        {
            return text is null && NullableFunc()(isNullAction) || text.Is(type, context, action);
        }

        /// <summary>
        /// Determine whether the given string is empty. If it is empty, perform the specified operation.<br />
        /// 判断给定的字符串是否为空。如果为空则执行指定的操作。
        /// </summary>
        /// <param name="text"></param>
        /// <param name="type"></param>
        /// <param name="contextAct"></param>
        /// <param name="action">If the string is guessed to be empty by the string specifier, perform this operation.</param>
        /// <param name="isNullAction">If the string is empty, perform this operation.</param>
        /// <returns></returns>
        public static bool IsNullable(this string text, Type type, Action<CastingContext> contextAct, Action<object> action = null, Action isNullAction = null)
        {
            return text is null && NullableFunc()(isNullAction) || text.Is(type, contextAct, action);
        }

        /// <summary>
        /// Determine whether the given string is empty. If it is empty, perform the specified operation.<br />
        /// 判断给定的字符串是否为空。如果为空则执行指定的操作。
        /// </summary>
        /// <param name="text"></param>
        /// <param name="action">If the string is guessed to be empty by the string specifier, perform this operation.</param>
        /// <param name="isNullAction">If the string is empty, perform this operation.</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsNullable<T>(this string text, Action<T> action = null, Action isNullAction = null)
        {
            return text is null && NullableFunc()(isNullAction) || text.Is(action);
        }

        /// <summary>
        /// Determine whether the given string is empty. If it is empty, perform the specified operation.<br />
        /// 判断给定的字符串是否为空。如果为空则执行指定的操作。
        /// </summary>
        /// <param name="text"></param>
        /// <param name="context"></param>
        /// <param name="action">If the string is guessed to be empty by the string specifier, perform this operation.</param>
        /// <param name="isNullAction">If the string is empty, perform this operation.</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsNullable<T>(this string text, CastingContext context, Action<T> action = null, Action isNullAction = null)
        {
            return text is null && NullableFunc()(isNullAction) || text.Is(context, action);
        }

        /// <summary>
        /// Determine whether the given string is empty. If it is empty, perform the specified operation.<br />
        /// 判断给定的字符串是否为空。如果为空则执行指定的操作。
        /// </summary>
        /// <param name="text"></param>
        /// <param name="contextAct"></param>
        /// <param name="action">If the string is guessed to be empty by the string specifier, perform this operation.</param>
        /// <param name="isNullAction">If the string is empty, perform this operation.</param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool IsNullable<T>(this string text, Action<CastingContext> contextAct, Action<T> action = null, Action isNullAction = null)
        {
            return text is null && NullableFunc()(isNullAction) || text.Is(contextAct, action);
        }

        private static Func<Action, bool> NullableFunc() => act =>
        {
            act?.Invoke();
            return true;
        };

        #endregion
    }
}