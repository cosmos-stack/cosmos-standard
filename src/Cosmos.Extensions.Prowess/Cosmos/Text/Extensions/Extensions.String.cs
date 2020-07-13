using System.Collections.Generic;
using Cosmos.Collections;

// ReSharper disable once CheckNamespace
namespace Cosmos.Text
{
    /// <summary>
    /// String extensions
    /// </summary>
    public static partial class StringExtensions
    {
        /// <summary>
        /// Use As Separator For
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="separator"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public static string UseAsSeparatorFor<T>(this string separator, IEnumerable<T> list) => list.JoinToString(separator);
    }
}