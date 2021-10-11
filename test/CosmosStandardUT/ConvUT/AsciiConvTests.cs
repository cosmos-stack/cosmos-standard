using CosmosStack.Conversions;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.ConvUT
{
    [Trait("ConvUT", "Ascii")]
    public class AsciiConvTests
    {
        [Fact(DisplayName = "Bytes-2-AsciiString test")]
        public void BytesAndAsciiStringTest()
        {
            var bytes = new byte[] {65, 66, 67};
            var asciiString = AsciiConv.BytesToAsciiString(bytes);

            asciiString.ShouldBe("ABC");

            var byteArray = AsciiConv.AsciiStringToBytes(asciiString);

            byteArray.Length.ShouldBe(3);
            byteArray[0].ShouldBe((byte) 65);
            byteArray[1].ShouldBe((byte) 66);
            byteArray[2].ShouldBe((byte) 67);
        }
    }
}