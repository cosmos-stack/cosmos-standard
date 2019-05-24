using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Shouldly;
using Xunit;
using Splitter = Cosmos.Splitters.Splitter;

namespace Cosmos.Tests.GuavaTests.GuavaSplitter
{
    public class FixedLengthSplitterTests
    {
        private static class OriginalStrings
        {
            public static string NormalString { get; } = "abcdefghijklmnopqrstuvwxyz";
            public static string IncludeWhiteSpaceString { get; } = "abcdefghijklmnopqrstuvwx yz";
        }

        [Fact]
        public void StringToFixedLengthEnumerableTest()
        {
            var enumerable = Splitter.FixedLength(3).Split(OriginalStrings.NormalString);
            // ReSharper disable once PossibleMultipleEnumeration
            enumerable.Count().ShouldBe(9);

            // ReSharper disable once PossibleMultipleEnumeration
            var list = enumerable.ToList();

            list.Count().ShouldBe(9);

            list[0].ShouldBe("abc");
            list[1].ShouldBe("def");
            list[2].ShouldBe("ghi");
            list[3].ShouldBe("jkl");
            list[4].ShouldBe("mno");
            list[5].ShouldBe("pqr");
            list[6].ShouldBe("stu");
            list[7].ShouldBe("vwx");
            list[8].ShouldBe("yz");
        }
        
        [Fact]
        public void StringToFixedLengthEnumerableWithLimitTest()
        {
            var enumerable = Splitter.FixedLength(3).Limit(3).Split(OriginalStrings.NormalString);
            // ReSharper disable once PossibleMultipleEnumeration
            enumerable.Count().ShouldBe(3);

            // ReSharper disable once PossibleMultipleEnumeration
            var list = enumerable.ToList();

            list.Count().ShouldBe(3);

            list[0].ShouldBe("abc");
            list[1].ShouldBe("def");
            list[2].ShouldBe("ghi");
        }

        [Fact]
        public void StringToFixedLengthEnumerableWithTrimTest()
        {
            var @base = Splitter.FixedLength(3).Split(OriginalStrings.IncludeWhiteSpaceString);
            // ReSharper disable once PossibleMultipleEnumeration
            @base.Count().ShouldBe(9);

            var enumerable = Splitter.FixedLength(3).TrimResults().Split(OriginalStrings.IncludeWhiteSpaceString);
            // ReSharper disable once PossibleMultipleEnumeration
            enumerable.Count().ShouldBe(9);

            // ReSharper disable once PossibleMultipleEnumeration
            var @baseList = @base.ToList();

            @baseList[0].ShouldBe("abc");
            @baseList[1].ShouldBe("def");
            @baseList[2].ShouldBe("ghi");
            @baseList[3].ShouldBe("jkl");
            @baseList[4].ShouldBe("mno");
            @baseList[5].ShouldBe("pqr");
            @baseList[6].ShouldBe("stu");
            @baseList[7].ShouldBe("vwx");
            @baseList[8].ShouldBe(" yz");


            // ReSharper disable once PossibleMultipleEnumeration
            var list = enumerable.ToList();

            list[0].ShouldBe("abc");
            list[1].ShouldBe("def");
            list[2].ShouldBe("ghi");
            list[3].ShouldBe("jkl");
            list[4].ShouldBe("mno");
            list[5].ShouldBe("pqr");
            list[6].ShouldBe("stu");
            list[7].ShouldBe("vwx");
            list[8].ShouldBe("yz");
        }

