using System.Collections.Generic;
using System.Linq;
using Cosmos;
using Cosmos.Reflection;

namespace System.Reflection
{
    /// <summary>
    /// Cosmos <see cref="MemberInfo"/> extensions
    /// </summary>
    public static class SystemMemberInfoExtensions
    {
        #region IsDefined

        /// <summary>
        /// To determine whether the given Attribute is defined.<br />
        /// 判断给定的特性是否定义。
        /// </summary>
        /// <typeparam name="TAttribute">要检查的特性类型</typeparam>
        /// <param name="member">要检查的类型成员</param>
        /// <param name="options">反射选项</param>
        /// <returns>是否存在</returns>
        public static bool IsAttributeDefined<TAttribute>(this MemberInfo member, ReflectionOptions options = ReflectionOptions.Default) where TAttribute : Attribute
            => TypeReflections.IsAttributeDefined<TAttribute>(member, options);
        
        /// <summary>
        /// To determine whether the given Attribute is undefined.<br />
        /// 判断给定的特性是否未定义。
        /// </summary>
        /// <typeparam name="TAttribute">要检查的特性类型</typeparam>
        /// <param name="member">要检查的类型成员</param>
        /// <param name="options">反射选项</param>
        /// <returns>是否不存在</returns>
        public static bool IsAttributeNotDefined<TAttribute>(this MemberInfo member, ReflectionOptions options = ReflectionOptions.Default) where TAttribute : Attribute
            => !TypeReflections.IsAttributeDefined<TAttribute>(member, options);

        /// <summary>
        /// To determine whether the given Attribute is defined.<br />
        /// 判断给定的特性是否定义。
        /// </summary>
        /// <param name="member"></param>
        /// <param name="attributeType"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static bool IsAttributeDefined(this MemberInfo member,Type attributeType, ReflectionOptions options = ReflectionOptions.Default)
            => TypeReflections.IsAttributeDefined(member,attributeType, options);
        
        /// <summary>
        /// To determine whether the given Attribute is undefined.<br />
        /// 判断给定的特性是否未定义。
        /// </summary>
        /// <param name="member"></param>
        /// <param name="attributeType"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static bool IsAttributeNotDefined(this MemberInfo member,Type attributeType, ReflectionOptions options = ReflectionOptions.Default)
            => !TypeReflections.IsAttributeDefined(member,attributeType, options);
        
        #endregion

        #region GetAttribute

        /// <summary>
        /// Get an instance of the specified Attribute type from <see cref="MemberInfo"/>.<br />
        /// 从 <see cref="MemberInfo"/> 中获取指定 Attribute 类型的实例。
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="info"></param>
        /// <returns></returns>
        public static TAttribute GetAttributeOrNull<TAttribute>(this MemberInfo info) where TAttribute : Attribute
            => info.GetCustomAttributes<TAttribute>().FirstOrDefault();

        /// <summary>
        /// Get an instance of the specified Attribute type from <see cref="MemberInfo"/>.<br />
        /// 从 <see cref="MemberInfo"/> 中获取指定 Attribute 类型的实例。
        /// </summary>
        /// <typeparam name="TAttribute">特性类型</typeparam>
        /// <param name="info">类型类型成员</param>
        /// <param name="inherit">是否从继承中查找</param>
        /// <returns>存在返回第一个，不存在返回null</returns>
        public static TAttribute GetAttributeOrNull<TAttribute>(this MemberInfo info, bool inherit)
            where TAttribute : Attribute
            => info.GetCustomAttributes<TAttribute>(inherit).FirstOrDefault();

        /// <summary>
        /// Try to get an instance of the specified Attribute type from <see cref="MemberInfo"/>.<br />
        /// 尝试从 <see cref="MemberInfo"/> 中获取指定 Attribute 类型的实例。
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="info"></param>
        /// <param name="attribute"></param>
        /// <returns></returns>
        public static bool TryGetAttribute<TAttribute>(this MemberInfo info, out TAttribute attribute)
            where TAttribute : Attribute
        {
            var ret = info.IsAttributeDefined<TAttribute>();
            attribute = ret
                ? info.GetAttributeOrNull<TAttribute>()
                : default;
            return ret;
        }

