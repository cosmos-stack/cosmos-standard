using System.Net;
using System.Text;
using Cosmos.Conversions;
using Cosmos.Conversions.Common;
using Cosmos.Reflection;

namespace Cosmos.Text;

/// <summary>
/// Cosmos.Core <see cref="string"/> extensions <br />
/// 字符串扩展
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
    /// <param name="matchedCallback"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Is(this string text, Type type, Action<object> matchedCallback = null)
    {
        return text.Is(type, CastingContext.DefaultContext, matchedCallback);
    }

    /// <summary>
    /// Determine whether the given string can be of the given type. <br />
    /// 判断给定的字符串是否能成为给定的类型。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="type"></param>
    /// <param name="matchedCallback"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    public static bool Is(this string text, Type type, CastingContext context, Action<object> matchedCallback = null)
    {
        ArgumentNullException.ThrowIfNull(type);
        ArgumentNullException.ThrowIfNull(context);

        if (Types.IsNullableType(type))
            return text is null || Is(text, TypeConv.GetNonNullableType(type)!, context, matchedCallback);

        if (!__unsupportedTypeCheck(type,
                out var typeIsAssignableFromEncoding,
                out var typeCanBeChecking, out var checkingHandler))
            return false;

        if (typeCanBeChecking)
            return __customChecking(checkingHandler);

        return TypeIs.__enumIs(text, type, matchedCallback, context.IgnoreCase)
                     .Or(() => TypeIs.__charIs(text, type, matchedCallback))
                     .Or(() => TypeIs.__numericIs(text, type, matchedCallback, context.NumberStyles, context.FormatProvider))
                     .Or(() => TypeIs.__booleanIs(text, type, matchedCallback))
                     .Or(() => TypeIs.__dateTimeIs(text, type, matchedCallback, context.Format, context.DateTimeStyles, context.FormatProvider))
                     .Or(() => TypeIs.__dateTimeOffsetIs(text, type, matchedCallback, context.Format, context.DateTimeStyles, context.FormatProvider))
                     .Or(() => TypeIs.__timeSpanIs(text, type, matchedCallback, context.Format, context.FormatProvider))
                     .Or(() => TypeIs.__guidIs(text, type, matchedCallback, context.Format))
                     .Or(() => TypeIs.__versionIs(text, type, matchedCallback))
                     .Or(() => TypeIs.__ipAddressIs(text, type, matchedCallback))
                     .Or(() => TypeIs.__encodingIs(text, matchedCallback, typeIsAssignableFromEncoding));

        // ReSharper disable once InconsistentNaming
        bool __unsupportedTypeCheck(Type t, out bool encodingFlag, out bool checkingFlag, out Func<object, bool> checker)
        {
            encodingFlag = t == typeof(Encoding) || TypeReflections.IsTypeDerivedFrom(t, typeof(Encoding), TypeDerivedOptions.CanAbstract);
            checkingFlag = CustomConvertManager.TryGetChecker(TypeClass.StringClazz, t, out checker);
            return t.IsValueType
                    .Or(encodingFlag)
                    .Or(checkingFlag)
                    .Or(() => t == typeof(Version))
                    .Or(() => t == typeof(IPAddress));
        }

        // ReSharper disable once InconsistentNaming
        bool __customChecking(Func<object, bool> handler)
        {
            var result = handler?.Invoke(text) ?? false;

            result.IfTrue(matchedCallback, text);

            return result;
        }
    }

    /// <summary>
    /// Determine whether the given string can be of the given type. <br />
    /// 判断给定的字符串是否能成为给定的类型。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="type"></param>
    /// <param name="matchedCallback"></param>
    /// <param name="contextAct"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Is(this string text, Type type, Action<CastingContext> contextAct, Action<object> matchedCallback = null)
    {
        var context = new CastingContext();
        contextAct?.Invoke(context);
        return text.Is(type, context, matchedCallback);
    }

    #endregion

    #region Is `1

    /// <summary>
    /// Determine whether the given string can be of the given type. <br />
    /// 判断给定的字符串是否能成为给定的类型。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="matchedCallback"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Is<T>(this string text, Action<T> matchedCallback = null)
    {
        return text.Is(typeof(T), ValueConverter.ConvertAct(matchedCallback));
    }

    /// <summary>
    /// Determine whether the given string can be of the given type. <br />
    /// 判断给定的字符串是否能成为给定的类型。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="matchedCallback"></param>
    /// <param name="context"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Is<T>(this string text, CastingContext context, Action<T> matchedCallback = null)
    {
        return text.Is(typeof(T), context, ValueConverter.ConvertAct(matchedCallback));
    }

    /// <summary>
    /// Determine whether the given string can be of the given type. <br />
    /// 判断给定的字符串是否能成为给定的类型。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="matchedCallback"></param>
    /// <param name="contextAct"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Is<T>(this string text, Action<CastingContext> contextAct, Action<T> matchedCallback = null)
    {
        return text.Is(typeof(T), contextAct, ValueConverter.ConvertAct(matchedCallback));
    }

    #endregion

    #region Is Nullable `0

    /// <summary>
    /// Determine whether the given string is empty. If it is empty, perform the specified operation.<br />
    /// 判断给定的字符串是否为空。如果为空则执行指定的操作。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="type"></param>
    /// <param name="matchedCallback">If the string is guessed to be empty by the string specifier, perform this operation.</param>
    /// <param name="noneMatchedCallback">If the string is empty, perform this operation.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNullable(this string text, Type type, Action<object> matchedCallback = null, Action noneMatchedCallback = null)
    {
        return text is null && NullableFunc()(noneMatchedCallback) || text.Is(type, matchedCallback);
    }

    /// <summary>
    /// Determine whether the given string is empty. If it is empty, perform the specified operation.<br />
    /// 判断给定的字符串是否为空。如果为空则执行指定的操作。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="type"></param>
    /// <param name="context"></param>
    /// <param name="matchedCallback">If the string is guessed to be empty by the string specifier, perform this operation.</param>
    /// <param name="noneMatchedCallback">If the string is empty, perform this operation.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNullable(this string text, Type type, CastingContext context, Action<object> matchedCallback = null, Action noneMatchedCallback = null)
    {
        return text is null && NullableFunc()(noneMatchedCallback) || text.Is(type, context, matchedCallback);
    }

    /// <summary>
    /// Determine whether the given string is empty. If it is empty, perform the specified operation.<br />
    /// 判断给定的字符串是否为空。如果为空则执行指定的操作。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="type"></param>
    /// <param name="contextAct"></param>
    /// <param name="matchedCallback">If the string is guessed to be empty by the string specifier, perform this operation.</param>
    /// <param name="noneMatchedCallback">If the string is empty, perform this operation.</param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNullable(this string text, Type type, Action<CastingContext> contextAct, Action<object> matchedCallback = null, Action noneMatchedCallback = null)
    {
        return text is null && NullableFunc()(noneMatchedCallback) || text.Is(type, contextAct, matchedCallback);
    }

    #endregion

    #region Is Nullable `1

    /// <summary>
    /// Determine whether the given string is empty. If it is empty, perform the specified operation.<br />
    /// 判断给定的字符串是否为空。如果为空则执行指定的操作。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="matchedCallback">If the string is guessed to be empty by the string specifier, perform this operation.</param>
    /// <param name="noneMatchedCallback">If the string is empty, perform this operation.</param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNullable<T>(this string text, Action<T> matchedCallback = null, Action noneMatchedCallback = null)
    {
        return text is null && NullableFunc()(noneMatchedCallback) || text.Is(matchedCallback);
    }

    /// <summary>
    /// Determine whether the given string is empty. If it is empty, perform the specified operation.<br />
    /// 判断给定的字符串是否为空。如果为空则执行指定的操作。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="context"></param>
    /// <param name="matchedCallback">If the string is guessed to be empty by the string specifier, perform this operation.</param>
    /// <param name="noneMatchedCallback">If the string is empty, perform this operation.</param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNullable<T>(this string text, CastingContext context, Action<T> matchedCallback = null, Action noneMatchedCallback = null)
    {
        return text is null && NullableFunc()(noneMatchedCallback) || text.Is(context, matchedCallback);
    }

    /// <summary>
    /// Determine whether the given string is empty. If it is empty, perform the specified operation.<br />
    /// 判断给定的字符串是否为空。如果为空则执行指定的操作。
    /// </summary>
    /// <param name="text"></param>
    /// <param name="contextAct"></param>
    /// <param name="matchedCallback">If the string is guessed to be empty by the string specifier, perform this operation.</param>
    /// <param name="noneMatchedCallback">If the string is empty, perform this operation.</param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNullable<T>(this string text, Action<CastingContext> contextAct, Action<T> matchedCallback = null, Action noneMatchedCallback = null)
    {
        return text is null && NullableFunc()(noneMatchedCallback) || text.Is(contextAct, matchedCallback);
    }

    private static Func<Action, bool> NullableFunc() => act => act.InvokeThenTrue();

    #endregion
}