        [Fact]
        public void StringToFixedLengthEnumerableWithCustomTrimTest()
        {
            var @base = Splitter.FixedLength(3).Split(OriginalStrings.IncludeWhiteSpaceString);
            // ReSharper disable once PossibleMultipleEnumeration
            @base.Count().ShouldBe(9);

            var enumerable = Splitter.FixedLength(3).TrimResults(s => s.TrimStart()).Split(OriginalStrings.IncludeWhiteSpaceString);
            // ReSharper disable once PossibleMultipleEnumeration
            enumerable.Count().ShouldBe(9);

            // ReSharper disable once PossibleMultipleEnumeration
            var @baseList = @base.ToList();

            @baseList[0].ShouldBe("abc");
            @baseList[1].ShouldBe("def");
            @baseList[2].ShouldBe("ghi");
            @baseList[3].ShouldBe("jkl");
            @baseList[4].ShouldBe("mno");
            @baseList[5].ShouldBe("pqr");
            @baseList[6].ShouldBe("stu");
            @baseList[7].ShouldBe("vwx");
            @baseList[8].ShouldBe(" yz");


            // ReSharper disable once PossibleMultipleEnumeration
            var list = enumerable.ToList();

            list[0].ShouldBe("abc");
            list[1].ShouldBe("def");
            list[2].ShouldBe("ghi");
            list[3].ShouldBe("jkl");
            list[4].ShouldBe("mno");
            list[5].ShouldBe("pqr");
            list[6].ShouldBe("stu");
            list[7].ShouldBe("vwx");
            list[8].ShouldBe("yz");
        }

        [Fact]
        public void StringToFixedLengthListTest()
        {
            var list = Splitter.FixedLength(3).SplitToList(OriginalStrings.NormalString);

            list.Count().ShouldBe(9);

            list[0].ShouldBe("abc");
            list[1].ShouldBe("def");
            list[2].ShouldBe("ghi");
            list[3].ShouldBe("jkl");
            list[4].ShouldBe("mno");
            list[5].ShouldBe("pqr");
            list[6].ShouldBe("stu");
            list[7].ShouldBe("vwx");
            list[8].ShouldBe("yz");
        }


        [Fact]
        public void StringToFixedLengthListWithLimitTest()
        {
            var list = Splitter.FixedLength(3).Limit(3).SplitToList(OriginalStrings.NormalString);

            list.Count().ShouldBe(3);

            list[0].ShouldBe("abc");
            list[1].ShouldBe("def");
            list[2].ShouldBe("ghi");
        }

        [Fact]
        public void StringToFixedLengthListWithTrimTest()
        {
            var @base = Splitter.FixedLength(3).SplitToList(OriginalStrings.IncludeWhiteSpaceString);
            @base.Count().ShouldBe(9);

            var list = Splitter.FixedLength(3).TrimResults().SplitToList(OriginalStrings.IncludeWhiteSpaceString);
            list.Count().ShouldBe(9);

            @base[0].ShouldBe("abc");
            @base[1].ShouldBe("def");
            @base[2].ShouldBe("ghi");
            @base[3].ShouldBe("jkl");
            @base[4].ShouldBe("mno");
            @base[5].ShouldBe("pqr");
            @base[6].ShouldBe("stu");
            @base[7].ShouldBe("vwx");
            @base[8].ShouldBe(" yz");


            list[0].ShouldBe("abc");
            list[1].ShouldBe("def");
            list[2].ShouldBe("ghi");
            list[3].ShouldBe("jkl");
            list[4].ShouldBe("mno");
            list[5].ShouldBe("pqr");
            list[6].ShouldBe("stu");
            list[7].ShouldBe("vwx");
            list[8].ShouldBe("yz");
        }

        [Fact]
        public void StringToFixedLengthListWithCustomTrimTest()
        {
            var @base = Splitter.FixedLength(3).SplitToList(OriginalStrings.IncludeWhiteSpaceString);
            @base.Count().ShouldBe(9);

            var list = Splitter.FixedLength(3).TrimResults(s => s.TrimStart()).SplitToList(OriginalStrings.IncludeWhiteSpaceString);
            list.Count().ShouldBe(9);

            @base[0].ShouldBe("abc");
            @base[1].ShouldBe("def");
            @base[2].ShouldBe("ghi");
            @base[3].ShouldBe("jkl");
            @base[4].ShouldBe("mno");
            @base[5].ShouldBe("pqr");
            @base[6].ShouldBe("stu");
            @base[7].ShouldBe("vwx");
            @base[8].ShouldBe(" yz");


            list[0].ShouldBe("abc");
            list[1].ShouldBe("def");
            list[2].ShouldBe("ghi");
            list[3].ShouldBe("jkl");
            list[4].ShouldBe("mno");
            list[5].ShouldBe("pqr");
            list[6].ShouldBe("stu");
            list[7].ShouldBe("vwx");
            list[8].ShouldBe("yz");
        }
    }
}
