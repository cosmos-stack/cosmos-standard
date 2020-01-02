using System;
using System.Collections.Generic;

namespace Cosmos.Optionals {
    /// <summary>
    /// Interface for Dynamic optional
    /// </summary>
    public interface IDynamicOptional {
        /// <summary>
        /// Key
        /// </summary>
        string Key { get; }

        /// <summary>
        /// Has value
        /// </summary>
        bool HasValue { get; }

        /// <summary>
        /// Value
        /// </summary>
        dynamic Value { get; }

        /// <summary>
        /// Contains
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool Contains(string key);

        /// <summary>
        /// Exists
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        bool Exists(Func<string, bool> predicate);

        /// <summary>
        /// Value or
        /// </summary>
        /// <param name="key"></param>
        /// <param name="alternative"></param>
        /// <returns></returns>
        dynamic ValueOr(string key, dynamic alternative);

        /// <summary>
        /// Value or
        /// </summary>
        /// <param name="key"></param>
        /// <param name="alternativeFactory"></param>
        /// <returns></returns>
        dynamic ValueOr(string key, Func<dynamic> alternativeFactory);

        /// <summary>
        /// Or
        /// </summary>
        /// <param name="key"></param>
        /// <param name="alternative"></param>
        /// <returns></returns>
        Maybe<dynamic> Or(string key, dynamic alternative);

        /// <summary>
        /// Or
        /// </summary>
        /// <param name="key"></param>
        /// <param name="alternativeFactory"></param>
        /// <returns></returns>
        Maybe<dynamic> Or(string key, Func<dynamic> alternativeFactory);

        /// <summary>
        /// Else
        /// </summary>
        /// <param name="key"></param>
        /// <param name="alternativeMaybe"></param>
        /// <returns></returns>
        Maybe<dynamic> Else(string key, Maybe<dynamic> alternativeMaybe);

        /// <summary>
        /// Else
        /// </summary>
        /// <param name="key"></param>
        /// <param name="alternativeMaybeFactory"></param>
        /// <returns></returns>
        Maybe<dynamic> Else(string key, Func<Maybe<dynamic>> alternativeMaybeFactory);

        /// <summary>
        /// Convert to dynamic object
        /// </summary>
        /// <returns></returns>
        dynamic ToDynamicObject();

        /// <summary>
        /// Gets keys
        /// </summary>
        IEnumerable<string> Keys { get; }

        /// <summary>
        /// Gets values
        /// </summary>
        IEnumerable<dynamic> Values { get; }

        /// <summary>
        /// Join
        /// </summary>
        /// <param name="value"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        DynamicMaybe Join(dynamic value, string key);

        /// <summary>
        /// Where
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        DynamicMaybe Where(Func<string, dynamic, bool> predicate);

        /// <summary>
        /// Where
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        DynamicMaybe Where(Func<dynamic, bool> predicate);

        /// <summary>
        /// Select
        /// </summary>
        /// <param name="selector"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        IEnumerable<T> Select<T>(Func<string, dynamic, T> selector);

        /// <summary>
        /// To Dictionary
        /// </summary>
        /// <returns></returns>
        IDictionary<string, dynamic> ToDictionary();

        /// <summary>
        /// To Dictionary
        /// </summary>
        /// <returns></returns>
        // ReSharper disable once InconsistentNaming
        IDictionary<T, V> ToDictionary<T, V>(Func<KeyValuePair<string, dynamic>, T> keySelector, Func<KeyValuePair<string, dynamic>, V> valueSelector);
    }
}