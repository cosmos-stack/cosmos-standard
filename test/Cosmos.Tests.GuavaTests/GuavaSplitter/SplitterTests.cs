using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using Cosmos.Guava;
using Shouldly;
using Xunit;

namespace Cosmos.Tests.GuavaTests.GuavaSplitter
{
    public class SplitterTests
    {
        private static class OriginalStrings
        {
            public static string NormalString { get; } = "a,b,c,d,e";
            public static string IncludeNullString { get; } = "a,,b,,,c,d,e";
            public static string IncludeWhiteSpaceString { get; } = "a, b ,c,d,e";
        }

        [Fact]
        public void StringToEnumerableTest()
        {
            var enumerable = Splitter.On(",").Split(OriginalStrings.NormalString);
            // ReSharper disable once PossibleMultipleEnumeration
            enumerable.Count().ShouldBe(5);

            // ReSharper disable once PossibleMultipleEnumeration
            var list = enumerable.ToList();

            list.Count().ShouldBe(5);

            list[0].ShouldBe("a");
            list[1].ShouldBe("b");
            list[2].ShouldBe("c");
            list[3].ShouldBe("d");
            list[4].ShouldBe("e");
        }

        [Fact]
        public void StringToEnumerableIncludeNullTest()
        {
            var @base = Splitter.On(",").Split(OriginalStrings.IncludeNullString);
            // ReSharper disable once PossibleMultipleEnumeration
            @base.Count().ShouldBe(8);

            var enumerable = Splitter.On(",").OmitEmptyStrings().Split(OriginalStrings.IncludeNullString);
            // ReSharper disable once PossibleMultipleEnumeration
            enumerable.Count().ShouldBe(5);

            // ReSharper disable once PossibleMultipleEnumeration
            var @baseList = @base.ToList();

            @baseList[0].ShouldBe("a");
            @baseList[1].ShouldBe("");
            @baseList[2].ShouldBe("b");
            @baseList[3].ShouldBe("");
            @baseList[4].ShouldBe("");
            @baseList[5].ShouldBe("c");
            @baseList[6].ShouldBe("d");
            @baseList[7].ShouldBe("e");

            // ReSharper disable once PossibleMultipleEnumeration
            var list = enumerable.ToList();

            list[0].ShouldBe("a");
            list[1].ShouldBe("b");
            list[2].ShouldBe("c");
            list[3].ShouldBe("d");
            list[4].ShouldBe("e");
        }

        [Fact]
        public void StringToEnumerableFromStringPatternTest()
        {
            var pattern = ",";

            var enumerable = Splitter.OnPattern(pattern).Split(OriginalStrings.NormalString);
            // ReSharper disable once PossibleMultipleEnumeration
            enumerable.Count().ShouldBe(5);

            // ReSharper disable once PossibleMultipleEnumeration
            var list = enumerable.ToList();

            list[0].ShouldBe("a");
            list[1].ShouldBe("b");
            list[2].ShouldBe("c");
            list[3].ShouldBe("d");
            list[4].ShouldBe("e");
        }

        [Fact]
        public void StringToEnumerableFromRegexPatternTest()
        {
            var pattern = new Regex(",");

            var enumerable = Splitter.On(pattern).Split(OriginalStrings.NormalString);
            // ReSharper disable once PossibleMultipleEnumeration
            enumerable.Count().ShouldBe(5);

            // ReSharper disable once PossibleMultipleEnumeration
            var list = enumerable.ToList();

            list[0].ShouldBe("a");
            list[1].ShouldBe("b");
            list[2].ShouldBe("c");
            list[3].ShouldBe("d");
            list[4].ShouldBe("e");
        }

        [Fact]
        public void StringToEnumerableWithLimitTest()
        {
            var enumerable = Splitter.On(",").Limit(3).Split(OriginalStrings.NormalString);
            // ReSharper disable once PossibleMultipleEnumeration
            enumerable.Count().ShouldBe(3);

            // ReSharper disable once PossibleMultipleEnumeration
            var list = enumerable.ToList();

            list.Count().ShouldBe(3);

            list[0].ShouldBe("a");
            list[1].ShouldBe("b");
            list[2].ShouldBe("c");
        }

        [Fact]
        public void StringToEnumerableWithTrimTest()
        {
            var @base = Splitter.On(",").Split(OriginalStrings.IncludeWhiteSpaceString);
            // ReSharper disable once PossibleMultipleEnumeration
            @base.Count().ShouldBe(5);

            var enumerable = Splitter.On(",").TrimResults().Split(OriginalStrings.IncludeWhiteSpaceString);
            // ReSharper disable once PossibleMultipleEnumeration
            enumerable.Count().ShouldBe(5);

            // ReSharper disable once PossibleMultipleEnumeration
            var @baseList = @base.ToList();

            @baseList[0].ShouldBe("a");
            @baseList[1].ShouldBe(" b ");
            @baseList[2].ShouldBe("c");
            @baseList[3].ShouldBe("d");
            @baseList[4].ShouldBe("e");


            // ReSharper disable once PossibleMultipleEnumeration
            var list = enumerable.ToList();

            list[0].ShouldBe("a");
            list[1].ShouldBe("b");
            list[2].ShouldBe("c");
            list[3].ShouldBe("d");
            list[4].ShouldBe("e");
        }

