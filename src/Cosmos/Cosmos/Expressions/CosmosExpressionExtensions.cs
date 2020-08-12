using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace Cosmos.Expressions
{
    /// <summary>
    /// public <see cref="Expression"/> extensions.
    /// </summary>
    public static class CosmosExpressionExtensions
    {
        
        #region To get property info from expression

        /// <summary>
        /// Get PropertyInfo
        /// </summary>
        /// <param name="expression"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static PropertyInfo GetPropertyInfo<T, TProperty>(this Expression<Func<T, TProperty>> expression)
        {
            if (expression is null)
                throw new ArgumentNullException(nameof(expression));

            var member = expression.Body as MemberExpression;

            ArgumentException CreateExpressionNotPropertyException() =>
                new ArgumentException($"The expression parameter ({nameof(expression)}) is not a property expression.");

            if (member is null && expression.Body.NodeType == ExpressionType.Convert)
            {
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
        public static IEnumerable<PropertyInfo> GetPropertyInfos<T>(this T source, IEnumerable<Expression<Func<T, object>>> expressions)
        {
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

        #endregion
        
        #region Create an expression to get property info

        private static ParameterExpression CreateParameterExpression(this Type type)
        {
            if (type is null)
                throw new ArgumentNullException(nameof(type));
            return Expression.Parameter(type, "o");
        }

        /// <summary>
        /// Create get property expression
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <returns></returns>
        public static MemberExpression CreateGetPropertyExpression(this PropertyInfo propertyInfo)
            => propertyInfo.CreateGetPropertyExpression(propertyInfo.DeclaringType.CreateParameterExpression());

        /// <summary>
        /// Create get property expression
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <param name="parameterExpression"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public static MemberExpression CreateGetPropertyExpression(this PropertyInfo propertyInfo, ParameterExpression parameterExpression)
        {
            if (propertyInfo is null)
                throw new ArgumentNullException(nameof(propertyInfo));
            if (parameterExpression is null)
                throw new ArgumentNullException(nameof(parameterExpression));

            if (!propertyInfo.DeclaringType.GetTypeInfo().IsAssignableFrom(parameterExpression.Type.GetTypeInfo()))
                throw new InvalidOperationException(
                    $"The type of {nameof(parameterExpression)} ({parameterExpression.Type} " +
                    $"is not assignable to the type of {nameof(propertyInfo.DeclaringType)} " +
                    $"({propertyInfo.DeclaringType}) passed in the {nameof(propertyInfo)} parameter.");

            return Expression.Property(parameterExpression, propertyInfo);
        }

        /// <summary>
        /// Create get property lambda expression
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <returns></returns>
        public static Expression<Func<T, TProperty>> CreateGetPropertyLambdaExpression<T, TProperty>(this PropertyInfo propertyInfo)
            => propertyInfo.CreateGetPropertyLambdaExpression<T, TProperty>(typeof(T).CreateParameterExpression());

        /// <summary>
        /// Create get property lambda expression
        /// </summary>
        /// <param name="propertyInfo"></param>
        /// <param name="parameterExpression"></param>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TProperty"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Expression<Func<T, TProperty>> CreateGetPropertyLambdaExpression<T, TProperty>(this PropertyInfo propertyInfo, ParameterExpression parameterExpression)
        {
            if (propertyInfo is null)
                throw new ArgumentNullException(nameof(propertyInfo));
            if (parameterExpression is null)
                throw new ArgumentNullException(nameof(parameterExpression));

            var propertyExpression = propertyInfo.CreateGetPropertyExpression(parameterExpression);

            Expression expression = propertyExpression;
            var type = typeof(TProperty);

            if (propertyInfo.PropertyType != type)
                expression = Expression.Convert(expression, type);

            return Expression.Lambda<Func<T, TProperty>>(expression, propertyExpression.Expression as ParameterExpression);
        }

        #endregion
        
    }
}