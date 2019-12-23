using System;
using System.Threading.Tasks;

namespace Cosmos.Optionals {
    /// <summary>
    /// Extensions for linq
    /// </summary>
    public static class AsyncLinqExtensions {
        /// <summary>
        /// Select
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Task<Maybe<TResult>> Select<TSource, TResult>(this Task<Maybe<TSource>> source, Func<TSource, TResult> selector) {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));
            return source.MapAsync(selector);
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
        public static Task<Maybe<TResult>> SelectMany<TSource, TResult>(this Task<Maybe<TSource>> source, Func<TSource, Task<Maybe<TResult>>> selector) {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));
            return source.FlatMapAsync(selector);
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
        public static Task<Maybe<TResult>> SelectMany<TSource, TCollection, TResult>(
            this Task<Maybe<TSource>> source,
            Func<TSource, Task<Maybe<TCollection>>> collectionSelector,
            Func<TSource, TCollection, TResult> resultSelector) {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (collectionSelector == null) throw new ArgumentNullException(nameof(collectionSelector));
            if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
            return source.FlatMapAsync(src => collectionSelector(src).MapAsync(elem => resultSelector(src, elem)));
        }

        /// <summary>
        /// Where
        /// </summary>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Task<Maybe<TSource>> Where<TSource>(this Task<Maybe<TSource>> source, Func<TSource, bool> predicate) {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (predicate == null) throw new ArgumentNullException(nameof(predicate));
            return source.FilterAsync(predicate);
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
        public static Task<Either<TResult, TException>> Select<TSource, TException, TResult>(this Task<Either<TSource, TException>> source, Func<TSource, TResult> selector) {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));
            return source.MapAsync(selector);
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
        public static Task<Either<TResult, TException>> SelectMany<TSource, TException, TResult>(
            this Task<Either<TSource, TException>> source,
            Func<TSource, Task<Either<TResult, TException>>> selector) {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (selector == null) throw new ArgumentNullException(nameof(selector));
            return source.FlatMapAsync(selector);
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
        public static Task<Either<TResult, TException>> SelectMany<TSource, TException, TCollection, TResult>(
            this Task<Either<TSource, TException>> source,
            Func<TSource, Task<Either<TCollection, TException>>> collectionSelector,
            Func<TSource, TCollection, TResult> resultSelector) {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (collectionSelector == null) throw new ArgumentNullException(nameof(collectionSelector));
            if (resultSelector == null) throw new ArgumentNullException(nameof(resultSelector));
            return source.FlatMapAsync(src => collectionSelector(src).MapAsync(elem => resultSelector(src, elem)));
        }
    }
}