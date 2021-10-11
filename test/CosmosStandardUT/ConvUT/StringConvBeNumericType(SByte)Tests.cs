using System;
using CosmosStack.Conversions;
using CosmosStack.Text;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.ConvUT
{
    [Trait("ConvUT", "StringConv.JudgeIsNumeric(SByte)")]
    public class StringConvBeSByteTypeTests
    {
        public StringConvBeSByteTypeTests()
        {
            Context = new CastingContext
            {
                IgnoreCase = IgnoreCase.TRUE
            };
        }

        private CastingContext Context { get; set; }

        [Fact(DisplayName = "To judge string is SByte type or not test")]
        public void JudgingStringIsSByteTypeTest()
        {
            var type = typeof(SByte);
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";

            text0.Is(type).ShouldBeTrue();
            text1.Is(type).ShouldBeTrue();
            text2.Is(type).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is SByte type or not and ignore case test")]
        public void JudgingStringIsSByteTypeWithIgnoreCaseTest()
        {
            var type = typeof(SByte);
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";

            text0.Is(type, Context).ShouldBeTrue();
            text1.Is(type, Context).ShouldBeTrue();
            text2.Is(type, Context).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is SByte type or not by generic type test")]
        public void JudgingStringIsSByteTypeByGenericTypeTest()
        {
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";

            text0.Is<SByte>().ShouldBeTrue();
            text1.Is<SByte>().ShouldBeTrue();
            text2.Is<SByte>().ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is SByte type or not by generic type and ignore case test")]
        public void JudgingStringIsSByteTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";

            text0.Is<SByte>(Context).ShouldBeTrue();
            text1.Is<SByte>(Context).ShouldBeTrue();
            text2.Is<SByte>(Context).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge null or empty string is SByte type or not test")]
        public void JudgingNullOrEmptyStringIsSByteTypeTest()
        {
            var type = typeof(SByte);
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

        [Fact(DisplayName = "To judge null or empty string is SByte type or not and ignore case test")]
        public void JudgingNullOrEmptyStringIsSByteTypeWithIgnoreCaseTest()
        {
            var type = typeof(SByte);
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

        [Fact(DisplayName = "To judge null or empty string is SByte type or not by generic type test")]
        public void JudgingNullOrEmptyStringIsSByteTypeByGenericTypeTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "1.1";
            string text4 = "C";

            text0.Is<SByte>().ShouldBeFalse();
            text1.Is<SByte>().ShouldBeFalse();
            text2.Is<SByte>().ShouldBeFalse();
            text3.Is<SByte>().ShouldBeFalse();
            text4.Is<SByte>().ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is SByte type or not by generic type and ignore case test")]
        public void JudgingNullOrEmptyStringIsSByteTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "1.1";
            string text4 = "C";

            text0.Is<SByte>(Context).ShouldBeFalse();
            text1.Is<SByte>(Context).ShouldBeFalse();
            text2.Is<SByte>(Context).ShouldBeFalse();
            text3.Is<SByte>(Context).ShouldBeFalse();
            text4.Is<SByte>(Context).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge string is nullable SByte type or not test")]
        public void JudgingStringIsNullableSByteTypeTest()
        {
            var type = typeof(SByte);
            var nullableType = typeof(SByte?);
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";

            text0.Is(type).ShouldBeTrue();
            text1.Is(type).ShouldBeTrue();
            text2.Is(type).ShouldBeTrue();

            text0.Is(nullableType).ShouldBeTrue();
            text1.Is(nullableType).ShouldBeTrue();
            text2.Is(nullableType).ShouldBeTrue();

            text0.IsNullable(type).ShouldBeTrue();
            text1.IsNullable(type).ShouldBeTrue();
            text2.IsNullable(type).ShouldBeTrue();

            text0.IsNullable(nullableType).ShouldBeTrue();
            text1.IsNullable(nullableType).ShouldBeTrue();
            text2.IsNullable(nullableType).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable SByte type or not and ignore case test")]
        public void JudgingStringIsNullableSByteTypeWithIgnoreCaseTest()
        {
            var type = typeof(SByte);
            var nullableType = typeof(SByte?);
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";

            text0.Is(type, Context).ShouldBeTrue();
            text1.Is(type, Context).ShouldBeTrue();
            text2.Is(type, Context).ShouldBeTrue();

            text0.Is(nullableType, Context).ShouldBeTrue();
            text1.Is(nullableType, Context).ShouldBeTrue();
            text2.Is(nullableType, Context).ShouldBeTrue();

            text0.IsNullable(type, Context).ShouldBeTrue();
            text1.IsNullable(type, Context).ShouldBeTrue();
            text2.IsNullable(type, Context).ShouldBeTrue();

            text0.IsNullable(nullableType, Context).ShouldBeTrue();
            text1.IsNullable(nullableType, Context).ShouldBeTrue();
            text2.IsNullable(nullableType, Context).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable SByte type or not by generic type test")]
        public void JudgingStringIsNullableSByteTypeByGenericTypeTest()
        {
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";

            text0.Is<SByte>().ShouldBeTrue();
            text1.Is<SByte>().ShouldBeTrue();
            text2.Is<SByte>().ShouldBeTrue();

            text0.Is<SByte?>().ShouldBeTrue();
            text1.Is<SByte?>().ShouldBeTrue();
            text2.Is<SByte?>().ShouldBeTrue();

            text0.IsNullable<SByte>().ShouldBeTrue();
            text1.IsNullable<SByte>().ShouldBeTrue();
            text2.IsNullable<SByte>().ShouldBeTrue();

            text0.IsNullable<SByte?>().ShouldBeTrue();
            text1.IsNullable<SByte?>().ShouldBeTrue();
            text2.IsNullable<SByte?>().ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable SByte type or not by generic type and ignore case test")]
        public void JudgingStringIsNullableSByteTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";

            text0.Is<SByte>(Context).ShouldBeTrue();
            text1.Is<SByte>(Context).ShouldBeTrue();
            text2.Is<SByte>(Context).ShouldBeTrue();

            text0.Is<SByte?>(Context).ShouldBeTrue();
            text1.Is<SByte?>(Context).ShouldBeTrue();
            text2.Is<SByte?>(Context).ShouldBeTrue();

            text0.IsNullable<SByte>(Context).ShouldBeTrue();
            text1.IsNullable<SByte>(Context).ShouldBeTrue();
            text2.IsNullable<SByte>(Context).ShouldBeTrue();

            text0.IsNullable<SByte?>(Context).ShouldBeTrue();
            text1.IsNullable<SByte?>(Context).ShouldBeTrue();
            text2.IsNullable<SByte?>(Context).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable SByte type or not test")]
        public void JudgingNullOrEmptyStringIsNullableSByteTypeTest()
        {
            var type = typeof(SByte);
            var nullableType = typeof(SByte?);
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

        [Fact(DisplayName = "To judge null or empty string is nullable SByte type or not and ignore case test")]
        public void JudgingNullOrEmptyStringIsNullableSByteTypeWithIgnoreCaseTest()
        {
            var type = typeof(SByte);
            var nullableType = typeof(SByte?);
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

        [Fact(DisplayName = "To judge null or empty string is nullable SByte type or not by generic type test")]
        public void JudgingNullOrEmptyStringIsNullableSByteTypeByGenericTypeTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "1.1";
            string text4 = "C";

            text0.Is<SByte?>().ShouldBeTrue();
            text1.Is<SByte?>().ShouldBeFalse();
            text2.Is<SByte?>().ShouldBeFalse();
            text3.Is<SByte?>().ShouldBeFalse();
            text4.Is<SByte?>().ShouldBeFalse();

            text0.IsNullable<SByte>().ShouldBeTrue();
            text1.IsNullable<SByte>().ShouldBeFalse();
            text2.IsNullable<SByte>().ShouldBeFalse();
            text3.IsNullable<SByte>().ShouldBeFalse();
            text4.IsNullable<SByte>().ShouldBeFalse();

            text0.IsNullable<SByte?>().ShouldBeTrue();
            text1.IsNullable<SByte?>().ShouldBeFalse();
            text2.IsNullable<SByte?>().ShouldBeFalse();
            text3.IsNullable<SByte?>().ShouldBeFalse();
            text4.IsNullable<SByte?>().ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable SByte type or not by generic type and ignore case test")]
        public void JudgingNullOrEmptyStringIsNullableSByteTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "1.1";
            string text4 = "C";

            text0.Is<SByte?>(Context).ShouldBeTrue();
            text1.Is<SByte?>(Context).ShouldBeFalse();
            text2.Is<SByte?>(Context).ShouldBeFalse();
            text3.Is<SByte?>(Context).ShouldBeFalse();
            text4.Is<SByte?>(Context).ShouldBeFalse();

            text0.IsNullable<SByte>(Context).ShouldBeTrue();
            text1.IsNullable<SByte>(Context).ShouldBeFalse();
            text2.IsNullable<SByte>(Context).ShouldBeFalse();
            text3.IsNullable<SByte>(Context).ShouldBeFalse();
            text4.IsNullable<SByte>(Context).ShouldBeFalse();

            text0.IsNullable<SByte?>(Context).ShouldBeTrue();
            text1.IsNullable<SByte?>(Context).ShouldBeFalse();
            text2.IsNullable<SByte?>(Context).ShouldBeFalse();
            text3.IsNullable<SByte?>(Context).ShouldBeFalse();
            text4.IsNullable<SByte?>(Context).ShouldBeFalse();
        }
    }
}