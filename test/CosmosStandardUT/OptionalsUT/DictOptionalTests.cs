using System.Collections.Generic;
using CosmosStack.Optionals;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.OptionalsUT
{
    [Trait("CollUT", "DictUT.Optionals")]
    public class DictOptionalTests
    {
        public DictOptionalTests()
        {
            Dictionary = new Dictionary<string, int> {{"A", 1}, {"B", 2}};

            CascadingDictionary = new List<Dictionary<string, int>>
            {
                new() {{"A", 1}, {"B", 2}},
                new() {{"C", 3}, {"D", 4}}
            };
        }

        private Dictionary<string, int> Dictionary { get; }
        private IEnumerable<Dictionary<string, int>> CascadingDictionary { get; }


        [Fact(DisplayName = "extension method To getting optional value from dictionary test")]
        public void GettingOptionalValueTest()
        {
            var val1 = Dictionary.GetOptionalValue("A");
            var val2 = Dictionary.GetOptionalValue("B");
            var val3 = Dictionary.GetOptionalValue("C");

            val1.HasValue.ShouldBeTrue();
            val2.HasValue.ShouldBeTrue();
            val3.HasValue.ShouldBeFalse();

            val1!.Value.ShouldBe(1);
            val2!.Value.ShouldBe(2);
        }

        [Fact(DisplayName = "extension method To getting optional value from cascading dictionary test")]
        public void GettingOptionalValueCascadingTest()
        {
            var val1 = CascadingDictionary.GetOptionalValue("A");
            var val2 = CascadingDictionary.GetOptionalValue("B");
            var val3 = CascadingDictionary.GetOptionalValue("C");
            var val4 = CascadingDictionary.GetOptionalValue("D");
            var val5 = CascadingDictionary.GetOptionalValue("E");

            val1.HasValue.ShouldBeTrue();
            val2.HasValue.ShouldBeTrue();
            val3.HasValue.ShouldBeTrue();
            val4.HasValue.ShouldBeTrue();
            val5.HasValue.ShouldBeFalse();

            val1!.Value.ShouldBe(1);
            val2!.Value.ShouldBe(2);
            val3!.Value.ShouldBe(3);
            val4!.Value.ShouldBe(4);
        }
    }
}