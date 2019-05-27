using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmos.Splitters
{
    public partial class Splitter : IMapSplitter
    {

        #region TrimResults

        IMapSplitter IMapSplitter.TrimResults()
        {
            Options.SetTrimResults(k => k.Trim(), v => v.Trim());
            return this;
        }

        IMapSplitter IMapSplitter.TrimResults(Func<string, string> keyTrimFunc, Func<string, string> valueTrimFunc)
        {
            Options.SetTrimResults(keyTrimFunc, valueTrimFunc);
            return this;
        }

        #endregion

        #region Limit

        IMapSplitter IMapSplitter.Limit(int limit)
        {
            Options.SetLimitLength(limit);
            return this;
        }

        #endregion

        #region Split - KeyValuePair

        IEnumerable<KeyValuePair<string, T>> IMapSplitter.Split<T>(string originalString, IObjectSerializer serializer)
            => InternalSplitToKeyValuePair(originalString, serializer.Deserialize<T>);

        IEnumerable<KeyValuePair<string, T>> IMapSplitter.Split<T>(string originalString, ITypeConverter<string, T> converter)
            => InternalSplitToKeyValuePair(originalString, converter.To);

        IEnumerable<KeyValuePair<string, string>> IMapSplitter.Split(string originalString)
            => InternalSplitToKeyValuePair(originalString, s => s);

        IEnumerable<KeyValuePair<string, T>> IMapSplitter.Split<TMiddle, T>(string originalString, IObjectSerializer serializer, IObjectMapper mapper)
            => InternalSplitToKeyValuePair(originalString, s => mapper.MapTo<TMiddle, T>(serializer.Deserialize<TMiddle>(s)));

        public Dictionary<string, string> SplitToDictionary(string originalString)
            => ((IMapSplitter)this).Split(originalString).ToDictionary(k => k.Key, v => v.Value);

        public Dictionary<string, T> SplitToDictionary<T>(string originalString, IObjectSerializer serializer)
            => ((IMapSplitter)this).Split<T>(originalString, serializer).ToDictionary(k => k.Key, v => v.Value);

        public Dictionary<string, T> SplitToDictionary<T>(string originalString, ITypeConverter<string, T> converter)
            => ((IMapSplitter)this).Split(originalString, converter).ToDictionary(k => k.Key, v => v.Value);

        public Dictionary<string, T> SplitToDictionary<TMiddle, T>(string originalString, IObjectSerializer serializer, IObjectMapper mapper)
            => ((IMapSplitter)this).Split<TMiddle, T>(originalString, serializer, mapper).ToDictionary(k => k.Key, v => v.Value);

        private IEnumerable<KeyValuePair<string, TValue>> InternalSplitToKeyValuePair<TValue>(string originalString, Func<string, TValue> to)
        {
            if (string.IsNullOrWhiteSpace(originalString))
                return Enumerable.Empty<KeyValuePair<string, TValue>>();

            var result = new List<KeyValuePair<string, TValue>>();
            var middle = _fixedLengthMode
                ? ((IFixedLengthSplitter)this).Split(originalString)
                : ((ISplitter)this).Split(originalString);

            foreach (var item in middle)
            {
                var (k, v) = SplitterUtils.SplitMap(Options, item);
                result.Add(SplitterUtils.OptionalMap(Options, k, v, to));
            }

            return result;
        }

        #endregion

        #region Private class

        private partial class SplitterOptions
        {
            #region WithKeyValueSeparator

            public string MapSeparator { get; private set; }

            public void SetMapSeparator(string separator)
            {
                MapSeparator = separator;
            }

            public void SetMapSeparator(char separator)
            {
                MapSeparator = $"{separator}";
            }

            #endregion

            #region TrimResults

            public bool MapTrimResultsFlag { get; private set; }

            public Func<string, string> KeyTrimFunc { get; private set; }

            public Func<string, string> ValueTrimFunc { get; private set; }

            public void SetTrimResults(Func<string, string> keyFunc, Func<string, string> valueFunc)
            {
                MapTrimResultsFlag = true;
                KeyTrimFunc = keyFunc ?? (k => k.Trim());
                ValueTrimFunc = valueFunc ?? (v => v.Trim());
            }

            #endregion
        }

        private static partial class SplitterUtils
        {
            public static KeyValuePair<string, TValue> OptionalMap<TValue>(SplitterOptions options, string key, string value, Func<string, TValue> to)
            {
                return options.MapTrimResultsFlag
                    ? new KeyValuePair<string, TValue>(options.KeyTrimFunc(key), to(options.ValueTrimFunc(value)))
                    : new KeyValuePair<string, TValue>(key, to(value));
            }

            public static (string, string) SplitMap(SplitterOptions options, string middleString)
            {
                var t = middleString.Split(options.MapSeparator);
                var key = t[0];
                var value = t.Length > 1 ? t[1] : string.Empty;
                return (key, value);
            }

        }

        #endregion
    }

}
