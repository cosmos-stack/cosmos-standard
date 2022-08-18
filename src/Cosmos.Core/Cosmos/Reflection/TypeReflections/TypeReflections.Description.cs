using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq.Expressions;
using System.Reflection;

namespace Cosmos.Reflection;

/// <summary>
/// Reflection Utilities. <br />
/// 反射工具
/// </summary>
public static partial class TypeReflections
{
    #region IsDescriptionDefined

    /// <summary>
    /// Determine whether <see cref="DescriptionAttribute"/> is defined. <br />
    /// 判断 <see cref="DescriptionAttribute"/> 是否被定义。
    /// </summary>
    /// <param name="member"></param>
    /// <param name="refOptions"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsDescriptionDefined(MemberInfo member, ReflectionOptions refOptions = ReflectionOptions.Default)
    {
        return member is not null &&
               (IsAttributeDefined<DescriptionAttribute>(member, refOptions) || IsAttributeDefined<DisplayAttribute>(member, refOptions));
    }

    /// <summary>
    /// Determine whether <see cref="DescriptionAttribute"/> is defined. <br />
    /// 判断 <see cref="DescriptionAttribute"/> 是否被定义。
    /// </summary>
    /// <param name="parameter"></param>
    /// <param name="refOptions"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool IsDescriptionDefined(ParameterInfo parameter, ReflectionOptions refOptions = ReflectionOptions.Default)
    {
        return parameter is not null &&
               (IsAttributeDefined<DescriptionAttribute>(parameter, refOptions) || IsAttributeDefined<DisplayAttribute>(parameter, refOptions));
    }

    #endregion

    #region GetDescription

    private static string GetDescriptionImpl(MemberInfo member, ReflectionOptions refOptions, ReflectionAmbiguousOptions ambOptions)
    {
        if (member is null) return string.Empty;
        if (GetAttribute(member, typeof(DescriptionAttribute), refOptions, ambOptions) is DescriptionAttribute attribute)
            return attribute.Description;
        if (GetAttribute(member, typeof(DisplayAttribute), refOptions, ambOptions) is DisplayAttribute displayAttribute)
            return displayAttribute.Description ?? string.Empty;
        return member.Name;
    }

    private static string GetDescriptionImpl(ParameterInfo parameter, ReflectionOptions refOptions, ReflectionAmbiguousOptions ambOptions)
    {
        if (parameter is null) return string.Empty;
        if (GetAttribute(parameter, typeof(DescriptionAttribute), refOptions, ambOptions) is DescriptionAttribute attribute)
            return attribute.Description;
        if (GetAttribute(parameter, typeof(DisplayAttribute), refOptions, ambOptions) is DisplayAttribute displayAttribute)
            return displayAttribute.Description ?? string.Empty;
        return parameter.Name ?? string.Empty;
    }

    /// <summary>
    /// Returns the description information of the member. The search will be carried out in the following order: <br />
    /// 返回成员的描述信息。将按照以下顺序进行寻找：
    /// <para>
    /// - <see cref="DescriptionAttribute"/> <br />
    /// - <see cref="DisplayAttribute"/> <br />
    /// - Name
    /// </para>
    /// </summary>
    /// <param name="member"></param>
    /// <param name="refOptions"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string GetDescription(MemberInfo member, ReflectionOptions refOptions = ReflectionOptions.Default)
    {
        return GetDescriptionImpl(member, refOptions, ReflectionAmbiguousOptions.IgnoreAmbiguous);
    }

    /// <summary>
    /// Returns the description information of the member. The search will be carried out in the following order: <br />
    /// 返回成员的描述信息。将按照以下顺序进行寻找：
    /// <para>
    /// - <see cref="DescriptionAttribute"/> <br />
    /// - <see cref="DisplayAttribute"/> <br />
    /// - Name
    /// </para>
    /// </summary>
    /// <param name="parameter"></param>
    /// <param name="refOptions"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string GetDescription(ParameterInfo parameter, ReflectionOptions refOptions = ReflectionOptions.Default)
    {
        return GetDescriptionImpl(parameter, refOptions, ReflectionAmbiguousOptions.IgnoreAmbiguous);
    }

