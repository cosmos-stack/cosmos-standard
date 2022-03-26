﻿using System.Reflection;

namespace Cosmos;

/// <summary>
/// Random extensions<br />
/// 随机数扩展方法
/// </summary>
public static class RandomExtensions
{
    /// <summary>
    /// Random returns true or false.<br />
    /// 随机返回 True 或 False
    /// </summary>
    /// <param name="random"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool NextBool(this Random random) => random.Next() % 2 == 1;

    /// <summary>
    /// Random returns a member of the given enum<br />
    /// 随机返回一个指定的枚举对象的成员
    /// </summary>
    /// <typeparam name="T"> 枚举 </typeparam>
    /// <param name="random"></param>
    /// <returns> 枚举对象的成员 </returns>
    public static T NextEnum<T>(this Random random) where T : struct
    {
        var type = typeof(T);
        if (!type.GetTypeInfo().IsEnum)
            throw new InvalidOperationException();
        var array = Enum.GetValues(type);
        var index = random.Next(array.GetLowerBound(0), array.GetUpperBound(0) + 1);
        // ReSharper disable once PossibleNullReferenceException
        var val = array.GetValue(index);
        return val is null ? default : (T)val;
    }

    /// <summary>
    /// 用随机数填充指定字节数组的元素。
    /// </summary>
    /// <param name="random"></param>
    /// <param name="length"> 字节长度 </param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static byte[] NextBytes(this Random random, int length)
    {
        var data = new byte[length];
        random.NextBytes(data);
        return data;
    }

    /// <summary>
    /// 随机返回一个无符号八位整数。
    /// </summary>
    /// <param name="random"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ushort NextUInt16(this Random random) =>
        BitConverter.ToUInt16(random.NextBytes(2), 0);

    /// <summary>
    /// 随机返回一个有符号十六位整数
    /// </summary>
    /// <param name="random"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static short NextInt16(this Random random) =>
        BitConverter.ToInt16(random.NextBytes(2), 0);

    /// <summary>
    /// 随机返回一个单精度浮点数
    /// </summary>
    /// <param name="random"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float NextFloat(this Random random) =>
        BitConverter.ToSingle(random.NextBytes(4), 0);

    /// <summary>
    /// 在指定范围内随机返回一个时间
    /// </summary>
    /// <param name="random">  </param>
    /// <param name="minValue"> 时间起始 </param>
    /// <param name="maxValue"> 时间截止 </param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime NextDateTime(this Random random, DateTime minValue, DateTime maxValue) =>
        new(minValue.Ticks + (long)((maxValue.Ticks - minValue.Ticks) * random.NextDouble()));

    /// <summary>
    /// 随机返回一个时间
    /// </summary>
    /// <param name="random"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static DateTime NextDateTime(this Random random) =>
        NextDateTime(random, DateTime.MinValue, DateTime.MaxValue);

    /// <summary>
    /// 随机获得一个指定范围的结果
    /// </summary>
    /// <param name="this"></param>
    /// <param name="values"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T OneOf<T>(this Random @this, params T[] values) =>
        values[@this.Next(values.Length)];
}