using System;
using Cosmos.Text;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.ConvUT
{
    [Trait("ConvUT", "StringConv.JudgeIsGuid")]
    public class StringConvBeGuidTypeTests
    {
        [Fact(DisplayName = "To judge string is Guid type or not test")]
        public void JudgingStringIsGuidTypeTest()
        {
            var type = typeof(Guid);
            var text0 = Guid.NewGuid().ToString("B");
            var text1 = Guid.NewGuid().ToString("D");
            var text2 = Guid.NewGuid().ToString("N");
            var text3 = Guid.NewGuid().ToString("P");
            var text4 = Guid.NewGuid().ToString("B").ToUpperInvariant();
            var text5 = Guid.NewGuid().ToString("D").ToUpperInvariant();
            var text6 = Guid.NewGuid().ToString("N").ToUpperInvariant();
            var text7 = Guid.NewGuid().ToString("P").ToUpperInvariant();
            var text8 = Guid.NewGuid().ToString("B").ToLowerInvariant();
            var text9 = Guid.NewGuid().ToString("D").ToLowerInvariant();
            var textA = Guid.NewGuid().ToString("N").ToLowerInvariant();
            var textB = Guid.NewGuid().ToString("P").ToLowerInvariant();

            text0.Is(type).ShouldBeTrue();
            text1.Is(type).ShouldBeTrue();
            text2.Is(type).ShouldBeTrue();
            text3.Is(type).ShouldBeTrue();
            text4.Is(type).ShouldBeTrue();
            text5.Is(type).ShouldBeTrue();
            text6.Is(type).ShouldBeTrue();
            text7.Is(type).ShouldBeTrue();
            text8.Is(type).ShouldBeTrue();
            text9.Is(type).ShouldBeTrue();
            textA.Is(type).ShouldBeTrue();
            textB.Is(type).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is Guid type or not and ignore case test")]
        public void JudgingStringIsGuidTypeWithIgnoreCaseTest()
        {
            var type = typeof(Guid);
            var text0 = Guid.NewGuid().ToString("B");
            var text1 = Guid.NewGuid().ToString("D");
            var text2 = Guid.NewGuid().ToString("N");
            var text3 = Guid.NewGuid().ToString("P");
            var text4 = Guid.NewGuid().ToString("B").ToUpperInvariant();
            var text5 = Guid.NewGuid().ToString("D").ToUpperInvariant();
            var text6 = Guid.NewGuid().ToString("N").ToUpperInvariant();
            var text7 = Guid.NewGuid().ToString("P").ToUpperInvariant();
            var text8 = Guid.NewGuid().ToString("B").ToLowerInvariant();
            var text9 = Guid.NewGuid().ToString("D").ToLowerInvariant();
            var textA = Guid.NewGuid().ToString("N").ToLowerInvariant();
            var textB = Guid.NewGuid().ToString("P").ToLowerInvariant();

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
        }

        [Fact(DisplayName = "To judge string is Guid type or not by generic type test")]
        public void JudgingStringIsGuidTypeByGenericTypeTest()
        {
            var text0 = Guid.NewGuid().ToString("B");
            var text1 = Guid.NewGuid().ToString("D");
            var text2 = Guid.NewGuid().ToString("N");
            var text3 = Guid.NewGuid().ToString("P");
            var text4 = Guid.NewGuid().ToString("B").ToUpperInvariant();
            var text5 = Guid.NewGuid().ToString("D").ToUpperInvariant();
            var text6 = Guid.NewGuid().ToString("N").ToUpperInvariant();
            var text7 = Guid.NewGuid().ToString("P").ToUpperInvariant();
            var text8 = Guid.NewGuid().ToString("B").ToLowerInvariant();
            var text9 = Guid.NewGuid().ToString("D").ToLowerInvariant();
            var textA = Guid.NewGuid().ToString("N").ToLowerInvariant();
            var textB = Guid.NewGuid().ToString("P").ToLowerInvariant();

            text0.Is<Guid>().ShouldBeTrue();
            text1.Is<Guid>().ShouldBeTrue();
            text2.Is<Guid>().ShouldBeTrue();
            text3.Is<Guid>().ShouldBeTrue();
            text4.Is<Guid>().ShouldBeTrue();
            text5.Is<Guid>().ShouldBeTrue();
            text6.Is<Guid>().ShouldBeTrue();
            text7.Is<Guid>().ShouldBeTrue();
            text8.Is<Guid>().ShouldBeTrue();
            text9.Is<Guid>().ShouldBeTrue();
            textA.Is<Guid>().ShouldBeTrue();
            textB.Is<Guid>().ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is Guid type or not by generic type and ignore case test")]
        public void JudgingStringIsGuidTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            var text0 = Guid.NewGuid().ToString("B");
            var text1 = Guid.NewGuid().ToString("D");
            var text2 = Guid.NewGuid().ToString("N");
            var text3 = Guid.NewGuid().ToString("P");
            var text4 = Guid.NewGuid().ToString("B").ToUpperInvariant();
            var text5 = Guid.NewGuid().ToString("D").ToUpperInvariant();
            var text6 = Guid.NewGuid().ToString("N").ToUpperInvariant();
            var text7 = Guid.NewGuid().ToString("P").ToUpperInvariant();
            var text8 = Guid.NewGuid().ToString("B").ToLowerInvariant();
            var text9 = Guid.NewGuid().ToString("D").ToLowerInvariant();
            var textA = Guid.NewGuid().ToString("N").ToLowerInvariant();
            var textB = Guid.NewGuid().ToString("P").ToLowerInvariant();

            text0.Is<Guid>(IgnoreCase.TRUE).ShouldBeTrue();
            text1.Is<Guid>(IgnoreCase.TRUE).ShouldBeTrue();
            text2.Is<Guid>(IgnoreCase.TRUE).ShouldBeTrue();
            text3.Is<Guid>(IgnoreCase.TRUE).ShouldBeTrue();
            text4.Is<Guid>(IgnoreCase.TRUE).ShouldBeTrue();
            text5.Is<Guid>(IgnoreCase.TRUE).ShouldBeTrue();
            text6.Is<Guid>(IgnoreCase.TRUE).ShouldBeTrue();
            text7.Is<Guid>(IgnoreCase.TRUE).ShouldBeTrue();
            text8.Is<Guid>(IgnoreCase.TRUE).ShouldBeTrue();
            text9.Is<Guid>(IgnoreCase.TRUE).ShouldBeTrue();
            textA.Is<Guid>(IgnoreCase.TRUE).ShouldBeTrue();
            textB.Is<Guid>(IgnoreCase.TRUE).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge null or empty string is Guid type or not test")]
        public void JudgingNullOrEmptyStringIsGuidTypeTest()
        {
            var type = typeof(Guid);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "---";
            string text4 = Guid.Empty.ToString("B");
            string text5 = Guid.Empty.ToString("D");
            string text6 = Guid.Empty.ToString("N");
            string text7 = Guid.Empty.ToString("P");

            text0.Is(type).ShouldBeFalse();
            text1.Is(type).ShouldBeFalse();
            text2.Is(type).ShouldBeFalse();
            text3.Is(type).ShouldBeFalse();
            text4.Is(type).ShouldBeTrue();
            text5.Is(type).ShouldBeTrue();
            text6.Is(type).ShouldBeTrue();
            text7.Is(type).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge null or empty string is Guid type or not and ignore case test")]
        public void JudgingNullOrEmptyStringIsGuidTypeWithIgnoreCaseTest()
        {
            var type = typeof(Guid);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "---";
            string text4 = Guid.Empty.ToString("B");
            string text5 = Guid.Empty.ToString("D");
            string text6 = Guid.Empty.ToString("N");
            string text7 = Guid.Empty.ToString("P");

            text0.Is(type, IgnoreCase.TRUE).ShouldBeFalse();
            text1.Is(type, IgnoreCase.TRUE).ShouldBeFalse();
            text2.Is(type, IgnoreCase.TRUE).ShouldBeFalse();
            text3.Is(type, IgnoreCase.TRUE).ShouldBeFalse();
            text4.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text5.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text6.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text7.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge null or empty string is Guid type or not by generic type test")]
        public void JudgingNullOrEmptyStringIsGuidTypeByGenericTypeTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "---";
            string text4 = Guid.Empty.ToString("B");
            string text5 = Guid.Empty.ToString("D");
            string text6 = Guid.Empty.ToString("N");
            string text7 = Guid.Empty.ToString("P");

            text0.Is<Guid>().ShouldBeFalse();
            text1.Is<Guid>().ShouldBeFalse();
            text2.Is<Guid>().ShouldBeFalse();
            text3.Is<Guid>().ShouldBeFalse();
            text4.Is<Guid>().ShouldBeTrue();
            text5.Is<Guid>().ShouldBeTrue();
            text6.Is<Guid>().ShouldBeTrue();
            text7.Is<Guid>().ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge null or empty string is Guid type or not by generic type and ignore case test")]
        public void JudgingNullOrEmptyStringIsGuidTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "---";
            string text4 = Guid.Empty.ToString("B");
            string text5 = Guid.Empty.ToString("D");
            string text6 = Guid.Empty.ToString("N");
            string text7 = Guid.Empty.ToString("P");

            text0.Is<Guid>(IgnoreCase.TRUE).ShouldBeFalse();
            text1.Is<Guid>(IgnoreCase.TRUE).ShouldBeFalse();
            text2.Is<Guid>(IgnoreCase.TRUE).ShouldBeFalse();
            text3.Is<Guid>(IgnoreCase.TRUE).ShouldBeFalse();
            text4.Is<Guid>(IgnoreCase.TRUE).ShouldBeTrue();
            text5.Is<Guid>(IgnoreCase.TRUE).ShouldBeTrue();
            text6.Is<Guid>(IgnoreCase.TRUE).ShouldBeTrue();
            text7.Is<Guid>(IgnoreCase.TRUE).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable Guid type or not test")]
        public void JudgingStringIsNullableGuidTypeTest()
        {
            var type = typeof(Guid);
            var nullableType = typeof(Guid?);
            var text0 = Guid.NewGuid().ToString("B");
            var text1 = Guid.NewGuid().ToString("D");
            var text2 = Guid.NewGuid().ToString("N");
            var text3 = Guid.NewGuid().ToString("P");
            var text4 = Guid.NewGuid().ToString("B").ToUpperInvariant();
            var text5 = Guid.NewGuid().ToString("D").ToUpperInvariant();
            var text6 = Guid.NewGuid().ToString("N").ToUpperInvariant();
            var text7 = Guid.NewGuid().ToString("P").ToUpperInvariant();
            var text8 = Guid.NewGuid().ToString("B").ToLowerInvariant();
            var text9 = Guid.NewGuid().ToString("D").ToLowerInvariant();
            var textA = Guid.NewGuid().ToString("N").ToLowerInvariant();
            var textB = Guid.NewGuid().ToString("P").ToLowerInvariant();

            text0.Is(type).ShouldBeTrue();
            text1.Is(type).ShouldBeTrue();
            text2.Is(type).ShouldBeTrue();
            text3.Is(type).ShouldBeTrue();
            text4.Is(type).ShouldBeTrue();
            text5.Is(type).ShouldBeTrue();
            text6.Is(type).ShouldBeTrue();
            text7.Is(type).ShouldBeTrue();
            text8.Is(type).ShouldBeTrue();
            text9.Is(type).ShouldBeTrue();
            textA.Is(type).ShouldBeTrue();
            textB.Is(type).ShouldBeTrue();

            text0.Is(nullableType).ShouldBeTrue();
            text1.Is(nullableType).ShouldBeTrue();
            text2.Is(nullableType).ShouldBeTrue();
            text3.Is(nullableType).ShouldBeTrue();
            text4.Is(nullableType).ShouldBeTrue();
            text5.Is(nullableType).ShouldBeTrue();
            text6.Is(nullableType).ShouldBeTrue();
            text7.Is(nullableType).ShouldBeTrue();
            text8.Is(nullableType).ShouldBeTrue();
            text9.Is(nullableType).ShouldBeTrue();
            textA.Is(nullableType).ShouldBeTrue();
            textB.Is(nullableType).ShouldBeTrue();

            text0.IsNullable(type).ShouldBeTrue();
            text1.IsNullable(type).ShouldBeTrue();
            text2.IsNullable(type).ShouldBeTrue();
            text3.IsNullable(type).ShouldBeTrue();
            text4.IsNullable(type).ShouldBeTrue();
            text5.IsNullable(type).ShouldBeTrue();
            text6.IsNullable(type).ShouldBeTrue();
            text7.IsNullable(type).ShouldBeTrue();
            text8.IsNullable(type).ShouldBeTrue();
            text9.IsNullable(type).ShouldBeTrue();
            textA.IsNullable(type).ShouldBeTrue();
            textB.IsNullable(type).ShouldBeTrue();

            text0.IsNullable(nullableType).ShouldBeTrue();
            text1.IsNullable(nullableType).ShouldBeTrue();
            text2.IsNullable(nullableType).ShouldBeTrue();
            text3.IsNullable(nullableType).ShouldBeTrue();
            text4.IsNullable(nullableType).ShouldBeTrue();
            text5.IsNullable(nullableType).ShouldBeTrue();
            text6.IsNullable(nullableType).ShouldBeTrue();
            text7.IsNullable(nullableType).ShouldBeTrue();
            text8.IsNullable(nullableType).ShouldBeTrue();
            text9.IsNullable(nullableType).ShouldBeTrue();
            textA.IsNullable(nullableType).ShouldBeTrue();
            textB.IsNullable(nullableType).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable Guid type or not and ignore case test")]
        public void JudgingStringIsNullableGuidTypeWithIgnoreCaseTest()
        {
            var type = typeof(Guid);
            var nullableType = typeof(Guid?);
            var text0 = Guid.NewGuid().ToString("B");
            var text1 = Guid.NewGuid().ToString("D");
            var text2 = Guid.NewGuid().ToString("N");
            var text3 = Guid.NewGuid().ToString("P");
            var text4 = Guid.NewGuid().ToString("B").ToUpperInvariant();
            var text5 = Guid.NewGuid().ToString("D").ToUpperInvariant();
            var text6 = Guid.NewGuid().ToString("N").ToUpperInvariant();
            var text7 = Guid.NewGuid().ToString("P").ToUpperInvariant();
            var text8 = Guid.NewGuid().ToString("B").ToLowerInvariant();
            var text9 = Guid.NewGuid().ToString("D").ToLowerInvariant();
            var textA = Guid.NewGuid().ToString("N").ToLowerInvariant();
            var textB = Guid.NewGuid().ToString("P").ToLowerInvariant();

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

            text0.Is(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text1.Is(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text2.Is(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text3.Is(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text4.Is(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text5.Is(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text6.Is(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text7.Is(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text8.Is(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text9.Is(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            textA.Is(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            textB.Is(nullableType, IgnoreCase.TRUE).ShouldBeTrue();

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

            text0.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text1.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text2.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text3.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text4.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text5.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text6.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text7.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text8.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text9.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            textA.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            textB.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable Guid type or not by generic type test")]
        public void JudgingStringIsNullableGuidTypeByGenericTypeTest()
        {
            var text0 = Guid.NewGuid().ToString("B");
            var text1 = Guid.NewGuid().ToString("D");
            var text2 = Guid.NewGuid().ToString("N");
            var text3 = Guid.NewGuid().ToString("P");
            var text4 = Guid.NewGuid().ToString("B").ToUpperInvariant();
            var text5 = Guid.NewGuid().ToString("D").ToUpperInvariant();
            var text6 = Guid.NewGuid().ToString("N").ToUpperInvariant();
            var text7 = Guid.NewGuid().ToString("P").ToUpperInvariant();
            var text8 = Guid.NewGuid().ToString("B").ToLowerInvariant();
            var text9 = Guid.NewGuid().ToString("D").ToLowerInvariant();
            var textA = Guid.NewGuid().ToString("N").ToLowerInvariant();
            var textB = Guid.NewGuid().ToString("P").ToLowerInvariant();

            text0.Is<Guid>().ShouldBeTrue();
            text1.Is<Guid>().ShouldBeTrue();
            text2.Is<Guid>().ShouldBeTrue();
            text3.Is<Guid>().ShouldBeTrue();
            text4.Is<Guid>().ShouldBeTrue();
            text5.Is<Guid>().ShouldBeTrue();
            text6.Is<Guid>().ShouldBeTrue();
            text7.Is<Guid>().ShouldBeTrue();
            text8.Is<Guid>().ShouldBeTrue();
            text9.Is<Guid>().ShouldBeTrue();
            textA.Is<Guid>().ShouldBeTrue();
            textB.Is<Guid>().ShouldBeTrue();

            text0.Is<Guid?>().ShouldBeTrue();
            text1.Is<Guid?>().ShouldBeTrue();
            text2.Is<Guid?>().ShouldBeTrue();
            text3.Is<Guid?>().ShouldBeTrue();
            text4.Is<Guid?>().ShouldBeTrue();
            text5.Is<Guid?>().ShouldBeTrue();
            text6.Is<Guid?>().ShouldBeTrue();
            text7.Is<Guid?>().ShouldBeTrue();
            text8.Is<Guid?>().ShouldBeTrue();
            text9.Is<Guid?>().ShouldBeTrue();
            textA.Is<Guid?>().ShouldBeTrue();
            textB.Is<Guid?>().ShouldBeTrue();

            text0.IsNullable<Guid>().ShouldBeTrue();
            text1.IsNullable<Guid>().ShouldBeTrue();
            text2.IsNullable<Guid>().ShouldBeTrue();
            text3.IsNullable<Guid>().ShouldBeTrue();
            text4.IsNullable<Guid>().ShouldBeTrue();
            text5.IsNullable<Guid>().ShouldBeTrue();
            text6.IsNullable<Guid>().ShouldBeTrue();
            text7.IsNullable<Guid>().ShouldBeTrue();
            text8.IsNullable<Guid>().ShouldBeTrue();
            text9.IsNullable<Guid>().ShouldBeTrue();
            textA.IsNullable<Guid>().ShouldBeTrue();
            textB.IsNullable<Guid>().ShouldBeTrue();

            text0.IsNullable<Guid?>().ShouldBeTrue();
            text1.IsNullable<Guid?>().ShouldBeTrue();
            text2.IsNullable<Guid?>().ShouldBeTrue();
            text3.IsNullable<Guid?>().ShouldBeTrue();
            text4.IsNullable<Guid?>().ShouldBeTrue();
            text5.IsNullable<Guid?>().ShouldBeTrue();
            text6.IsNullable<Guid?>().ShouldBeTrue();
            text7.IsNullable<Guid?>().ShouldBeTrue();
            text8.IsNullable<Guid?>().ShouldBeTrue();
            text9.IsNullable<Guid?>().ShouldBeTrue();
            textA.IsNullable<Guid?>().ShouldBeTrue();
            textB.IsNullable<Guid?>().ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge string is nullable Guid type or not by generic type and ignore case test")]
        public void JudgingStringIsNullableGuidTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            var text0 = Guid.NewGuid().ToString("B");
            var text1 = Guid.NewGuid().ToString("D");
            var text2 = Guid.NewGuid().ToString("N");
            var text3 = Guid.NewGuid().ToString("P");
            var text4 = Guid.NewGuid().ToString("B").ToUpperInvariant();
            var text5 = Guid.NewGuid().ToString("D").ToUpperInvariant();
            var text6 = Guid.NewGuid().ToString("N").ToUpperInvariant();
            var text7 = Guid.NewGuid().ToString("P").ToUpperInvariant();
            var text8 = Guid.NewGuid().ToString("B").ToLowerInvariant();
            var text9 = Guid.NewGuid().ToString("D").ToLowerInvariant();
            var textA = Guid.NewGuid().ToString("N").ToLowerInvariant();
            var textB = Guid.NewGuid().ToString("P").ToLowerInvariant();
            
            text0.Is<Guid>(IgnoreCase.TRUE).ShouldBeTrue();
            text1.Is<Guid>(IgnoreCase.TRUE).ShouldBeTrue();
            text2.Is<Guid>(IgnoreCase.TRUE).ShouldBeTrue();
            text3.Is<Guid>(IgnoreCase.TRUE).ShouldBeTrue();
            text4.Is<Guid>(IgnoreCase.TRUE).ShouldBeTrue();
            text5.Is<Guid>(IgnoreCase.TRUE).ShouldBeTrue();
            text6.Is<Guid>(IgnoreCase.TRUE).ShouldBeTrue();
            text7.Is<Guid>(IgnoreCase.TRUE).ShouldBeTrue();
            text8.Is<Guid>(IgnoreCase.TRUE).ShouldBeTrue();
            text9.Is<Guid>(IgnoreCase.TRUE).ShouldBeTrue();
            textA.Is<Guid>(IgnoreCase.TRUE).ShouldBeTrue();
            textB.Is<Guid>(IgnoreCase.TRUE).ShouldBeTrue();

            text0.Is<Guid?>(IgnoreCase.TRUE).ShouldBeTrue();
            text1.Is<Guid?>(IgnoreCase.TRUE).ShouldBeTrue();
            text2.Is<Guid?>(IgnoreCase.TRUE).ShouldBeTrue();
            text3.Is<Guid?>(IgnoreCase.TRUE).ShouldBeTrue();
            text4.Is<Guid?>(IgnoreCase.TRUE).ShouldBeTrue();
            text5.Is<Guid?>(IgnoreCase.TRUE).ShouldBeTrue();
            text6.Is<Guid?>(IgnoreCase.TRUE).ShouldBeTrue();
            text7.Is<Guid?>(IgnoreCase.TRUE).ShouldBeTrue();
            text8.Is<Guid?>(IgnoreCase.TRUE).ShouldBeTrue();
            text9.Is<Guid?>(IgnoreCase.TRUE).ShouldBeTrue();
            textA.Is<Guid?>(IgnoreCase.TRUE).ShouldBeTrue();
            textB.Is<Guid?>(IgnoreCase.TRUE).ShouldBeTrue();

            text0.IsNullable<Guid>(IgnoreCase.TRUE).ShouldBeTrue();
            text1.IsNullable<Guid>(IgnoreCase.TRUE).ShouldBeTrue();
            text2.IsNullable<Guid>(IgnoreCase.TRUE).ShouldBeTrue();
            text3.IsNullable<Guid>(IgnoreCase.TRUE).ShouldBeTrue();
            text4.IsNullable<Guid>(IgnoreCase.TRUE).ShouldBeTrue();
            text5.IsNullable<Guid>(IgnoreCase.TRUE).ShouldBeTrue();
            text6.IsNullable<Guid>(IgnoreCase.TRUE).ShouldBeTrue();
            text7.IsNullable<Guid>(IgnoreCase.TRUE).ShouldBeTrue();
            text8.IsNullable<Guid>(IgnoreCase.TRUE).ShouldBeTrue();
            text9.IsNullable<Guid>(IgnoreCase.TRUE).ShouldBeTrue();
            textA.IsNullable<Guid>(IgnoreCase.TRUE).ShouldBeTrue();
            textB.IsNullable<Guid>(IgnoreCase.TRUE).ShouldBeTrue();

            text0.IsNullable<Guid?>(IgnoreCase.TRUE).ShouldBeTrue();
            text1.IsNullable<Guid?>(IgnoreCase.TRUE).ShouldBeTrue();
            text2.IsNullable<Guid?>(IgnoreCase.TRUE).ShouldBeTrue();
            text3.IsNullable<Guid?>(IgnoreCase.TRUE).ShouldBeTrue();
            text4.IsNullable<Guid?>(IgnoreCase.TRUE).ShouldBeTrue();
            text5.IsNullable<Guid?>(IgnoreCase.TRUE).ShouldBeTrue();
            text6.IsNullable<Guid?>(IgnoreCase.TRUE).ShouldBeTrue();
            text7.IsNullable<Guid?>(IgnoreCase.TRUE).ShouldBeTrue();
            text8.IsNullable<Guid?>(IgnoreCase.TRUE).ShouldBeTrue();
            text9.IsNullable<Guid?>(IgnoreCase.TRUE).ShouldBeTrue();
            textA.IsNullable<Guid?>(IgnoreCase.TRUE).ShouldBeTrue();
            textB.IsNullable<Guid?>(IgnoreCase.TRUE).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable Guid type or not test")]
        public void JudgingNullOrEmptyStringIsNullableGuidTypeTest()
        {
            var type = typeof(Guid);
            var nullableType = typeof(Guid?);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "---";
            string text4 = Guid.Empty.ToString("B");
            string text5 = Guid.Empty.ToString("D");
            string text6 = Guid.Empty.ToString("N");
            string text7 = Guid.Empty.ToString("P");

            text0.Is(type).ShouldBeFalse();
            text1.Is(type).ShouldBeFalse();
            text2.Is(type).ShouldBeFalse();
            text3.Is(type).ShouldBeFalse();
            text4.Is(type).ShouldBeTrue();
            text5.Is(type).ShouldBeTrue();
            text6.Is(type).ShouldBeTrue();
            text7.Is(type).ShouldBeTrue();

            text0.Is(nullableType).ShouldBeTrue();
            text1.Is(nullableType).ShouldBeFalse();
            text2.Is(nullableType).ShouldBeFalse();
            text3.Is(nullableType).ShouldBeFalse();
            text4.Is(nullableType).ShouldBeTrue();
            text5.Is(nullableType).ShouldBeTrue();
            text6.Is(nullableType).ShouldBeTrue();
            text7.Is(nullableType).ShouldBeTrue();

            text0.IsNullable(type).ShouldBeTrue();
            text1.IsNullable(type).ShouldBeFalse();
            text2.IsNullable(type).ShouldBeFalse();
            text3.IsNullable(type).ShouldBeFalse();
            text4.IsNullable(type).ShouldBeTrue();
            text5.IsNullable(type).ShouldBeTrue();
            text6.IsNullable(type).ShouldBeTrue();
            text7.IsNullable(type).ShouldBeTrue();

            text0.IsNullable(nullableType).ShouldBeTrue();
            text1.IsNullable(nullableType).ShouldBeFalse();
            text2.IsNullable(nullableType).ShouldBeFalse();
            text3.IsNullable(nullableType).ShouldBeFalse();
            text4.IsNullable(nullableType).ShouldBeTrue();
            text5.IsNullable(nullableType).ShouldBeTrue();
            text6.IsNullable(nullableType).ShouldBeTrue();
            text7.IsNullable(nullableType).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable Guid type or not and ignore case test")]
        public void JudgingNullOrEmptyStringIsNullableGuidTypeWithIgnoreCaseTest()
        {
            var type = typeof(Guid);
            var nullableType = typeof(Guid?);
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "---";
            string text4 = Guid.Empty.ToString("B");
            string text5 = Guid.Empty.ToString("D");
            string text6 = Guid.Empty.ToString("N");
            string text7 = Guid.Empty.ToString("P");
            
            text0.Is(type, IgnoreCase.TRUE).ShouldBeFalse();
            text1.Is(type, IgnoreCase.TRUE).ShouldBeFalse();
            text2.Is(type, IgnoreCase.TRUE).ShouldBeFalse();
            text3.Is(type, IgnoreCase.TRUE).ShouldBeFalse();
            text4.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text5.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text6.Is(type, IgnoreCase.TRUE).ShouldBeTrue();
            text7.Is(type, IgnoreCase.TRUE).ShouldBeTrue();

            text0.Is(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text1.Is(nullableType, IgnoreCase.TRUE).ShouldBeFalse();
            text2.Is(nullableType, IgnoreCase.TRUE).ShouldBeFalse();
            text3.Is(nullableType, IgnoreCase.TRUE).ShouldBeFalse();
            text4.Is(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text5.Is(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text6.Is(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text7.Is(nullableType, IgnoreCase.TRUE).ShouldBeTrue();

            text0.IsNullable(type, IgnoreCase.TRUE).ShouldBeTrue();
            text1.IsNullable(type, IgnoreCase.TRUE).ShouldBeFalse();
            text2.IsNullable(type, IgnoreCase.TRUE).ShouldBeFalse();
            text3.IsNullable(type, IgnoreCase.TRUE).ShouldBeFalse();
            text4.IsNullable(type, IgnoreCase.TRUE).ShouldBeTrue();
            text5.IsNullable(type, IgnoreCase.TRUE).ShouldBeTrue();
            text6.IsNullable(type, IgnoreCase.TRUE).ShouldBeTrue();
            text7.IsNullable(type, IgnoreCase.TRUE).ShouldBeTrue();

            text0.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text1.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeFalse();
            text2.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeFalse();
            text3.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeFalse();
            text4.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text5.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text6.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
            text7.IsNullable(nullableType, IgnoreCase.TRUE).ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable Guid type or not by generic type test")]
        public void JudgingNullOrEmptyStringIsNullableGuidTypeByGenericTypeTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "---";
            string text4 = Guid.Empty.ToString("B");
            string text5 = Guid.Empty.ToString("D");
            string text6 = Guid.Empty.ToString("N");
            string text7 = Guid.Empty.ToString("P");

            text0.Is<Guid?>().ShouldBeTrue();
            text1.Is<Guid?>().ShouldBeFalse();
            text2.Is<Guid?>().ShouldBeFalse();
            text3.Is<Guid?>().ShouldBeFalse();
            text4.Is<Guid?>().ShouldBeTrue();
            text5.Is<Guid?>().ShouldBeTrue();
            text6.Is<Guid?>().ShouldBeTrue();
            text7.Is<Guid?>().ShouldBeTrue();

            text0.IsNullable<Guid>().ShouldBeTrue();
            text1.IsNullable<Guid>().ShouldBeFalse();
            text2.IsNullable<Guid>().ShouldBeFalse();
            text3.IsNullable<Guid>().ShouldBeFalse();
            text4.IsNullable<Guid>().ShouldBeTrue();
            text5.IsNullable<Guid>().ShouldBeTrue();
            text6.IsNullable<Guid>().ShouldBeTrue();
            text7.IsNullable<Guid>().ShouldBeTrue();

            text0.IsNullable<Guid?>().ShouldBeTrue();
            text1.IsNullable<Guid?>().ShouldBeFalse();
            text2.IsNullable<Guid?>().ShouldBeFalse();
            text3.IsNullable<Guid?>().ShouldBeFalse();
            text4.IsNullable<Guid?>().ShouldBeTrue();
            text5.IsNullable<Guid?>().ShouldBeTrue();
            text6.IsNullable<Guid?>().ShouldBeTrue();
            text7.IsNullable<Guid?>().ShouldBeTrue();
        }

        [Fact(DisplayName = "To judge null or empty string is nullable Guid type or not by generic type and ignore case test")]
        public void JudgingNullOrEmptyStringIsNullableGuidTypeByGenericTypeAndWithIgnoreCaseTest()
        {
            string text0 = null;
            string text1 = string.Empty;
            string text2 = "";
            string text3 = "---";
            string text4 = Guid.Empty.ToString("B");
            string text5 = Guid.Empty.ToString("D");
            string text6 = Guid.Empty.ToString("N");
            string text7 = Guid.Empty.ToString("P");
            
            text0.Is<Guid?>(IgnoreCase.TRUE).ShouldBeTrue();
            text1.Is<Guid?>(IgnoreCase.TRUE).ShouldBeFalse();
            text2.Is<Guid?>(IgnoreCase.TRUE).ShouldBeFalse();
            text3.Is<Guid?>(IgnoreCase.TRUE).ShouldBeFalse();
            text4.Is<Guid?>(IgnoreCase.TRUE).ShouldBeTrue();
            text5.Is<Guid?>(IgnoreCase.TRUE).ShouldBeTrue();
            text6.Is<Guid?>(IgnoreCase.TRUE).ShouldBeTrue();
            text7.Is<Guid?>(IgnoreCase.TRUE).ShouldBeTrue();

            text0.IsNullable<Guid>(IgnoreCase.TRUE).ShouldBeTrue();
            text1.IsNullable<Guid>(IgnoreCase.TRUE).ShouldBeFalse();
            text2.IsNullable<Guid>(IgnoreCase.TRUE).ShouldBeFalse();
            text3.IsNullable<Guid>(IgnoreCase.TRUE).ShouldBeFalse();
            text4.IsNullable<Guid>(IgnoreCase.TRUE).ShouldBeTrue();
            text5.IsNullable<Guid>(IgnoreCase.TRUE).ShouldBeTrue();
            text6.IsNullable<Guid>(IgnoreCase.TRUE).ShouldBeTrue();
            text7.IsNullable<Guid>(IgnoreCase.TRUE).ShouldBeTrue();

            text0.IsNullable<Guid?>(IgnoreCase.TRUE).ShouldBeTrue();
            text1.IsNullable<Guid?>(IgnoreCase.TRUE).ShouldBeFalse();
            text2.IsNullable<Guid?>(IgnoreCase.TRUE).ShouldBeFalse();
            text3.IsNullable<Guid?>(IgnoreCase.TRUE).ShouldBeFalse();
            text4.IsNullable<Guid?>(IgnoreCase.TRUE).ShouldBeTrue();
            text5.IsNullable<Guid?>(IgnoreCase.TRUE).ShouldBeTrue();
            text6.IsNullable<Guid?>(IgnoreCase.TRUE).ShouldBeTrue();
            text7.IsNullable<Guid?>(IgnoreCase.TRUE).ShouldBeTrue();
        }
    }
}