using System.Collections.Generic;
using Cosmos.Text;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.StringUT
{
    [Trait("StringUT", "Strings.Basic")]
    public class StringsTests
    {
        [Fact(DisplayName = "Merge all chars test")]
        public void MergeForAllCharsTest()
        {
            var chars = new List<char> {'a', 'b', 'c'};
            Strings.Merge(chars).ShouldBe("abc");
        }

        [Fact(DisplayName = "Merge all strings test")]
        public void MergeForStringsTest()
        {
            var strings = new List<string> {"00", "11", "22"};
            Strings.Merge("AA", strings.ToArray()).ShouldBe("AA001122");
        }

        [Fact(DisplayName = "Merge one string and a set of string test")]
        public void MergeForStringAndStringsTest()
        {
            Strings.Merge("AA", "00", "11", "22").ShouldBe("AA001122");
        }

        [Fact(DisplayName = "Merge one string and a set of chars test")]
        public void MergeForStringAndCharsTest()
        {
            Strings.Merge("AA", '0', '0', '1', '1', '2', '2').ShouldBe("AA001122");
        }

        [Fact(DisplayName = "Equals between two string and ignore case test")]
        public void EqualsBetweenTwoStringsIgnoreCaseTest()
        {
            "AAA".EqualsIgnoreCase("aaa").ShouldBeTrue();
            "aaa".EqualsIgnoreCase("AAA").ShouldBeTrue();
            "AaA".EqualsIgnoreCase("aAa").ShouldBeTrue();
            "".EqualsIgnoreCase("").ShouldBeTrue();
        }

        [Fact(DisplayName = "Equals to any one and ignore case test")]
        public void EqualsToAnyOneAndIgnoreCaseTest()
        {
            "AAA".EqualsToAnyIgnoreCase("a", "aa", "aaa").ShouldBeTrue();
            "aaa".EqualsToAnyIgnoreCase("b", "a", "bb", "AA", "AAA").ShouldBeTrue();
            "ZZZ".EqualsToAnyIgnoreCase().ShouldBeFalse();
            "ZZZ".EqualsToAnyIgnoreCase(null).ShouldBeFalse();
        }
    }
}