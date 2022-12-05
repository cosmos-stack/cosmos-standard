namespace Cosmos.Reflection;

/// <summary>
/// Type visit, an advanced TypeReflections utility. <br />
/// 类型访问器，一个高级的 TypeReflections 工具。
/// </summary>
public static partial class TypeVisit
{
    /// <summary>
    /// Determine whether there is a parameterless constructor. <br />
    /// 推测当前类型是否存在无参构造函数
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static bool HasParameterlessConstructor(Type type)
    {
        ArgumentNullException.ThrowIfNull(type);

        var ctor = type.GetConstructors().OrderBy(c => c.IsPublic ? 0 : (c.IsPrivate ? 2 : 1))
                       .ThenBy(c => c.GetParameters().Length)
                       .FirstOrDefault();

        return ctor?.GetParameters().Length == 0;
    }

    /// <summary>
    /// Get default constructor without any parameters. <br />
    /// 获取当前类型的无参构造函数
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static ConstructorInfo GetParameterlessConstructor(Type type)
    {
        var ctor = type.GetConstructors()
                       .OrderBy(c => c.IsPublic ? 0 : (c.IsPrivate ? 2 : 1))
                       .ThenBy(c => c.GetParameters().Length)
                       .FirstOrDefault();

        return ctor?.GetParameters().Length == 0 ? ctor : null;
    }

    /// <summary>
    /// Finds a constructor with the matching type parameters. <br />
    /// 获取命中参数的构造器
    /// </summary>
    /// <param name="type">The type being tested.</param>
    /// <param name="constructorParameterTypes">The types of the contractor to find.</param>
    /// <returns>The <see cref="ConstructorInfo"/> is a match is found; otherwise, <c>null</c>.</returns>
    public static ConstructorInfo GetMatchingConstructor(Type type, Type[] constructorParameterTypes)
    {
        if (constructorParameterTypes == null || constructorParameterTypes.Length == 0)
            return GetParameterlessConstructor(type);

        return type.GetConstructors()
                   .FirstOrDefault(c => c.GetParameters()
                                         .Select(p => p.ParameterType)
                                         .SequenceEqual(constructorParameterTypes)
                   );
    }
}

/// <summary>
/// Type metadata visit, a meta information access entry for TypeReflections and TypeVisit. <br />
/// 类型元数据访问器，为 TypeReflections 和 TypeVisit 提供元信息的访问入口
/// </summary>
public static partial class TypeMetaVisitExtensions
{
    /// <summary>
    /// Determine whether there is a parameterless constructor. <br />
    /// 推测当前类型是否存在无参构造函数
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static bool HasParameterlessConstructor(this Type type)
    {
        return TypeVisit.HasParameterlessConstructor(type);
    }

    /// <summary>
    /// Get default constructor without any parameters. <br />
    /// 获取当前类型的无参构造函数
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public static ConstructorInfo GetParameterlessConstructor(this Type type)
    {
        return TypeVisit.GetParameterlessConstructor(type);
    }

    /// <summary>
    /// Finds a constructor with the matching type parameters. <br />
    /// 获取命中参数的构造器
    /// </summary>
    /// <param name="type">The type being tested.</param>
    /// <param name="constructorParameterTypes">The types of the contractor to find.</param>
    /// <returns>The <see cref="ConstructorInfo"/> is a match is found; otherwise, <c>null</c>.</returns>
    public static ConstructorInfo GetMatchingConstructor(this Type type, Type[] constructorParameterTypes)
    {
        return TypeVisit.GetMatchingConstructor(type, constructorParameterTypes);
    }
}