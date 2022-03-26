using System.Linq.Expressions;

namespace Cosmos.Reflection;

/// <summary>
/// Type visit, an advanced TypeReflections utility. <br />
/// 类型访问器，一个高级的 TypeReflections 工具。
/// </summary>
public static partial class TypeVisit { }

/// <summary>
/// Type metadata visit, a meta information access entry for TypeReflections and TypeVisit. <br />
/// 类型元数据访问器，为 TypeReflections 和 TypeVisit 提供元信息的访问入口
/// </summary>
public static partial class TypeMetaVisitExtensions
{
    /// <summary>
    /// Indicates whether the description is defined <br />
    /// 指示描述是否已定义
    /// </summary>
    /// <param name="member"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public static bool IsDescriptionDefined(this MemberInfo member, ReflectionOptions options = ReflectionOptions.Default)
    {
        return TypeReflections.IsDescriptionDefined(member, options);
    }

    /// <summary>
    /// Get description <br />
    /// 获取描述
    /// </summary>
    /// <param name="member"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public static string GetDescription(this MemberInfo member, ReflectionOptions options = ReflectionOptions.Default)
    {
        return TypeReflections.GetDescription(member, options);
    }

    /// <summary>
    /// Get description <br />
    /// 获取描述
    /// </summary>
    /// <param name="x"></param>
    /// <param name="expression"></param>
    /// <param name="options"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static string GetDescription<T>(this T x, Expression<Func<T, object>> expression, ReflectionOptions options = ReflectionOptions.Default)
    {
        return x is null ? string.Empty : TypeReflections.GetDescription(expression, options);
    }

    /// <summary>
    /// Get description, or return default <br />
    /// 获取描述，或返回默认值
    /// </summary>
    /// <param name="member"></param>
    /// <param name="defaultVal"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public static string GetDescriptionOr(this MemberInfo member, string defaultVal, ReflectionOptions options = ReflectionOptions.Default)
    {
        return TypeReflections.GetDescriptionOr(member, defaultVal, options);
    }

    /// <summary>
    /// Get description, or return default <br />
    /// 获取描述，或返回默认值
    /// </summary>
    /// <param name="x"></param>
    /// <param name="expression"></param>
    /// <param name="defaultVal"></param>
    /// <param name="options"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    public static string GetDescriptionOr<T>(this T x, Expression<Func<T, object>> expression, string defaultVal, ReflectionOptions options = ReflectionOptions.Default)
    {
        return x is null ? defaultVal : TypeReflections.GetDescriptionOr(expression, defaultVal, options);
    }
}