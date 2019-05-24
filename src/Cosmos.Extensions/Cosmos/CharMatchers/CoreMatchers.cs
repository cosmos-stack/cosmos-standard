using System.Collections.Generic;

namespace Cosmos.CharMatchers
{
    public partial class CharMatcher
    {
        private class CoreMatchers : List<ICharMatcherImplementor>
        {
            public string Mode { get; set; } = MatchingMode.AND;

            public CoreMatchers AndMatcher(ICharMatcherImplementor matcher)
            {
                Add(matcher);
                Mode = MatchingMode.AND;
                return this;
            }

            public CoreMatchers OrMatcher(ICharMatcherImplementor matcher)
            {
                Add(matcher);
                Mode = MatchingMode.OR;
                return this;
            }

            public CoreMatchers AndMatchers(CoreMatchers matchers)
            {
                foreach (var matcher in matchers)
                    AndMatcher(matcher);
                Mode = MatchingMode.AND;
                return this;
            }

            public CoreMatchers OrMatchers(CoreMatchers matchers)
            {
                foreach (var matcher in matchers)
                    AndMatcher(matcher);
                Mode = MatchingMode.OR;
                return this;
            }

            public bool Matches(char c)
            {
                if (MatchingMode.IsAndMode(Mode))
                {
                    foreach (var matcher in this)
                    {
                        if (!matcher.Matches(c))
                            return false;
                    }

                    return true;
                }
                else
                {
                    foreach (var matcher in this)
                    {
                        if (matcher.Matches(c))
                            return true;
                    }

                    return false;
                }
            }

            public static CoreMatchers Create()
            {
                var matcher = new CoreMatcher();
                var matchers = new CoreMatchers {matcher};
                return matchers;
            }
        }

    }
}