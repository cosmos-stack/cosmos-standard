using System;
using System.Collections.Generic;

namespace Cosmos.Splitters {
    public interface IMapSplitter
    {
        IMapSplitter TrimResults();
        IMapSplitter TrimResults(Func<string, string> keyTrimFunc, Func<string, string> valueTrimFunc);
        IMapSplitter Limit(int limit);
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