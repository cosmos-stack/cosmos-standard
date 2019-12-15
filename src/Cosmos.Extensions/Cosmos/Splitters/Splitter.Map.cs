using System;
using System.Collections.Generic;
using System.Linq;
using Cosmos.Serialization;

namespace Cosmos.Splitters {
    /// <summary>
    /// Splitter<br />
    /// 字符串分割器
    /// </summary>
    public partial class Splitter : IMapSplitter {

        #region TrimResults

        /// <summary>
        /// Trim results<br />
        /// 修整结果两端
        /// </summary>
        /// <returns></returns>
        IMapSplitter IMapSplitter.TrimResults() {
            Options.SetTrimResults(k => k.Trim(), v => v.Trim());
            return this;
        }

        /// <summary>
        /// Trim results<br />
        /// 修整结果，按照指定的方法
        /// </summary>
        /// <param name="keyTrimFunc"></param>
        /// <param name="valueTrimFunc"></param>
        /// <returns></returns>
        IMapSplitter IMapSplitter.TrimResults(Func<string, string> keyTrimFunc, Func<string, string> valueTrimFunc) {
            Options.SetTrimResults(keyTrimFunc, valueTrimFunc);
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
        IMapSplitter IMapSplitter.Limit(int limit) {
            Options.SetLimitLength(limit);
            return this;
        }

        #endregion

        #region Split - KeyValuePair

        /// <summary>
        /// Split<br />
        /// 分割
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalString"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        IEnumerable<KeyValuePair<string, T>> IMapSplitter.Split<T>(string originalString, IObjectSerializer serializer)
            => InternalSplitToKeyValuePair(originalString, serializer.Deserialize<T>);

        /// <summary>
        /// Split<br />
        /// 分割
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalString"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        IEnumerable<KeyValuePair<string, T>> IMapSplitter.Split<T>(string originalString, ITypeConverter<string, T> converter)
            => InternalSplitToKeyValuePair(originalString, converter.To);

        /// <summary>
        /// Split<br />
        /// 分割
        /// </summary>
        /// <param name="originalString"></param>
        /// <returns></returns>
        IEnumerable<KeyValuePair<string, string>> IMapSplitter.Split(string originalString)
            => InternalSplitToKeyValuePair(originalString, s => s);

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
        IEnumerable<KeyValuePair<string, T>> IMapSplitter.Split<TMiddle, T>(string originalString, IObjectSerializer serializer, IObjectMapper mapper)
            => InternalSplitToKeyValuePair(originalString, s => mapper.MapTo<TMiddle, T>(serializer.Deserialize<TMiddle>(s)));

        /// <summary>
        /// Split to dictionary<br />
        /// 分割为字典
        /// </summary>
        /// <param name="originalString"></param>
        /// <returns></returns>
        public Dictionary<string, string> SplitToDictionary(string originalString)
            => ((IMapSplitter) this).Split(originalString).ToDictionary(k => k.Key, v => v.Value);

        /// <summary>
        /// Split to dictionary<br />
        /// 分割为字典
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalString"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public Dictionary<string, T> SplitToDictionary<T>(string originalString, IObjectSerializer serializer)
            => ((IMapSplitter) this).Split<T>(originalString, serializer).ToDictionary(k => k.Key, v => v.Value);

        /// <summary>
        /// Split to dictionary<br />
        /// 分割为字典
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalString"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        public Dictionary<string, T> SplitToDictionary<T>(string originalString, ITypeConverter<string, T> converter)
            => ((IMapSplitter) this).Split(originalString, converter).ToDictionary(k => k.Key, v => v.Value);

        /// <summary>
        /// Split to dictionary<br />
        /// 分割为字典
        /// </summary>
        /// <typeparam name="TMiddle"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalString"></param>
        /// <param name="serializer"></param>
        /// <param name="mapper"></param>
        /// <returns></returns>
        public Dictionary<string, T> SplitToDictionary<TMiddle, T>(string originalString, IObjectSerializer serializer, IObjectMapper mapper)
            => ((IMapSplitter) this).Split<TMiddle, T>(originalString, serializer, mapper).ToDictionary(k => k.Key, v => v.Value);

        private IEnumerable<KeyValuePair<string, TValue>> InternalSplitToKeyValuePair<TValue>(string originalString, Func<string, TValue> to) {
            if (string.IsNullOrWhiteSpace(originalString))
                return Enumerable.Empty<KeyValuePair<string, TValue>>();

            var result = new List<KeyValuePair<string, TValue>>();
            var middle = _fixedLengthMode
                ? ((IFixedLengthSplitter) this).Split(originalString)
                : ((ISplitter) this).Split(originalString);

            foreach (var item in middle) {
                var (k, v) = SplitterUtils.SplitMap(Options, item);
                result.Add(SplitterUtils.OptionalMap(Options, k, v, to));
            }

            return result;
        }

        #endregion

        #region Private class

        private partial class SplitterOptions {

            #region WithKeyValueSeparator

            public string MapSeparator { get; private set; }

            public void SetMapSeparator(string separator) {
                MapSeparator = separator;
            }

            public void SetMapSeparator(char separator) {
                MapSeparator = $"{separator}";
            }

            #endregion

            #region TrimResults

            public bool MapTrimResultsFlag { get; private set; }

            public Func<string, string> KeyTrimFunc { get; private set; }

            public Func<string, string> ValueTrimFunc { get; private set; }

            public void SetTrimResults(Func<string, string> keyFunc, Func<string, string> valueFunc) {
                MapTrimResultsFlag = true;
                KeyTrimFunc = keyFunc ?? (k => k.Trim());
                ValueTrimFunc = valueFunc ?? (v => v.Trim());
            }

            #endregion

        }

        private static partial class SplitterUtils {
            public static KeyValuePair<string, TValue> OptionalMap<TValue>(SplitterOptions options, string key, string value, Func<string, TValue> to) {
                return options.MapTrimResultsFlag
                    ? new KeyValuePair<string, TValue>(options.KeyTrimFunc(key), to(options.ValueTrimFunc(value)))
                    : new KeyValuePair<string, TValue>(key, to(value));
            }

            public static (string, string) SplitMap(SplitterOptions options, string middleString) {
                var t = middleString.Split(options.MapSeparator);
                var key = t[0];
                var value = t.Length > 1 ? t[1] : string.Empty;
                return (key, value);
            }

        }

        #endregion

    }

}