using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

// ReSharper disable InconsistentNaming

namespace Cosmos.Guava
{
    public partial class Splitter : IGuavaSplitter
    {
        private readonly bool _regexMode;
        private readonly bool _fixedLengthMode;
        private readonly string[] _on;
        private readonly string _pattern;
        private readonly Regex _regexPattern;
        private readonly int _fixedLengthPattern;

        private SplitterOptions Options { get; set; } = new SplitterOptions();

        private Splitter(string[] on)
        {
            _on = on;
            _pattern = string.Empty;
            _regexPattern = null;
            _regexMode = false;
            _fixedLengthPattern = 0;
            _fixedLengthMode = false;
        }

        private Splitter(string pattern)
        {
            _on = new string[0];
            _pattern = pattern;
            _regexPattern = null;
            _regexMode = true;
            _fixedLengthPattern = 0;
            _fixedLengthMode = false;
        }

        private Splitter(Regex regexPattern)
        {
            _on = new string[0];
            _pattern = string.Empty;
            _regexPattern = regexPattern;
            _regexMode = true;
            _fixedLengthPattern = 0;
            _fixedLengthMode = false;
        }

        private Splitter(int fixedLength)
        {
            _on = new string[0];
            _pattern = string.Empty;
            _regexPattern = null;
            _regexMode = false;
            _fixedLengthPattern = fixedLength;
            _fixedLengthMode = true;
        }

        #region OmitEmptyStrings

        public IGuavaSplitter OmitEmptyStrings()
        {
            Options.SetOmitEmptyStrings();
            return this;
        }

        #endregion

        #region WithKeyValueSeparator

        IGuavaMapSplitter IGuavaSplitter.WithKeyValueSeparator(string separator)
        {
            Options.SetMapSeparator(separator);
            return this;
        }
        IGuavaMapSplitter IGuavaSplitter.WithKeyValueSeparator(char separator)
        {
            Options.SetMapSeparator(separator);
            return this;
        }

        #endregion

        #region TrimResults

        IGuavaSplitter IGuavaSplitter.TrimResults()
        {
            Options.SetTrimResults();
            return this;
        }

        IGuavaSplitter IGuavaSplitter.TrimResults(Func<string, string> trimFunc)
        {
            Options.SetTrimResults(trimFunc);
            return this;
        }

        #endregion

        #region Limit

        IGuavaSplitter IGuavaSplitter.Limit(int limit)
        {
            Options.SetLimitLength(limit);
            return this;
        }

        #endregion

        #region Split - List

        private bool _doesUseInLimitedMode() => Options.LimitLength >= 0 && (!_regexMode || (_regexMode && _regexPattern == null));

        IEnumerable<string> IGuavaSplitter.Split(string originalString)
            => InternalSplitToEnumerable(originalString, s => s);

        IEnumerable<T> IGuavaSplitter.Split<T>(string originalString, IObjectSerializer serializer)
            => InternalSplitToEnumerable(originalString, serializer.Deserialize<T>);

        IEnumerable<T> IGuavaSplitter.Split<T>(string originalString, ITypeConverter<string, T> converter)
            => InternalSplitToEnumerable(originalString, converter.To);

        IEnumerable<T> IGuavaSplitter.Split<TMiddle, T>(string originalString, IObjectSerializer serializer, IObjectMapper mapper)
            => InternalSplitToEnumerable(originalString, s => mapper.MapTo<TMiddle, T>(serializer.Deserialize<TMiddle>(s)));

        List<string> IGuavaSplitter.SplitToList(string originalString)
           => ((IGuavaSplitter)this).Split(originalString).ToList();

        List<T> IGuavaSplitter.SplitToList<T>(string originalString, IObjectSerializer serializer)
           => ((IGuavaSplitter)this).Split<T>(originalString, serializer).ToList();

        List<T> IGuavaSplitter.SplitToList<T>(string originalString, ITypeConverter<string, T> converter)
           => ((IGuavaSplitter)this).Split(originalString, converter).ToList();

        List<T> IGuavaSplitter.SplitToList<TMiddle, T>(string originalString, IObjectSerializer serializer, IObjectMapper mapper)
           => ((IGuavaSplitter)this).Split<TMiddle, T>(originalString, serializer, mapper).ToList();

