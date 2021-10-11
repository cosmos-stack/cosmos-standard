using System;
using System.Collections.Generic;
using System.Linq;
using CosmosStack.Optionals.DynamicOptionals;

namespace CosmosStack.Optionals
{
    /// <summary>
    /// Dynamic maybe <br />
    /// 动态 MayBe 组件
    /// </summary>
    public readonly struct DynamicMaybe : IDynamicOptional
    {
        private readonly DynamicOptionalObject _dynamicOptionalObject;

        internal DynamicMaybe(DynamicOptionalObject optionalObject)
        {
            _dynamicOptionalObject = optionalObject ?? throw new ArgumentNullException(nameof(optionalObject));
        }

        /// <inheritdoc />
        public string Key => _dynamicOptionalObject.Key;

        /// <inheritdoc />
        public bool HasValue => _dynamicOptionalObject.Keys.Any();

        /// <inheritdoc />
        public dynamic Value => _dynamicOptionalObject.GetDynamicObject();

        #region Index

        /// <summary>
        /// Index
        /// </summary>
        /// <param name="index"></param>
        public Maybe<dynamic> this[int index] => Optional.From(_dynamicOptionalObject[index]);

        /// <summary>
        /// Index <br />
        /// 索引
        /// </summary>
        /// <param name="key"></param>
        public Maybe<dynamic> this[string key] => Optional.From(_dynamicOptionalObject[key]);

        #endregion

        #region Enumerable

        /// <summary>
        /// To enumerable
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Maybe<dynamic>> ToEnumerable()
        {
            foreach (var item in _dynamicOptionalObject)
                yield return new NamedOptionalBuilder.NamedOptionalLevel1Builder<dynamic>(item.Value, item.Key).Build();
        }

        /// <summary>
        /// Get enumrtator
        /// </summary>
        /// <returns></returns>
        public IEnumerator<Maybe<dynamic>> GetEnumerator()
        {
            foreach (var item in _dynamicOptionalObject)
                yield return new NamedOptionalBuilder.NamedOptionalLevel1Builder<dynamic>(item.Value, item.Key).Build();
        }

        #endregion

        #region Contains / Exists

        /// <inheritdoc />
        public bool Contains(string key)
        {
            return _dynamicOptionalObject.Contains(key);
        }

        /// <inheritdoc />
        public bool Exists(Func<string, bool> predicate)
        {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            return _dynamicOptionalObject.Exists(predicate);
        }

        #endregion

        #region Value or

        /// <inheritdoc />
        public dynamic ValueOr(string key, dynamic alternative)
        {
            return Contains(key) ? _dynamicOptionalObject[key] : alternative;
        }

        /// <inheritdoc />
        public dynamic ValueOr(string key, Func<dynamic> alternativeFactory)
        {
            if (alternativeFactory is null)
                throw new ArgumentNullException(nameof(alternativeFactory));
            return Contains(key) ? _dynamicOptionalObject[key] : alternativeFactory();
        }

        #endregion

        #region Or / Else

        /// <inheritdoc />
        public Maybe<dynamic> Or(string key, dynamic alternative)
        {
            return Contains(key) ? this[key] : Optional.Some(alternative);
        }

        /// <inheritdoc />
        public Maybe<dynamic> Or(string key, Func<dynamic> alternativeFactory)
        {
            if (alternativeFactory is null)
                throw new ArgumentNullException(nameof(alternativeFactory));
            return Contains(key) ? this[key] : Optional.Some(alternativeFactory());
        }

        /// <inheritdoc />
        public Maybe<dynamic> Else(string key, Maybe<dynamic> alternativeMaybe)
        {
            return Contains(key) ? this[key] : alternativeMaybe;
        }

        /// <inheritdoc />
        public Maybe<dynamic> Else(string key, Func<Maybe<dynamic>> alternativeMaybeFactory)
        {
            if (alternativeMaybeFactory is null)
                throw new ArgumentNullException(nameof(alternativeMaybeFactory));
            return Contains(key) ? this[key] : alternativeMaybeFactory();
        }

        #endregion

        #region To Dynamic

        /// <inheritdoc />
        public dynamic ToDynamicObject() => _dynamicOptionalObject.GetDynamicObject();

        #endregion

        #region Keys / Values

        /// <inheritdoc />
        public IEnumerable<string> Keys => _dynamicOptionalObject.Keys;

        /// <inheritdoc />
        public IEnumerable<dynamic> Values => _dynamicOptionalObject.Values;

        #endregion

        #region Join

        /// <inheritdoc />
        public DynamicMaybe Join(dynamic value, string key)
        {
            return DynamicOptionalBuilder.Returns(_dynamicOptionalObject).SilenceMay(value, key).Build();
        }

        #endregion

        #region Linq

        /// <summary>
        /// Where
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public DynamicMaybe Where(Func<string, dynamic, bool> predicate)
        {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            var dictionary = Filter(_dynamicOptionalObject, predicate).ToDictionary(k => k.Key, v => v.Value);
            var queueLikeList = _dynamicOptionalObject.InternalQueueLikeList.Where(s => dictionary.Keys.Contains(s));
            return DynamicOptionalBuilder.Returns(dictionary, queueLikeList).Build();
        }

        /// <summary>
        /// Where
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public DynamicMaybe Where(Func<dynamic, bool> predicate)
        {
            if (predicate is null)
                throw new ArgumentNullException(nameof(predicate));
            var dictionary = Filter(_dynamicOptionalObject, predicate).ToDictionary(k => k.Key, v => v.Value);
            var queueLikeList = _dynamicOptionalObject.InternalQueueLikeList.Where(s => dictionary.Keys.Contains(s));
            return DynamicOptionalBuilder.Returns(dictionary, queueLikeList).Build();
        }

        private static IEnumerable<KeyValuePair<string, dynamic>> Filter(DynamicOptionalObject dynamicOptionalObject, Func<string, dynamic, bool> predicate)
        {
            foreach (var pair in dynamicOptionalObject)
            {
                if (predicate.Invoke(pair.Key, pair.Value))
                    yield return pair;
            }
        }

        private static IEnumerable<KeyValuePair<string, dynamic>> Filter(DynamicOptionalObject dynamicOptionalObject, Func<dynamic, bool> predicate)
        {
            foreach (var pair in dynamicOptionalObject)
            {
                if (predicate.Invoke(pair.Value))
                    yield return pair;
            }
        }

        /// <summary>
        /// Select
        /// </summary>
        /// <param name="selector"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IEnumerable<T> Select<T>(Func<string, dynamic, T> selector)
        {
            if (selector is null)
                throw new ArgumentNullException(nameof(selector));
            foreach (var pair in _dynamicOptionalObject)
                yield return selector(pair.Key, pair.Value);
        }

        /// <summary>
        /// To Dictionary
        /// </summary>
        /// <returns></returns>
        public IDictionary<string, dynamic> ToDictionary()
        {
            var result = new Dictionary<string, dynamic>();
            foreach (var pair in _dynamicOptionalObject)
                result.Add(pair.Key, pair.Value);
            return result;
        }

        /// <summary>
        /// To Dictionary
        /// </summary>
        /// <returns></returns>
        // ReSharper disable once InconsistentNaming
        public IDictionary<T, V> ToDictionary<T, V>(Func<KeyValuePair<string, dynamic>, T> keySelector, Func<KeyValuePair<string, dynamic>, V> valueSelector)
        {
            if (keySelector is null)
                throw new ArgumentNullException(nameof(keySelector));
            if (valueSelector is null)
                throw new ArgumentNullException(nameof(valueSelector));
            var result = new Dictionary<T, V>();
            foreach (var pair in _dynamicOptionalObject)
            {
                var key = keySelector(pair);
                var value = valueSelector(pair);
                result.Add(key, value);
            }

            return result;
        }

        #endregion
    }
}