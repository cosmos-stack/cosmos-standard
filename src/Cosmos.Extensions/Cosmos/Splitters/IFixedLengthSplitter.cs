using System;
using System.Collections.Generic;

namespace Cosmos.Splitters {
    public interface IFixedLengthSplitter
    {
        IFixedLengthSplitter TrimResults();
        IFixedLengthSplitter TrimResults(Func<string, string> trimFunc);
        IFixedLengthSplitter Limit(int limit);
        IMapSplitter WithKeyValueSeparator(char separator);
        IMapSplitter WithKeyValueSeparator(string separator);
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