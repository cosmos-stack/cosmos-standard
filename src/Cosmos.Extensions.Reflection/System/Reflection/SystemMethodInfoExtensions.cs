using System.Linq;
using System.Text;

namespace System.Reflection
{
    /// <summary>
    /// Cosmos <see cref="MethodInfo"/> extensions.
    /// </summary>
    public static class SystemMethodInfoExtensions
    {
        /// <summary>
        /// Get full name of method including type name and method name.<br />
        /// 获取方法的全名，包括类型名和方法名
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        public static string GetFullName(this MethodInfo method)
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
        public static string GetFullyQualifiedName(this MethodInfo method)
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
}