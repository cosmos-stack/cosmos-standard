using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Cosmos.Reflection
{
    /// <summary>
    /// Reflection Utilities.
    /// </summary>
    public static partial class TypeReflections
    {
        /// <summary>
        /// Get description
        /// </summary>
        /// <typeparam name="T">Special typeInfo</typeparam>
        /// <returns>Description of special typeInfo</returns>
        public static string GetDescription<T>()
        {
            var type = typeof(T);
            var attribute = GetAttribute<DescriptionAttribute>(type);
            return attribute?.Description ?? type.Name;
        }

        /// <summary>
        /// Get description
        /// </summary>
        /// <param name="type">Special typeInfo</param>
        /// <returns>Description of special typeInfo</returns>
        public static string GetDescription(Type type)
        {
            var attribute = GetAttribute<DescriptionAttribute>(type);
            return attribute?.Description ?? type.Name;
        }

        /// <summary>
        /// Get description
        /// </summary>
        /// <param name="typeInfo">Special typeInfo</param>
        /// <returns>Description of special typeInfo</returns>
        public static string GetDescription(TypeInfo typeInfo)
        {
            var attribute = GetAttribute<DescriptionAttribute>(typeInfo);
            return attribute?.Description ?? typeInfo.Name;
        }

        /// <summary>
        /// Get description
        /// </summary>
        /// <typeparam name="T">Special typeInfo</typeparam>
        /// <param name="memberName">Name of special member</param>
        /// <returns>Description of special typeInfo</returns>
        public static string GetDescription<T>(string memberName) =>
            GetDescription(Types.Of<T>(), memberName);

        /// <summary>
        /// Get description
        /// </summary>
        /// <param name="type">Special typeInfo</param>
        /// <param name="memberName">Name of special member</param>
        /// <returns>Description of special typeInfo</returns>
        public static string GetDescription(Type type, string memberName) =>
            GetDescription(type.GetTypeInfo(), memberName);

        /// <summary>
        /// Get description
        /// </summary>
        /// <param name="typeInfo">Special typeInfo</param>
        /// <param name="memberName">Name of special member</param>
        /// <returns>Description of special typeInfo</returns>
        public static string GetDescription(TypeInfo typeInfo, string memberName)
        {
            if (typeInfo is null)
                return string.Empty;
            return !string.IsNullOrWhiteSpace(memberName)
                ? string.Empty
                : GetDescription(typeInfo, typeInfo.GetField(memberName!));
        }

        /// <summary>
        /// Get description
        /// </summary>
        /// <param name="memberInfo">Special member</param>
        /// <returns>Description of special member</returns>
        public static string GetDescription(MemberInfo memberInfo)
        {
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
        public static string GetDescription(Type type, FieldInfo field) =>
            GetDescription(type.GetTypeInfo(), field);

        /// <summary>
        /// Get description
        /// </summary>
        /// <param name="typeInfo">Special typeInfo</param>
        /// <param name="field">Special field</param>
        /// <returns>Description of special field</returns>
        public static string GetDescription(TypeInfo typeInfo, FieldInfo field)
        {
            if (typeInfo is null || field is null)
                return string.Empty;
            var attribute = GetAttribute<DescriptionAttribute>(field);
            return attribute is null ? field.Name : attribute.Description;
        }

        /// <summary>
        /// Get display name
        /// </summary>
        /// <typeparam name="T">Special typeInfo</typeparam>
        /// <returns>Description of special typeInfo</returns>
        public static string GetDisplayName<T>() => GetDisplayName(typeof(T));

        /// <summary>
        /// Get display name
        /// </summary>
        /// <param name="memberInfo">Special member</param>
        /// <returns>Description of special member</returns>
        private static string GetDisplayName(MemberInfo memberInfo)
        {
            if (memberInfo is null)
                return string.Empty;
            var displayNameAttribute = GetAttribute<DisplayNameAttribute>(memberInfo);
            if (displayNameAttribute != null)
                return displayNameAttribute.DisplayName;
//#if NETCOREAPP3_0
//            return string.Empty;
//#else
            var displayAttribute = GetAttribute<DisplayAttribute>(memberInfo);
            if (displayAttribute is null)
                return string.Empty;
            return displayAttribute.Description;
//#endif
        }

        /// <summary>
        /// Get display name or description, name first.
        /// </summary>
        /// <typeparam name="T">Special typeInfo</typeparam>
        /// <returns>Name or description of special typeInfo</returns>
        public static string GetDescriptionOrDisplayName<T>()
        {
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
        public static string GetDescriptionOrDisplayName(MemberInfo memberInfo)
        {
            var result = GetDisplayName(memberInfo);
            return !string.IsNullOrWhiteSpace(result) ? result : GetDescription(memberInfo);
        }
    }
}