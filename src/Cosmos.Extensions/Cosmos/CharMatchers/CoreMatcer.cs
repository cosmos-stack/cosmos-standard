namespace Cosmos.CharMatchers
{
    public partial class CharMatcher
    {
        private class CoreMatcher : ICharMatcherImplementor
        {
            public bool Matches(char c) => true;

            public CoreMatchers And(CoreMatcher matcher)
            {
                var matchers = new CoreMatchers {this};
                matchers.AndMatcher(matcher);
                return matchers;
            }

            public CoreMatchers Or(CoreMatcher matcher)
            {
                var matchers = new CoreMatchers {this};
                matchers.OrMatcher(matcher);
                return matchers;
            }
        }
    }

}