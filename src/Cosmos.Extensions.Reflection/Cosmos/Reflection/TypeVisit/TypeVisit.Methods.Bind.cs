using System.Collections.Concurrent;

namespace Cosmos.Reflection;

/// <summary>
/// Type visit, an advanced TypeReflections utility. <br />
/// 类型访问器，一个高级的 TypeReflections 工具。
/// </summary>
public static partial class TypeVisit
{
    private static readonly ConcurrentDictionary<MethodInfo, PropertyInfo> dictionary = new();

    public static bool IsPropertyBinding(MethodInfo method)
        => method is null ? throw new ArgumentNullException(nameof(method)) : method.GetBindingProperty() != null;

    public static PropertyInfo GetBindingProperty(MethodInfo method)
    {
        if (method is null)
            throw new ArgumentNullException(nameof(method));

        return dictionary.GetOrAdd(method, m =>
        {
            foreach (var property in m.DeclaringType.GetTypeInfo().GetProperties())
            {
                if (property.CanRead && property.GetMethod == m)
                {
                    return property;
                }

                if (property.CanWrite && property.SetMethod == m)
                {
                    return property;
                }
            }

            return null;
        });
    }
}

/// <summary>
/// Type metadata visit, a meta information access entry for TypeReflections and TypeVisit. <br />
/// 类型元数据访问器，为 TypeReflections 和 TypeVisit 提供元信息的访问入口
/// </summary>
public static partial class TypeMetaVisitExtensions
{
    public static bool IsPropertyBinding(this MethodInfo method)
        => TypeVisit.IsPropertyBinding(method);

    public static PropertyInfo GetBindingProperty(this MethodInfo method)
        => TypeVisit.GetBindingProperty(method);
}