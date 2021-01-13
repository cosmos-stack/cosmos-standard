using System;
using Cosmos.Conversions;
using Cosmos.Text;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.ConvUT
{
    [Trait("ConvUT", "StringConv.JudgeIsNumeric(Decimal)")]
    public class StringConvBeDecimalTypeTests
    {
        public StringConvBeDecimalTypeTests()
        {
            Context = new CastingContext
            {
                IgnoreCase = IgnoreCase.TRUE
            };
        }

        private CastingContext Context { get; set; }

        [Fact(DisplayName = "To judge string is Decimal type or not test")]
        public void JudgingStringIsDecimalTypeTest()
        {
            var type = typeof(Decimal);
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

        [Fact(DisplayName = "To judge string is Decimal type or not and ignore case test")]
        public void JudgingStringIsDecimalTypeWithIgnoreCaseTest()
        {
            var type = typeof(Decimal);
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

        [Fact(DisplayName = "To judge string is Decimal type or not by generic type test")]
        public void JudgingStringIsDecimalTypeByGenericTypeTest()
        {
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";
            var text3 = "-1.1";
            var text4 = "1.1";

            text0.Is<Decimal>().ShouldBeTrue();
            text1.Is<Decimal>().ShouldBeTrue();
            text2.Is<Decimal>().ShouldBeTrue();
            text3.Is<Decimal>().ShouldBeTrue();
            text4.Is<Decimal>().ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is Decimal type or not by generic type and ignore case test")]
        public void JudgingStringIsDecimalTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";
            var text3 = "-1.1";
            var text4 = "1.1";

            text0.Is<Decimal>(Context).ShouldBeTrue();
            text1.Is<Decimal>(Context).ShouldBeTrue();
            text2.Is<Decimal>(Context).ShouldBeTrue();
            text3.Is<Decimal>(Context).ShouldBeTrue();
            text4.Is<Decimal>(Context).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge null or empty string is Decimal type or not test")]
        public void JudgingNullOrEmptyStringIsDecimalTypeTest()
        {
            var type = typeof(Decimal);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "C";

            text0.Is(type).ShouldBeFalse();
            text1.Is(type).ShouldBeFalse();
            text2.Is(type).ShouldBeFalse();
            text3.Is(type).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is Decimal type or not and ignore case test")]
        public void JudgingNullOrEmptyStringIsDecimalTypeWithIgnoreCaseTest()
        {
            var type = typeof(Decimal);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "C";

            text0.Is(type, Context).ShouldBeFalse();
            text1.Is(type, Context).ShouldBeFalse();
            text2.Is(type, Context).ShouldBeFalse();
            text3.Is(type, Context).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is Decimal type or not by generic type test")]
        public void JudgingNullOrEmptyStringIsDecimalTypeByGenericTypeTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "C";

            text0.Is<Decimal>().ShouldBeFalse();
            text1.Is<Decimal>().ShouldBeFalse();
            text2.Is<Decimal>().ShouldBeFalse();
            text3.Is<Decimal>().ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is Decimal type or not by generic type and ignore case test")]
        public void JudgingNullOrEmptyStringIsDecimalTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "C";

            text0.Is<Decimal>(Context).ShouldBeFalse();
            text1.Is<Decimal>(Context).ShouldBeFalse();
            text2.Is<Decimal>(Context).ShouldBeFalse();
            text3.Is<Decimal>(Context).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge string is nullable Decimal type or not test")]
        public void JudgingStringIsNullableDecimalTypeTest()
        {
            var type = typeof(Decimal);
            var nullableType = typeof(Decimal?);
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

        [Fact(DisplayName = "To judge string is nullable Decimal type or not and ignore case test")]
        public void JudgingStringIsNullableDecimalTypeWithIgnoreCaseTest()
        {
            var type = typeof(Decimal);
            var nullableType = typeof(Decimal?);
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

        [Fact(DisplayName = "To judge string is nullable Decimal type or not by generic type test")]
        public void JudgingStringIsNullableDecimalTypeByGenericTypeTest()
        {
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";
            var text3 = "-1.1";
            var text4 = "1.1";

            text0.Is<Decimal>().ShouldBeTrue();
            text1.Is<Decimal>().ShouldBeTrue();
            text2.Is<Decimal>().ShouldBeTrue();
            text3.Is<Decimal>().ShouldBeTrue();
            text4.Is<Decimal>().ShouldBeTrue();

            text0.Is<Decimal?>().ShouldBeTrue();
            text1.Is<Decimal?>().ShouldBeTrue();
            text2.Is<Decimal?>().ShouldBeTrue();
            text3.Is<Decimal?>().ShouldBeTrue();
            text4.Is<Decimal?>().ShouldBeTrue();

            text0.IsNullable<Decimal>().ShouldBeTrue();
            text1.IsNullable<Decimal>().ShouldBeTrue();
            text2.IsNullable<Decimal>().ShouldBeTrue();
            text3.IsNullable<Decimal>().ShouldBeTrue();
            text4.IsNullable<Decimal>().ShouldBeTrue();

            text0.IsNullable<Decimal?>().ShouldBeTrue();
            text1.IsNullable<Decimal?>().ShouldBeTrue();
            text2.IsNullable<Decimal?>().ShouldBeTrue();
            text3.IsNullable<Decimal?>().ShouldBeTrue();
            text4.IsNullable<Decimal?>().ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable Decimal type or not by generic type and ignore case test")]
        public void JudgingStringIsNullableDecimalTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";
            var text3 = "-1.1";
            var text4 = "1.1";

            text0.Is<Decimal>(Context).ShouldBeTrue();
            text1.Is<Decimal>(Context).ShouldBeTrue();
            text2.Is<Decimal>(Context).ShouldBeTrue();
            text3.Is<Decimal>(Context).ShouldBeTrue();
            text4.Is<Decimal>(Context).ShouldBeTrue();

            text0.Is<Decimal?>(Context).ShouldBeTrue();
            text1.Is<Decimal?>(Context).ShouldBeTrue();
            text2.Is<Decimal?>(Context).ShouldBeTrue();
            text3.Is<Decimal?>(Context).ShouldBeTrue();
            text4.Is<Decimal?>(Context).ShouldBeTrue();

            text0.IsNullable<Decimal>(Context).ShouldBeTrue();
            text1.IsNullable<Decimal>(Context).ShouldBeTrue();
            text2.IsNullable<Decimal>(Context).ShouldBeTrue();
            text3.IsNullable<Decimal>(Context).ShouldBeTrue();
            text4.IsNullable<Decimal>(Context).ShouldBeTrue();

            text0.IsNullable<Decimal?>(Context).ShouldBeTrue();
            text1.IsNullable<Decimal?>(Context).ShouldBeTrue();
            text2.IsNullable<Decimal?>(Context).ShouldBeTrue();
            text3.IsNullable<Decimal?>(Context).ShouldBeTrue();
            text4.IsNullable<Decimal?>(Context).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable Decimal type or not test")]
        public void JudgingNullOrEmptyStringIsNullableDecimalTypeTest()
        {
            var type = typeof(Decimal);
            var nullableType = typeof(Decimal?);
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

        [Fact(DisplayName = "To judge null or empty string is nullable Decimal type or not and ignore case test")]
        public void JudgingNullOrEmptyStringIsNullableDecimalTypeWithIgnoreCaseTest()
        {
            var type = typeof(Decimal);
            var nullableType = typeof(Decimal?);
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

        [Fact(DisplayName = "To judge null or empty string is nullable Decimal type or not by generic type test")]
        public void JudgingNullOrEmptyStringIsNullableDecimalTypeByGenericTypeTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "C";

            text0.Is<Decimal?>().ShouldBeTrue();
            text1.Is<Decimal?>().ShouldBeFalse();
            text2.Is<Decimal?>().ShouldBeFalse();
            text3.Is<Decimal?>().ShouldBeFalse();

            text0.IsNullable<Decimal>().ShouldBeTrue();
            text1.IsNullable<Decimal>().ShouldBeFalse();
            text2.IsNullable<Decimal>().ShouldBeFalse();
            text3.IsNullable<Decimal>().ShouldBeFalse();

            text0.IsNullable<Decimal?>().ShouldBeTrue();
            text1.IsNullable<Decimal?>().ShouldBeFalse();
            text2.IsNullable<Decimal?>().ShouldBeFalse();
            text3.IsNullable<Decimal?>().ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable Decimal type or not by generic type and ignore case test")]
        public void JudgingNullOrEmptyStringIsNullableDecimalTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "C";

            text0.Is<Decimal?>(Context).ShouldBeTrue();
            text1.Is<Decimal?>(Context).ShouldBeFalse();
            text2.Is<Decimal?>(Context).ShouldBeFalse();
            text3.Is<Decimal?>(Context).ShouldBeFalse();

            text0.IsNullable<Decimal>(Context).ShouldBeTrue();
            text1.IsNullable<Decimal>(Context).ShouldBeFalse();
            text2.IsNullable<Decimal>(Context).ShouldBeFalse();
            text3.IsNullable<Decimal>(Context).ShouldBeFalse();

            text0.IsNullable<Decimal?>(Context).ShouldBeTrue();
            text1.IsNullable<Decimal?>(Context).ShouldBeFalse();
            text2.IsNullable<Decimal?>(Context).ShouldBeFalse();
            text3.IsNullable<Decimal?>(Context).ShouldBeFalse();
        }
    }
}