    /// <summary>
    /// Returns the description information of the member. The search will be carried out in the following order: <br />
    /// 返回成员的描述信息。将按照以下顺序进行寻找：
    /// <para>
    /// - <see cref="DescriptionAttribute"/> <br />
    /// - <see cref="DisplayAttribute"/> <br />
    /// - Name
    /// </para>
    /// </summary>
    /// <param name="refOptions"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string GetDescription<T>(ReflectionOptions refOptions = ReflectionOptions.Default)
    {
        return GetDescriptionImpl(typeof(T), refOptions, ReflectionAmbiguousOptions.IgnoreAmbiguous);
    }

    /// <summary>
    /// Returns the description information of the member. The search will be carried out in the following order: <br />
    /// 返回成员的描述信息。将按照以下顺序进行寻找：
    /// <para>
    /// - <see cref="DescriptionAttribute"/> <br />
    /// - <see cref="DisplayAttribute"/> <br />
    /// - Name
    /// </para>
    /// </summary>
    /// <param name="type"></param>
    /// <param name="memberName"></param>
    /// <param name="refOptions"></param>
    /// <returns></returns>
    public static string GetDescription(Type type, string memberName, ReflectionOptions refOptions = ReflectionOptions.Default)
    {
        if (type is null) return string.Empty;
        if (string.IsNullOrWhiteSpace(memberName)) return string.Empty;
        var members = type.GetMembers();
        return GetDescriptionImpl(members.FirstOrDefault(x => x.Name == memberName), refOptions, ReflectionAmbiguousOptions.IgnoreAmbiguous);
    }

    /// <summary>
    /// Returns the description information of the member. The search will be carried out in the following order: <br />
    /// 返回成员的描述信息。将按照以下顺序进行寻找：
    /// <para>
    /// - <see cref="DescriptionAttribute"/> <br />
    /// - <see cref="DisplayAttribute"/> <br />
    /// - Name
    /// </para>
    /// </summary>
    /// <param name="memberName"></param>
    /// <param name="refOptions"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static string GetDescription<T>(string memberName, ReflectionOptions refOptions = ReflectionOptions.Default)
    {
        if (string.IsNullOrWhiteSpace(memberName)) return string.Empty;
        var members = typeof(T).GetMembers();
        return GetDescriptionImpl(members.FirstOrDefault(x => x.Name == memberName), refOptions, ReflectionAmbiguousOptions.IgnoreAmbiguous);
    }

    /// <summary>
    /// Returns the description information of the member. The search will be carried out in the following order: <br />
    /// 返回成员的描述信息。将按照以下顺序进行寻找：
    /// <para>
    /// - <see cref="DescriptionAttribute"/> <br />
    /// - <see cref="DisplayAttribute"/> <br />
    /// - Name
    /// </para>
    /// </summary>
    /// <param name="expression"></param>
    /// <param name="options"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static string GetDescription<T>(Expression<Func<T, object>> expression, ReflectionOptions options = ReflectionOptions.Default)
    {
        var member = expression.Body as MemberExpression;

        if (member is null
         && expression.Body.NodeType == ExpressionType.Convert
         && expression.Body is UnaryExpression unary)
            member = unary.Operand as MemberExpression;

        return GetDescriptionImpl(member?.Member, options, ReflectionAmbiguousOptions.IgnoreAmbiguous);
    }

    #endregion

    #region GetDisplayName

    private static string GetDisplayNameImpl(MemberInfo member, ReflectionOptions refOptions, ReflectionAmbiguousOptions ambOptions)
    {
        if (member is null) return string.Empty;
        if (GetAttribute(member, typeof(DisplayNameAttribute), refOptions, ambOptions) is DisplayNameAttribute displayNameAttribute)
            return displayNameAttribute.DisplayName;
        if (GetAttribute(member, typeof(DisplayAttribute), refOptions, ambOptions) is DisplayAttribute displayAttribute)
            return displayAttribute.Name ?? string.Empty;
        return member.Name;
    }

