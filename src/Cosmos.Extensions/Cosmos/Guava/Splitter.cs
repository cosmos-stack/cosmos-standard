using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
// ReSharper disable InconsistentNaming

namespace Cosmos.Guava
{
    public class Splitter : IGuavaLikeSplitter, IKeyValuePairSplitter
    {
        private readonly bool _regexMode;
        private readonly string[] _on;
        private readonly string _pattern;
        private readonly Regex _regexPattern;

        private Splitter(string[] on)
        {
            _on = on;
            _pattern = string.Empty;
            _regexPattern = null;
            _regexMode = false;
        }

        private Splitter(string pattern)
        {
            _on = new string[0];
            _pattern = pattern;
            _regexPattern = null;
            _regexMode = true;
        }

        private Splitter(Regex regexPattern)
        {
            _on = new string[0];
            _pattern = string.Empty;
            _regexPattern = regexPattern;
            _regexMode = true;
        }

        #region OmitEmptyStrings

        private bool _omitEmptyStrings { get; set; }

        public IGuavaLikeSplitter OmitEmptyStrings()
        {
            _omitEmptyStrings = true;
            return this;
        }

        private StringSplitOptions _getStringSplitOptions() => _omitEmptyStrings ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None;

        #endregion

        #region WithKeyValueSeparator

        private string _kvpSeparator { get; set; }

        public IKeyValuePairSplitter WithKeyValueSeparator(string separator)
        {
            _kvpSeparator = separator;
            return this;
        }

        public IKeyValuePairSplitter WithKeyValueSeparator(char separator)
        {
            return WithKeyValueSeparator($"{separator}");
        }

        #endregion

        #region TrimResults

        private bool _trimResults { get; set; }
        private Func<string, string> _trimFunc { get; set; } = s => s.Trim();
        private bool _kvpTrimResults { get; set; }
        private Func<string, string> _keyTrimFunc { get; set; } = s => s.Trim();
        private Func<string, string> _valueTrimFunc { get; set; } = s => s.Trim();

        IGuavaLikeSplitter IGuavaLikeSplitter.TrimResults()
        {
            _trimResults = true;
            _trimFunc = s => s.Trim();
            return this;
        }

        IGuavaLikeSplitter IGuavaLikeSplitter.TrimResults(Func<string, string> trimFunc)
        {
            _trimResults = true;
            _trimFunc = trimFunc;
            return this;
        }

        IKeyValuePairSplitter IKeyValuePairSplitter.TrimResults()
        {
            _kvpTrimResults = true;
            _keyTrimFunc = s => s.Trim();
            _valueTrimFunc = s => s.Trim();
            return this;
        }


        IKeyValuePairSplitter IKeyValuePairSplitter.TrimResults(Func<string, string> keyTrimFunc, Func<string, string> valueTrimFunc)
        {
            _kvpTrimResults = true;
            _keyTrimFunc = keyTrimFunc;
            _valueTrimFunc = valueTrimFunc;
            return this;
        }

        #endregion

        #region Limit

        private int _limit { get; set; } = -1;
        IGuavaLikeSplitter IGuavaLikeSplitter.Limit(int limit)
        {
            _limit = limit;
            return this;
        }

        IKeyValuePairSplitter IKeyValuePairSplitter.Limit(int limit)
        {
            _limit = limit;
            return this;
        }

        #endregion

        #region Split - List

        private bool _doesUseInLimitedMode() => _limit >= 0 && (!_regexMode || (_regexMode && _regexPattern == null));

        IEnumerable<string> IGuavaLikeSplitter.Split(string originalString)
            => InternalSplitToEnumerable<string>(originalString, s => s);

        IEnumerable<T> IGuavaLikeSplitter.Split<T>(string originalString, IObjectSerializer serializer)
            => InternalSplitToEnumerable<T>(originalString, serializer.Deserialize<T>);

        IEnumerable<T> IGuavaLikeSplitter.Split<T>(string originalString, ITypeConverter<string, T> converter)
            => InternalSplitToEnumerable<T>(originalString, converter.To);

