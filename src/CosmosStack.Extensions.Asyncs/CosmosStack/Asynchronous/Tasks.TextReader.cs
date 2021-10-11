using System;
using System.Collections.Generic;
using System.IO;

namespace CosmosStack.Asynchronous
{
    /// <summary>
    /// TextReader Extensions
    /// </summary>
    public static partial class TaskExtensions
    {
        /// <summary>
        /// Get enumerable
        /// </summary>
        /// <param name="textReader"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<string> GetEnumerable(this TextReader textReader)
        {
            if (textReader is null)
                throw new ArgumentNullException(nameof(textReader));

            string line;

            while ((line = textReader.ReadLine()) != null)
                yield return line;
        }
    }
}