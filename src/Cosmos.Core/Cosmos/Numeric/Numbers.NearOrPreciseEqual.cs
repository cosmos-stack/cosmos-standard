﻿using System.Diagnostics.Contracts;

namespace Cosmos.Numeric;

/// <summary>
/// Number Utilities <br />
/// 数值工具
/// </summary>
public static partial class Numbers
{
    /// <summary>
    /// Shortcut for validating a if a floating point value is considered zero (within epsilon tolerance). <br />
    /// 如果浮点值被视为零（在 Epsilon 容差内），则验证 a 的快捷方式。
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsZeroValue(float value)
    {
        return IsPreciseEqual(value, 0f);
    }

    /// <summary>
    /// Shortcut for validating a if a double tolerance floating point value is considered zero (within epsilon tolerance). <br />
    /// 如果双容差浮点值被视为零（在 Epsilon 容差内），则验证 a 的快捷方式。
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsZeroValue(double value)
    {
        return IsPreciseEqual(value, 0d);
    }

    /// <summary>
    /// Shortcut for validating a if a double tolerance floating point value is considered zero (within provided tolerance). <br />
    /// 如果双容差浮点值被视为零（在提供的容差内），则验证 a 的快捷方式。
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNearZeroValue(double value, double precision = 0.001)
    {
        return IsNearEqual(value, 0d, precision);
    }

    /// <summary>
    /// Shortcut for validating a if a floating point value is close enough to another addValue using the given tolerance tolerance. <br />
    /// 使用给定的容差来验证浮点值是否足够接近另一个 addValue 的快捷方式。
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNearEqual(float a, float b, float tolerance)
    {
        return a.Equals(b) || float.IsNaN(a) && float.IsNaN(b) || Math.Abs(a - b) < tolerance;
    }

    /// <summary>
    /// Shortcut for validating a if a double precision floating point value is close enough to another addValue using the given tolerance tolerance. <br />
    /// 使用给定的容差来验证双精度浮点值是否足够接近另一个 addValue 的快捷方式。
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNearEqual(double a, double b, double tolerance)
    {
        return a.Equals(b) || double.IsNaN(a) && double.IsNaN(b) || Math.Abs(a - b) < tolerance;
    }

    /// <summary>
    /// Shortcut for validating a if a decimal addValue is close enough to another addValue using the given tolerance tolerance. <br />
    /// 使用给定的容差来验证一个十进制 addValue 是否足够接近另一个 addValue 的快捷方式。
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNearEqual(decimal a, decimal b, decimal tolerance)
    {
        return a.Equals(b) || Math.Abs(a - b) < tolerance;
    }

    /// <summary>
    /// Shortcut for validating a if a decimal addValue is close enough to another addValue using the given tolerance tolerance. <br />
    /// 使用给定的容差来验证一个十进制 addValue 是否足够接近另一个 addValue 的快捷方式。
    /// </summary>
    public static bool IsRelativeNearEqual(double a, double b, uint minDecimalPlaces)
    {
        var tolerance = 1 / Math.Pow(10, minDecimalPlaces);
        if (IsNearEqual(a, b, tolerance)) return true;
        if (double.IsNaN(a) || double.IsNaN(b)) return false;
        var d = Math.Min(GetDecimalPlaces(a), GetDecimalPlaces(b));
        var divisor = Math.Pow(10, minDecimalPlaces - d);
        a /= divisor;
        b /= divisor;
        return IsNearEqual(a, b, tolerance);
    }

    /// <summary>
    /// Validates if values are equal within epsilon tolerance. <br />
    /// 验证值是否在 epsilon 容差内相等。
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsPreciseEqual(double a, double b, bool stringValidate = false)
    {
        return IsNearEqual(a, b, double.Epsilon)
            || (stringValidate && !double.IsNaN(a) && !double.IsNaN(b) && a.ToString(CultureInfo.InvariantCulture) == b.ToString(CultureInfo.InvariantCulture));
    }

    /// <summary>
    /// Validates if values are equal within epsilon tolerance. <br />
    /// 验证值是否在 epsilon 容差内相等。
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsPreciseEqual(float a, float b, bool stringValidate = false)
    {
        return IsNearEqual(a, b, float.Epsilon) ||
               (stringValidate && !float.IsNaN(a) && !float.IsNaN(b) && a.ToString(CultureInfo.InvariantCulture) == b.ToString(CultureInfo.InvariantCulture));
    }

    /// <summary>
    /// Validates if values are equal within epsilon tolerance. <br />
    /// 验证值是否在 epsilon 容差内相等。
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsPreciseEqual(double? a, double? b, bool stringValidate = false)
    {
        return !a.HasValue && !b.HasValue || a.HasValue && b.HasValue && IsPreciseEqual(a.Value, b.Value, stringValidate);
    }