        private IEnumerable<TValue> InternalSplitToEnumerable<TValue>(string originalString, Func<string, TValue> to)
        {
            if (string.IsNullOrWhiteSpace(originalString))
                return Enumerable.Empty<TValue>();

            var result = new List<string>();
            var middle = _regexMode
                ? SplitterUtils.SplitPatternList(Options, originalString, _pattern, _regexPattern)
                : SplitterUtils.SplitList(Options, originalString, _on);

            if (_doesUseInLimitedMode())
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

        #region On

        public static IGuavaSplitter On(string on, params string[] on2)
        {
            var o = new string[(on2?.Length ?? 0) + 1];
            o[0] = on;
            if (o.Length > 1 && on2 != null && on2.Length > 0)
                Array.Copy(on2, 0, o, 1, on2.Length);
            return new Splitter(o);
        }

        public static IGuavaSplitter On(Regex pattern)
        {
            return new Splitter(pattern);
        }

        public static IGuavaSplitter OnPattern(string separatorPattern)
        {
            return new Splitter(separatorPattern);
        }

        #endregion

        #region FixedLength

        public static IGuavaFixedLengthSplitter FixedLength(int length)
        {
            if (length <= 0)
                throw new ArgumentOutOfRangeException(nameof(length), length, "The fixedLength must be greater than zero.");
            return new Splitter(length);
        }

        #endregion

        #region Private class

        private partial class SplitterOptions
        {

            #region OmitEmptyStrings

            private bool OmitEmptyStrings { get; set; }

            public void SetOmitEmptyStrings()
            {
                OmitEmptyStrings = true;
            }

            public StringSplitOptions GetStringSplitOptions() => OmitEmptyStrings ? StringSplitOptions.RemoveEmptyEntries : StringSplitOptions.None;

            #endregion

            #region Limit

            public int LimitLength { get; private set; } = -1;

            public void SetLimitLength(int limit)
            {
                if (limit <= 0)
                    LimitLength = -1;
                else
                    LimitLength = limit;
            }

            #endregion

            #region TrimResults

            public bool TrimResultsFlag { get; private set; }

            public Func<string, string> TrimFunc { get; private set; }

            public void SetTrimResults()
            {
                TrimResultsFlag = true;
                TrimFunc = s => s.Trim();
            }

            public void SetTrimResults(Func<string, string> func)
            {
                TrimResultsFlag = true;
                TrimFunc = func ?? (s => s.Trim());
            }

            #endregion

        }

        private static partial class SplitterUtils
        {
            public static IEnumerable<string> OptionalRange(SplitterOptions options, string[] middleStrings)
            {
                return options.TrimResultsFlag ? middleStrings.Select(options.TrimFunc) : middleStrings;
            }

            public static string[] SplitList(SplitterOptions options, string originalString, string[] on)
            {
                return originalString.Split(on, options.GetStringSplitOptions());
            }

            public static string[] SplitPatternList(SplitterOptions options, string originalString, string stringPattern, Regex regexPattern)
            {
                return regexPattern == null
                    ? Regex.Split(originalString, stringPattern)
                    : options.LimitLength > 0
                        ? regexPattern.Split(originalString, options.LimitLength)
                        : regexPattern.Split(originalString);
            }
        }

        #endregion
    }

    public interface IGuavaSplitter
    {
        IGuavaSplitter OmitEmptyStrings();
        IGuavaSplitter TrimResults();
        IGuavaSplitter TrimResults(Func<string, string> trimFunc);
        IGuavaSplitter Limit(int limit);
        IGuavaMapSplitter WithKeyValueSeparator(char separator);
        IGuavaMapSplitter WithKeyValueSeparator(string separator);
        IEnumerable<string> Split(string originalString);
        IEnumerable<T> Split<T>(string originalString, IObjectSerializer serializer);
        IEnumerable<T> Split<T>(string originalString, ITypeConverter<string, T> converter);
        IEnumerable<T> Split<TMiddle, T>(string originalString, IObjectSerializer serializer, IObjectMapper mapper);
        List<string> SplitToList(string originalString);
        List<T> SplitToList<T>(string originalString, IObjectSerializer serializer);
        List<T> SplitToList<T>(string originalString, ITypeConverter<string, T> converter);
        List<T> SplitToList<TMiddle, T>(string originalString, IObjectSerializer serializer, IObjectMapper mapper);
    }
}