    private static string GetDisplayNameImpl(ParameterInfo parameter, ReflectionOptions refOptions, ReflectionAmbiguousOptions ambOptions)
    {
        if (parameter is null) return string.Empty;
        if (GetAttribute(parameter, typeof(DisplayNameAttribute), refOptions, ambOptions) is DisplayNameAttribute displayNameAttribute)
            return displayNameAttribute.DisplayName;
        if (GetAttribute(parameter, typeof(DisplayAttribute), refOptions, ambOptions) is DisplayAttribute displayAttribute)
            return displayAttribute.Name ?? string.Empty;
        return parameter.Name ?? string.Empty;
    }

    /// <summary>
    /// Returns the name of the member. The search will be carried out in the following order: <br />
    /// 返回成员的名称。将按照以下顺序进行寻找：
    /// <para>
    /// - <see cref="DisplayNameAttribute"/> <br />
    /// - <see cref="DisplayAttribute"/> <br />
    /// - Name
    /// </para>
    /// </summary>
    /// <param name="member"></param>
    /// <param name="refOptions"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string GetDisplayName(MemberInfo member, ReflectionOptions refOptions = ReflectionOptions.Default)
    {
        return GetDisplayNameImpl(member, refOptions, ReflectionAmbiguousOptions.IgnoreAmbiguous);
    }

    /// <summary>
    /// Returns the name of the member. The search will be carried out in the following order: <br />
    /// 返回成员的名称。将按照以下顺序进行寻找：
    /// <para>
    /// - <see cref="DisplayNameAttribute"/> <br />
    /// - <see cref="DisplayAttribute"/> <br />
    /// - Name
    /// </para>
    /// </summary>
    /// <param name="parameter"></param>
    /// <param name="refOptions"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string GetDisplayName(ParameterInfo parameter, ReflectionOptions refOptions = ReflectionOptions.Default)
    {
        return GetDisplayNameImpl(parameter, refOptions, ReflectionAmbiguousOptions.IgnoreAmbiguous);
    }

    /// <summary>
    /// Returns the name of the member. The search will be carried out in the following order: <br />
    /// 返回成员的名称。将按照以下顺序进行寻找：
    /// <para>
    /// - <see cref="DisplayNameAttribute"/> <br />
    /// - <see cref="DisplayAttribute"/> <br />
    /// - Name
    /// </para>
    /// </summary>
    /// <param name="refOptions"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string GetDisplayName<T>(ReflectionOptions refOptions = ReflectionOptions.Default)
    {
        return GetDisplayNameImpl(typeof(T), refOptions, ReflectionAmbiguousOptions.IgnoreAmbiguous);
    }

    /// <summary>
    /// Returns the name of the member. The search will be carried out in the following order: <br />
    /// 返回成员的名称。将按照以下顺序进行寻找：
    /// <para>
    /// - <see cref="DisplayNameAttribute"/> <br />
    /// - <see cref="DisplayAttribute"/> <br />
    /// - Name
    /// </para>
    /// </summary>
    /// <param name="type"></param>
    /// <param name="memberName"></param>
    /// <param name="refOptions"></param>
    /// <returns></returns>
    public static string GetDisplayName(Type type, string memberName, ReflectionOptions refOptions = ReflectionOptions.Default)
    {
        if (type is null) return string.Empty;
        if (string.IsNullOrWhiteSpace(memberName)) return string.Empty;
        var members = type.GetMembers();
        return GetDisplayNameImpl(members.FirstOrDefault(x => x.Name == memberName), refOptions, ReflectionAmbiguousOptions.IgnoreAmbiguous);
    }

