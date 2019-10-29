using System;
using System.Collections.Generic;
using Cosmos.Serialization;

namespace Cosmos.Splitters
{
    /// <summary>
    /// Splitter interface
    /// </summary>
    public interface ISplitter
    {
        /// <summary>
        /// Omit empty strings
        /// </summary>
        /// <returns></returns>
        ISplitter OmitEmptyStrings();

        /// <summary>
        /// Trim results
        /// </summary>
        /// <returns></returns>
        ISplitter TrimResults();

        /// <summary>
        /// Trim results
        /// </summary>
        /// <param name="trimFunc"></param>
        /// <returns></returns>
        ISplitter TrimResults(Func<string, string> trimFunc);

        /// <summary>
        /// Limit
        /// </summary>
        /// <param name="limit"></param>
        /// <returns></returns>
        ISplitter Limit(int limit);

        /// <summary>
        /// With KeyValue separator
        /// </summary>
        /// <param name="separator"></param>
        /// <returns></returns>
        IMapSplitter WithKeyValueSeparator(char separator);

        /// <summary>
        /// With KeyValue separator
        /// </summary>
        /// <param name="separator"></param>
        /// <returns></returns>
        IMapSplitter WithKeyValueSeparator(string separator);

        /// <summary>
        /// Split
        /// </summary>
        /// <param name="originalString"></param>
        /// <returns></returns>
        IEnumerable<string> Split(string originalString);

        /// <summary>
        /// Split
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalString"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        IEnumerable<T> Split<T>(string originalString, IObjectSerializer serializer);

        /// <summary>
        /// Split
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalString"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        IEnumerable<T> Split<T>(string originalString, ITypeConverter<string, T> converter);

        /// <summary>
        /// Split
        /// </summary>
        /// <typeparam name="TMiddle"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalString"></param>
        /// <param name="serializer"></param>
        /// <param name="mapper"></param>
        /// <returns></returns>
        IEnumerable<T> Split<TMiddle, T>(string originalString, IObjectSerializer serializer, IObjectMapper mapper);

        /// <summary>
        /// Split to list
        /// </summary>
        /// <param name="originalString"></param>
        /// <returns></returns>
        List<string> SplitToList(string originalString);

        /// <summary>
        /// Split to list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalString"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        List<T> SplitToList<T>(string originalString, IObjectSerializer serializer);

        /// <summary>
        /// Split to list
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalString"></param>
        /// <param name="converter"></param>
        /// <returns></returns>
        List<T> SplitToList<T>(string originalString, ITypeConverter<string, T> converter);

        /// <summary>
        /// Split to list
        /// </summary>
        /// <typeparam name="TMiddle"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="originalString"></param>
        /// <param name="serializer"></param>
        /// <param name="mapper"></param>
        /// <returns></returns>
        List<T> SplitToList<TMiddle, T>(string originalString, IObjectSerializer serializer, IObjectMapper mapper);
    }
}