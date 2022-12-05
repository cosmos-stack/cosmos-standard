namespace Cosmos.Optionals;

/// <summary>
/// Extensions for optional
/// </summary>
public static partial class OptionalsExtensions
{
    #region Collections sync

    /// <summary>
    /// Flattens a sequence of maybe into a sequence containing all inner values.
    /// Empty elements are discarded.
    /// </summary>
    /// <param name="source"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IEnumerable<T> MapValues<T>(this IEnumerable<Maybe<T>> source)
    {
        ArgumentNullException.ThrowIfNull(source);
        foreach (var maybe in source)
            if (maybe.HasValue)
                yield return maybe.Value;
    }

    /// <summary>
    /// Flattens a sequence of either into a sequence containing all inner values.
    /// Empty elements and their exceptional values are discarded.
    /// </summary>
    /// <param name="source"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IEnumerable<T> MapValues<T, TException>(this IEnumerable<Either<T, TException>> source)
    {
        ArgumentNullException.ThrowIfNull(source);
        foreach (var either in source)
            if (either.HasValue)
                yield return either.Value;
    }

    /// <summary>
    /// Flattens a sequence of optionals into a sequence containing all exceptional values.
    /// Non-empty elements and their values are discarded.
    /// </summary>
    /// <param name="source"></param>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TException"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IEnumerable<TException> MapExceptions<T, TException>(this IEnumerable<Either<T, TException>> source)
    {
        ArgumentNullException.ThrowIfNull(source);
        foreach (var either in source)
            if (!either.HasValue)
                yield return either.Exception;
    }

    /// <summary>
    /// Returns the value associated with the specified key if such exists.
    /// A dictionary lookup will be used if available, otherwise falling
    /// back to a linear scan of the enumerable.
    /// </summary>
    /// <param name="source"></param>
    /// <param name="key"></param>
    /// <param name="type"></param>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static IOptional<T> FindOrNone<TKey, T>(this IEnumerable<KeyValuePair<TKey, T>> source, TKey key, OptionalType type = OptionalType.ReferenceType)
    {
        ArgumentNullException.ThrowIfNull(source);
        if (source is IDictionary<TKey, T> dictionary)
            return dictionary.TryGetValue(key, out var value) ? value.Some(type) : value.None(type)!;
        if (source is IReadOnlyDictionary<TKey, T> readOnlyDictionary)
            return readOnlyDictionary.TryGetValue(key, out var value) ? value.Some(type) : value.None(type)!;
        return source
               .FirstOrNone(pair => EqualityComparer<TKey>.Default.Equals(pair.Key, key))
               .Map(pair => pair.Value);
    }

    /// <summary>
    /// Returns the first element of a sequence if such exists.
    /// </summary>
    /// <param name="source"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static Maybe<T> FirstOrNone<T>(this IEnumerable<T> source)
    {
        ArgumentNullException.ThrowIfNull(source);
        if (source is IList<T> list)
        {
            if (list.Count > 0)
                return list[0].AsOptionals();
        }
        else if (source is IReadOnlyList<T> readOnlyList)
        {
            if (readOnlyList.Count > 0)
                return readOnlyList[0].AsOptionals();
        }
        else
        {
            using var enumerator = source.GetEnumerator();
            if (enumerator.MoveNext())
                return enumerator.Current.AsOptionals();
        }

        return Optional.None<T>();
    }

    /// <summary>
    /// Returns the first element of a sequence, satisfying a specified predicate,
    /// if such exists.
    /// </summary>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static Maybe<T> FirstOrNone<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(predicate);
        foreach (var element in source)
        {
            if (predicate(element))
                return element.AsOptionals();
        }

