using System;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Serialization;

namespace Cosmos.Splitters
{
    /// <summary>
    /// Splitter<br />
    /// 字符串分割器
    /// </summary>
    public partial class Splitter : IFixedLengthSplitter
    {
        #region TrimResults

        /// <summary>
        /// Trim results<br />
        /// 修整结果两端
        /// </summary>
        /// <returns></returns>
        IFixedLengthSplitter IFixedLengthSplitter.TrimResults()
        {
            Options.SetTrimResults();
            return this;
        }

        /// <summary>
        /// Trim results<br />
        /// 修整结果，按照指定的方法
        /// </summary>
        /// <param name="trimFunc"></param>
        /// <returns></returns>
        IFixedLengthSplitter IFixedLengthSplitter.TrimResults(Func<string, string> trimFunc)
        {
            Options.SetTrimResults(trimFunc);
            return this;
        }

        #endregion

        #region Limit

        /// <summary>
        /// Limit<br />
        /// 设置限制的值
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        IFixedLengthSplitter IFixedLengthSplitter.Limit(int limit)
        {
            Options.SetLimitLength(limit);
            return this;
        }

        #endregion

        #region WithKeyValueSeparator

        /// <summary>
        /// With KeyValue separator<br />
        /// 设置键值对分隔符
        /// </summary>
        /// <param name="separator"></param>
        /// <returns></returns>
        IMapSplitter IFixedLengthSplitter.WithKeyValueSeparator(string separator)
        {
            Options.SetMapSeparator(separator);
            return this;
        }

        /// <summary>
        /// With KeyValue separator<br />
        /// 设置键值对分隔符
        /// </summary>
        /// <param name="separator"></param>
        /// <returns></returns>
        IMapSplitter IFixedLengthSplitter.WithKeyValueSeparator(char separator)
        {
            Options.SetMapSeparator(separator);
            return this;
        }

        #endregion

        #region Split - List - FixedLength

        /// <summary>
        /// Split<br />
        /// 分割
        /// </summary>
        /// <param name="originalString"></param>
        /// <returns></returns>
        IEnumerable<string> IFixedLengthSplitter.Split(string originalString)
            => InternalSplitToEnumerable2(originalString, s => s);

        /// <summary>
        /// Split<br />
        /// 分割
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalString"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        IEnumerable<T> IFixedLengthSplitter.Split<T>(string originalString, IObjectSerializer serializer)
            => InternalSplitToEnumerable2(originalString, serializer.Deserialize<T>);

        /// <summary>
        /// Split<br />
        /// 分割
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalString"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        IEnumerable<T> IFixedLengthSplitter.Split<T>(string originalString, ITypeConverter<string, T> converter)
            => InternalSplitToEnumerable2(originalString, converter.To);

        /// <summary>
        /// Split<br />
        /// 分割
        /// </summary>
        /// <typeparam name="TMiddle"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalString"></param>
        /// <param name="serializer"></param>
        /// <param name="mapper"></param>
        /// <returns></returns>
        IEnumerable<T> IFixedLengthSplitter.Split<TMiddle, T>(string originalString, IObjectSerializer serializer, IObjectMapper mapper)
            => InternalSplitToEnumerable2(originalString, s => mapper.MapTo<TMiddle, T>(serializer.Deserialize<TMiddle>(s)));

        /// <summary>
        /// Split<br />
        /// 分割
        /// </summary>
        /// <param name="originalString"></param>
        /// <returns></returns>
        List<string> IFixedLengthSplitter.SplitToList(string originalString)
           => ((IFixedLengthSplitter)this).Split(originalString).ToList();

        /// <summary>
        /// Split to list<br />
        /// 分割为列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalString"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        List<T> IFixedLengthSplitter.SplitToList<T>(string originalString, IObjectSerializer serializer)
           => ((IFixedLengthSplitter)this).Split<T>(originalString, serializer).ToList();

        /// <summary>
        /// Split to list<br />
        /// 分割为列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalString"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        List<T> IFixedLengthSplitter.SplitToList<T>(string originalString, ITypeConverter<string, T> converter)
           => ((IFixedLengthSplitter)this).Split(originalString, converter).ToList();

        /// <summary>
        /// Split to list<br />
        /// 分割为列表
        /// </summary>
        /// <typeparam name="TMiddle"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalString"></param>
        /// <param name="serializer"></param>
        /// <param name="mapper"></param>
        /// <returns></returns>
        List<T> IFixedLengthSplitter.SplitToList<TMiddle, T>(string originalString, IObjectSerializer serializer, IObjectMapper mapper)
           => ((IFixedLengthSplitter)this).Split<TMiddle, T>(originalString, serializer, mapper).ToList();

        private IEnumerable<TValue> InternalSplitToEnumerable2<TValue>(string originalString, Func<string, TValue> to)
        {
            if (string.IsNullOrWhiteSpace(originalString))
                return Enumerable.Empty<TValue>();
            var result = new List<string>();
            var middle = SplitterUtils.SplitByFixedLength(originalString, _fixedLengthPattern);

            if (Options.LimitLength >= 0)
            {
                result.AddRange(SplitterUtils.OptionalRange(Options, middle), Options.LimitLength);
            }
            else
            {
                result.AddRange(SplitterUtils.OptionalRange(Options, middle));
            }

            return result.Select(to);
        }

        #endregion

        #region Private class

        private static partial class SplitterUtils
        {
            public static string[] SplitByFixedLength(string originalString, int length)
            {
                var mod = originalString.Length % length;
                var group = mod > 0
                    ? (int)(originalString.Length / length) + 1
                    : (originalString.Length / length);
                var lastGroupLength = mod == 0
                    ? length
                    : mod;
                var middle = new char[group][];
                var pointer = 0;

                for (var i = 0; i < group; i++)
                {
                    var inlineRangeTimes = i == group - 1 ? lastGroupLength : length;
                    middle[i] = new char[inlineRangeTimes];
                    for (var j = 0; j < inlineRangeTimes; j++, pointer++)
                    {
                        middle[i][j] = originalString[pointer];
                    }
                }

                return CharArrayToStringArray(middle);
            }

            private static string[] CharArrayToStringArray(char[][] charArray)
            {
                var results = new string[charArray.Length];
                for (var i = 0; i < charArray.Length; i++)
                    results[i] = new string(charArray[i]);
                return results;
            }
        }

        #endregion
    }

}
