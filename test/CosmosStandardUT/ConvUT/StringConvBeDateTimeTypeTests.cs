using System;
using Cosmos.Text;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.ConvUT
{
    [Trait("ConvUT", "StringConv.JudgeIsDateTime")]
    public class StringConvBeDateTimeTypeTests
    {
        [Fact(DisplayName = "To judge string is DateTime type or not test")]
        public void JudgingStringIsDateTimeTypeTest()
        {
            var type = typeof(DateTime);
            var text0 = DateTime.Today.ToString("yyyy-MM-dd");
            var text1 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var text2 = DateTime.Today.ToString("yyyy MM dd");
            var text3 = DateTime.Now.ToString("yyyy MM dd HH:mm:ss");

            text0.Is(type).ShouldBeTrue();
            text1.Is(type).ShouldBeTrue();
            text2.Is(type).ShouldBeTrue();
            text3.Is(type).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is DateTime type or not and ignore case test")]
        public void JudgingStringIsDateTimeTypeWithIgnoreCaseTest()
        {
            var type = typeof(DateTime);
            var text0 = DateTime.Today.ToString("yyyy-MM-dd");
            var text1 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var text2 = DateTime.Today.ToString("yyyy MM dd");
            var text3 = DateTime.Now.ToString("yyyy MM dd HH:mm:ss");

            text0.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text1.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text2.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text3.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is DateTime type or not by generic type test")]
        public void JudgingStringIsDateTimeTypeByGenericTypeTest()
        {
            var text0 = DateTime.Today.ToString("yyyy-MM-dd");
            var text1 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var text2 = DateTime.Today.ToString("yyyy MM dd");
            var text3 = DateTime.Now.ToString("yyyy MM dd HH:mm:ss");

            text0.Is<DateTime>().ShouldBeTrue();
            text1.Is<DateTime>().ShouldBeTrue();
            text2.Is<DateTime>().ShouldBeTrue();
            text3.Is<DateTime>().ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is DateTime type or not by generic type and ignore case test")]
        public void JudgingStringIsDateTimeTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            var text0 = DateTime.Today.ToString("yyyy-MM-dd");
            var text1 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var text2 = DateTime.Today.ToString("yyyy MM dd");
            var text3 = DateTime.Now.ToString("yyyy MM dd HH:mm:ss");

            text0.Is<DateTime>(IgnoreCase.TRUE).ShouldBeTrue();
            text1.Is<DateTime>(IgnoreCase.TRUE).ShouldBeTrue();
            text2.Is<DateTime>(IgnoreCase.TRUE).ShouldBeTrue();
            text3.Is<DateTime>(IgnoreCase.TRUE).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge null or empty string is DateTime type or not test")]
        public void JudgingNullOrEmptyStringIsDateTimeTypeTest()
        {
            var type = typeof(DateTime);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";

            text0.Is(type).ShouldBeFalse();
            text1.Is(type).ShouldBeFalse();
            text2.Is(type).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is DateTime type or not and ignore case test")]
        public void JudgingNullOrEmptyStringIsDateTimeTypeWithIgnoreCaseTest()
        {
            var type = typeof(DateTime);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";

            text0.Is(type, IgnoreCase.TRUE).ShouldBeFalse();
            text1.Is(type, IgnoreCase.TRUE).ShouldBeFalse();
            text2.Is(type, IgnoreCase.TRUE).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is DateTime type or not by generic type test")]
        public void JudgingNullOrEmptyStringIsDateTimeTypeByGenericTypeTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";

            text0.Is<DateTime>().ShouldBeFalse();
            text1.Is<DateTime>().ShouldBeFalse();
            text2.Is<DateTime>().ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is DateTime type or not by generic type and ignore case test")]
        public void JudgingNullOrEmptyStringIsDateTimeTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";

            text0.Is<DateTime>(IgnoreCase.TRUE).ShouldBeFalse();
            text1.Is<DateTime>(IgnoreCase.TRUE).ShouldBeFalse();
            text2.Is<DateTime>(IgnoreCase.TRUE).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge invalid string test")]
        public void JudgingInvalidStringTest()
        {
            var type = typeof(DateTime);
            var text0 = "D";
            var text1 = "2000-13-01";
            var text2 = "2000-12-32";

            text0.Is(type).ShouldBeFalse();
            text0.Is(type, IgnoreCase.TRUE).ShouldBeFalse();

            text0.Is<DateTime>().ShouldBeFalse();
            text0.Is<DateTime>(IgnoreCase.TRUE).ShouldBeFalse();

            text1.Is(type).ShouldBeFalse();
            text1.Is(type, IgnoreCase.TRUE).ShouldBeFalse();

            text1.Is<DateTime>().ShouldBeFalse();
            text1.Is<DateTime>(IgnoreCase.TRUE).ShouldBeFalse();

            text2.Is(type).ShouldBeFalse();
            text2.Is(type, IgnoreCase.TRUE).ShouldBeFalse();

            text2.Is<DateTime>().ShouldBeFalse();
            text2.Is<DateTime>(IgnoreCase.TRUE).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge string is nullable DateTime type or not test")]
        public void JudgingStringIsNullableDateTimeTypeTest()
        {
            var type = typeof(DateTime);
            var nullableType = typeof(DateTime?);
            var text0 = DateTime.Today.ToString("yyyy-MM-dd");
            var text1 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var text2 = DateTime.Today.ToString("yyyy MM dd");
            var text3 = DateTime.Now.ToString("yyyy MM dd HH:mm:ss");

            text0.Is(type).ShouldBeTrue();
            text1.Is(type).ShouldBeTrue();
            text2.Is(type).ShouldBeTrue();
            text3.Is(type).ShouldBeTrue();

            text0.Is(nullableType).ShouldBeTrue();
            text1.Is(nullableType).ShouldBeTrue();
            text2.Is(nullableType).ShouldBeTrue();
            text3.Is(nullableType).ShouldBeTrue();

            text0.IsNullable(type).ShouldBeTrue();
            text1.IsNullable(type).ShouldBeTrue();
            text2.IsNullable(type).ShouldBeTrue();
            text3.IsNullable(type).ShouldBeTrue();

            text0.IsNullable(nullableType).ShouldBeTrue();
            text1.IsNullable(nullableType).ShouldBeTrue();
            text2.IsNullable(nullableType).ShouldBeTrue();
            text3.IsNullable(nullableType).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable DateTime type or not and ignore case test")]
        public void JudgingStringIsNullableDateTimeTypeWithIgnoreCaseTest()
        {
            var type = typeof(DateTime);
            var nullableType = typeof(DateTime?);
            var text0 = DateTime.Today.ToString("yyyy-MM-dd");
            var text1 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var text2 = DateTime.Today.ToString("yyyy MM dd");
            var text3 = DateTime.Now.ToString("yyyy MM dd HH:mm:ss");

            text0.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text1.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text2.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text3.Is(type, IgnoreCase.TRUE).ShouldBeTrue();

            text0.Is(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text1.Is(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text2.Is(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text3.Is(nullableType, IgnoreCase.TRUE).ShouldBeTrue();

            text0.IsNullable(type, IgnoreCase.TRUE).ShouldBeTrue();
            text1.IsNullable(type, IgnoreCase.TRUE).ShouldBeTrue();
            text2.IsNullable(type, IgnoreCase.TRUE).ShouldBeTrue();
            text3.IsNullable(type, IgnoreCase.TRUE).ShouldBeTrue();

            text0.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text1.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text2.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text3.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable DateTime type or not by generic type test")]
        public void JudgingStringIsNullableDateTimeTypeByGenericTypeTest()
        {
            var text0 = DateTime.Today.ToString("yyyy-MM-dd");
            var text1 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var text2 = DateTime.Today.ToString("yyyy MM dd");
            var text3 = DateTime.Now.ToString("yyyy MM dd HH:mm:ss");

            text0.Is<DateTime>().ShouldBeTrue();
            text1.Is<DateTime>().ShouldBeTrue();
            text2.Is<DateTime>().ShouldBeTrue();
            text3.Is<DateTime>().ShouldBeTrue();

            text0.Is<DateTime?>().ShouldBeTrue();
            text1.Is<DateTime?>().ShouldBeTrue();
            text2.Is<DateTime?>().ShouldBeTrue();
            text3.Is<DateTime?>().ShouldBeTrue();

            text0.IsNullable<DateTime>().ShouldBeTrue();
            text1.IsNullable<DateTime>().ShouldBeTrue();
            text2.IsNullable<DateTime>().ShouldBeTrue();
            text3.IsNullable<DateTime>().ShouldBeTrue();

            text0.IsNullable<DateTime?>().ShouldBeTrue();
            text1.IsNullable<DateTime?>().ShouldBeTrue();
            text2.IsNullable<DateTime?>().ShouldBeTrue();
            text3.IsNullable<DateTime?>().ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable DateTime type or not by generic type and ignore case test")]
        public void JudgingStringIsNullableDateTimeTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            var text0 = DateTime.Today.ToString("yyyy-MM-dd");
            var text1 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var text2 = DateTime.Today.ToString("yyyy MM dd");
            var text3 = DateTime.Now.ToString("yyyy MM dd HH:mm:ss");

            text0.Is<DateTime>(IgnoreCase.TRUE).ShouldBeTrue();
            text1.Is<DateTime>(IgnoreCase.TRUE).ShouldBeTrue();
            text2.Is<DateTime>(IgnoreCase.TRUE).ShouldBeTrue();
            text3.Is<DateTime>(IgnoreCase.TRUE).ShouldBeTrue();

            text0.Is<DateTime?>(IgnoreCase.TRUE).ShouldBeTrue();
            text1.Is<DateTime?>(IgnoreCase.TRUE).ShouldBeTrue();
            text2.Is<DateTime?>(IgnoreCase.TRUE).ShouldBeTrue();
            text3.Is<DateTime?>(IgnoreCase.TRUE).ShouldBeTrue();

            text0.IsNullable<DateTime>(IgnoreCase.TRUE).ShouldBeTrue();
            text1.IsNullable<DateTime>(IgnoreCase.TRUE).ShouldBeTrue();
            text2.IsNullable<DateTime>(IgnoreCase.TRUE).ShouldBeTrue();
            text3.IsNullable<DateTime>(IgnoreCase.TRUE).ShouldBeTrue();

            text0.IsNullable<DateTime?>(IgnoreCase.TRUE).ShouldBeTrue();
            text1.IsNullable<DateTime?>(IgnoreCase.TRUE).ShouldBeTrue();
            text2.IsNullable<DateTime?>(IgnoreCase.TRUE).ShouldBeTrue();
            text3.IsNullable<DateTime?>(IgnoreCase.TRUE).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable DateTime type or not test")]
        public void JudgingNullOrEmptyStringIsNullableDateTimeTypeTest()
        {
            var type = typeof(DateTime);
            var nullableType = typeof(DateTime?);
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

        [Fact(DisplayName = "To judge null or empty string is nullable DateTime type or not and ignore case test")]
        public void JudgingNullOrEmptyStringIsNullableDateTimeTypeWithIgnoreCaseTest()
        {
            var type = typeof(DateTime);
            var nullableType = typeof(DateTime?);
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

        [Fact(DisplayName = "To judge null or empty string is nullable DateTime type or not by generic type test")]
        public void JudgingNullOrEmptyStringIsNullableDateTimeTypeByGenericTypeTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";

            text0.Is<DateTime?>().ShouldBeTrue();
            text1.Is<DateTime?>().ShouldBeFalse();
            text2.Is<DateTime?>().ShouldBeFalse();

            text0.IsNullable<DateTime>().ShouldBeTrue();
            text1.IsNullable<DateTime>().ShouldBeFalse();
            text2.IsNullable<DateTime>().ShouldBeFalse();

            text0.IsNullable<DateTime?>().ShouldBeTrue();
            text1.IsNullable<DateTime?>().ShouldBeFalse();
            text2.IsNullable<DateTime?>().ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable DateTime type or not by generic type and ignore case test")]
        public void JudgingNullOrEmptyStringIsNullableDateTimeTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";

            text0.Is<DateTime?>(IgnoreCase.TRUE).ShouldBeTrue();
            text1.Is<DateTime?>(IgnoreCase.TRUE).ShouldBeFalse();
            text2.Is<DateTime?>(IgnoreCase.TRUE).ShouldBeFalse();

            text0.IsNullable<DateTime>(IgnoreCase.TRUE).ShouldBeTrue();
            text1.IsNullable<DateTime>(IgnoreCase.TRUE).ShouldBeFalse();
            text2.IsNullable<DateTime>(IgnoreCase.TRUE).ShouldBeFalse();

            text0.IsNullable<DateTime?>(IgnoreCase.TRUE).ShouldBeTrue();
            text1.IsNullable<DateTime?>(IgnoreCase.TRUE).ShouldBeFalse();
            text2.IsNullable<DateTime?>(IgnoreCase.TRUE).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge invalid string to nullable DateTime type test")]
        public void JudgingInvalidStringToNullableDateTimeTypeTest()
        {
            var type = typeof(DateTime);
            var nullableType = typeof(DateTime?);
            var text0 = "D";
            var text1 = "2000-13-01";
            var text2 = "2000-12-32";

            text0.Is(type).ShouldBeFalse();
            text0.Is(type, IgnoreCase.TRUE).ShouldBeFalse();

            text0.Is<DateTime>().ShouldBeFalse();
            text0.Is<DateTime>(IgnoreCase.TRUE).ShouldBeFalse();

            text0.Is(nullableType).ShouldBeFalse();
            text0.Is(nullableType, IgnoreCase.TRUE).ShouldBeFalse();

            text0.Is<DateTime?>().ShouldBeFalse();
            text0.Is<DateTime?>(IgnoreCase.TRUE).ShouldBeFalse();

            text0.IsNullable(type).ShouldBeFalse();
            text0.IsNullable(type, IgnoreCase.TRUE).ShouldBeFalse();

            text0.IsNullable(nullableType).ShouldBeFalse();
            text0.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeFalse();

            text0.IsNullable<DateTime>().ShouldBeFalse();
            text0.IsNullable<DateTime>(IgnoreCase.TRUE).ShouldBeFalse();

            text0.IsNullable<DateTime?>().ShouldBeFalse();
            text0.IsNullable<DateTime?>(IgnoreCase.TRUE).ShouldBeFalse();

            text1.Is(type).ShouldBeFalse();
            text1.Is(type, IgnoreCase.TRUE).ShouldBeFalse();

            text1.Is<DateTime>().ShouldBeFalse();
            text1.Is<DateTime>(IgnoreCase.TRUE).ShouldBeFalse();

            text1.Is(nullableType).ShouldBeFalse();
            text1.Is(nullableType, IgnoreCase.TRUE).ShouldBeFalse();

            text1.Is<DateTime?>().ShouldBeFalse();
            text1.Is<DateTime?>(IgnoreCase.TRUE).ShouldBeFalse();

            text1.IsNullable(type).ShouldBeFalse();
            text1.IsNullable(type, IgnoreCase.TRUE).ShouldBeFalse();

            text1.IsNullable(nullableType).ShouldBeFalse();
            text1.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeFalse();

            text1.IsNullable<DateTime>().ShouldBeFalse();
            text1.IsNullable<DateTime>(IgnoreCase.TRUE).ShouldBeFalse();

            text1.IsNullable<DateTime?>().ShouldBeFalse();
            text1.IsNullable<DateTime?>(IgnoreCase.TRUE).ShouldBeFalse();
            
            text2.Is(type).ShouldBeFalse();
            text2.Is(type, IgnoreCase.TRUE).ShouldBeFalse();

            text2.Is<DateTime>().ShouldBeFalse();
            text2.Is<DateTime>(IgnoreCase.TRUE).ShouldBeFalse();

            text2.Is(nullableType).ShouldBeFalse();
            text2.Is(nullableType, IgnoreCase.TRUE).ShouldBeFalse();

            text2.Is<DateTime?>().ShouldBeFalse();
            text2.Is<DateTime?>(IgnoreCase.TRUE).ShouldBeFalse();

            text2.IsNullable(type).ShouldBeFalse();
            text2.IsNullable(type, IgnoreCase.TRUE).ShouldBeFalse();

            text2.IsNullable(nullableType).ShouldBeFalse();
            text2.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeFalse();

            text2.IsNullable<DateTime>().ShouldBeFalse();
            text2.IsNullable<DateTime>(IgnoreCase.TRUE).ShouldBeFalse();

            text2.IsNullable<DateTime?>().ShouldBeFalse();
            text2.IsNullable<DateTime?>(IgnoreCase.TRUE).ShouldBeFalse();
        }
    }
}