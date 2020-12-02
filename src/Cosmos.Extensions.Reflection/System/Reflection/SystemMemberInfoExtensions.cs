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
    }
}