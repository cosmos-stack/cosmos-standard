namespace Cosmos.Numeric;

internal static class NumericGuardHelper
{
    public static T? N<T>(T? x, NumericMayOptions options, string argumentName, string message = null) where T : struct
    {
        if (options is NumericMayOptions.Default)
            ValidationExceptionHelper.WrapAndRaise<ArgumentNullException>(
                x is not null,
                argumentName, message ?? $"The given nullable number should not be null.");
        return x;
    }
}

/// <summary>
/// Numeric Guard <br />
/// 数值守护
/// </summary>
public static class NumericGuard
{
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
    public static void ShouldBePositive(int argument, string argumentName, string message = null)
    {
        ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
            argument > 0,
            argumentName, argument, message ?? $"The given number ({nameof(argument)} = {argument}) should be positive.");
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
    public static void ShouldBePositive(int? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
    {
        ShouldBePositive(NumericGuardHelper.N(argument, options, argumentName, message).SafeValue(), argumentName, message);
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
    public static void ShouldBePositiveOrZero(int argument, string argumentName, string message = null)
    {
        ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
            argument >= 0,
            argumentName, argument, message ?? $"The given number ({nameof(argument)} = {argument}) should be positive or zero.");
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
    public static void ShouldBePositiveOrZero(int? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
    {
        ShouldBePositiveOrZero(NumericGuardHelper.N(argument, options, argumentName, message).SafeValue(), argumentName, message);
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
    public static void ShouldBeNegative(int argument, string argumentName, string message = null)
    {
        ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
            argument < 0,
            argumentName, argument, message ?? $"The given number ({nameof(argument)} = {argument}) should be negative.");
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
    public static void ShouldBeNegative(int? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
    {
        ShouldBeNegative(NumericGuardHelper.N(argument, options, argumentName, message).SafeValue(), argumentName, message);
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
    public static void ShouldBeNegativeOrZero(int argument, string argumentName, string message = null)
    {
        ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
            argument <= 0,
            argumentName, argument, message ?? $"The given number ({nameof(argument)} = {argument}) should be negative or zero.");
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
    public static void ShouldBeNegativeOrZero(int? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
    {
        ShouldBeNegativeOrZero(NumericGuardHelper.N(argument, options, argumentName, message).SafeValue(), argumentName, message);
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
    public static void ShouldBeWithinRange(int argument, int min, int max, string argumentName, string message = null)
    {
        ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
            NumericJudge.IsBetween(argument, min, max),
            argumentName, argument, message ?? $"The given number ({nameof(argument)} = {argument}) should be between [{min}, {max}].");
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
    public static void ShouldBeWithinRange(int? argument, int min, int max, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
    {
        ShouldBeWithinRange(NumericGuardHelper.N(argument, options, argumentName, message).SafeValue(), min, max, argumentName, message);
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
    public static void ShouldBePositive(long argument, string argumentName, string message = null)
    {
        ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
            argument > 0,
            argumentName, argument, message ?? $"The given number ({nameof(argument)} = {argument}) should be positive.");
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
    public static void ShouldBePositive(long? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
    {
        ShouldBePositive(NumericGuardHelper.N(argument, options, argumentName, message).SafeValue(), argumentName, message);
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
    public static void ShouldBePositiveOrZero(long argument, string argumentName, string message = null)
    {
        ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
            argument >= 0,
            argumentName, argument, message ?? $"The given number ({nameof(argument)} = {argument}) should be positive or zero.");
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
    public static void ShouldBePositiveOrZero(long? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
    {
        ShouldBePositiveOrZero(NumericGuardHelper.N(argument, options, argumentName, message).SafeValue(), argumentName, message);
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
    public static void ShouldBeNegative(long argument, string argumentName, string message = null)
    {
        ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
            argument < 0,
            argumentName, argument, message ?? $"The given number ({nameof(argument)} = {argument}) should be negative.");
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
    public static void ShouldBeNegative(long? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
    {
        ShouldBeNegative(NumericGuardHelper.N(argument, options, argumentName, message).SafeValue(), argumentName, message);
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
    public static void ShouldBeNegativeOrZero(long argument, string argumentName, string message = null)
    {
        ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
            argument <= 0,
            argumentName, argument, message ?? $"The given number ({nameof(argument)} = {argument}) should be negative or zero.");
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
    public static void ShouldBeNegativeOrZero(long? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
    {
        ShouldBeNegativeOrZero(NumericGuardHelper.N(argument, options, argumentName, message).SafeValue(), argumentName, message);
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
    public static void ShouldBeWithinRange(long argument, long min, long max, string argumentName, string message = null)
    {
        ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
            NumericJudge.IsBetween(argument, min, max),
            argumentName, argument, message ?? $"The given number ({nameof(argument)} = {argument}) should be between [{min}, {max}].");
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
    public static void ShouldBeWithinRange(long? argument, long min, long max, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
    {
        ShouldBeWithinRange(NumericGuardHelper.N(argument, options, argumentName, message).SafeValue(), min, max, argumentName, message);
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
    public static void ShouldBePositive(float argument, string argumentName, string message = null)
    {
        ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
            argument > 0,
            argumentName, argument, message ?? $"The given number ({nameof(argument)} = {argument}) should be positive.");
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
    public static void ShouldBePositive(float? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
    {
        ShouldBePositive(NumericGuardHelper.N(argument, options, argumentName, message).SafeValue(), argumentName, message);
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
    public static void ShouldBePositiveOrZero(float argument, string argumentName, string message = null)
    {
        ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
            argument >= 0,
            argumentName, argument, message ?? $"The given number ({nameof(argument)} = {argument}) should be positive or zero.");
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
    public static void ShouldBePositiveOrZero(float? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
    {
        ShouldBePositiveOrZero(NumericGuardHelper.N(argument, options, argumentName, message).SafeValue(), argumentName, message);
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
    public static void ShouldBeNegative(float argument, string argumentName, string message = null)
    {
        ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
            argument < 0,
            argumentName, argument, message ?? $"The given number ({nameof(argument)} = {argument}) should be negativev.");
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
    public static void ShouldBeNegative(float? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
    {
        ShouldBeNegative(NumericGuardHelper.N(argument, options, argumentName, message).SafeValue(), argumentName, message);
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
    public static void ShouldBeNegativeOrZero(float argument, string argumentName, string message = null)
    {
        ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
            argument <= 0,
            argumentName, argument, message ?? $"The given number ({nameof(argument)} = {argument}) should be negative or zero.");
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
    public static void ShouldBeNegativeOrZero(float? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
    {
        ShouldBeNegativeOrZero(NumericGuardHelper.N(argument, options, argumentName, message).SafeValue(), argumentName, message);
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
    public static void ShouldBeWithinRange(float argument, float min, float max, string argumentName, string message = null)
    {
        ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
            NumericJudge.IsBetween(argument, min, max),
            argumentName, argument, message ?? $"The given number ({nameof(argument)} = {argument}) should be between [{min}, {max}].");
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
    public static void ShouldBeWithinRange(float? argument, float min, float max, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
    {
        ShouldBeWithinRange(NumericGuardHelper.N(argument, options, argumentName, message).SafeValue(), min, max, argumentName, message);
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
    public static void ShouldBePositive(double argument, string argumentName, string message = null)
    {
        ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
            argument > 0,
            argumentName, argument, message ?? $"The given number ({nameof(argument)} = {argument}) should be positive.");
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
    public static void ShouldBePositive(double? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
    {
        ShouldBePositive(NumericGuardHelper.N(argument, options, argumentName, message).SafeValue(), argumentName, message);
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
    public static void ShouldBePositiveOrZero(double argument, string argumentName, string message = null)
    {
        ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
            argument >= 0,
            argumentName, argument, message ?? $"The given number ({nameof(argument)} = {argument}) should be positive or zero.");
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
    public static void ShouldBePositiveOrZero(double? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
    {
        ShouldBePositiveOrZero(NumericGuardHelper.N(argument, options, argumentName, message).SafeValue(), argumentName, message);
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
    public static void ShouldBeNegative(double argument, string argumentName, string message = null)
    {
        ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
            argument < 0,
            argumentName, argument, message ?? $"The given number ({nameof(argument)} = {argument}) should be negative.");
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
    public static void ShouldBeNegative(double? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
    {
        ShouldBeNegative(NumericGuardHelper.N(argument, options, argumentName, message).SafeValue(), argumentName, message);
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
    public static void ShouldBeNegativeOrZero(double argument, string argumentName, string message = null)
    {
        ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
            argument <= 0,
            argumentName, argument, message ?? $"The given number ({nameof(argument)} = {argument}) should be negative or zero.");
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
    public static void ShouldBeNegativeOrZero(double? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
    {
        ShouldBeNegativeOrZero(NumericGuardHelper.N(argument, options, argumentName, message).SafeValue(), argumentName, message);
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
    public static void ShouldBeWithinRange(double argument, double min, double max, string argumentName, string message = null)
    {
        ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
            NumericJudge.IsBetween(argument, min, max),
            argumentName, argument, message ?? $"The given number ({nameof(argument)} = {argument}) should be between [{min}, {max}].");
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
    public static void ShouldBeWithinRange(double? argument, double min, double max, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
    {
        ShouldBeWithinRange(NumericGuardHelper.N(argument, options, argumentName, message).SafeValue(), min, max, argumentName, message);
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
    public static void ShouldBePositive(decimal argument, string argumentName, string message = null)
    {
        ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
            argument > 0, argumentName, argument, message ?? $"The given number ({nameof(argument)} = {argument}) should be positive.");
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
    public static void ShouldBePositive(decimal? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
    {
        ShouldBePositive(NumericGuardHelper.N(argument, options, argumentName, message).SafeValue(), argumentName, message);
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
    public static void ShouldBePositiveOrZero(decimal argument, string argumentName, string message = null)
    {
        ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
            argument >= 0,
            argumentName, argument, message ?? $"The given number ({nameof(argument)} = {argument}) should be positive or zero.");
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
    public static void ShouldBePositiveOrZero(decimal? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
    {
        ShouldBePositiveOrZero(NumericGuardHelper.N(argument, options, argumentName, message).SafeValue(), argumentName, message);
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
    public static void ShouldBeNegative(decimal argument, string argumentName, string message = null)
    {
        ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
            argument < 0,
            argumentName, argument, message ?? $"The given number ({nameof(argument)} = {argument}) should be negative.");
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
    public static void ShouldBeNegative(decimal? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
    {
        ShouldBeNegative(NumericGuardHelper.N(argument, options, argumentName, message).SafeValue(), argumentName, message);
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
    public static void ShouldBeNegativeOrZero(decimal argument, string argumentName, string message = null)
    {
        ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
            argument <= 0,
            argumentName, argument, message ?? $"The given number ({nameof(argument)} = {argument}) should be negative or zero.");
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
    public static void ShouldBeNegativeOrZero(decimal? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
    {
        ShouldBeNegativeOrZero(NumericGuardHelper.N(argument, options, argumentName, message).SafeValue(), argumentName, message);
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
    public static void ShouldBeWithinRange(decimal argument, decimal min, decimal max, string argumentName, string message = null)
    {
        ValidationExceptionHelper.WrapAndRaise<ArgumentOutOfRangeException>(
            NumericJudge.IsBetween(argument, min, max),
            argumentName, argument, message ?? $"The given number ({nameof(argument)} = {argument}) should be between [{min}, {max}].");
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
    public static void ShouldBeWithinRange(decimal? argument, decimal min, decimal max, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
    {
        ShouldBeWithinRange(NumericGuardHelper.N(argument, options, argumentName, message).SafeValue(), min, max, argumentName, message);
    }
}

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
    public static void RequireWithinRange(this int argument, int min, int max, string argumentName, string message = null)
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
    public static void RequireWithinRange(this int? argument, int min, int max, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void RequirePositiveOrZero(this int argument, string argumentName, string message = null)
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
    public static void RequirePositiveOrZero(this int? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void RequirePositive(this int argument, string argumentName, string message = null)
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
    public static void RequirePositive(this int? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void RequireNegativeOrZero(this int argument, string argumentName, string message = null)
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
    public static void RequireNegativeOrZero(this int? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void RequireNegative(this int argument, string argumentName, string message = null)
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
    public static void RequireNegative(this int? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void RequireWithinRange(this long argument, long min, long max, string argumentName, string message = null)
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
    public static void RequireWithinRange(this long? argument, long min, long max, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void RequirePositiveOrZero(this long argument, string argumentName, string message = null)
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
    public static void RequirePositiveOrZero(this long? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void RequirePositive(this long argument, string argumentName, string message = null)
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
    public static void RequirePositive(this long? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void RequireNegativeOrZero(this long argument, string argumentName, string message = null)
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
    public static void RequireNegativeOrZero(this long? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void RequireNegative(this long argument, string argumentName, string message = null)
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
    public static void RequireNegative(this long? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void RequireWithinRange(this float argument, float min, float max, string argumentName, string message = null)
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
    public static void RequireWithinRange(this float? argument, float min, float max, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void RequirePositiveOrZero(this float argument, string argumentName, string message = null)
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
    public static void RequirePositiveOrZero(this float? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void RequirePositive(this float argument, string argumentName, string message = null)
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
    public static void RequirePositive(this float? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void RequireNegativeOrZero(this float argument, string argumentName, string message = null)
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
    public static void RequireNegativeOrZero(this float? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void RequireNegative(this float argument, string argumentName, string message = null)
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
    public static void RequireNegative(this float? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void RequireWithinRange(this double argument, double min, double max, string argumentName, string message = null)
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
    public static void RequireWithinRange(this double? argument, double min, double max, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void RequirePositiveOrZero(this double argument, string argumentName, string message = null)
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
    public static void RequirePositiveOrZero(this double? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void RequirePositive(this double argument, string argumentName, string message = null)
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
    public static void RequirePositive(this double? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void RequireNegativeOrZero(this double argument, string argumentName, string message = null)
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
    public static void RequireNegativeOrZero(this double? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void RequireNegative(this double argument, string argumentName, string message = null)
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
    public static void RequireNegative(this double? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void RequireWithinRange(this decimal argument, decimal min, decimal max, string argumentName, string message = null)
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
    public static void RequireWithinRange(this decimal? argument, decimal min, decimal max, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void RequirePositiveOrZero(this decimal argument, string argumentName, string message = null)
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
    public static void RequirePositiveOrZero(this decimal? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void RequirePositive(this decimal argument, string argumentName, string message = null)
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
    public static void RequirePositive(this decimal? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void RequireNegativeOrZero(this decimal argument, string argumentName, string message = null)
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
    public static void RequireNegativeOrZero(this decimal? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void RequireNegative(this decimal argument, string argumentName, string message = null)
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
    public static void RequireNegative(this decimal? argument, string argumentName, string message = null, NumericMayOptions options = NumericMayOptions.Default)
    {
        NumericGuard.ShouldBeNegative(argument, argumentName, message, options);
    }
}