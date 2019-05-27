using System;
using System.Collections.Generic;
using System.Text;

namespace Cosmos.Joiners
{
    public interface ITupleJoiner
    {
        ITupleJoiner SkipNulls();
        ITupleJoiner SkipNulls(SkipNullType type);
        ITupleJoiner UseForNull<T1, T2>(Func<T1, T2, T1> tupleKeyFunc, Func<T1, T2, T2> tupleValueFunc);
        string Join(IEnumerable<(string, string)> list);
        string Join(IEnumerable<(string, string)> list, string defaultKey, string defaultValue);
        string Join((string, string) tuple1, params (string, string)[] restTuples);
        string Join<T1, T2>(IEnumerable<(T1, T2)> list, Func<T1, string> keyFunc, Func<T2, string> valueFunc);
        string Join<T1, T2>(IEnumerable<(T1, T2)> list, T1 defaultKey, T2 defaultValue, Func<T1, string> keyFunc, Func<T2, string> valueFunc);
        string Join<T1, T2>(Func<T1, string> keyFunc, Func<T2, string> valueFunc, (T1, T2) tuple1, params (T1, T2)[] restTuples);
        StringBuilder AppendTo(StringBuilder builder, IEnumerable<(string, string)> list);
        StringBuilder AppendTo(StringBuilder builder, IEnumerable<(string, string)> list, string defaultKey, string defaultValue);
        StringBuilder AppendTo(StringBuilder builder, (string, string) tuple1, params (string, string)[] restTuples);
        StringBuilder AppendTo<T1, T2>(StringBuilder builder, IEnumerable<(T1, T2)> list, Func<T1, string> keyFunc, Func<T2, string> valueFunc);
        StringBuilder AppendTo<T1, T2>(StringBuilder builder, IEnumerable<(T1, T2)> list, T1 defaultKey, T2 defaultValue, Func<T1, string> keyFunc, Func<T2, string> valueFunc);
        StringBuilder AppendTo<T1, T2>(StringBuilder builder, Func<T1, string> keyFunc, Func<T2, string> valueFunc, (T1, T2) tuple1, params (T1, T2)[] restTuples);
    }
}