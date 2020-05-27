using System;

// ReSharper disable once CheckNamespace
namespace Cosmos.Exceptions
{
    /// <summary>
    /// Extensions for Try
    /// </summary>
    public static class TryExtensions
    {
        /// <summary>
        /// Select
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Try<TResult> Select<TSource, TResult>(this Try<TSource> source, Func<TSource, TResult> selector)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));
            return source.Bind(val => Try.LiftValue(selector(val)));
        }

        /// <summary>
        /// Select many
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Try<TResult> SelectMany<TSource, TResult>(this Try<TSource> source, Func<TSource, Try<TResult>> selector)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));
            return source.Bind(selector);
        }

        /// <summary>
        /// Select many
        /// </summary>
        /// <param name="source"></param>
        /// <param name="convert"></param>
        /// <param name="selector"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TIntermediate"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        public static Try<TResult> SelectMany<TSource, TIntermediate, TResult>(this Try<TSource> source,
            Func<TSource, Try<TIntermediate>> convert, Func<TSource, TIntermediate, TResult> selector)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (convert is null)
                throw new ArgumentNullException(nameof(convert));
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));
            return source.Bind(val => convert(val).Select(interVal => selector(val, interVal)));
        }

        /// <summary>
        /// Where
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static Try<TSource> Where<TSource>(this Try<TSource> source, Func<TSource, bool> predicate)
        {
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            return source.Bind(val => predicate(val) ? source : Try.LiftException<TSource>(new InvalidOperationException("Predicate not satisfied")));
        }
    }
}