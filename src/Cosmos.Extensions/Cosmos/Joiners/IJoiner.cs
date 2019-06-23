using System;
using System.Collections.Generic;
using System.Text;

namespace Cosmos.Joiners
{
    /// <summary>
    /// Joiner Interface<br />
    /// 连接器接口
    /// </summary>
    public interface IJoiner
    {
        /// <summary>
        /// Skip null<br />
        /// 跳过 null
        /// </summary>
        /// <returns></returns>
        IJoiner SkipNulls();

        /// <summary>
        /// If null, then use the special value.<br />
        /// 如果为 null，则使用指定的值来替代
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        IJoiner UseForNull(string value);

        /// <summary>
        /// If null, then use the special value.<br />
        /// 如果为 null，则使用指定的值来替代
        /// </summary>
        /// <param name="valueFunc"></param>
        /// <returns></returns>
        IJoiner UseForNull(Func<string, string> valueFunc);

        /// <summary>
        /// With KeyValue Separator
        /// </summary>
        /// <param name="separator"></param>
        /// <returns></returns>
        IMapJoiner WithKeyValueSeparator(string separator);

        /// <summary>
        /// With KeyValue Separator
        /// </summary>
        /// <param name="separator"></param>
        /// <returns></returns>
        IMapJoiner WithKeyValueSeparator(char separator);

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
        /// <param name="str1"></param>
        /// <param name="restStrings"></param>
        /// <returns></returns>
        string Join(string str1, params string[] restStrings);

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
        /// <param name="to"></param>
        /// <returns></returns>
        string Join<T>(IEnumerable<T> list, Func<T, string> to);

        /// <summary>
        /// Join<br />
        /// 连接
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="converter"></param>
        /// <param name="item1"></param>
        /// <param name="restItems"></param>
        /// <returns></returns>
        string Join<T>(ITypeConverter<T, string> converter, T item1, params T[] restItems);

        /// <summary>
        /// Join<br />
        /// 连接
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="to"></param>
        /// <param name="item1"></param>
        /// <param name="restItems"></param>
        /// <returns></returns>
        string Join<T>(Func<T, string> to, T item1, params T[] restItems);

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
        /// <param name="str1"></param>
        /// <param name="restStrings"></param>
        /// <returns></returns>
        StringBuilder AppendTo(StringBuilder builder, string str1, params string[] restStrings);

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
        /// <param name="to"></param>
        /// <returns></returns>
        StringBuilder AppendTo<T>(StringBuilder builder, IEnumerable<T> list, Func<T, string> to);

        /// <summary>
        /// Append to...<br />
        /// 附加到...
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder"></param>
        /// <param name="converter"></param>
        /// <param name="item1"></param>
        /// <param name="restItems"></param>
        /// <returns></returns>
        StringBuilder AppendTo<T>(StringBuilder builder, ITypeConverter<T, string> converter, T item1, params T[] restItems);

        /// <summary>
        /// Append to...<br />
        /// 附加到...
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="builder"></param>
        /// <param name="to"></param>
        /// <param name="item1"></param>
        /// <param name="restItems"></param>
        /// <returns></returns>
        StringBuilder AppendTo<T>(StringBuilder builder, Func<T, string> to, T item1, params T[] restItems);
    }

}