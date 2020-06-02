using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

// ReSharper disable once CheckNamespace
namespace Cosmos.Text
{
    /// <summary>
    /// StringBuilder extensions
    /// </summary>
    public static partial class StringBuilderExtensions
    {
        /// <summary>
        /// Shortcut for adding an array of values to a StringBuilder.
        /// </summary>
        public static StringBuilder AppendAll<T>(this StringBuilder target, IEnumerable<T> values, string separator = null)
        {
            if (target is null)
                throw new NullReferenceException();

            Contract.EndContractBlock();

            if (values != null)
            {
                if (string.IsNullOrEmpty(separator))
                {
                    foreach (var value in values)
                        target.Append(value);
                }
                else
                {
                    foreach (var value in values)
                        target.AppendWithSeparator(separator, value);
                }
            }

            return target;
        }

        /// <summary>
        /// Shortcut for adding an array of values to a StringBuilder.
        /// </summary>
        public static StringBuilder AppendAll<T>(this StringBuilder target, IEnumerable<T> values, in char separator)
        {
            if (target is null)
                throw new NullReferenceException();
            Contract.EndContractBlock();

            if (values != null)
                foreach (var value in values)
                    target.AppendWithSeparator(in separator, value);

            return target;
        }

        /// <summary>
        /// Appends values to StringBuilder prefixing the provided separator.
        /// </summary>
        public static StringBuilder AppendWithSeparator<T>(this StringBuilder target, string separator, params T[] values)
        {
            if (target is null)
                throw new NullReferenceException();
            if (values is null || values.Length == 0)
                throw new ArgumentException("Parameters missing.");

            Contract.EndContractBlock();

            if (!string.IsNullOrEmpty(separator) && target.Length != 0)
                target.Append(separator);

            target.AppendAll(values);

            return target;
        }

        /// <summary>
        /// Appends values to StringBuilder prefixing the provided separator.
        /// </summary>
        public static StringBuilder AppendWithSeparator<T>(this StringBuilder target, in char separator, params T[] values)
        {
            if (target is null)
                throw new NullReferenceException();
            if (values is null || values.Length == 0)
                throw new ArgumentException("Parameters missing.");

            Contract.EndContractBlock();

            if (target.Length != 0)
                target.Append(separator);

            target.AppendAll(values);

            return target;
        }

        /// <summary>
        /// Appends a key/value pair to StringBuilder using the provided separators.
        /// </summary>
        public static void AppendWithSeparator<T>(this StringBuilder target, IDictionary<string, T> source, string key, string itemSeparator, string keyValueSeparator)
        {
            if (target is null)
                throw new NullReferenceException();
            if (source is null)
                throw new ArgumentNullException(nameof(source));
            if (key is null)
                throw new ArgumentNullException(nameof(key));
            if (itemSeparator is null)
                throw new ArgumentNullException(nameof(itemSeparator));
            if (keyValueSeparator is null)
                throw new ArgumentNullException(nameof(keyValueSeparator));

            Contract.EndContractBlock();

            if (source.TryGetValue(key, out var result))
                target
                   .AppendWithSeparator(itemSeparator, key)
                   .Append(keyValueSeparator)
                   .Append(result);
        }
    }
}