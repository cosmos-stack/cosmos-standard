using Cosmos.Collections;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.CollUT
{
    [Trait("CollUT", "ArrayUT.Empty")]
    public class ArrayEmptyTests
    {
        [Fact(DisplayName = "Arrays.Empty test")]
        public void EmptyArrayTest()
        {
            var array = Arrays.Empty<string>();
            
            array.ShouldNotBeNull();
            array.ShouldBeEmpty();
        }
    }
}