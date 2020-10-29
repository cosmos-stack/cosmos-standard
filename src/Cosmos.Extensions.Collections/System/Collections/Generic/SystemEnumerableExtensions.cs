using System.Collections.ObjectModel;
using System.Linq;
using Cosmos.Collections;

namespace System.Collections.Generic
{
    public static class SystemEnumerableExtensions
    {
        #region ReadOnly

        /// <summary>
        /// To readonly collection
        /// </summary>
        /// <param name="src"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static ReadOnlyCollection<T> ToReadOnlyCollection<T>(this IEnumerable<T> src)
        {
            if (src is null)
                throw new ArgumentNullException(nameof(src));
            return src.ToList().WrapInReadOnlyCollection();
        }

        #endregion
    }
}