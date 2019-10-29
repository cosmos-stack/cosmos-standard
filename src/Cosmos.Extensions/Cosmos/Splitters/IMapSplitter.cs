using System;
using System.Collections.Generic;
using Cosmos.Serialization;

namespace Cosmos.Splitters
{
    /// <summary>
    /// MapSplitter interface
    /// </summary>
    public interface IMapSplitter
    {
        /// <summary>
        /// Trim results
        /// </summary>
        /// <returns></returns>
        IMapSplitter TrimResults();

        /// <summary>
        /// Trim results
        /// </summary>
        /// <param name="keyTrimFunc"></param>
        /// <param name="valueTrimFunc"></param>
        /// <returns></returns>
        IMapSplitter TrimResults(Func<string, string> keyTrimFunc, Func<string, string> valueTrimFunc);

        /// <summary>
        /// Limit
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        IMapSplitter Limit(int limit);

        /// <summary>
        /// Split
        /// </summary>
        /// <param name="originalString"></param>
        /// <returns></returns>
        IEnumerable<KeyValuePair<string, string>> Split(string originalString);

        /// <summary>
        /// Split
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalString"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        IEnumerable<KeyValuePair<string, T>> Split<T>(string originalString, IObjectSerializer serializer);

        /// <summary>
        /// Split
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalString"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        IEnumerable<KeyValuePair<string, T>> Split<T>(string originalString, ITypeConverter<string, T> converter);

        /// <summary>
        /// Split
        /// </summary>
        /// <typeparam name="TMiddle"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalString"></param>
        /// <param name="serializer"></param>
        /// <param name="mapper"></param>
        /// <returns></returns>
        IEnumerable<KeyValuePair<string, T>> Split<TMiddle, T>(string originalString, IObjectSerializer serializer, IObjectMapper mapper);

        /// <summary>
        /// Split to dictionary
        /// </summary>
        /// <param name="originalString"></param>
        /// <returns></returns>
        Dictionary<string, string> SplitToDictionary(string originalString);

        /// <summary>
        /// Split to dictionary
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalString"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        Dictionary<string, T> SplitToDictionary<T>(string originalString, IObjectSerializer serializer);

        /// <summary>
        /// Split to dictionary
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalString"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        Dictionary<string, T> SplitToDictionary<T>(string originalString, ITypeConverter<string, T> converter);

        /// <summary>
        /// Split to dictionary
        /// </summary>
        /// <typeparam name="TMiddle"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalString"></param>
        /// <param name="serializer"></param>
        /// <param name="mapper"></param>
        /// <returns></returns>
        Dictionary<string, T> SplitToDictionary<TMiddle, T>(string originalString, IObjectSerializer serializer, IObjectMapper mapper);
    }
}