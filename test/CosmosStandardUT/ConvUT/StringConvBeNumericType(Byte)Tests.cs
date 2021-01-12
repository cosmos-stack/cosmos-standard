using System;
using Cosmos.Text;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.ConvUT
{
    [Trait("ConvUT", "StringConv.JudgeIsNumeric(Byte)")]
    public class StringConvBeByteTypeTests
    {
        [Fact(DisplayName = "To judge string is Byte type or not test")]
        public void JudgingStringIsByteTypeTest()
        {
            var type = typeof(Byte);
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";

            text0.Is(type).ShouldBeFalse();
            text1.Is(type).ShouldBeTrue();
            text2.Is(type).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is Byte type or not and ignore case test")]
        public void JudgingStringIsByteTypeWithIgnoreCaseTest()
        {
            var type = typeof(Byte);
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";

            text0.Is(type, IgnoreCase.TRUE).ShouldBeFalse();
            text1.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text2.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is Byte type or not by generic type test")]
        public void JudgingStringIsByteTypeByGenericTypeTest()
        {
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";

            text0.Is<Byte>().ShouldBeFalse();
            text1.Is<Byte>().ShouldBeTrue();
            text2.Is<Byte>().ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is Byte type or not by generic type and ignore case test")]
        public void JudgingStringIsByteTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";

            text0.Is<Byte>(IgnoreCase.TRUE).ShouldBeFalse();
            text1.Is<Byte>(IgnoreCase.TRUE).ShouldBeTrue();
            text2.Is<Byte>(IgnoreCase.TRUE).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge null or empty string is Byte type or not test")]
        public void JudgingNullOrEmptyStringIsByteTypeTest()
        {
            var type = typeof(Byte);
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

        [Fact(DisplayName = "To judge null or empty string is Byte type or not and ignore case test")]
        public void JudgingNullOrEmptyStringIsByteTypeWithIgnoreCaseTest()
        {
            var type = typeof(Byte);
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

        [Fact(DisplayName = "To judge null or empty string is Byte type or not by generic type test")]
        public void JudgingNullOrEmptyStringIsByteTypeByGenericTypeTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "1.1";
            string text4 = "C";

            text0.Is<Byte>().ShouldBeFalse();
            text1.Is<Byte>().ShouldBeFalse();
            text2.Is<Byte>().ShouldBeFalse();
            text3.Is<Byte>().ShouldBeFalse();
            text4.Is<Byte>().ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is Byte type or not by generic type and ignore case test")]
        public void JudgingNullOrEmptyStringIsByteTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "1.1";
            string text4 = "C";

            text0.Is<Byte>(IgnoreCase.TRUE).ShouldBeFalse();
            text1.Is<Byte>(IgnoreCase.TRUE).ShouldBeFalse();
            text2.Is<Byte>(IgnoreCase.TRUE).ShouldBeFalse();
            text3.Is<Byte>(IgnoreCase.TRUE).ShouldBeFalse();
            text4.Is<Byte>(IgnoreCase.TRUE).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge string is nullable Byte type or not test")]
        public void JudgingStringIsNullableByteTypeTest()
        {
            var type = typeof(Byte);
            var nullableType = typeof(Byte?);
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

        [Fact(DisplayName = "To judge string is nullable Byte type or not and ignore case test")]
        public void JudgingStringIsNullableByteTypeWithIgnoreCaseTest()
        {
            var type = typeof(Byte);
            var nullableType = typeof(Byte?);
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

        [Fact(DisplayName = "To judge string is nullable Byte type or not by generic type test")]
        public void JudgingStringIsNullableByteTypeByGenericTypeTest()
        {
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";

            text0.Is<Byte>().ShouldBeFalse();
            text1.Is<Byte>().ShouldBeTrue();
            text2.Is<Byte>().ShouldBeTrue();

            text0.Is<Byte?>().ShouldBeFalse();
            text1.Is<Byte?>().ShouldBeTrue();
            text2.Is<Byte?>().ShouldBeTrue();

            text0.IsNullable<Byte>().ShouldBeFalse();
            text1.IsNullable<Byte>().ShouldBeTrue();
            text2.IsNullable<Byte>().ShouldBeTrue();

            text0.IsNullable<Byte?>().ShouldBeFalse();
            text1.IsNullable<Byte?>().ShouldBeTrue();
            text2.IsNullable<Byte?>().ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable Byte type or not by generic type and ignore case test")]
        public void JudgingStringIsNullableByteTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            var text0 = "-1";
            var text1 = "0";
            var text2 = "1";

            text0.Is<Byte>(IgnoreCase.TRUE).ShouldBeFalse();
            text1.Is<Byte>(IgnoreCase.TRUE).ShouldBeTrue();
            text2.Is<Byte>(IgnoreCase.TRUE).ShouldBeTrue();

            text0.Is<Byte?>(IgnoreCase.TRUE).ShouldBeFalse();
            text1.Is<Byte?>(IgnoreCase.TRUE).ShouldBeTrue();
            text2.Is<Byte?>(IgnoreCase.TRUE).ShouldBeTrue();

            text0.IsNullable<Byte>(IgnoreCase.TRUE).ShouldBeFalse();
            text1.IsNullable<Byte>(IgnoreCase.TRUE).ShouldBeTrue();
            text2.IsNullable<Byte>(IgnoreCase.TRUE).ShouldBeTrue();

            text0.IsNullable<Byte?>(IgnoreCase.TRUE).ShouldBeFalse();
            text1.IsNullable<Byte?>(IgnoreCase.TRUE).ShouldBeTrue();
            text2.IsNullable<Byte?>(IgnoreCase.TRUE).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable Byte type or not test")]
        public void JudgingNullOrEmptyStringIsNullableByteTypeTest()
        {
            var type = typeof(Byte);
            var nullableType = typeof(Byte?);
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

        [Fact(DisplayName = "To judge null or empty string is nullable Byte type or not and ignore case test")]
        public void JudgingNullOrEmptyStringIsNullableByteTypeWithIgnoreCaseTest()
        {
            var type = typeof(Byte);
            var nullableType = typeof(Byte?);
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

        [Fact(DisplayName = "To judge null or empty string is nullable Byte type or not by generic type test")]
        public void JudgingNullOrEmptyStringIsNullableByteTypeByGenericTypeTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "1.1";
            string text4 = "C";

            text0.Is<Byte?>().ShouldBeTrue();
            text1.Is<Byte?>().ShouldBeFalse();
            text2.Is<Byte?>().ShouldBeFalse();
            text3.Is<Byte?>().ShouldBeFalse();
            text4.Is<Byte?>().ShouldBeFalse();

            text0.IsNullable<Byte>().ShouldBeTrue();
            text1.IsNullable<Byte>().ShouldBeFalse();
            text2.IsNullable<Byte>().ShouldBeFalse();
            text3.IsNullable<Byte>().ShouldBeFalse();
            text4.IsNullable<Byte>().ShouldBeFalse();

            text0.IsNullable<Byte?>().ShouldBeTrue();
            text1.IsNullable<Byte?>().ShouldBeFalse();
            text2.IsNullable<Byte?>().ShouldBeFalse();
            text3.IsNullable<Byte?>().ShouldBeFalse();
            text4.IsNullable<Byte?>().ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable Byte type or not by generic type and ignore case test")]
        public void JudgingNullOrEmptyStringIsNullableByteTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "1.1";
            string text4 = "C";

            text0.Is<Byte?>(IgnoreCase.TRUE).ShouldBeTrue();
            text1.Is<Byte?>(IgnoreCase.TRUE).ShouldBeFalse();
            text2.Is<Byte?>(IgnoreCase.TRUE).ShouldBeFalse();
            text3.Is<Byte?>(IgnoreCase.TRUE).ShouldBeFalse();
            text4.Is<Byte?>(IgnoreCase.TRUE).ShouldBeFalse();

            text0.IsNullable<Byte>(IgnoreCase.TRUE).ShouldBeTrue();
            text1.IsNullable<Byte>(IgnoreCase.TRUE).ShouldBeFalse();
            text2.IsNullable<Byte>(IgnoreCase.TRUE).ShouldBeFalse();
            text3.IsNullable<Byte>(IgnoreCase.TRUE).ShouldBeFalse();
            text4.IsNullable<Byte>(IgnoreCase.TRUE).ShouldBeFalse();

            text0.IsNullable<Byte?>(IgnoreCase.TRUE).ShouldBeTrue();
            text1.IsNullable<Byte?>(IgnoreCase.TRUE).ShouldBeFalse();
            text2.IsNullable<Byte?>(IgnoreCase.TRUE).ShouldBeFalse();
            text3.IsNullable<Byte?>(IgnoreCase.TRUE).ShouldBeFalse();
            text4.IsNullable<Byte?>(IgnoreCase.TRUE).ShouldBeFalse();
        }
    }
}