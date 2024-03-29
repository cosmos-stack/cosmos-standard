using Cosmos.Conversions.Common.Core;

namespace Cosmos.EnumUtils;

/// <summary>
/// Enum Convertor <br />S
/// 枚举转换器
/// </summary>
public static class EnumConv
{
    /// <summary>
    /// Convert <see cref="string"/> to TEnum. <br />
    /// 将字符串转换为给定类型的枚举值
    /// </summary>
    /// <param name="member"></param>
    /// <param name="ignoreCase"></param>
    /// <param name="defaultVal"></param>
    /// <typeparam name="TEnum"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TEnum ToEnum<TEnum>(string member, bool ignoreCase = false, TEnum defaultVal = default) where TEnum : struct, Enum
    {
        return EnumConvX.StringToEnum(member, defaultVal, ignoreCase);
    }

    /// <summary>
    /// Convert <see cref="string"/> to the given type enum. <br />
    /// 将字符串转换为给定类型的枚举值
    /// </summary>
    /// <param name="member"></param>
    /// <param name="enumType"></param>
    /// <param name="ignoreCase"></param>
    /// <param name="defaultVal"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static object ToEnum(string member, Type enumType, bool ignoreCase = false, object defaultVal = default)
    {
        return EnumConvX.StringToEnum(member, enumType, defaultVal, ignoreCase);
    }

    /// <summary>
    /// Convert <see cref="object"/> to TEnum. <br />
    /// 将对象转换为给定类型的枚举值
    /// </summary>
    /// <param name="member"></param>
    /// <param name="defaultVal"></param>
    /// <typeparam name="TEnum"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TEnum ToEnum<TEnum>(object member, TEnum defaultVal = default) where TEnum : struct, Enum
    {
        return EnumConvX.ObjToEnum(member, defaultVal);
    }

    /// <summary>
    /// Convert <see cref="object"/> to the given type enum. <br />
    /// 将对象转换为给定类型的枚举值
    /// </summary>
    /// <param name="member"></param>
    /// <param name="enumType"></param>
    /// <param name="defaultVal"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static object ToEnum(object member, Type enumType, object defaultVal = default)
    {
        return EnumConvX.ObjToEnum(member, enumType, defaultVal);
    }
}