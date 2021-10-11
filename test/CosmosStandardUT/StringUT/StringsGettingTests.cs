using CosmosStack.Text;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.StringUT
{
    [Trait("StringUT", "Strings.Get")]
    public class StringsGettingTests
    {
        [Fact(DisplayName = "Filter char in a string for digit and letters test")]
        public void FilterForDigitAndLetters()
        {
            Strings.GetNumbersAndLetters("abcd1234").ShouldBe("abcd1234");
        }

        [Fact(DisplayName = "Filter char in a string for letters test")]
        public void FilterForLetters()
        {
            Strings.GetLetters("abcd1234").ShouldBe("abcd");
        }

        [Fact(DisplayName = "Filter char in a string for digit test")]
        public void FilterForDigit()
        {
            Strings.GetNumbers("abcd1234").ShouldBe("1234");
        }
    }
}