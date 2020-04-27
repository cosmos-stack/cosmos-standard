using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Cosmos.Expressions;

// ReSharper disable once CheckNamespace
namespace Cosmos {
    public static partial class ReflectionExtensions {
        /// <summary>
        /// Exclude
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="shape"></param>
        /// <param name="expressions"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<PropertyInfo> Exclude<T>(this IEnumerable<PropertyInfo> properties, T shape, params Expression<Func<T, object>>[] expressions)
            => properties.Exclude(shape, (IEnumerable<Expression<Func<T, object>>>) expressions);

        /// <summary>
        /// Exclude
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="shape"></param>
        /// <param name="expressions"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<PropertyInfo> Exclude<T>(this IEnumerable<PropertyInfo> properties, T shape, IEnumerable<Expression<Func<T, object>>> expressions)
            => properties.Exclude(expressions);

        /// <summary>
        /// Exclude
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="expressions"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<PropertyInfo> Exclude<T>(this IEnumerable<PropertyInfo> properties, params Expression<Func<T, object>>[] expressions)
            => properties.Exclude((IEnumerable<Expression<Func<T, object>>>) expressions);

        /// <summary>
        /// Exclude
        /// </summary>
        /// <param name="properties"></param>
        /// <param name="expressions"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<PropertyInfo> Exclude<T>(this IEnumerable<PropertyInfo> properties, IEnumerable<Expression<Func<T, object>>> expressions) {
            if (properties is null)
                throw new ArgumentNullException(nameof(properties));
            if (expressions is null)
                throw new ArgumentNullException(nameof(expressions));

            ISet<PropertyInfo> excluded = new HashSet<PropertyInfo>(expressions.GetPropertyInfos());

            return properties.Where(p => !excluded.Contains(p));
        }
    }
}