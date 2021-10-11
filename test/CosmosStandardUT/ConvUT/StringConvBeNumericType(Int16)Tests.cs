using System;
using CosmosStack.Conversions;
using CosmosStack.Text;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.ConvUT
{
    [Trait("ConvUT", "StringConv.JudgeIsNumeric(Int16)")]
    public class StringConvBeInt16TypeTests
    {
        public StringConvBeInt16TypeTests()
        {
            Context = new CastingContext
            {
                IgnoreCase = IgnoreCase.TRUE
            };
        }

        private CastingContext Context { get; set; }

        [Fact(DisplayName = "To judge string is Int16 type or not test")]
        public void JudgingStringIsInt16TypeTest()
        {
            var type = typeof(Int16);
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";

            text0.Is(type).ShouldBeTrue();
            text1.Is(type).ShouldBeTrue();
            text2.Is(type).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is Int16 type or not and ignore case test")]
        public void JudgingStringIsInt16TypeWithIgnoreCaseTest()
        {
            var type = typeof(Int16);
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";

            text0.Is(type, Context).ShouldBeTrue();
            text1.Is(type, Context).ShouldBeTrue();
            text2.Is(type, Context).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is Int16 type or not by generic type test")]
        public void JudgingStringIsInt16TypeByGenericTypeTest()
        {
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";

            text0.Is<Int16>().ShouldBeTrue();
            text1.Is<Int16>().ShouldBeTrue();
            text2.Is<Int16>().ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is Int16 type or not by generic type and ignore case test")]
        public void JudgingStringIsInt16TypeByGenericTypeAndWithIgnoreCaseTest()
        {
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";

            text0.Is<Int16>(Context).ShouldBeTrue();
            text1.Is<Int16>(Context).ShouldBeTrue();
            text2.Is<Int16>(Context).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge null or empty string is Int16 type or not test")]
        public void JudgingNullOrEmptyStringIsInt16TypeTest()
        {
            var type = typeof(Int16);
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

        [Fact(DisplayName = "To judge null or empty string is Int16 type or not and ignore case test")]
        public void JudgingNullOrEmptyStringIsInt16TypeWithIgnoreCaseTest()
        {
            var type = typeof(Int16);
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

        [Fact(DisplayName = "To judge null or empty string is Int16 type or not by generic type test")]
        public void JudgingNullOrEmptyStringIsInt16TypeByGenericTypeTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "1.1";
            string text4 = "C";

            text0.Is<Int16>().ShouldBeFalse();
            text1.Is<Int16>().ShouldBeFalse();
            text2.Is<Int16>().ShouldBeFalse();
            text3.Is<Int16>().ShouldBeFalse();
            text4.Is<Int16>().ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is Int16 type or not by generic type and ignore case test")]
        public void JudgingNullOrEmptyStringIsInt16TypeByGenericTypeAndWithIgnoreCaseTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "1.1";
            string text4 = "C";

            text0.Is<Int16>(Context).ShouldBeFalse();
            text1.Is<Int16>(Context).ShouldBeFalse();
            text2.Is<Int16>(Context).ShouldBeFalse();
            text3.Is<Int16>(Context).ShouldBeFalse();
            text4.Is<Int16>(Context).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge string is nullable Int16 type or not test")]
        public void JudgingStringIsNullableInt16TypeTest()
        {
            var type = typeof(Int16);
            var nullableType = typeof(Int16?);
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

        [Fact(DisplayName = "To judge string is nullable Int16 type or not and ignore case test")]
        public void JudgingStringIsNullableInt16TypeWithIgnoreCaseTest()
        {
            var type = typeof(Int16);
            var nullableType = typeof(Int16?);
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

        [Fact(DisplayName = "To judge string is nullable Int16 type or not by generic type test")]
        public void JudgingStringIsNullableInt16TypeByGenericTypeTest()
        {
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";

            text0.Is<Int16>().ShouldBeTrue();
            text1.Is<Int16>().ShouldBeTrue();
            text2.Is<Int16>().ShouldBeTrue();

            text0.Is<Int16?>().ShouldBeTrue();
            text1.Is<Int16?>().ShouldBeTrue();
            text2.Is<Int16?>().ShouldBeTrue();

            text0.IsNullable<Int16>().ShouldBeTrue();
            text1.IsNullable<Int16>().ShouldBeTrue();
            text2.IsNullable<Int16>().ShouldBeTrue();

            text0.IsNullable<Int16?>().ShouldBeTrue();
            text1.IsNullable<Int16?>().ShouldBeTrue();
            text2.IsNullable<Int16?>().ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable Int16 type or not by generic type and ignore case test")]
        public void JudgingStringIsNullableInt16TypeByGenericTypeAndWithIgnoreCaseTest()
        {
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";

            text0.Is<Int16>(Context).ShouldBeTrue();
            text1.Is<Int16>(Context).ShouldBeTrue();
            text2.Is<Int16>(Context).ShouldBeTrue();

            text0.Is<Int16?>(Context).ShouldBeTrue();
            text1.Is<Int16?>(Context).ShouldBeTrue();
            text2.Is<Int16?>(Context).ShouldBeTrue();

            text0.IsNullable<Int16>(Context).ShouldBeTrue();
            text1.IsNullable<Int16>(Context).ShouldBeTrue();
            text2.IsNullable<Int16>(Context).ShouldBeTrue();

            text0.IsNullable<Int16?>(Context).ShouldBeTrue();
            text1.IsNullable<Int16?>(Context).ShouldBeTrue();
            text2.IsNullable<Int16?>(Context).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable Int16 type or not test")]
        public void JudgingNullOrEmptyStringIsNullableInt16TypeTest()
        {
            var type = typeof(Int16);
            var nullableType = typeof(Int16?);
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

        [Fact(DisplayName = "To judge null or empty string is nullable Int16 type or not and ignore case test")]
        public void JudgingNullOrEmptyStringIsNullableInt16TypeWithIgnoreCaseTest()
        {
            var type = typeof(Int16);
            var nullableType = typeof(Int16?);
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

        [Fact(DisplayName = "To judge null or empty string is nullable Int16 type or not by generic type test")]
        public void JudgingNullOrEmptyStringIsNullableInt16TypeByGenericTypeTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "1.1";
            string text4 = "C";

            text0.Is<Int16?>().ShouldBeTrue();
            text1.Is<Int16?>().ShouldBeFalse();
            text2.Is<Int16?>().ShouldBeFalse();
            text3.Is<Int16?>().ShouldBeFalse();
            text4.Is<Int16?>().ShouldBeFalse();

            text0.IsNullable<Int16>().ShouldBeTrue();
            text1.IsNullable<Int16>().ShouldBeFalse();
            text2.IsNullable<Int16>().ShouldBeFalse();
            text3.IsNullable<Int16>().ShouldBeFalse();
            text4.IsNullable<Int16>().ShouldBeFalse();

            text0.IsNullable<Int16?>().ShouldBeTrue();
            text1.IsNullable<Int16?>().ShouldBeFalse();
            text2.IsNullable<Int16?>().ShouldBeFalse();
            text3.IsNullable<Int16?>().ShouldBeFalse();
            text4.IsNullable<Int16?>().ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable Int16 type or not by generic type and ignore case test")]
        public void JudgingNullOrEmptyStringIsNullableInt16TypeByGenericTypeAndWithIgnoreCaseTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "1.1";
            string text4 = "C";

            text0.Is<Int16?>(Context).ShouldBeTrue();
            text1.Is<Int16?>(Context).ShouldBeFalse();
            text2.Is<Int16?>(Context).ShouldBeFalse();
            text3.Is<Int16?>(Context).ShouldBeFalse();
            text4.Is<Int16?>(Context).ShouldBeFalse();

            text0.IsNullable<Int16>(Context).ShouldBeTrue();
            text1.IsNullable<Int16>(Context).ShouldBeFalse();
            text2.IsNullable<Int16>(Context).ShouldBeFalse();
            text3.IsNullable<Int16>(Context).ShouldBeFalse();
            text4.IsNullable<Int16>(Context).ShouldBeFalse();

            text0.IsNullable<Int16?>(Context).ShouldBeTrue();
            text1.IsNullable<Int16?>(Context).ShouldBeFalse();
            text2.IsNullable<Int16?>(Context).ShouldBeFalse();
            text3.IsNullable<Int16?>(Context).ShouldBeFalse();
            text4.IsNullable<Int16?>(Context).ShouldBeFalse();
        }
    }
}