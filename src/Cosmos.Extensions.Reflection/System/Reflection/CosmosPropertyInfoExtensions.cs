using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Cosmos.Expressions;
using Cosmos.Reflection;

namespace System.Reflection
{
    /// <summary>
    /// Cosmos <see cref="PropertyInfo"/> extensions.
    /// </summary>
    public static class CosmosPropertyInfoExtensions
    {
        #region Exclude

        /// <summary>
        /// Exclude all PropertyInfos that meet the given conditions from the PropertyInfo list,
        /// and return the remaining PropertyInfo.<br />
        /// 从 PropertyInfo 列表中排除所有满足给定条件的 PropertyInfo，并返回其余 PropertyInfo。
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="shape"></param>
        /// <param name="expressions"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<PropertyInfo> Exclude<T>(this IEnumerable<PropertyInfo> properties, T shape, params Expression<Func<T, object>>[] expressions)
            => properties.Exclude(shape, (IEnumerable<Expression<Func<T, object>>>) expressions);

        /// <summary>
        /// Exclude all PropertyInfos that meet the given conditions from the PropertyInfo list,
        /// and return the remaining PropertyInfo.<br />
        /// 从 PropertyInfo 列表中排除所有满足给定条件的 PropertyInfo，并返回其余 PropertyInfo。
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="shape"></param>
        /// <param name="expressions"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<PropertyInfo> Exclude<T>(this IEnumerable<PropertyInfo> properties, T shape, IEnumerable<Expression<Func<T, object>>> expressions)
            => properties.Exclude(expressions);

        /// <summary>
        /// Exclude all PropertyInfos that meet the given conditions from the PropertyInfo list,
        /// and return the remaining PropertyInfo.<br />
        /// 从 PropertyInfo 列表中排除所有满足给定条件的 PropertyInfo，并返回其余 PropertyInfo。
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="expressions"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<PropertyInfo> Exclude<T>(this IEnumerable<PropertyInfo> properties, params Expression<Func<T, object>>[] expressions)
            => properties.Exclude((IEnumerable<Expression<Func<T, object>>>) expressions);

        /// <summary>
        /// Exclude all PropertyInfos that meet the given conditions from the PropertyInfo list,
        /// and return the remaining PropertyInfo.<br />
        /// 从 PropertyInfo 列表中排除所有满足给定条件的 PropertyInfo，并返回其余 PropertyInfo。
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="expressions"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<PropertyInfo> Exclude<T>(this IEnumerable<PropertyInfo> properties, IEnumerable<Expression<Func<T, object>>> expressions)
        {
            if (properties is null)
                throw new ArgumentNullException(nameof(properties));
            if (expressions is null)
                throw new ArgumentNullException(nameof(expressions));

            ISet<PropertyInfo> excluded = new HashSet<PropertyInfo>(expressions.GetPropertyInfos());

            return properties.Where(p => !excluded.Contains(p));
        }

        #endregion

        #region Gets Attribute

        /// <summary>
        /// Get the Attribute of the specified type from the given PropertyInfo. <br />
        /// 从给定的 PropertyInfo 中获取指定类型的 Attribute。
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetAttribute<T>(PropertyInfo propertyInfo) where T : Attribute
        {
            var attributes = propertyInfo.GetCustomAttributes(typeof(T), false);

            return CosmosObjectExtensions.GetAttribute<T>(attributes);
        }

        #endregion

        #region Is

        /// <summary>
        /// Determine whether the specified property is an virtual property.<br />
        /// 判断指定属性是否是虚属性。
        /// </summary>
        public static bool IsVirtual(this PropertyInfo property)
        {
            var accessor = property.GetAccessors().FirstOrDefault();
            if (accessor == null)
            {
                return false;
            }

            return accessor.IsVirtual && !accessor.IsFinal;
        }

        #endregion
    }
}