using System.Reflection;

namespace Cosmos.Reflection;

/// <summary>
/// Reflection Utilities. <br />
/// 反射工具
/// </summary>
public static partial class TypeReflections
{
    private static bool X(MemberInfo member, Func<Type, Type> typeClear, Func<Type, bool> typeInfer)
    {
        return member switch
        {
            null => false,
            Type type => typeInfer(typeClear(type)),
            PropertyInfo propertyInfo => typeInfer(typeClear(propertyInfo.PropertyType)),
            FieldInfo fieldInfo => typeInfer(typeClear(fieldInfo.FieldType)),
            _ => false
        };
    }

    private static Type N(Type type, TypeIsOptions isOptions = TypeIsOptions.Default)
    {
        return isOptions switch
        {
            TypeIsOptions.Default => type,
            TypeIsOptions.IgnoreNullable => TypeConv.GetNonNullableType(type),
            _ => type
        };
    }

    /// <summary>
    /// Determine whether the given MemberInfo is a Boolean type.<br />
    /// 判断给定的 MemberInfo 元信息是否为布尔类型。
    /// </summary>
    /// <param name="isOptions"></param>
    /// <param name="member">成员</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsBoolean(MemberInfo member, TypeIsOptions isOptions = TypeIsOptions.Default)
    {
        return X(member, type => N(type, isOptions), type => type == TypeClass.BooleanClazz);
    }

    /// <summary>
    /// Determine whether the given MemberInfo is a datetime.<br />
    /// 判断给定的 MemberInfo 元信息是否为 DateTime 类型。
    /// </summary>
    /// <param name="isOptions"></param>
    /// <param name="member">成员</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsDateTime(MemberInfo member, TypeIsOptions isOptions = TypeIsOptions.Default)
    {
        return X(member, type => N(type, isOptions), type => type == TypeClass.DateTimeClazz);
    }

    /// <summary>
    /// Determine whether the given MemberInfo is a numeric type.<br />
    /// 判断给定的 MemberInfo 元信息是否为数字类型。
    /// </summary>
    /// <param name="member">成员</param>
    /// <param name="isOptions"></param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsNumeric(MemberInfo member, TypeIsOptions isOptions = TypeIsOptions.Default)
    {
        return X(member, type => type, type => Types.IsNumericType(type, isOptions));
    }

    /// <summary>
    /// Determine whether the given MemberInfo is an enum type.<br />
    /// 判断给定的 MemberInfo 元信息是否为枚举类型。
    /// </summary>
    /// <param name="member"></param>
    /// <param name="isOptions"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsEnum(MemberInfo member, TypeIsOptions isOptions = TypeIsOptions.Default)
    {
        return X(member, type => type, type => Types.IsEnumType(type, isOptions));
    }

    /// <summary>
    /// Determine whether the given MemberInfo is a struct type.<br />
    /// 判断给定的 MemberInfo 元信息是否为结构类型。
    /// </summary>
    /// <param name="member"></param>
    /// <param name="isOptions"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsStruct(MemberInfo member, TypeIsOptions isOptions = TypeIsOptions.Default)
    {
        return X(member, type => type, type => Types.IsStructType(type, isOptions));
    }

    /// <summary>
    /// Determine whether the given MemberInfo is a primitive type.<br />
    /// 判断给定的 MemberInfo 元信息是否为原始类型。
    /// </summary>
    /// <param name="member"></param>
    /// <param name="isOptions"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsPrimitive(MemberInfo member, TypeIsOptions isOptions = TypeIsOptions.Default)
    {
        return X(member, type => type, type => Types.IsPrimitiveType(type, isOptions));
    }

    /// <summary>
    /// Determine whether the given MemberInfo is a value type.<br />
    /// 判断给定的 MemberInfo 元信息是否为值类型。
    /// </summary>
    /// <param name="member"></param>
    /// <param name="isOptions"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsValueType(MemberInfo member, TypeIsOptions isOptions = TypeIsOptions.Default)
    {
        return X(member, type => type, type => Types.IsValueType(type, isOptions));
    }

    /// <summary>
    /// Determine whether the given type is a collection or array type.<br />
    /// 判断给定的类型是否为集合或数组类型。
    /// </summary>
    /// <param name="member"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsCollection(MemberInfo member)
    {
        return X(member, type => type, Types.IsCollectionType);
    }
}