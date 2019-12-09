using System;
using System.Collections.Generic;

namespace Cosmos {
    /// <summary>
    /// Provide a unified singleton management portal.
    /// </summary>
    public class Singleton {
        static Singleton() {
            AllSingletons = new Dictionary<Type, object>();
        }

        /// <summary>
        /// All singleton objects
        /// </summary>
        public static IDictionary<Type, object> AllSingletons { get; }
    }

    /// <summary>
    /// Provide a unified singleton management portal and a copy of itself.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Singleton<T> : Singleton {
        private static T _instance;

        /// <summary>
        /// Singleton instance
        /// </summary>
        public static T Instance {
            get => _instance;
            set {
                _instance = value;
                AllSingletons[typeof(T)] = value;
            }
        }
    }

    /// <summary>
    /// Provide a unified singleton management portal and a copy of itself.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SingletonList<T> : Singleton<IList<T>> {
        static SingletonList() {
            Singleton<IList<T>>.Instance = new List<T>();
        }

        /// <summary>
        /// Get a singleton of the specified type T
        /// </summary>
        public new static IList<T> Instance => Singleton<IList<T>>.Instance;
    }

    /// <summary>
    /// Provide a unified singleton management portal and a copy of itself
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class SingletonDictionary<TKey, TValue> : Singleton<IDictionary<TKey, TValue>> {
        static SingletonDictionary() {
            Singleton<Dictionary<TKey, TValue>>.Instance = new Dictionary<TKey, TValue>();
        }

        /// <summary>
        /// Get a singleton of the specified type T
        /// </summary>
        public new static IDictionary<TKey, TValue> Instance => Singleton<Dictionary<TKey, TValue>>.Instance;
    }
}