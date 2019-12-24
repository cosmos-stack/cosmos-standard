using System;

namespace Cosmos.Optionals {
    /// <summary>
    /// Interface for optional
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TImpl"></typeparam>
    public interface IOptionalImpl<T, TImpl> : IOptional<T>, IEquatable<T>, IComparable<T> {
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
        /// Else
        /// </summary>
        /// <param name="alternativeMaybe"></param>
        /// <returns></returns>
        TImpl Else(TImpl alternativeMaybe);

        /// <summary>
        /// Else
        /// </summary>
        /// <param name="alternativeMaybeFactory"></param>
        /// <returns></returns>
        TImpl Else(Func<TImpl> alternativeMaybeFactory);

        /// <summary>
        /// With exception
        /// </summary>
        /// <param name="exception"></param>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        Either<T, TException> WithException<TException>(TException exception);

        /// <summary>
        /// With exception
        /// </summary>
        /// <param name="exceptionFactory"></param>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        Either<T, TException> WithException<TException>(Func<TException> exceptionFactory);

        /// <summary>
        /// Match
        /// </summary>
        /// <param name="someFactory"></param>
        /// <param name="noneFactory"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        TResult Match<TResult>(Func<T, TResult> someFactory, Func<TResult> noneFactory);

        /// <summary>
        /// Match
        /// </summary>
        /// <param name="someAct"></param>
        /// <param name="noneAct"></param>
        void Match(Action<T> someAct, Action noneAct);

        /// <summary>
        /// Match maybe
        /// </summary>
        /// <param name="maybeAct"></param>
        void MatchMaybe(Action<T> maybeAct);

        /// <summary>
        /// Match none
        /// </summary>
        /// <param name="noneAct"></param>
        void MatchNone(Action noneAct);

        /// <summary>
        /// Map
        /// </summary>
        /// <param name="mapping"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        Maybe<TResult> Map<TResult>(Func<T, TResult> mapping);

        /// <summary>
        /// Flat map
        /// </summary>
        /// <param name="mapping"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <returns></returns>
        Maybe<TResult> FlatMap<TResult>(Func<T, Maybe<TResult>> mapping);

        /// <summary>
        /// Flat map
        /// </summary>
        /// <param name="mapping"></param>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TException"></typeparam>
        /// <returns></returns>
        Maybe<TResult> FlatMap<TResult, TException>(Func<T, Either<TResult, TException>> mapping);

        /// <summary>
        /// Filter
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        TImpl Filter(bool condition);

        /// <summary>
        /// Filter
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        TImpl Filter(Func<T, bool> predicate);

        /// <summary>
        /// Not null
        /// </summary>
        /// <returns></returns>
        TImpl NotNull();
    }
}