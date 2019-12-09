using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Cosmos.Collections;
using Cosmos.Serialization;

// ReSharper disable InconsistentNaming

namespace Cosmos.Splitters {
    /// <summary>
    /// Splitter<br />
    /// 字符串分割器
    /// </summary>
    public partial class Splitter : ISplitter {
        private readonly bool _regexMode;
        private readonly bool _fixedLengthMode;
        private readonly string[] _on;
        private readonly string _pattern;
        private readonly Regex _regexPattern;
        private readonly int _fixedLengthPattern;

        private SplitterOptions Options { get; set; } = new SplitterOptions();

        private Splitter(string[] on) {
            _on = on;
            _pattern = string.Empty;
            _regexPattern = null;
            _regexMode = false;
            _fixedLengthPattern = 0;
            _fixedLengthMode = false;
        }

        private Splitter(string pattern) {
            _on = new string[0];
            _pattern = pattern;
            _regexPattern = null;
            _regexMode = true;
            _fixedLengthPattern = 0;
            _fixedLengthMode = false;
        }

        private Splitter(Regex regexPattern) {
            _on = new string[0];
            _pattern = string.Empty;
            _regexPattern = regexPattern;
            _regexMode = true;
            _fixedLengthPattern = 0;
            _fixedLengthMode = false;
        }

        private Splitter(int fixedLength) {
            _on = new string[0];
            _pattern = string.Empty;
            _regexPattern = null;
            _regexMode = false;
            _fixedLengthPattern = fixedLength;
            _fixedLengthMode = true;
        }

        #region OmitEmptyStrings

