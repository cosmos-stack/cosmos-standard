using System.Text;
using Cosmos.Text;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.ConvUT
{
    [Trait("ConvUT", "StringConv.JudgeIsEncoding")]
    public class StringConvBeEncodingTypeTests
    {
        [Fact(DisplayName = "To judge string is Encoding type or not test")]
        public void JudgingStringIsEncodingTypeTest()
        {
            var type = typeof(Encoding);
            var text0 = Encoding.Default.BodyName;
            var text1 = Encoding.Unicode.BodyName;
            var text2 = Encoding.UTF8.BodyName;
            var text3 = Encoding.ASCII.BodyName;
            var textC = "ANSI";

            text0.Is(type).ShouldBeTrue();
            text1.Is(type).ShouldBeTrue();
            text2.Is(type).ShouldBeTrue();
            text3.Is(type).ShouldBeTrue();
            textC.Is(type).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is Encoding type or not and ignore case test")]
        public void JudgingStringIsEncodingTypeWithIgnoreCaseTest()
        {
            var type = typeof(Encoding);
            var text0 = Encoding.Default.BodyName;
            var text1 = Encoding.Unicode.BodyName;
            var text2 = Encoding.UTF8.BodyName;
            var text3 = Encoding.ASCII.BodyName;
            var text4 = Encoding.Default.BodyName.ToUpperInvariant();
            var text5 = Encoding.Unicode.BodyName.ToUpperInvariant();
            var text6 = Encoding.UTF8.BodyName.ToUpperInvariant();
            var text7 = Encoding.ASCII.BodyName.ToUpperInvariant();
            var text8 = Encoding.Default.BodyName.ToLowerInvariant();
            var text9 = Encoding.Unicode.BodyName.ToLowerInvariant();
            var textA = Encoding.UTF8.BodyName.ToLowerInvariant();
            var textB = Encoding.ASCII.BodyName.ToLowerInvariant();
            var textC = "ANSI";
            
            text0.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text1.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text2.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text3.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text4.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text5.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text6.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text7.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text8.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text9.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            textA.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            textB.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            textC.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is Encoding type or not by generic type test")]
        public void JudgingStringIsEncodingTypeByGenericTypeTest()
        {
            var text0 = Encoding.Default.BodyName;
            var text1 = Encoding.Unicode.BodyName;
            var text2 = Encoding.UTF8.BodyName;
            var text3 = Encoding.ASCII.BodyName;
            var textC = "ANSI";

            text0.Is<Encoding>().ShouldBeTrue();
            text1.Is<Encoding>().ShouldBeTrue();
            text2.Is<Encoding>().ShouldBeTrue();
            text3.Is<Encoding>().ShouldBeTrue();
            textC.Is<Encoding>().ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is Encoding type or not by generic type and ignore case test")]
        public void JudgingStringIsEncodingTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            var text0 = Encoding.Default.BodyName;
            var text1 = Encoding.Unicode.BodyName;
            var text2 = Encoding.UTF8.BodyName;
            var text3 = Encoding.ASCII.BodyName;
            var text4 = Encoding.Default.BodyName.ToUpperInvariant();
            var text5 = Encoding.Unicode.BodyName.ToUpperInvariant();
            var text6 = Encoding.UTF8.BodyName.ToUpperInvariant();
            var text7 = Encoding.ASCII.BodyName.ToUpperInvariant();
            var text8 = Encoding.Default.BodyName.ToLowerInvariant();
            var text9 = Encoding.Unicode.BodyName.ToLowerInvariant();
            var textA = Encoding.UTF8.BodyName.ToLowerInvariant();
            var textB = Encoding.ASCII.BodyName.ToLowerInvariant();
            var textC = "ANSI";

            text0.Is<Encoding>(IgnoreCase.TRUE).ShouldBeTrue();
            text1.Is<Encoding>(IgnoreCase.TRUE).ShouldBeTrue();
            text2.Is<Encoding>(IgnoreCase.TRUE).ShouldBeTrue();
            text3.Is<Encoding>(IgnoreCase.TRUE).ShouldBeTrue();
            text4.Is<Encoding>(IgnoreCase.TRUE).ShouldBeTrue();
            text5.Is<Encoding>(IgnoreCase.TRUE).ShouldBeTrue();
            text6.Is<Encoding>(IgnoreCase.TRUE).ShouldBeTrue();
            text7.Is<Encoding>(IgnoreCase.TRUE).ShouldBeTrue();
            text8.Is<Encoding>(IgnoreCase.TRUE).ShouldBeTrue();
            text9.Is<Encoding>(IgnoreCase.TRUE).ShouldBeTrue();
            textA.Is<Encoding>(IgnoreCase.TRUE).ShouldBeTrue();
            textB.Is<Encoding>(IgnoreCase.TRUE).ShouldBeTrue();
            textC.Is<Encoding>(IgnoreCase.TRUE).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge null or empty string is Encoding type or not test")]
        public void JudgingNullOrEmptyStringIsEncodingTypeTest()
        {
            var type = typeof(Encoding);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "---";

            text0.Is(type).ShouldBeFalse();
            text1.Is(type).ShouldBeFalse();
            text2.Is(type).ShouldBeFalse();
            text3.Is(type).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is Encoding type or not and ignore case test")]
        public void JudgingNullOrEmptyStringIsEncodingTypeWithIgnoreCaseTest()
        {
            var type = typeof(Encoding);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "---";

            text0.Is(type, IgnoreCase.TRUE).ShouldBeFalse();
            text1.Is(type, IgnoreCase.TRUE).ShouldBeFalse();
            text2.Is(type, IgnoreCase.TRUE).ShouldBeFalse();
            text3.Is(type, IgnoreCase.TRUE).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is Encoding type or not by generic type test")]
        public void JudgingNullOrEmptyStringIsEncodingTypeByGenericTypeTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "---";

            text0.Is<Encoding>().ShouldBeFalse();
            text1.Is<Encoding>().ShouldBeFalse();
            text2.Is<Encoding>().ShouldBeFalse();
            text3.Is<Encoding>().ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is Encoding type or not by generic type and ignore case test")]
        public void JudgingNullOrEmptyStringIsEncodingTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "---";

            text0.Is<Encoding>(IgnoreCase.TRUE).ShouldBeFalse();
            text1.Is<Encoding>(IgnoreCase.TRUE).ShouldBeFalse();
            text2.Is<Encoding>(IgnoreCase.TRUE).ShouldBeFalse();
            text3.Is<Encoding>(IgnoreCase.TRUE).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge string is nullable Encoding type or not test")]
        public void JudgingStringIsNullableEncodingTypeTest()
        {
            var type = typeof(Encoding);
            var text0 = Encoding.Default.BodyName;
            var text1 = Encoding.Unicode.BodyName;
            var text2 = Encoding.UTF8.BodyName;
            var text3 = Encoding.ASCII.BodyName;
            var textC = "ANSI";

            text0.Is(type).ShouldBeTrue();
            text1.Is(type).ShouldBeTrue();
            text2.Is(type).ShouldBeTrue();
            text3.Is(type).ShouldBeTrue();
            textC.Is(type).ShouldBeTrue();

            text0.IsNullable(type).ShouldBeTrue();
            text1.IsNullable(type).ShouldBeTrue();
            text2.IsNullable(type).ShouldBeTrue();
            text3.IsNullable(type).ShouldBeTrue();
            textC.IsNullable(type).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable Encoding type or not and ignore case test")]
        public void JudgingStringIsNullableEncodingTypeWithIgnoreCaseTest()
        {
            var type = typeof(Encoding);
            var text0 = Encoding.Default.BodyName;
            var text1 = Encoding.Unicode.BodyName;
            var text2 = Encoding.UTF8.BodyName;
            var text3 = Encoding.ASCII.BodyName;
            var text4 = Encoding.Default.BodyName.ToUpperInvariant();
            var text5 = Encoding.Unicode.BodyName.ToUpperInvariant();
            var text6 = Encoding.UTF8.BodyName.ToUpperInvariant();
            var text7 = Encoding.ASCII.BodyName.ToUpperInvariant();
            var text8 = Encoding.Default.BodyName.ToLowerInvariant();
            var text9 = Encoding.Unicode.BodyName.ToLowerInvariant();
            var textA = Encoding.UTF8.BodyName.ToLowerInvariant();
            var textB = Encoding.ASCII.BodyName.ToLowerInvariant();
            var textC = "ANSI";

            text0.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text1.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text2.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text3.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text4.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text5.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text6.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text7.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text8.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text9.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            textA.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            textB.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            textC.Is(type, IgnoreCase.TRUE).ShouldBeTrue();

            text0.IsNullable(type, IgnoreCase.TRUE).ShouldBeTrue();
            text1.IsNullable(type, IgnoreCase.TRUE).ShouldBeTrue();
            text2.IsNullable(type, IgnoreCase.TRUE).ShouldBeTrue();
            text3.IsNullable(type, IgnoreCase.TRUE).ShouldBeTrue();
            text4.IsNullable(type, IgnoreCase.TRUE).ShouldBeTrue();
            text5.IsNullable(type, IgnoreCase.TRUE).ShouldBeTrue();
            text6.IsNullable(type, IgnoreCase.TRUE).ShouldBeTrue();
            text7.IsNullable(type, IgnoreCase.TRUE).ShouldBeTrue();
            text8.IsNullable(type, IgnoreCase.TRUE).ShouldBeTrue();
            text9.IsNullable(type, IgnoreCase.TRUE).ShouldBeTrue();
            textA.IsNullable(type, IgnoreCase.TRUE).ShouldBeTrue();
            textB.IsNullable(type, IgnoreCase.TRUE).ShouldBeTrue();
            textC.IsNullable(type, IgnoreCase.TRUE).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable Encoding type or not by generic type test")]
        public void JudgingStringIsNullableEncodingTypeByGenericTypeTest()
        {
            var text0 = Encoding.Default.BodyName;
            var text1 = Encoding.Unicode.BodyName;
            var text2 = Encoding.UTF8.BodyName;
            var text3 = Encoding.ASCII.BodyName;
            var textC = "ANSI";

            text0.Is<Encoding>().ShouldBeTrue();
            text1.Is<Encoding>().ShouldBeTrue();
            text2.Is<Encoding>().ShouldBeTrue();
            text3.Is<Encoding>().ShouldBeTrue();
            textC.Is<Encoding>().ShouldBeTrue();

            text0.IsNullable<Encoding>().ShouldBeTrue();
            text1.IsNullable<Encoding>().ShouldBeTrue();
            text2.IsNullable<Encoding>().ShouldBeTrue();
            text3.IsNullable<Encoding>().ShouldBeTrue();
            textC.IsNullable<Encoding>().ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable Encoding type or not by generic type and ignore case test")]
        public void JudgingStringIsNullableEncodingTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            var text0 = Encoding.Default.BodyName;
            var text1 = Encoding.Unicode.BodyName;
            var text2 = Encoding.UTF8.BodyName;
            var text3 = Encoding.ASCII.BodyName;
            var text4 = Encoding.Default.BodyName.ToUpperInvariant();
            var text5 = Encoding.Unicode.BodyName.ToUpperInvariant();
            var text6 = Encoding.UTF8.BodyName.ToUpperInvariant();
            var text7 = Encoding.ASCII.BodyName.ToUpperInvariant();
            var text8 = Encoding.Default.BodyName.ToLowerInvariant();
            var text9 = Encoding.Unicode.BodyName.ToLowerInvariant();
            var textA = Encoding.UTF8.BodyName.ToLowerInvariant();
            var textB = Encoding.ASCII.BodyName.ToLowerInvariant();
            var textC = "ANSI";

            text0.Is<Encoding>(IgnoreCase.TRUE).ShouldBeTrue();
            text1.Is<Encoding>(IgnoreCase.TRUE).ShouldBeTrue();
            text2.Is<Encoding>(IgnoreCase.TRUE).ShouldBeTrue();
            text3.Is<Encoding>(IgnoreCase.TRUE).ShouldBeTrue();
            text4.Is<Encoding>(IgnoreCase.TRUE).ShouldBeTrue();
            text5.Is<Encoding>(IgnoreCase.TRUE).ShouldBeTrue();
            text6.Is<Encoding>(IgnoreCase.TRUE).ShouldBeTrue();
            text7.Is<Encoding>(IgnoreCase.TRUE).ShouldBeTrue();
            text8.Is<Encoding>(IgnoreCase.TRUE).ShouldBeTrue();
            text9.Is<Encoding>(IgnoreCase.TRUE).ShouldBeTrue();
            textA.Is<Encoding>(IgnoreCase.TRUE).ShouldBeTrue();
            textB.Is<Encoding>(IgnoreCase.TRUE).ShouldBeTrue();
            textC.Is<Encoding>(IgnoreCase.TRUE).ShouldBeTrue();

            text0.IsNullable<Encoding>(IgnoreCase.TRUE).ShouldBeTrue();
            text1.IsNullable<Encoding>(IgnoreCase.TRUE).ShouldBeTrue();
            text2.IsNullable<Encoding>(IgnoreCase.TRUE).ShouldBeTrue();
            text3.IsNullable<Encoding>(IgnoreCase.TRUE).ShouldBeTrue();
            text4.IsNullable<Encoding>(IgnoreCase.TRUE).ShouldBeTrue();
            text5.IsNullable<Encoding>(IgnoreCase.TRUE).ShouldBeTrue();
            text6.IsNullable<Encoding>(IgnoreCase.TRUE).ShouldBeTrue();
            text7.IsNullable<Encoding>(IgnoreCase.TRUE).ShouldBeTrue();
            text8.IsNullable<Encoding>(IgnoreCase.TRUE).ShouldBeTrue();
            text9.IsNullable<Encoding>(IgnoreCase.TRUE).ShouldBeTrue();
            textA.IsNullable<Encoding>(IgnoreCase.TRUE).ShouldBeTrue();
            textB.IsNullable<Encoding>(IgnoreCase.TRUE).ShouldBeTrue();
            textC.IsNullable<Encoding>(IgnoreCase.TRUE).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable Encoding type or not test")]
        public void JudgingNullOrEmptyStringIsNullableEncodingTypeTest()
        {
            var type = typeof(Encoding);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "---";

            text0.Is(type).ShouldBeFalse();
            text1.Is(type).ShouldBeFalse();
            text2.Is(type).ShouldBeFalse();
            text3.Is(type).ShouldBeFalse();

            text0.IsNullable(type).ShouldBeTrue();
            text1.IsNullable(type).ShouldBeFalse();
            text2.IsNullable(type).ShouldBeFalse();
            text3.IsNullable(type).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable Encoding type or not and ignore case test")]
        public void JudgingNullOrEmptyStringIsNullableEncodingTypeWithIgnoreCaseTest()
        {
            var type = typeof(Encoding);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "---";

            text0.Is(type, IgnoreCase.TRUE).ShouldBeFalse();
            text1.Is(type, IgnoreCase.TRUE).ShouldBeFalse();
            text2.Is(type, IgnoreCase.TRUE).ShouldBeFalse();
            text3.Is(type, IgnoreCase.TRUE).ShouldBeFalse();

            text0.IsNullable(type, IgnoreCase.TRUE).ShouldBeTrue();
            text1.IsNullable(type, IgnoreCase.TRUE).ShouldBeFalse();
            text2.IsNullable(type, IgnoreCase.TRUE).ShouldBeFalse();
            text3.IsNullable(type, IgnoreCase.TRUE).ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable Encoding type or not by generic type test")]
        public void JudgingNullOrEmptyStringIsNullableEncodingTypeByGenericTypeTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "---";

            text0.IsNullable<Encoding>().ShouldBeTrue();
            text1.IsNullable<Encoding>().ShouldBeFalse();
            text2.IsNullable<Encoding>().ShouldBeFalse();
            text3.IsNullable<Encoding>().ShouldBeFalse();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable Encoding type or not by generic type and ignore case test")]
        public void JudgingNullOrEmptyStringIsNullableEncodingTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "---";

            text0.IsNullable<Encoding>(IgnoreCase.TRUE).ShouldBeTrue();
            text1.IsNullable<Encoding>(IgnoreCase.TRUE).ShouldBeFalse();
            text2.IsNullable<Encoding>(IgnoreCase.TRUE).ShouldBeFalse();
            text3.IsNullable<Encoding>(IgnoreCase.TRUE).ShouldBeFalse();
        }
    }
}