        IEnumerable<T> IGuavaLikeSplitter.Split<TMiddle, T>(string originalString, IObjectSerializer serializer, IObjectMapper mapper)
            => InternalSplitToEnumerable<T>(originalString, s => mapper.MapTo<TMiddle, T>(serializer.Deserialize<TMiddle>(s)));
        
        public List<string> SplitToList(string originalString)
            => ((IGuavaLikeSplitter)this).Split(originalString).ToList();

        public List<T> SplitToList<T>(string originalString, IObjectSerializer serializer)
            => ((IGuavaLikeSplitter)this).Split<T>(originalString, serializer).ToList();

        public List<T> SplitToList<T>(string originalString, ITypeConverter<string, T> converter)
            => ((IGuavaLikeSplitter)this).Split<T>(originalString, converter).ToList();

        public List<T> SplitToList<TMiddle, T>(string originalString, IObjectSerializer serializer, IObjectMapper mapper)
            => ((IGuavaLikeSplitter)this).Split<TMiddle, T>(originalString, serializer, mapper).ToList();

        private IEnumerable<TValue> InternalSplitToEnumerable<TValue>(string originalString, Func<string, TValue> to)
        {
            if (string.IsNullOrWhiteSpace(originalString))
                return Enumerable.Empty<TValue>();

            var result = new List<string>();
            var middle = _regexMode
                ? _regexPattern == null
                    ? Regex.Split(originalString, _pattern)
                    : _limit > 0
                        ? _regexPattern.Split(originalString, _limit)
                        : _regexPattern.Split(originalString)
                : originalString.Split(_on, _getStringSplitOptions());

            if (_doesUseInLimitedMode())
            {
                result.AddRange(_trimResults ? middle.Select(item => _trimFunc?.Invoke(item) ?? item.Trim()) : middle, _limit);
            }
            else
            {
                result.AddRange(_trimResults ? middle.Select(item => _trimFunc?.Invoke(item) ?? item.Trim()) : middle);
            }

            return result.Select(to);
        }

        #endregion

        #region Split - KeyValuePair

        IEnumerable<KeyValuePair<string, T>> IKeyValuePairSplitter.Split<T>(string originalString, IObjectSerializer serializer)
            => InternalSplitToKeyValuePair<T>(originalString, serializer.Deserialize<T>);

        IEnumerable<KeyValuePair<string, T>> IKeyValuePairSplitter.Split<T>(string originalString, ITypeConverter<string, T> converter)
            => InternalSplitToKeyValuePair<T>(originalString, converter.To);

        IEnumerable<KeyValuePair<string, string>> IKeyValuePairSplitter.Split(string originalString)
            => InternalSplitToKeyValuePair<string>(originalString, s => s);

        IEnumerable<KeyValuePair<string, T>> IKeyValuePairSplitter.Split<TMiddle, T>(string originalString, IObjectSerializer serializer, IObjectMapper mapper)
            => InternalSplitToKeyValuePair<T>(originalString, s => mapper.MapTo<TMiddle, T>(serializer.Deserialize<TMiddle>(s)));

        public Dictionary<string, string> SplitToDictionary(string originalString)
            => ((IKeyValuePairSplitter)this).Split(originalString).ToDictionary(k => k.Key, v => v.Value);

        public Dictionary<string, T> SplitToDictionary<T>(string originalString, IObjectSerializer serializer)
            => ((IKeyValuePairSplitter)this).Split<T>(originalString, serializer).ToDictionary(k => k.Key, v => v.Value);

        public Dictionary<string, T> SplitToDictionary<T>(string originalString, ITypeConverter<string, T> converter)
            => ((IKeyValuePairSplitter)this).Split<T>(originalString, converter).ToDictionary(k => k.Key, v => v.Value);

        public Dictionary<string, T> SplitToDictionary<TMiddle, T>(string originalString, IObjectSerializer serializer, IObjectMapper mapper)
            => ((IKeyValuePairSplitter)this).Split<TMiddle, T>(originalString, serializer, mapper).ToDictionary(k => k.Key, v => v.Value);

