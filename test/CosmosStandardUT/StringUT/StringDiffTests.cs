using Cosmos.Text;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.StringUT
{
    [Trait("StringUT", "Strings.Diff")]
    public class StringDiffTests
    {
        [Fact(DisplayName = "To count for diff chars with both null and empty text test")]
        public void BothNullOrEmptyTextTest()
        {
            Strings.CountForDiffChars("", "").ShouldBe(0);
            Strings.CountForDiffChars((string) null, (string) null).ShouldBe(-1);
            Strings.CountForDiffChars("", (string) null).ShouldBe(0);
            Strings.CountForDiffChars((string) null, "").ShouldBe(0);
        }

        [Fact(DisplayName = "To count for diff chars with one null and empty and another is valid text test")]
        public void OneNullOrEmptyAndAnotherValidTextTest()
        {
            Strings.CountForDiffChars("1", "").ShouldBe(1);
            Strings.CountForDiffChars("1", (string) null).ShouldBe(1);
            Strings.CountForDiffChars("", "1").ShouldBe(1);
            Strings.CountForDiffChars((string) null, "1").ShouldBe(1);
        }

        [Fact(DisplayName = "To count for diff chars with two valid texts test")]
        public void TwoValidTextsTest()
        {
            Strings.CountForDiffChars("12345","12345").ShouldBe(0);
            Strings.CountForDiffChars("12345","1234").ShouldBe(1);
            Strings.CountForDiffChars("12345","123").ShouldBe(2);
            Strings.CountForDiffChars("12345","12").ShouldBe(3);
            Strings.CountForDiffChars("12345","1").ShouldBe(4);
            Strings.CountForDiffChars("12345","").ShouldBe(5);
            
            Strings.CountForDiffChars("12345","2345").ShouldBe(5);
            Strings.CountForDiffChars("12345","345").ShouldBe(5);
            Strings.CountForDiffChars("12345","45").ShouldBe(5);
            Strings.CountForDiffChars("12345","5").ShouldBe(5);
            
            Strings.CountForDiffChars("12345","z2345").ShouldBe(1);
            Strings.CountForDiffChars("12345","zy345").ShouldBe(2);
            Strings.CountForDiffChars("12345","zyx45").ShouldBe(3);
            Strings.CountForDiffChars("12345","zyxw5").ShouldBe(4);
            Strings.CountForDiffChars("12345","zyxwv").ShouldBe(5);
        }
        
        [Fact(DisplayName = "To count for diff chars with both null and empty text test")]
        public void BothNullOrEmptyTextAndIgnoreCaseTest()
        {
            Strings.CountForDiffCharsIgnoreCase("", "").ShouldBe(0);
            Strings.CountForDiffCharsIgnoreCase((string) null, (string) null).ShouldBe(-1);
            Strings.CountForDiffCharsIgnoreCase("", (string) null).ShouldBe(0);
            Strings.CountForDiffCharsIgnoreCase((string) null, "").ShouldBe(0);
        }

        [Fact(DisplayName = "To count for diff chars with one null and empty and another is valid text test")]
        public void OneNullOrEmptyAndAnotherValidTextAndIgnoreCaseTest()
        {
            Strings.CountForDiffCharsIgnoreCase("1", "").ShouldBe(1);
            Strings.CountForDiffCharsIgnoreCase("1", (string) null).ShouldBe(1);
            Strings.CountForDiffCharsIgnoreCase("", "1").ShouldBe(1);
            Strings.CountForDiffCharsIgnoreCase((string) null, "1").ShouldBe(1);
        }

        [Fact(DisplayName = "To count for diff chars with two valid texts test")]
        public void TwoValidTextsAndIgnoreCaseTest()
        {
            Strings.CountForDiffCharsIgnoreCase("12345","12345").ShouldBe(0);
            Strings.CountForDiffCharsIgnoreCase("12345","1234").ShouldBe(1);
            Strings.CountForDiffCharsIgnoreCase("12345","123").ShouldBe(2);
            Strings.CountForDiffCharsIgnoreCase("12345","12").ShouldBe(3);
            Strings.CountForDiffCharsIgnoreCase("12345","1").ShouldBe(4);
            Strings.CountForDiffCharsIgnoreCase("12345","").ShouldBe(5);
            
            Strings.CountForDiffCharsIgnoreCase("12345","2345").ShouldBe(5);
            Strings.CountForDiffCharsIgnoreCase("12345","345").ShouldBe(5);
            Strings.CountForDiffCharsIgnoreCase("12345","45").ShouldBe(5);
            Strings.CountForDiffCharsIgnoreCase("12345","5").ShouldBe(5);
            
            Strings.CountForDiffCharsIgnoreCase("12345","z2345").ShouldBe(1);
            Strings.CountForDiffCharsIgnoreCase("12345","zy345").ShouldBe(2);
            Strings.CountForDiffCharsIgnoreCase("12345","zyx45").ShouldBe(3);
            Strings.CountForDiffCharsIgnoreCase("12345","zyxw5").ShouldBe(4);
            Strings.CountForDiffCharsIgnoreCase("12345","zyxwv").ShouldBe(5);
            
            Strings.CountForDiffCharsIgnoreCase("abcde","ABCDE").ShouldBe(0);
        }
    }
}