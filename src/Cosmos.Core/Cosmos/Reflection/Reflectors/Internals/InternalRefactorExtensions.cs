namespace Cosmos.Reflection.Reflectors.Internals;

internal static class InternalRefactorExtensions
{
    internal static MethodInfo? GetMethodBySign(this TypeInfo typeInfo, MethodInfo method)
    {
        return typeInfo.DeclaredMethods.FirstOrDefault(m => m.ToString() == method.ToString());
    }

    internal static bool IsCallvirt(this MethodInfo methodInfo)
    {
        var typeInfo = methodInfo.DeclaringType!.GetTypeInfo();
        return !typeInfo.IsClass;
    }

    internal static string GetFullName(this MemberInfo member)
    {
        var declaringType = member.DeclaringType!.GetTypeInfo();
        return declaringType.IsInterface
            ? $"{declaringType.Name}.{member.Name}".Replace('+', '.')
            : member.Name;
    }

    internal static bool IsReturnTask(this MethodInfo methodInfo)
    {
        return typeof(Task).GetTypeInfo().IsAssignableFrom(methodInfo.ReturnType.GetTypeInfo());
    }

    internal static Type[] GetParameterTypes(this MethodBase method)
    {
        return method.GetParameters().Select(x => x.ParameterType).ToArray();
    }

    internal static Type UnWrapArrayType(this TypeInfo typeInfo)
    {
        ArgumentNullException.ThrowIfNull(typeInfo);

        if (!typeInfo.IsArray)
            return typeInfo.AsType();

        return typeInfo.ImplementedInterfaces.First(x => x.GetTypeInfo().IsGenericType && x.GetTypeInfo().GetGenericTypeDefinition() == typeof(IEnumerable<>)).GenericTypeArguments[0];
    }
}