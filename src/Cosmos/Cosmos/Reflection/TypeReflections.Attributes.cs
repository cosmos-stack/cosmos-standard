using System;
using System.Collections.Generic;
using System.Reflection;
using AspectCore.Extensions.Reflection;

namespace Cosmos.Reflection
{
    /// <summary>
    /// Reflection Utilities.
    /// </summary>
    public static partial class TypeReflections
    {
        #region GetAttribute

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="fieldInfo">Special field</param>
        /// <typeparam name="TAttribute">Special typeInfo of attribute</typeparam>
        /// <returns>Attribute of special field</returns>
        public static TAttribute GetAttribute<TAttribute>(FieldInfo fieldInfo) where TAttribute : Attribute =>
            fieldInfo?.GetReflector().GetCustomAttribute<TAttribute>();

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="memberInfo">Special member</param>
        /// <typeparam name="TAttribute">Special typeInfo of member</typeparam>
        /// <returns>Attribute of special field</returns>
        public static TAttribute GetAttribute<TAttribute>(MemberInfo memberInfo) where TAttribute : Attribute =>
            memberInfo?.GetCustomAttribute<TAttribute>();

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="type">Special typeInfo</param>
        /// <typeparam name="TAttribute">Special typeInfo of attribute</typeparam>
        /// <returns>Attribute of special typeInfo</returns>
        public static TAttribute GetAttribute<TAttribute>(Type type) where TAttribute : Attribute =>
            type?.GetReflector().GetCustomAttribute<TAttribute>();

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="typeInfo">Special typeInfo</param>
        /// <typeparam name="TAttribute">Special typeInfo of attribute</typeparam>
        /// <returns>Attribute of special typeInfo</returns>
        public static TAttribute GetAttribute<TAttribute>(TypeInfo typeInfo) where TAttribute : Attribute =>
            typeInfo?.GetReflector().GetCustomAttribute<TAttribute>();

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="fieldInfo">Special field</param>
        /// <param name="attributeType"></param>
        /// <returns>Attribute of special field</returns>
        public static Attribute GetAttribute(FieldInfo fieldInfo, Type attributeType) =>
            fieldInfo?.GetReflector().GetCustomAttribute(attributeType);

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="memberInfo">Special member</param>
        /// <param name="attributeType"></param>
        /// <returns>Attribute of special field</returns>
        public static Attribute GetAttribute(MemberInfo memberInfo, Type attributeType) =>
            memberInfo?.GetCustomAttribute(attributeType);

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="type">Special typeInfo</param>
        /// <param name="attributeType"></param>
        /// <returns>Attribute of special typeInfo</returns>
        public static Attribute GetAttribute(Type type, Type attributeType) =>
            type?.GetReflector().GetCustomAttribute(attributeType);

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="typeInfo">Special typeInfo</param>
        /// <param name="attributeType"></param>
        /// <returns>Attribute of special typeInfo</returns>
        public static Attribute GetAttribute(TypeInfo typeInfo, Type attributeType) =>
            typeInfo?.GetReflector().GetCustomAttribute(attributeType);

        #endregion

