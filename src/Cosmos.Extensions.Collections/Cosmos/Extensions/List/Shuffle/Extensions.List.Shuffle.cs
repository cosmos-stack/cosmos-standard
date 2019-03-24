using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Cosmos
{
    public static partial class ListExtensions
    {
        public static void ShuffleInPlace<T>(this IList<T> items)
        {
            ShuffleInPlace(items, 4);
        }

        public static void ShuffleInPlace<T>(this IList<T> items, int times)
        {
            for (int j = 0; j < times; j++)
            {
                var rnd = new Random((int)(DateTime.Now.Ticks % int.MaxValue) - j);

                for (int i = 0; i < items.Count; i++)
                {
                    var index = rnd.Next(items.Count - 1);
                    var temp = items[index];
                    items[index] = items[i];
                    items[i] = temp;
                }
            }
        }

        public static List<T> ShuffleToNewList<T>(this IList<T> items)
        {
            return ShuffleToNewList(items, 4);
        }

        public static List<T> ShuffleToNewList<T>(this IList<T> items, int times)
        {
            var res = new List<T>(items);
            res.ShuffleInPlace(times);
            return res;
        }
    }
}
