using CosmosStack.Text;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.ConvUT
{
    public class NumericCastTests
    {
        [Theory]
        [InlineData("1", 1)]
        [InlineData("0", 0)]
        [InlineData("-1", -1)]
        public void StringToShortTest(string str, short expected)
        {
            str.CastToInt16().ShouldBe(expected);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("0", 0)]
        public void StringToUShortTest(string str, ushort expected)
        {
            str.CastToUInt16().ShouldBe(expected);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("0", 0)]
        [InlineData("-1", -1)]
        public void StringToIntTest(string str, int expected)
        {
            str.CastToInt32().ShouldBe(expected);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("0", 0)]
        public void StringToUIntTest(string str, uint expected)
        {
            str.CastToUInt32().ShouldBe(expected);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("0", 0)]
        [InlineData("-1", -1)]
        public void StringToLongTest(string str, long expected)
        {
            str.CastToInt64().ShouldBe(expected);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("0", 0)]
        public void StringToULongTest(string str, ulong expected)
        {
            str.CastToUInt64().ShouldBe(expected);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("0", 0)]
        [InlineData("0.1", 0.1)]
        [InlineData("10.1", 10.1)]
        [InlineData("-0.1", -0.1)]
        [InlineData("188594011.1555", 188594011.1555)]
        public void StringToFloatTest(string str, float expected)
        {
            str.CastToFloat().ShouldBe(expected);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("0", 0)]
        [InlineData("0.1", 0.1)]
        [InlineData("10.1", 10.1)]
        [InlineData("-0.1", -0.1)]
        [InlineData("188594011.1555", 188594011.1555)]
        public void StringToDoubleTest(string str, double expected)
        {
            str.CastToDouble().ShouldBe(expected);
        }

        [Theory]
        [InlineData("1", 1)]
        [InlineData("0", 0)]
        [InlineData("0.1", 0.1)]
        [InlineData("10.1", 10.1)]
        [InlineData("-0.1", -0.1)]
        [InlineData("188594011.1555", 188594011.1555)]
        public void StringToDecimalTest(string str, decimal expected)
        {
            str.CastToDecimal().ShouldBe(expected);
        }
    }
}