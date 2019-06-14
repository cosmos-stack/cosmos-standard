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
    /// <summary>
    /// Regex verbal expressions
    /// </summary>
    public class RegexVerbalExpressions
    {
        /// <summary>
        /// Returns a default instance of RegexVerbalExpressions
        /// having the Multiline option enabled
        /// </summary>
        public static RegexVerbalExpressions DefaultExpression => new RegexVerbalExpressions();

        // ReSharper disable once InconsistentNaming
        private readonly RegexCache regexCache = new RegexCache();

        // ReSharper disable FieldCanBeMadeReadOnly.Local
        private StringBuilder _prefixes = new StringBuilder(), _source = new StringBuilder(), _suffixes = new StringBuilder();

        private RegexOptions _modifiers = RegexOptions.Multiline;

        private string RegexString => new StringBuilder().Append(_prefixes).Append(_source).Append(_suffixes).ToString();

        private Regex PatternRegex => regexCache.Get(RegexString, _modifiers);

        #region Expression Modifiers

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="regexTypes"></param>
        /// <returns></returns>
        public RegexVerbalExpressions Add(RegexTypes regexTypes) => Add(regexTypes.Name, false);

        /// <summary>
        /// Add
        /// </summary>
        /// <param name="value"></param>
        /// <param name="sanitize"></param>
        /// <returns></returns>
        public RegexVerbalExpressions Add(string value, bool sanitize = true)
        {
            if (value == null)
                throw new ArgumentNullException(nameof(value), "value must be provided");
            _source.Append(sanitize ? Sanitize(value) : value);
            return this;
        }

        /// <summary>
        /// Start of line
        /// </summary>
        /// <param name="enable"></param>
        /// <returns></returns>
        public RegexVerbalExpressions StartOfLine(bool enable = true)
        {
            _prefixes.Append(enable ? "^" : string.Empty);
            return this;
        }

        /// <summary>
        /// End of line
        /// </summary>
        /// <param name="enable"></param>
        /// <returns></returns>
        public RegexVerbalExpressions EndOfLine(bool enable = true)
        {
            _suffixes.Append(enable ? "$" : string.Empty);
            return this;
        }

        /// <summary>
        /// Then
        /// </summary>
        /// <param name="value"></param>
        /// <param name="sanitize"></param>
        /// <returns></returns>
        public RegexVerbalExpressions Then(string value, bool sanitize = true) => Add($"({(sanitize ? Sanitize(value) : value)})", false);

        /// <summary>
        /// Then
        /// </summary>
        /// <param name="regexTypes"></param>
        /// <returns></returns>
        public RegexVerbalExpressions Then(RegexTypes regexTypes) => Then(regexTypes.Name, false);

        /// <summary>
        /// Find
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public RegexVerbalExpressions Find(string value) => Then(value);

        /// <summary>
        /// Maybe
        /// </summary>
        /// <param name="value"></param>
        /// <param name="sanitize"></param>
        /// <returns></returns>
        public RegexVerbalExpressions Maybe(string value, bool sanitize = true) => Add($"({(sanitize ? Sanitize(value) : value)})?", false);

        /// <summary>
        /// Maybe
        /// </summary>
        /// <param name="regexTypes"></param>
        /// <returns></returns>
        public RegexVerbalExpressions Maybe(RegexTypes regexTypes) => Maybe(regexTypes.Name, sanitize: false);

        /// <summary>
        /// Anything
        /// </summary>
        /// <returns></returns>
        public RegexVerbalExpressions Anything() => Add("(.*)", false);

        /// <summary>
        /// Anything but...
        /// </summary>
        /// <param name="value"></param>
        /// <param name="sanitize"></param>
        /// <returns></returns>
        public RegexVerbalExpressions AnythingBut(string value, bool sanitize = true) => Add($"([^{(sanitize ? Sanitize(value) : value)}]*)", false);

        /// <summary>
        /// Something
        /// </summary>
        /// <returns></returns>
        public RegexVerbalExpressions Something() => Add("(.+)", false);

        /// <summary>
        /// Something but...
        /// </summary>
        /// <param name="value"></param>
        /// <param name="sanitize"></param>
        /// <returns></returns>
        public RegexVerbalExpressions SomethingBut(string value, bool sanitize = true) => Add($"([^{(sanitize ? Sanitize(value) : value)}]+)", false);

        /// <summary>
        /// Replace
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public RegexVerbalExpressions Replace(string value)
        {
            var whereToReplace = PatternRegex.ToString();
            if (whereToReplace.Length != 0)
                _source.Replace(whereToReplace, value);
            return this;
        }

        /// <summary>
        /// Line break
        /// </summary>
        /// <returns></returns>
        public RegexVerbalExpressions LineBreak() => Add(@"(\n|(\r\n))", false);

        /// <summary>
        /// Br
        /// </summary>
        /// <returns></returns>
        public RegexVerbalExpressions Br() => LineBreak();

        /// <summary>
        /// Tab
        /// </summary>
        /// <returns></returns>
        public RegexVerbalExpressions Tab() => Add(@"\t");

        /// <summary>
        /// Word
        /// </summary>
        /// <returns></returns>
        public RegexVerbalExpressions Word() => Add(@"\w+", false);

        /// <summary>
        /// Any of
        /// </summary>
        /// <param name="value"></param>
        /// <param name="sanitize"></param>
        /// <returns></returns>
        public RegexVerbalExpressions AnyOf(string value, bool sanitize = true)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            return Add($"[{(sanitize ? Sanitize(value) : value)}]", false);
        }

        /// <summary>
        /// Any
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public RegexVerbalExpressions Any(string value) => AnyOf(value);

        /// <summary>
        /// Range
        /// </summary>
        /// <param name="arguments"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Multiple
        /// </summary>
        /// <param name="value"></param>
        /// <param name="sanitize"></param>
        /// <returns></returns>
        public RegexVerbalExpressions Multiple(string value, bool sanitize = true)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            return Add($@"({(sanitize ? Sanitize(value) : value)})+", false);
        }

        /// <summary>
        /// Or
        /// </summary>
        /// <param name="regexTypes"></param>
        /// <returns></returns>
        public RegexVerbalExpressions Or(RegexTypes regexTypes) => Or(regexTypes.Name, false);

        /// <summary>
        /// Or
        /// </summary>
        /// <param name="value"></param>
        /// <param name="sanitize"></param>
        /// <returns></returns>
        public RegexVerbalExpressions Or(string value, bool sanitize = true)
        {
            _prefixes.Append("(");
            _suffixes.Insert(0, ")");
            _source.Append(")|(");
            return Add(value, sanitize);
        }

        /// <summary>
        /// Begin capture
        /// </summary>
        /// <returns></returns>
        public RegexVerbalExpressions BeginCapture() => Add("(", false);

        /// <summary>
        /// Begin capture
        /// </summary>
        /// <param name="groupName"></param>
        /// <returns></returns>
        // ReSharper disable once RedundantArgumentDefaultValue
        public RegexVerbalExpressions BeginCapture(string groupName) => Add("(?<", false).Add(groupName, true).Add(">", false);

        /// <summary>
        /// End capture
        /// </summary>
        /// <returns></returns>
        public RegexVerbalExpressions EndCapture() => Add(")", false);

        /// <summary>
        /// Repeat previous
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        public RegexVerbalExpressions RepeatPrevious(int n) => Add("{" + n + "}", false);

        /// <summary>
        /// Repeat previous
        /// </summary>
        /// <param name="n"></param>
        /// <param name="m"></param>
        /// <returns></returns>
        public RegexVerbalExpressions RepeatPrevious(int n, int m) => Add("{" + n + "," + m + "}", false);

        #endregion Expression Modifiers

        #region Expression Options Modifiers

        /// <summary>
        /// Add modifier
        /// </summary>
        /// <param name="modifier"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Remove modifier
        /// </summary>
        /// <param name="modifier"></param>
        /// <returns></returns>
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

        /// <summary>
        /// With any case
        /// </summary>
        /// <param name="enable"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Use one lne search option
        /// </summary>
        /// <param name="enable"></param>
        /// <returns></returns>
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

        /// <summary>
        /// With options
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public RegexVerbalExpressions WithOptions(RegexOptions options)
        {
            _modifiers = options;
            return this;
        }

        #endregion Expression Options Modifiers

        #region Helpers

        /// <summary>
        /// Sanitize
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public string Sanitize(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));
            return Regex.Escape(value);
        }

        /// <summary>
        /// Test
        /// </summary>
        /// <param name="toTest"></param>
        /// <returns></returns>
        public bool Test(string toTest) => IsMatch(toTest);

        /// <summary>
        /// Is match
        /// </summary>
        /// <param name="toTest"></param>
        /// <returns></returns>
        public bool IsMatch(string toTest) => PatternRegex.IsMatch(toTest);

        /// <summary>
        /// To regex
        /// </summary>
        /// <returns></returns>
        public Regex ToRegex() => PatternRegex;

        /// <summary>
        /// To string
        /// </summary>
        /// <returns></returns>
        public override string ToString() => PatternRegex.ToString();

        /// <summary>
        /// Capture
        /// </summary>
        /// <param name="toTest"></param>
        /// <param name="groupName"></param>
        /// <returns></returns>
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
