using System;

namespace Cosmos.Optionals {
    /// <summary>
    /// Interface for optional
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TImpl"></typeparam>
    /// <typeparam name="TException"></typeparam>
    public interface IOptionalImpl<T, TException, TImpl> : IOptional<T, TException>,
                                                           IEquatable<T>,
                                                           IComparable<T> {
        /// <summary>
        /// Or
        /// </summary>
        /// <param name="alternative"></param>
        /// <returns></returns>
        TImpl Or(T alternative);

        /// <summary>
        /// Or
        /// </summary>
        /// <param name="alternativeFactory"></param>
        /// <returns></returns>
        TImpl Or(Func<T> alternativeFactory);

        /// <summary>
        /// Or
        /// </summary>
        /// <param name="alternativeFactory"></param>
        /// <returns></returns>
        TImpl Or(Func<TException, T> alternativeFactory);

        /// <summary>
        /// Else
        /// </summary>
        /// <param name="alternativeOption"></param>
        /// <returns></returns>
        TImpl Else(TImpl alternativeOption);

        /// <summary>
        /// Else
        /// </summary>
        /// <param name="alternativeOptionFactory"></param>
        /// <returns></returns>
        TImpl Else(Func<TImpl> alternativeOptionFactory);

        /// <summary>
        /// Else
        /// </summary>
        /// <param name="alternativeOptionFactory"></param>
        /// <returns></returns>
        TImpl Else(Func<TException, TImpl> alternativeOptionFactory);

        /// <summary>
        /// With exception
        /// </summary>
        /// <returns></returns>
        Maybe<T> WithoutException();

        /// <summary>
        /// Match
        /// </summary>
        /// <param name="someFactory"></param>
        /// <param name="noneFactory"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        TResult Match<TResult>(Func<T, TResult> someFactory, Func<TException, TResult> noneFactory);

        /// <summary>
        /// Match
        /// </summary>
        /// <param name="someAct"></param>
        /// <param name="noneAct"></param>
        void Match(Action<T> someAct, Action<TException> noneAct);

        /// <summary>
        /// Match some
        /// </summary>
        /// <param name="someAct"></param>
        void MatchSome(Action<T> someAct);

        /// <summary>
        /// Match none
        /// </summary>
        /// <param name="noneAct"></param>
        void MatchNone(Action<TException> noneAct);

        /// <summary>
        /// Map
        /// </summary>
        /// <param name="mapping"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        Either<TResult, TException> Map<TResult>(Func<T, TResult> mapping);

        /// <summary>
        /// Map exception
        /// </summary>
        /// <param name="mapping"></param>
        /// <typeparam name="TExceptionResult"></typeparam>
        /// <returns></returns>
        Either<T, TExceptionResult> MapException<TExceptionResult>(Func<TException, TExceptionResult> mapping);

        /// <summary>
        /// Flat map
        /// </summary>
        /// <param name="mapping"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        Either<TResult, TException> FlatMap<TResult>(Func<T, Either<TResult, TException>> mapping);

        /// <summary>
        /// Flat map
        /// </summary>
        /// <param name="mapping"></param>
        /// <param name="exception"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        Either<TResult, TException> FlatMap<TResult>(Func<T, Maybe<TResult>> mapping, TException exception);

        /// <summary>
        /// Flat map
        /// </summary>
        /// <param name="mapping"></param>
        /// <param name="exceptionFactory"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        Either<TResult, TException> FlatMap<TResult>(Func<T, Maybe<TResult>> mapping, Func<TException> exceptionFactory);

        /// <summary>
        /// Filter
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        TImpl Filter(bool condition, TException exception);

        /// <summary>
        /// Filter
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="exceptionFactory"></param>
        /// <returns></returns>
        TImpl Filter(bool condition, Func<TException> exceptionFactory);

        /// <summary>
        /// Filter
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        TImpl Filter(Func<T, bool> predicate, TException exception);

        /// <summary>
        /// Filter
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="exceptionFactory"></param>
        /// <returns></returns>
        TImpl Filter(Func<T, bool> predicate, Func<TException> exceptionFactory);

        /// <summary>
        /// Not null
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        TImpl NotNull(TException exception);

        /// <summary>
        /// Not null
        /// </summary>
        /// <param name="exceptionFactory"></param>
        /// <returns></returns>
        TImpl NotNull(Func<TException> exceptionFactory);
    }
}