using System;

namespace Cosmos.CharMatchers
{
    public partial class CharMatcher : IIsNotModeCharMatcher
    {
        #region Negate

        IIsModeCharMatcher IIsNotModeCharMatcher.Negate()
        {
            Options.Negate();
            return this;
        }

        #endregion

        #region InRange

        string IIsNotModeCharMatcher.InRange(char startInclusive, char endInclusive)
        {
            var @char = Options.GetSingleChar();
            var (min, max) = CharMatcherUtils.GetMinAndMax(startInclusive, endInclusive);
            return @char.IsBetween(min, max).Ifttt(
                () => string.Empty,
                () => $"{@char}");
        }

        #endregion

        #region ForPredicate

        string IIsNotModeCharMatcher.ForPredicate(Func<char, bool> predicate)
        {
            var @char = Options.GetSingleChar();
            return (predicate?.Invoke(@char) ?? false).Ifttt(
                () => string.Empty,
                () => $"{@char}");
        }

        #endregion

        #region Match

        bool IIsNotModeCharMatcher.MatchesAnyOf(string sequence)
        {
            return !SingleUtils.MatchesAnyOf(sequence, Options);
        }

        bool IIsNotModeCharMatcher.MatchesAllOf(string sequence)
        {
            return !SingleUtils.MatchesAllOf(sequence, Options);
        }

        bool IIsNotModeCharMatcher.MatchesNoneOf(string sequence)
        {
            return SingleUtils.MatchesAnyOf(sequence, Options);
        }

        #endregion

        #region IndexIn

        int IIsNotModeCharMatcher.IndexIn(string sequence)
        {
            return SingleUtils.IndexIn(sequence, Options.GetSingleChar());
        }

        int IIsNotModeCharMatcher.IndexIn(string sequence, int startIndex)
        {
            return SingleUtils.IndexIn(sequence, Options.GetSingleChar(), startIndex);
        }

        int IIsNotModeCharMatcher.LastIndexIn(string sequence)
        {
            return SingleUtils.LastIndexIn(sequence, Options.GetSingleChar());
        }

        #endregion

        #region CountIn

        int IIsNotModeCharMatcher.CountIn(string sequence)
        {
            return SingleUtils.CountIn(sequence, Options.GetSingleChar());
        }

        #endregion

        #region Operation from

        string IIsNotModeCharMatcher.RemoveFrom(string sequence)
        {
            return SingleUtils.RemoveFrom(sequence, Options);
        }

        string IIsNotModeCharMatcher.RetainFrom(string sequence)
        {
            return SingleUtils.RemoveFrom(sequence, Options, true);
        }

        string IIsNotModeCharMatcher.ReplaceFrom(string sequence, char replacement)
        {
            return SingleUtils.ReplaceFrom(sequence, $"{replacement}", Options);
        }

        string IIsNotModeCharMatcher.ReplaceFrom(string sequence, string replacement)
        {
            return SingleUtils.ReplaceFrom(sequence, replacement, Options);
        }

        #endregion

        #region Trim

        string IIsNotModeCharMatcher.TrimFrom(string sequence)
        {
            return SingleUtils.TrimFrom(sequence, Options);
        }


        string IIsNotModeCharMatcher.TrimLeadingForm(string sequence)
        {
            return SingleUtils.TrimStartFrom(sequence, Options);
        }

        string IIsNotModeCharMatcher.TrimTrailingFrom(string sequence)
        {
            return SingleUtils.TrimEndFrom(sequence, Options);
        }

        #endregion

        #region Collapse

        string IIsNotModeCharMatcher.CollapseFrom(string sequence, char replacement)
        {
            return SingleUtils.CollapseFrom(sequence, replacement, Options);
        }

        string IIsNotModeCharMatcher.TrimAndCollapseFrom(string sequence, char replacement)
        {
            var here = ((IIsNotModeCharMatcher) this);
            var middle = here.TrimFrom(sequence);
            return here.CollapseFrom(middle, replacement);
        }

        #endregion

        #region Apply

        bool IIsNotModeCharMatcher.Apply(char character)
        {
            return Options.GetSingleChar() != character;
        }

        #endregion
    }
}