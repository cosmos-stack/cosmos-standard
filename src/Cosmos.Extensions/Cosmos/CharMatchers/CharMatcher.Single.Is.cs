using System;

namespace Cosmos.CharMatchers
{
    /// <summary>
    /// Char matcher
    /// </summary>
    public partial class CharMatcher : IIsModeCharMatcher
    {
        #region Negate

        IIsNotModeCharMatcher IIsModeCharMatcher.Negate()
        {
            Options.Negate();
            return this;
        }

        #endregion

        #region InRange

        string IIsModeCharMatcher.InRange(char startInclusive, char endInclusive)
        {
            var @char = Options.GetSingleChar();
            var (min, max) = CharMatcherUtils.GetMinAndMax(startInclusive, endInclusive);
            return @char.IsBetween(min, max).Ifttt(
                () => $"{@char}",
                () => string.Empty);
        }

        #endregion

        #region ForPredicate

        string IIsModeCharMatcher.ForPredicate(Func<char, bool> predicate)
        {
            var @char = Options.GetSingleChar();
            return (predicate?.Invoke(@char) ?? false).Ifttt(
                () => $"{@char}", 
                () => string.Empty);
        }

        #endregion

        #region Match

        bool IIsModeCharMatcher.MatchesAnyOf(string sequence)
        {
            return SingleUtils.MatchesAnyOf(sequence, Options);
        }

        bool IIsModeCharMatcher.MatchesAllOf(string sequence)
        {
            return SingleUtils.MatchesAllOf(sequence, Options);
        }

        bool IIsModeCharMatcher.MatchesNoneOf(string sequence)
        {
            return !SingleUtils.MatchesAnyOf(sequence, Options);
        }

        #endregion

        #region IndexIn

        int IIsModeCharMatcher.IndexIn(string sequence)
        {
            return SingleUtils.IndexIn(sequence, Options.GetSingleChar());
        }

        int IIsModeCharMatcher.IndexIn(string sequence, int startIndex)
        {
            return SingleUtils.IndexIn(sequence, Options.GetSingleChar(), startIndex);
        }

        int IIsModeCharMatcher.LastIndexIn(string sequence)
        {
            return SingleUtils.LastIndexIn(sequence, Options.GetSingleChar());
        }

        #endregion

        #region CountIn

        int IIsModeCharMatcher.CountIn(string sequence)
        {
            return SingleUtils.CountIn(sequence, Options.GetSingleChar());
        }

        #endregion

        #region Operation from

        string IIsModeCharMatcher.RemoveFrom(string sequence)
        {
            return SingleUtils.RemoveFrom(sequence, Options);
        }

        string IIsModeCharMatcher.RetainFrom(string sequence)
        {
            return SingleUtils.RemoveFrom(sequence, Options, true);
        }

        string IIsModeCharMatcher.ReplaceFrom(string sequence, char replacement)
        {
            return SingleUtils.ReplaceFrom(sequence, $"{replacement}", Options);
        }

        string IIsModeCharMatcher.ReplaceFrom(string sequence, string replacement)
        {
            return SingleUtils.ReplaceFrom(sequence, replacement, Options);
        }

        #endregion

        #region Trim

        string IIsModeCharMatcher.TrimFrom(string sequence)
        {
            return SingleUtils.TrimFrom(sequence, Options);
        }


        string IIsModeCharMatcher.TrimLeadingForm(string sequence)
        {
            return SingleUtils.TrimStartFrom(sequence, Options);
        }

        string IIsModeCharMatcher.TrimTrailingFrom(string sequence)
        {
            return SingleUtils.TrimEndFrom(sequence, Options);
        }

        #endregion

        #region Collapse

        string IIsModeCharMatcher.CollapseFrom(string sequence, char replacement)
        {
            return SingleUtils.CollapseFrom(sequence, replacement, Options);
        }

        string IIsModeCharMatcher.TrimAndCollapseFrom(string sequence, char replacement)
        {
            var here = ((IIsModeCharMatcher) this);
            var middle = here.TrimFrom(sequence);
            return here.CollapseFrom(middle, replacement);
        }

        #endregion

        #region Apply

        bool IIsModeCharMatcher.Apply(char character)
        {
            return Options.GetSingleChar() == character;
        }

        #endregion

    }

}