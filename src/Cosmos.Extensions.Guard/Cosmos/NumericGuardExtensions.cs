using Cosmos.Numeric;

namespace Cosmos;

/// <summary>
/// Numeric Guard Extensions <br />
/// 数值守护扩展
/// </summary>
public static class NumericGuardExtensions
{
    /// <summary>
    /// Check whether the value is within the range.
    /// If the value is out of range, an exception is thrown.
    /// 检查数值是否在范围内。
    /// 如果数值超出范围，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequireWithinRange(this int argument, int min, int max, string argumentName, string message = null)
#else
    public static void RequireWithinRange(this int argument, int min, int max, [CallerArgumentExpression("argument")] string argumentName = null, string message = null)
#endif
    {
        NumericGuard.ShouldBeWithinRange(argument, min, max, argumentName, message);
    }

    /// <summary>
    /// Check whether the value is within the range.
    /// If the value is out of range, an exception is thrown.
    /// 检查数值是否在范围内。
    /// 如果数值超出范围，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    /// <param name="options"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequireWithinRange(this int? argument, int min, int max, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#else
    public static void RequireWithinRange(this int? argument, int min, int max, [CallerArgumentExpression("argument")] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#endif
    {
        NumericGuard.ShouldBeWithinRange(argument, min, max, argumentName, message, options);
    }

    /// <summary>
    /// Check whether the number is positive or zero. <br />
    /// If the number is negative, an exception is thrown. <br />
    /// 检查数值是否为正或为零。 <br />
    /// 如果数值为负，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequirePositiveOrZero(this int argument, string argumentName, string message = null)
#else
    public static void RequirePositiveOrZero(this int argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null)
#endif
    {
        NumericGuard.ShouldBePositiveOrZero(argument, argumentName, message);
    }

    /// <summary>
    /// Check whether the number is positive or zero. <br />
    /// If the number is negative, an exception is thrown. <br />
    /// 检查数值是否为正或为零。 <br />
    /// 如果数值为负，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    /// <param name="options"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequirePositiveOrZero(this int? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#else
    public static void RequirePositiveOrZero(this int? argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#endif
    {
        NumericGuard.ShouldBePositiveOrZero(argument, argumentName, message, options);
    }

    /// <summary>
    /// Check whether the number is positive. <br />
    /// If the number is negative or zero, an exception is thrown. <br />
    /// 检查数值是否为正的。 <br />
    /// 如果数值为负或为零，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequirePositive(this int argument, string argumentName, string message = null)
#else
    public static void RequirePositive(this int argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null)
#endif
    {
        NumericGuard.ShouldBePositive(argument, argumentName, message);
    }

    /// <summary>
    /// Check whether the number is positive. <br />
    /// If the number is negative or zero, an exception is thrown. <br />
    /// 检查数值是否为正的。 <br />
    /// 如果数值为负或为零，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    /// <param name="options"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequirePositive(this int? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#else
    public static void RequirePositive(this int? argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#endif
    {
        NumericGuard.ShouldBePositive(argument, argumentName, message, options);
    }

    /// <summary>
    /// Check whether the number is negative or zero. <br />
    /// If the number is positive, an exception is thrown. <br />
    /// 检查数值是否为负或为零。 <br />
    /// 如果数值为正，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequireNegativeOrZero(this int argument, string argumentName, string message = null)
#else
    public static void RequireNegativeOrZero(this int argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null)
#endif
    {
        NumericGuard.ShouldBeNegativeOrZero(argument, argumentName, message);
    }

    /// <summary>
    /// Check whether the number is negative or zero. <br />
    /// If the number is positive, an exception is thrown. <br />
    /// 检查数值是否为负或为零。 <br />
    /// 如果数值为正，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    /// <param name="options"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequireNegativeOrZero(this int? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#else
    public static void RequireNegativeOrZero(this int? argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#endif
    {
        NumericGuard.ShouldBeNegativeOrZero(argument, argumentName, message, options);
    }

    /// <summary>
    /// Check whether the number is negative. <br />
    /// If the number is positive or zero, an exception is thrown. <br />
    /// 检查数值是否为负的。 <br />
    /// 如果数值为正或为零，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequireNegative(this int argument, string argumentName, string message = null)
#else
    public static void RequireNegative(this int argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null)
#endif
    {
        NumericGuard.ShouldBeNegative(argument, argumentName, message);
    }

    /// <summary>
    /// Check whether the number is negative. <br />
    /// If the number is positive or zero, an exception is thrown. <br />
    /// 检查数值是否为负的。 <br />
    /// 如果数值为正或为零，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    /// <param name="options"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequireNegative(this int? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#else
    public static void RequireNegative(this int? argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#endif
    {
        NumericGuard.ShouldBeNegative(argument, argumentName, message, options);
    }

    /// <summary>
    /// Check whether the value is within the range.
    /// If the value is out of range, an exception is thrown.
    /// 检查数值是否在范围内。
    /// 如果数值超出范围，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequireWithinRange(this long argument, long min, long max, string argumentName, string message = null)
#else
    public static void RequireWithinRange(this long argument, long min, long max, [CallerArgumentExpression("argument")] string argumentName = null, string message = null)
#endif
    {
        NumericGuard.ShouldBeWithinRange(argument, min, max, argumentName, message);
    }

    /// <summary>
    /// Check whether the value is within the range.
    /// If the value is out of range, an exception is thrown.
    /// 检查数值是否在范围内。
    /// 如果数值超出范围，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    /// <param name="options"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequireWithinRange(this long? argument, long min, long max, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#else
    public static void RequireWithinRange(this long? argument, long min, long max, [CallerArgumentExpression("argument")] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#endif
    {
        NumericGuard.ShouldBeWithinRange(argument, min, max, argumentName, message, options);
    }

    /// <summary>
    /// Check whether the number is positive or zero. <br />
    /// If the number is negative, an exception is thrown. <br />
    /// 检查数值是否为正或为零。 <br />
    /// 如果数值为负，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequirePositiveOrZero(this long argument, string argumentName, string message = null)
#else
    public static void RequirePositiveOrZero(this long argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null)
#endif
    {
        NumericGuard.ShouldBePositiveOrZero(argument, argumentName, message);
    }

    /// <summary>
    /// Check whether the number is positive or zero. <br />
    /// If the number is negative, an exception is thrown. <br />
    /// 检查数值是否为正或为零。 <br />
    /// 如果数值为负，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    /// <param name="options"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequirePositiveOrZero(this long? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#else
    public static void RequirePositiveOrZero(this long? argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#endif
    {
        NumericGuard.ShouldBePositiveOrZero(argument, argumentName, message, options);
    }

    /// <summary>
    /// Check whether the number is positive. <br />
    /// If the number is negative or zero, an exception is thrown. <br />
    /// 检查数值是否为正的。 <br />
    /// 如果数值为负或为零，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequirePositive(this long argument, string argumentName, string message = null)
#else
    public static void RequirePositive(this long argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null)
#endif
    {
        NumericGuard.ShouldBePositive(argument, argumentName, message);
    }

    /// <summary>
    /// Check whether the number is positive. <br />
    /// If the number is negative or zero, an exception is thrown. <br />
    /// 检查数值是否为正的。 <br />
    /// 如果数值为负或为零，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    /// <param name="options"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequirePositive(this long? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#else
    public static void RequirePositive(this long? argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#endif
    {
        NumericGuard.ShouldBePositive(argument, argumentName, message, options);
    }

    /// <summary>
    /// Check whether the number is negative or zero. <br />
    /// If the number is positive, an exception is thrown. <br />
    /// 检查数值是否为负或为零。 <br />
    /// 如果数值为正，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequireNegativeOrZero(this long argument, string argumentName, string message = null)
#else
    public static void RequireNegativeOrZero(this long argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null)
#endif
    {
        NumericGuard.ShouldBeNegativeOrZero(argument, argumentName, message);
    }

    /// <summary>
    /// Check whether the number is negative or zero. <br />
    /// If the number is positive, an exception is thrown. <br />
    /// 检查数值是否为负或为零。 <br />
    /// 如果数值为正，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    /// <param name="options"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequireNegativeOrZero(this long? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#else
    public static void RequireNegativeOrZero(this long? argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#endif
    {
        NumericGuard.ShouldBeNegativeOrZero(argument, argumentName, message, options);
    }

    /// <summary>
    /// Check whether the number is negative. <br />
    /// If the number is positive or zero, an exception is thrown. <br />
    /// 检查数值是否为负的。 <br />
    /// 如果数值为正或为零，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequireNegative(this long argument, string argumentName, string message = null)
#else
    public static void RequireNegative(this long argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null)
#endif
    {
        NumericGuard.ShouldBeNegative(argument, argumentName, message);
    }

    /// <summary>
    /// Check whether the number is negative. <br />
    /// If the number is positive or zero, an exception is thrown. <br />
    /// 检查数值是否为负的。 <br />
    /// 如果数值为正或为零，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    /// <param name="options"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequireNegative(this long? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#else
    public static void RequireNegative(this long? argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#endif
    {
        NumericGuard.ShouldBeNegative(argument, argumentName, message, options);
    }

    /// <summary>
    /// Check whether the value is within the range.
    /// If the value is out of range, an exception is thrown.
    /// 检查数值是否在范围内。
    /// 如果数值超出范围，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequireWithinRange(this float argument, float min, float max, string argumentName, string message = null)
#else
    public static void RequireWithinRange(this float argument, float min, float max, [CallerArgumentExpression("argument")] string argumentName = null, string message = null)
#endif
    {
        NumericGuard.ShouldBeWithinRange(argument, min, max, argumentName, message);
    }

    /// <summary>
    /// Check whether the value is within the range.
    /// If the value is out of range, an exception is thrown.
    /// 检查数值是否在范围内。
    /// 如果数值超出范围，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    /// <param name="options"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequireWithinRange(this float? argument, float min, float max, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#else
    public static void RequireWithinRange(this float? argument, float min, float max, [CallerArgumentExpression("argument")] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#endif
    {
        NumericGuard.ShouldBeWithinRange(argument, min, max, argumentName, message, options);
    }

    /// <summary>
    /// Check whether the number is positive or zero. <br />
    /// If the number is negative, an exception is thrown. <br />
    /// 检查数值是否为正或为零。 <br />
    /// 如果数值为负，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequirePositiveOrZero(this float argument, string argumentName, string message = null)
#else
    public static void RequirePositiveOrZero(this float argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null)
#endif
    {
        NumericGuard.ShouldBePositiveOrZero(argument, argumentName, message);
    }

    /// <summary>
    /// Check whether the number is positive or zero. <br />
    /// If the number is negative, an exception is thrown. <br />
    /// 检查数值是否为正或为零。 <br />
    /// 如果数值为负，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    /// <param name="options"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequirePositiveOrZero(this float? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#else
    public static void RequirePositiveOrZero(this float? argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#endif
    {
        NumericGuard.ShouldBePositiveOrZero(argument, argumentName, message, options);
    }

    /// <summary>
    /// Check whether the number is positive. <br />
    /// If the number is negative or zero, an exception is thrown. <br />
    /// 检查数值是否为正的。 <br />
    /// 如果数值为负或为零，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequirePositive(this float argument, string argumentName, string message = null)
#else
    public static void RequirePositive(this float argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null)
#endif
    {
        NumericGuard.ShouldBePositive(argument, argumentName, message);
    }

    /// <summary>
    /// Check whether the number is positive. <br />
    /// If the number is negative or zero, an exception is thrown. <br />
    /// 检查数值是否为正的。 <br />
    /// 如果数值为负或为零，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    /// <param name="options"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequirePositive(this float? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#else
    public static void RequirePositive(this float? argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#endif
    {
        NumericGuard.ShouldBePositive(argument, argumentName, message, options);
    }

    /// <summary>
    /// Check whether the number is negative or zero. <br />
    /// If the number is positive, an exception is thrown. <br />
    /// 检查数值是否为负或为零。 <br />
    /// 如果数值为正，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequireNegativeOrZero(this float argument, string argumentName, string message = null)
#else
    public static void RequireNegativeOrZero(this float argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null)
#endif
    {
        NumericGuard.ShouldBeNegativeOrZero(argument, argumentName, message);
    }

    /// <summary>
    /// Check whether the number is negative or zero. <br />
    /// If the number is positive, an exception is thrown. <br />
    /// 检查数值是否为负或为零。 <br />
    /// 如果数值为正，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    /// <param name="options"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequireNegativeOrZero(this float? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#else
    public static void RequireNegativeOrZero(this float? argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#endif
    {
        NumericGuard.ShouldBeNegativeOrZero(argument, argumentName, message, options);
    }

    /// <summary>
    /// Check whether the number is negative. <br />
    /// If the number is positive or zero, an exception is thrown. <br />
    /// 检查数值是否为负的。 <br />
    /// 如果数值为正或为零，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequireNegative(this float argument, string argumentName, string message = null)
#else
    public static void RequireNegative(this float argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null)
#endif
    {
        NumericGuard.ShouldBeNegative(argument, argumentName, message);
    }

    /// <summary>
    /// Check whether the number is negative. <br />
    /// If the number is positive or zero, an exception is thrown. <br />
    /// 检查数值是否为负的。 <br />
    /// 如果数值为正或为零，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    /// <param name="options"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequireNegative(this float? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#else
    public static void RequireNegative(this float? argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#endif
    {
        NumericGuard.ShouldBeNegative(argument, argumentName, message, options);
    }

    /// <summary>
    /// Check whether the value is within the range.
    /// If the value is out of range, an exception is thrown.
    /// 检查数值是否在范围内。
    /// 如果数值超出范围，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequireWithinRange(this double argument, double min, double max, string argumentName, string message = null)
#else
    public static void RequireWithinRange(this double argument, double min, double max, [CallerArgumentExpression("argument")] string argumentName = null, string message = null)
#endif
    {
        NumericGuard.ShouldBeWithinRange(argument, min, max, argumentName, message);
    }

    /// <summary>
    /// Check whether the value is within the range.
    /// If the value is out of range, an exception is thrown.
    /// 检查数值是否在范围内。
    /// 如果数值超出范围，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    /// <param name="options"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequireWithinRange(this double? argument, double min, double max, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#else
    public static void RequireWithinRange(this double? argument, double min, double max, [CallerArgumentExpression("argument")] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#endif
    {
        NumericGuard.ShouldBeWithinRange(argument, min, max, argumentName, message, options);
    }

    /// <summary>
    /// Check whether the number is positive or zero. <br />
    /// If the number is negative, an exception is thrown. <br />
    /// 检查数值是否为正或为零。 <br />
    /// 如果数值为负，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequirePositiveOrZero(this double argument, string argumentName, string message = null)
#else
    public static void RequirePositiveOrZero(this double argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null)
#endif
    {
        NumericGuard.ShouldBePositiveOrZero(argument, argumentName, message);
    }

    /// <summary>
    /// Check whether the number is positive or zero. <br />
    /// If the number is negative, an exception is thrown. <br />
    /// 检查数值是否为正或为零。 <br />
    /// 如果数值为负，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    /// <param name="options"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequirePositiveOrZero(this double? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#else
    public static void RequirePositiveOrZero(this double? argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#endif
    {
        NumericGuard.ShouldBePositiveOrZero(argument, argumentName, message, options);
    }

    /// <summary>
    /// Check whether the number is positive. <br />
    /// If the number is negative or zero, an exception is thrown. <br />
    /// 检查数值是否为正的。 <br />
    /// 如果数值为负或为零，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequirePositive(this double argument, string argumentName, string message = null)
#else
    public static void RequirePositive(this double argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null)
#endif
    {
        NumericGuard.ShouldBePositive(argument, argumentName, message);
    }

    /// <summary>
    /// Check whether the number is positive. <br />
    /// If the number is negative or zero, an exception is thrown. <br />
    /// 检查数值是否为正的。 <br />
    /// 如果数值为负或为零，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    /// <param name="options"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequirePositive(this double? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#else
    public static void RequirePositive(this double? argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#endif
    {
        NumericGuard.ShouldBePositive(argument, argumentName, message, options);
    }

    /// <summary>
    /// Check whether the number is negative or zero. <br />
    /// If the number is positive, an exception is thrown. <br />
    /// 检查数值是否为负或为零。 <br />
    /// 如果数值为正，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequireNegativeOrZero(this double argument, string argumentName, string message = null)
#else
    public static void RequireNegativeOrZero(this double argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null)
#endif
    {
        NumericGuard.ShouldBeNegativeOrZero(argument, argumentName, message);
    }

    /// <summary>
    /// Check whether the number is negative or zero. <br />
    /// If the number is positive, an exception is thrown. <br />
    /// 检查数值是否为负或为零。 <br />
    /// 如果数值为正，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    /// <param name="options"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequireNegativeOrZero(this double? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#else
    public static void RequireNegativeOrZero(this double? argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#endif
    {
        NumericGuard.ShouldBeNegativeOrZero(argument, argumentName, message, options);
    }

    /// <summary>
    /// Check whether the number is negative. <br />
    /// If the number is positive or zero, an exception is thrown. <br />
    /// 检查数值是否为负的。 <br />
    /// 如果数值为正或为零，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequireNegative(this double argument, string argumentName, string message = null)
#else
    public static void RequireNegative(this double argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null)
#endif
    {
        NumericGuard.ShouldBeNegative(argument, argumentName, message);
    }

    /// <summary>
    /// Check whether the number is negative. <br />
    /// If the number is positive or zero, an exception is thrown. <br />
    /// 检查数值是否为负的。 <br />
    /// 如果数值为正或为零，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    /// <param name="options"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequireNegative(this double? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#else
    public static void RequireNegative(this double? argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#endif
    {
        NumericGuard.ShouldBeNegative(argument, argumentName, message, options);
    }

    /// <summary>
    /// Check whether the value is within the range.
    /// If the value is out of range, an exception is thrown.
    /// 检查数值是否在范围内。
    /// 如果数值超出范围，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequireWithinRange(this decimal argument, decimal min, decimal max, string argumentName, string message = null)
#else
    public static void RequireWithinRange(this decimal argument, decimal min, decimal max, [CallerArgumentExpression("argument")] string argumentName = null, string message = null)
#endif
    {
        NumericGuard.ShouldBeWithinRange(argument, min, max, argumentName, message);
    }

    /// <summary>
    /// Check whether the value is within the range.
    /// If the value is out of range, an exception is thrown.
    /// 检查数值是否在范围内。
    /// 如果数值超出范围，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    /// <param name="options"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequireWithinRange(this decimal? argument, decimal min, decimal max, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#else
    public static void RequireWithinRange(this decimal? argument, decimal min, decimal max, [CallerArgumentExpression("argument")] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#endif
    {
        NumericGuard.ShouldBeWithinRange(argument, min, max, argumentName, message, options);
    }

    /// <summary>
    /// Check whether the number is positive or zero. <br />
    /// If the number is negative, an exception is thrown. <br />
    /// 检查数值是否为正或为零。 <br />
    /// 如果数值为负，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequirePositiveOrZero(this decimal argument, string argumentName, string message = null)
#else
    public static void RequirePositiveOrZero(this decimal argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null)
#endif
    {
        NumericGuard.ShouldBePositiveOrZero(argument, argumentName, message);
    }

    /// <summary>
    /// Check whether the number is positive or zero. <br />
    /// If the number is negative, an exception is thrown. <br />
    /// 检查数值是否为正或为零。 <br />
    /// 如果数值为负，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    /// <param name="options"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequirePositiveOrZero(this decimal? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#else
    public static void RequirePositiveOrZero(this decimal? argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#endif
    {
        NumericGuard.ShouldBePositiveOrZero(argument, argumentName, message, options);
    }

    /// <summary>
    /// Check whether the number is positive. <br />
    /// If the number is negative or zero, an exception is thrown. <br />
    /// 检查数值是否为正的。 <br />
    /// 如果数值为负或为零，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequirePositive(this decimal argument, string argumentName, string message = null)
#else
    public static void RequirePositive(this decimal argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null)
#endif
    {
        NumericGuard.ShouldBePositive(argument, argumentName, message);
    }

    /// <summary>
    /// Check whether the number is positive. <br />
    /// If the number is negative or zero, an exception is thrown. <br />
    /// 检查数值是否为正的。 <br />
    /// 如果数值为负或为零，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    /// <param name="options"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequirePositive(this decimal? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#else
    public static void RequirePositive(this decimal? argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#endif
    {
        NumericGuard.ShouldBePositive(argument, argumentName, message, options);
    }

    /// <summary>
    /// Check whether the number is negative or zero. <br />
    /// If the number is positive, an exception is thrown. <br />
    /// 检查数值是否为负或为零。 <br />
    /// 如果数值为正，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequireNegativeOrZero(this decimal argument, string argumentName, string message = null)
#else
    public static void RequireNegativeOrZero(this decimal argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null)
#endif
    {
        NumericGuard.ShouldBeNegativeOrZero(argument, argumentName, message);
    }

    /// <summary>
    /// Check whether the number is negative or zero. <br />
    /// If the number is positive, an exception is thrown. <br />
    /// 检查数值是否为负或为零。 <br />
    /// 如果数值为正，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    /// <param name="options"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequireNegativeOrZero(this decimal? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#else
    public static void RequireNegativeOrZero(this decimal? argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#endif
    {
        NumericGuard.ShouldBeNegativeOrZero(argument, argumentName, message, options);
    }

    /// <summary>
    /// Check whether the number is negative. <br />
    /// If the number is positive or zero, an exception is thrown. <br />
    /// 检查数值是否为负的。 <br />
    /// 如果数值为正或为零，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequireNegative(this decimal argument, string argumentName, string message = null)
#else
    public static void RequireNegative(this decimal argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null)
#endif
    {
        NumericGuard.ShouldBeNegative(argument, argumentName, message);
    }

    /// <summary>
    /// Check whether the number is negative. <br />
    /// If the number is positive or zero, an exception is thrown. <br />
    /// 检查数值是否为负的。 <br />
    /// 如果数值为正或为零，则抛出异常。
    /// </summary>
    /// <param name="argument"></param>
    /// <param name="argumentName"></param>
    /// <param name="message"></param>
    /// <param name="options"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
#if NETFRAMEWORK
    public static void RequireNegative(this decimal? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#else
    public static void RequireNegative(this decimal? argument, [CallerArgumentExpression("argument")] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
#endif
    {
        NumericGuard.ShouldBeNegative(argument, argumentName, message, options);
    }
}