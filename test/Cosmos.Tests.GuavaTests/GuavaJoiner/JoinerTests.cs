using System.Collections.Generic;
using Cosmos.Guava;
using Shouldly;
using Xunit;

namespace Cosmos.Tests.GuavaTests.GuavaJoiner
{
    public class JoinerTests
    {
        private static class OriginalMaterials
        {
            public static List<string> NormalList { get; } = new List<string> { "a", "b", "c", "d", "e" };
            public static List<string> IncludeWhiteSpaceList { get; } = new List<string> { "a", "b", "c", "d", "e", "" };
            public static List<string> IncludeNullList { get; } = new List<string> { "a", "b", "c", "d", "e", null };
            public static List<string> IncludeEmptyList { get; } = new List<string> { "a", "b", "c", "d", "e", string.Empty };
            public static List<string> IncludeInlineWhiteSpaceList { get; } = new List<string> { "a", "b", "c", "", "d", "e" };
            public static List<string> IncludeInlineNullList { get; } = new List<string> { "a", "b", "c", null, "d", "e" };
            public static List<string> IncludeInlineEmptyList { get; } = new List<string> { "a", "b", "c", string.Empty, "d", "e" };
        }

        [Fact]
        public void ListToStringTest()
        {
            var str = Joiner.On(",").Join(OriginalMaterials.NormalList);
            str.ShouldBe("a,b,c,d,e");
        }

        [Fact]
        public void ListToStringWithWhiteSpaceTest()
        {
            var str = Joiner.On(",").Join(OriginalMaterials.IncludeWhiteSpaceList);
            str.ShouldBe("a,b,c,d,e,");
        }

        [Fact]
        public void ListToStringWithNullTest()
        {
            var str = Joiner.On(",").Join(OriginalMaterials.IncludeNullList);
            str.ShouldBe("a,b,c,d,e,");
        }

        [Fact]
        public void ListToStringWithEmptyTest()
        {
            var str = Joiner.On(",").Join(OriginalMaterials.IncludeEmptyList);
            str.ShouldBe("a,b,c,d,e,");
        }

        [Fact]
        public void ListToStringWithWhiteSpaceAndSkipNullsTest()
        {
            var str = Joiner.On(",").SkipNulls().Join(OriginalMaterials.IncludeInlineWhiteSpaceList);
            str.ShouldBe("a,b,c,d,e");
        }

        [Fact]
        public void ListToStringWithNullAndSkipNullsTest()
        {
            var str = Joiner.On(",").SkipNulls().Join(OriginalMaterials.IncludeInlineNullList);
            str.ShouldBe("a,b,c,d,e");
        }

        [Fact]
        public void ListToStringWithEmptyAndSkipNullsTest()
        {
            var str = Joiner.On(",").SkipNulls().Join(OriginalMaterials.IncludeInlineEmptyList);
            str.ShouldBe("a,b,c,d,e");
        }

        [Fact]
        public void ListToStringWithWhiteSpaceReplaceTest()
        {
            var str = Joiner.On(",").UseForNull("zzz").Join(OriginalMaterials.IncludeInlineWhiteSpaceList);
            str.ShouldBe("a,b,c,zzz,d,e");
        }

        [Fact]
        public void ListToStringWithNullReplaceTest()
        {
            var str = Joiner.On(",").UseForNull("zzz").Join(OriginalMaterials.IncludeInlineNullList);
            str.ShouldBe("a,b,c,zzz,d,e");
        }

        [Fact]
        public void ListToStringWithEmptyReplaceTest()
        {
            var str = Joiner.On(",").UseForNull("zzz").Join(OriginalMaterials.IncludeInlineEmptyList);
            str.ShouldBe("a,b,c,zzz,d,e");
        }
    }
}
