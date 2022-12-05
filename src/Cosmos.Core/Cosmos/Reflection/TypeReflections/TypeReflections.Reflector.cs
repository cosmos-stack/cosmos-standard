using System.Linq.Expressions;
using Cosmos.Reflection.Reflectors;

namespace Cosmos.Reflection;

public static partial class TypeReflections
{
    internal static class InternalRefactorUtils
    {
        internal static MethodInfo GetMethod<T>(Expression<T> expression)
        {
            ArgumentNullException.ThrowIfNull(expression);
            if (expression.Body is not MethodCallExpression methodCallExpression)
                throw new InvalidCastException("Cannot be converted to MethodCallExpression");
            return methodCallExpression.Method;
        }

        internal static MethodInfo GetMethod<T>(string name)
        {
            ArgumentNullException.ThrowIfNull(name);
            return typeof(T).GetTypeInfo().GetMethod(name);
        }
    }
}

/// <summary>
/// Reflection Utilities. <br />
/// 反射工具
/// </summary>
public static partial class TypeReflectionsExtensions
{
    #region Reflection

    public static TypeReflector GetReflector(this Type type)
    {
        return type switch
        {
            null => throw new ArgumentNullException(nameof(type)),
            _ => TypeReflector.Create(type.GetTypeInfo())
        };
    }

    public static TypeReflector GetReflector(this TypeInfo typeInfo)
    {
        return typeInfo switch
        {
            null => throw new ArgumentNullException(nameof(typeInfo)),
            _ => TypeReflector.Create(typeInfo)
        };
    }

    public static ConstructorReflector GetReflector(this ConstructorInfo constructor)
    {
        return constructor switch
        {
            null => throw new ArgumentNullException(nameof(constructor)),
            _ => ConstructorReflector.Create(constructor)
        };
    }

    public static FieldReflector GetReflector(this FieldInfo field)
    {
        return field switch
        {
            null => throw new ArgumentNullException(nameof(field)),
            _ => FieldReflector.Create(field)
        };
    }

    public static MethodReflector GetReflector(this MethodInfo method)
    {
        return GetReflector(method, CallOptions.Callvirt);
    }

    public static MethodReflector GetReflector(this MethodInfo method, CallOptions callOption)
    {
        return method switch
        {
            null => throw new ArgumentNullException(nameof(method)),
            _ => MethodReflector.Create(method, callOption)
        };
    }

    public static PropertyReflector GetReflector(this PropertyInfo property)
    {
        return property switch
        {
            null => throw new ArgumentNullException(nameof(property)),
            _ => GetReflector(property, CallOptions.Callvirt)
        };
    }

    public static PropertyReflector GetReflector(this PropertyInfo property, CallOptions callOption)
    {
        return property switch
        {
            null => throw new ArgumentNullException(nameof(property)),
            _ => PropertyReflector.Create(property, callOption)
        };
    }

    public static ParameterReflector GetReflector(this ParameterInfo parameterInfo)
    {
        return parameterInfo switch
        {
            null => throw new ArgumentNullException(nameof(parameterInfo)),
            _ => ParameterReflector.Create(parameterInfo)
        };
    }

    #endregion

    #region Refactor

    public static FieldInfo GetFieldInfo(this FieldReflector reflector) => reflector?.GetMemberInfo();

    public static MethodInfo GetMethodInfo(this MethodReflector reflector) => reflector?.GetMemberInfo();

    public static ConstructorInfo GetConstructorInfo(this ConstructorReflector reflector) => reflector?.GetMemberInfo();

    public static PropertyInfo GetPropertyInfo(this PropertyReflector reflector) => reflector?.GetMemberInfo();

    #endregion
}