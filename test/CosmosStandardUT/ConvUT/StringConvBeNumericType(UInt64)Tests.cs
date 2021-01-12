using System;
using Cosmos.Text;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.ConvUT
{
    [Trait("ConvUT", "StringConv.JudgeIsNumeric(UInt64)")]
    public class StringConvBeUInt64TypeTests
    {
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

            text0.Is(type, IgnoreCase.TRUE).ShouldBeFalse();
            text1.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text2.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
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

            text0.Is<UInt64>(IgnoreCase.TRUE).ShouldBeFalse();
            text1.Is<UInt64>(IgnoreCase.TRUE).ShouldBeTrue();
            text2.Is<UInt64>(IgnoreCase.TRUE).ShouldBeTrue();
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

            text0.Is(type, IgnoreCase.TRUE).ShouldBeFalse();
            text1.Is(type, IgnoreCase.TRUE).ShouldBeFalse();
            text2.Is(type, IgnoreCase.TRUE).ShouldBeFalse();
            text3.Is(type, IgnoreCase.TRUE).ShouldBeFalse();
            text4.Is(type, IgnoreCase.TRUE).ShouldBeFalse();
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

            text0.Is<UInt64>(IgnoreCase.TRUE).ShouldBeFalse();
            text1.Is<UInt64>(IgnoreCase.TRUE).ShouldBeFalse();
            text2.Is<UInt64>(IgnoreCase.TRUE).ShouldBeFalse();
            text3.Is<UInt64>(IgnoreCase.TRUE).ShouldBeFalse();
            text4.Is<UInt64>(IgnoreCase.TRUE).ShouldBeFalse();
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

            text0.Is(type, IgnoreCase.TRUE).ShouldBeFalse();
            text1.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text2.Is(type, IgnoreCase.TRUE).ShouldBeTrue();

            text0.Is(nullableType, IgnoreCase.TRUE).ShouldBeFalse();
            text1.Is(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text2.Is(nullableType, IgnoreCase.TRUE).ShouldBeTrue();

            text0.IsNullable(type, IgnoreCase.TRUE).ShouldBeFalse();
            text1.IsNullable(type, IgnoreCase.TRUE).ShouldBeTrue();
            text2.IsNullable(type, IgnoreCase.TRUE).ShouldBeTrue();

            text0.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeFalse();
            text1.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text2.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
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

            text0.Is<UInt64>(IgnoreCase.TRUE).ShouldBeFalse();
            text1.Is<UInt64>(IgnoreCase.TRUE).ShouldBeTrue();
            text2.Is<UInt64>(IgnoreCase.TRUE).ShouldBeTrue();

            text0.Is<UInt64?>(IgnoreCase.TRUE).ShouldBeFalse();
            text1.Is<UInt64?>(IgnoreCase.TRUE).ShouldBeTrue();
            text2.Is<UInt64?>(IgnoreCase.TRUE).ShouldBeTrue();

            text0.IsNullable<UInt64>(IgnoreCase.TRUE).ShouldBeFalse();
            text1.IsNullable<UInt64>(IgnoreCase.TRUE).ShouldBeTrue();
            text2.IsNullable<UInt64>(IgnoreCase.TRUE).ShouldBeTrue();

            text0.IsNullable<UInt64?>(IgnoreCase.TRUE).ShouldBeFalse();
            text1.IsNullable<UInt64?>(IgnoreCase.TRUE).ShouldBeTrue();
            text2.IsNullable<UInt64?>(IgnoreCase.TRUE).ShouldBeTrue();
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

            text0.Is(type, IgnoreCase.TRUE).ShouldBeFalse();
            text1.Is(type, IgnoreCase.TRUE).ShouldBeFalse();
            text2.Is(type, IgnoreCase.TRUE).ShouldBeFalse();
            text3.Is(type, IgnoreCase.TRUE).ShouldBeFalse();
            text4.Is(type, IgnoreCase.TRUE).ShouldBeFalse();

            text0.Is(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text1.Is(nullableType, IgnoreCase.TRUE).ShouldBeFalse();
            text2.Is(nullableType, IgnoreCase.TRUE).ShouldBeFalse();
            text3.Is(nullableType, IgnoreCase.TRUE).ShouldBeFalse();
            text4.Is(nullableType, IgnoreCase.TRUE).ShouldBeFalse();

            text0.IsNullable(type, IgnoreCase.TRUE).ShouldBeTrue();
            text1.IsNullable(type, IgnoreCase.TRUE).ShouldBeFalse();
            text2.IsNullable(type, IgnoreCase.TRUE).ShouldBeFalse();
            text3.IsNullable(type, IgnoreCase.TRUE).ShouldBeFalse();
            text4.IsNullable(type, IgnoreCase.TRUE).ShouldBeFalse();

            text0.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text1.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeFalse();
            text2.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeFalse();
            text3.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeFalse();
            text4.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeFalse();
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

            text0.Is<UInt64?>(IgnoreCase.TRUE).ShouldBeTrue();
            text1.Is<UInt64?>(IgnoreCase.TRUE).ShouldBeFalse();
            text2.Is<UInt64?>(IgnoreCase.TRUE).ShouldBeFalse();
            text3.Is<UInt64?>(IgnoreCase.TRUE).ShouldBeFalse();
            text4.Is<UInt64?>(IgnoreCase.TRUE).ShouldBeFalse();

            text0.IsNullable<UInt64>(IgnoreCase.TRUE).ShouldBeTrue();
            text1.IsNullable<UInt64>(IgnoreCase.TRUE).ShouldBeFalse();
            text2.IsNullable<UInt64>(IgnoreCase.TRUE).ShouldBeFalse();
            text3.IsNullable<UInt64>(IgnoreCase.TRUE).ShouldBeFalse();
            text4.IsNullable<UInt64>(IgnoreCase.TRUE).ShouldBeFalse();

            text0.IsNullable<UInt64?>(IgnoreCase.TRUE).ShouldBeTrue();
            text1.IsNullable<UInt64?>(IgnoreCase.TRUE).ShouldBeFalse();
            text2.IsNullable<UInt64?>(IgnoreCase.TRUE).ShouldBeFalse();
            text3.IsNullable<UInt64?>(IgnoreCase.TRUE).ShouldBeFalse();
            text4.IsNullable<UInt64?>(IgnoreCase.TRUE).ShouldBeFalse();
        }
    }
}