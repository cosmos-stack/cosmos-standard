using System;
using System.Text;

namespace Cosmos.CharMatchers
{
    /// <summary>
    /// Char matcher
    /// </summary>
    public partial class CharMatcher : IAnyOfModeCharMatcher
    {
        #region Negate
        INoneOfModeCharMatcher IAnyOfModeCharMatcher.Negate()
        {
            Options.Negate();
            return this;
        }

        #endregion

        #region InRange

        string IAnyOfModeCharMatcher.InRange(char startInclusive, char endInclusive)
        {
            var @string = Options.GetSequenceChars();
            var (min, max) = CharMatcherUtils.GetMinAndMax(startInclusive, endInclusive);
            var sb = new StringBuilder();
            foreach (var @char in @string)
                @char.IsBetween(min, max).IfTrue(() => sb.Append(@char));
            return sb.ToString();
        }

        #endregion

        #region ForPredicate

        string IAnyOfModeCharMatcher.ForPredicate(Func<char, bool> predicate)
        {
            var @string = Options.GetSequenceChars();
            var sb = new StringBuilder();
            foreach (var @char in @string)
                (predicate?.Invoke(@char) ?? false).IfTrue(() => sb.Append(@char));
            return sb.ToString();
        }

        #endregion

        #region Match

        bool IAnyOfModeCharMatcher.MatchesAnyOf(string sequence)
        {
            return SequenceUtils.MatchesAnyOf(sequence, Options);
        }

        bool IAnyOfModeCharMatcher.MatchesAllOf(string sequence)
        {
            return SequenceUtils.MatchesAllOf(sequence, Options);
        }

        bool IAnyOfModeCharMatcher.MatchesNoneOf(string sequence)
        {
            return !SequenceUtils.MatchesAnyOf(sequence, Options);
        }

        #endregion

        #region IndexIn

        int IAnyOfModeCharMatcher.IndexIn(string sequence)
        {
            return SequenceUtils.IndexIn(sequence, Options.GetSequenceChars());
        }

        int IAnyOfModeCharMatcher.IndexIn(string sequence, int startIndex)
        {
            return SequenceUtils.IndexIn(sequence, Options.GetSequenceChars(), startIndex);
        }

        int IAnyOfModeCharMatcher.LastIndexIn(string sequence)
        {
            return SequenceUtils.LastIndexIn(sequence, Options.GetSequenceChars());
        }

        #endregion

        #region CountIn

        int IAnyOfModeCharMatcher.CountIn(string sequence)
        {
            return SequenceUtils.CountIn(sequence, Options.GetSequenceChars());
        }

        #endregion

        #region Operation from

        string IAnyOfModeCharMatcher.RemoveFrom(string sequence)
        {
            return SequenceUtils.RemoveFrom(sequence, Options);
        }

        string IAnyOfModeCharMatcher.RetainFrom(string sequence)
        {
            return SequenceUtils.RemoveFrom(sequence, Options, true);
        }

        string IAnyOfModeCharMatcher.ReplaceFrom(string sequence, char replacement)
        {
            return SequenceUtils.ReplaceFrom(sequence, $"{replacement}", Options);
        }

        string IAnyOfModeCharMatcher.ReplaceFrom(string sequence, string replacement)
        {
            return SequenceUtils.ReplaceFrom(sequence, replacement, Options);
        }

        #endregion

        #region Trim

        string IAnyOfModeCharMatcher.TrimFrom(string sequence)
        {
            return SequenceUtils.TrimFrom(sequence, Options);
        }

        string IAnyOfModeCharMatcher.TrimLeadingForm(string sequence)
        {
            return SequenceUtils.TrimStartFrom(sequence, Options);
        }

        string IAnyOfModeCharMatcher.TrimTrailingFrom(string sequence)
        {
            return SequenceUtils.TrimEndFrom(sequence, Options);
        }

        #endregion

        #region Collapse

        string IAnyOfModeCharMatcher.CollapseFrom(string sequence, char replacement)
        {
            return SequenceUtils.CollapseFrom(sequence, replacement, Options);
        }

        string IAnyOfModeCharMatcher.TrimAndCollapseFrom(string sequence, char replacement)
        {
            var here = ((IAnyOfModeCharMatcher) this);
            var middle = here.TrimFrom(sequence);
            return here.CollapseFrom(middle, replacement);
        }

        #endregion

        #region Apply

        bool IAnyOfModeCharMatcher.Apply(char character)
        {
            return Options.GetSequenceChars().Contains(character);
        }

        #endregion

    }

}