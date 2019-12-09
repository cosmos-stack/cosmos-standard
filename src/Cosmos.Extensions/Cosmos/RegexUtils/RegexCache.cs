/*!
 * CSharpVerbalExpressions v0.1
 * https://github.com/VerbalExpressions/CSharpVerbalExpressions
 */

using System;
using System.Text.RegularExpressions;

/*
 * Reference to:
 *      VerbalExpressions/CSharpVerbalExpressions
 *      Author: VerbalExpressions Team
 *      URL: https://github.com/VerbalExpressions/CSharpVerbalExpressions
 *      MIT
 * 
 * Changed and updated by Alex Lewis
 */

namespace Cosmos.RegexUtils {
    /// <summary>
    /// Regex cache
    /// </summary>
    public sealed class RegexCache {
        private bool _hasValue;
        private Key _key;
        private Regex _regex;

        private class Key {
            public Key(string pattern, RegexOptions options) {
                Pattern = pattern;
                Options = options;
            }

            private string Pattern { get; }

            private RegexOptions Options { get; }

            public override bool Equals(object obj) {
                return obj is Key key &&
                       key.Pattern == Pattern &&
                       key.Options == Options;
            }

            public override int GetHashCode() {
                return Pattern.GetHashCode() ^ Options.GetHashCode();
            }
        }

        /// <summary>
        /// Gets the already cached value for a key, or calculates the value and stores it.
        /// </summary>
        /// <param name="pattern">The pattern used to create the regular expression.</param>
        /// <param name="options">The options for regex.</param>
        /// <returns>The calculated or cached value.</returns>
        public Regex Get(string pattern, RegexOptions options) {
            if (pattern == null)
                throw new ArgumentNullException(nameof(pattern));

            lock (this) {
                var current = new Key(pattern, options);
                if (_hasValue && current.Equals(_key)) {
                    return _regex;
                }

                _regex = new Regex(pattern, options);
                _key = current;
                _hasValue = true;

                return _regex;
            }
        }
    }
}