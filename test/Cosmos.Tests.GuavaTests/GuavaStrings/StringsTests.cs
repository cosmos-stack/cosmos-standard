using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Guava;
using Shouldly;
using Xunit;

namespace Cosmos.Tests.GuavaTests.GuavaStrings
{
    public class StringsTests
    {
        [Fact]
        public void StringTest()
        {
            string str = "str";
            var checker = Strings.NullToEmpty(str);
            checker.ShouldBe("str");
        }

        [Fact]
        public void NullStringTest()
        {
            string str = null;
            var checker = Strings.NullToEmpty(str);
            checker.ShouldBeEmpty();
            checker.ShouldBe(string.Empty);
        }

        [Fact]
        public void EmptyStringTest()
        {
            string str = string.Empty;
            var checker = Strings.NullToEmpty(str);
            checker.ShouldBeEmpty();
            checker.ShouldBe(string.Empty);
        }

        [Fact]
        public void WhiteSpaceStringTest()
        {
            string str = "";
            var checker = Strings.NullToEmpty(str);
            checker.ShouldBe("");
        }
    }
}
