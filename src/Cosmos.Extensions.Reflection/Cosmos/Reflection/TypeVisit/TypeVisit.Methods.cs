using System.Text;

namespace Cosmos.Reflection;

/// <summary>
/// Type visit, an advanced TypeReflections utility. <br />
/// 类型访问器，一个高级的 TypeReflections 工具。
/// </summary>
public static partial class TypeVisit
{
    /// <summary>
    /// Get full name of method including type name and method name.<br />
    /// 获取方法的全名，包括类型名和方法名
    /// </summary>
    /// <param name="method"></param>
    /// <returns></returns>
    public static string GetFullName(MethodInfo method)
    {
        var result = new StringBuilder();
        var type = method.DeclaringType;
        if (type != null)
            result.Append(type.FullName).Append('.');

        result.Append(method.Name);
        return result.ToString();
    }

    /// <summary>
    /// Get unique fully qualified name for <see cref="MethodInfo"/>.<br />
    /// 获取给定 <see cref="MethodInfo"/> 的完全限定名。
    /// </summary>
    /// <param name="method"></param>
    /// <returns></returns>
    public static string GetFullyQualifiedName(MethodInfo method)
    {
        var sb = new StringBuilder();
        sb.Append(method.ReturnType.GetFullyQualifiedName());
        sb.Append(" ");
        sb.Append(method.Name);
        if (method.IsGenericMethod)
        {
            sb.Append("[");
            var genericTypes = method.GetGenericArguments().ToList();
            for (var i = 0; i < genericTypes.Count; i++)
            {
                sb.Append(genericTypes[i].GetFullyQualifiedName());
                if (i != genericTypes.Count - 1)
                    sb.Append(", ");
            }

            sb.Append("]");
        }

        sb.Append("(");
        var parameters = method.GetParameters();
        for (var i = 0; i < parameters.Length; i++)
        {
            sb.Append(parameters[i].ParameterType.GetFullyQualifiedName());
            if (i != parameters.Length - 1)
                sb.Append(", ");
        }

        sb.Append(")");
        return sb.ToString();
    }

    /// <summary>
    /// Get BaseMethod <br />
    /// 获取 BaseMethod
    /// </summary>
    /// <param name="method"></param>
    /// <returns></returns>
    public static MethodInfo GetBaseMethod(MethodInfo method)
    {
        if (null == method?.DeclaringType?.BaseType)
            return null;

        return GetMethodBySignature(method.DeclaringType.BaseType, method);
    }

    /// <summary>
    /// Get method by signature <br />
    /// 根据方法签名获取方法
    /// </summary>
    /// <param name="type"></param>
    /// <param name="method"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static MethodInfo GetMethodBySignature(Type type, MethodInfo method)
    {
        if (type is null)
            throw new ArgumentNullException(nameof(type));

        if (method is null)
            throw new ArgumentNullException(nameof(method));

        var methods = type.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                          .Where(x => x.Name.Equals(method.Name))
                          .ToArray();

        var parameterTypes = method.GetParameters().Select(x => x.ParameterType).ToArray();
        if (method.ContainsGenericParameters)
        {
            foreach (var info in methods)
            {
                var innerParams = info.GetParameters();
                if (innerParams.Length != parameterTypes.Length)
                {
                    continue;
                }

                var idx = 0;
                foreach (var param in innerParams)
                {
                    if (!param.ParameterType.IsGenericParameter
                     && !parameterTypes[idx].IsGenericParameter
                     && param.ParameterType != parameterTypes[idx]
                       )
                    {
                        break;
                    }

                    idx++;
                }

                if (idx < parameterTypes.Length)
                {
                    continue;
                }

                return info;
            }

            return null;
        }

        return type.GetMethod(method.Name, parameterTypes);
    }

    /// <summary>
    /// Get method by signature <br />
    /// 根据方法签名获取方法
    /// </summary>
    /// <param name="typeInfo"></param>
    /// <param name="signature"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static MethodInfo GetMethodBySignature(TypeInfo typeInfo, MethodSignature signature)
    {
        if (typeInfo is null)
            throw new ArgumentNullException(nameof(typeInfo));
        return typeInfo.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static).FirstOrDefault(m => new MethodSignature(m) == signature);
    }

    /// <summary>
    /// Get declared method by signature <br />
    /// 根据方法签名获取声明的方法
    /// </summary>
    /// <param name="typeInfo"></param>
    /// <param name="signature"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static MethodInfo GetDeclaredMethodBySignature(TypeInfo typeInfo, MethodSignature signature)
    {
        if (typeInfo is null)
            throw new ArgumentNullException(nameof(typeInfo));
        return typeInfo.DeclaredMethods.FirstOrDefault(m => new MethodSignature(m) == signature);
    }

    /// <summary>
    /// Determine whether MethodInfo is Visible and Virtual. <br />
    /// 判断方法是可见且为虚方法。
    /// </summary>
    /// <param name="method"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static bool IsVisibleAndVirtual(MethodInfo method)
    {
        if (method is null)
            throw new ArgumentNullException(nameof(method));

        if (method.IsStatic || method.IsFinal)
            return false;

        return method.IsVirtual &&
               (method.IsPublic || method.IsFamily || method.IsFamilyOrAssembly);
    }

    /// <summary>
    /// Determine whether MethodBase is Visible. <br />
    /// 判断 MethodBase 为可见的
    /// </summary>
    /// <param name="method"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static bool IsVisible(MethodBase method)
    {
        if (method is null)
            throw new ArgumentNullException(nameof(method));
        return method.IsPublic || method.IsFamily || method.IsFamilyOrAssembly;
    }
}

