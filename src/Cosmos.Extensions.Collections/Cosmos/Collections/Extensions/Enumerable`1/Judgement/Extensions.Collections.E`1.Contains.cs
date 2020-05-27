using System;
using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections
{
    public static partial class CollectionExtensions
    {
        /// <summary>
        /// Contains<br />
        /// 包含
        /// </summary>
        /// <param name="me"></param>
        /// <param name="condition"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static bool Contains<T>(this IEnumerable<T> me, Predicate<T> condition) => me.Any(val => condition(val));
    }
}