        [Fact]
        public void StringToEnumerableWithCustomTrimTest()
        {
            var @base = Splitter.On(",").Split(OriginalStrings.IncludeWhiteSpaceString);
            // ReSharper disable once PossibleMultipleEnumeration
            @base.Count().ShouldBe(5);

            var enumerable = Splitter.On(",").TrimResults(s => s.TrimStart()).Split(OriginalStrings.IncludeWhiteSpaceString);
            // ReSharper disable once PossibleMultipleEnumeration
            enumerable.Count().ShouldBe(5);

            // ReSharper disable once PossibleMultipleEnumeration
            var @baseList = @base.ToList();

            @baseList[0].ShouldBe("a");
            @baseList[1].ShouldBe(" b ");
            @baseList[2].ShouldBe("c");
            @baseList[3].ShouldBe("d");
            @baseList[4].ShouldBe("e");


            // ReSharper disable once PossibleMultipleEnumeration
            var list = enumerable.ToList();

            list[0].ShouldBe("a");
            list[1].ShouldBe("b ");
            list[2].ShouldBe("c");
            list[3].ShouldBe("d");
            list[4].ShouldBe("e");
        }

        [Fact]
        public void StringToListTest()
        {
            var list = Splitter.On(",").SplitToList(OriginalStrings.NormalString);

            list.Count().ShouldBe(5);

            list[0].ShouldBe("a");
            list[1].ShouldBe("b");
            list[2].ShouldBe("c");
            list[3].ShouldBe("d");
            list[4].ShouldBe("e");
        }

        [Fact]
        public void StringToListIncludeNullTest()
        {
            var @base = Splitter.On(",").SplitToList(OriginalStrings.IncludeNullString);
            @base.Count().ShouldBe(8);

            var list = Splitter.On(",").OmitEmptyStrings().SplitToList(OriginalStrings.IncludeNullString);
            list.Count.ShouldBe(5);

            @base[0].ShouldBe("a");
            @base[1].ShouldBe("");
            @base[2].ShouldBe("b");
            @base[3].ShouldBe("");
            @base[4].ShouldBe("");
            @base[5].ShouldBe("c");
            @base[6].ShouldBe("d");
            @base[7].ShouldBe("e");

            list[0].ShouldBe("a");
            list[1].ShouldBe("b");
            list[2].ShouldBe("c");
            list[3].ShouldBe("d");
            list[4].ShouldBe("e");
        }

        [Fact]
        public void StringToListFromStringPatternTest()
        {
            var pattern = ",";

            var list = Splitter.OnPattern(pattern).SplitToList(OriginalStrings.NormalString);
            list.Count().ShouldBe(5);

            list[0].ShouldBe("a");
            list[1].ShouldBe("b");
            list[2].ShouldBe("c");
            list[3].ShouldBe("d");
            list[4].ShouldBe("e");
        }

        [Fact]
        public void StringToListFromRegexPatternTest()
        {
            var pattern = new Regex(",");

            var list = Splitter.On(pattern).SplitToList(OriginalStrings.NormalString);
            list.Count().ShouldBe(5);

            list[0].ShouldBe("a");
            list[1].ShouldBe("b");
            list[2].ShouldBe("c");
            list[3].ShouldBe("d");
            list[4].ShouldBe("e");
        }

        [Fact]
        public void StringToListWithLimitTest()
        {
            var list = Splitter.On(",").Limit(3).SplitToList(OriginalStrings.NormalString);

            list.Count().ShouldBe(3);

            list[0].ShouldBe("a");
            list[1].ShouldBe("b");
            list[2].ShouldBe("c");
        }

        [Fact]
        public void StringToListWithTrimTest()
        {
            var @base = Splitter.On(",").SplitToList(OriginalStrings.IncludeWhiteSpaceString);
            @base.Count().ShouldBe(5);

            var list = Splitter.On(",").TrimResults().SplitToList(OriginalStrings.IncludeWhiteSpaceString);
            list.Count().ShouldBe(5);

            @base[0].ShouldBe("a");
            @base[1].ShouldBe(" b ");
            @base[2].ShouldBe("c");
            @base[3].ShouldBe("d");
            @base[4].ShouldBe("e");


            list[0].ShouldBe("a");
            list[1].ShouldBe("b");
            list[2].ShouldBe("c");
            list[3].ShouldBe("d");
            list[4].ShouldBe("e");
        }

        [Fact]
        public void StringToListWithCustomTrimTest()
        {
            var @base = Splitter.On(",").SplitToList(OriginalStrings.IncludeWhiteSpaceString);
            @base.Count().ShouldBe(5);

            var list = Splitter.On(",").TrimResults(s => s.TrimStart()).SplitToList(OriginalStrings.IncludeWhiteSpaceString);
            list.Count().ShouldBe(5);

            @base[0].ShouldBe("a");
            @base[1].ShouldBe(" b ");
            @base[2].ShouldBe("c");
            @base[3].ShouldBe("d");
            @base[4].ShouldBe("e");


            list[0].ShouldBe("a");
            list[1].ShouldBe("b ");
            list[2].ShouldBe("c");
            list[3].ShouldBe("d");
            list[4].ShouldBe("e");
        }
    }

}
