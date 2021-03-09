using System.Reflection;
using System.Linq;
using System.Text;

namespace Cosmos.Reflection
{
    /// <summary>
    /// Type visit, an advanced TypeReflections utility.
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
    }

    /// <summary>
    /// Type metadata visit, a meta information access entry for TypeReflections and TypeVisit.
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
    }
}