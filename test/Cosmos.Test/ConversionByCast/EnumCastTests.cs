using Xunit;
using Shouldly;

namespace Cosmos.Test.ConversionByCast {
    public class EnumCastTests {

        [Theory]
        [InlineData("A", NiceYou001.A)]
        [InlineData("B", NiceYou001.B)]
        [InlineData("C", NiceYou001.C)]
        [InlineData("D", NiceYou001.D)]
        public void StringToEnumTest(string str, NiceYou001 expectedNice) {
            str.CastToEnum<NiceYou001>().ShouldBe(expectedNice);
        }

        [Theory]
        [InlineData(NiceYou001.A, "A")]
        [InlineData(NiceYou001.B, "B")]
        [InlineData(NiceYou001.C, "C")]
        [InlineData(NiceYou001.D, "D")]
        public void EnumToStringTest(NiceYou001 value, string expectedStr) {
            value.CastToString().ShouldBe(expectedStr);
        }

        [Theory]
        [InlineData(NiceYou001.A)]
        [InlineData(NiceYou001.B)]
        [InlineData(NiceYou001.C)]
        [InlineData(NiceYou001.D)]
        public void EnumToIntTest(NiceYou001 value) {
            var expectedInt = (int) value;
            value.CastTo<int>().ShouldBe(expectedInt);
        }
    }

    public enum NiceYou001 : int {
        A = 1,
        B = 2,
        C = 3,
        D = 4
    }
}