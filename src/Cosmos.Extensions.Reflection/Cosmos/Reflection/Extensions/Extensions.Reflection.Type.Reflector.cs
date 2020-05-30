using System;
using System.Linq;
using AspectCore.Extensions.Reflection;

// ReSharper disable once CheckNamespace
namespace Cosmos.Reflection
{
    public static partial class ReflectionExtensions
    {
        /// <summary>
        /// Is defined special attribute
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool IsDefined<TAttribute>(this Type type) where TAttribute : Attribute
            => type.GetReflector().IsDefined<TAttribute>();

        /// <summary>
        /// Is defined special attribute
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="type"></param>
        /// <param name="inherit"></param>
        /// <returns></returns>
        public static bool IsDefined<TAttribute>(this Type type, bool inherit) where TAttribute : Attribute
            => inherit
                ? type.GetCustomAttributes(typeof(TAttribute), true).Any(t => t is TAttribute)
                : type.IsDefined<TAttribute>();

        /// <summary>
        /// Is defined special attribute
        /// </summary>
        /// <param name="type"></param>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        public static bool IsDefined(this Type type, Type attributeType)
            => type.GetReflector().IsDefined(attributeType);

        /// <summary>
        /// Is defined special attribute
        /// </summary>
        /// <param name="type"></param>
        /// <param name="attributeType"></param>
        /// <param name="inherit"></param>
        /// <returns></returns>
        public static bool IsDefined(this Type type, Type attributeType, bool inherit)
            => inherit
                ? type.GetCustomAttributes(attributeType, true).Any(t => t.GetType() == attributeType)
                : type.GetReflector().IsDefined(attributeType);

        /// <summary>
        /// Is NOT defined special attribute
        /// </summary>
        /// <param name="type"></param>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns></returns>
        public static bool IsNotDefined<TAttribute>(this Type type) where TAttribute : Attribute
            => !type.IsDefined<TAttribute>();

        /// <summary>
        /// Is NOT defined special attribute
        /// </summary>
        /// <param name="type"></param>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        public static bool IsNotDefined(this Type type, Type attributeType)
            => !type.IsDefined(attributeType);

        /// <summary>
        /// Has attribute
        /// </summary>
        /// <param name="type"></param>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns></returns>
        public static bool HasAttribute<TAttribute>(this Type type) where TAttribute : Attribute
            => type.IsDefined<TAttribute>();

        /// <summary>
        /// Has attribute
        /// </summary>
        /// <param name="type"></param>
        /// <param name="inherit"></param>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns></returns>
        public static bool HasAttribute<TAttribute>(this Type type, bool inherit) where TAttribute : Attribute
            => type.IsDefined<TAttribute>(inherit);

        /// <summary>
        /// Has attribute
        /// </summary>
        /// <param name="type"></param>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        public static bool HasAttribute(this Type type, Type attributeType)
            => type.IsDefined(attributeType);

        /// <summary>
        /// Has attribute
        /// </summary>
        /// <param name="type"></param>
        /// <param name="attributeType"></param>
        /// <param name="inherit"></param>
        /// <returns></returns>
        public static bool HasAttribute(this Type type, Type attributeType, bool inherit)
            => type.IsDefined(attributeType, inherit);

        /// <summary>
        /// Has NOT attribute
        /// </summary>
        /// <param name="type"></param>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns></returns>
        public static bool HasNotAttribute<TAttribute>(this Type type) where TAttribute : Attribute
            => !type.IsDefined<TAttribute>();

        /// <summary>
        /// Has NOT attribute
        /// </summary>
        /// <param name="type"></param>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        public static bool HasNotAttribute(this Type type, Type attributeType)
            => !type.IsDefined(attributeType);

        /// <summary>
        /// Has interface
        /// </summary>
        /// <param name="type"></param>
        /// <typeparam name="TInterface"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static bool HasInterface<TInterface>(this Type type)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));

            var interfaceType = typeof(TInterface);

            if (!interfaceType.IsInterface)
                throw new ArgumentException($"Type '{interfaceType.FullName}' is not an interface type.");

            return type.TypeInfo().ImplementedInterfaces.Any(x => x == interfaceType);
        }

        /// <summary>
        /// Has interface
        /// </summary>
        /// <param name="type"></param>
        /// <param name="interfaceType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static bool HasInterface(this Type type, Type interfaceType)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));

            if (!interfaceType.IsInterface)
                throw new ArgumentException($"Type '{interfaceType.FullName}' is not an interface type.");

            return type.TypeInfo().ImplementedInterfaces.Any(x => x == interfaceType);
        }

        /// <summary>
        /// Has NOT interface
        /// </summary>
        /// <param name="type"></param>
        /// <typeparam name="TInterface"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static bool HasNotInterface<TInterface>(this Type type) =>
            !type.HasInterface<TInterface>();

        /// <summary>
        /// Has NOT interface
        /// </summary>
        /// <param name="type"></param>
        /// <param name="interfaceType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static bool HasNotInterface(this Type type, Type interfaceType)
            => !type.HasInterface(interfaceType);
    }
}