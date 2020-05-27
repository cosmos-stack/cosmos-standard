using System;

// ReSharper disable once CheckNamespace
namespace Cosmos.Optionals
{
    /// <summary>
    /// Extensions for linq
    /// </summary>
    public static partial class OptionalsExtensions
    {
        /// <summary>
        /// Select
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Maybe<TResult> Select<TSource, TResult>(this Maybe<TSource> source, Func<TSource, TResult> selector)
        {
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));
            return source.Map(selector);
        }

        /// <summary>
        /// Select many
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Maybe<TResult> SelectMany<TSource, TResult>(this Maybe<TSource> source, Func<TSource, Maybe<TResult>> selector)
        {
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));
            return source.FlatMap(selector);
        }

        /// <summary>
        /// Select many
        /// </summary>
        /// <param name="source"></param>
        /// <param name="collectionSelector"></param>
        /// <param name="resultSelector"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TCollection"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Maybe<TResult> SelectMany<TSource, TCollection, TResult>(
            this Maybe<TSource> source,
            Func<TSource, Maybe<TCollection>> collectionSelector,
            Func<TSource, TCollection, TResult> resultSelector)
        {
            if (collectionSelector is null)
                throw new ArgumentNullException(nameof(collectionSelector));
            if (resultSelector is null)
                throw new ArgumentNullException(nameof(resultSelector));
            return source.FlatMap(src => collectionSelector(src).Map(elem => resultSelector(src, elem)));
        }

        /// <summary>
        /// Where
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Maybe<TSource> Where<TSource>(this Maybe<TSource> source, Func<TSource, bool> predicate)
        {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            return source.Filter(predicate);
        }

        /// <summary>
        /// Select
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Either<TResult, TException> Select<TSource, TException, TResult>(this Either<TSource, TException> source, Func<TSource, TResult> selector)
        {
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));
            return source.Map(selector);
        }

        /// <summary>
        /// Select many
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Either<TResult, TException> SelectMany<TSource, TException, TResult>(
            this Either<TSource, TException> source,
            Func<TSource, Either<TResult, TException>> selector)
        {
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));
            return source.FlatMap(selector);
        }

        /// <summary>
        /// Select many
        /// </summary>
        /// <param name="source"></param>
        /// <param name="collectionSelector"></param>
        /// <param name="resultSelector"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <typeparam name="TCollection"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Either<TResult, TException> SelectMany<TSource, TException, TCollection, TResult>(
            this Either<TSource, TException> source,
            Func<TSource, Either<TCollection, TException>> collectionSelector,
            Func<TSource, TCollection, TResult> resultSelector)
        {
            if (collectionSelector is null) throw new ArgumentNullException(nameof(collectionSelector));
            if (resultSelector is null) throw new ArgumentNullException(nameof(resultSelector));
            return source.FlatMap(src => collectionSelector(src).Map(elem => resultSelector(src, elem)));
        }
    }
}