        /// <summary>
        /// Try to get an instance of the specified Attribute type from <see cref="MemberInfo"/>.<br />
        /// 尝试从 <see cref="MemberInfo"/> 中获取指定 Attribute 类型的实例。
        /// </summary>
        /// <typeparam name="TAttribute">特性类型</typeparam>
        /// <param name="info">类型类型成员</param>
        /// <param name="inherit">是否从继承中查找</param>
        /// <param name="attribute"></param>
        /// <returns>存在返回第一个，不存在返回null</returns>
        public static bool TryGetAttribute<TAttribute>(this MemberInfo info, bool inherit, out TAttribute attribute)
            where TAttribute : Attribute
        {
            var ret = info.IsAttributeDefined<TAttribute>();
            attribute = ret
                ? info.GetAttributeOrNull<TAttribute>(inherit)
                : default;
            return ret;
        }

        /// <summary>
        /// Get all instances of the specified Attribute type from <see cref="MemberInfo"/>.<br />
        /// 从 <see cref="MemberInfo"/> 中获取指定 Attribute 类型的所有实例。
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="info"></param>
        /// <returns></returns>
        public static IEnumerable<TAttribute> GetAttributes<TAttribute>(this MemberInfo info)
            where TAttribute : Attribute
            => info.GetCustomAttributes(typeof(TAttribute)).OfType<TAttribute>();

        /// <summary>
        /// Get all instances of the specified Attribute type from <see cref="MemberInfo"/>.<br />
        /// 从 <see cref="MemberInfo"/> 中获取指定 Attribute 类型的所有实例。
        /// </summary>
        /// <typeparam name="TAttribute">特性类型</typeparam>
        /// <param name="info">类型类型成员</param>
        /// <param name="inherit">是否从继承中查找</param>
        /// <returns>存在返回第一个，不存在返回 null</returns>
        public static IEnumerable<TAttribute> GetAttributes<TAttribute>(this MemberInfo info, bool inherit)
            where TAttribute : Attribute
            => info.GetCustomAttributes(typeof(TAttribute), inherit).OfType<TAttribute>();

        /// <summary>
        /// Get an instance of the specified Attribute type from <see cref="Type"/> or its base type.<br />
        /// 从 <see cref="Type"/> 或其基类中获取指定 Attribute 类型的实例。
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="type"></param>
        /// <param name="inherit"></param>
        /// <returns></returns>
        public static TAttribute GetAttributeOfTypeOrBaseTypeOrNull<TAttribute>(this Type type, bool inherit = true) where TAttribute : Attribute
            => type.GetTypeInfo().GetAttributeOrNull<TAttribute>(inherit) ??
               type.GetTypeInfo().BaseType?.GetAttributeOfTypeOrBaseTypeOrNull<TAttribute>(inherit);

        #endregion

        #region GetMemberValue

        /// <summary>
        /// Get property value from the given instance.
        /// </summary>
        /// <param name="member"></param>
        /// <param name="instance"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static object GetMemberValue(this MemberInfo member, object instance)
        {
            if (member is null)
                throw new ArgumentNullException(nameof(member));
            if (instance is null)
                throw new ArgumentNullException(nameof(instance));
            return instance.GetType().GetProperty(member.Name)?.GetValue(instance);
        }

        public static TMemberValue GetMemberValue<TMemberValue>(this MemberInfo member, object instance)
        {
            if (member is null)
                throw new ArgumentNullException(nameof(member));
            if (instance is null)
                throw new ArgumentNullException(nameof(instance));
            var value = instance.GetType().GetProperty(member.Name)?.GetValue(instance);

            if (value is null)
                return default;
            return value.As<TMemberValue>();
        }

        #endregion
    }
}