using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AspectCore.Extensions.Reflection;

namespace Cosmos.Reflection
{
    public enum ReflectionOptions
    {
        Default = 0,
        Inherit = 1
    }
    
    internal static class TypeReflectorHelper{
        public static ICustomAttributeReflectorProvider GetReflector(MemberInfo member)
        {
            return member switch
            {
                TypeInfo typeInfo => typeInfo.GetReflector(),
                Type type => type.GetReflector(),
                FieldInfo field => field.GetReflector(),
                PropertyInfo property => property.GetReflector(),
                MethodInfo method => method.GetReflector(),
                ConstructorInfo constructor => constructor.GetReflector(),
                _ => throw new InvalidOperationException("Current MemberInfo cannot be converted to Reflector.")
            };
        }

        public static ICustomAttributeReflectorProvider GetReflector(ParameterInfo parameter)
        {
            return parameter.GetReflector();
        }

        private static FieldInfo CustomAttributeReflectorRuntimeTypeHandle = typeof(CustomAttributeReflector).GetField("_tokens", BindingFlags.Instance | BindingFlags.NonPublic);

        public static HashSet<RuntimeTypeHandle> GetRuntimeTypeHandles(CustomAttributeReflector reflector)
        {
            return CustomAttributeReflectorRuntimeTypeHandle.GetValue(reflector) as HashSet<RuntimeTypeHandle>;
        }

    }

    /// <summary>
    /// Reflection Utilities.
    /// </summary>
    public static partial class TypeReflections
    {
      
        #region IsAttributeDefined

        /// <summary>
        /// To determine whether the given Attribute is defined.<br />
        /// 判断给定的特性是否定义。
        /// </summary>
        /// <param name="member"></param>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns></returns>
        public static bool IsAttributeDefined<TAttribute>(MemberInfo member) where TAttribute : Attribute
        {
            return IsAttributeDefinedImpl(TypeReflectorHelper.GetReflector(member), typeof(TAttribute));
        }

        /// <summary>
        /// To determine whether the given Attribute is defined.<br />
        /// 判断给定的特性是否定义。
        /// </summary>
        /// <param name="member"></param>
        /// <param name="options"></param>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns></returns>
        public static bool IsAttributeDefined<TAttribute>(MemberInfo member, ReflectionOptions options) where TAttribute : Attribute
        {
            return options switch
            {
                ReflectionOptions.Default => IsAttributeDefinedImpl(TypeReflectorHelper.GetReflector(member), typeof(TAttribute)),
                ReflectionOptions.Inherit => member.GetCustomAttributes<TAttribute>(true).Any(),
                _ => member.GetCustomAttributes<TAttribute>().Any()
            };
        }

        /// <summary>
        /// To determine whether the given Attribute is defined.<br />
        /// 判断给定的特性是否定义。
        /// </summary>
        /// <param name="parameter"></param>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns></returns>
        public static bool IsAttributeDefined<TAttribute>(ParameterInfo parameter) where TAttribute : Attribute
        {
            return IsAttributeDefinedImpl(TypeReflectorHelper.GetReflector(parameter), typeof(TAttribute));
        }

        /// <summary>
        /// To determine whether the given Attribute is defined.<br />
        /// 判断给定的特性是否定义。
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="options"></param>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns></returns>
        public static bool IsAttributeDefined<TAttribute>(ParameterInfo parameter, ReflectionOptions options) where TAttribute : Attribute
        {
            return options switch
            {
                ReflectionOptions.Default => parameter.GetCustomAttributes<TAttribute>().Any(),
                ReflectionOptions.Inherit => IsAttributeDefinedImpl(TypeReflectorHelper.GetReflector(parameter), typeof(TAttribute)),
                _ => parameter.GetCustomAttributes<TAttribute>().Any()
            };
        }

        /// <summary>
        /// To determine whether the given Attribute is defined.<br />
        /// 判断给定的特性是否定义。
        /// </summary>
        /// <param name="member"></param>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        public static bool IsAttributeDefined(MemberInfo member, Type attributeType)
        {
            return IsAttributeDefinedImpl(TypeReflectorHelper.GetReflector(member), attributeType);
        }

