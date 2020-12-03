using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Cosmos.Reflection;

namespace System.Reflection
{
    /// <summary>
    /// Cosmos <see cref="PropertyInfo"/> extensions.
    /// </summary>
    public static class SystemPropertyInfoExtensions
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

            ISet<PropertyInfo> excluded = new HashSet<PropertyInfo>(TypeVisit.GetProperties(expressions));

            return properties.Where(p => !excluded.Contains(p));
        }

        #endregion
    }
}