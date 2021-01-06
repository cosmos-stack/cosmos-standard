using Cosmos.Text;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.StringUT
{
    [Trait("StringUT", "Strings.Where")]
    public class StringFilterTests
    {
        [Fact(DisplayName = "Filter char in a string by given predicate test")]
        public void FilterCharInStringTest()
        {
            Strings.Merge(Strings.FilterByChar("123456789", c => c > '8')).ShouldBe("9");
            Strings.Merge(Strings.FilterByChar("123456789abcdefg", char.IsDigit)).ShouldBe("123456789");
            Strings.Merge(Strings.FilterByChar("123456789abcdefg", char.IsLetter)).ShouldBe("abcdefg");
        }

        [Fact(DisplayName = "Extension method for Filter char in a string by given predicate test")]
        public void ExtensionsMethodForFilterCharInStringTest()
        {
            Strings.Merge("123456789".Where(c => c > '8')).ShouldBe("9");
            Strings.Merge("123456789abcdefg".Where(char.IsDigit)).ShouldBe("123456789");
            Strings.Merge("123456789abcdefg".Where(char.IsLetter)).ShouldBe("abcdefg");
        }

        [Fact(DisplayName = "Filter char in a string for digit and letters test")]
        public void FilterForDigitAndLetters()
        {
            Strings.Merge(Strings.FilterForNumbersAndLetters("abcd1234")).ShouldBe("abcd1234");
        }
        
        [Fact(DisplayName = "Filter char in a string for digit test")]
        public void FilterForDigit()
        {
            Strings.Merge(Strings.FilterForNumbers("abcd1234")).ShouldBe("1234");
        }
        
        [Fact(DisplayName = "Filter char in a string for letters test")]
        public void FilterForLetters()
        {
            Strings.Merge(Strings.FilterForLetters("abcd1234")).ShouldBe("abcd");
        }
    }
}