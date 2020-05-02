using System;
using System.Collections.Generic;
using System.Text;

namespace Cosmos.Joiners {
    /// <summary>
    /// TupleJoiner Interface<br />
    /// TupleJoiner 接口
    /// </summary>
    public interface ITupleJoiner {
        /// <summary>
        /// Skip null<br />
        /// 跳过 null
        /// </summary>
        /// <returns></returns>
        ITupleJoiner SkipNulls();

        /// <summary>
        /// Skip null<br />
        /// 跳过 null
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        ITupleJoiner SkipNulls(SkipNullType type);

        /// <summary>
        /// If null, then use the special value.<br />
        /// 如果为 null，则使用指定的值来替代
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="tupleKeyFunc"></param>
        /// <param name="tupleValueFunc"></param>
        /// <returns></returns>
        ITupleJoiner UseForNull<T1, T2>(Func<T1, T2, T1> tupleKeyFunc, Func<T1, T2, T2> tupleValueFunc);

        /// <summary>
        /// Join<br />
        /// 连接
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        string Join(IEnumerable<(string, string)> list);

        /// <summary>
        /// Join<br />
        /// 连接
        /// </summary>
        /// <param name="list"></param>
        /// <param name="defaultKey"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        string Join(IEnumerable<(string, string)> list, string defaultKey, string defaultValue);

        /// <summary>
        /// Join<br />
        /// 连接
        /// </summary>
        /// <param name="tuple1"></param>
        /// <param name="restTuples"></param>
        /// <returns></returns>
        string Join((string, string) tuple1, params (string, string)[] restTuples);

        /// <summary>
        /// Join<br />
        /// 连接
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="list"></param>
        /// <param name="keyFunc"></param>
        /// <param name="valueFunc"></param>
        /// <returns></returns>
        string Join<T1, T2>(IEnumerable<(T1, T2)> list, Func<T1, string> keyFunc, Func<T2, string> valueFunc);

        /// <summary>
        /// Join<br />
        /// 连接
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="list"></param>
        /// <param name="defaultKey"></param>
        /// <param name="defaultValue"></param>
        /// <param name="keyFunc"></param>
        /// <param name="valueFunc"></param>
        /// <returns></returns>
        string Join<T1, T2>(IEnumerable<(T1, T2)> list, T1 defaultKey, T2 defaultValue, Func<T1, string> keyFunc, Func<T2, string> valueFunc);

        /// <summary>
        /// Join<br />
        /// 连接
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="keyFunc"></param>
        /// <param name="valueFunc"></param>
        /// <param name="tuple1"></param>
        /// <param name="restTuples"></param>
        /// <returns></returns>
        string Join<T1, T2>(Func<T1, string> keyFunc, Func<T2, string> valueFunc, (T1, T2) tuple1, params (T1, T2)[] restTuples);

        /// <summary>
        /// Append to...<br />
        /// 附加到...
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        StringBuilder AppendTo(StringBuilder builder, IEnumerable<(string, string)> list);

        /// <summary>
        /// Append to...<br />
        /// 附加到...
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="list"></param>
        /// <param name="defaultKey"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        StringBuilder AppendTo(StringBuilder builder, IEnumerable<(string, string)> list, string defaultKey, string defaultValue);

        /// <summary>
        /// Append to...<br />
        /// 附加到...
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="tuple1"></param>
        /// <param name="restTuples"></param>
        /// <returns></returns>
        StringBuilder AppendTo(StringBuilder builder, (string, string) tuple1, params (string, string)[] restTuples);

        /// <summary>
        /// Append to...<br />
        /// 附加到...
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="builder"></param>
        /// <param name="list"></param>
        /// <param name="keyFunc"></param>
        /// <param name="valueFunc"></param>
        /// <returns></returns>
        StringBuilder AppendTo<T1, T2>(StringBuilder builder, IEnumerable<(T1, T2)> list, Func<T1, string> keyFunc, Func<T2, string> valueFunc);

        /// <summary>
        /// Append to...<br />
        /// 附加到...
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="builder"></param>
        /// <param name="list"></param>
        /// <param name="defaultKey"></param>
        /// <param name="defaultValue"></param>
        /// <param name="keyFunc"></param>
        /// <param name="valueFunc"></param>
        /// <returns></returns>
        StringBuilder AppendTo<T1, T2>(StringBuilder builder, IEnumerable<(T1, T2)> list, T1 defaultKey, T2 defaultValue, Func<T1, string> keyFunc, Func<T2, string> valueFunc);

        /// <summary>
        /// Append to...<br />
        /// 附加到...
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="builder"></param>
        /// <param name="keyFunc"></param>
        /// <param name="valueFunc"></param>
        /// <param name="tuple1"></param>
        /// <param name="restTuples"></param>
        /// <returns></returns>
        StringBuilder AppendTo<T1, T2>(StringBuilder builder, Func<T1, string> keyFunc, Func<T2, string> valueFunc, (T1, T2) tuple1, params (T1, T2)[] restTuples);
    }
}