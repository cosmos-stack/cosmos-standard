using System;
using System.Collections.Generic;

namespace Cosmos.Reflection
{
    /// <summary>
    /// Cosmos <see cref="object"/> extensions.
    /// </summary>
    public static class ObjectRefExtensions
    {
        #region GetHashCode

        /// <summary>
        /// Get hashcode
        /// </summary>
        /// <param name="x"></param>
        /// <param name="hashFieldValuesFunc"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static int GetHashCode<T>(this T x, Func<T, IEnumerable<object>> hashFieldValuesFunc)
            => HashCodeUtil.InternalCalculator.GetHashCodeImpl(hashFieldValuesFunc(x));

        #endregion
    }
}