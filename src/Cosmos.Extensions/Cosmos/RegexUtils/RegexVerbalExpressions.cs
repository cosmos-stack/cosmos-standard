/*!
 * CSharpVerbalExpressions v0.1
 * https://github.com/VerbalExpressions/CSharpVerbalExpressions
 * 
 * @psoholt
 * 
 * Date: 2013-07-26
 * 
 * Additions and Refactoring
 * @alexpeta
 * 
 * Date: 2013-08-06
 */

using System;
using System.Text;
using System.Linq;
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

namespace Cosmos.RegexUtils
{
    public class RegexVerbalExpressions
    {
        /// <summary>
        /// Returns a default instance of RegexVerbalExpressions
        /// having the Multiline option enabled
        /// </summary>
        public static RegexVerbalExpressions DefaultExpression => new RegexVerbalExpressions();

        private readonly RegexCache regexCache = new RegexCache();

        private StringBuilder _prefixes = new StringBuilder(), _source = new StringBuilder(), _suffixes = new StringBuilder();

        private RegexOptions _modifiers = RegexOptions.Multiline;

        private string RegexString => new StringBuilder().Append(_prefixes).Append(_source).Append(_suffixes).ToString();

        private Regex PatternRegex => regexCache.Get(this.RegexString, _modifiers);

        #region Expression Modifiers

        public RegexVerbalExpressions Add(RegexTypes regexTypes) => Add(regexTypes.Name, false);

