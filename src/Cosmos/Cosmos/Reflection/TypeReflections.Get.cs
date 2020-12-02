using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Cosmos.Reflection
{
    /// <summary>
    /// Property access type
    /// </summary>
    public enum PropertyAccessType
    {
        /// <summary>
        /// Getters
        /// </summary>
        Getters,

        /// <summary>
        /// Setters
        /// </summary>
        Setters
    }

    /// <summary>
    /// Reflection Utilities.
    /// </summary>
    public static partial class TypeReflections
    {
        #region Gets/Sets PropertyInfo

        /// <summary>
        /// Get all properties from the given Type.<br />
        /// 从给定的 Type 中获得所有属性。
        /// </summary>
        /// <param name="type"></param>
        /// <param name="accessType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static IEnumerable<PropertyInfo> GetProperties(Type type, PropertyAccessType accessType)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));

            return accessType switch
            {
                PropertyAccessType.Getters => type.GetPropertiesWithPublicInstanceGetters(),
                PropertyAccessType.Setters => type.GetPropertiesWithPublicInstanceSetters(),
                _ => throw new InvalidOperationException("Invalid operation for unknown access type")
            };
        }

        /// <summary>
        /// Get all properties from the given Type.<br />
        /// 从给定的 Type 中获得所有属性。
        /// </summary>
        /// <param name="accessType"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<PropertyInfo> GetProperties<T>(PropertyAccessType accessType)
        {
            return GetProperties(typeof(T), accessType);
        }

        private static IEnumerable<PropertyInfo> GetPropertiesWithPublicInstanceSetters(this Type type)
        {
            return type.GetRuntimeProperties().Where(p => p.SetMethod != null && !p.SetMethod.IsStatic && p.SetMethod.IsPublic);
        }

        private static IEnumerable<PropertyInfo> GetPropertiesWithPublicInstanceGetters(this Type type)
        {
            return type.GetRuntimeProperties().Where(p => p.GetMethod != null && !p.GetMethod.IsStatic && p.GetMethod.IsPublic);
        }

        #endregion
    }
}