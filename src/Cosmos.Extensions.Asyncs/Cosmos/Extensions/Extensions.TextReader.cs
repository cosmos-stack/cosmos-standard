using System;
using System.Collections.Generic;
using System.IO;

// ReSharper disable once CheckNamespace
namespace Cosmos.Asynchronous {
    /// <summary>
    /// TextReader Extensions
    /// </summary>
    public static partial class TextReaderExtensions {
        /// <summary>
        /// Get enumerable
        /// </summary>
        /// <param name="textReader"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<string> GetEnumerable(this TextReader textReader) {
            if (textReader == null)
                throw new ArgumentNullException(nameof(textReader));

            string line;

            while ((line = textReader.ReadLine()) != null)
                yield return line;
        }
    }
}