        public RegexVerbalExpressions Add(string value, bool sanitize = true)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value), "value must be provided");
            _source.Append(sanitize ? Sanitize(value) : value);
            return this;
        }

        public RegexVerbalExpressions StartOfLine(bool enable = true)
        {
            _prefixes.Append(enable ? "^" : string.Empty);
            return this;
        }

        public RegexVerbalExpressions EndOfLine(bool enable = true)
        {
            _suffixes.Append(enable ? "$" : string.Empty);
            return this;
        }

        public RegexVerbalExpressions Then(string value, bool sanitize = true) => Add($"({(sanitize ? Sanitize(value) : value)})", false);

        public RegexVerbalExpressions Then(RegexTypes regexTypes) => Then(regexTypes.Name, false);

        public RegexVerbalExpressions Find(string value) => Then(value);

        public RegexVerbalExpressions Maybe(string value, bool sanitize = true) => Add($"({(sanitize ? Sanitize(value) : value)})?", false);

        public RegexVerbalExpressions Maybe(RegexTypes regexTypes) => Maybe(regexTypes.Name, sanitize: false);

        public RegexVerbalExpressions Anything() => Add("(.*)", false);

        public RegexVerbalExpressions AnythingBut(string value, bool sanitize = true) => Add($"([^{(sanitize ? Sanitize(value) : value)}]*)", false);

        public RegexVerbalExpressions Something() => Add("(.+)", false);

        public RegexVerbalExpressions SomethingBut(string value, bool sanitize = true) => Add($"([^{(sanitize ? Sanitize(value) : value)}]+)", false);

        public RegexVerbalExpressions Replace(string value)
        {
            var whereToReplace = PatternRegex.ToString();
            if (whereToReplace.Length != 0)
                _source.Replace(whereToReplace, value);
            return this;
        }

        public RegexVerbalExpressions LineBreak() => Add(@"(\n|(\r\n))", false);

        public RegexVerbalExpressions Br() => LineBreak();

        public RegexVerbalExpressions Tab() => Add(@"\t");

        public RegexVerbalExpressions Word() => Add(@"\w+", false);

        public RegexVerbalExpressions AnyOf(string value, bool sanitize = true)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            return Add($"[{(sanitize ? Sanitize(value) : value)}]", false);
        }

        public RegexVerbalExpressions Any(string value) => AnyOf(value);

        public RegexVerbalExpressions Range(params object[] arguments)
        {
            if (arguments is null)
                throw new ArgumentNullException(nameof(arguments));

            if (arguments.Length == 1)
                throw new ArgumentOutOfRangeException(nameof(arguments));

            var sanitizedStrings = arguments.Select(argument =>
                {
                    if (argument is null)
                        return string.Empty;
                    var castRet = argument.ToString();
                    return string.IsNullOrEmpty(castRet) ? string.Empty : Sanitize(castRet);
                })
                .Where(sanitizedString => !string.IsNullOrEmpty(sanitizedString))
                .OrderBy(s => s)
                .ToArray();

            if (sanitizedStrings.Length > 3)
                throw new ArgumentOutOfRangeException(nameof(arguments));

            if (!sanitizedStrings.Any())
                return this;

            var hasOddNumberOfParams = (sanitizedStrings.Length % 2) > 0;

            var sb = new StringBuilder("[");
            for (var from = 0; from < sanitizedStrings.Length; from += 2)
            {
                var to = from + 1;
                if (sanitizedStrings.Length <= to)
                    break;
                sb.AppendFormat("{0}-{1}", sanitizedStrings[from], sanitizedStrings[to]);
            }
            sb.Append("]");

            if (hasOddNumberOfParams)
                sb.AppendFormat("|{0}", sanitizedStrings.Last());

            return Add(sb.ToString(), false);
        }

        public RegexVerbalExpressions Multiple(string value, bool sanitize = true)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            return Add($@"({(sanitize ? Sanitize(value) : value)})+", false);
        }

        public RegexVerbalExpressions Or(RegexTypes regexTypes) => Or(regexTypes.Name, false);

        public RegexVerbalExpressions Or(string value, bool sanitize = true)
        {
            _prefixes.Append("(");
            _suffixes.Insert(0, ")");
            _source.Append(")|(");
            return Add(value, sanitize);
        }

        public RegexVerbalExpressions BeginCapture() => Add("(", false);

        public RegexVerbalExpressions BeginCapture(string groupName) => Add("(?<", false).Add(groupName, true).Add(">", false);

        public RegexVerbalExpressions EndCapture() => Add(")", false);

        public RegexVerbalExpressions RepeatPrevious(int n) => Add("{" + n + "}", false);

        public RegexVerbalExpressions RepeatPrevious(int n, int m) => Add("{" + n + "," + m + "}", false);

        #endregion Expression Modifiers

        #region Expression Options Modifiers

        public RegexVerbalExpressions AddModifier(char modifier)
        {
            switch (modifier)
            {
                case 'i':
                    _modifiers |= RegexOptions.IgnoreCase;
                    break;
                case 'x':
                    _modifiers |= RegexOptions.IgnorePatternWhitespace;
                    break;
                case 'm':
                    _modifiers |= RegexOptions.Multiline;
                    break;
                case 's':
                    _modifiers |= RegexOptions.Singleline;
                    break;
            }

            return this;
        }

        public RegexVerbalExpressions RemoveModifier(char modifier)
        {
            switch (modifier)
            {
                case 'i':
                    _modifiers &= ~RegexOptions.IgnoreCase;
                    break;
                case 'x':
                    _modifiers &= ~RegexOptions.IgnorePatternWhitespace;
                    break;
                case 'm':
                    _modifiers &= ~RegexOptions.Multiline;
                    break;
                case 's':
                    _modifiers &= ~RegexOptions.Singleline;
                    break;
            }

            return this;
        }

        public RegexVerbalExpressions WithAnyCase(bool enable = true)
        {
            if (enable)
            {
                AddModifier('i');
            }
            else
            {
                RemoveModifier('i');
            }
            return this;
        }

        public RegexVerbalExpressions UseOneLineSearchOption(bool enable)
        {
            if (enable)
            {
                RemoveModifier('m');
            }
            else
            {
                AddModifier('m');
            }

            return this;
        }

        public RegexVerbalExpressions WithOptions(RegexOptions options)
        {
            _modifiers = options;
            return this;
        }

        #endregion Expression Options Modifiers

        #region Helpers

        public string Sanitize(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            return Regex.Escape(value);
        }

        public bool Test(string toTest) => IsMatch(toTest);

        public bool IsMatch(string toTest) => PatternRegex.IsMatch(toTest);

        public Regex ToRegex() => PatternRegex;

        public override string ToString() => PatternRegex.ToString();

        public string Capture(string toTest, string groupName)
        {
            if (!Test(toTest))
                return null;

            var match = PatternRegex.Match(toTest);

            return match.Groups[groupName].Value;
        }

        #endregion Helpers
    }
}
