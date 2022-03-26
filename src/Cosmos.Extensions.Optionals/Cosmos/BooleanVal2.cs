namespace Cosmos;

/// <summary>
/// Two-Value Boolean <br />
/// 双值布尔值
/// </summary>
public class BooleanVal2 : UnionOf<BooleanVal2.True, BooleanVal2.False>
{
    private BooleanVal2(UnionType<True, False> input) : base(input) { }

    #region Values

    /// <summary>
    /// True Value
    /// </summary>
    public class True : ValueOf<bool, True>
    {
        public static True Instance { get; } = From(true);

        public static implicit operator bool(True _) => true;
    }

    /// <summary>
    /// False Value
    /// </summary>
    public class False : ValueOf<bool, False>
    {
        public static False Instance { get; } = From(false);

        public static implicit operator bool(False _) => false;
    }

    #endregion

    #region Value Shortcut

    /// <summary>
    /// True Value
    /// </summary>
    public static bool TrueValue => true;

    /// <summary>
    /// False Value
    /// </summary>
    public static bool FalseValue => false;

    #endregion

    #region Value Instances

    /// <summary>
    /// True Value
    /// </summary>
    public static BooleanVal2 TrueVal => True.Instance;

    /// <summary>
    /// False Value
    /// </summary>
    public static BooleanVal2 FalseVal => False.Instance;

    #endregion

    #region Implicit Opts

    public static implicit operator BooleanVal2(True input) => new(input);

    public static implicit operator BooleanVal2(False input) => new(input);

    public static implicit operator BooleanVal2(bool value) => new(X(value));

    public static implicit operator bool(BooleanVal2 value)
    {
        if (value.IsT0()) return value.AsT0();
        if (value.IsT1()) return value.AsT1();
        return false;
    }

    #endregion

    #region Static Methods

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static UnionType<True, False> X(bool v)
    {
        if (v)
            return True.Instance;
        return False.Instance;
    }

    /// <summary>
    /// And operator
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool And(bool left, bool right)
    {
        return left && right;
    }

    /// <summary>
    /// And operator
    /// </summary>
    /// <param name="left"></param>
    /// <param name="rights"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool And(bool left, params bool[] rights)
    {
        return left && rights.All(x => x);
    }

    /// <summary>
    /// Or operator
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Or(bool left, bool right)
    {
        return left || right;
    }

    /// <summary>
    /// Or operator
    /// </summary>
    /// <param name="left"></param>
    /// <param name="rights"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Or(bool left, params bool[] rights)
    {
        return left || rights.Any(x => x);
    }

    /// <summary>
    /// Same operator
    /// </summary>
    /// <param name="left"></param>
    /// <param name="right"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Same(bool left, bool right)
    {
        return left == right;
    }

    #endregion
}

/// <summary>
/// Two-Value Boolean Extensions <br />
/// 双值布尔值扩展
/// </summary>
public static class BooleanVal2Extensions
{
    /// <summary>
    /// Convert boolean to Two-Value Boolean <br />
    /// 将普通布尔值转换为双值布尔值
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static BooleanVal2 ToBooleanVal2(this bool value) => value;

    /// <summary>
    /// Convert boolean to Two-Value Boolean <br />
    /// 将普通布尔值转换为双值布尔值
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static BooleanVal2 ToBooleanVal2(this bool? value) => value.HasValue ? value.Value : BooleanVal2.FalseVal;
}