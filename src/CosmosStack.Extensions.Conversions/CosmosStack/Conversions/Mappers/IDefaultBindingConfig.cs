using System;
using System.Linq.Expressions;

namespace CosmosStack.Conversions.Mappers
{
    /// <summary>
    /// Default mapping binding configuration
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TTarget"></typeparam>
    public interface IDefaultBindingConfig<TSource, TTarget>
    {
        /// <summary>
        /// Bind
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        void Bind(Expression<Func<TSource, object>> source, Expression<Func<TTarget, object>> target);

        /// <summary>
        /// Bind
        /// </summary>
        /// <param name="target"></param>
        /// <param name="targetType"></param>
        void Bind(Expression<Func<TTarget, object>> target, Type targetType);

        /// <summary>
        /// Bind
        /// </summary>
        /// <param name="expression"></param>
        void Ignore(Expression<Func<TSource, object>> expression);
    }
}