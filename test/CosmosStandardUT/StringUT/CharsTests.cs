using System.Text;
using CosmosStack.Text;
using CosmosStandardUT.Helpers;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.StringUT
{
    [Trait("StringUT", "Char")]
    public class CharsTests
    {
        [Fact(DisplayName = "Char repeat test")]
        public void CharRepeatTest()
        {
            Chars.Repeat('A', -1).ShouldBeEmpty();
            Chars.Repeat('A', 0).ShouldBeEmpty();
            Chars.Repeat('A', 1).ShouldBe("A");
            Chars.Repeat('A', 2).ShouldBe("AA");

            'A'.Repeat(-1).ShouldBeEmpty();
            'A'.Repeat(0).ShouldBeEmpty();
            'A'.Repeat(1).ShouldBe("A");
            'A'.Repeat(2).ShouldBe("AA");
        }

        [Fact(DisplayName = "Char range test")]
        public void RangeTest()
        {
            var chars = Chars.Range('a', 'z');
            var builder = new StringBuilder();
            foreach (var v in chars)
                builder.Append(v);
            builder.ToString().ShouldBe("abcdefghijklmnopqrstuvwxyz");
        }

        [Fact(DisplayName = "Char is between a and b test")]
        public void BetweenTest()
        {
            Chars.IsBetween('a', 'a', 'a').ShouldBeTrue();
            Chars.IsBetween('a', 'a', 'b').ShouldBeTrue();
            Chars.IsBetween('a', 'b', 'a').ShouldBeTrue();
            Chars.IsBetween('a', 'b', 'b').ShouldBeFalse();
        }

        [Fact(DisplayName = "Char is contained in a and b test")]
        public void BeContainedInTest()
        {
            Chars.BeContainedIn('a', 'a', 'b', 'c').ShouldBeTrue();
            Chars.BeContainedIn('a', 'b', 'c', 'd').ShouldBeFalse();

            Chars.BeNotContainedIn('a', 'a', 'b', 'c').ShouldBeFalse();
            Chars.BeNotContainedIn('a', 'b', 'c', 'd').ShouldBeTrue();
        }

        [Fact(DisplayName = "Char is contained in a and b with ignore case test")]
        public void BeContainedInWithIgnoreCaseTest()
        {
            Chars.BeContainedIn('a', ArrayCreator.Of('a', 'b', 'c'), IgnoreCase.FALSE).ShouldBeTrue();
            Chars.BeContainedIn('a', ArrayCreator.Of('b', 'c', 'd'), IgnoreCase.FALSE).ShouldBeFalse();

            Chars.BeNotContainedIn('a', ArrayCreator.Of('a', 'b', 'c'), IgnoreCase.FALSE).ShouldBeFalse();
            Chars.BeNotContainedIn('a', ArrayCreator.Of('b', 'c', 'd'), IgnoreCase.FALSE).ShouldBeTrue();

            Chars.BeContainedIn('a', ArrayCreator.Of('A', 'b', 'c'), IgnoreCase.FALSE).ShouldBeFalse();
            Chars.BeContainedIn('a', ArrayCreator.Of('b', 'c', 'd'), IgnoreCase.FALSE).ShouldBeFalse();

            Chars.BeNotContainedIn('a', ArrayCreator.Of('A', 'b', 'c'), IgnoreCase.FALSE).ShouldBeTrue();
            Chars.BeNotContainedIn('a', ArrayCreator.Of('b', 'c', 'd'), IgnoreCase.FALSE).ShouldBeTrue();

            Chars.BeContainedIn('a', ArrayCreator.Of('A', 'b', 'c'), IgnoreCase.TRUE).ShouldBeTrue();
            Chars.BeContainedIn('a', ArrayCreator.Of('b', 'c', 'd'), IgnoreCase.TRUE).ShouldBeFalse();

            Chars.BeNotContainedIn('a', ArrayCreator.Of('A', 'b', 'c'), IgnoreCase.TRUE).ShouldBeFalse();
            Chars.BeNotContainedIn('a', ArrayCreator.Of('b', 'c', 'd'), IgnoreCase.TRUE).ShouldBeTrue();
        }

        [Fact(DisplayName = "Extension method for Char is between a and b test")]
        public void ExtensionMethodForBetweenTest()
        {
            'a'.IsBetween('a', 'a').ShouldBeTrue();
            'a'.IsBetween('a', 'b').ShouldBeTrue();
            'a'.IsBetween('b', 'a').ShouldBeTrue();
            'a'.IsBetween('b', 'b').ShouldBeFalse();
        }

        [Fact(DisplayName = "Extension method for Char is contained in a and b test")]
        public void ExtensionMethodForBeContainedInTest()
        {
            'a'.BeContainedIn('a', 'b', 'c').ShouldBeTrue();
            'a'.BeContainedIn('b', 'c', 'd').ShouldBeFalse();

            'a'.BeNotContainedIn('a', 'b', 'c').ShouldBeFalse();
            'a'.BeNotContainedIn('b', 'c', 'd').ShouldBeTrue();

            'a'.BeContainedIn(ArrayCreator.Of('a', 'b', 'c'), IgnoreCase.FALSE).ShouldBeTrue();
            'a'.BeContainedIn(ArrayCreator.Of('b', 'c', 'd'), IgnoreCase.FALSE).ShouldBeFalse();

            'a'.BeNotContainedIn(ArrayCreator.Of('a', 'b', 'c'), IgnoreCase.FALSE).ShouldBeFalse();
            'a'.BeNotContainedIn(ArrayCreator.Of('b', 'c', 'd'), IgnoreCase.FALSE).ShouldBeTrue();

            'a'.BeContainedIn(ArrayCreator.Of('a', 'b', 'c'), IgnoreCase.TRUE).ShouldBeTrue();
            'a'.BeContainedIn(ArrayCreator.Of('b', 'c', 'd'), IgnoreCase.TRUE).ShouldBeFalse();

            'a'.BeNotContainedIn(ArrayCreator.Of('a', 'b', 'c'), IgnoreCase.TRUE).ShouldBeFalse();
            'a'.BeNotContainedIn(ArrayCreator.Of('b', 'c', 'd'), IgnoreCase.TRUE).ShouldBeTrue();
        }

        [Fact(DisplayName = "Char should be equals to a ignore case test")]
        public void EqualWithIgnoreCaseTest()
        {
            'a'.EqualsIgnoreCase('a').ShouldBeTrue();
            'a'.EqualsIgnoreCase('A').ShouldBeTrue();
            'A'.EqualsIgnoreCase('a').ShouldBeTrue();
            'A'.EqualsIgnoreCase('A').ShouldBeTrue();

            'a'.Equals('a', IgnoreCase.TRUE).ShouldBeTrue();
            'a'.Equals('A', IgnoreCase.TRUE).ShouldBeTrue();
            'A'.Equals('a', IgnoreCase.TRUE).ShouldBeTrue();
            'A'.Equals('A', IgnoreCase.TRUE).ShouldBeTrue();

            'a'.Equals('a', IgnoreCase.FALSE).ShouldBeTrue();
            'a'.Equals('A', IgnoreCase.FALSE).ShouldBeFalse();
            'A'.Equals('a', IgnoreCase.FALSE).ShouldBeFalse();
            'A'.Equals('A', IgnoreCase.FALSE).ShouldBeTrue();
        }
    }
}