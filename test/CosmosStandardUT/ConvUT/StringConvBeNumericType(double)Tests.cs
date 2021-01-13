using System;
using Cosmos.Conversions;
using Cosmos.Text;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.ConvUT
{
    [Trait("ConvUT", "StringConv.JudgeIsNumeric(Double)")]
    public class StringConvBeDoubleTypeTests
    {
        public StringConvBeDoubleTypeTests()
        {
            Context = new CastingContext
            {
                IgnoreCase = IgnoreCase.TRUE
            };
        }

        private CastingContext Context { get; set; }

        [Fact(DisplayName = "To judge string is Double type or not test")]
        public void JudgingStringIsDoubleTypeTest()
        {
            var type = typeof(Double);
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";
            var text3 = "-1.1";
            var text4 = "1.1";

            text0.Is(type).ShouldBeTrue();
            text1.Is(type).ShouldBeTrue();
            text2.Is(type).ShouldBeTrue();
            text3.Is(type).ShouldBeTrue();
            text4.Is(type).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is Double type or not and ignore case test")]
        public void JudgingStringIsDoubleTypeWithIgnoreCaseTest()
        {
            var type = typeof(Double);
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";
            var text3 = "-1.1";
            var text4 = "1.1";

            text0.Is(type, Context).ShouldBeTrue();
            text1.Is(type, Context).ShouldBeTrue();
            text2.Is(type, Context).ShouldBeTrue();
            text3.Is(type, Context).ShouldBeTrue();
            text4.Is(type, Context).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is Double type or not by generic type test")]
        public void JudgingStringIsDoubleTypeByGenericTypeTest()
        {
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";
            var text3 = "-1.1";
            var text4 = "1.1";

            text0.Is<Double>().ShouldBeTrue();
            text1.Is<Double>().ShouldBeTrue();
            text2.Is<Double>().ShouldBeTrue();
            text3.Is<Double>().ShouldBeTrue();
            text4.Is<Double>().ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is Double type or not by generic type and ignore case test")]
        public void JudgingStringIsDoubleTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";
            var text3 = "-1.1";
            var text4 = "1.1";

            text0.Is<Double>(Context).ShouldBeTrue();
            text1.Is<Double>(Context).ShouldBeTrue();
            text2.Is<Double>(Context).ShouldBeTrue();
            text3.Is<Double>(Context).ShouldBeTrue();
            text4.Is<Double>(Context).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge null or empty string is Double type or not test")]
        public void JudgingNullOrEmptyStringIsDoubleTypeTest()
        {
            var type = typeof(Double);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "C";

            text0.Is(type).ShouldBeFalse();
            text1.Is(type).ShouldBeFalse();
            text2.Is(type).ShouldBeFalse();
            text3.Is(type).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is Double type or not and ignore case test")]
        public void JudgingNullOrEmptyStringIsDoubleTypeWithIgnoreCaseTest()
        {
            var type = typeof(Double);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "C";

            text0.Is(type, Context).ShouldBeFalse();
            text1.Is(type, Context).ShouldBeFalse();
            text2.Is(type, Context).ShouldBeFalse();
            text3.Is(type, Context).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is Double type or not by generic type test")]
        public void JudgingNullOrEmptyStringIsDoubleTypeByGenericTypeTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "C";

            text0.Is<Double>().ShouldBeFalse();
            text1.Is<Double>().ShouldBeFalse();
            text2.Is<Double>().ShouldBeFalse();
            text3.Is<Double>().ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is Double type or not by generic type and ignore case test")]
        public void JudgingNullOrEmptyStringIsDoubleTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "C";

            text0.Is<Double>(Context).ShouldBeFalse();
            text1.Is<Double>(Context).ShouldBeFalse();
            text2.Is<Double>(Context).ShouldBeFalse();
            text3.Is<Double>(Context).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge string is nullable Double type or not test")]
        public void JudgingStringIsNullableDoubleTypeTest()
        {
            var type = typeof(Double);
            var nullableType = typeof(Double?);
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";
            var text3 = "-1.1";
            var text4 = "1.1";

            text0.Is(type).ShouldBeTrue();
            text1.Is(type).ShouldBeTrue();
            text2.Is(type).ShouldBeTrue();
            text3.Is(type).ShouldBeTrue();
            text4.Is(type).ShouldBeTrue();

            text0.Is(nullableType).ShouldBeTrue();
            text1.Is(nullableType).ShouldBeTrue();
            text2.Is(nullableType).ShouldBeTrue();
            text3.Is(nullableType).ShouldBeTrue();
            text4.Is(nullableType).ShouldBeTrue();

            text0.IsNullable(type).ShouldBeTrue();
            text1.IsNullable(type).ShouldBeTrue();
            text2.IsNullable(type).ShouldBeTrue();
            text3.IsNullable(type).ShouldBeTrue();
            text4.IsNullable(type).ShouldBeTrue();

            text0.IsNullable(nullableType).ShouldBeTrue();
            text1.IsNullable(nullableType).ShouldBeTrue();
            text2.IsNullable(nullableType).ShouldBeTrue();
            text3.IsNullable(nullableType).ShouldBeTrue();
            text4.IsNullable(nullableType).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable Double type or not and ignore case test")]
        public void JudgingStringIsNullableDoubleTypeWithIgnoreCaseTest()
        {
            var type = typeof(Double);
            var nullableType = typeof(Double?);
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";
            var text3 = "-1.1";
            var text4 = "1.1";

            text0.Is(type, Context).ShouldBeTrue();
            text1.Is(type, Context).ShouldBeTrue();
            text2.Is(type, Context).ShouldBeTrue();
            text3.Is(type, Context).ShouldBeTrue();
            text4.Is(type, Context).ShouldBeTrue();

            text0.Is(nullableType, Context).ShouldBeTrue();
            text1.Is(nullableType, Context).ShouldBeTrue();
            text2.Is(nullableType, Context).ShouldBeTrue();
            text3.Is(nullableType, Context).ShouldBeTrue();
            text4.Is(nullableType, Context).ShouldBeTrue();

            text0.IsNullable(type, Context).ShouldBeTrue();
            text1.IsNullable(type, Context).ShouldBeTrue();
            text2.IsNullable(type, Context).ShouldBeTrue();
            text3.IsNullable(type, Context).ShouldBeTrue();
            text4.IsNullable(type, Context).ShouldBeTrue();

            text0.IsNullable(nullableType, Context).ShouldBeTrue();
            text1.IsNullable(nullableType, Context).ShouldBeTrue();
            text2.IsNullable(nullableType, Context).ShouldBeTrue();
            text3.IsNullable(nullableType, Context).ShouldBeTrue();
            text4.IsNullable(nullableType, Context).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable Double type or not by generic type test")]
        public void JudgingStringIsNullableDoubleTypeByGenericTypeTest()
        {
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";
            var text3 = "-1.1";
            var text4 = "1.1";

            text0.Is<Double>().ShouldBeTrue();
            text1.Is<Double>().ShouldBeTrue();
            text2.Is<Double>().ShouldBeTrue();
            text3.Is<Double>().ShouldBeTrue();
            text4.Is<Double>().ShouldBeTrue();

            text0.Is<Double?>().ShouldBeTrue();
            text1.Is<Double?>().ShouldBeTrue();
            text2.Is<Double?>().ShouldBeTrue();
            text3.Is<Double?>().ShouldBeTrue();
            text4.Is<Double?>().ShouldBeTrue();

            text0.IsNullable<Double>().ShouldBeTrue();
            text1.IsNullable<Double>().ShouldBeTrue();
            text2.IsNullable<Double>().ShouldBeTrue();
            text3.IsNullable<Double>().ShouldBeTrue();
            text4.IsNullable<Double>().ShouldBeTrue();

            text0.IsNullable<Double?>().ShouldBeTrue();
            text1.IsNullable<Double?>().ShouldBeTrue();
            text2.IsNullable<Double?>().ShouldBeTrue();
            text3.IsNullable<Double?>().ShouldBeTrue();
            text4.IsNullable<Double?>().ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable Double type or not by generic type and ignore case test")]
        public void JudgingStringIsNullableDoubleTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";
            var text3 = "-1.1";
            var text4 = "1.1";

            text0.Is<Double>(Context).ShouldBeTrue();
            text1.Is<Double>(Context).ShouldBeTrue();
            text2.Is<Double>(Context).ShouldBeTrue();
            text3.Is<Double>(Context).ShouldBeTrue();
            text4.Is<Double>(Context).ShouldBeTrue();

            text0.Is<Double?>(Context).ShouldBeTrue();
            text1.Is<Double?>(Context).ShouldBeTrue();
            text2.Is<Double?>(Context).ShouldBeTrue();
            text3.Is<Double?>(Context).ShouldBeTrue();
            text4.Is<Double?>(Context).ShouldBeTrue();

            text0.IsNullable<Double>(Context).ShouldBeTrue();
            text1.IsNullable<Double>(Context).ShouldBeTrue();
            text2.IsNullable<Double>(Context).ShouldBeTrue();
            text3.IsNullable<Double>(Context).ShouldBeTrue();
            text4.IsNullable<Double>(Context).ShouldBeTrue();

            text0.IsNullable<Double?>(Context).ShouldBeTrue();
            text1.IsNullable<Double?>(Context).ShouldBeTrue();
            text2.IsNullable<Double?>(Context).ShouldBeTrue();
            text3.IsNullable<Double?>(Context).ShouldBeTrue();
            text4.IsNullable<Double?>(Context).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable Double type or not test")]
        public void JudgingNullOrEmptyStringIsNullableDoubleTypeTest()
        {
            var type = typeof(Double);
            var nullableType = typeof(Double?);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "C";

            text0.Is(type).ShouldBeFalse();
            text1.Is(type).ShouldBeFalse();
            text2.Is(type).ShouldBeFalse();
            text3.Is(type).ShouldBeFalse();

            text0.Is(nullableType).ShouldBeTrue();
            text1.Is(nullableType).ShouldBeFalse();
            text2.Is(nullableType).ShouldBeFalse();
            text3.Is(nullableType).ShouldBeFalse();

            text0.IsNullable(type).ShouldBeTrue();
            text1.IsNullable(type).ShouldBeFalse();
            text2.IsNullable(type).ShouldBeFalse();
            text3.IsNullable(type).ShouldBeFalse();

            text0.IsNullable(nullableType).ShouldBeTrue();
            text1.IsNullable(nullableType).ShouldBeFalse();
            text2.IsNullable(nullableType).ShouldBeFalse();
            text3.IsNullable(nullableType).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable Double type or not and ignore case test")]
        public void JudgingNullOrEmptyStringIsNullableDoubleTypeWithIgnoreCaseTest()
        {
            var type = typeof(Double);
            var nullableType = typeof(Double?);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "C";

            text0.Is(type, Context).ShouldBeFalse();
            text1.Is(type, Context).ShouldBeFalse();
            text2.Is(type, Context).ShouldBeFalse();
            text3.Is(type, Context).ShouldBeFalse();

            text0.Is(nullableType, Context).ShouldBeTrue();
            text1.Is(nullableType, Context).ShouldBeFalse();
            text2.Is(nullableType, Context).ShouldBeFalse();
            text3.Is(nullableType, Context).ShouldBeFalse();

            text0.IsNullable(type, Context).ShouldBeTrue();
            text1.IsNullable(type, Context).ShouldBeFalse();
            text2.IsNullable(type, Context).ShouldBeFalse();
            text3.IsNullable(type, Context).ShouldBeFalse();

            text0.IsNullable(nullableType, Context).ShouldBeTrue();
            text1.IsNullable(nullableType, Context).ShouldBeFalse();
            text2.IsNullable(nullableType, Context).ShouldBeFalse();
            text3.IsNullable(nullableType, Context).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable Double type or not by generic type test")]
        public void JudgingNullOrEmptyStringIsNullableDoubleTypeByGenericTypeTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "C";

            text0.Is<Double?>().ShouldBeTrue();
            text1.Is<Double?>().ShouldBeFalse();
            text2.Is<Double?>().ShouldBeFalse();
            text3.Is<Double?>().ShouldBeFalse();

            text0.IsNullable<Double>().ShouldBeTrue();
            text1.IsNullable<Double>().ShouldBeFalse();
            text2.IsNullable<Double>().ShouldBeFalse();
            text3.IsNullable<Double>().ShouldBeFalse();

            text0.IsNullable<Double?>().ShouldBeTrue();
            text1.IsNullable<Double?>().ShouldBeFalse();
            text2.IsNullable<Double?>().ShouldBeFalse();
            text3.IsNullable<Double?>().ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable Double type or not by generic type and ignore case test")]
        public void JudgingNullOrEmptyStringIsNullableDoubleTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "C";

            text0.Is<Double?>(Context).ShouldBeTrue();
            text1.Is<Double?>(Context).ShouldBeFalse();
            text2.Is<Double?>(Context).ShouldBeFalse();
            text3.Is<Double?>(Context).ShouldBeFalse();

            text0.IsNullable<Double>(Context).ShouldBeTrue();
            text1.IsNullable<Double>(Context).ShouldBeFalse();
            text2.IsNullable<Double>(Context).ShouldBeFalse();
            text3.IsNullable<Double>(Context).ShouldBeFalse();

            text0.IsNullable<Double?>(Context).ShouldBeTrue();
            text1.IsNullable<Double?>(Context).ShouldBeFalse();
            text2.IsNullable<Double?>(Context).ShouldBeFalse();
            text3.IsNullable<Double?>(Context).ShouldBeFalse();
        }
    }
}