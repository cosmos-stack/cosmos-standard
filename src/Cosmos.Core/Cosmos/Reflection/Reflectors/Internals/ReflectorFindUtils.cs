namespace Cosmos.Reflection.Reflectors.Internals;

internal static class ReflectorFindUtils
{
    /// <summary>
    /// find member using binary search
    /// </summary>
    /// <typeparam name="TReflector"></typeparam>
    /// <typeparam name="TMemberInfo"></typeparam>
    /// <param name="reflectors">pre order by name</param>
    /// <param name="name"></param>
    /// <returns></returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal static TReflector FindMember<TReflector, TMemberInfo>(TReflector[] reflectors, string name)
        where TReflector : MemberReflector<TMemberInfo>
        where TMemberInfo : MemberInfo
    {
        ArgumentNullException.ThrowIfNull(name);

        var length = reflectors.Length;
        if (length == 0)
            return null;

        if (length == 1)
        {
            var reflector = reflectors[0];
            if (reflector.Name == name)
            {
                return reflector;
            }

            return null;
        }

        // do binary search
        var first = 0;
        while (first <= length)
        {
            var middle = (first + length) / 2;
            var entry = reflectors[middle];
            var compareResult = string.CompareOrdinal(entry.Name, name);
            if (compareResult == 0)
            {
                return entry;
            }
            else if (compareResult < 0)
            {
                first = middle + 1;
            }
            // ReSharper disable once ConditionIsAlwaysTrueOrFalse
            else if (compareResult > 0)
            {
                length = middle - 1;
            }
        }

        return null;
    }
}