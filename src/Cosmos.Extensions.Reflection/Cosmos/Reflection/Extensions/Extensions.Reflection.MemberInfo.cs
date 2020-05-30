using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

// ReSharper disable once CheckNamespace
namespace Cosmos.Reflection
{
    public static partial class ReflectionExtensions
    {
        /// <summary>
        /// To judge the attribute exists or not
        /// </summary>
        /// <typeparam name="TAttribute">要检查的特性类型</typeparam>
        /// <param name="memberInfo">要检查的类型成员</param>
        /// <returns>是否存在</returns>
        public static bool IsDefined<TAttribute>(this MemberInfo memberInfo) where TAttribute : Attribute
            => memberInfo.GetCustomAttributes(typeof(TAttribute)).Any(m => m is TAttribute);

        /// <summary>
        /// To judge the attribute exists or not
        /// </summary>
        /// <typeparam name="TAttribute">要检查的特性类型</typeparam>
        /// <param name="memberInfo">要检查的类型成员</param>
        /// <param name="inherit">是否从继承中查找</param>
        /// <returns>是否存在</returns>
        public static bool IsDefined<TAttribute>(this MemberInfo memberInfo, bool inherit) where TAttribute : Attribute
            => memberInfo.GetCustomAttributes(typeof(TAttribute), inherit).Any(m => m is TAttribute);

        /// <summary>
        /// To judge the attribute dosn't exist or not
        /// </summary>
        /// <typeparam name="TAttribute">要检查的特性类型</typeparam>
        /// <param name="memberInfo">要检查的类型成员</param>
        /// <returns>是否不存在</returns>
        public static bool IsNotDefined<TAttribute>(this MemberInfo memberInfo) where TAttribute : Attribute
            => !memberInfo.IsDefined<TAttribute>();

        /// <summary>
        /// To judge the attribute dosn't exist or not
        /// </summary>
        /// <typeparam name="TAttribute">要检查的特性类型</typeparam>
        /// <param name="memberInfo">要检查的类型成员</param>
        /// <param name="inherit">是否从继承中查找</param>
        /// <returns>是否不存在</returns>
        public static bool IsNotDefined<TAttribute>(this MemberInfo memberInfo, bool inherit) where TAttribute : Attribute
            => !memberInfo.IsDefined<TAttribute>(inherit);

        /// <summary>
        /// Get attribute from memberinfo
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="info"></param>
        /// <returns></returns>
        public static TAttribute GetAttribute<TAttribute>(this MemberInfo info) where TAttribute : Attribute
            => info.GetCustomAttributes<TAttribute>().FirstOrDefault();

        /// <summary>
        /// Get attributes from memberinfo
        /// </summary>
        /// <typeparam name="TAttribute">特性类型</typeparam>
        /// <param name="info">类型类型成员</param>
        /// <param name="inherit">是否从继承中查找</param>
        /// <returns>存在返回第一个，不存在返回null</returns>
        public static TAttribute GetAttribute<TAttribute>(this MemberInfo info, bool inherit) where TAttribute : Attribute
            => info.GetCustomAttributes<TAttribute>(inherit).FirstOrDefault();

        /// <summary>
        /// Get attribute from memberinfo
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="info"></param>
        /// <param name="attribute"></param>
        /// <returns></returns>
        public static bool TryGetAttribute<TAttribute>(this MemberInfo info, out TAttribute attribute) where TAttribute : Attribute
        {
            var ret = info.IsDefined<TAttribute>();
            attribute = ret
                ? info.GetAttribute<TAttribute>()
                : default;
            return ret;
        }

        /// <summary>
        /// Get attributes from memberinfo
        /// </summary>
        /// <typeparam name="TAttribute">特性类型</typeparam>
        /// <param name="info">类型类型成员</param>
        /// <param name="inherit">是否从继承中查找</param>
        /// <param name="attribute"></param>
        /// <returns>存在返回第一个，不存在返回null</returns>
        public static bool TryGetAttribute<TAttribute>(this MemberInfo info, bool inherit, out TAttribute attribute) where TAttribute : Attribute
        {
            var ret = info.IsDefined<TAttribute>();
            attribute = ret
                ? info.GetAttribute<TAttribute>(inherit)
                : default;
            return ret;
        }

        /// <summary>
        /// Get Attributes from memberinfo
        /// </summary>
        /// <typeparam name="TAttribute"></typeparam>
        /// <param name="info"></param>
        /// <returns></returns>
        public static IEnumerable<TAttribute> GetAttributes<TAttribute>(this MemberInfo info) where TAttribute : Attribute
            => info.GetCustomAttributes(typeof(TAttribute)).OfType<TAttribute>();

        /// <summary>
        /// Get attributes from memberinfo
        /// </summary>
        /// <typeparam name="TAttribute">特性类型</typeparam>
        /// <param name="info">类型类型成员</param>
        /// <param name="inherit">是否从继承中查找</param>
        /// <returns>存在返回第一个，不存在返回 null</returns>
        public static IEnumerable<TAttribute> GetAttributes<TAttribute>(this MemberInfo info, bool inherit) where TAttribute : Attribute
            => info.GetCustomAttributes(typeof(TAttribute), inherit).OfType<TAttribute>();
    }
}