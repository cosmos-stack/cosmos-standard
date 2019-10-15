using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using AspectCore.Extensions.Reflection;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    /// <summary>
    /// Type extensions
    /// </summary>
    public static partial class ReflectionExtensions
    {

        #region ToNonNullableType

        /// <summary>
        /// Get non-nullable inderlying <see cref="Type"/>
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Type ToNonNullableType(this Type type)
            => Conversions.TypeConversion.ToNonNullableType(type);

        /// <summary>
        /// Get non-nullable inderlying <see cref="TypeInfo"/>
        /// </summary>
        /// <param name="typeinfo"></param>
        /// <returns></returns>
        public static TypeInfo ToNonNullableTypeInfo(this TypeInfo typeinfo)
            => Conversions.TypeConversion.ToNonNullableTypeInfo(typeinfo);

        #endregion

        #region ToTypeInfo

        /// <summary>
        /// Get object's <see cref="TypeInfo"/>
        /// </summary>
        /// <param name="object"></param>
        /// <returns></returns>
        public static TypeInfo TypeInfo(this object @object)
            => @object.GetType().GetTypeInfo();

        /// <summary>
        /// Convert <see cref="Type"/> array to <see cref="TypeInfo"/> list
        /// </summary>
        /// <param name="types"></param>
        /// <returns></returns>
        public static IEnumerable<TypeInfo> ToTypeInfo(this Type[] types)
            => types.Select(type => type.GetTypeInfo());

        #endregion

        #region Gets/Sets PropertyValue

        /// <summary>
        /// Gets property value
        /// </summary>
        /// <param name="object">Any <see cref="object"/></param>
        /// <param name="propertyName">Property name in this object</param>
        /// <returns>Value of the specific property in this object</returns>
        public static object GetPropertyValue(this object @object, string propertyName)
            => @object.TypeInfo().GetProperty(propertyName).GetReflector().GetValue(@object);

        /// <summary>
        /// Sets property value
        /// </summary>
        /// <param name="object"></param>
        /// <param name="propertyName"></param>
        /// <param name="value"></param>
        public static void SetPropertyValue(this object @object, string propertyName, object value)
            => @object.TypeInfo().GetProperty(propertyName).GetReflector().SetValue(@object, value);

        #endregion

        #region Gets/Sets PropertyInfo

        /// <summary>
        /// Get properties
        /// </summary>
        /// <param name="type"></param>
        /// <param name="accessType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static IEnumerable<PropertyInfo> GetProperties(this Type type, PropertyAccessType accessType)
        {
            if (type == null)
                throw new ArgumentNullException(nameof(type));

            switch (accessType)
            {
                case PropertyAccessType.Getters:
                    return type.GetPropertiesWithPublicInstanceGetters();

                case PropertyAccessType.Setters:
                    return type.GetPropertiesWithPublicInstanceSetters();

                default:
                    throw new InvalidOperationException("Invalid operation for unknown access type");
            }
        }

        /// <summary>
        /// Get properties
        /// </summary>
        /// <param name="accessType"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<PropertyInfo> GetProperties<T>(PropertyAccessType accessType) => typeof(T).GetProperties(accessType);

        private static IEnumerable<PropertyInfo> GetPropertiesWithPublicInstanceSetters(this Type type)
        {
            // Get the properties.
            return type.GetRuntimeProperties().Where(p => p.SetMethod != null && !p.SetMethod.IsStatic && p.SetMethod.IsPublic);
        }

        private static IEnumerable<PropertyInfo> GetPropertiesWithPublicInstanceGetters(this Type type)
        {
            // Get the properties.
            // NOTE: Used to be
            //return type.GetTypeInfo().GetProperties(BindingFlags.Instance | BindingFlags.Public).
            return type.GetRuntimeProperties().Where(p => p.GetMethod != null && !p.GetMethod.IsStatic && p.GetMethod.IsPublic);
        }

        #endregion

        #region ToComputeSignature

        /// <summary>
        /// To compute signature
        /// </summary>
        /// <param name="typeinfo"></param>
        /// <returns></returns>
        public static string ToComputeSignature(this TypeInfo typeinfo)
        {
            var sb = new StringBuilder();
            if (typeinfo.IsGenericType)
            {
                sb.Append(typeinfo.GetGenericTypeDefinition().FullName)
                    .Append("[");

                var genericArgs = typeinfo.GetGenericArguments().ToTypeInfo().ToList();
                for (var i = 0; i < genericArgs.Count; i++)
                {
                    sb.Append(genericArgs[i].ToComputeSignature());
                    if (i != genericArgs.Count - 1)
                        sb.Append(", ");
                }

                sb.Append("]");
            }
            else
            {
                if (!string.IsNullOrEmpty(typeinfo.FullName))
                    sb.Append(typeinfo.FullName);
                else if (!string.IsNullOrEmpty(typeinfo.Name))
                    sb.Append(typeinfo.Name);
                else
                    sb.Append(typeinfo);
            }

            return sb.ToString();
        }

        /// <summary>
        /// To compute signature
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static string ToComputeSignature(this Type type) => ToComputeSignature(type.TypeInfo());

        #endregion

        #region IsAssignableToGenericType

        /// <summary>
        /// To judge the given type is assignable to the generic type or not
        /// </summary>
        /// <param name="givenType">给定类型</param>
        /// <param name="genericType">泛型类型</param>
        /// <returns></returns>
        public static bool IsAssignableToGenericType(this Type givenType, Type genericType)
            => Types.IsGenericImplementation(givenType, genericType);

        /// <summary>
        /// To judge the <see cref="givenType"/> is assignable to the <see cref="genericType"/> or not
        /// </summary>
        /// <param name="givenType">给定类型</param>
        /// <param name="genericType">泛型类型</param>
        /// <returns></returns>
        public static bool IsAssignableToGenericType(this TypeInfo givenType, TypeInfo genericType)
            => Types.IsGenericImplementation(genericType, genericType);

        /// <summary>
        /// To judge the <see cref="givenType"/> is assignable to the <see cref="TGeneric"/> or not
        /// </summary>
        /// <typeparam name="TGeneric">泛型类型</typeparam>
        /// <param name="givenType">给定类型</param>
        /// <returns></returns>
        public static bool IsAssignableToGenericType<TGeneric>(this Type givenType)
            => Types.IsGenericImplementation(givenType, typeof(TGeneric));

        /// <summary>
        /// To judge the <see cref="givenType"/> is assignable to the <see cref="TGeneric"/> or not
        /// </summary>
        /// <typeparam name="TGeneric">泛型类型</typeparam>
        /// <param name="givenType">给定类型</param>
        /// <returns></returns>
        public static bool IsAssignableToGenericType<TGeneric>(this TypeInfo givenType)
            => Types.IsGenericImplementation(givenType, typeof(TGeneric));

        /// <summary>
        /// To judge the given type is assignable to the generic type or not
        /// </summary>
        /// <param name="givenType">给定类型</param>
        /// <param name="genericType">泛型类型</param>
        /// <returns></returns>
        public static bool IsGenericImplementationFor(this Type givenType, Type genericType)
            => Types.IsGenericImplementation(givenType, genericType);

        /// <summary>
        /// To judge the <see cref="givenType"/> is assignable to the <see cref="genericType"/> or not
        /// </summary>
        /// <param name="givenType">给定类型</param>
        /// <param name="genericType">泛型类型</param>
        /// <returns></returns>
        public static bool IsGenericImplementationFor(this TypeInfo givenType, TypeInfo genericType)
            => Types.IsGenericImplementation(genericType, genericType);

        /// <summary>
        /// To judge the <see cref="givenType"/> is assignable to the <see cref="TGeneric"/> or not
        /// </summary>
        /// <typeparam name="TGeneric">泛型类型</typeparam>
        /// <param name="givenType">给定类型</param>
        /// <returns></returns>
        public static bool IsGenericImplementationFor<TGeneric>(this Type givenType)
            => Types.IsGenericImplementation(givenType, typeof(TGeneric));

        /// <summary>
        /// To judge the <see cref="givenType"/> is assignable to the <see cref="TGeneric"/> or not
        /// </summary>
        /// <typeparam name="TGeneric">泛型类型</typeparam>
        /// <param name="givenType">给定类型</param>
        /// <returns></returns>
        public static bool IsGenericImplementationFor<TGeneric>(this TypeInfo givenType)
            => Types.IsGenericImplementation(givenType, typeof(TGeneric));

        #endregion

        #region FindGenericType

        /// <summary>
        /// Find typeinfo from the given type's parameters' type
        /// </summary>
        /// <param name="definition"></param>
        /// <param name="typeinfo"></param>
        /// <returns></returns>
        public static TypeInfo FindGenericTypeInfo(this TypeInfo definition, TypeInfo typeinfo)
        {
            var objectTypeInfo = typeof(object).GetTypeInfo();
            while (typeinfo != null && typeinfo != objectTypeInfo)
            {
                if (typeinfo.IsGenericType && typeinfo.GetGenericTypeDefinition().GetTypeInfo() == definition)
                    return typeinfo;

                if (definition.IsInterface)
                {
                    foreach (var type in typeinfo.GetInterfaces())
                    {
                        var typeinfo2 = FindGenericTypeInfo(definition, type.GetTypeInfo());
                        if (typeinfo2 != null)
                            return typeinfo2;
                    }
                }

                typeinfo = typeinfo.BaseType.GetTypeInfo();
            }

            return null;
        }

        /// <summary>
        /// Find typeinfo from the given type's parameters' type
        /// </summary>
        /// <param name="definition"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static Type FindGenericType(this Type definition, Type type)
            => (FindGenericTypeInfo(definition.GetTypeInfo(), type.GetTypeInfo()))?.AsType();

        #endregion

        #region IsAssignableFrom

        /// <summary>
        /// Is assignable from...
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="this"></param>
        /// <returns></returns>
        public static bool IsAssignableFrom<T>(this object @this)
            => @this.GetType().IsAssignableFrom(typeof(T));

        /// <summary>
        /// Is assignable from...
        /// </summary>
        /// <param name="this"></param>
        /// <param name="from"></param>
        /// <returns></returns>
        public static bool IsAssignableFrom(this object @this, Type from)
            => @this.GetType().IsAssignableFrom(from);

        /// <summary>
        /// Is assignable from...
        /// </summary>
        /// <param name="to"></param>
        /// <param name="from"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static bool IsAssignableFrom(this Type to, Type from)
        {
            if (from == null) throw new ArgumentNullException(nameof(from));
            if (to == null) throw new ArgumentNullException(nameof(to));

            var fromTypeInfo = from.GetTypeInfo();
            var toTypeInfo = to.GetTypeInfo();

            return toTypeInfo.IsAssignableFrom(fromTypeInfo);
        }

        #endregion

    }
}