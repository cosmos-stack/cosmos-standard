using Cosmos.Reflection.Reflectors;

// ReSharper disable PossibleMultipleEnumeration

namespace Cosmos.Reflection;

/// <summary>
/// Reflection options <br />
/// 反射选项
/// </summary>
public enum ReflectionOptions
{
    Default = 0,
    Inherit = 1
}

/// <summary>
/// Reflection Ambiguous options <br />
/// 反射歧义选项
/// </summary>
public enum ReflectionAmbiguousOptions
{
    Default = 0,
    IgnoreAmbiguous = 1
}

internal static class TypeReflectorHelper
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ICustomAttributeReflectorProvider GetReflector(MemberInfo member)
    {
        ArgumentNullException.ThrowIfNull(member);
        return member switch
        {
            TypeInfo typeInfo => typeInfo.GetReflector(),
            Type type => type.GetReflector(),
            FieldInfo field => field.GetReflector(),
            PropertyInfo property => property.GetReflector(),
            MethodInfo method => method.GetReflector(),
            ConstructorInfo constructor => constructor.GetReflector(),
            _ => throw new InvalidOperationException("Current MemberInfo cannot be converted to Reflector.")
        };
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static ICustomAttributeReflectorProvider GetReflector(ParameterInfo parameter)
    {
        return parameter.GetReflector();
    }
}