    /// <summary>
    /// Returns the name of the member. The search will be carried out in the following order: <br />
    /// 返回成员的名称。将按照以下顺序进行寻找：
    /// <para>
    /// - <see cref="DisplayNameAttribute"/> <br />
    /// - <see cref="DisplayAttribute"/> <br />
    /// - Name
    /// </para>
    /// </summary>
    /// <param name="memberName"></param>
    /// <param name="refOptions"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static string GetDisplayName<T>(string memberName, ReflectionOptions refOptions = ReflectionOptions.Default)
    {
        if (string.IsNullOrWhiteSpace(memberName)) return string.Empty;
        var members = typeof(T).GetMembers();
        return GetDisplayNameImpl(members.FirstOrDefault(x => x.Name == memberName), refOptions, ReflectionAmbiguousOptions.IgnoreAmbiguous);
    }

    /// <summary>
    /// Returns the name of the member. The search will be carried out in the following order: <br />
    /// 返回成员的名称。将按照以下顺序进行寻找：
    /// <para>
    /// - <see cref="DisplayNameAttribute"/> <br />
    /// - <see cref="DisplayAttribute"/> <br />
    /// - Name
    /// </para>
    /// </summary>
    /// <param name="expression"></param>
    /// <param name="options"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static string GetDisplayName<T>(Expression<Func<T, object>> expression, ReflectionOptions options = ReflectionOptions.Default)
    {
        var member = expression.Body as MemberExpression;

        if (member is null
         && expression.Body.NodeType == ExpressionType.Convert
         && expression.Body is UnaryExpression unary)
            member = unary.Operand as MemberExpression;

        return GetDisplayNameImpl(member?.Member, options, ReflectionAmbiguousOptions.IgnoreAmbiguous);
    }

    #endregion

    #region GetDescriptionOr

    private static string GetDescriptionOrImpl(MemberInfo member, string defaultVal, ReflectionOptions refOptions, ReflectionAmbiguousOptions ambOptions)
    {
        return member is not null && IsDescriptionDefined(member, refOptions)
            ? GetDescriptionImpl(member, refOptions, ambOptions)
            : defaultVal;
    }

