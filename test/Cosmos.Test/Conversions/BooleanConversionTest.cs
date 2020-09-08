using Cosmos.Conversions;
using Xunit;

namespace Cosmos.Test.Conversions {
    public class BooleanConversionTest {

        public class One { }

        [Fact]
        public void ObjectBooleanTest() {
            One one = new One();
            One two = null;

            Assert.False(BooleanConv.ToBoolean(one));
            Assert.False(BooleanConv.ToBoolean(two));
        }

        [Fact]
        public void ObjectNullableBooleanTest() {
            One one = new One();
            One two = null;

            Assert.Null(BooleanConv.ToNullableBoolean(one));
            Assert.Null(BooleanConv.ToNullableBoolean(two));
        }

        [Theory]
        [InlineData("yes")]
        [InlineData("1")]
        public void VerbaAliasTrueBooleanTest(string alias) {
            Assert.True(BooleanConv.ToBoolean(alias));
        }

        [Theory]
        [InlineData("no")]
        [InlineData("0")]
        public void VerbaAliasFalseBooleanTest(string alias) {
            Assert.False(BooleanConv.ToBoolean(alias));
        }


        [Theory]
        [InlineData("yes")]
        [InlineData("1")]
        public void VerbaAliasTrueNullableBooleanTest(string alias) {
            Assert.True(BooleanConv.ToNullableBoolean(alias));
        }

        [Theory]
        [InlineData("no")]
        [InlineData("0")]
        public void VerbaAliasFalseNullableBooleanTest(string alias) {
            Assert.False(BooleanConv.ToNullableBoolean(alias));
        }

        [Theory]
        [InlineData("nono")]
        [InlineData("yeah")]
        public void VerbaAliasNullableBooleanTest(string alias) {
            Assert.Null(BooleanConv.ToNullableBoolean(alias));
        }
    }
}