        private IEnumerable<KeyValuePair<string, TValue>> InternalSplitToKeyValuePair<TValue>(string originalString, Func<string, TValue> to)
        {
            if (string.IsNullOrWhiteSpace(originalString))
                return Enumerable.Empty<KeyValuePair<string, TValue>>();
            var result = new List<KeyValuePair<string, TValue>>();
            var middle = ((IGuavaLikeSplitter)this).Split(originalString);
            foreach (var item in middle)
            {
                var t = item.Split(_kvpSeparator);
                var key = t[0];
                var value = t.Length > 1 ? t[1] : string.Empty;
                result.Add(
                    _kvpTrimResults
                        ? new KeyValuePair<string, TValue>(_keyTrimFunc?.Invoke(key) ?? key.Trim(), to(_valueTrimFunc?.Invoke(value) ?? value.Trim()))
                        : new KeyValuePair<string, TValue>(key, to(value))
                );
            }

            return result;
        }

        #endregion

        #region On

        public static IGuavaLikeSplitter On(string on, params string[] on2)
        {
            var o = new string[(on2?.Length ?? 0) + 1];
            o[0] = on;
            if (o.Length > 1 && on2 != null && on2.Length > 0)
                Array.Copy(on2, 0, o, 1, on2.Length);
            return new Splitter(o);
        }

        public static IGuavaLikeSplitter On(Regex pattern)
        {
            return new Splitter(pattern);
        }

        public static IGuavaLikeSplitter OnPattern(string separatorPattern)
        {
            return new Splitter(separatorPattern);
        }

        #endregion
    }

    public interface IGuavaLikeSplitter
    {
        IGuavaLikeSplitter OmitEmptyStrings();
        IGuavaLikeSplitter TrimResults();
        IGuavaLikeSplitter TrimResults(Func<string, string> trimFunc);
        IGuavaLikeSplitter Limit(int limit);
        IKeyValuePairSplitter WithKeyValueSeparator(char separator);
        IKeyValuePairSplitter WithKeyValueSeparator(string separator);
        IEnumerable<string> Split(string originalString);
        IEnumerable<T> Split<T>(string originalString, IObjectSerializer serializer);
        IEnumerable<T> Split<T>(string originalString, ITypeConverter<string, T> converter);
        IEnumerable<T> Split<TMiddle, T>(string originalString, IObjectSerializer serializer, IObjectMapper mapper);
        List<string> SplitToList(string originalString);
        List<T> SplitToList<T>(string originalString, IObjectSerializer serializer);
        List<T> SplitToList<T>(string originalString, ITypeConverter<string, T> converter);
        List<T> SplitToList<TMiddle, T>(string originalString, IObjectSerializer serializer, IObjectMapper mapper);

    }

    public interface IKeyValuePairSplitter
    {
        IKeyValuePairSplitter TrimResults();
        IKeyValuePairSplitter TrimResults(Func<string, string> keyTrimFunc, Func<string, string> valueTrimFunc);
        IKeyValuePairSplitter Limit(int limit);
        IEnumerable<KeyValuePair<string, string>> Split(string originalString);
        IEnumerable<KeyValuePair<string, T>> Split<T>(string originalString, IObjectSerializer serializer);
        IEnumerable<KeyValuePair<string, T>> Split<T>(string originalString, ITypeConverter<string, T> converter);
        IEnumerable<KeyValuePair<string, T>> Split<TMiddle, T>(string originalString, IObjectSerializer serializer, IObjectMapper mapper);
        Dictionary<string, string> SplitToDictionary(string originalString);
        Dictionary<string, T> SplitToDictionary<T>(string originalString, IObjectSerializer serializer);
        Dictionary<string, T> SplitToDictionary<T>(string originalString, ITypeConverter<string, T> converter);
        Dictionary<string, T> SplitToDictionary<TMiddle, T>(string originalString, IObjectSerializer serializer, IObjectMapper mapper);
    }
}
