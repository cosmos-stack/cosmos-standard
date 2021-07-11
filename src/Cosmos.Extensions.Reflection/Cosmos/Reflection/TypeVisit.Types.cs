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

        /// <summary>
        /// Determine whether there is a parameterless constructor.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool HasEmptyConstructor(Type type)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));

            var ctor = type.GetConstructors().OrderBy(c => c.IsPublic ? 0 : (c.IsPrivate ? 2 : 1))
                           .ThenBy(c => c.GetParameters().Length)
                           .FirstOrDefault();

            return ctor?.GetParameters().Length == 0;
        }

        /// <summary>
        /// Get default constructor without any parameters.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static ConstructorInfo GetEmptyConstructor(Type type)
        {
            var ctor = type.GetConstructors()
                           .OrderBy(c => c.IsPublic ? 0 : (c.IsPrivate ? 2 : 1))
                           .ThenBy(c => c.GetParameters().Length)
                           .FirstOrDefault();

            return ctor?.GetParameters().Length == 0 ? ctor : null;
        }

        /// <summary>
        /// Finds a constructor with the matching type parameters.
        /// </summary>
        /// <param name="type">The type being tested.</param>
        /// <param name="constructorParameterTypes">The types of the contractor to find.</param>
        /// <returns>The <see cref="ConstructorInfo"/> is a match is found; otherwise, <c>null</c>.</returns>
        public static ConstructorInfo GetMatchingConstructor(Type type, Type[] constructorParameterTypes)
        {
            if (constructorParameterTypes == null || constructorParameterTypes.Length == 0)
                return GetEmptyConstructor(type);

            return type.GetConstructors()
                       .FirstOrDefault(c => c.GetParameters()
                                             .Select(p => p.ParameterType)
                                             .SequenceEqual(constructorParameterTypes)
                       );
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

        /// <summary>
        /// Determine whether there is a parameterless constructor.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool HasEmptyConstructor(this Type type)
        {
            return TypeVisit.HasEmptyConstructor(type);
        }

        /// <summary>
        /// Get default constructor without any parameters.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static ConstructorInfo GetEmptyConstructor(this Type type)
        {
            return TypeVisit.GetEmptyConstructor(type);
        }

        /// <summary>
        /// Finds a constructor with the matching type parameters.
        /// </summary>
        /// <param name="type">The type being tested.</param>
        /// <param name="constructorParameterTypes">The types of the contractor to find.</param>
        /// <returns>The <see cref="ConstructorInfo"/> is a match is found; otherwise, <c>null</c>.</returns>
        public static ConstructorInfo GetMatchingConstructor(this Type type, Type[] constructorParameterTypes)
        {
            return TypeVisit.GetMatchingConstructor(type, constructorParameterTypes);
        }
    }
}