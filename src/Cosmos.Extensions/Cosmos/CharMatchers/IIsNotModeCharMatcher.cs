using System;

namespace Cosmos.CharMatchers {
    public interface IIsNotModeCharMatcher : ICharMatcher
    {
        IIsNotModeCharMatcher And(IIsNotModeCharMatcher matcher);
        IIsNotModeCharMatcher Or(IIsNotModeCharMatcher matcher);
        IIsModeCharMatcher Negate();
        string InRange(char startInclusive, char endInclusive);
        string ForPredicate(Func<char, bool> predicate);
        bool MatchesAnyOf(string sequence);
        bool MatchesAllOf(string sequence);
        bool MatchesNoneOf(string sequence);
        int IndexIn(string sequence);
        int IndexIn(string sequence, int startIndex);
        int LastIndexIn(string sequence);
        int CountIn(string sequence);
        string RemoveFrom(string sequence);
        string RetainFrom(string sequence);
        string ReplaceFrom(string sequence, char replacement);
        string ReplaceFrom(string sequence, string replacement);
        string TrimFrom(string sequence);
        string TrimLeadingForm(string sequence);
        string TrimTrailingFrom(string sequence);
        string CollapseFrom(string sequence, char replacement);
        string TrimAndCollapseFrom(string sequence, char replacement);
        bool Apply(char character);
    }
}