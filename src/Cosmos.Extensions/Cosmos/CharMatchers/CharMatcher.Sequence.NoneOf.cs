using System;
using System.Text;

namespace Cosmos.CharMatchers
{
    public partial class CharMatcher : INoneOfModeCharMatcher
    {
        #region Negate

        IAnyOfModeCharMatcher INoneOfModeCharMatcher.Negate()
        {
            Options.Negate();
            return this;
        }

        #endregion

        #region InRange

        string INoneOfModeCharMatcher.InRange(char startInclusive, char endInclusive)
        {
            var @string = Options.GetSequenceChars();
            var (min, max) = CharMatcherUtils.GetMinAndMax(startInclusive, endInclusive);
            var sb = new StringBuilder();
            foreach (var @char in @string)
                @char.IsBetween(min, max).IfFalse(() => sb.Append(@char));
            return sb.ToString();
        }

        #endregion

        #region ForPredicate

        string INoneOfModeCharMatcher.ForPredicate(Func<char, bool> predicate)
        {
            var @string = Options.GetSequenceChars();
            var sb = new StringBuilder();
            foreach (var @char in @string)
                (predicate?.Invoke(@char) ?? false).IfFalse(() => sb.Append(@char));
            return sb.ToString();
        }

        #endregion

        #region Match

        bool INoneOfModeCharMatcher.MatchesAnyOf(string sequence)
        {
            return !SequenceUtils.MatchesAnyOf(sequence, Options);
        }

        bool INoneOfModeCharMatcher.MatchesAllOf(string sequence)
        {
            return !SequenceUtils.MatchesAllOf(sequence, Options);
        }

        bool INoneOfModeCharMatcher.MatchesNoneOf(string sequence)
        {
            return SequenceUtils.MatchesAnyOf(sequence, Options);
        }

        #endregion

        #region IndexIn

        int INoneOfModeCharMatcher.IndexIn(string sequence)
        {
            return SequenceUtils.IndexIn(sequence, Options.GetSequenceChars());
        }

        int INoneOfModeCharMatcher.IndexIn(string sequence, int startIndex)
        {
            return SequenceUtils.IndexIn(sequence, Options.GetSequenceChars(), startIndex);
        }

        int INoneOfModeCharMatcher.LastIndexIn(string sequence)
        {
            return SequenceUtils.LastIndexIn(sequence, Options.GetSequenceChars());
        }

        #endregion

        #region CountIn

        int INoneOfModeCharMatcher.CountIn(string sequence)
        {
            return SequenceUtils.CountIn(sequence, Options.GetSequenceChars());
        }

        #endregion

        #region Operation from

        string INoneOfModeCharMatcher.RemoveFrom(string sequence)
        {
            return SequenceUtils.RemoveFrom(sequence, Options);
        }

        string INoneOfModeCharMatcher.RetainFrom(string sequence)
        {
            return SequenceUtils.RemoveFrom(sequence, Options, true);
        }

        string INoneOfModeCharMatcher.ReplaceFrom(string sequence, char replacement)
        {
            return SequenceUtils.ReplaceFrom(sequence, $"{replacement}", Options);
        }

        string INoneOfModeCharMatcher.ReplaceFrom(string sequence, string replacement)
        {
            return SequenceUtils.ReplaceFrom(sequence, replacement, Options);
        }

        #endregion

        #region Trim

        string INoneOfModeCharMatcher.TrimFrom(string sequence)
        {
            return SequenceUtils.TrimFrom(sequence, Options);
        }

        string INoneOfModeCharMatcher.TrimLeadingForm(string sequence)
        {
            return SequenceUtils.TrimStartFrom(sequence, Options);
        }

        string INoneOfModeCharMatcher.TrimTrailingFrom(string sequence)
        {
            return SequenceUtils.TrimEndFrom(sequence, Options);
        }

        #endregion

        #region Collapse

        string INoneOfModeCharMatcher.CollapseFrom(string sequence, char replacement)
        {
            return SequenceUtils.CollapseFrom(sequence, replacement, Options);
        }

        string INoneOfModeCharMatcher.TrimAndCollapseFrom(string sequence, char replacement)
        {
            var here = ((INoneOfModeCharMatcher) this);
            var middle = here.TrimFrom(sequence);
            return here.CollapseFrom(middle, replacement);
        }

        #endregion

        #region Apply

        bool INoneOfModeCharMatcher.Apply(char character)
        {
            return !Options.GetSequenceChars().Contains(character);
        }

        #endregion

    }

}