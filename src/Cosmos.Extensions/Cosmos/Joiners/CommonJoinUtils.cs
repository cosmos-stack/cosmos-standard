using System;
using System.Collections.Generic;

namespace Cosmos.Joiners
{
    public static class CommonJoinUtils
    {
        public static void JoinToString<T, TContainer>(
            TContainer container, Action<TContainer, string> containerUpdateFunc,
            IEnumerable<T> list, string delimiter,
            Func<T, bool> predicate, Func<T, string> to, Func<T, T> replaceFunc = null)
        {
            if (list == null)
                return;

            bool head = true;

            foreach (var item in list)
            {
                var checker = item;
                if (!(predicate?.Invoke(checker) ?? true))
                {
                    if (replaceFunc == null)
                        continue;
                    else
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