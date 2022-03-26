using System;
using Cosmos.Conversions;
using Cosmos.Text;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.ConvUT
{
    [Trait("ConvUT", "StringConv.JudgeIsNumeric(UInt64)")]
    public class StringConvBeUInt64TypeTests
    {
        public StringConvBeUInt64TypeTests()
        {
            Context = new CastingContext
            {
                IgnoreCase = IgnoreCase.TRUE
            };
        }

        private CastingContext Context { get; set; }

        [Fact(DisplayName = "To judge string is UInt64 type or not test")]
        public void JudgingStringIsUInt64TypeTest()
        {
            var type = typeof(UInt64);
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";

            text0.Is(type).ShouldBeFalse();
            text1.Is(type).ShouldBeTrue();
            text2.Is(type).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is UInt64 type or not and ignore case test")]
        public void JudgingStringIsUInt64TypeWithIgnoreCaseTest()
        {
            var type = typeof(UInt64);
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";

            text0.Is(type, Context).ShouldBeFalse();
            text1.Is(type, Context).ShouldBeTrue();
            text2.Is(type, Context).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is UInt64 type or not by generic type test")]
        public void JudgingStringIsUInt64TypeByGenericTypeTest()
        {
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";

            text0.Is<UInt64>().ShouldBeFalse();
            text1.Is<UInt64>().ShouldBeTrue();
            text2.Is<UInt64>().ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is UInt64 type or not by generic type and ignore case test")]
        public void JudgingStringIsUInt64TypeByGenericTypeAndWithIgnoreCaseTest()
        {
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";

            text0.Is<UInt64>(Context).ShouldBeFalse();
            text1.Is<UInt64>(Context).ShouldBeTrue();
            text2.Is<UInt64>(Context).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge null or empty string is UInt64 type or not test")]
        public void JudgingNullOrEmptyStringIsUInt64TypeTest()
        {
            var type = typeof(UInt64);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "1.1";
            string text4 = "C";

            text0.Is(type).ShouldBeFalse();
            text1.Is(type).ShouldBeFalse();
            text2.Is(type).ShouldBeFalse();
            text3.Is(type).ShouldBeFalse();
            text4.Is(type).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is UInt64 type or not and ignore case test")]
        public void JudgingNullOrEmptyStringIsUInt64TypeWithIgnoreCaseTest()
        {
            var type = typeof(UInt64);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "1.1";
            string text4 = "C";

            text0.Is(type, Context).ShouldBeFalse();
            text1.Is(type, Context).ShouldBeFalse();
            text2.Is(type, Context).ShouldBeFalse();
            text3.Is(type, Context).ShouldBeFalse();
            text4.Is(type, Context).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is UInt64 type or not by generic type test")]
        public void JudgingNullOrEmptyStringIsUInt64TypeByGenericTypeTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "1.1";
            string text4 = "C";

            text0.Is<UInt64>().ShouldBeFalse();
            text1.Is<UInt64>().ShouldBeFalse();
            text2.Is<UInt64>().ShouldBeFalse();
            text3.Is<UInt64>().ShouldBeFalse();
            text4.Is<UInt64>().ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is UInt64 type or not by generic type and ignore case test")]
        public void JudgingNullOrEmptyStringIsUInt64TypeByGenericTypeAndWithIgnoreCaseTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "1.1";
            string text4 = "C";

            text0.Is<UInt64>(Context).ShouldBeFalse();
            text1.Is<UInt64>(Context).ShouldBeFalse();
            text2.Is<UInt64>(Context).ShouldBeFalse();
            text3.Is<UInt64>(Context).ShouldBeFalse();
            text4.Is<UInt64>(Context).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge string is nullable UInt64 type or not test")]
        public void JudgingStringIsNullableUInt64TypeTest()
        {
            var type = typeof(UInt64);
            var nullableType = typeof(UInt64?);
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";

            text0.Is(type).ShouldBeFalse();
            text1.Is(type).ShouldBeTrue();
            text2.Is(type).ShouldBeTrue();

            text0.Is(nullableType).ShouldBeFalse();
            text1.Is(nullableType).ShouldBeTrue();
            text2.Is(nullableType).ShouldBeTrue();

            text0.IsNullable(type).ShouldBeFalse();
            text1.IsNullable(type).ShouldBeTrue();
            text2.IsNullable(type).ShouldBeTrue();

            text0.IsNullable(nullableType).ShouldBeFalse();
            text1.IsNullable(nullableType).ShouldBeTrue();
            text2.IsNullable(nullableType).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable UInt64 type or not and ignore case test")]
        public void JudgingStringIsNullableUInt64TypeWithIgnoreCaseTest()
        {
            var type = typeof(UInt64);
            var nullableType = typeof(UInt64?);
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";

            text0.Is(type, Context).ShouldBeFalse();
            text1.Is(type, Context).ShouldBeTrue();
            text2.Is(type, Context).ShouldBeTrue();

            text0.Is(nullableType, Context).ShouldBeFalse();
            text1.Is(nullableType, Context).ShouldBeTrue();
            text2.Is(nullableType, Context).ShouldBeTrue();

            text0.IsNullable(type, Context).ShouldBeFalse();
            text1.IsNullable(type, Context).ShouldBeTrue();
            text2.IsNullable(type, Context).ShouldBeTrue();

            text0.IsNullable(nullableType, Context).ShouldBeFalse();
            text1.IsNullable(nullableType, Context).ShouldBeTrue();
            text2.IsNullable(nullableType, Context).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable UInt64 type or not by generic type test")]
        public void JudgingStringIsNullableUInt64TypeByGenericTypeTest()
        {
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";

            text0.Is<UInt64>().ShouldBeFalse();
            text1.Is<UInt64>().ShouldBeTrue();
            text2.Is<UInt64>().ShouldBeTrue();

            text0.Is<UInt64?>().ShouldBeFalse();
            text1.Is<UInt64?>().ShouldBeTrue();
            text2.Is<UInt64?>().ShouldBeTrue();

            text0.IsNullable<UInt64>().ShouldBeFalse();
            text1.IsNullable<UInt64>().ShouldBeTrue();
            text2.IsNullable<UInt64>().ShouldBeTrue();

            text0.IsNullable<UInt64?>().ShouldBeFalse();
            text1.IsNullable<UInt64?>().ShouldBeTrue();
            text2.IsNullable<UInt64?>().ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable UInt64 type or not by generic type and ignore case test")]
        public void JudgingStringIsNullableUInt64TypeByGenericTypeAndWithIgnoreCaseTest()
        {
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";

            text0.Is<UInt64>(Context).ShouldBeFalse();
            text1.Is<UInt64>(Context).ShouldBeTrue();
            text2.Is<UInt64>(Context).ShouldBeTrue();

            text0.Is<UInt64?>(Context).ShouldBeFalse();
            text1.Is<UInt64?>(Context).ShouldBeTrue();
            text2.Is<UInt64?>(Context).ShouldBeTrue();

            text0.IsNullable<UInt64>(Context).ShouldBeFalse();
            text1.IsNullable<UInt64>(Context).ShouldBeTrue();
            text2.IsNullable<UInt64>(Context).ShouldBeTrue();

            text0.IsNullable<UInt64?>(Context).ShouldBeFalse();
            text1.IsNullable<UInt64?>(Context).ShouldBeTrue();
            text2.IsNullable<UInt64?>(Context).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable UInt64 type or not test")]
        public void JudgingNullOrEmptyStringIsNullableUInt64TypeTest()
        {
            var type = typeof(UInt64);
            var nullableType = typeof(UInt64?);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "1.1";
            string text4 = "C";

            text0.Is(type).ShouldBeFalse();
            text1.Is(type).ShouldBeFalse();
            text2.Is(type).ShouldBeFalse();
            text3.Is(type).ShouldBeFalse();
            text4.Is(type).ShouldBeFalse();

            text0.Is(nullableType).ShouldBeTrue();
            text1.Is(nullableType).ShouldBeFalse();
            text2.Is(nullableType).ShouldBeFalse();
            text3.Is(nullableType).ShouldBeFalse();
            text4.Is(nullableType).ShouldBeFalse();

            text0.IsNullable(type).ShouldBeTrue();
            text1.IsNullable(type).ShouldBeFalse();
            text2.IsNullable(type).ShouldBeFalse();
            text3.IsNullable(type).ShouldBeFalse();
            text4.IsNullable(type).ShouldBeFalse();

            text0.IsNullable(nullableType).ShouldBeTrue();
            text1.IsNullable(nullableType).ShouldBeFalse();
            text2.IsNullable(nullableType).ShouldBeFalse();
            text3.IsNullable(nullableType).ShouldBeFalse();
            text4.IsNullable(nullableType).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable UInt64 type or not and ignore case test")]
        public void JudgingNullOrEmptyStringIsNullableUInt64TypeWithIgnoreCaseTest()
        {
            var type = typeof(UInt64);
            var nullableType = typeof(UInt64?);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "1.1";
            string text4 = "C";

            text0.Is(type, Context).ShouldBeFalse();
            text1.Is(type, Context).ShouldBeFalse();
            text2.Is(type, Context).ShouldBeFalse();
            text3.Is(type, Context).ShouldBeFalse();
            text4.Is(type, Context).ShouldBeFalse();

            text0.Is(nullableType, Context).ShouldBeTrue();
            text1.Is(nullableType, Context).ShouldBeFalse();
            text2.Is(nullableType, Context).ShouldBeFalse();
            text3.Is(nullableType, Context).ShouldBeFalse();
            text4.Is(nullableType, Context).ShouldBeFalse();

            text0.IsNullable(type, Context).ShouldBeTrue();
            text1.IsNullable(type, Context).ShouldBeFalse();
            text2.IsNullable(type, Context).ShouldBeFalse();
            text3.IsNullable(type, Context).ShouldBeFalse();
            text4.IsNullable(type, Context).ShouldBeFalse();

            text0.IsNullable(nullableType, Context).ShouldBeTrue();
            text1.IsNullable(nullableType, Context).ShouldBeFalse();
            text2.IsNullable(nullableType, Context).ShouldBeFalse();
            text3.IsNullable(nullableType, Context).ShouldBeFalse();
            text4.IsNullable(nullableType, Context).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable UInt64 type or not by generic type test")]
        public void JudgingNullOrEmptyStringIsNullableUInt64TypeByGenericTypeTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "1.1";
            string text4 = "C";

            text0.Is<UInt64?>().ShouldBeTrue();
            text1.Is<UInt64?>().ShouldBeFalse();
            text2.Is<UInt64?>().ShouldBeFalse();
            text3.Is<UInt64?>().ShouldBeFalse();
            text4.Is<UInt64?>().ShouldBeFalse();

            text0.IsNullable<UInt64>().ShouldBeTrue();
            text1.IsNullable<UInt64>().ShouldBeFalse();
            text2.IsNullable<UInt64>().ShouldBeFalse();
            text3.IsNullable<UInt64>().ShouldBeFalse();
            text4.IsNullable<UInt64>().ShouldBeFalse();

            text0.IsNullable<UInt64?>().ShouldBeTrue();
            text1.IsNullable<UInt64?>().ShouldBeFalse();
            text2.IsNullable<UInt64?>().ShouldBeFalse();
            text3.IsNullable<UInt64?>().ShouldBeFalse();
            text4.IsNullable<UInt64?>().ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable UInt64 type or not by generic type and ignore case test")]
        public void JudgingNullOrEmptyStringIsNullableUInt64TypeByGenericTypeAndWithIgnoreCaseTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "1.1";
            string text4 = "C";

            text0.Is<UInt64?>(Context).ShouldBeTrue();
            text1.Is<UInt64?>(Context).ShouldBeFalse();
            text2.Is<UInt64?>(Context).ShouldBeFalse();
            text3.Is<UInt64?>(Context).ShouldBeFalse();
            text4.Is<UInt64?>(Context).ShouldBeFalse();

            text0.IsNullable<UInt64>(Context).ShouldBeTrue();
            text1.IsNullable<UInt64>(Context).ShouldBeFalse();
            text2.IsNullable<UInt64>(Context).ShouldBeFalse();
            text3.IsNullable<UInt64>(Context).ShouldBeFalse();
            text4.IsNullable<UInt64>(Context).ShouldBeFalse();

            text0.IsNullable<UInt64?>(Context).ShouldBeTrue();
            text1.IsNullable<UInt64?>(Context).ShouldBeFalse();
            text2.IsNullable<UInt64?>(Context).ShouldBeFalse();
            text3.IsNullable<UInt64?>(Context).ShouldBeFalse();
            text4.IsNullable<UInt64?>(Context).ShouldBeFalse();
        }
    }
}