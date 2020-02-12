using Cosmos.Conversions;
using Xunit;

namespace Cosmos.Test.Conversions {
    public class BooleanConversionTest {

        public class One { }

        [Fact]
        public void ObjectBooleanTest() {
            One one = new One();
            One two = null;

            Assert.False(BooleanConverter.ToBoolean(one));
            Assert.False(BooleanConverter.ToBoolean(two));
        }

        [Fact]
        public void ObjectNullableBooleanTest() {
            One one = new One();
            One two = null;

            Assert.Null(BooleanConverter.ToNullableBoolean(one));
            Assert.Null(BooleanConverter.ToNullableBoolean(two));
        }

        [Theory]
        [InlineData("yes")]
        [InlineData("1")]
        public void VerbaAliasTrueBooleanTest(string alias) {
            Assert.True(BooleanConverter.ToBoolean(alias));
        }

        [Theory]
        [InlineData("no")]
        [InlineData("0")]
        public void VerbaAliasFalseBooleanTest(string alias) {
            Assert.False(BooleanConverter.ToBoolean(alias));
        }


        [Theory]
        [InlineData("yes")]
        [InlineData("1")]
        public void VerbaAliasTrueNullableBooleanTest(string alias) {
            Assert.True(BooleanConverter.ToNullableBoolean(alias));
        }

        [Theory]
        [InlineData("no")]
        [InlineData("0")]
        public void VerbaAliasFalseNullableBooleanTest(string alias) {
            Assert.False(BooleanConverter.ToNullableBoolean(alias));
        }

        [Theory]
        [InlineData("nono")]
        [InlineData("yeah")]
        public void VerbaAliasNullableBooleanTest(string alias) {
            Assert.Null(BooleanConverter.ToNullableBoolean(alias));
        }
    }
}