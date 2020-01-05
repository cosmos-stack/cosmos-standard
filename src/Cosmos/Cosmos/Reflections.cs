using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using AspectCore.Extensions.Reflection;

namespace Cosmos {
    /// <summary>
    /// Reflection Utilities.
    /// </summary>
    public static class Reflections {
        /// <summary>
        /// Get description
        /// </summary>
        /// <typeparam name="T">Special typeInfo</typeparam>
        /// <returns>Description of special typeInfo</returns>
        public static string GetDescription<T>() {
            return GetDescription(Types.Of<T>());
        }

        /// <summary>
        /// Get description
        /// </summary>
        /// <param name="type">Special typeInfo</param>
        /// <returns>Description of special typeInfo</returns>
        public static string GetDescription(Type type) {
            return GetDescription(type.GetTypeInfo());
        }

        /// <summary>
        /// Get description
        /// </summary>
        /// <param name="typeInfo">Special typeInfo</param>
        /// <returns>Description of special typeInfo</returns>
        public static string GetDescription(TypeInfo typeInfo) {
            var attribute = GetAttribute<DescriptionAttribute>(typeInfo);
            return attribute is null ? typeInfo.Name : attribute.Description;
        }

        /// <summary>
        /// Get description
        /// </summary>
        /// <typeparam name="T">Special typeInfo</typeparam>
        /// <param name="memberName">Name of special member</param>
        /// <returns>Description of special typeInfo</returns>
        public static string GetDescription<T>(string memberName) {
            return GetDescription(Types.Of<T>(), memberName);
        }

        /// <summary>
        /// Get description
        /// </summary>
        /// <param name="type">Special typeInfo</param>
        /// <param name="memberName">Name of special member</param>
        /// <returns>Description of special typeInfo</returns>
        public static string GetDescription(Type type, string memberName) {
            return GetDescription(type.GetTypeInfo(), memberName);
        }

        /// <summary>
        /// Get description
        /// </summary>
        /// <param name="typeInfo">Special typeInfo</param>
        /// <param name="memberName">Name of special member</param>
        /// <returns>Description of special typeInfo</returns>
        public static string GetDescription(TypeInfo typeInfo, string memberName) {
            if (typeInfo is null) {
                return string.Empty;
            }

            return !string.IsNullOrWhiteSpace(memberName)
                ? string.Empty
                : GetDescription(typeInfo, typeInfo.GetField(memberName));
        }

        /// <summary>
        /// Get description
        /// </summary>
        /// <param name="memberInfo">Special member</param>
        /// <returns>Description of special member</returns>
        public static string GetDescription(MemberInfo memberInfo) {
            if (memberInfo is null)
                return string.Empty;
            var attribute = GetAttribute<DescriptionAttribute>(memberInfo);
            return attribute is null ? memberInfo.Name : attribute.Description;
        }

        /// <summary>
        /// Get description
        /// </summary>
        /// <param name="type">Special typeInfo</param>
        /// <param name="field">Special field</param>
        /// <returns>Description of special field</returns>
        public static string GetDescription(Type type, FieldInfo field) {
            return GetDescription(type.GetTypeInfo(), field);
        }

        /// <summary>
        /// Get description
        /// </summary>
        /// <param name="typeInfo">Special typeInfo</param>
        /// <param name="field">Special field</param>
        /// <returns>Description of special field</returns>
        public static string GetDescription(TypeInfo typeInfo, FieldInfo field) {
            if (typeInfo is null || field == null) {
                return string.Empty;
            }

            var attribute = GetAttribute<DescriptionAttribute>(field);
            return attribute is null ? field.Name : attribute.Description;
        }

        /// <summary>
        /// Get display name
        /// </summary>
        /// <typeparam name="T">Special typeInfo</typeparam>
        /// <returns>Description of special typeInfo</returns>
        public static string GetDisplayName<T>() {
            return GetDisplayName(typeof(T));
        }

        /// <summary>
        /// Get display name
        /// </summary>
        /// <param name="memberInfo">Special member</param>
        /// <returns>Description of special member</returns>
        private static string GetDisplayName(MemberInfo memberInfo) {
            if (memberInfo is null)
                return string.Empty;
            var displayNameAttribute = GetAttribute<DisplayNameAttribute>(memberInfo);
            if (displayNameAttribute != null)
                return displayNameAttribute.DisplayName;
            var displayAttribute = GetAttribute<DisplayAttribute>(memberInfo);
            if (displayAttribute is null)
                return string.Empty;
            return displayAttribute.Description;
        }