    private static string GetDescriptionOrImpl(ParameterInfo parameter, string defaultVal, ReflectionOptions refOptions, ReflectionAmbiguousOptions ambOptions)
    {
        return parameter is not null && IsDescriptionDefined(parameter, refOptions)
            ? GetDescriptionImpl(parameter, refOptions, ambOptions)
            : defaultVal;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string GetDescriptionOr(MemberInfo member, string defaultVal, ReflectionOptions refOptions = ReflectionOptions.Default)
    {
        return GetDescriptionOrImpl(member, defaultVal, refOptions, ReflectionAmbiguousOptions.IgnoreAmbiguous);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string GetDescriptionOr(ParameterInfo parameter, string defaultVal, ReflectionOptions refOptions = ReflectionOptions.Default)
    {
        return GetDescriptionOrImpl(parameter, defaultVal, refOptions, ReflectionAmbiguousOptions.IgnoreAmbiguous);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string GetDescriptionOr<T>(string defaultVal, ReflectionOptions refOptions = ReflectionOptions.Default)
    {
        return GetDescriptionOrImpl(typeof(T), defaultVal, refOptions, ReflectionAmbiguousOptions.IgnoreAmbiguous);
    }

    public static string GetDescriptionOr(Type type, string memberName, string defaultVal, ReflectionOptions refOptions = ReflectionOptions.Default)
    {
        if (type is null) return defaultVal;
        if (string.IsNullOrWhiteSpace(memberName)) return defaultVal;
        var members = type.GetMembers();
        return GetDescriptionOrImpl(members.FirstOrDefault(x => x.Name == memberName), defaultVal, refOptions, ReflectionAmbiguousOptions.IgnoreAmbiguous);
    }

    public static string GetDescriptionOr<T>(string memberName, string defaultVal, ReflectionOptions refOptions = ReflectionOptions.Default)
    {
        if (string.IsNullOrWhiteSpace(memberName)) return defaultVal;
        var members = typeof(T).GetMembers();
        return GetDescriptionOrImpl(members.FirstOrDefault(x => x.Name == memberName), defaultVal, refOptions, ReflectionAmbiguousOptions.IgnoreAmbiguous);
    }

    public static string GetDescriptionOr<T>(Expression<Func<T, object>> expression, string defaultVal, ReflectionOptions options = ReflectionOptions.Default)
    {
        var member = expression.Body as MemberExpression;

        if (member is null
         && expression.Body.NodeType == ExpressionType.Convert
         && expression.Body is UnaryExpression unary)
            member = unary.Operand as MemberExpression;

        return GetDescriptionOrImpl(member?.Member, defaultVal, options, ReflectionAmbiguousOptions.IgnoreAmbiguous);
    }

    #endregion

    #region GetDisplayNameOr

    private static string GetDisplayNameOrImpl(MemberInfo member, string defaultVal, ReflectionOptions refOptions, ReflectionAmbiguousOptions ambOptions)
    {
        if (member is null) return defaultVal;
        if (GetAttribute(member, typeof(DisplayNameAttribute), refOptions, ambOptions) is DisplayNameAttribute displayNameAttribute)
            return displayNameAttribute.DisplayName;
        if (GetAttribute(member, typeof(DisplayAttribute), refOptions, ambOptions) is DisplayAttribute displayAttribute)
            return displayAttribute.Name ?? string.Empty;
        return defaultVal;
    }

    private static string GetDisplayNameOrImpl(ParameterInfo parameter, string defaultVal, ReflectionOptions refOptions, ReflectionAmbiguousOptions ambOptions)
    {
        if (parameter is null) return defaultVal;
        if (GetAttribute(parameter, typeof(DisplayNameAttribute), refOptions, ambOptions) is DisplayNameAttribute displayNameAttribute)
            return displayNameAttribute.DisplayName;
        if (GetAttribute(parameter, typeof(DisplayAttribute), refOptions, ambOptions) is DisplayAttribute displayAttribute)
            return displayAttribute.Name ?? string.Empty;
        return defaultVal;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string GetDisplayNameOr(MemberInfo member, string defaultVal, ReflectionOptions refOptions = ReflectionOptions.Default)
    {
        return GetDisplayNameOrImpl(member, defaultVal, refOptions, ReflectionAmbiguousOptions.IgnoreAmbiguous);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string GetDisplayNameOr(ParameterInfo parameter, string defaultVal, ReflectionOptions refOptions = ReflectionOptions.Default)
    {
        return GetDisplayNameOrImpl(parameter, defaultVal, refOptions, ReflectionAmbiguousOptions.IgnoreAmbiguous);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string GetDisplayNameOr<T>(string defaultVal, ReflectionOptions refOptions = ReflectionOptions.Default)
    {
        return GetDisplayNameOrImpl(typeof(T), defaultVal, refOptions, ReflectionAmbiguousOptions.IgnoreAmbiguous);
    }

    public static string GetDisplayNameOr(Type type, string memberName, string defaultVal, ReflectionOptions refOptions = ReflectionOptions.Default)
    {
        if (type is null) return string.Empty;
        if (string.IsNullOrWhiteSpace(memberName)) return string.Empty;
        var members = type.GetMembers();
        return GetDisplayNameOrImpl(members.FirstOrDefault(x => x.Name == memberName), defaultVal, refOptions, ReflectionAmbiguousOptions.IgnoreAmbiguous);
    }

    public static string GetDisplayNameOr<T>(string memberName, string defaultVal, ReflectionOptions refOptions = ReflectionOptions.Default)
    {
        if (string.IsNullOrWhiteSpace(memberName)) return string.Empty;
        var members = typeof(T).GetMembers();
        return GetDisplayNameOrImpl(members.FirstOrDefault(x => x.Name == memberName), defaultVal, refOptions, ReflectionAmbiguousOptions.IgnoreAmbiguous);
    }

    public static string GetDisplayNameOr<T>(Expression<Func<T, object>> expression, string defaultVal, ReflectionOptions options = ReflectionOptions.Default)
    {
        var member = expression.Body as MemberExpression;

        if (member is null
         && expression.Body.NodeType == ExpressionType.Convert
         && expression.Body is UnaryExpression unary)
            member = unary.Operand as MemberExpression;

        return GetDisplayNameOrImpl(member?.Member, defaultVal, options, ReflectionAmbiguousOptions.IgnoreAmbiguous);
    }

    #endregion

    #region GetDescriptionOrDisplayName

    private static string GetDescriptionOrDisplayNameImpl(MemberInfo member, ReflectionOptions refOptions, ReflectionAmbiguousOptions ambOptions)
    {
        if (member is null)
            return string.Empty;
        return IsDescriptionDefined(member, refOptions)
            ? GetDescriptionImpl(member, refOptions, ambOptions)
            : GetDisplayNameImpl(member, refOptions, ambOptions);
    }

    private static string GetDescriptionOrDisplayNameImpl(ParameterInfo parameter, ReflectionOptions refOptions, ReflectionAmbiguousOptions ambOptions)
    {
        if (parameter is null)
            return string.Empty;
        return IsDescriptionDefined(parameter, refOptions)
            ? GetDescriptionImpl(parameter, refOptions, ambOptions)
            : GetDisplayNameImpl(parameter, refOptions, ambOptions);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string GetDescriptionOrDisplayName(MemberInfo member, ReflectionOptions refOptions = ReflectionOptions.Default)
    {
        return GetDescriptionOrDisplayNameImpl(member, refOptions, ReflectionAmbiguousOptions.IgnoreAmbiguous);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string GetDescriptionOrDisplayName(ParameterInfo parameter, ReflectionOptions refOptions = ReflectionOptions.Default)
    {
        return GetDescriptionOrDisplayNameImpl(parameter, refOptions, ReflectionAmbiguousOptions.IgnoreAmbiguous);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string GetDescriptionOrDisplayName<T>(ReflectionOptions refOptions = ReflectionOptions.Default)
    {
        return GetDescriptionOrDisplayNameImpl(typeof(T), refOptions, ReflectionAmbiguousOptions.IgnoreAmbiguous);
    }

    public static string GetDescriptionOrDisplayName(Type type, string memberName, ReflectionOptions refOptions = ReflectionOptions.Default)
    {
        if (type is null) return string.Empty;
        if (string.IsNullOrWhiteSpace(memberName)) return string.Empty;
        var members = type.GetMembers();
        return GetDescriptionOrDisplayNameImpl(members.FirstOrDefault(x => x.Name == memberName), refOptions, ReflectionAmbiguousOptions.IgnoreAmbiguous);
    }

    public static string GetDescriptionOrDisplayName<T>(string memberName, ReflectionOptions refOptions = ReflectionOptions.Default)
    {
        if (string.IsNullOrWhiteSpace(memberName)) return string.Empty;
        var members = typeof(T).GetMembers();
        return GetDescriptionOrDisplayNameImpl(members.FirstOrDefault(x => x.Name == memberName), refOptions, ReflectionAmbiguousOptions.IgnoreAmbiguous);
    }

    public static string GetDescriptionOrDisplayName<T>(Expression<Func<T, object>> expression, ReflectionOptions options = ReflectionOptions.Default)
    {
        var member = expression.Body as MemberExpression;

        if (member is null
         && expression.Body.NodeType == ExpressionType.Convert
         && expression.Body is UnaryExpression unary)
            member = unary.Operand as MemberExpression;

        return GetDescriptionOrDisplayNameImpl(member?.Member, options, ReflectionAmbiguousOptions.IgnoreAmbiguous);
    }

    #endregion
}