        #region GetAttributes

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="fieldInfo">Special field</param>
        /// <typeparam name="TAttribute">Special typeInfo of attribute</typeparam>
        /// <returns>Attribute of special field</returns>
        public static IEnumerable<TAttribute> GetAttributes<TAttribute>(FieldInfo fieldInfo) where TAttribute : Attribute =>
            fieldInfo?.GetReflector().GetCustomAttributes<TAttribute>();

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="memberInfo">Special member</param>
        /// <typeparam name="TAttribute">Special typeInfo of member</typeparam>
        /// <returns>Attribute of special field</returns>
        public static IEnumerable<TAttribute> GetAttributes<TAttribute>(MemberInfo memberInfo) where TAttribute : Attribute =>
            memberInfo?.GetCustomAttributes<TAttribute>();

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="type">Special typeInfo</param>
        /// <typeparam name="TAttribute">Special typeInfo of attribute</typeparam>
        /// <returns>Attribute of special typeInfo</returns>
        public static IEnumerable<TAttribute> GetAttributes<TAttribute>(Type type) where TAttribute : Attribute =>
            type?.GetReflector().GetCustomAttributes<TAttribute>();

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="typeInfo">Special typeInfo</param>
        /// <typeparam name="TAttribute">Special typeInfo of attribute</typeparam>
        /// <returns>Attribute of special typeInfo</returns>
        public static IEnumerable<TAttribute> GetAttributes<TAttribute>(TypeInfo typeInfo) where TAttribute : Attribute =>
            typeInfo?.GetReflector().GetCustomAttributes<TAttribute>();

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="fieldInfo">Special field</param>
        /// <param name="attributeType"></param>
        /// <returns>Attribute of special field</returns>
        public static IEnumerable<Attribute> GetAttributes(FieldInfo fieldInfo, Type attributeType) =>
            fieldInfo?.GetReflector().GetCustomAttributes(attributeType);

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="memberInfo">Special member</param>
        /// <param name="attributeType"></param>
        /// <returns>Attribute of special field</returns>
        public static IEnumerable<Attribute> GetAttributes(MemberInfo memberInfo, Type attributeType) =>
            memberInfo?.GetCustomAttributes(attributeType);

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="type">Special typeInfo</param>
        /// <param name="attributeType"></param>
        /// <returns>Attribute of special typeInfo</returns>
        public static IEnumerable<Attribute> GetAttributes(Type type, Type attributeType) =>
            type?.GetReflector().GetCustomAttributes(attributeType);

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="typeInfo">Special typeInfo</param>
        /// <param name="attributeType"></param>
        /// <returns>Attribute of special typeInfo</returns>
        public static IEnumerable<Attribute> GetAttributes(TypeInfo typeInfo, Type attributeType) =>
            typeInfo?.GetReflector().GetCustomAttributes(attributeType);

        #endregion

        #region GetRequiredAttribute

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="fieldInfo">Special field</param>
        /// <typeparam name="TAttribute">Special typeInfo of attribute</typeparam>
        /// <returns>Attribute of special field</returns>
        public static TAttribute GetRequiredAttribute<TAttribute>(FieldInfo fieldInfo) where TAttribute : Attribute =>
            fieldInfo?.GetReflector().GetCustomAttribute<TAttribute>() ??
            throw new ArgumentException($"There is no {typeof(TAttribute)} attribute can be found.");

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="memberInfo">Special member</param>
        /// <typeparam name="TAttribute">Special typeInfo of attribute</typeparam>
        /// <returns>Attribute of special member</returns>
        public static TAttribute GetRequiredAttribute<TAttribute>(MemberInfo memberInfo) where TAttribute : Attribute =>
            memberInfo?.GetCustomAttribute<TAttribute>() ??
            throw new ArgumentException($"There is no {typeof(TAttribute)} attribute can be found.");

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="type">Special typeInfo</param>
        /// <typeparam name="TAttribute">Special typeInfo of attribute</typeparam>
        /// <returns>Attribute of special typeInfo</returns>
        public static TAttribute GetRequiredAttribute<TAttribute>(Type type) where TAttribute : Attribute =>
            type?.GetReflector().GetCustomAttribute<TAttribute>() ??
            throw new ArgumentException($"There is no {typeof(TAttribute)} attribute can be found.");

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="typeInfo">Special typeInfo</param>
        /// <typeparam name="TAttribute">Special typeInfo of attribute</typeparam>
        /// <returns>Attribute of special typeInfo</returns>
        public static TAttribute GetRequiredAttribute<TAttribute>(TypeInfo typeInfo) where TAttribute : Attribute =>
            typeInfo?.GetReflector().GetCustomAttribute<TAttribute>() ??
            throw new ArgumentException($"There is no {typeof(TAttribute)} attribute can be found.");

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="fieldInfo">Special field</param>
        /// <param name="attributeType"></param>
        /// <returns>Attribute of special field</returns>
        public static Attribute GetRequiredAttribute(FieldInfo fieldInfo, Type attributeType) =>
            fieldInfo?.GetReflector().GetCustomAttribute(attributeType) ??
            throw new ArgumentException($"There is no {attributeType} attribute can be found.");

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="memberInfo">Special member</param>
        /// <param name="attributeType"></param>
        /// <returns>Attribute of special field</returns>
        public static Attribute GetRequiredAttribute(MemberInfo memberInfo, Type attributeType) =>
            memberInfo?.GetCustomAttribute(attributeType) ??
            throw new ArgumentException($"There is no {attributeType} attribute can be found.");

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="type">Special typeInfo</param>
        /// <param name="attributeType"></param>
        /// <returns>Attribute of special typeInfo</returns>
        public static Attribute GetRequiredAttribute(Type type, Type attributeType) =>
            type?.GetReflector().GetCustomAttribute(attributeType) ??
            throw new ArgumentException($"There is no {attributeType} attribute can be found.");

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="typeInfo">Special typeInfo</param>
        /// <param name="attributeType"></param>
        /// <returns>Attribute of special typeInfo</returns>
        public static Attribute GetRequiredAttribute(TypeInfo typeInfo, Type attributeType) =>
            typeInfo?.GetReflector().GetCustomAttribute(attributeType) ??
            throw new ArgumentException($"There is no {attributeType} attribute can be found.");