        /// <summary>
        /// Get display name or description, name first.
        /// </summary>
        /// <typeparam name="T">Special typeInfo</typeparam>
        /// <returns>Name or description of special typeInfo</returns>
        public static string GetDescriptionOrDisplayName<T>() {
            var result = GetDisplayName<T>();
            if (string.IsNullOrWhiteSpace(result))
                result = GetDescription<T>();
            return result;
        }

        /// <summary>
        /// Get display name or description, name first.
        /// </summary>
        /// <param name="memberInfo">Special member</param>
        /// <returns>Name or description of special member</returns>
        public static string GetDescriptionOrDisplayName(MemberInfo memberInfo) {
            var result = GetDisplayName(memberInfo);
            return !string.IsNullOrWhiteSpace(result) ? result : GetDescription(memberInfo);
        }

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="fieldInfo">Special field</param>
        /// <typeparam name="TAttribute">Special typeInfo of attribute</typeparam>
        /// <returns>Attribute of special field</returns>
        public static TAttribute GetAttribute<TAttribute>(FieldInfo fieldInfo) where TAttribute : Attribute {
            return fieldInfo?.GetReflector().GetCustomAttributes<TAttribute>().FirstOrDefault();
        }

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="memberInfo">Special member</param>
        /// <typeparam name="TAttribute">Special typeInfo of member</typeparam>
        /// <returns>Attribute of special field</returns>
        public static TAttribute GetAttribute<TAttribute>(MemberInfo memberInfo) where TAttribute : Attribute {
            return memberInfo is null ? null : GetAttribute<TAttribute>(memberInfo.GetType());
        }

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="type">Special typeInfo</param>
        /// <typeparam name="TAttribute">Special typeInfo of attribute</typeparam>
        /// <returns>Attribute of special typeInfo</returns>
        public static TAttribute GetAttribute<TAttribute>(Type type) where TAttribute : Attribute {
            return type is null ? null : GetAttribute<TAttribute>(type.GetTypeInfo());
        }

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="typeInfo">Special typeInfo</param>
        /// <typeparam name="TAttribute">Special typeInfo of attribute</typeparam>
        /// <returns>Attribute of special typeInfo</returns>
        public static TAttribute GetAttribute<TAttribute>(TypeInfo typeInfo) where TAttribute : Attribute {
            return typeInfo?.GetReflector().GetCustomAttributes<TAttribute>().FirstOrDefault();
        }

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="fieldInfo">Special field</param>
        /// <typeparam name="TAttribute">Special typeInfo of attribute</typeparam>
        /// <returns>Attribute of special field</returns>
        public static TAttribute GetRequiredAttribute<TAttribute>(FieldInfo fieldInfo) where TAttribute : Attribute {
            return fieldInfo?.GetReflector().GetCustomAttribute<TAttribute>();
        }

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="memberInfo">Special member</param>
        /// <typeparam name="TAttribute">Special typeInfo of attribute</typeparam>
        /// <returns>Attribute of special member</returns>
        public static TAttribute GetRequiredAttribute<TAttribute>(MemberInfo memberInfo) where TAttribute : Attribute {
            return memberInfo is null ? null : GetRequiredAttribute<TAttribute>(memberInfo.GetType());
        }

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="type">Special typeInfo</param>
        /// <typeparam name="TAttribute">Special typeInfo of attribute</typeparam>
        /// <returns>Attribute of special typeInfo</returns>
        public static TAttribute GetRequiredAttribute<TAttribute>(Type type) where TAttribute : Attribute {
            return type is null ? null : GetRequiredAttribute<TAttribute>(type.GetTypeInfo());
        }

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="typeInfo">Special typeInfo</param>
        /// <typeparam name="TAttribute">Special typeInfo of attribute</typeparam>
        /// <returns>Attribute of special typeInfo</returns>
        public static TAttribute GetRequiredAttribute<TAttribute>(TypeInfo typeInfo) where TAttribute : Attribute {
            return typeInfo?.GetReflector().GetCustomAttribute<TAttribute>();
        }
    }
}