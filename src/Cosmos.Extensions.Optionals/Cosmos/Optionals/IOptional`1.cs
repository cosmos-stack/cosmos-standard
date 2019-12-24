using System;

namespace Cosmos.Optionals {
    /// <summary>
    /// Interface for optional
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IOptional<T> {
        /// <summary>
        /// Has value
        /// </summary>
        bool HasValue { get; }

        /// <summary>
        /// Value
        /// </summary>
        T Value { get; }

        /// <summary>
        /// Contains
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        bool Contains(T value);

        /// <summary>
        /// Exists
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        bool Exists(Func<T, bool> predicate);

        /// <summary>
        /// Value or
        /// </summary>
        /// <param name="alternative"></param>
        /// <returns></returns>
        T ValueOr(T alternative);

        /// <summary>
        /// Value or
        /// </summary>
        /// <param name="alternativeFactory"></param>
        /// <returns></returns>
        T ValueOr(Func<T> alternativeFactory);
    }
}