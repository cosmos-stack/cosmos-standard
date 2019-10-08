using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Cosmos.Extensions
{
    /// <summary>
    /// Extensions of collection
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// 对集合内每一项元素都进行一次操作
        /// </summary>
        /// <param name="enumerable"></param>
        /// <param name="action"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IEnumerable<T> ForEachItem<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var item in enumerable)
            {
                action?.Invoke(item);
                yield return item;
            }
        }

        /// <summary>
        /// 将集合转换为只读集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        public static ReadOnlyCollection<T> AsReadOnly<T>(this IEnumerable<T> enumerable)
        {
            return new ReadOnlyCollection<T>(new List<T>(enumerable));
        }

        /// <summary>
        /// 将两个具有相同种类的元素的集合合并
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="left"> </param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static IEnumerable<T> Merge<T>(this IEnumerator<T> left, IEnumerator<T> right)
        {
            while (left.MoveNext()) yield return left.Current;
            while (right.MoveNext()) yield return right.Current;
        }

        /// <summary>
        /// 将一个元素添加到一个具有相同种类的元素的集合内
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="left"></param>
        /// <param name="last"></param>
        /// <returns></returns>
        public static IEnumerable<T> Merge<T>(this IEnumerator<T> left, T last)
        {
            while (left.MoveNext()) yield return left.Current;
            yield return last;
        }
        
        /// <summary>
        /// 将多层的集合展开并整理为单层集合
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inputs">   </param>
        /// <param name="enumerate"></param>
        /// <returns></returns>
        public static IEnumerable<T> Flatten<T>(this IEnumerable<T> inputs, Func<T, IEnumerable<T>> enumerate)
        {
            if (inputs != null)
            {
                var stack = new Stack<T>(inputs);
                while (stack.Count > 0)
                {
                    var current = stack.Pop();
                    if (current == null) continue;
                    yield return current;
                    var enumerable = enumerate?.Invoke(current);
                    if (enumerable != null)
                    {
                        foreach (var child in enumerable) stack.Push(child);
                    }
                }
            }
        }

        /// <summary>
        /// 将多层的集合展开并整理为单层集合
        /// </summary>
        /// <param name="inputs"></param>
        /// <param name="enumerate"></param>
        /// <returns></returns>
        public static IEnumerable Flatten(this IEnumerable inputs, Func<object, IEnumerable> enumerate)
        {
            return Flatten(inputs.Cast<object>(), o => (enumerate(o) ?? new object[0]).Cast<object>());
        }

        public static TItem FirstBasedOn<TItem>(this IList<TItem> list, Func<TItem, IComparable> order) where TItem : class
        {
            if (!list.Any()) return default;
            var first = default(TItem);
            IComparable valueFirst = null;

            foreach (var item in list)
            {
                var actual = order(item);
                if (valueFirst == null || actual.CompareTo(valueFirst) < 0)
                {
                    valueFirst = actual;
                    first = item;
                }
            }

            return first;
        }

        public static TItem LastBasedOn<TItem>(this List<TItem> list, Func<TItem, IComparable> order)
        {
            if (!list.Any()) return default;
            var last = default(TItem);
            IComparable valueLast = null;

            foreach (var item in list)
            {
                var actual = order(item);
                if (valueLast == null || actual.CompareTo(valueLast) >= 0)
                {
                    valueLast = actual;
                    last = item;
                }
            }

            return last;
        }

        public static int CountDistinct<TObj, TResult>(this IList<TObj> list, Func<TObj, TResult> valCalculator)
        {
            var check = new HashSet<TResult>();
            foreach (var item in list)
            {
                var result = valCalculator(item);
                if (!check.Contains(result))
                    check.Add(result);
            }

            return check.Count;
        }

        public static List<TSource> MoveToFirst<TSource>(this List<TSource> source, TSource element)
        {
            if (!source.Contains(element))
                return source;

            source.Remove(element);
            source.Insert(0, element);
            return source;
        }
    }
}