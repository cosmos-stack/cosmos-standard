namespace Cosmos.Collections;

/// <summary>
/// Array Judgement <br />
/// 数组检查器
/// </summary>
public static class ArrayJudge
{
    /// <summary>
    /// In a one-dimensional array, determine whether the given index value will exceed the upper and lower bounds of the array.
    /// If it exceeds, it returns false. <br />
    /// 在一维数组中，判断给定的索引值是否会超出数组上下界。如果超出则返回 false。
    /// </summary>
    /// <param name="array"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsIndexInRange(Array array, int index)
    {
        return index >= 0 && index < array.Length;
    }

    /// <summary>
    /// In a multidimensional array, determine whether the given index value will exceed the upper and lower bounds on the specified dimension of the array.
    /// If it exceeds, it returns false.<br />
    /// If the dimension value exceeds the bounds, an exception is thrown. <br />
    /// 在多维数组中，判断给定的索引值是否会超出数组指定维度上的上下界。如果超出则返回 false。 <br />
    /// 如果维度值超界，则抛出异常。
    /// </summary>
    /// <param name="array"></param>
    /// <param name="index"></param>
    /// <param name="dimension"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsIndexInRange(Array array, int index, int dimension)
    {
        if (dimension <= 0) throw new ArgumentOutOfRangeException(nameof(dimension));
        return index >= array.GetLowerBound(dimension) && index <= array.GetUpperBound(dimension);
    }
}

/// <summary>
/// Array Judgement Extensions<br />
/// 数组检查器扩展
/// </summary>
public static class ArrayJudgeExtensions { }