    /// <summary>
    /// Validates if values are equal within epsilon tolerance. <br />
    /// 验证值是否在 epsilon 容差内相等。
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsPreciseEqual(float? a, float? b, bool stringValidate = false)
    {
        return !a.HasValue && !b.HasValue || a.HasValue && b.HasValue && IsPreciseEqual(a.Value, b.Value, stringValidate);
    }

    /// <summary>
    /// Shortcut for validating a if a potential floating point value is close enough to another addValue using the given tolerance tolerance. <br />
    /// 使用给定的容差来验证潜在浮点值是否足够接近另一个 addValue 的快捷方式。
    /// </summary>
    public static bool IsNearEqual(IComparable a, IComparable b, IComparable tolerance)
    {
        if (a is null)
            throw new NullReferenceException();
        if (b is null)
            throw new ArgumentNullException(nameof(b));

        Contract.EndContractBlock();

        if (a.Equals(b))
            return true;

        return a switch
        {
            float f => IsNearEqual(f, (float)b, (float)tolerance),
            double d => IsNearEqual(d, (double)b, (double)tolerance),
            decimal @decimal => IsNearEqual(@decimal, (decimal)b, (decimal)tolerance),
            _ => throw new InvalidCastException(),
        };
    }
}

/// <summary>
/// Extensions for number utilities <br />
/// 数值工具扩展
/// </summary>
public static partial class NumberExtensions
{
    /// <summary>
    /// Shortcut for validating a if a floating point value is considered zero (within epsilon tolerance). <br />
    /// 如果双容差浮点值被视为零（在提供的容差内），则验证 a 的快捷方式。
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsZero(this float value) => Numbers.IsNearZeroValue(value);

    /// <summary>
    /// Shortcut for validating a if a double tolerance floating point value is considered zero (within epsilon tolerance). <br />
    /// 如果双容差浮点值被视为零（在提供的容差内），则验证 a 的快捷方式。
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsZero(this double value) => Numbers.IsNearZeroValue(value);

    /// <summary>
    /// Shortcut for validating a if a double tolerance floating point value is considered zero (within provided tolerance). <br />
    /// 如果双容差浮点值被视为零（在提供的容差内），则验证 a 的快捷方式。
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNearZero(this double value, double precision = 0.001) => Numbers.IsNearZeroValue(value, precision);

    /// <summary>
    /// Shortcut for validating a if a floating point value is close enough to another addValue using the given tolerance tolerance. <br />
    /// 使用给定的容差来验证浮点值是否足够接近另一个 addValue 的快捷方式。
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNearEqual(this float a, float b, float tolerance) => Numbers.IsNearEqual(a, b, tolerance);

    /// <summary>
    /// Shortcut for validating a if a double precision floating point value is close enough to another addValue using the given tolerance tolerance. <br />
    /// 使用给定的容差来验证双精度浮点值是否足够接近另一个 addValue 的快捷方式。
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNearEqual(this double a, double b, double tolerance) => Numbers.IsNearEqual(a, b, tolerance);

    /// <summary>
    /// Shortcut for validating a if a decimal addValue is close enough to another addValue using the given tolerance tolerance. <br />
    /// 使用给定的容差来验证一个十进制 addValue 是否足够接近另一个 addValue 的快捷方式。
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNearEqual(this decimal a, decimal b, decimal tolerance) => Numbers.IsNearEqual(a, b, tolerance);

    /// <summary>
    /// Shortcut for validating a if a decimal addValue is close enough to another addValue using the given tolerance tolerance. <br />
    /// 使用给定的容差来验证一个十进制 addValue 是否足够接近另一个 addValue 的快捷方式。
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsRelativeNearEqual(this double a, double b, uint minDecimalPlaces) => Numbers.IsRelativeNearEqual(a, b, minDecimalPlaces);

    /// <summary>
    /// Validates if values are equal within epsilon tolerance. <br />
    /// 验证值是否在 epsilon 容差内相等。
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsPreciseEqual(this double a, double b, bool stringValidate = false) => Numbers.IsPreciseEqual(a, b, stringValidate);

    /// <summary>
    /// Validates if values are equal within epsilon tolerance. <br />
    /// 验证值是否在 epsilon 容差内相等。
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsPreciseEqual(this float a, float b, bool stringValidate = false) => Numbers.IsPreciseEqual(a, b, stringValidate);

    /// <summary>
    /// Validates if values are equal within epsilon tolerance. <br />
    /// 验证值是否在 epsilon 容差内相等。
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsPreciseEqual(this double? a, double? b, bool stringValidate = false) => Numbers.IsPreciseEqual(a, b, stringValidate);

    /// <summary>
    /// Validates if values are equal within epsilon tolerance. <br />
    /// 验证值是否在 epsilon 容差内相等。
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsPreciseEqual(this float? a, float? b, bool stringValidate = false) => Numbers.IsPreciseEqual(a, b, stringValidate);
}