using System;
using Cosmos.Conversions;
using Cosmos.Date;
using Cosmos.Text;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.ConvUT
{
    [Trait("ConvUT", "StringConv.JudgeIsDateTimeSpan")]
    public class StringConvBeDateTimeSpanTypeTests
    {
        public StringConvBeDateTimeSpanTypeTests()
        {
            Context = new CastingContext
            {
                IgnoreCase = IgnoreCase.TRUE
            };
        }

        private CastingContext Context { get; set; }

        [Fact(DisplayName = "To judge string is DateTimeSpan type or not test")]
        public void JudgingStringIsDateTimeSpanTypeTest()
        {
            var type = typeof(DateTimeSpan);
            var today = DateTime.Today.AddDays(-10);
            var now = DateTime.Now;
            DateTimeSpan span = now - today;
            var text0 = span.ToString("c");
            var text1 = span.ToString("g");
            var text2 = span.ToString("G");

            text0.Is(type).ShouldBeTrue();
            text1.Is(type).ShouldBeTrue();
            text2.Is(type).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is DateTimeSpan type or not and ignore case test")]
        public void JudgingStringIsDateTimeSpanTypeWithIgnoreCaseTest()
        {
            var type = typeof(DateTimeSpan);
            var today = DateTime.Today.AddDays(-10);
            var now = DateTime.Now;
            DateTimeSpan span = now - today;
            var text0 = span.ToString("c");
            var text1 = span.ToString("g");
            var text2 = span.ToString("G");

            text0.Is(type, Context).ShouldBeTrue();
            text1.Is(type, Context).ShouldBeTrue();
            text2.Is(type, Context).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is DateTimeSpan type or not by generic type test")]
        public void JudgingStringIsDateTimeSpanTypeByGenericTypeTest()
        {
            var today = DateTime.Today.AddDays(-10);
            var now = DateTime.Now;
            DateTimeSpan span = now - today;
            var text0 = span.ToString("c");
            var text1 = span.ToString("g");
            var text2 = span.ToString("G");

            text0.Is<DateTimeSpan>().ShouldBeTrue();
            text1.Is<DateTimeSpan>().ShouldBeTrue();
            text2.Is<DateTimeSpan>().ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is DateTimeSpan type or not by generic type and ignore case test")]
        public void JudgingStringIsDateTimeSpanTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            var today = DateTime.Today.AddDays(-10);
            var now = DateTime.Now;
            DateTimeSpan span = now - today;
            var text0 = span.ToString("c");
            var text1 = span.ToString("g");
            var text2 = span.ToString("G");

            text0.Is<DateTimeSpan>(Context).ShouldBeTrue();
            text1.Is<DateTimeSpan>(Context).ShouldBeTrue();
            text2.Is<DateTimeSpan>(Context).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge null or empty string is DateTimeSpan type or not test")]
        public void JudgingNullOrEmptyStringIsDateTimeSpanTypeTest()
        {
            var type = typeof(DateTimeSpan);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";

            text0.Is(type).ShouldBeFalse();
            text1.Is(type).ShouldBeFalse();
            text2.Is(type).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is DateTimeSpan type or not and ignore case test")]
        public void JudgingNullOrEmptyStringIsDateTimeSpanTypeWithIgnoreCaseTest()
        {
            var type = typeof(DateTimeSpan);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";

            text0.Is(type, Context).ShouldBeFalse();
            text1.Is(type, Context).ShouldBeFalse();
            text2.Is(type, Context).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is DateTimeSpan type or not by generic type test")]
        public void JudgingNullOrEmptyStringIsDateTimeSpanTypeByGenericTypeTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";

            text0.Is<DateTimeSpan>().ShouldBeFalse();
            text1.Is<DateTimeSpan>().ShouldBeFalse();
            text2.Is<DateTimeSpan>().ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is DateTimeSpan type or not by generic type and ignore case test")]
        public void JudgingNullOrEmptyStringIsDateTimeSpanTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";

            text0.Is<DateTimeSpan>(Context).ShouldBeFalse();
            text1.Is<DateTimeSpan>(Context).ShouldBeFalse();
            text2.Is<DateTimeSpan>(Context).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge invalid string test")]
        public void JudgingInvalidStringTest()
        {
            var type = typeof(DateTimeSpan);
            var text0 = "D";
            var text1 = "2000-12-01";
            var text2 = "23:61:00.4560000";

            text0.Is(type).ShouldBeFalse();
            text0.Is(type, Context).ShouldBeFalse();

            text0.Is<DateTimeSpan>().ShouldBeFalse();
            text0.Is<DateTimeSpan>(Context).ShouldBeFalse();

            text1.Is(type).ShouldBeFalse();
            text1.Is(type, Context).ShouldBeFalse();

            text1.Is<DateTimeSpan>().ShouldBeFalse();
            text1.Is<DateTimeSpan>(Context).ShouldBeFalse();

            text2.Is(type).ShouldBeFalse();
            text2.Is(type, Context).ShouldBeFalse();

            text2.Is<DateTimeSpan>().ShouldBeFalse();
            text2.Is<DateTimeSpan>(Context).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge string is nullable DateTimeSpan type or not test")]
        public void JudgingStringIsNullableDateTimeSpanTypeTest()
        {
            var type = typeof(DateTimeSpan);
            var nullableType = typeof(DateTimeSpan?);
            var today = DateTime.Today.AddDays(-10);
            var now = DateTime.Now;
            DateTimeSpan span = now - today;
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

        [Fact(DisplayName = "To judge string is nullable DateTimeSpan type or not and ignore case test")]
        public void JudgingStringIsNullableDateTimeSpanTypeWithIgnoreCaseTest()
        {
            var type = typeof(DateTimeSpan);
            var nullableType = typeof(DateTimeSpan?);
            var today = DateTime.Today.AddDays(-10);
            var now = DateTime.Now;
            DateTimeSpan span = now - today;
            var text0 = span.ToString("c");
            var text1 = span.ToString("g");
            var text2 = span.ToString("G");

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

        [Fact(DisplayName = "To judge string is nullable DateTimeSpan type or not by generic type test")]
        public void JudgingStringIsNullableDateTimeSpanTypeByGenericTypeTest()
        {
            var today = DateTime.Today.AddDays(-10);
            var now = DateTime.Now;
            DateTimeSpan span = now - today;
            var text0 = span.ToString("c");
            var text1 = span.ToString("g");
            var text2 = span.ToString("G");

            text0.Is<DateTimeSpan>().ShouldBeTrue();
            text1.Is<DateTimeSpan>().ShouldBeTrue();
            text2.Is<DateTimeSpan>().ShouldBeTrue();

            text0.Is<DateTimeSpan?>().ShouldBeTrue();
            text1.Is<DateTimeSpan?>().ShouldBeTrue();
            text2.Is<DateTimeSpan?>().ShouldBeTrue();

            text0.IsNullable<DateTimeSpan>().ShouldBeTrue();
            text1.IsNullable<DateTimeSpan>().ShouldBeTrue();
            text2.IsNullable<DateTimeSpan>().ShouldBeTrue();

            text0.IsNullable<DateTimeSpan?>().ShouldBeTrue();
            text1.IsNullable<DateTimeSpan?>().ShouldBeTrue();
            text2.IsNullable<DateTimeSpan?>().ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable DateTimeSpan type or not by generic type and ignore case test")]
        public void JudgingStringIsNullableDateTimeSpanTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            var today = DateTime.Today.AddDays(-10);
            var now = DateTime.Now;
            DateTimeSpan span = now - today;
            var text0 = span.ToString("c");
            var text1 = span.ToString("g");
            var text2 = span.ToString("G");

            text0.Is<DateTimeSpan>(Context).ShouldBeTrue();
            text1.Is<DateTimeSpan>(Context).ShouldBeTrue();
            text2.Is<DateTimeSpan>(Context).ShouldBeTrue();

            text0.Is<DateTimeSpan?>(Context).ShouldBeTrue();
            text1.Is<DateTimeSpan?>(Context).ShouldBeTrue();
            text2.Is<DateTimeSpan?>(Context).ShouldBeTrue();

            text0.IsNullable<DateTimeSpan>(Context).ShouldBeTrue();
            text1.IsNullable<DateTimeSpan>(Context).ShouldBeTrue();
            text2.IsNullable<DateTimeSpan>(Context).ShouldBeTrue();

            text0.IsNullable<DateTimeSpan?>(Context).ShouldBeTrue();
            text1.IsNullable<DateTimeSpan?>(Context).ShouldBeTrue();
            text2.IsNullable<DateTimeSpan?>(Context).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable DateTimeSpan type or not test")]
        public void JudgingNullOrEmptyStringIsNullableDateTimeSpanTypeTest()
        {
            var type = typeof(DateTimeSpan);
            var nullableType = typeof(DateTimeSpan?);
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

        [Fact(DisplayName = "To judge null or empty string is nullable DateTimeSpan type or not and ignore case test")]
        public void JudgingNullOrEmptyStringIsNullableDateTimeSpanTypeWithIgnoreCaseTest()
        {
            var type = typeof(DateTimeSpan);
            var nullableType = typeof(DateTimeSpan?);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";

            text0.Is(type, Context).ShouldBeFalse();
            text1.Is(type, Context).ShouldBeFalse();
            text2.Is(type, Context).ShouldBeFalse();

            text0.Is(nullableType, Context).ShouldBeTrue();
            text1.Is(nullableType, Context).ShouldBeFalse();
            text2.Is(nullableType, Context).ShouldBeFalse();

            text0.IsNullable(type, Context).ShouldBeTrue();
            text1.IsNullable(type, Context).ShouldBeFalse();
            text2.IsNullable(type, Context).ShouldBeFalse();

            text0.IsNullable(nullableType, Context).ShouldBeTrue();
            text1.IsNullable(nullableType, Context).ShouldBeFalse();
            text2.IsNullable(nullableType, Context).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable DateTimeSpan type or not by generic type test")]
        public void JudgingNullOrEmptyStringIsNullableDateTimeSpanTypeByGenericTypeTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";

            text0.Is<DateTimeSpan?>().ShouldBeTrue();
            text1.Is<DateTimeSpan?>().ShouldBeFalse();
            text2.Is<DateTimeSpan?>().ShouldBeFalse();

            text0.IsNullable<DateTimeSpan>().ShouldBeTrue();
            text1.IsNullable<DateTimeSpan>().ShouldBeFalse();
            text2.IsNullable<DateTimeSpan>().ShouldBeFalse();

            text0.IsNullable<DateTimeSpan?>().ShouldBeTrue();
            text1.IsNullable<DateTimeSpan?>().ShouldBeFalse();
            text2.IsNullable<DateTimeSpan?>().ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable DateTimeSpan type or not by generic type and ignore case test")]
        public void JudgingNullOrEmptyStringIsNullableDateTimeSpanTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";

            text0.Is<DateTimeSpan?>(Context).ShouldBeTrue();
            text1.Is<DateTimeSpan?>(Context).ShouldBeFalse();
            text2.Is<DateTimeSpan?>(Context).ShouldBeFalse();

            text0.IsNullable<DateTimeSpan>(Context).ShouldBeTrue();
            text1.IsNullable<DateTimeSpan>(Context).ShouldBeFalse();
            text2.IsNullable<DateTimeSpan>(Context).ShouldBeFalse();

            text0.IsNullable<DateTimeSpan?>(Context).ShouldBeTrue();
            text1.IsNullable<DateTimeSpan?>(Context).ShouldBeFalse();
            text2.IsNullable<DateTimeSpan?>(Context).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge invalid string to nullable DateTimeSpan type test")]
        public void JudgingInvalidStringToNullableDateTimeSpanTypeTest()
        {
            var type = typeof(DateTimeSpan);
            var nullableType = typeof(DateTimeSpan?);
            var text0 = "D";
            var text1 = "2000-12-01";
            var text2 = "23:61:00.4560000";

            text0.Is(type).ShouldBeFalse();
            text0.Is(type, Context).ShouldBeFalse();

            text0.Is<DateTimeSpan>().ShouldBeFalse();
            text0.Is<DateTimeSpan>(Context).ShouldBeFalse();

            text0.Is(nullableType).ShouldBeFalse();
            text0.Is(nullableType, Context).ShouldBeFalse();

            text0.Is<DateTimeSpan?>().ShouldBeFalse();
            text0.Is<DateTimeSpan?>(Context).ShouldBeFalse();

            text0.IsNullable(type).ShouldBeFalse();
            text0.IsNullable(type, Context).ShouldBeFalse();

            text0.IsNullable(nullableType).ShouldBeFalse();
            text0.IsNullable(nullableType, Context).ShouldBeFalse();

            text0.IsNullable<DateTimeSpan>().ShouldBeFalse();
            text0.IsNullable<DateTimeSpan>(Context).ShouldBeFalse();

            text0.IsNullable<DateTimeSpan?>().ShouldBeFalse();
            text0.IsNullable<DateTimeSpan?>(Context).ShouldBeFalse();

            text1.Is(type).ShouldBeFalse();
            text1.Is(type, Context).ShouldBeFalse();

            text1.Is<DateTimeSpan>().ShouldBeFalse();
            text1.Is<DateTimeSpan>(Context).ShouldBeFalse();

            text1.Is(nullableType).ShouldBeFalse();
            text1.Is(nullableType, Context).ShouldBeFalse();

            text1.Is<DateTimeSpan?>().ShouldBeFalse();
            text1.Is<DateTimeSpan?>(Context).ShouldBeFalse();

            text1.IsNullable(type).ShouldBeFalse();
            text1.IsNullable(type, Context).ShouldBeFalse();

            text1.IsNullable(nullableType).ShouldBeFalse();
            text1.IsNullable(nullableType, Context).ShouldBeFalse();

            text1.IsNullable<DateTimeSpan>().ShouldBeFalse();
            text1.IsNullable<DateTimeSpan>(Context).ShouldBeFalse();

            text1.IsNullable<DateTimeSpan?>().ShouldBeFalse();
            text1.IsNullable<DateTimeSpan?>(Context).ShouldBeFalse();
            
            text2.Is(type).ShouldBeFalse();
            text2.Is(type, Context).ShouldBeFalse();

            text2.Is<DateTimeSpan>().ShouldBeFalse();
            text2.Is<DateTimeSpan>(Context).ShouldBeFalse();

            text2.Is(nullableType).ShouldBeFalse();
            text2.Is(nullableType, Context).ShouldBeFalse();

            text2.Is<DateTimeSpan?>().ShouldBeFalse();
            text2.Is<DateTimeSpan?>(Context).ShouldBeFalse();

            text2.IsNullable(type).ShouldBeFalse();
            text2.IsNullable(type, Context).ShouldBeFalse();

            text2.IsNullable(nullableType).ShouldBeFalse();
            text2.IsNullable(nullableType, Context).ShouldBeFalse();

            text2.IsNullable<DateTimeSpan>().ShouldBeFalse();
            text2.IsNullable<DateTimeSpan>(Context).ShouldBeFalse();

            text2.IsNullable<DateTimeSpan?>().ShouldBeFalse();
            text2.IsNullable<DateTimeSpan?>(Context).ShouldBeFalse();
        }
    }
}