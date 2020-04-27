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
        private static ParameterExpression CreateParameterExpression(this Type type) {
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
        public static MemberExpression CreateGetPropertyExpression(this PropertyInfo propertyInfo, ParameterExpression parameterExpression) {
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
        public static Expression<Func<T, TProperty>> CreateGetPropertyLambdaExpression<T, TProperty>(this PropertyInfo propertyInfo, ParameterExpression parameterExpression) {
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
    }
}