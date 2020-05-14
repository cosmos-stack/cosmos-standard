using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections {
    /// <summary>
    /// Collection extensions
    /// </summary>
    public static partial class CollectionExtensions {
        /// <summary>
        /// Remove deplicates
        /// </summary>
        /// <param name="values"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <returns></returns>
        public static IEnumerable<TSource> RemoveDuplicates<TSource>(this IList<TSource> values) {
            var duplicateCheck = new HashSet<TSource>();

            return values.RemoveWhere(item => {
                if (duplicateCheck.Contains(item))
                    return true;

                duplicateCheck.Add(item);
                return false;
            });
        }

        /// <summary>
        /// Remove buplicates
        /// </summary>
        /// <param name="values"></param>
        /// <param name="duplicatePredicate"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TCheck"></typeparam>
        /// <returns></returns>
        public static IEnumerable<TSource> RemoveDuplicates<TSource, TCheck>(this IList<TSource> values, Func<TSource, TCheck> duplicatePredicate) {
            if (duplicatePredicate is null)
                throw new ArgumentNullException(nameof(duplicatePredicate));

            var duplicateCheck = new HashSet<TCheck>();

            return values.RemoveWhere(item => {
                var val = duplicatePredicate(item);

                if (duplicateCheck.Contains(val))
                    return true;

                duplicateCheck.Add(val);
                return false;
            });
        }

        /// <summary>
        /// Remove duplicates ignore case
        /// </summary>
        /// <param name="values"></param>
        /// <returns></returns>
        public static IEnumerable<string> RemoveDuplicatesIgnoreCase(this IList<string> values) {
            var duplicateCheck = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            return values.RemoveWhere(item => {
                if (duplicateCheck.Contains(item))
                    return true;

                duplicateCheck.Add(item);
                return false;
            });
        }
    }
}