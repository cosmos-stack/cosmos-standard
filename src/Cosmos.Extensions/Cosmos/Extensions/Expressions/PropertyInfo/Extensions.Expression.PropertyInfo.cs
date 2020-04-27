using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

// ReSharper disable once CheckNamespace
namespace Cosmos.Expressions {
    /// <summary>
    /// Expression extensions
    /// </summary>
    public static partial class ExpressionExtensions {
        /// <summary>
        /// Get PropertyInfo
        /// </summary>
        /// <param name="expression"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static PropertyInfo GetPropertyInfo<T, TProperty>(this Expression<Func<T, TProperty>> expression) {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            var member = expression.Body as MemberExpression;

            ArgumentException CreateExpressionNotPropertyException() =>
                new ArgumentException($"The expression parameter ({nameof(expression)}) is not a property expression.");

            if (member is null && expression.Body.NodeType == ExpressionType.Convert) {
                var operand = (expression.Body as UnaryExpression)?.Operand;
                if (operand != null)
                    member = operand as MemberExpression;
            }

            if (member is null)
                throw CreateExpressionNotPropertyException();

            if (!(member.Member is PropertyInfo propertyInfo))
                throw CreateExpressionNotPropertyException();

            return propertyInfo;
        }

        /// <summary>
        /// Get PropertyInfo
        /// </summary>
        /// <param name="source"></param>
        /// <param name="expression"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <returns></returns>
        public static PropertyInfo GetPropertyInfo<T, TProperty>(this T source, Expression<Func<T, TProperty>> expression)
            => expression.GetPropertyInfo();

        /// <summary>
        /// Get PropertyInfos
        /// </summary>
        /// <param name="source"></param>
        /// <param name="expressions"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<PropertyInfo> GetPropertyInfos<T>(this T source, params Expression<Func<T, object>>[] expressions)
            => source.GetPropertyInfos((IEnumerable<Expression<Func<T, object>>>) expressions);

        /// <summary>
        /// Get PropertyInfos
        /// </summary>
        /// <param name="source"></param>
        /// <param name="expressions"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<PropertyInfo> GetPropertyInfos<T>(this T source, IEnumerable<Expression<Func<T, object>>> expressions) {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (expressions is null)
                throw new ArgumentNullException(nameof(expressions));

            return expressions.GetPropertyInfos();
        }

        /// <summary>
        /// Get PropertyInfos
        /// </summary>
        /// <param name="expressions"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static IEnumerable<PropertyInfo> GetPropertyInfos<TSource>(this IEnumerable<Expression<Func<TSource, object>>> expressions) =>
            expressions.Select(e => e.GetPropertyInfo());
    }
}