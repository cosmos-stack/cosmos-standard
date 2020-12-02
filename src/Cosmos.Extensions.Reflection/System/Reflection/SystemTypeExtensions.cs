using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cosmos.Reflection;

namespace System.Reflection
{
    /// <summary>
    /// Cosmos <see cref="Type"/> extensions
    /// </summary>
    public static partial class SystemTypeExtensions
    {
        #region ToTypeInfo

        /// <summary>
        /// Get that's <see cref="TypeInfo"/><br />
        /// 获取给定对象的 <see cref="TypeInfo"/>。
        /// </summary>
        /// <param name="that"></param>
        /// <returns></returns>
        public static TypeInfo TypeInfo(this object that)
            => that.GetType().GetTypeInfo();

        /// <summary>
        /// Convert <see cref="Type"/> array to <see cref="TypeInfo"/> list.<br />
        /// 将给定的 <see cref="Type"/> 数组转换为 <see cref="TypeInfo"/> 列表。
        /// </summary>
        /// <param name="types"></param>
        /// <returns></returns>
        public static IEnumerable<TypeInfo> ToTypeInfo(this Type[] types)
            => types.Select(type => type.GetTypeInfo());

        #endregion
        
        #region FindGenericType

        private static readonly TypeInfo ObjectTypeInfo = TypeClass.ObjectClazz.GetTypeInfo();

        /// <summary>
        /// Find <see cref="TypeInfo"/> from the given type's parameters' type
        /// </summary>
        /// <param name="definition"></param>
        /// <param name="typeInfo"></param>
        /// <returns></returns>
        public static TypeInfo FindGenericTypeInfo(this TypeInfo definition, TypeInfo typeInfo)
        {
            while (typeInfo != null && typeInfo != ObjectTypeInfo)
            {
                if (typeInfo.IsGenericType && typeInfo.GetGenericTypeDefinition().GetTypeInfo() == definition)
                    return typeInfo;

                if (definition.IsInterface)
                {
                    foreach (var type in typeInfo.GetInterfaces())
                    {
                        var __ = FindGenericTypeInfo(definition, type.GetTypeInfo());
                        if (__ != null)
                            return __;
                    }
                }

                typeInfo = typeInfo.BaseType?.GetTypeInfo();
            }

            return null;
        }

        /// <summary>
        /// Find <see cref="Type"/> from the given type's parameters' type<br />
        /// </summary>
        /// <param name="definition"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Type FindGenericType(this Type definition, Type type)
            => (FindGenericTypeInfo(definition.GetTypeInfo(), type.GetTypeInfo()))?.AsType();

        #endregion

        #region GetFullyQualifiedName

        /// <summary>
        /// Get unique fully qualified name for <see cref="TypeInfo"/>.<br />
        /// 获取给定 <see cref="TypeInfo"/> 的完全限定名。
        /// </summary>
        /// <param name="typeInfo"></param>
        /// <returns></returns>
        public static string GetFullyQualifiedName(this TypeInfo typeInfo)
        {
            var sb = new StringBuilder();
            if (typeInfo.IsGenericType)
            {
                sb.Append(typeInfo.GetGenericTypeDefinition().FullName)
                    .Append("[");

                var genericArgs = typeInfo.GetGenericArguments().ToTypeInfo().ToList();
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
                if (!string.IsNullOrEmpty(typeInfo.FullName))
                    sb.Append(typeInfo.FullName);
                else if (!string.IsNullOrEmpty(typeInfo.Name))
                    sb.Append(typeInfo.Name);
                else
                    sb.Append(typeInfo);
            }

            return sb.ToString();
        }

        /// <summary>
        /// Get unique fully qualified name for <see cref="TypeInfo"/>.<br />
        /// 获取给定 <see cref="TypeInfo"/> 的完全限定名。
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string GetFullyQualifiedName(this Type type) => GetFullyQualifiedName(type.TypeInfo());

        #endregion
    }
}