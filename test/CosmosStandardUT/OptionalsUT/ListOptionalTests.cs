using System.Collections.Generic;
using Cosmos.Optionals;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.OptionalsUT
{
    [Trait("CollUT", "ListUT.Remove")]
    public class ListOptionalTests
    {
        [Fact(DisplayName = "extension method Remove range of elements from List safety test")]
        public void ExtensionMethodForRemoveRangeFromListSafety()
        {
            var nice = new List<string> {"1", "2", "3"};

            nice.RemoveRangeSafety(4, 4);
            nice.ShouldNotBeNull();
            nice.ShouldNotBeEmpty();
            nice.Count.ShouldBe(3);

            nice.RemoveRangeSafety(0, 0);
            nice.ShouldNotBeNull();
            nice.ShouldNotBeEmpty();
            nice.Count.ShouldBe(3);

            nice.RemoveRangeSafety(4, 0);
            nice.ShouldNotBeNull();
            nice.ShouldNotBeEmpty();
            nice.Count.ShouldBe(3);

            nice.RemoveRangeSafety(0, 4);
            nice.ShouldNotBeNull();
            nice.ShouldBeEmpty();
        }
    }
}