﻿namespace Cosmos.Numeric;

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
    public static void ShouldBePositive(int argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null)
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
    public static void ShouldBePositive(int? argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void ShouldBePositiveOrZero(int argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null)
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
    public static void ShouldBePositiveOrZero(int? argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void ShouldBeNegative(int argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null)
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
    public static void ShouldBeNegative(int? argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void ShouldBeNegativeOrZero(int argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null)
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
    public static void ShouldBeNegativeOrZero(int? argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void ShouldBeWithinRange(int argument, int min, int max, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null)
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
    public static void ShouldBeWithinRange(int? argument, int min, int max, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void ShouldBePositive(long argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null)
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
    public static void ShouldBePositive(long? argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void ShouldBePositiveOrZero(long argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null)
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
    public static void ShouldBePositiveOrZero(long? argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void ShouldBeNegative(long argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null)
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
    public static void ShouldBeNegative(long? argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void ShouldBeNegativeOrZero(long argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null)
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
    public static void ShouldBeNegativeOrZero(long? argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void ShouldBeWithinRange(long argument, long min, long max, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null)
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
    public static void ShouldBeWithinRange(long? argument, long min, long max, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void ShouldBePositive(float argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null)
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
    public static void ShouldBePositive(float? argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void ShouldBePositiveOrZero(float argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null)
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
    public static void ShouldBePositiveOrZero(float? argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void ShouldBeNegative(float argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null)
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
    public static void ShouldBeNegative(float? argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void ShouldBeNegativeOrZero(float argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null)
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
    public static void ShouldBeNegativeOrZero(float? argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void ShouldBeWithinRange(float argument, float min, float max, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null)
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
    public static void ShouldBeWithinRange(float? argument, float min, float max, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void ShouldBePositive(double argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null)
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
    public static void ShouldBePositive(double? argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void ShouldBePositiveOrZero(double argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null)
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
    public static void ShouldBePositiveOrZero(double? argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void ShouldBeNegative(double argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null)
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
    public static void ShouldBeNegative(double? argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void ShouldBeNegativeOrZero(double argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null)
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
    public static void ShouldBeNegativeOrZero(double? argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void ShouldBeWithinRange(double argument, double min, double max, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null)
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
    public static void ShouldBeWithinRange(double? argument, double min, double max, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void ShouldBePositive(decimal argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null)
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
    public static void ShouldBePositive(decimal? argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void ShouldBePositiveOrZero(decimal argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null)
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
    public static void ShouldBePositiveOrZero(decimal? argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void ShouldBeNegative(decimal argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null)
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
    public static void ShouldBeNegative(decimal? argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void ShouldBeNegativeOrZero(decimal argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null)
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
    public static void ShouldBeNegativeOrZero(decimal? argument, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
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
    public static void ShouldBeWithinRange(decimal argument, decimal min, decimal max, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null)
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
    public static void ShouldBeWithinRange(decimal? argument, decimal min, decimal max, [CallerArgumentExpression(nameof(argument))] string argumentName = null, string message = null, NumericMayOptions options = NumericMayOptions.Default)
    {
        ShouldBeWithinRange(NumericGuardHelper.N(argument, options, argumentName, message).SafeValue(), min, max, argumentName, message);
    }
}