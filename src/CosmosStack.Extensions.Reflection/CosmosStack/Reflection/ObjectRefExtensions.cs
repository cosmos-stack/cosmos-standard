using System;
using System.Collections.Generic;

namespace CosmosStack.Reflection
{
    /// <summary>
    /// CosmosStack <see cref="object"/> extensions. <br />
    /// 对象扩展
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