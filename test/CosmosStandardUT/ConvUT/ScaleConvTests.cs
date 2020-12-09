using Cosmos.Conversions;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.ConvUT
{
    public class ScaleConvTests
    {
        [Fact(DisplayName = "X-2-X test")]
        public void SystemToSystemTest()
        {
           ScaleConv.X2X("101110",2,10).ShouldBe("46");
           ScaleConv.X2X("101110", 2, 16).ShouldBe("2E");
           ScaleConv.X2X("128",10,16).ShouldBe("80");
           ScaleConv.X2X("2E",16,10).ShouldBe("46");
        }
    }
}