using Cosmos.Numeric;

namespace CosmosStandardUT.NumericUT
{
    [Trait("NumericUT", "NumericJudge")]
    public class NumericJudgeTests
    {
        [Fact(DisplayName = "Number should be int16 test")]
        public void NumericShouldBeInt16Test()
        {
            NumericJudge.IsInt16("16").ShouldBeTrue();
            NumericJudge.IsInt16("1600000").ShouldBeFalse();
        }

        [Fact(DisplayName = "Number should be int32 test")]
        public void NumericShouldBeInt32Test()
        {
            NumericJudge.IsInt32("32").ShouldBeTrue();
            NumericJudge.IsInt32("320000000000000").ShouldBeFalse();
        }

        [Fact(DisplayName = "Number should be int64 test")]
        public void NumericShouldBeInt64Test()
        {
            NumericJudge.IsInt64("64").ShouldBeTrue();
            NumericJudge.IsInt64("64000000000000000000000000000000000000000000000000000000000000000000000000000000").ShouldBeFalse();
        }

        [Fact(DisplayName = "Number should be Uint16 test")]
        public void NumericShouldBeUInt16Test()
        {
            NumericJudge.IsUInt16("16").ShouldBeTrue();
            NumericJudge.IsUInt16("1600000").ShouldBeFalse();
            NumericJudge.IsUInt16("-16").ShouldBeFalse();
            NumericJudge.IsUInt16("-1600000").ShouldBeFalse();
        }

        [Fact(DisplayName = "Number should be Uint32 test")]
        public void NumericShouldBeUInt32Test()
        {
            NumericJudge.IsUInt32("32").ShouldBeTrue();
            NumericJudge.IsUInt32("320000000000000").ShouldBeFalse();
            NumericJudge.IsUInt32("-32").ShouldBeFalse();
            NumericJudge.IsUInt32("-320000000000000").ShouldBeFalse();
        }

        [Fact(DisplayName = "Number should be Uint64 test")]
        public void NumericShouldBeUInt64Test()
        {
            NumericJudge.IsUInt64("64").ShouldBeTrue();
            NumericJudge.IsUInt64("64000000000000000000000000000000000000000000000000000000000000000000000000000000").ShouldBeFalse();
            NumericJudge.IsUInt64("-64").ShouldBeFalse();
            NumericJudge.IsUInt64("-64000000000000000000000000000000000000000000000000000000000000000000000000000000").ShouldBeFalse();
        }

        [Fact(DisplayName = "Number should be between test")]
        public void NumericBetweenTest()
        {
            short a = 1;
            int b = 1;
            long c = 1;
            float d = 1;
            double e = 1;
            decimal f = 1;

            NumericJudge.IsBetween(a, (short) 0, (short) 2).ShouldBeTrue();
            NumericJudge.IsBetween(b, 0, 2).ShouldBeTrue();
            NumericJudge.IsBetween(c, 0, 2).ShouldBeTrue();
            NumericJudge.IsBetween(d, 0, 2).ShouldBeTrue();
            NumericJudge.IsBetween(e, 0, 2).ShouldBeTrue();
            NumericJudge.IsBetween(f, 0, 2).ShouldBeTrue();
        }
        [Fact(DisplayName = "Number should be NaN test")]
        public void NaNTest()
        {
            var number1 = double.NaN;
            var number2 = float.NaN;

            NumericJudge.IsNaN(number1).ShouldBeTrue();
            NumericJudge.IsNaN(number2).ShouldBeTrue();
            NumericJudge.IsNaN(123).ShouldBeFalse();
        }
    }
}