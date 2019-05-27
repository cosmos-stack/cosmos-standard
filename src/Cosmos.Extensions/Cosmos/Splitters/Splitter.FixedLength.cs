using System;
using System.Collections.Generic;
using System.Linq;

namespace Cosmos.Splitters
{
    public partial class Splitter : IFixedLengthSplitter
    {
        #region TrimResults

        IFixedLengthSplitter IFixedLengthSplitter.TrimResults()
        {
            Options.SetTrimResults();
            return this;
        }

        IFixedLengthSplitter IFixedLengthSplitter.TrimResults(Func<string, string> trimFunc)
        {
            Options.SetTrimResults(trimFunc);
            return this;
        }

        #endregion

        #region Limit

        IFixedLengthSplitter IFixedLengthSplitter.Limit(int limit)
        {
            Options.SetLimitLength(limit);
            return this;
        }

        #endregion

        #region WithKeyValueSeparator

        IMapSplitter IFixedLengthSplitter.WithKeyValueSeparator(string separator)
        {
            Options.SetMapSeparator(separator);
            return this;
        }

        IMapSplitter IFixedLengthSplitter.WithKeyValueSeparator(char separator)
        {
            Options.SetMapSeparator(separator);
            return this;
        }

        #endregion

        #region Split - List - FixedLength

        IEnumerable<string> IFixedLengthSplitter.Split(string originalString)
            => InternalSplitToEnumerable2(originalString, s => s);

        IEnumerable<T> IFixedLengthSplitter.Split<T>(string originalString, IObjectSerializer serializer)
            => InternalSplitToEnumerable2(originalString, serializer.Deserialize<T>);

        IEnumerable<T> IFixedLengthSplitter.Split<T>(string originalString, ITypeConverter<string, T> converter)
            => InternalSplitToEnumerable2(originalString, converter.To);

        IEnumerable<T> IFixedLengthSplitter.Split<TMiddle, T>(string originalString, IObjectSerializer serializer, IObjectMapper mapper)
            => InternalSplitToEnumerable2(originalString, s => mapper.MapTo<TMiddle, T>(serializer.Deserialize<TMiddle>(s)));

        List<string> IFixedLengthSplitter.SplitToList(string originalString)
           => ((IFixedLengthSplitter)this).Split(originalString).ToList();

        List<T> IFixedLengthSplitter.SplitToList<T>(string originalString, IObjectSerializer serializer)
           => ((IFixedLengthSplitter)this).Split<T>(originalString, serializer).ToList();

        List<T> IFixedLengthSplitter.SplitToList<T>(string originalString, ITypeConverter<string, T> converter)
           => ((IFixedLengthSplitter)this).Split(originalString, converter).ToList();

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
