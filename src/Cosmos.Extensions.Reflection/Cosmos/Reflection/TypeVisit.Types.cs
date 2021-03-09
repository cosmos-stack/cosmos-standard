using System;
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
        /// Get unique fully name for <see cref="TypeInfo"/>.<br />
        /// 获取给定 <see cref="MethodInfo"/> 的名称。
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetFullName(Type type)
        {
            if (type is null) throw new ArgumentNullException(nameof(type));
            return type.FullName;
        }

        /// <summary>
        /// Get unique fully qualified name for <see cref="TypeInfo"/>.<br />
        /// 获取给定 <see cref="TypeInfo"/> 的完全限定名。
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetFullyQualifiedName(Type type)
        {
            if (type is null) throw new ArgumentNullException(nameof(type));
            var sb = new StringBuilder();
            if (type.IsGenericType)
            {
                sb.Append(type.GetGenericTypeDefinition().FullName)
                  .Append("[");

                var genericArgs = type.GetGenericArguments().ToList();
                for (var i = 0; i < genericArgs.Count; i++)
                {
                    sb.Append(genericArgs[i].GetFullyQualifiedName());
                    if (i != genericArgs.Count - 1)
                        sb.Append(", ");
                }

                sb.Append("]");
            }
            else
            {
                if (!string.IsNullOrEmpty(type.FullName))
                    sb.Append(type.FullName);
                else if (!string.IsNullOrEmpty(type.Name))
                    sb.Append(type.Name);
                else
                    sb.Append(type);
            }

            return sb.ToString();
        }
    }

    /// <summary>
    /// Type metadata visit, a meta information access entry for TypeReflections and TypeVisit.
    /// </summary>
    public static partial class TypeMetaVisitExtensions
    {
        public static string GetFullyQualifiedName(this Type type)
        {
            if (type is null) throw new ArgumentNullException(nameof(type));
            return TypeVisit.GetFullyQualifiedName(type);
        }
    }
}