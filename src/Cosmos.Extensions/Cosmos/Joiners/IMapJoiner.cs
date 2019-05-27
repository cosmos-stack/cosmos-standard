using System;
using System.Collections.Generic;
using System.Text;

namespace Cosmos.Joiners
{

    public interface IMapJoiner
    {
        IMapJoiner SkipNulls();
        IMapJoiner SkipNulls(SkipNullType type);
        IMapJoiner UseForNull(string key, string value);
        IMapJoiner UseForNull(Func<string, string> keyFunc, Func<string, string> valueFunc);
        IMapJoiner UseForNull<T1, T2>(T1 key, T2 value);
        IMapJoiner UseForNull<T1, T2>(Func<T1, T1> keyFunc, Func<T2, T2> valueFunc);
        ITupleJoiner FromTuple();
        string Join(IEnumerable<string> list);
        string Join(IEnumerable<string> list, string defaultKey, string defaultValue);
        string Join(string str1, string str2, params string[] restStrings);
        string Join<T>(IEnumerable<T> list, ITypeConverter<T, string> converter);
        string Join<T>(IEnumerable<T> list, T defaultKey, T defaultValue, ITypeConverter<T, string> converter);
        string Join<T>(ITypeConverter<T, string> converter, T t1, T t2, params T[] restTs);
        StringBuilder AppendTo(StringBuilder builder, IEnumerable<string> list);
        StringBuilder AppendTo(StringBuilder builder, IEnumerable<string> list, string defaultKey, string defaultValue);
        StringBuilder AppendTo(StringBuilder builder, string str1, string str2, params string[] restStrings);
        StringBuilder AppendTo<T>(StringBuilder builder, IEnumerable<T> list, ITypeConverter<T, string> converter);
        StringBuilder AppendTo<T>(StringBuilder builder, IEnumerable<T> list, T defaultKey, T defaultValue, ITypeConverter<T, string> converter);
        StringBuilder AppendTo<T>(StringBuilder builder, ITypeConverter<T, string> converter, T t1, T t2, params T[] restTs);
    }
}