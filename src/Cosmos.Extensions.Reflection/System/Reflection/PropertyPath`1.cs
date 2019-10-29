using System.Collections.Generic;
using System.Linq.Expressions;

namespace System.Reflection
{
    /// <summary>
    /// Property path
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PropertyPath<T> : PropertyPath
    {
        internal PropertyPath() : base(null) { }

        internal PropertyPath(PropertyPath root) : base(root) { }

        /// <summary>
        /// Then enumerable
        /// </summary>
        /// <param name="expression"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public PropertyPath<TResult> ThenEnumerable<TResult>(Expression<Func<T, IEnumerable<TResult>>> expression)
        {
            if (expression == null) 
                throw new ArgumentNullException(nameof(expression));

            var propertyInfo = (expression.Body as MemberExpression)?.Member as PropertyInfo;

            if (propertyInfo == null)
                throw new InvalidOperationException($"The {nameof(expression)} parameter must be an expression backed by a PropertyInfo.");

            Append(propertyInfo);

            return new PropertyPath<TResult>(Root);
        }

        /// <summary>
        /// Then
        /// </summary>
        /// <param name="expression"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        public PropertyPath<TResult> Then<TResult>(Expression<Func<T, TResult>> expression)
        {
            if (expression == null) 
                throw new ArgumentNullException(nameof(expression));

            var propertyInfo = (expression.Body as MemberExpression)?.Member as PropertyInfo;

            if (propertyInfo == null)
                throw new InvalidOperationException($"The {nameof(expression)} parameter must be an expression backed by a PropertyInfo.");

            Append(propertyInfo);

            return new PropertyPath<TResult>(Root);
        }
    }
}