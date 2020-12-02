using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AspectCore.Extensions.Reflection;

// ReSharper disable PossibleMultipleEnumeration

namespace Cosmos.Reflection
{
    public enum ReflectionOptions
    {
        Default = 0,
        Inherit = 1
    }

    public enum ReflectionAmbiguousOptions
    {
        Default = 0,
        IgnoreAmbiguous = 1
    }

    internal static class TypeReflectorHelper
    {
        public static ICustomAttributeReflectorProvider GetReflector(MemberInfo member)
        {
            if (member is null)
                throw new ArgumentNullException(nameof(member));
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
        private static TRequired AttrRequired<TRequired>(this TRequired value, string message)
        {
            return value ?? throw new ArgumentException(message);
        }

        private static IEnumerable<TRequired> AttrRequired<TRequired>(this IEnumerable<TRequired> value, string message)
        {
            if (value is null || !value.Any())
                throw new ArgumentException(message);
            return value;
        }

        private static TAttribute AttrDisambiguation<TAttribute>(this IEnumerable<TAttribute> value)
        {
            return value.FirstOrDefault();
        }

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
        /// <param name="member">Special member</param>
        /// <param name="attributeType"></param>
        /// <returns>Attribute of special field</returns>
        public static Attribute GetAttribute(MemberInfo member, Type attributeType)
        {
            return GetAttributeImpl(TypeReflectorHelper.GetReflector(member), attributeType);
        }

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="member"></param>
        /// <param name="attributeType"></param>
        /// <param name="refOptions"></param>
        /// <param name="ambOptions"></param>
        /// <returns></returns>
        public static Attribute GetAttribute(MemberInfo member, Type attributeType, ReflectionOptions refOptions, ReflectionAmbiguousOptions ambOptions = ReflectionAmbiguousOptions.Default)
        {
            return refOptions switch
            {
                ReflectionOptions.Default => GetAttributeImpl(TypeReflectorHelper.GetReflector(member), attributeType),
                ReflectionOptions.Inherit => ambOptions switch
                {
                    ReflectionAmbiguousOptions.Default => member.GetCustomAttribute(attributeType, true),
                    ReflectionAmbiguousOptions.IgnoreAmbiguous => GetAttributes(member, attributeType, refOptions).AttrDisambiguation(),
                    _ => member.GetCustomAttribute(attributeType, true)
                },
                _ => member.GetCustomAttribute(attributeType)
            };
        }

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="member">Special member</param>
        /// <typeparam name="TAttribute">Special typeInfo of member</typeparam>
        /// <returns>Attribute of special field</returns>
        public static TAttribute GetAttribute<TAttribute>(MemberInfo member) where TAttribute : Attribute
        {
            return (TAttribute) GetAttributeImpl(TypeReflectorHelper.GetReflector(member), typeof(TAttribute));
        }

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="member"></param>
        /// <param name="refOptions"></param>
        /// <param name="ambOptions"></param>
        /// <typeparam name="TAttribute"></typeparam>
        /// <returns></returns>
        public static TAttribute GetAttribute<TAttribute>(MemberInfo member, ReflectionOptions refOptions, ReflectionAmbiguousOptions ambOptions = ReflectionAmbiguousOptions.Default) where TAttribute : Attribute
        {
            return refOptions switch
            {
                ReflectionOptions.Default => (TAttribute) GetAttributeImpl(TypeReflectorHelper.GetReflector(member), typeof(TAttribute)),
                ReflectionOptions.Inherit => ambOptions switch
                {
                    ReflectionAmbiguousOptions.Default => member.GetCustomAttribute<TAttribute>(true),
                    ReflectionAmbiguousOptions.IgnoreAmbiguous => GetAttributes<TAttribute>(member, refOptions).AttrDisambiguation(),
                    _ => member.GetCustomAttribute<TAttribute>(true)
                },
                _ => member.GetCustomAttribute<TAttribute>()
            };
        }

        private static Attribute GetAttributeImpl(ICustomAttributeReflectorProvider customAttributeReflectorProvider, Type attributeType)
        {
            if (attributeType is null) throw new ArgumentNullException(nameof(attributeType));
            var attributeReflectors = customAttributeReflectorProvider != null
                ? customAttributeReflectorProvider.CustomAttributeReflectors
                : throw new ArgumentNullException(nameof(customAttributeReflectorProvider));
            var length = attributeReflectors.Length;
            if (length == 0) return default;
            var typeHandle = attributeType.TypeHandle;
            for (var i = 0; i < length; i++)
            {
                if (TypeReflectorHelper.GetRuntimeTypeHandles(attributeReflectors[i]).Contains(typeHandle))
                    return attributeReflectors[i].Invoke();
            }

            return default;
        }

        #endregion

        #region GetAttributes

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="member">Special member</param>
        /// <typeparam name="TAttribute">Special typeInfo of member</typeparam>
        /// <returns>Attribute of special field</returns>
        public static IEnumerable<TAttribute> GetAttributes<TAttribute>(MemberInfo member) where TAttribute : Attribute
        {
            return GetAttributesImpl(TypeReflectorHelper.GetReflector(member), typeof(TAttribute)).Cast<TAttribute>();
        }

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="member">Special member</param>
        /// <param name="refOptions"></param>
        /// <typeparam name="TAttribute">Special typeInfo of member</typeparam>
        /// <returns>Attribute of special field</returns>
        public static IEnumerable<TAttribute> GetAttributes<TAttribute>(MemberInfo member, ReflectionOptions refOptions) where TAttribute : Attribute
        {
            return refOptions switch
            {
                ReflectionOptions.Default => GetAttributesImpl(TypeReflectorHelper.GetReflector(member), typeof(TAttribute)).Cast<TAttribute>(),
                ReflectionOptions.Inherit => member.GetCustomAttributes<TAttribute>(true),
                _ => member.GetCustomAttributes<TAttribute>()
            };
        }

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="member">Special member</param>
        /// <param name="attributeType"></param>
        /// <returns>Attribute of special field</returns>
        public static IEnumerable<Attribute> GetAttributes(MemberInfo member, Type attributeType)
        {
            return GetAttributesImpl(TypeReflectorHelper.GetReflector(member), attributeType);
        }

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="member">Special member</param>
        /// <param name="attributeType"></param>
        /// <param name="refOptions"></param>
        /// <returns>Attribute of special field</returns>
        public static IEnumerable<Attribute> GetAttributes(MemberInfo member, Type attributeType, ReflectionOptions refOptions)
        {
            return refOptions switch
            {
                ReflectionOptions.Default => GetAttributesImpl(TypeReflectorHelper.GetReflector(member), attributeType),
                ReflectionOptions.Inherit => member.GetCustomAttributes(attributeType, true) as Attribute[],
                _ => member.GetCustomAttributes(attributeType)
            };
        }

        private static IEnumerable<Attribute> GetAttributesImpl(ICustomAttributeReflectorProvider customAttributeReflectorProvider, Type attributeType)
        {
            if (attributeType is null) throw new ArgumentNullException(nameof(attributeType));
            var attributeReflectors = customAttributeReflectorProvider != null
                ? customAttributeReflectorProvider.CustomAttributeReflectors
                : throw new ArgumentNullException(nameof(customAttributeReflectorProvider));
            var length = attributeReflectors.Length;
            if (length == 0)
                return Enumerable.Empty<Attribute>();
            var typeHandle = attributeType.TypeHandle;
            var holder = new Attribute[length];
            var counter = 0;
            for (var i = 0; i < length; i++)
            {
                var attributeReflector = attributeReflectors[i];
                if (TypeReflectorHelper.GetRuntimeTypeHandles(attributeReflector).Contains(typeHandle))
                    holder[counter++] = attributeReflector.Invoke();
            }

            if (length == counter)
                return holder;

            var result = new Attribute[counter];
            Array.Copy(holder, result, counter);
            return result;
        }

        #endregion

        #region GetRequiredAttribute

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="member">Special member</param>
        /// <typeparam name="TAttribute">Special typeInfo of attribute</typeparam>
        /// <returns>Attribute of special member</returns>
        public static TAttribute GetAttributeRequired<TAttribute>(MemberInfo member) where TAttribute : Attribute
        {
            return GetAttribute<TAttribute>(member).AttrRequired($"There is no {typeof(TAttribute)} attribute can be found.");
        }

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="member">Special member</param>
        /// <param name="refOptions"></param>
        /// <param name="ambOptions"></param>
        /// <typeparam name="TAttribute">Special typeInfo of attribute</typeparam>
        /// <returns>Attribute of special member</returns>
        public static TAttribute GetAttributeRequired<TAttribute>(MemberInfo member, ReflectionOptions refOptions, ReflectionAmbiguousOptions ambOptions = ReflectionAmbiguousOptions.Default) where TAttribute : Attribute
        {
            var val = ambOptions switch
            {
                ReflectionAmbiguousOptions.Default => GetAttribute<TAttribute>(member, refOptions),
                ReflectionAmbiguousOptions.IgnoreAmbiguous => GetAttributes<TAttribute>(member, refOptions).AttrDisambiguation(),
                _ => GetAttribute<TAttribute>(member, refOptions)
            };

            return val.AttrRequired($"There is no {typeof(TAttribute)} attribute can be found.");
        }

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="member">Special member</param>
        /// <param name="attributeType"></param>
        /// <returns>Attribute of special field</returns>
        public static Attribute GetAttributeRequired(MemberInfo member, Type attributeType)
        {
            return GetAttribute(member, attributeType).AttrRequired($"There is no {attributeType} attribute can be found.");
        }

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="member">Special member</param>
        /// <param name="attributeType"></param>
        /// <param name="refOptions"></param>
        /// <param name="ambOptions"></param>
        /// <returns>Attribute of special field</returns>
        public static Attribute GetAttributeRequired(MemberInfo member, Type attributeType, ReflectionOptions refOptions, ReflectionAmbiguousOptions ambOptions = ReflectionAmbiguousOptions.Default)
        {
            var val = ambOptions switch
            {
                ReflectionAmbiguousOptions.Default => GetAttribute(member, attributeType, refOptions),
                ReflectionAmbiguousOptions.IgnoreAmbiguous => GetAttributes(member, attributeType, refOptions).AttrDisambiguation(),
                _ => GetAttribute(member, attributeType, refOptions)
            };

            return val.AttrRequired($"There is no {attributeType} attribute can be found.");
        }

        #endregion

        #region GetRequiredAttributes

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="member">Special member</param>
        /// <typeparam name="TAttribute">Special typeInfo of attribute</typeparam>
        /// <returns>Attribute of special member</returns>
        public static IEnumerable<TAttribute> GetAttributesRequired<TAttribute>(MemberInfo member) where TAttribute : Attribute
        {
            return GetAttributes<TAttribute>(member).AttrRequired($"There is no any {typeof(TAttribute)} attributes can be found.");
        }

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="member">Special member</param>
        /// <param name="refOptions"></param>
        /// <typeparam name="TAttribute">Special typeInfo of attribute</typeparam>
        /// <returns>Attribute of special member</returns>
        public static IEnumerable<TAttribute> GetAttributesRequired<TAttribute>(MemberInfo member, ReflectionOptions refOptions) where TAttribute : Attribute
        {
            return GetAttributes<TAttribute>(member, refOptions).AttrRequired($"There is no any {typeof(TAttribute)} attributes can be found.");
        }

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="member">Special member</param>
        /// <param name="attributeType"></param>
        /// <returns>Attribute of special field</returns>
        public static IEnumerable<Attribute> GetAttributesRequired(MemberInfo member, Type attributeType)
        {
            return GetAttributes(member, attributeType).AttrRequired($"There is no any {attributeType} attributes can be found.");
        }

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="member">Special member</param>
        /// <param name="attributeType"></param>
        /// <param name="refOptions"></param>
        /// <returns>Attribute of special field</returns>
        public static IEnumerable<Attribute> GetAttributesRequired(MemberInfo member, Type attributeType, ReflectionOptions refOptions)
        {
            return GetAttributes(member, attributeType, refOptions).AttrRequired($"There is no any {attributeType} attributes can be found.");
        }

        #endregion

        #region GetAllAttributes

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="member">Special member</param>
        /// <returns>Attribute of special field</returns>
        public static IEnumerable<Attribute> GetAttributes(MemberInfo member)
        {
            return GetAttributesImpl(TypeReflectorHelper.GetReflector(member));
        }

        /// <summary>
        /// Get attribute
        /// </summary>
        /// <param name="member">Special member</param>
        /// <param name="refOptions"></param>
        /// <returns>Attribute of special field</returns>
        public static IEnumerable<Attribute> GetAttributes(MemberInfo member, ReflectionOptions refOptions)
        {
            return refOptions switch
            {
                ReflectionOptions.Default => GetAttributesImpl(TypeReflectorHelper.GetReflector(member)),
                ReflectionOptions.Inherit => member.GetCustomAttributes(true).Cast<Attribute>(),
                _ => member.GetCustomAttributes()
            };
        }

        private static IEnumerable<Attribute> GetAttributesImpl(ICustomAttributeReflectorProvider customAttributeReflectorProvider)
        {
            var attributeReflectors = customAttributeReflectorProvider != null
                ? customAttributeReflectorProvider.CustomAttributeReflectors
                : throw new ArgumentNullException(nameof(customAttributeReflectorProvider));
            var length = attributeReflectors.Length;
            if (length == 0)
                return Enumerable.Empty<Attribute>();
            var attributeArray = new Attribute[length];
            for (var i = 0; i < length; i++)
                attributeArray[i] = attributeReflectors[i].Invoke();
            return attributeArray;
        }

        #endregion
    }
}