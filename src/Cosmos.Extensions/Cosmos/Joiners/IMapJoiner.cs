using System;
using System.Collections.Generic;
using System.Text;

namespace Cosmos.Joiners
{
    /// <summary>
    /// MapJoiner Interface<br />
    /// MapJoiner 接口
    /// </summary>
    public interface IMapJoiner
    {
        /// <summary>
        /// Skip null<br />
        /// 跳过 null
        /// </summary>
        /// <returns></returns>
        IMapJoiner SkipNulls();

        /// <summary>
        /// Skip null<br />
        /// 跳过 null
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        IMapJoiner SkipNulls(SkipNullType type);

        /// <summary>
        /// If null, then use the special value.<br />
        /// 如果为 null，则使用指定的值来替代
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        IMapJoiner UseForNull(string key, string value);

        /// <summary>
        /// If null, then use the special value.<br />
        /// 如果为 null，则使用指定的值来替代
        /// </summary>
        /// <param name="keyFunc"></param>
        /// <param name="valueFunc"></param>
        /// <returns></returns>
        IMapJoiner UseForNull(Func<string, string> keyFunc, Func<string, string> valueFunc);

        /// <summary>
        /// If null, then use the special value.<br />
        /// 如果为 null，则使用指定的值来替代
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        IMapJoiner UseForNull<T1, T2>(T1 key, T2 value);

        /// <summary>
        /// If null, then use the special value.<br />
        /// 如果为 null，则使用指定的值来替代
        /// </summary>
        /// <typeparam name="T1"></typeparam>
        /// <typeparam name="T2"></typeparam>
        /// <param name="keyFunc"></param>
        /// <param name="valueFunc"></param>
        /// <returns></returns>
        IMapJoiner UseForNull<T1, T2>(Func<T1, T1> keyFunc, Func<T2, T2> valueFunc);

        /// <summary>
        /// Switch to tuple mode<br />
        /// 切换为 Tuple 模式
        /// </summary>
        /// <returns></returns>
        ITupleJoiner FromTuple();

        /// <summary>
        /// Join<br />
        /// 连接
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        string Join(IEnumerable<string> list);

        /// <summary>
        /// Join<br />
        /// 连接
        /// </summary>
        /// <param name="list"></param>
        /// <param name="defaultKey"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        string Join(IEnumerable<string> list, string defaultKey, string defaultValue);

        /// <summary>
        /// Join<br />
        /// 连接
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <param name="restStrings"></param>
        /// <returns></returns>
        string Join(string str1, string str2, params string[] restStrings);

        /// <summary>
        /// Join<br />
        /// 连接
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        string Join<T>(IEnumerable<T> list, ITypeConverter<T, string> converter);

        /// <summary>
        /// Join<br />
        /// 连接
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="defaultKey"></param>
        /// <param name="defaultValue"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        string Join<T>(IEnumerable<T> list, T defaultKey, T defaultValue, ITypeConverter<T, string> converter);

        /// <summary>
        /// Join<br />
        /// 连接
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="converter"></param>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <param name="restTs"></param>
        /// <returns></returns>
        string Join<T>(ITypeConverter<T, string> converter, T t1, T t2, params T[] restTs);

        /// <summary>
        /// Append to...<br />
        /// 附加到...
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        StringBuilder AppendTo(StringBuilder builder, IEnumerable<string> list);

        /// <summary>
        /// Append to...<br />
        /// 附加到...
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="list"></param>
        /// <param name="defaultKey"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        StringBuilder AppendTo(StringBuilder builder, IEnumerable<string> list, string defaultKey, string defaultValue);

        /// <summary>
        /// Append to...<br />
        /// 附加到...
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <param name="restStrings"></param>
        /// <returns></returns>
        StringBuilder AppendTo(StringBuilder builder, string str1, string str2, params string[] restStrings);

        /// <summary>
        /// Append to...<br />
        /// 附加到...
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder"></param>
        /// <param name="list"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        StringBuilder AppendTo<T>(StringBuilder builder, IEnumerable<T> list, ITypeConverter<T, string> converter);

        /// <summary>
        /// Append to...<br />
        /// 附加到...
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder"></param>
        /// <param name="list"></param>
        /// <param name="defaultKey"></param>
        /// <param name="defaultValue"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        StringBuilder AppendTo<T>(StringBuilder builder, IEnumerable<T> list, T defaultKey, T defaultValue, ITypeConverter<T, string> converter);

        /// <summary>
        /// Append to...<br />
        /// 附加到...
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder"></param>
        /// <param name="converter"></param>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <param name="restTs"></param>
        /// <returns></returns>
        StringBuilder AppendTo<T>(StringBuilder builder, ITypeConverter<T, string> converter, T t1, T t2, params T[] restTs);
    }
}