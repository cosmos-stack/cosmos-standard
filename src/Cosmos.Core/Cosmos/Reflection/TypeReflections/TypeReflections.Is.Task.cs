using System.Collections.Concurrent;

namespace Cosmos.Reflection;

/// <summary>
/// Reflection Utilities. <br />
/// 反射工具
/// </summary>
public static partial class TypeReflections
{
    private static readonly ConcurrentDictionary<TypeInfo, bool> isTaskOfTCache = new();
    private static readonly ConcurrentDictionary<TypeInfo, bool> isValueTaskOfTCache = new();
    private static readonly Type voidTaskResultType = Type.GetType("System.Threading.Tasks.VoidTaskResult", false);

    public static bool IsTask(TypeInfo typeInfo)
    {
        ArgumentNullException.ThrowIfNull(typeInfo);
        return typeInfo.AsType() == typeof(Task);
    }

    public static bool IsTaskWithResult(TypeInfo typeInfo)
    {
        ArgumentNullException.ThrowIfNull(typeInfo);
        return isTaskOfTCache.GetOrAdd(typeInfo, Info => Info.IsGenericType && typeof(Task).GetTypeInfo().IsAssignableFrom(Info));
    }

    public static bool IsTaskWithVoidTaskResult(TypeInfo typeInfo)
    {
        ArgumentNullException.ThrowIfNull(typeInfo);
        return typeInfo.GenericTypeArguments.Length > 0 && typeInfo.GenericTypeArguments[0] == voidTaskResultType;
    }

    public static bool IsValueTask(TypeInfo typeInfo)
    {
        ArgumentNullException.ThrowIfNull(typeInfo);
        return typeInfo.AsType() == typeof(ValueTask);
    }

    public static bool IsValueTaskWithResult(TypeInfo typeInfo)
    {
        ArgumentNullException.ThrowIfNull(typeInfo);
        return isValueTaskOfTCache.GetOrAdd(typeInfo, Info => Info.IsGenericType && Info.GetGenericTypeDefinition() == typeof(ValueTask<>));
    }
}

/// <summary>
/// Reflection Utilities. <br />
/// 反射工具
/// </summary>
public static partial class TypeReflectionsExtensions
{
    public static bool IsTask(this TypeInfo typeInfo) => TypeReflections.IsTask(typeInfo);

    public static bool IsTaskWithResult(this TypeInfo typeInfo) => TypeReflections.IsTaskWithResult(typeInfo);

    public static bool IsTaskWithVoidTaskResult(this TypeInfo typeInfo) => TypeReflections.IsTaskWithVoidTaskResult(typeInfo);

    public static bool IsValueTask(this TypeInfo typeInfo) => TypeReflections.IsValueTask(typeInfo);

    public static bool IsValueTaskWithResult(this TypeInfo typeInfo) => TypeReflections.IsValueTaskWithResult(typeInfo);
}