        #endregion

        #region GetRequiredAttributes

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="fieldInfo">Special field</param>
        /// <typeparam name="TAttribute">Special typeInfo of attribute</typeparam>
        /// <returns>Attribute of special field</returns>
        public static IEnumerable<TAttribute> GetRequiredAttributes<TAttribute>(FieldInfo fieldInfo) where TAttribute : Attribute =>
            fieldInfo?.GetReflector().GetCustomAttributes<TAttribute>() ??
            throw new ArgumentException($"There is no any {typeof(TAttribute)} attributes can be found.");

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="memberInfo">Special member</param>
        /// <typeparam name="TAttribute">Special typeInfo of attribute</typeparam>
        /// <returns>Attribute of special member</returns>
        public static IEnumerable<TAttribute> GetRequiredAttributes<TAttribute>(MemberInfo memberInfo) where TAttribute : Attribute =>
            memberInfo?.GetCustomAttributes<TAttribute>() ??
            throw new ArgumentException($"There is no any {typeof(TAttribute)} attributes can be found.");

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="type">Special typeInfo</param>
        /// <typeparam name="TAttribute">Special typeInfo of attribute</typeparam>
        /// <returns>Attribute of special typeInfo</returns>
        public static IEnumerable<TAttribute> GetRequiredAttributes<TAttribute>(Type type) where TAttribute : Attribute =>
            type?.GetReflector().GetCustomAttributes<TAttribute>() ??
            throw new ArgumentException($"There is no any {typeof(TAttribute)} attributes can be found.");

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="typeInfo">Special typeInfo</param>
        /// <typeparam name="TAttribute">Special typeInfo of attribute</typeparam>
        /// <returns>Attribute of special typeInfo</returns>
        public static IEnumerable<TAttribute> GetRequiredAttributes<TAttribute>(TypeInfo typeInfo) where TAttribute : Attribute =>
            typeInfo?.GetReflector().GetCustomAttributes<TAttribute>() ??
            throw new ArgumentException($"There is no any {typeof(TAttribute)} attributes can be found.");

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="fieldInfo">Special field</param>
        /// <param name="attributeType"></param>
        /// <returns>Attribute of special field</returns>
        public static IEnumerable<Attribute> GetRequiredAttributes(FieldInfo fieldInfo, Type attributeType) =>
            fieldInfo?.GetReflector().GetCustomAttributes(attributeType) ??
            throw new ArgumentException($"There is no any {attributeType} attributes can be found.");

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="memberInfo">Special member</param>
        /// <param name="attributeType"></param>
        /// <returns>Attribute of special field</returns>
        public static IEnumerable<Attribute> GetRequiredAttributes(MemberInfo memberInfo, Type attributeType) =>
            memberInfo?.GetCustomAttributes(attributeType) ??
            throw new ArgumentException($"There is no any {attributeType} attributes can be found.");

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="type">Special typeInfo</param>
        /// <param name="attributeType"></param>
        /// <returns>Attribute of special typeInfo</returns>
        public static IEnumerable<Attribute> GetRequiredAttributes(Type type, Type attributeType) =>
            type?.GetReflector().GetCustomAttributes(attributeType) ??
            throw new ArgumentException($"There is no any {attributeType} attributes can be found.");

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="typeInfo">Special typeInfo</param>
        /// <param name="attributeType"></param>
        /// <returns>Attribute of special typeInfo</returns>
        public static IEnumerable<Attribute> GetRequiredAttributes(TypeInfo typeInfo, Type attributeType) =>
            typeInfo?.GetReflector().GetCustomAttributes(attributeType) ??
            throw new ArgumentException($"There is no any {attributeType} attributes can be found.");

        #endregion
    }
}