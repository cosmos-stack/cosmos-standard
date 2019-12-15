using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections {
    /// <summary>
    /// Extensions of list
    /// </summary>
    public static partial class ListExtensions {
        /// <summary>
        /// Shuffle in place
        /// </summary>
        /// <param name="items"></param>
        /// <typeparam name="T"></typeparam>
        public static void ShuffleInPlace<T>(this IList<T> items) {
            ShuffleInPlace(items, 4);
        }

        /// <summary>
        /// Shuffle in place
        /// </summary>
        /// <param name="items"></param>
        /// <param name="times"></param>
        /// <typeparam name="T"></typeparam>
        public static void ShuffleInPlace<T>(this IList<T> items, int times) {
            for (int j = 0; j < times; j++) {
                var rnd = new Random((int) (DateTime.Now.Ticks % int.MaxValue) - j);

                for (int i = 0; i < items.Count; i++) {
                    var index = rnd.Next(items.Count - 1);
                    var temp = items[index];
                    items[index] = items[i];
                    items[i] = temp;
                }
            }
        }

        /// <summary>
        /// Shuffle to new list
        /// </summary>
        /// <param name="items"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> ShuffleToNewList<T>(this IList<T> items) {
            return ShuffleToNewList(items, 4);
        }

        /// <summary>
        /// Shuffle to new list
        /// </summary>
        /// <param name="items"></param>
        /// <param name="times"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> ShuffleToNewList<T>(this IList<T> items, int times) {
            var res = new List<T>(items);
            res.ShuffleInPlace(times);
            return res;
        }
    }
}