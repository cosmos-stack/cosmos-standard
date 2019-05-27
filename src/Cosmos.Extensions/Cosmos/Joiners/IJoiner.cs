using System;
using System.Collections.Generic;
using System.Text;

namespace Cosmos.Joiners
{
    public interface IJoiner
    {
        IJoiner SkipNulls();
        IJoiner UseForNull(string value);
        IJoiner UseForNull(Func<string, string> valueFunc);
        IMapJoiner WithKeyValueSeparator(string separator);
        IMapJoiner WithKeyValueSeparator(char separator);
        string Join(IEnumerable<string> list);
        string Join(string str1, params string[] restStrings);
        string Join<T>(IEnumerable<T> list, ITypeConverter<T, string> converter);
        string Join<T>(IEnumerable<T> list, Func<T, string> to);
        string Join<T>(ITypeConverter<T, string> converter, T item1, params T[] restItems);
        string Join<T>(Func<T, string> to, T item1, params T[] restItems);
        StringBuilder AppendTo(StringBuilder builder, IEnumerable<string> list);
        StringBuilder AppendTo(StringBuilder builder, string str1, params string[] restStrings);
        StringBuilder AppendTo<T>(StringBuilder builder, IEnumerable<T> list, ITypeConverter<T, string> converter);
        StringBuilder AppendTo<T>(StringBuilder builder, IEnumerable<T> list, Func<T, string> to);
        StringBuilder AppendTo<T>(StringBuilder builder, ITypeConverter<T, string> converter, T item1, params T[] restItems);
        StringBuilder AppendTo<T>(StringBuilder builder, Func<T, string> to, T item1, params T[] restItems);
    }

}