        return Optional.None<T>();
    }

    /// <summary>
    /// Returns the last element of a sequence if such exists.
    /// </summary>
    /// <param name="source"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static Maybe<T> LastOrNone<T>(this IEnumerable<T> source)
    {
        ArgumentNullException.ThrowIfNull(source);
        if (source is IList<T> list)
        {
            var count = list.Count;
            if (count > 0)
                return list[count].AsOptionals();
        }
        else if (source is IReadOnlyList<T> readOnlyList)
        {
            var count = readOnlyList.Count;
            if (count > 0)
                return readOnlyList[count].AsOptionals();
        }
        else
        {
            using var enumerator = source.GetEnumerator();
            if (enumerator.MoveNext())
            {
                T t;
                do
                {
                    t = enumerator.Current;
                } while (enumerator.MoveNext());

                return t.AsOptionals();
            }
        }

        return Optional.None<T>();
    }

    /// <summary>
    /// Returns the last element of a sequence, satisfying a specified predicate,
    /// if such exists.
    /// </summary>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static Maybe<T> LastOrNone<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(predicate);
        if (source is IList<T> list)
        {
            for (var i = list.Count - 1; i >= 0; --i)
            {
                var result = list[i];
                if (predicate(result))
                    return result.AsOptionals();
            }
        }
        else if (source is IReadOnlyList<T> readOnlyList)
        {
            for (var i = readOnlyList.Count - 1; i >= 0; --i)
            {
                var result = readOnlyList[i];
                if (predicate(result))
                    return result.AsOptionals();
            }
        }
        else
        {
            using var enumerator = source.GetEnumerator();
            if (enumerator.MoveNext())
            {
                var result = enumerator.Current;
                if (predicate(result))
                {
                    while (enumerator.MoveNext())
                    {
                        var element = enumerator.Current;
                        if (predicate(element))
                        {
                            result = element;
                        }
                    }

                    return result.AsOptionals();
                }
            }
        }

        return Optional.None<T>();
    }

    /// <summary>
    /// Returns a single element from a sequence, if it exists
    /// and is the only element in the sequence.
    /// </summary>
    /// <param name="source"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static Maybe<T> SingleOrNone<T>(this IEnumerable<T> source)
    {
        ArgumentNullException.ThrowIfNull(source);
        if (source is IList<T> list)
        {
            switch (list.Count)
            {
                case 0: return Optional.None<T>();
                case 1: return list[0].AsOptionals();
            }
        }
        else if (source is IReadOnlyList<T> readOnlyList)
        {
            switch (readOnlyList.Count)
            {
                case 0: return Optional.None<T>();
                case 1: return readOnlyList[0].AsOptionals();
            }
        }
        else
        {
            using var enumerator = source.GetEnumerator();
            if (!enumerator.MoveNext())
                return Optional.None<T>();
            var result = enumerator.Current;
            if (!enumerator.MoveNext())
                return result.AsOptionals();
        }

        return Optional.None<T>();
    }

    /// <summary>
    /// Returns a single element from a sequence, satisfying a specified predicate,
    /// if it exists and is the only element in the sequence.
    /// </summary>
    /// <param name="source"></param>
    /// <param name="predicate"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static Maybe<T> SingleOrNone<T>(this IEnumerable<T> source, Func<T, bool> predicate)
    {
        ArgumentNullException.ThrowIfNull(source);
        ArgumentNullException.ThrowIfNull(predicate);
        using (var enumerator = source.GetEnumerator())
        {
            while (enumerator.MoveNext())
            {
                var result = enumerator.Current;
                if (predicate(result))
                {
                    while (enumerator.MoveNext())
                    {
                        if (predicate(enumerator.Current))
                            return Optional.None<T>();
                    }

                    return result.AsOptionals();
                }
            }
        }

        return Optional.None<T>();
    }

    /// <summary>
    /// Returns an element at a specified position in a sequence if such exists.
    /// </summary>
    /// <param name="source"></param>
    /// <param name="index"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static Maybe<T> ElementAtOrNone<T>(this IEnumerable<T> source, int index)
    {
        ArgumentNullException.ThrowIfNull(source);
        if (index >= 0)
        {
            if (source is IList<T> list)
            {
                if (index < list.Count)
                {
                    return list[index].AsOptionals();
                }
            }
            else if (source is IReadOnlyList<T> readOnlyList)
            {
                if (index < readOnlyList.Count)
                {
                    return readOnlyList[index].AsOptionals();
                }
            }
            else
            {
                using var enumerator = source.GetEnumerator();
                while (enumerator.MoveNext())
                {
                    if (index == 0)
                    {
                        return enumerator.Current.AsOptionals();
                    }

                    index--;
                }
            }
        }

        return Optional.None<T>();
    }

    #endregion
}