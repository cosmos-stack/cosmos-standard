using System;
using System.Collections.Generic;

namespace Cosmos.Joiners
{
    /// <summary>
    /// Common join utils
    /// </summary>
    public static class CommonJoinUtils
    {
        /// <summary>
        /// Join to string
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TContainer"></typeparam>
        /// <param name="container"></param>
        /// <param name="containerUpdateFunc"></param>
        /// <param name="list"></param>
        /// <param name="delimiter"></param>
        /// <param name="predicate"></param>
        /// <param name="to"></param>
        /// <param name="replaceFunc"></param>
        public static void JoinToString<T, TContainer>(
            TContainer container, Action<TContainer, string> containerUpdateFunc,
            IEnumerable<T> list, string delimiter,
            Func<T, bool> predicate, Func<T, string> to, Func<T, T> replaceFunc = null)
        {
            if (list is null)
                return;

            var head = true;

            foreach (var item in list)
            {
                var checker = item;
                if (!(predicate?.Invoke(checker) ?? true))
                {
                    if (replaceFunc == null)
                        continue;
                    checker = replaceFunc(item);
                }

                if (head)
                {
                    head = false;
                }
                else
                {
                    containerUpdateFunc.Invoke(container, delimiter);
                }

                containerUpdateFunc.Invoke(container, to(checker));
            }
        }
    }
}