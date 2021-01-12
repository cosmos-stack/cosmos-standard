using System;
using Cosmos.Text;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.ConvUT
{
    [Trait("ConvUT", "StringConv.JudgeIsTimeSpan")]
    public class StringConvBeTimeSpanTypeTests
    {
        [Fact(DisplayName = "To judge string is TimeSpan type or not test")]
        public void JudgingStringIsTimeSpanTypeTest()
        {
            var type = typeof(TimeSpan);
            var today = DateTime.Today;
            var now = DateTime.Now;
            var span = now - today;
            var text0 = span.ToString("c");
            var text1 = span.ToString("g");
            var text2 = span.ToString("G");

            text0.Is(type).ShouldBeTrue();
            text1.Is(type).ShouldBeTrue();
            text2.Is(type).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is TimeSpan type or not and ignore case test")]
        public void JudgingStringIsTimeSpanTypeWithIgnoreCaseTest()
        {
            var type = typeof(TimeSpan);
            var today = DateTime.Today;
            var now = DateTime.Now;
            var span = now - today;
            var text0 = span.ToString("c");
            var text1 = span.ToString("g");
            var text2 = span.ToString("G");

            text0.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text1.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text2.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is TimeSpan type or not by generic type test")]
        public void JudgingStringIsTimeSpanTypeByGenericTypeTest()
        {
            var today = DateTime.Today;
            var now = DateTime.Now;
            var span = now - today;
            var text0 = span.ToString("c");
            var text1 = span.ToString("g");
            var text2 = span.ToString("G");

            text0.Is<TimeSpan>().ShouldBeTrue();
            text1.Is<TimeSpan>().ShouldBeTrue();
            text2.Is<TimeSpan>().ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is TimeSpan type or not by generic type and ignore case test")]
        public void JudgingStringIsTimeSpanTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            var today = DateTime.Today;
            var now = DateTime.Now;
            var span = now - today;
            var text0 = span.ToString("c");
            var text1 = span.ToString("g");
            var text2 = span.ToString("G");

            text0.Is<TimeSpan>(IgnoreCase.TRUE).ShouldBeTrue();
            text1.Is<TimeSpan>(IgnoreCase.TRUE).ShouldBeTrue();
            text2.Is<TimeSpan>(IgnoreCase.TRUE).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge null or empty string is TimeSpan type or not test")]
        public void JudgingNullOrEmptyStringIsTimeSpanTypeTest()
        {
            var type = typeof(TimeSpan);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";

            text0.Is(type).ShouldBeFalse();
            text1.Is(type).ShouldBeFalse();
            text2.Is(type).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is TimeSpan type or not and ignore case test")]
        public void JudgingNullOrEmptyStringIsTimeSpanTypeWithIgnoreCaseTest()
        {
            var type = typeof(TimeSpan);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";

            text0.Is(type, IgnoreCase.TRUE).ShouldBeFalse();
            text1.Is(type, IgnoreCase.TRUE).ShouldBeFalse();
            text2.Is(type, IgnoreCase.TRUE).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is TimeSpan type or not by generic type test")]
        public void JudgingNullOrEmptyStringIsTimeSpanTypeByGenericTypeTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";

            text0.Is<TimeSpan>().ShouldBeFalse();
            text1.Is<TimeSpan>().ShouldBeFalse();
            text2.Is<TimeSpan>().ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is TimeSpan type or not by generic type and ignore case test")]
        public void JudgingNullOrEmptyStringIsTimeSpanTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";

            text0.Is<TimeSpan>(IgnoreCase.TRUE).ShouldBeFalse();
            text1.Is<TimeSpan>(IgnoreCase.TRUE).ShouldBeFalse();
            text2.Is<TimeSpan>(IgnoreCase.TRUE).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge invalid string test")]
        public void JudgingInvalidStringTest()
        {
            var type = typeof(TimeSpan);
            var text0 = "D";
            var text1 = "2000-12-01";
            var text2 = "23:61:00.4560000";

            text0.Is(type).ShouldBeFalse();
            text0.Is(type, IgnoreCase.TRUE).ShouldBeFalse();

            text0.Is<TimeSpan>().ShouldBeFalse();
            text0.Is<TimeSpan>(IgnoreCase.TRUE).ShouldBeFalse();

            text1.Is(type).ShouldBeFalse();
            text1.Is(type, IgnoreCase.TRUE).ShouldBeFalse();

            text1.Is<TimeSpan>().ShouldBeFalse();
            text1.Is<TimeSpan>(IgnoreCase.TRUE).ShouldBeFalse();

            text2.Is(type).ShouldBeFalse();
            text2.Is(type, IgnoreCase.TRUE).ShouldBeFalse();

            text2.Is<TimeSpan>().ShouldBeFalse();
            text2.Is<TimeSpan>(IgnoreCase.TRUE).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge string is nullable TimeSpan type or not test")]
        public void JudgingStringIsNullableTimeSpanTypeTest()
        {
            var type = typeof(TimeSpan);
            var nullableType = typeof(TimeSpan?);
            var today = DateTime.Today;
            var now = DateTime.Now;
            var span = now - today;
            var text0 = span.ToString("c");
            var text1 = span.ToString("g");
            var text2 = span.ToString("G");

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

        [Fact(DisplayName = "To judge string is nullable TimeSpan type or not and ignore case test")]
        public void JudgingStringIsNullableTimeSpanTypeWithIgnoreCaseTest()
        {
            var type = typeof(TimeSpan);
            var nullableType = typeof(TimeSpan?);
            var today = DateTime.Today;
            var now = DateTime.Now;
            var span = now - today;
            var text0 = span.ToString("c");
            var text1 = span.ToString("g");
            var text2 = span.ToString("G");

            text0.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text1.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text2.Is(type, IgnoreCase.TRUE).ShouldBeTrue();

            text0.Is(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text1.Is(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text2.Is(nullableType, IgnoreCase.TRUE).ShouldBeTrue();

            text0.IsNullable(type, IgnoreCase.TRUE).ShouldBeTrue();
            text1.IsNullable(type, IgnoreCase.TRUE).ShouldBeTrue();
            text2.IsNullable(type, IgnoreCase.TRUE).ShouldBeTrue();

            text0.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text1.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text2.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable TimeSpan type or not by generic type test")]
        public void JudgingStringIsNullableTimeSpanTypeByGenericTypeTest()
        {
            var today = DateTime.Today;
            var now = DateTime.Now;
            var span = now - today;
            var text0 = span.ToString("c");
            var text1 = span.ToString("g");
            var text2 = span.ToString("G");

            text0.Is<TimeSpan>().ShouldBeTrue();
            text1.Is<TimeSpan>().ShouldBeTrue();
            text2.Is<TimeSpan>().ShouldBeTrue();

            text0.Is<TimeSpan?>().ShouldBeTrue();
            text1.Is<TimeSpan?>().ShouldBeTrue();
            text2.Is<TimeSpan?>().ShouldBeTrue();

            text0.IsNullable<TimeSpan>().ShouldBeTrue();
            text1.IsNullable<TimeSpan>().ShouldBeTrue();
            text2.IsNullable<TimeSpan>().ShouldBeTrue();

            text0.IsNullable<TimeSpan?>().ShouldBeTrue();
            text1.IsNullable<TimeSpan?>().ShouldBeTrue();
            text2.IsNullable<TimeSpan?>().ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable TimeSpan type or not by generic type and ignore case test")]
        public void JudgingStringIsNullableTimeSpanTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            var today = DateTime.Today;
            var now = DateTime.Now;
            var span = now - today;
            var text0 = span.ToString("c");
            var text1 = span.ToString("g");
            var text2 = span.ToString("G");

            text0.Is<TimeSpan>(IgnoreCase.TRUE).ShouldBeTrue();
            text1.Is<TimeSpan>(IgnoreCase.TRUE).ShouldBeTrue();
            text2.Is<TimeSpan>(IgnoreCase.TRUE).ShouldBeTrue();

            text0.Is<TimeSpan?>(IgnoreCase.TRUE).ShouldBeTrue();
            text1.Is<TimeSpan?>(IgnoreCase.TRUE).ShouldBeTrue();
            text2.Is<TimeSpan?>(IgnoreCase.TRUE).ShouldBeTrue();

            text0.IsNullable<TimeSpan>(IgnoreCase.TRUE).ShouldBeTrue();
            text1.IsNullable<TimeSpan>(IgnoreCase.TRUE).ShouldBeTrue();
            text2.IsNullable<TimeSpan>(IgnoreCase.TRUE).ShouldBeTrue();

            text0.IsNullable<TimeSpan?>(IgnoreCase.TRUE).ShouldBeTrue();
            text1.IsNullable<TimeSpan?>(IgnoreCase.TRUE).ShouldBeTrue();
            text2.IsNullable<TimeSpan?>(IgnoreCase.TRUE).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable TimeSpan type or not test")]
        public void JudgingNullOrEmptyStringIsNullableTimeSpanTypeTest()
        {
            var type = typeof(TimeSpan);
            var nullableType = typeof(TimeSpan?);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";

            text0.Is(type).ShouldBeFalse();
            text1.Is(type).ShouldBeFalse();
            text2.Is(type).ShouldBeFalse();

            text0.Is(nullableType).ShouldBeTrue();
            text1.Is(nullableType).ShouldBeFalse();
            text2.Is(nullableType).ShouldBeFalse();

            text0.IsNullable(type).ShouldBeTrue();
            text1.IsNullable(type).ShouldBeFalse();
            text2.IsNullable(type).ShouldBeFalse();

            text0.IsNullable(nullableType).ShouldBeTrue();
            text1.IsNullable(nullableType).ShouldBeFalse();
            text2.IsNullable(nullableType).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable TimeSpan type or not and ignore case test")]
        public void JudgingNullOrEmptyStringIsNullableTimeSpanTypeWithIgnoreCaseTest()
        {
            var type = typeof(TimeSpan);
            var nullableType = typeof(TimeSpan?);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";

            text0.Is(type, IgnoreCase.TRUE).ShouldBeFalse();
            text1.Is(type, IgnoreCase.TRUE).ShouldBeFalse();
            text2.Is(type, IgnoreCase.TRUE).ShouldBeFalse();

            text0.Is(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text1.Is(nullableType, IgnoreCase.TRUE).ShouldBeFalse();
            text2.Is(nullableType, IgnoreCase.TRUE).ShouldBeFalse();

            text0.IsNullable(type, IgnoreCase.TRUE).ShouldBeTrue();
            text1.IsNullable(type, IgnoreCase.TRUE).ShouldBeFalse();
            text2.IsNullable(type, IgnoreCase.TRUE).ShouldBeFalse();

            text0.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text1.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeFalse();
            text2.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable TimeSpan type or not by generic type test")]
        public void JudgingNullOrEmptyStringIsNullableTimeSpanTypeByGenericTypeTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";

            text0.Is<TimeSpan?>().ShouldBeTrue();
            text1.Is<TimeSpan?>().ShouldBeFalse();
            text2.Is<TimeSpan?>().ShouldBeFalse();

            text0.IsNullable<TimeSpan>().ShouldBeTrue();
            text1.IsNullable<TimeSpan>().ShouldBeFalse();
            text2.IsNullable<TimeSpan>().ShouldBeFalse();

            text0.IsNullable<TimeSpan?>().ShouldBeTrue();
            text1.IsNullable<TimeSpan?>().ShouldBeFalse();
            text2.IsNullable<TimeSpan?>().ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable TimeSpan type or not by generic type and ignore case test")]
        public void JudgingNullOrEmptyStringIsNullableTimeSpanTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";

            text0.Is<TimeSpan?>(IgnoreCase.TRUE).ShouldBeTrue();
            text1.Is<TimeSpan?>(IgnoreCase.TRUE).ShouldBeFalse();
            text2.Is<TimeSpan?>(IgnoreCase.TRUE).ShouldBeFalse();

            text0.IsNullable<TimeSpan>(IgnoreCase.TRUE).ShouldBeTrue();
            text1.IsNullable<TimeSpan>(IgnoreCase.TRUE).ShouldBeFalse();
            text2.IsNullable<TimeSpan>(IgnoreCase.TRUE).ShouldBeFalse();

            text0.IsNullable<TimeSpan?>(IgnoreCase.TRUE).ShouldBeTrue();
            text1.IsNullable<TimeSpan?>(IgnoreCase.TRUE).ShouldBeFalse();
            text2.IsNullable<TimeSpan?>(IgnoreCase.TRUE).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge invalid string to nullable TimeSpan type test")]
        public void JudgingInvalidStringToNullableTimeSpanTypeTest()
        {
            var type = typeof(TimeSpan);
            var nullableType = typeof(TimeSpan?);
            var text0 = "D";
            var text1 = "2000-12-01";
            var text2 = "23:61:00.4560000";

            text0.Is(type).ShouldBeFalse();
            text0.Is(type, IgnoreCase.TRUE).ShouldBeFalse();

            text0.Is<TimeSpan>().ShouldBeFalse();
            text0.Is<TimeSpan>(IgnoreCase.TRUE).ShouldBeFalse();

            text0.Is(nullableType).ShouldBeFalse();
            text0.Is(nullableType, IgnoreCase.TRUE).ShouldBeFalse();

            text0.Is<TimeSpan?>().ShouldBeFalse();
            text0.Is<TimeSpan?>(IgnoreCase.TRUE).ShouldBeFalse();

            text0.IsNullable(type).ShouldBeFalse();
            text0.IsNullable(type, IgnoreCase.TRUE).ShouldBeFalse();

            text0.IsNullable(nullableType).ShouldBeFalse();
            text0.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeFalse();

            text0.IsNullable<TimeSpan>().ShouldBeFalse();
            text0.IsNullable<TimeSpan>(IgnoreCase.TRUE).ShouldBeFalse();

            text0.IsNullable<TimeSpan?>().ShouldBeFalse();
            text0.IsNullable<TimeSpan?>(IgnoreCase.TRUE).ShouldBeFalse();

            text1.Is(type).ShouldBeFalse();
            text1.Is(type, IgnoreCase.TRUE).ShouldBeFalse();

            text1.Is<TimeSpan>().ShouldBeFalse();
            text1.Is<TimeSpan>(IgnoreCase.TRUE).ShouldBeFalse();

            text1.Is(nullableType).ShouldBeFalse();
            text1.Is(nullableType, IgnoreCase.TRUE).ShouldBeFalse();

            text1.Is<TimeSpan?>().ShouldBeFalse();
            text1.Is<TimeSpan?>(IgnoreCase.TRUE).ShouldBeFalse();

            text1.IsNullable(type).ShouldBeFalse();
            text1.IsNullable(type, IgnoreCase.TRUE).ShouldBeFalse();

            text1.IsNullable(nullableType).ShouldBeFalse();
            text1.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeFalse();

            text1.IsNullable<TimeSpan>().ShouldBeFalse();
            text1.IsNullable<TimeSpan>(IgnoreCase.TRUE).ShouldBeFalse();

            text1.IsNullable<TimeSpan?>().ShouldBeFalse();
            text1.IsNullable<TimeSpan?>(IgnoreCase.TRUE).ShouldBeFalse();
            
            text2.Is(type).ShouldBeFalse();
            text2.Is(type, IgnoreCase.TRUE).ShouldBeFalse();

            text2.Is<TimeSpan>().ShouldBeFalse();
            text2.Is<TimeSpan>(IgnoreCase.TRUE).ShouldBeFalse();

            text2.Is(nullableType).ShouldBeFalse();
            text2.Is(nullableType, IgnoreCase.TRUE).ShouldBeFalse();

            text2.Is<TimeSpan?>().ShouldBeFalse();
            text2.Is<TimeSpan?>(IgnoreCase.TRUE).ShouldBeFalse();

            text2.IsNullable(type).ShouldBeFalse();
            text2.IsNullable(type, IgnoreCase.TRUE).ShouldBeFalse();

            text2.IsNullable(nullableType).ShouldBeFalse();
            text2.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeFalse();

            text2.IsNullable<TimeSpan>().ShouldBeFalse();
            text2.IsNullable<TimeSpan>(IgnoreCase.TRUE).ShouldBeFalse();

            text2.IsNullable<TimeSpan?>().ShouldBeFalse();
            text2.IsNullable<TimeSpan?>(IgnoreCase.TRUE).ShouldBeFalse();
        }
    }
}