/// <summary>
/// Type metadata visit, a meta information access entry for TypeReflections and TypeVisit. <br />
/// 类型元数据访问器，为 TypeReflections 和 TypeVisit 提供元信息的访问入口
/// </summary>
public static partial class TypeMetaVisitExtensions
{
    /// <summary>
    /// Determine whether the specified method is an asynchronous method.<br />
    /// 判断指定的方法是否为异步方法。
    /// </summary>
    /// <param name="method"></param>
    /// <returns></returns>
    public static bool IsAsyncMethod(this MethodInfo method)
    {
        return method.ReturnType == TypeClass.TaskClazz
            || method.ReturnType == TypeClass.ValueTaskClazz
            || method.ReturnType.IsGenericType && method.ReturnType.GetGenericTypeDefinition() == TypeClass.GenericTaskClazz
            || method.ReturnType.IsGenericType && method.ReturnType.GetGenericTypeDefinition() == TypeClass.GenericValueTaskClazz;
    }

    /// <summary>
    /// Determine whether the specified method is an overriding method.<br />
    /// 判断指定方法是否是重写方法
    /// </summary>
    /// <param name="method">要判断的方法信息</param>
    /// <returns>是否是重写方法</returns>
    public static bool IsOverridden(this MethodInfo method)
    {
        return method.GetBaseDefinition().DeclaringType != method.DeclaringType;
    }

    /// <summary>
    /// Get full name of method including type name and method name.<br />
    /// 获取方法的全名，包括类型名和方法名
    /// </summary>
    /// <param name="method"></param>
    /// <returns></returns>
    public static string GetFullName(this MethodInfo method)
    {
        return TypeVisit.GetFullName(method);
    }

    /// <summary>
    /// Get unique fully qualified name for <see cref="MethodInfo"/>.<br />
    /// 获取给定 <see cref="MethodInfo"/> 的完全限定名。
    /// </summary>
    /// <param name="method"></param>
    /// <returns></returns>
    public static string GetFullyQualifiedName(this MethodInfo method)
    {
        return TypeVisit.GetFullyQualifiedName(method);
    }

    /// <summary>
    /// Get BaseMethod <br />
    /// 获取 BaseMethod
    /// </summary>
    /// <param name="method"></param>
    /// <returns></returns>
    public static MethodInfo GetBaseMethod(this MethodInfo method)
    {
        return TypeVisit.GetBaseMethod(method);
    }

    /// <summary>
    /// Get method by signature <br />
    /// 获取方法签名
    /// </summary>
    /// <param name="type"></param>
    /// <param name="method"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static MethodInfo GetMethodBySignature(this Type type, MethodInfo method)
    {
        return TypeVisit.GetMethodBySignature(type, method);
    }

    /// <summary>
    /// Get method by signature <br />
    /// 根据方法签名获取方法
    /// </summary>
    /// <param name="typeInfo"></param>
    /// <param name="signature"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static MethodInfo GetMethodBySignature(this TypeInfo typeInfo, MethodSignature signature)
    {
        return TypeVisit.GetMethodBySignature(typeInfo, signature);
    }

    /// <summary>
    /// Get declared method by signature <br />
    /// 根据方法签名获取声明的方法
    /// </summary>
    /// <param name="typeInfo"></param>
    /// <param name="signature"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static MethodInfo GetDeclaredMethodBySignature(this TypeInfo typeInfo, MethodSignature signature)
    {
        return TypeVisit.GetDeclaredMethodBySignature(typeInfo, signature);
    }

    /// <summary>
    /// Determine whether MethodInfo is Visible and Virtual. <br />
    /// 判断方法是可见且为虚方法。
    /// </summary>
    /// <param name="method"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static bool IsVisibleAndVirtual(this MethodInfo method)
    {
        return TypeVisit.IsVisibleAndVirtual(method);
    }

    /// <summary>
    /// Determine whether MethodBase is Visible. <br />
    /// 判断 MethodBase 为可见的
    /// </summary>
    /// <param name="method"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static bool IsVisible(this MethodBase method)
    {
        return TypeVisit.IsVisible(method);
    }
}