        /// <summary>
        /// Omit empty string<br />
        /// 移除空字符串
        /// </summary>
        /// <returns></returns>
        public ISplitter OmitEmptyStrings() {
            Options.SetOmitEmptyStrings();
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
        IMapSplitter ISplitter.WithKeyValueSeparator(string separator) {
            Options.SetMapSeparator(separator);
            return this;
        }

        /// <summary>
        /// With KeyValue separator<br />
        /// 设置键值对分隔符
        /// </summary>
        /// <param name="separator"></param>
        /// <returns></returns>
        IMapSplitter ISplitter.WithKeyValueSeparator(char separator) {
            Options.SetMapSeparator(separator);
            return this;
        }

        #endregion

        #region TrimResults

        /// <summary>
        /// Trim results<br />
        /// 修整结果两端
        /// </summary>
        /// <returns></returns>
        ISplitter ISplitter.TrimResults() {
            Options.SetTrimResults();
            return this;
        }

        /// <summary>
        /// Trim results<br />
        /// 修整结果，按照指定的方法
        /// </summary>
        /// <param name="trimFunc"></param>
        /// <returns></returns>
        ISplitter ISplitter.TrimResults(Func<string, string> trimFunc) {
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
        ISplitter ISplitter.Limit(int limit) {
            Options.SetLimitLength(limit);
            return this;
        }

        #endregion

        #region Split - List

        private bool _doesUseInLimitedMode() => Options.LimitLength >= 0 && (!_regexMode || (_regexMode && _regexPattern == null));

        /// <summary>
        /// Split<br />
        /// 分割
        /// </summary>
        /// <param name="originalString"></param>
        /// <returns></returns>
        IEnumerable<string> ISplitter.Split(string originalString)
            => InternalSplitToEnumerable(originalString, s => s);

        /// <summary>
        /// Split<br />
        /// 分割
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalString"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        IEnumerable<T> ISplitter.Split<T>(string originalString, IObjectSerializer serializer)
            => InternalSplitToEnumerable(originalString, serializer.Deserialize<T>);

        /// <summary>
        /// Split<br />
        /// 分割
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalString"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        IEnumerable<T> ISplitter.Split<T>(string originalString, ITypeConverter<string, T> converter)
            => InternalSplitToEnumerable(originalString, converter.To);

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
        IEnumerable<T> ISplitter.Split<TMiddle, T>(string originalString, IObjectSerializer serializer, IObjectMapper mapper)
            => InternalSplitToEnumerable(originalString, s => mapper.MapTo<TMiddle, T>(serializer.Deserialize<TMiddle>(s)));

        /// <summary>
        /// Split to list<br />
        /// 分割为列表
        /// </summary>
        /// <param name="originalString"></param>
        /// <returns></returns>
        List<string> ISplitter.SplitToList(string originalString)
            => ((ISplitter) this).Split(originalString).ToList();

        /// <summary>
        /// Split to list<br />
        /// 分割为列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalString"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        List<T> ISplitter.SplitToList<T>(string originalString, IObjectSerializer serializer)
            => ((ISplitter) this).Split<T>(originalString, serializer).ToList();

        /// <summary>
        /// Split to list<br />
        /// 分割为列表
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalString"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        List<T> ISplitter.SplitToList<T>(string originalString, ITypeConverter<string, T> converter)
            => ((ISplitter) this).Split(originalString, converter).ToList();

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
        List<T> ISplitter.SplitToList<TMiddle, T>(string originalString, IObjectSerializer serializer, IObjectMapper mapper)
            => ((ISplitter) this).Split<TMiddle, T>(originalString, serializer, mapper).ToList();

        private IEnumerable<TValue> InternalSplitToEnumerable<TValue>(string originalString, Func<string, TValue> to) {
            if (string.IsNullOrWhiteSpace(originalString))
                return Enumerable.Empty<TValue>();

            var result = new List<string>();
            var middle = _regexMode
                ? SplitterUtils.SplitPatternList(Options, originalString, _pattern, _regexPattern)
                : SplitterUtils.SplitList(Options, originalString, _on);

            if (_doesUseInLimitedMode()) {
                result.AddRange(SplitterUtils.OptionalRange(Options, middle), Options.LimitLength);
            }
            else {
                result.AddRange(SplitterUtils.OptionalRange(Options, middle));
            }

            return result.Select(to);
        }

        #endregion

        #region On

        /// <summary>
        /// On, to create a new Splitter instance.<br />
        /// On 操作，创建一个新的 Splitter 实例。
        /// </summary>
        /// <param name="on"></param>
        /// <param name="on2"></param>
        /// <returns></returns>
        public static ISplitter On(string on, params string[] on2) {
            var o = new string[(on2?.Length ?? 0) + 1];
            o[0] = on;
            if (o.Length > 1 && on2 != null && on2.Length > 0)
                Array.Copy(on2, 0, o, 1, on2.Length);
            return new Splitter(o);
        }

        /// <summary>
        /// On, to create a new Splitter instance.<br />
        /// On 操作，创建一个新的 Splitter 实例。
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static ISplitter On(Regex pattern) {
            return new Splitter(pattern);
        }

        /// <summary>
        /// On, to create a new Splitter instance.<br />
        /// On 操作，创建一个新的 Splitter 实例。
        /// </summary>
        /// <param name="separatorPattern"></param>
        /// <returns></returns>
        public static ISplitter OnPattern(string separatorPattern) {
            return new Splitter(separatorPattern);
        }

        #endregion

        #region FixedLength

        /// <summary>
        /// Fixed length<br />
        /// 固定长度
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        public static IFixedLengthSplitter FixedLength(int length) {
            if (length <= 0)
                throw new ArgumentOutOfRangeException(nameof(length), length, "The fixedLength must be greater than zero.");
            return new Splitter(length);
        }

        #endregion

        #region Private class

        private partial class SplitterOptions {

            #region OmitEmptyStrings

            private bool OmitEmptyStrings { get; set; }

            public void SetOmitEmptyStrings() {
                OmitEmptyStrings = true;
            }

            public StringSplitOptions GetStringSplitOptions() => OmitEmptyStrings ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None;

            #endregion

            #region Limit

            public int LimitLength { get; private set; } = -1;

            public void SetLimitLength(int limit) {
                if (limit <= 0)
                    LimitLength = -1;
                else
                    LimitLength = limit;
            }

            #endregion

            #region TrimResults

            public bool TrimResultsFlag { get; private set; }

            public Func<string, string> TrimFunc { get; private set; }

            public void SetTrimResults() {
                TrimResultsFlag = true;
                TrimFunc = s => s.Trim();
            }

            public void SetTrimResults(Func<string, string> func) {
                TrimResultsFlag = true;
                TrimFunc = func ?? (s => s.Trim());
            }

            #endregion

        }

        private static partial class SplitterUtils {
            public static IEnumerable<string> OptionalRange(SplitterOptions options, string[] middleStrings) {
                return options.TrimResultsFlag ? middleStrings.Select(options.TrimFunc) : middleStrings;
            }

            public static string[] SplitList(SplitterOptions options, string originalString, string[] on) {
                return originalString.Split(on, options.GetStringSplitOptions());
            }

            public static string[] SplitPatternList(SplitterOptions options, string originalString, string stringPattern, Regex regexPattern) {
                return regexPattern == null
                    ? Regex.Split(originalString, stringPattern)
                    : options.LimitLength > 0
                        ? regexPattern.Split(originalString, options.LimitLength)
                        : regexPattern.Split(originalString);
            }
        }

        #endregion

    }

}