        /// <summary>
        /// To determine whether the given Attribute is defined.<br />
        /// 判断给定的特性是否定义。
        /// </summary>
        /// <param name="member"></param>
        /// <param name="attributeType"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static bool IsAttributeDefined(MemberInfo member, Type attributeType, ReflectionOptions options)
        {
            return options switch
            {
                ReflectionOptions.Default => IsAttributeDefinedImpl(TypeReflectorHelper.GetReflector(member), attributeType),
                ReflectionOptions.Inherit => member.GetCustomAttributes(attributeType, true).Any(),
                _ => member.GetCustomAttributes(attributeType).Any()
            };
        }

        /// <summary>
        /// To determine whether the given Attribute is defined.<br />
        /// 判断给定的特性是否定义。
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="attributeType"></param>
        /// <returns></returns>
        public static bool IsAttributeDefined(ParameterInfo parameter, Type attributeType) 
        {
            return IsAttributeDefinedImpl(TypeReflectorHelper.GetReflector(parameter), attributeType);
        }

        /// <summary>
        /// To determine whether the given Attribute is defined.<br />
        /// 判断给定的特性是否定义。
        /// </summary>
        /// <param name="parameter"></param>
        /// <param name="attributeType"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static bool IsAttributeDefined(ParameterInfo parameter, Type attributeType, ReflectionOptions options) 
        {
            return options switch
            {
                ReflectionOptions.Default => IsAttributeDefinedImpl(TypeReflectorHelper.GetReflector(parameter), attributeType),
                ReflectionOptions.Inherit => parameter.GetCustomAttributes(attributeType, true).Any(),
                _ => parameter.GetCustomAttributes(attributeType).Any()
            };
        }
        
        private static bool IsAttributeDefinedImpl(ICustomAttributeReflectorProvider customAttributeReflectorProvider, Type attributeType)
        {
            if (attributeType is null) throw new ArgumentNullException(nameof(attributeType));
            var attributeReflectors = customAttributeReflectorProvider != null
                ? customAttributeReflectorProvider.CustomAttributeReflectors
                : throw new ArgumentNullException(nameof(customAttributeReflectorProvider));
            var length = attributeReflectors.Length;
            if (length == 0) return false;
            var typeHandle = attributeType.TypeHandle;
            for (var i = 0; i < length; i++)
            {
                if (TypeReflectorHelper.GetRuntimeTypeHandles(attributeReflectors[i]).Contains(typeHandle))
                    return true;
            }

            return false;
        }

        #endregion
        
        #region GetAttribute

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
        /// <param name="memberInfo">Special member</param>
        /// <param name="attributeType"></param>
        /// <returns>Attribute of special field</returns>
        public static Attribute GetAttribute(MemberInfo memberInfo, Type attributeType) =>
            memberInfo?.GetCustomAttribute(attributeType);

        #endregion

        #region GetAttributes

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
        /// <param name="memberInfo">Special member</param>
        /// <param name="attributeType"></param>
        /// <returns>Attribute of special field</returns>
        public static IEnumerable<Attribute> GetAttributes(MemberInfo memberInfo, Type attributeType) =>
            memberInfo?.GetCustomAttributes(attributeType);

        #endregion

        #region GetRequiredAttribute

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
        /// <param name="memberInfo">Special member</param>
        /// <param name="attributeType"></param>
        /// <returns>Attribute of special field</returns>
        public static Attribute GetRequiredAttribute(MemberInfo memberInfo, Type attributeType) =>
            memberInfo?.GetCustomAttribute(attributeType) ??
            throw new ArgumentException($"There is no {attributeType} attribute can be found.");

        #endregion

        #region GetRequiredAttributes

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
        /// <param name="memberInfo">Special member</param>
        /// <param name="attributeType"></param>
        /// <returns>Attribute of special field</returns>
        public static IEnumerable<Attribute> GetRequiredAttributes(MemberInfo memberInfo, Type attributeType) =>
            memberInfo?.GetCustomAttributes(attributeType) ??
            throw new ArgumentException($"There is no any {attributeType} attributes can be found.");

        #endregion
    }
}