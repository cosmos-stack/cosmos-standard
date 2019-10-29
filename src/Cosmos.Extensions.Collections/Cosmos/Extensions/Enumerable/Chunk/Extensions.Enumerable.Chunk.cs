using System;
using System.Collections.Generic;

// ReSharper disable once CheckNamespace
namespace Cosmos.Collections
{
    /// <summary>
    /// Enumerable extensions
    /// </summary>
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Chunk
        /// </summary>
        /// <param name="source"></param>
        /// <param name="size"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static IEnumerable<IEnumerable<T>> Chunk<T>(this IEnumerable<T> source, int size)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));
            if (size <= 0)
                throw new ArgumentOutOfRangeException(nameof(size), size, $"The {nameof(size)} parameter must be a positive value.");

            using (var enumerator = source.GetEnumerator())
            {
                do
                {
                    if (!enumerator.MoveNext())
                        yield break;
                    
                    yield return ChunkSequence(enumerator, size);
                    
                } while (true);
            }
        }

        private static IEnumerable<T> ChunkSequence<T>(IEnumerator<T> enumerator, int size)
        {
            if (enumerator == null)
                throw new ArgumentNullException(nameof(enumerator));

            var count = 0;

            do
            {
                yield return enumerator.Current;
            } while (++count < size && enumerator.MoveNext());
        }
    }
}