using Cosmos.Collections;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.CollUT
{
    [Trait("CollUT", "ListUT.Empty")]
    public class CollsEmptyTests
    {
        [Fact(DisplayName = "Colls.Empty test")]
        public void EmptyArrayTest()
        {
            var array = Colls.Empty<string>();

            array.ShouldNotBeNull();
            array.ShouldBeEmpty();
        }
    }
}