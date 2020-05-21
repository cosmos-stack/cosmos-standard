using System;

namespace Cosmos.CharMatchers
{
    /// <summary>
    /// Interface to flag 'Not' mode of char matcher
    /// </summary>
    public interface IIsNotModeCharMatcher : ICharMatcher
    {
        /// <summary>
        /// Negate
        /// </summary>
        /// <returns></returns>
        IIsModeCharMatcher Negate();

        /// <summary>
        /// In range
        /// </summary>
        /// <param name="startInclusive"></param>
        /// <param name="endInclusive"></param>
        /// <returns></returns>
        string InRange(char startInclusive, char endInclusive);

        /// <summary>
        /// For predicate
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        string ForPredicate(Func<char, bool> predicate);

        /// <summary>
        /// Matches any of
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        bool MatchesAnyOf(string sequence);

        /// <summary>
        /// Matches all of
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        bool MatchesAllOf(string sequence);

        /// <summary>
        /// Matches none of
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        bool MatchesNoneOf(string sequence);

        /// <summary>
        /// Index in
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        int IndexIn(string sequence);

        /// <summary>
        /// Index in
        /// </summary>
        /// <param name="sequence"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        int IndexIn(string sequence, int startIndex);

        /// <summary>
        /// Last index in
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        int LastIndexIn(string sequence);

        /// <summary>
        /// Count in
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        int CountIn(string sequence);

        /// <summary>
        /// Remove from
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        string RemoveFrom(string sequence);

        /// <summary>
        /// Retain from
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        string RetainFrom(string sequence);

        /// <summary>
        /// Replace from
        /// </summary>
        /// <param name="sequence"></param>
        /// <param name="replacement"></param>
        /// <returns></returns>
        string ReplaceFrom(string sequence, char replacement);

        /// <summary>
        /// Replace from
        /// </summary>
        /// <param name="sequence"></param>
        /// <param name="replacement"></param>
        /// <returns></returns>
        string ReplaceFrom(string sequence, string replacement);

        /// <summary>
        /// Trim from
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        string TrimFrom(string sequence);

        /// <summary>
        /// Trim trailing from
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        string TrimLeadingForm(string sequence);

        /// <summary>
        /// Trim trailing from
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        string TrimTrailingFrom(string sequence);

        /// <summary>
        /// Collapse from
        /// </summary>
        /// <param name="sequence"></param>
        /// <param name="replacement"></param>
        /// <returns></returns>
        string CollapseFrom(string sequence, char replacement);

        /// <summary>
        /// Trim and collapse from
        /// </summary>
        /// <param name="sequence"></param>
        /// <param name="replacement"></param>
        /// <returns></returns>
        string TrimAndCollapseFrom(string sequence, char replacement);

        /// <summary>
        /// Apply
        /// </summary>
        /// <param name="character"></param>
        /// <returns></returns>
        bool Apply(char character);
    }
}