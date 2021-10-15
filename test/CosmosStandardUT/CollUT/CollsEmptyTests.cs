using CosmosStack.Collections;
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
        
        [Fact(DisplayName = "ReadOnlyColls.Empty test")]
        public void ReadOnlyEmptyArrayTest()
        {
            var array = ReadOnlyColls.Empty<string>();

            array.ShouldNotBeNull();
            array.ShouldBeEmpty();
        }
    }
}