using System.Linq;
using Cosmos.Text;

namespace CosmosStandardUT.StringUT
{
    [Trait("StringUT", "Strings.Words")]
    public class StringWordsTests
    {
        [Fact(DisplayName = "String/Words CapitalCase test")]
        public void CapitalCaseTest()
        {
            var text = "nice to meet you, AlexLEWIS";
            Strings.ToCapitalCase(text).ShouldBe("Nice To Meet You, Alexlewis");
        }

        [Fact(DisplayName = "String/Words CamelCase test")]
        public void CamelCaseTest()
        {
            var text = "AlexLEWIS DuDuDu";
            Strings.ToCapitalCase(text).ShouldBe("Alexlewis Dududu");
        }

        [Fact(DisplayName = "String/Words CountByWords test")]
        public void CountByWordsTest()
        {
            var text = "Nice to meet you";
            Strings.CountByWords(text).ShouldBe(4);
        }

        [Fact(DisplayName = "String/Words SplitByWords test")]
        public void SplitByWordsTest()
        {
            var text = "Nice to meet you";
            var vals = Strings.SplitByWords(text).ToList();

            vals.Count.ShouldBe(4);
        }

        [Fact(DisplayName = "String/Words TruncateByWords test")]
        public void TruncateByWordsTest()
        {
            var text = "Nice to meet you";
            Strings.TruncateByWords(text, 3).ShouldBe("Nice to meet...");
            Strings.TruncateByWords(text, 3, extraSpace: true).ShouldBe("Nice to meet ...");
        }
    }
}