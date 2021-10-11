using Cosmos.Collections;
using Shouldly;
using Xunit;
using Arrays = CosmosStack.Collections.Arrays;

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