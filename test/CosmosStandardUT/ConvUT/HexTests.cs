using Cosmos.Conversions;

namespace CosmosStandardUT.ConvUT
{
    [Trait("ConvUT", "HexTests")]
    public class HexTests
    {
        [Fact]
        public void HexTest()
        {
            var dec = "1234567890";
            var hex = ScaleConv.X2X(dec, 10, 16); // Should be 499602D2

            var hexBytes01 = Hex.ToBytes(hex); // Should be 73 150 2 210
            var hex01 = Hex.ToString(hexBytes01);
            
            hex01.ShouldBe(hex);
        }
    }
}