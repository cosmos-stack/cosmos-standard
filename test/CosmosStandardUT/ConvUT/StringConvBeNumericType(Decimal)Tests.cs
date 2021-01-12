using System;
using Cosmos.Text;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.ConvUT
{
    [Trait("ConvUT", "StringConv.JudgeIsNumeric(Decimal)")]
    public class StringConvBeDecimalTypeTests
    {
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

            text0.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text1.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text2.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text3.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text4.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
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

            text0.Is<Decimal>(IgnoreCase.TRUE).ShouldBeTrue();
            text1.Is<Decimal>(IgnoreCase.TRUE).ShouldBeTrue();
            text2.Is<Decimal>(IgnoreCase.TRUE).ShouldBeTrue();
            text3.Is<Decimal>(IgnoreCase.TRUE).ShouldBeTrue();
            text4.Is<Decimal>(IgnoreCase.TRUE).ShouldBeTrue();
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

            text0.Is(type, IgnoreCase.TRUE).ShouldBeFalse();
            text1.Is(type, IgnoreCase.TRUE).ShouldBeFalse();
            text2.Is(type, IgnoreCase.TRUE).ShouldBeFalse();
            text3.Is(type, IgnoreCase.TRUE).ShouldBeFalse();
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

            text0.Is<Decimal>(IgnoreCase.TRUE).ShouldBeFalse();
            text1.Is<Decimal>(IgnoreCase.TRUE).ShouldBeFalse();
            text2.Is<Decimal>(IgnoreCase.TRUE).ShouldBeFalse();
            text3.Is<Decimal>(IgnoreCase.TRUE).ShouldBeFalse();
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

            text0.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text1.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text2.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text3.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text4.Is(type, IgnoreCase.TRUE).ShouldBeTrue();

            text0.Is(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text1.Is(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text2.Is(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text3.Is(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text4.Is(nullableType, IgnoreCase.TRUE).ShouldBeTrue();

            text0.IsNullable(type, IgnoreCase.TRUE).ShouldBeTrue();
            text1.IsNullable(type, IgnoreCase.TRUE).ShouldBeTrue();
            text2.IsNullable(type, IgnoreCase.TRUE).ShouldBeTrue();
            text3.IsNullable(type, IgnoreCase.TRUE).ShouldBeTrue();
            text4.IsNullable(type, IgnoreCase.TRUE).ShouldBeTrue();

            text0.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text1.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text2.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text3.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text4.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
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

            text0.Is<Decimal>(IgnoreCase.TRUE).ShouldBeTrue();
            text1.Is<Decimal>(IgnoreCase.TRUE).ShouldBeTrue();
            text2.Is<Decimal>(IgnoreCase.TRUE).ShouldBeTrue();
            text3.Is<Decimal>(IgnoreCase.TRUE).ShouldBeTrue();
            text4.Is<Decimal>(IgnoreCase.TRUE).ShouldBeTrue();

            text0.Is<Decimal?>(IgnoreCase.TRUE).ShouldBeTrue();
            text1.Is<Decimal?>(IgnoreCase.TRUE).ShouldBeTrue();
            text2.Is<Decimal?>(IgnoreCase.TRUE).ShouldBeTrue();
            text3.Is<Decimal?>(IgnoreCase.TRUE).ShouldBeTrue();
            text4.Is<Decimal?>(IgnoreCase.TRUE).ShouldBeTrue();

            text0.IsNullable<Decimal>(IgnoreCase.TRUE).ShouldBeTrue();
            text1.IsNullable<Decimal>(IgnoreCase.TRUE).ShouldBeTrue();
            text2.IsNullable<Decimal>(IgnoreCase.TRUE).ShouldBeTrue();
            text3.IsNullable<Decimal>(IgnoreCase.TRUE).ShouldBeTrue();
            text4.IsNullable<Decimal>(IgnoreCase.TRUE).ShouldBeTrue();

            text0.IsNullable<Decimal?>(IgnoreCase.TRUE).ShouldBeTrue();
            text1.IsNullable<Decimal?>(IgnoreCase.TRUE).ShouldBeTrue();
            text2.IsNullable<Decimal?>(IgnoreCase.TRUE).ShouldBeTrue();
            text3.IsNullable<Decimal?>(IgnoreCase.TRUE).ShouldBeTrue();
            text4.IsNullable<Decimal?>(IgnoreCase.TRUE).ShouldBeTrue();
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

            text0.Is(type, IgnoreCase.TRUE).ShouldBeFalse();
            text1.Is(type, IgnoreCase.TRUE).ShouldBeFalse();
            text2.Is(type, IgnoreCase.TRUE).ShouldBeFalse();
            text3.Is(type, IgnoreCase.TRUE).ShouldBeFalse();

            text0.Is(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text1.Is(nullableType, IgnoreCase.TRUE).ShouldBeFalse();
            text2.Is(nullableType, IgnoreCase.TRUE).ShouldBeFalse();
            text3.Is(nullableType, IgnoreCase.TRUE).ShouldBeFalse();

            text0.IsNullable(type, IgnoreCase.TRUE).ShouldBeTrue();
            text1.IsNullable(type, IgnoreCase.TRUE).ShouldBeFalse();
            text2.IsNullable(type, IgnoreCase.TRUE).ShouldBeFalse();
            text3.IsNullable(type, IgnoreCase.TRUE).ShouldBeFalse();

            text0.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text1.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeFalse();
            text2.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeFalse();
            text3.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeFalse();
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

            text0.Is<Decimal?>(IgnoreCase.TRUE).ShouldBeTrue();
            text1.Is<Decimal?>(IgnoreCase.TRUE).ShouldBeFalse();
            text2.Is<Decimal?>(IgnoreCase.TRUE).ShouldBeFalse();
            text3.Is<Decimal?>(IgnoreCase.TRUE).ShouldBeFalse();

            text0.IsNullable<Decimal>(IgnoreCase.TRUE).ShouldBeTrue();
            text1.IsNullable<Decimal>(IgnoreCase.TRUE).ShouldBeFalse();
            text2.IsNullable<Decimal>(IgnoreCase.TRUE).ShouldBeFalse();
            text3.IsNullable<Decimal>(IgnoreCase.TRUE).ShouldBeFalse();

            text0.IsNullable<Decimal?>(IgnoreCase.TRUE).ShouldBeTrue();
            text1.IsNullable<Decimal?>(IgnoreCase.TRUE).ShouldBeFalse();
            text2.IsNullable<Decimal?>(IgnoreCase.TRUE).ShouldBeFalse();
            text3.IsNullable<Decimal?>(IgnoreCase.TRUE).ShouldBeFalse();
        }
    }
}