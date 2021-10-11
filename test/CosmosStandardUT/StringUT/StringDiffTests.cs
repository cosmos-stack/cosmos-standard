using CosmosStack.Text;
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
        
        [Fact(DisplayName = "To count for diff chars with both null and empty text with IgnoreCase options test")]
        public void BothNullOrEmptyTextAndIgnoreCaseOptionsTest()
        {
            Strings.CountForDiffChars("", "", IgnoreCase.FALSE).ShouldBe(0);
            Strings.CountForDiffChars((string) null, (string) null, IgnoreCase.FALSE).ShouldBe(-1);
            Strings.CountForDiffChars("", (string) null, IgnoreCase.FALSE).ShouldBe(0);
            Strings.CountForDiffChars((string) null, "", IgnoreCase.FALSE).ShouldBe(0);
            
            Strings.CountForDiffChars("", "", IgnoreCase.TRUE).ShouldBe(0);
            Strings.CountForDiffChars((string) null, (string) null, IgnoreCase.TRUE).ShouldBe(-1);
            Strings.CountForDiffChars("", (string) null, IgnoreCase.TRUE).ShouldBe(0);
            Strings.CountForDiffChars((string) null, "", IgnoreCase.TRUE).ShouldBe(0);
        }

        [Fact(DisplayName = "To count for diff chars with one null and empty and another is valid text test")]
        public void OneNullOrEmptyAndAnotherValidTextAndIgnoreCaseTest()
        {
            Strings.CountForDiffCharsIgnoreCase("1", "").ShouldBe(1);
            Strings.CountForDiffCharsIgnoreCase("1", (string) null).ShouldBe(1);
            Strings.CountForDiffCharsIgnoreCase("", "1").ShouldBe(1);
            Strings.CountForDiffCharsIgnoreCase((string) null, "1").ShouldBe(1);
        }

        [Fact(DisplayName = "To count for diff chars with one null and empty and another is valid text with IgnoreCase options test")]
        public void OneNullOrEmptyAndAnotherValidTextAndIgnoreCaseOptionsTest()
        {
            Strings.CountForDiffChars("1", "", IgnoreCase.FALSE).ShouldBe(1);
            Strings.CountForDiffChars("1", (string) null, IgnoreCase.FALSE).ShouldBe(1);
            Strings.CountForDiffChars("", "1", IgnoreCase.FALSE).ShouldBe(1);
            Strings.CountForDiffChars((string) null, "1", IgnoreCase.FALSE).ShouldBe(1);
            
            Strings.CountForDiffChars("1", "", IgnoreCase.TRUE).ShouldBe(1);
            Strings.CountForDiffChars("1", (string) null, IgnoreCase.TRUE).ShouldBe(1);
            Strings.CountForDiffChars("", "1", IgnoreCase.TRUE).ShouldBe(1);
            Strings.CountForDiffChars((string) null, "1", IgnoreCase.TRUE).ShouldBe(1);
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

        [Fact(DisplayName = "To count for diff chars with two valid texts with IgnoreCase options test")]
        public void TwoValidTextsAndIgnoreCaseOptionsTest()
        {
            Strings.CountForDiffChars("abcde","ABCDE", IgnoreCase.TRUE).ShouldBe(0);
            Strings.CountForDiffChars("abcde","ABCD", IgnoreCase.TRUE).ShouldBe(1);
            Strings.CountForDiffChars("abcde","ABC", IgnoreCase.TRUE).ShouldBe(2);
            Strings.CountForDiffChars("abcde","AB", IgnoreCase.TRUE).ShouldBe(3);
            Strings.CountForDiffChars("abcde","A", IgnoreCase.TRUE).ShouldBe(4);
            Strings.CountForDiffChars("abcde","", IgnoreCase.TRUE).ShouldBe(5);
            
            Strings.CountForDiffChars("abcde","BCDE", IgnoreCase.TRUE).ShouldBe(5);
            Strings.CountForDiffChars("abcde","CDE", IgnoreCase.TRUE).ShouldBe(5);
            Strings.CountForDiffChars("abcde","DE", IgnoreCase.TRUE).ShouldBe(5);
            Strings.CountForDiffChars("abcde","E", IgnoreCase.TRUE).ShouldBe(5);
            
            Strings.CountForDiffChars("abcde","ZBCDE", IgnoreCase.TRUE).ShouldBe(1);
            Strings.CountForDiffChars("abcde","ZYCDE", IgnoreCase.TRUE).ShouldBe(2);
            Strings.CountForDiffChars("abcde","ZYXDE", IgnoreCase.TRUE).ShouldBe(3);
            Strings.CountForDiffChars("abcde","ZYXWE", IgnoreCase.TRUE).ShouldBe(4);
            Strings.CountForDiffChars("abcde","ZYXWV", IgnoreCase.TRUE).ShouldBe(5);
            
            Strings.CountForDiffChars("abcde","ABCDE", IgnoreCase.TRUE).ShouldBe(0);
            
            Strings.CountForDiffChars("abcde","ABCDE", IgnoreCase.FALSE).ShouldBe(5);
            Strings.CountForDiffChars("abcde","ABCD", IgnoreCase.FALSE).ShouldBe(5);
            Strings.CountForDiffChars("abcde","ABC", IgnoreCase.FALSE).ShouldBe(5);
            Strings.CountForDiffChars("abcde","AB", IgnoreCase.FALSE).ShouldBe(5);
            Strings.CountForDiffChars("abcde","A", IgnoreCase.FALSE).ShouldBe(5);
            Strings.CountForDiffChars("abcde","", IgnoreCase.FALSE).ShouldBe(5);
            
            Strings.CountForDiffChars("abcde","BCDE", IgnoreCase.FALSE).ShouldBe(5);
            Strings.CountForDiffChars("abcde","CDE", IgnoreCase.FALSE).ShouldBe(5);
            Strings.CountForDiffChars("abcde","DE", IgnoreCase.FALSE).ShouldBe(5);
            Strings.CountForDiffChars("abcde","E", IgnoreCase.FALSE).ShouldBe(5);
            
            Strings.CountForDiffChars("abcde","ZBCDE", IgnoreCase.FALSE).ShouldBe(5);
            Strings.CountForDiffChars("abcde","ZYCDE", IgnoreCase.FALSE).ShouldBe(5);
            Strings.CountForDiffChars("abcde","ZYXDE", IgnoreCase.FALSE).ShouldBe(5);
            Strings.CountForDiffChars("abcde","ZYXWE", IgnoreCase.FALSE).ShouldBe(5);
            Strings.CountForDiffChars("abcde","ZYXWV", IgnoreCase.FALSE).ShouldBe(5);
            
            Strings.CountForDiffChars("abcde","ABCDE", IgnoreCase.FALSE).ShouldBe(5);
        }
    }
}