/// <summary>
/// Reflection Utilities. <br />
/// 反射工具
/// </summary>
public static partial class TypeReflections
{
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static TRequired AttrRequired<TRequired>(this TRequired value, string message)
    {
        return value ?? throw new ArgumentException(message);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static IEnumerable<TRequired> AttrRequired<TRequired>(this IEnumerable<TRequired> value, string message)
    {
        if (value is null || !value.Any())
            throw new ArgumentException(message);
        return value;
    }

#pragma warning disable CS8603

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static TAttribute AttrDisambiguation<TAttribute>(this IEnumerable<TAttribute> value)
    {
        return value is null ? default : value.FirstOrDefault();
    }

#pragma warning restore CS8603

    #region IsAttributeDefined

    /// <summary>
    /// To determine whether the given Attribute is defined.<br />
    /// 判断给定的特性是否定义。
    /// </summary>
    /// <param name="member"></param>
    /// <typeparam name="TAttribute"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsAttributeDefined<TAttribute>(MemberInfo member) where TAttribute : Attribute
    {
        return TypeReflectorHelper.GetReflector(member).IsAttributeDefined<TAttribute>();
    }

    /// <summary>
    /// To determine whether the given Attribute is defined.<br />
    /// 判断给定的特性是否定义。
    /// </summary>
    /// <param name="member"></param>
    /// <param name="options"></param>
    /// <typeparam name="TAttribute"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsAttributeDefined<TAttribute>(MemberInfo member, ReflectionOptions options) where TAttribute : Attribute
    {
        return options switch
        {
            ReflectionOptions.Default => TypeReflectorHelper.GetReflector(member).IsAttributeDefined<TAttribute>(),
            ReflectionOptions.Inherit => member.GetCustomAttributes<TAttribute>(true).Any(),
            _ => member.GetCustomAttributes<TAttribute>().Any()
        };
    }

    /// <summary>
    /// To determine whether the given Attribute is defined.<br />
    /// 判断给定的特性是否定义。
    /// </summary>
    /// <param name="parameter"></param>
    /// <typeparam name="TAttribute"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsAttributeDefined<TAttribute>(ParameterInfo parameter) where TAttribute : Attribute
    {
        return TypeReflectorHelper.GetReflector(parameter).IsAttributeDefined<TAttribute>();
    }

    /// <summary>
    /// To determine whether the given Attribute is defined.<br />
    /// 判断给定的特性是否定义。
    /// </summary>
    /// <param name="parameter"></param>
    /// <param name="options"></param>
    /// <typeparam name="TAttribute"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsAttributeDefined<TAttribute>(ParameterInfo parameter, ReflectionOptions options) where TAttribute : Attribute
    {
        return options switch
        {
            ReflectionOptions.Default => parameter.GetCustomAttributes<TAttribute>().Any(),
            ReflectionOptions.Inherit => TypeReflectorHelper.GetReflector(parameter).IsAttributeDefined<TAttribute>(),
            _ => parameter.GetCustomAttributes<TAttribute>().Any()
        };
    }

    /// <summary>
    /// To determine whether the given Attribute is defined.<br />
    /// 判断给定的特性是否定义。
    /// </summary>
    /// <param name="member"></param>
    /// <param name="attributeType"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsAttributeDefined(MemberInfo member, Type attributeType)
    {
        return TypeReflectorHelper.GetReflector(member).IsAttributeDefined(attributeType);
    }

    /// <summary>
    /// To determine whether the given Attribute is defined.<br />
    /// 判断给定的特性是否定义。
    /// </summary>
    /// <param name="member"></param>
    /// <param name="attributeType"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsAttributeDefined(MemberInfo member, Type attributeType, ReflectionOptions options)
    {
        return options switch
        {
            ReflectionOptions.Default => TypeReflectorHelper.GetReflector(member).IsAttributeDefined(attributeType),
            ReflectionOptions.Inherit => member.GetCustomAttributes(attributeType, true).Any(),
            _ => member.GetCustomAttributes(attributeType).Any()
        };
    }

    /// <summary>
    /// To determine whether the given Attribute is defined.<br />
    /// 判断给定的特性是否定义。
    /// </summary>
    /// <param name="parameter"></param>
    /// <param name="attributeType"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsAttributeDefined(ParameterInfo parameter, Type attributeType)
    {
        return TypeReflectorHelper.GetReflector(parameter).IsAttributeDefined(attributeType);
    }

    /// <summary>
    /// To determine whether the given Attribute is defined.<br />
    /// 判断给定的特性是否定义。
    /// </summary>
    /// <param name="parameter"></param>
    /// <param name="attributeType"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsAttributeDefined(ParameterInfo parameter, Type attributeType, ReflectionOptions options)
    {
        return options switch
        {
            ReflectionOptions.Default => TypeReflectorHelper.GetReflector(parameter).IsAttributeDefined(attributeType),
            ReflectionOptions.Inherit => parameter.GetCustomAttributes(attributeType, true).Any(),
            _ => parameter.GetCustomAttributes(attributeType).Any()
        };
    }

    #endregion

    #region GetAttribute

    /// <summary>
    /// Obtain the specified Attribute instance from the MemberInfo. <br />
    /// 从成员信息中获取指定的 Attribute 实例。
    /// </summary>
    /// <param name="member">Special member</param>
    /// <param name="attributeType"></param>
    /// <returns>Attribute of special field</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Attribute GetAttribute(MemberInfo member, Type attributeType)
    {
        return TypeReflectorHelper.GetReflector(member).GetAttribute(attributeType);
    }

    /// <summary>
    /// Obtain the specified Attribute instance from the ParameterInfo. <br />
    /// 从成员信息中获取指定的 Attribute 实例。
    /// </summary>
    /// <param name="parameter">Special member</param>
    /// <param name="attributeType"></param>
    /// <returns>Attribute of special field</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Attribute GetAttribute(ParameterInfo parameter, Type attributeType)
    {
        return TypeReflectorHelper.GetReflector(parameter).GetAttribute(attributeType);
    }

    /// <summary>
    /// Obtain the specified Attribute instance from the MemberInfo. <br />
    /// 从成员信息中获取指定的 Attribute 实例。
    /// </summary>
    /// <param name="member"></param>
    /// <param name="attributeType"></param>
    /// <param name="refOptions"></param>
    /// <param name="ambOptions"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Attribute GetAttribute(MemberInfo member, Type attributeType, ReflectionOptions refOptions, ReflectionAmbiguousOptions ambOptions = ReflectionAmbiguousOptions.Default)
    {
        return refOptions switch
        {
            ReflectionOptions.Default => TypeReflectorHelper.GetReflector(member).GetAttribute(attributeType),
            ReflectionOptions.Inherit => ambOptions switch
            {
                ReflectionAmbiguousOptions.Default => member.GetCustomAttribute(attributeType, true),
                ReflectionAmbiguousOptions.IgnoreAmbiguous => GetAttributes(member, attributeType, refOptions).AttrDisambiguation(),
                _ => member.GetCustomAttribute(attributeType, true)
            },
            _ => member.GetCustomAttribute(attributeType)
        };
    }

    /// <summary>
    /// Obtain the specified Attribute instance from the ParameterInfo. <br />
    /// 从成员信息中获取指定的 Attribute 实例。
    /// </summary>
    /// <param name="parameter"></param>
    /// <param name="attributeType"></param>
    /// <param name="refOptions"></param>
    /// <param name="ambOptions"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Attribute GetAttribute(ParameterInfo parameter, Type attributeType, ReflectionOptions refOptions, ReflectionAmbiguousOptions ambOptions = ReflectionAmbiguousOptions.Default)
    {
        return refOptions switch
        {
            ReflectionOptions.Default => TypeReflectorHelper.GetReflector(parameter).GetAttribute(attributeType),
            ReflectionOptions.Inherit => ambOptions switch
            {
                ReflectionAmbiguousOptions.Default => parameter.GetCustomAttribute(attributeType, true),
                ReflectionAmbiguousOptions.IgnoreAmbiguous => GetAttributes(parameter, attributeType, refOptions).AttrDisambiguation(),
                _ => parameter.GetCustomAttribute(attributeType, true)
            },
            _ => parameter.GetCustomAttribute(attributeType)
        };
    }

    /// <summary>
    /// Obtain the specified Attribute instance from the MemberInfo. <br />
    /// 从成员信息中获取指定的 Attribute 实例。
    /// </summary>
    /// <param name="member">Special member</param>
    /// <typeparam name="TAttribute">Special typeInfo of member</typeparam>
    /// <returns>Attribute of special field</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TAttribute GetAttribute<TAttribute>(MemberInfo member) where TAttribute : Attribute
    {
        return TypeReflectorHelper.GetReflector(member).GetAttribute<TAttribute>();
    }

    /// <summary>
    /// Obtain the specified Attribute instance from the ParameterInfo. <br />
    /// 从成员信息中获取指定的 Attribute 实例。
    /// </summary>
    /// <param name="parameter">Special member</param>
    /// <typeparam name="TAttribute">Special typeInfo of member</typeparam>
    /// <returns>Attribute of special field</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TAttribute GetAttribute<TAttribute>(ParameterInfo parameter) where TAttribute : Attribute
    {
        return TypeReflectorHelper.GetReflector(parameter).GetAttribute<TAttribute>();
    }

    /// <summary>
    /// Obtain the specified Attribute instance from the MemberInfo. <br />
    /// 从成员信息中获取指定的 Attribute 实例。
    /// </summary>
    /// <param name="member"></param>
    /// <param name="refOptions"></param>
    /// <param name="ambOptions"></param>
    /// <typeparam name="TAttribute"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TAttribute GetAttribute<TAttribute>(MemberInfo member, ReflectionOptions refOptions, ReflectionAmbiguousOptions ambOptions = ReflectionAmbiguousOptions.Default) where TAttribute : Attribute
    {
        return refOptions switch
        {
            ReflectionOptions.Default => TypeReflectorHelper.GetReflector(member).GetAttribute<TAttribute>(),
            ReflectionOptions.Inherit => ambOptions switch
            {
                ReflectionAmbiguousOptions.Default => member.GetCustomAttribute<TAttribute>(true),
                ReflectionAmbiguousOptions.IgnoreAmbiguous => GetAttributes<TAttribute>(member, refOptions).AttrDisambiguation(),
                _ => member.GetCustomAttribute<TAttribute>(true)
            },
            _ => member.GetCustomAttribute<TAttribute>()
        };
    }

    /// <summary>
    /// Obtain the specified Attribute instance from the ParameterInfo. <br />
    /// 从成员信息中获取指定的 Attribute 实例。
    /// </summary>
    /// <param name="parameter"></param>
    /// <param name="refOptions"></param>
    /// <param name="ambOptions"></param>
    /// <typeparam name="TAttribute"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TAttribute GetAttribute<TAttribute>(ParameterInfo parameter, ReflectionOptions refOptions, ReflectionAmbiguousOptions ambOptions = ReflectionAmbiguousOptions.Default) where TAttribute : Attribute
    {
        return refOptions switch
        {
            ReflectionOptions.Default => TypeReflectorHelper.GetReflector(parameter).GetAttribute<TAttribute>(),
            ReflectionOptions.Inherit => ambOptions switch
            {
                ReflectionAmbiguousOptions.Default => parameter.GetCustomAttribute<TAttribute>(true),
                ReflectionAmbiguousOptions.IgnoreAmbiguous => GetAttributes<TAttribute>(parameter, refOptions).AttrDisambiguation(),
                _ => parameter.GetCustomAttribute<TAttribute>(true)
            },
            _ => parameter.GetCustomAttribute<TAttribute>()
        };
    }

    #endregion

    #region GetAttributes

    /// <summary>
    /// Obtain a set of specified Attribute instances from the MemberInfo. <br />
    /// 从成员信息中获取一组指定的 Attribute 实例。
    /// </summary>
    /// <param name="member">Special member</param>
    /// <typeparam name="TAttribute">Special typeInfo of member</typeparam>
    /// <returns>Attribute of special field</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<TAttribute> GetAttributes<TAttribute>(MemberInfo member) where TAttribute : Attribute
    {
        return TypeReflectorHelper.GetReflector(member).GetAttributes<TAttribute>();
    }

    /// <summary>
    /// Obtain a set of specified Attribute instances from the ParameterInfo. <br />
    /// 从成员信息中获取一组指定的 Attribute 实例。
    /// </summary>
    /// <param name="parameter">Special member</param>
    /// <typeparam name="TAttribute">Special typeInfo of member</typeparam>
    /// <returns>Attribute of special field</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<TAttribute> GetAttributes<TAttribute>(ParameterInfo parameter) where TAttribute : Attribute
    {
        return TypeReflectorHelper.GetReflector(parameter).GetAttributes<TAttribute>();
    }

    /// <summary>
    /// Obtain a set of specified Attribute instances from the MemberInfo. <br />
    /// 从成员信息中获取一组指定的 Attribute 实例。
    /// </summary>
    /// <param name="member">Special member</param>
    /// <param name="refOptions"></param>
    /// <typeparam name="TAttribute">Special typeInfo of member</typeparam>
    /// <returns>Attribute of special field</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<TAttribute> GetAttributes<TAttribute>(MemberInfo member, ReflectionOptions refOptions) where TAttribute : Attribute
    {
        return refOptions switch
        {
            ReflectionOptions.Default => TypeReflectorHelper.GetReflector(member).GetAttributes<TAttribute>(),
            ReflectionOptions.Inherit => member.GetCustomAttributes<TAttribute>(true),
            _ => member.GetCustomAttributes<TAttribute>()
        };
    }

    /// <summary>
    /// Obtain a set of specified Attribute instances from the ParameterInfo. <br />
    /// 从成员信息中获取一组指定的 Attribute 实例。
    /// </summary>
    /// <param name="parameter">Special member</param>
    /// <param name="refOptions"></param>
    /// <typeparam name="TAttribute">Special typeInfo of member</typeparam>
    /// <returns>Attribute of special field</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<TAttribute> GetAttributes<TAttribute>(ParameterInfo parameter, ReflectionOptions refOptions) where TAttribute : Attribute
    {
        return refOptions switch
        {
            ReflectionOptions.Default => TypeReflectorHelper.GetReflector(parameter).GetAttributes<TAttribute>(),
            ReflectionOptions.Inherit => parameter.GetCustomAttributes<TAttribute>(true),
            _ => parameter.GetCustomAttributes<TAttribute>()
        };
    }

    /// <summary>
    /// Obtain a set of specified Attribute instances from the MemberInfo. <br />
    /// 从成员信息中获取一组指定的 Attribute 实例。
    /// </summary>
    /// <param name="member">Special member</param>
    /// <param name="attributeType"></param>
    /// <returns>Attribute of special field</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<Attribute> GetAttributes(MemberInfo member, Type attributeType)
    {
        return TypeReflectorHelper.GetReflector(member).GetAttributes(attributeType);
    }

    /// <summary>
    /// Obtain a set of specified Attribute instances from the ParameterInfo. <br />
    /// 从成员信息中获取一组指定的 Attribute 实例。
    /// </summary>
    /// <param name="parameter">Special member</param>
    /// <param name="attributeType"></param>
    /// <returns>Attribute of special field</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<Attribute> GetAttributes(ParameterInfo parameter, Type attributeType)
    {
        return TypeReflectorHelper.GetReflector(parameter).GetAttributes(attributeType);
    }

    /// <summary>
    /// Obtain a set of specified Attribute instances from the MemberInfo. <br />
    /// 从成员信息中获取一组指定的 Attribute 实例。
    /// </summary>
    /// <param name="member">Special member</param>
    /// <param name="attributeType"></param>
    /// <param name="refOptions"></param>
    /// <returns>Attribute of special field</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<Attribute> GetAttributes(MemberInfo member, Type attributeType, ReflectionOptions refOptions)
    {
        return refOptions switch
        {
            ReflectionOptions.Default => TypeReflectorHelper.GetReflector(member).GetAttributes(attributeType),
            ReflectionOptions.Inherit => member.GetCustomAttributes(attributeType, true) as Attribute[],
            _ => member.GetCustomAttributes(attributeType)
        };
    }

    /// <summary>
    /// Obtain a set of specified Attribute instances from the ParameterInfo. <br />
    /// 从成员信息中获取一组指定的 Attribute 实例。
    /// </summary>
    /// <param name="parameter">Special member</param>
    /// <param name="attributeType"></param>
    /// <param name="refOptions"></param>
    /// <returns>Attribute of special field</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<Attribute> GetAttributes(ParameterInfo parameter, Type attributeType, ReflectionOptions refOptions)
    {
        return refOptions switch
        {
            ReflectionOptions.Default => TypeReflectorHelper.GetReflector(parameter).GetAttributes(attributeType),
            ReflectionOptions.Inherit => parameter.GetCustomAttributes(attributeType, true) as Attribute[],
            _ => parameter.GetCustomAttributes(attributeType)
        };
    }

    #endregion

    #region GetRequiredAttribute

    /// <summary>
    /// Obtain the specified Attribute instance from the MemberInfo, and throw an exception if the acquisition fails.<br />
    /// 从成员信息中获取指定的 Attribute 实例，如果获取失败则抛出异常。
    /// </summary>
    /// <param name="member">Special member</param>
    /// <typeparam name="TAttribute">Special typeInfo of attribute</typeparam>
    /// <returns>Attribute of special member</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TAttribute GetAttributeRequired<TAttribute>(MemberInfo member) where TAttribute : Attribute
    {
        return GetAttribute<TAttribute>(member).AttrRequired($"There is no {typeof(TAttribute)} attribute can be found.");
    }

    /// <summary>
    /// Obtain the specified Attribute instance from the ParameterInfo, and throw an exception if the acquisition fails.<br />
    /// 从成员信息中获取指定的 Attribute 实例，如果获取失败则抛出异常。
    /// </summary>
    /// <param name="parameter">Special member</param>
    /// <typeparam name="TAttribute">Special typeInfo of attribute</typeparam>
    /// <returns>Attribute of special member</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TAttribute GetAttributeRequired<TAttribute>(ParameterInfo parameter) where TAttribute : Attribute
    {
        return GetAttribute<TAttribute>(parameter).AttrRequired($"There is no {typeof(TAttribute)} attribute can be found.");
    }

    /// <summary>
    /// Obtain the specified Attribute instance from the MemberInfo, and throw an exception if the acquisition fails.<br />
    /// 从成员信息中获取指定的 Attribute 实例，如果获取失败则抛出异常。
    /// </summary>
    /// <param name="member">Special member</param>
    /// <param name="refOptions"></param>
    /// <param name="ambOptions"></param>
    /// <typeparam name="TAttribute">Special typeInfo of attribute</typeparam>
    /// <returns>Attribute of special member</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TAttribute GetAttributeRequired<TAttribute>(MemberInfo member, ReflectionOptions refOptions, ReflectionAmbiguousOptions ambOptions = ReflectionAmbiguousOptions.Default) where TAttribute : Attribute
    {
        var val = ambOptions switch
        {
            ReflectionAmbiguousOptions.Default => GetAttribute<TAttribute>(member, refOptions),
            ReflectionAmbiguousOptions.IgnoreAmbiguous => GetAttributes<TAttribute>(member, refOptions).AttrDisambiguation(),
            _ => GetAttribute<TAttribute>(member, refOptions)
        };

        return val.AttrRequired($"There is no {typeof(TAttribute)} attribute can be found.");
    }

    /// <summary>
    /// Obtain the specified Attribute instance from the ParameterInfo, and throw an exception if the acquisition fails.<br />
    /// 从成员信息中获取指定的 Attribute 实例，如果获取失败则抛出异常。
    /// </summary>
    /// <param name="parameter">Special member</param>
    /// <param name="refOptions"></param>
    /// <param name="ambOptions"></param>
    /// <typeparam name="TAttribute">Special typeInfo of attribute</typeparam>
    /// <returns>Attribute of special member</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TAttribute GetAttributeRequired<TAttribute>(ParameterInfo parameter, ReflectionOptions refOptions, ReflectionAmbiguousOptions ambOptions = ReflectionAmbiguousOptions.Default) where TAttribute : Attribute
    {
        var val = ambOptions switch
        {
            ReflectionAmbiguousOptions.Default => GetAttribute<TAttribute>(parameter, refOptions),
            ReflectionAmbiguousOptions.IgnoreAmbiguous => GetAttributes<TAttribute>(parameter, refOptions).AttrDisambiguation(),
            _ => GetAttribute<TAttribute>(parameter, refOptions)
        };

        return val.AttrRequired($"There is no {typeof(TAttribute)} attribute can be found.");
    }

    /// <summary>
    /// Obtain the specified Attribute instance from the MemberInfo, and throw an exception if the acquisition fails.<br />
    /// 从成员信息中获取指定的 Attribute 实例，如果获取失败则抛出异常。
    /// </summary>
    /// <param name="member">Special member</param>
    /// <param name="attributeType"></param>
    /// <returns>Attribute of special field</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Attribute GetAttributeRequired(MemberInfo member, Type attributeType)
    {
        return GetAttribute(member, attributeType).AttrRequired($"There is no {attributeType} attribute can be found.");
    }

    /// <summary>
    /// Obtain the specified Attribute instance from the ParameterInfo, and throw an exception if the acquisition fails.<br />
    /// 从成员信息中获取指定的 Attribute 实例，如果获取失败则抛出异常。
    /// </summary>
    /// <param name="parameter">Special member</param>
    /// <param name="attributeType"></param>
    /// <returns>Attribute of special field</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Attribute GetAttributeRequired(ParameterInfo parameter, Type attributeType)
    {
        return GetAttribute(parameter, attributeType).AttrRequired($"There is no {attributeType} attribute can be found.");
    }

    /// <summary>
    /// Obtain the specified Attribute instance from the MemberInfo, and throw an exception if the acquisition fails.<br />
    /// 从成员信息中获取指定的 Attribute 实例，如果获取失败则抛出异常。
    /// </summary>
    /// <param name="member">Special member</param>
    /// <param name="attributeType"></param>
    /// <param name="refOptions"></param>
    /// <param name="ambOptions"></param>
    /// <returns>Attribute of special field</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Attribute GetAttributeRequired(MemberInfo member, Type attributeType, ReflectionOptions refOptions, ReflectionAmbiguousOptions ambOptions = ReflectionAmbiguousOptions.Default)
    {
        var val = ambOptions switch
        {
            ReflectionAmbiguousOptions.Default => GetAttribute(member, attributeType, refOptions),
            ReflectionAmbiguousOptions.IgnoreAmbiguous => GetAttributes(member, attributeType, refOptions).AttrDisambiguation(),
            _ => GetAttribute(member, attributeType, refOptions)
        };

        return val.AttrRequired($"There is no {attributeType} attribute can be found.");
    }

    /// <summary>
    /// Obtain the specified Attribute instance from the ParameterInfo, and throw an exception if the acquisition fails.<br />
    /// 从成员信息中获取指定的 Attribute 实例，如果获取失败则抛出异常。
    /// </summary>
    /// <param name="parameter">Special member</param>
    /// <param name="attributeType"></param>
    /// <param name="refOptions"></param>
    /// <param name="ambOptions"></param>
    /// <returns>Attribute of special field</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Attribute GetAttributeRequired(ParameterInfo parameter, Type attributeType, ReflectionOptions refOptions, ReflectionAmbiguousOptions ambOptions = ReflectionAmbiguousOptions.Default)
    {
        var val = ambOptions switch
        {
            ReflectionAmbiguousOptions.Default => GetAttribute(parameter, attributeType, refOptions),
            ReflectionAmbiguousOptions.IgnoreAmbiguous => GetAttributes(parameter, attributeType, refOptions).AttrDisambiguation(),
            _ => GetAttribute(parameter, attributeType, refOptions)
        };

        return val.AttrRequired($"There is no {attributeType} attribute can be found.");
    }

    #endregion

    #region GetRequiredAttributes

    /// <summary>
    /// Obtain a set of specified Attribute instances from the MemberInfo, and throw an exception if the acquisition fails. <br />
    /// 从成员信息中获取一组指定的 Attribute 实例，如果获取失败则抛出异常。
    /// </summary>
    /// <param name="member">Special member</param>
    /// <typeparam name="TAttribute">Special typeInfo of attribute</typeparam>
    /// <returns>Attribute of special member</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<TAttribute> GetAttributesRequired<TAttribute>(MemberInfo member) where TAttribute : Attribute
    {
        return GetAttributes<TAttribute>(member).AttrRequired($"There is no any {typeof(TAttribute)} attributes can be found.");
    }

    /// <summary>
    /// Obtain a set of specified Attribute instances from the ParameterInfo, and throw an exception if the acquisition fails. <br />
    /// 从成员信息中获取一组指定的 Attribute 实例，如果获取失败则抛出异常。
    /// </summary>
    /// <param name="parameter">Special member</param>
    /// <typeparam name="TAttribute">Special typeInfo of attribute</typeparam>
    /// <returns>Attribute of special member</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<TAttribute> GetAttributesRequired<TAttribute>(ParameterInfo parameter) where TAttribute : Attribute
    {
        return GetAttributes<TAttribute>(parameter).AttrRequired($"There is no any {typeof(TAttribute)} attributes can be found.");
    }

    /// <summary>
    /// Obtain a set of specified Attribute instances from the MemberInfo, and throw an exception if the acquisition fails. <br />
    /// 从成员信息中获取一组指定的 Attribute 实例，如果获取失败则抛出异常。
    /// </summary>
    /// <param name="member">Special member</param>
    /// <param name="refOptions"></param>
    /// <typeparam name="TAttribute">Special typeInfo of attribute</typeparam>
    /// <returns>Attribute of special member</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<TAttribute> GetAttributesRequired<TAttribute>(MemberInfo member, ReflectionOptions refOptions) where TAttribute : Attribute
    {
        return GetAttributes<TAttribute>(member, refOptions).AttrRequired($"There is no any {typeof(TAttribute)} attributes can be found.");
    }

    /// <summary>
    /// Obtain a set of specified Attribute instances from the ParameterInfo, and throw an exception if the acquisition fails. <br />
    /// 从成员信息中获取一组指定的 Attribute 实例，如果获取失败则抛出异常。
    /// </summary>
    /// <param name="parameter">Special member</param>
    /// <param name="refOptions"></param>
    /// <typeparam name="TAttribute">Special typeInfo of attribute</typeparam>
    /// <returns>Attribute of special member</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<TAttribute> GetAttributesRequired<TAttribute>(ParameterInfo parameter, ReflectionOptions refOptions) where TAttribute : Attribute
    {
        return GetAttributes<TAttribute>(parameter, refOptions).AttrRequired($"There is no any {typeof(TAttribute)} attributes can be found.");
    }

    /// <summary>
    /// Obtain a set of specified Attribute instances from the MemberInfo, and throw an exception if the acquisition fails. <br />
    /// 从成员信息中获取一组指定的 Attribute 实例，如果获取失败则抛出异常。
    /// </summary>
    /// <param name="member">Special member</param>
    /// <param name="attributeType"></param>
    /// <returns>Attribute of special field</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<Attribute> GetAttributesRequired(MemberInfo member, Type attributeType)
    {
        return GetAttributes(member, attributeType).AttrRequired($"There is no any {attributeType} attributes can be found.");
    }

    /// <summary>
    /// Obtain a set of specified Attribute instances from the ParameterInfo, and throw an exception if the acquisition fails. <br />
    /// 从成员信息中获取一组指定的 Attribute 实例，如果获取失败则抛出异常。
    /// </summary>
    /// <param name="parameter">Special member</param>
    /// <param name="attributeType"></param>
    /// <returns>Attribute of special field</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<Attribute> GetAttributesRequired(ParameterInfo parameter, Type attributeType)
    {
        return GetAttributes(parameter, attributeType).AttrRequired($"There is no any {attributeType} attributes can be found.");
    }

    /// <summary>
    /// Obtain a set of specified Attribute instances from the MemberInfo, and throw an exception if the acquisition fails. <br />
    /// 从成员信息中获取一组指定的 Attribute 实例，如果获取失败则抛出异常。
    /// </summary>
    /// <param name="member">Special member</param>
    /// <param name="attributeType"></param>
    /// <param name="refOptions"></param>
    /// <returns>Attribute of special field</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<Attribute> GetAttributesRequired(MemberInfo member, Type attributeType, ReflectionOptions refOptions)
    {
        return GetAttributes(member, attributeType, refOptions)?.AttrRequired($"There is no any {attributeType} attributes can be found.");
    }

    /// <summary>
    /// Obtain a set of specified Attribute instances from the ParameterInfo, and throw an exception if the acquisition fails. <br />
    /// 从成员信息中获取一组指定的 Attribute 实例，如果获取失败则抛出异常。
    /// </summary>
    /// <param name="parameter">Special member</param>
    /// <param name="attributeType"></param>
    /// <param name="refOptions"></param>
    /// <returns>Attribute of special field</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<Attribute> GetAttributesRequired(ParameterInfo parameter, Type attributeType, ReflectionOptions refOptions)
    {
        return GetAttributes(parameter, attributeType, refOptions)?.AttrRequired($"There is no any {attributeType} attributes can be found.");
    }

    #endregion

    #region GetAllAttributes

    /// <summary>
    /// Obtain all Attribute instances from the MemberInfo. <br />
    /// 从成员信息中获取所有 Attribute 实例。
    /// </summary>
    /// <param name="member">Special member</param>
    /// <returns>Attribute of special field</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<Attribute> GetAttributes(MemberInfo member)
    {
        return GetAttributesImpl(TypeReflectorHelper.GetReflector(member));
    }

    /// <summary>
    /// Obtain all Attribute instances from the ParameterInfo. <br />
    /// 从成员信息中获取所有 Attribute 实例。
    /// </summary>
    /// <param name="parameter">Special member</param>
    /// <returns>Attribute of special field</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<Attribute> GetAttributes(ParameterInfo parameter)
    {
        return GetAttributesImpl(TypeReflectorHelper.GetReflector(parameter));
    }

    /// <summary>
    /// Obtain all Attribute instances from the MemberInfo. <br />
    /// 从成员信息中获取所有 Attribute 实例。
    /// </summary>
    /// <param name="member">Special member</param>
    /// <param name="refOptions"></param>
    /// <returns>Attribute of special field</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<Attribute> GetAttributes(MemberInfo member, ReflectionOptions refOptions)
    {
        return refOptions switch
        {
            ReflectionOptions.Default => GetAttributesImpl(TypeReflectorHelper.GetReflector(member)),
            ReflectionOptions.Inherit => member.GetCustomAttributes(true).Cast<Attribute>(),
            _ => member.GetCustomAttributes()
        };
    }

    /// <summary>
    /// Obtain all Attribute instances from the ParameterInfo. <br />
    /// 从成员信息中获取所有 Attribute 实例。
    /// </summary>
    /// <param name="parameter">Special member</param>
    /// <param name="refOptions"></param>
    /// <returns>Attribute of special field</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IEnumerable<Attribute> GetAttributes(ParameterInfo parameter, ReflectionOptions refOptions)
    {
        return refOptions switch
        {
            ReflectionOptions.Default => GetAttributesImpl(TypeReflectorHelper.GetReflector(parameter)),
            ReflectionOptions.Inherit => parameter.GetCustomAttributes(true).Cast<Attribute>(),
            _ => parameter.GetCustomAttributes()
        };
    }

    private static IEnumerable<Attribute> GetAttributesImpl(ICustomAttributeReflectorProvider customAttributeReflectorProvider)
    {
        var attributeReflectors = customAttributeReflectorProvider != null
            ? customAttributeReflectorProvider.CustomAttributeReflectors
            : throw new ArgumentNullException(nameof(customAttributeReflectorProvider));
        var length = attributeReflectors.Length;
        if (length == 0)
            return Enumerable.Empty<Attribute>();
        var attributeArray = new Attribute[length];
        for (var i = 0; i < length; i++)
            attributeArray[i] = attributeReflectors[i].Invoke();
        return attributeArray;
    }

    #endregion
}