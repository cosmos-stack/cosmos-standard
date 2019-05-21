using System.Collections.Generic;
using Cosmos.Guava;
using Shouldly;
using Xunit;

namespace Cosmos.Tests.GuavaTests.GuavaJoiner
{
    public class MapJoinerTests
    {
        public class Int32ToStringConverter : ITypeConverter<int, string>
        {
            public string To(int @from)
            {
                return $"{@from}";
            }
        }

        private static class OriginalMaterials
        {
            public static List<string> NormalList { get; } = new List<string> { "a", "1", "b", "2", "c", "3", "d", "4", "e", "5" };
            public static List<string> NormalListJi { get; } = new List<string> { "a", "1", "b", "2", "c", "3", "d", "4", "e" };
            public static List<int> IntTypeList { get; } = new List<int> { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5 };
            public static List<int> IntTypeListJi { get; } = new List<int> { 1, 1, 2, 2, 3, 3, 4, 4, 5 };
            public static List<string> IncludeWhiteSpaceKvList { get; } = new List<string> { "a", "1", "b", "2", "c", "3", "d", "4", "e", "5", "", "" };
            public static List<string> IncludeNullKvList { get; } = new List<string> { "a", "1", "b", "2", "c", "3", "d", "4", "e", "5", null, null };
            public static List<string> IncludeEmptyKvList { get; } = new List<string> { "a", "1", "b", "2", "c", "3", "d", "4", "e", "5", string.Empty, string.Empty };
            public static List<string> IncludeWhiteSpaceValueList { get; } = new List<string> { "a", "1", "b", "2", "c", "3", "d", "4", "e", "5", "f", "" };
            public static List<string> IncludeNullValueList { get; } = new List<string> { "a", "1", "b", "2", "c", "3", "d", "4", "e", "5", "f", null };
            public static List<string> IncludeEmptyValueList { get; } = new List<string> { "a", "1", "b", "2", "c", "3", "d", "4", "e", "5", "f", string.Empty };
        }

        [Fact]
        public void MapToStringOuTest()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").Join(OriginalMaterials.NormalList);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=5");
        }

        [Fact]
        public void MapToStringJiTest()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").Join(OriginalMaterials.NormalListJi);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=");
        }

        [Fact]
        public void MapToStringWithDefaultKvTest()
        {
            var strOu = Joiner.On("&").WithKeyValueSeparator("=").Join(OriginalMaterials.NormalList, "d", "0");
            var strJi = Joiner.On("&").WithKeyValueSeparator("=").Join(OriginalMaterials.NormalListJi, "d", "0");

            strOu.ShouldBe("a=1&b=2&c=3&d=4&e=5");
            strJi.ShouldBe("a=1&b=2&c=3&d=4&e=0");
        }

        [Fact]
        public void MapToStringWithConverterOuTest()
        {
            var converter = new Int32ToStringConverter();
            var str = Joiner.On("&").WithKeyValueSeparator("=").Join(OriginalMaterials.IntTypeList, converter);
            str.ShouldBe("1=1&2=2&3=3&4=4&5=5");
        }

        [Fact]
        public void MapToStringWithConverterJiTest()
        {
            var converter = new Int32ToStringConverter();
            var str = Joiner.On("&").WithKeyValueSeparator("=").Join(OriginalMaterials.IntTypeListJi, converter);
            str.ShouldBe("1=1&2=2&3=3&4=4&5=0");
        }

        [Fact]
        public void MapToStringWithConverterAndDefaultKvJiTest()
        {
            var converter = new Int32ToStringConverter();
            var str = Joiner.On("&").WithKeyValueSeparator("=").Join(OriginalMaterials.IntTypeListJi, 9, 9, converter);
            str.ShouldBe("1=1&2=2&3=3&4=4&5=9");
        }

        [Fact]
        public void MapToStringWithConverterAndDefaultKvOuTest()
        {
            var converter = new Int32ToStringConverter();
            var str = Joiner.On("&").WithKeyValueSeparator("=").Join(OriginalMaterials.IntTypeList, 9, 9, converter);
            str.ShouldBe("1=1&2=2&3=3&4=4&5=5");
        }

        [Fact]
        public void MapToStringWithWhiteSpaceKvTest()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").Join(OriginalMaterials.IncludeWhiteSpaceKvList);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=5&=");
        }

        [Fact]
        public void MapToStringWithWhiteSpaceKvAndSkipNullsTest()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls().Join(OriginalMaterials.IncludeWhiteSpaceKvList);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=5");
        }

        [Fact]
        public void MapToStringWithNullKvTest()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").Join(OriginalMaterials.IncludeNullKvList);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=5&=");
        }

        [Fact]
        public void MapToStringWithNullKvAndSkipNullsTest()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls().Join(OriginalMaterials.IncludeNullKvList);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=5");
        }

        [Fact]
        public void MapToStringWithEmptyKvTest()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").Join(OriginalMaterials.IncludeEmptyKvList);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=5&=");
        }

        [Fact]
        public void MapToStringWithEmptyKvAndSkipNullsTest()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls().Join(OriginalMaterials.IncludeEmptyKvList);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=5");
        }

        [Fact]
        public void MapToStringWithWhiteSpaceValueAndSkipNullsTest()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls().Join(OriginalMaterials.IncludeWhiteSpaceValueList);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=5");

        }

        [Fact]
        public void MapToStringWithNullValueAndSkipNullsTest()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls().Join(OriginalMaterials.IncludeNullValueList);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=5");

        }

        [Fact]
        public void MapToStringWithEmptyValueAndSkipNullsTest()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls().Join(OriginalMaterials.IncludeEmptyValueList);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=5");
        }

        [Fact]
        public void MapToStringWithWhiteSpaceKvAndSkipNulls_WhenKeyIsNull_Test()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenKeyIsNull).Join(OriginalMaterials.IncludeWhiteSpaceKvList);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=5");
        }

        [Fact]
        public void MapToStringWithNullKvAndSkipNulls_WhenKeyIsNull_Test()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenKeyIsNull).Join(OriginalMaterials.IncludeNullKvList);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=5");
        }

        [Fact]
        public void MapToStringWithEmptyKvAndSkipNulls_WhenKeyIsNull_Test()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenKeyIsNull).Join(OriginalMaterials.IncludeEmptyKvList);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=5");
        }

        [Fact]
        public void MapToStringWithWhiteSpaceValueAndSkipNulls_WhenKeyIsNull_Test()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenKeyIsNull).Join(OriginalMaterials.IncludeWhiteSpaceValueList);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=5&f=");

        }

        [Fact]
        public void MapToStringWithNullValueAndSkipNulls_WhenKeyIsNull_Test()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenKeyIsNull).Join(OriginalMaterials.IncludeNullValueList);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=5&f=");

        }

        [Fact]
        public void MapToStringWithEmptyValueAndSkipNulls_WhenKeyIsNull_Test()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenKeyIsNull).Join(OriginalMaterials.IncludeEmptyValueList);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=5&f=");
        }

        [Fact]
        public void MapToStringWithWhiteSpaceKvAndSkipNulls_WhenValueIsNull_Test()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenValueIsNull).Join(OriginalMaterials.IncludeWhiteSpaceKvList);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=5");
        }

        [Fact]
        public void MapToStringWithNullKvAndSkipNulls_WhenValueIsNull_Test()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenValueIsNull).Join(OriginalMaterials.IncludeNullKvList);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=5");
        }

        [Fact]
        public void MapToStringWithEmptyKvAndSkipNulls_WhenValueIsNull_Test()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenValueIsNull).Join(OriginalMaterials.IncludeEmptyKvList);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=5");
        }

        [Fact]
        public void MapToStringWithWhiteSpaceValueAndSkipNulls_WhenValueIsNull_Test()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenValueIsNull).Join(OriginalMaterials.IncludeWhiteSpaceValueList);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=5");

        }

        [Fact]
        public void MapToStringWithNullValueAndSkipNulls_WhenValueIsNull_Test()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenValueIsNull).Join(OriginalMaterials.IncludeNullValueList);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=5");

        }

        [Fact]
        public void MapToStringWithEmptyValueAndSkipNulls_WhenValueIsNull_Test()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenValueIsNull).Join(OriginalMaterials.IncludeEmptyValueList);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=5");
        }

        [Fact]
        public void MapToStringWithWhiteSpaceKvAndSkipNulls_WhenBoth_Test()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenBoth).Join(OriginalMaterials.IncludeWhiteSpaceKvList);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=5");
        }

        [Fact]
        public void MapToStringWithNullKvAndSkipNulls_WhenBoth_Test()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenBoth).Join(OriginalMaterials.IncludeNullKvList);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=5");
        }

        [Fact]
        public void MapToStringWithEmptyKvAndSkipNulls_WhenBoth_Test()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenBoth).Join(OriginalMaterials.IncludeEmptyKvList);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=5");
        }

        [Fact]
        public void MapToStringWithWhiteSpaceValueAndSkipNulls_WhenBoth_Test()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenBoth).Join(OriginalMaterials.IncludeWhiteSpaceValueList);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=5");

        }

        [Fact]
        public void MapToStringWithNullValueAndSkipNulls_WhenBoth_Test()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenBoth).Join(OriginalMaterials.IncludeNullValueList);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=5");

        }

        [Fact]
        public void MapToStringWithEmptyValueAndSkipNulls_WhenBoth_Test()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenBoth).Join(OriginalMaterials.IncludeEmptyValueList);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=5");
        }

        [Fact]
        public void MapToStringWithWhiteSpaceKvAndSkipNulls_Nothing_Test()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.Nothing).Join(OriginalMaterials.IncludeWhiteSpaceKvList);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=5&=");
        }

        [Fact]
        public void MapToStringWithNullKvAndSkipNulls_Nothing_Test()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.Nothing).Join(OriginalMaterials.IncludeNullKvList);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=5&=");
        }

        [Fact]
        public void MapToStringWithEmptyKvAndSkipNulls_Nothing_Test()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.Nothing).Join(OriginalMaterials.IncludeEmptyKvList);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=5&=");
        }

        [Fact]
        public void MapToStringWithWhiteSpaceValueAndSkipNulls_Nothing_Test()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.Nothing).Join(OriginalMaterials.IncludeWhiteSpaceValueList);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=5&f=");

        }

        [Fact]
        public void MapToStringWithNullValueAndSkipNulls_Nothing_Test()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.Nothing).Join(OriginalMaterials.IncludeNullValueList);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=5&f=");

        }

        [Fact]
        public void MapToStringWithEmptyValueAndSkipNulls_Nothing_Test()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.Nothing).Join(OriginalMaterials.IncludeEmptyValueList);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=5&f=");
        }

        [Fact]
        public void MapToStringWithWhiteSpaceKvAndSkipNulls_WhenEither_Test()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenEither).Join(OriginalMaterials.IncludeWhiteSpaceKvList);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=5");
        }

        [Fact]
        public void MapToStringWithNullKvAndSkipNulls_WhenEither_Test()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenEither).Join(OriginalMaterials.IncludeNullKvList);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=5");
        }

        [Fact]
        public void MapToStringWithEmptyKvAndSkipNulls_WhenEither_Test()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenEither).Join(OriginalMaterials.IncludeEmptyKvList);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=5");
        }

        [Fact]
        public void MapToStringWithWhiteSpaceValueAndSkipNulls_WhenEither_Test()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenEither).Join(OriginalMaterials.IncludeWhiteSpaceValueList);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=5");

        }

        [Fact]
        public void MapToStringWithNullValueAndSkipNulls_WhenEither_Test()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenEither).Join(OriginalMaterials.IncludeNullValueList);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=5");

        }

        [Fact]
        public void MapToStringWithEmptyValueAndSkipNulls_WhenEither_Test()
        {
            var str = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenEither).Join(OriginalMaterials.IncludeEmptyValueList);
            str.ShouldBe("a=1&b=2&c=3&d=4&e=5");
        }

        [Fact]
        public void MapToStringWithWhiteSpaceKvAndReplaceTest()
        {
            var str1 = Joiner.On("&").WithKeyValueSeparator("=").UseForNull("NullKey", "NullValue").Join(OriginalMaterials.IncludeWhiteSpaceKvList);
            var str2 = Joiner.On("&").WithKeyValueSeparator("=").UseForNull(s => "NullKeyFunc", s => "NullValueFunc").Join(OriginalMaterials.IncludeWhiteSpaceKvList);

            str1.ShouldBe("a=1&b=2&c=3&d=4&e=5&NullKey=NullValue");
            str2.ShouldBe("a=1&b=2&c=3&d=4&e=5&NullKeyFunc=NullValueFunc");
        }

        [Fact]
        public void MapToStringWithNullKvAndReplaceTest()
        {
            var str3 = Joiner.On("&").WithKeyValueSeparator("=").UseForNull("NullKey", "NullValue").Join(OriginalMaterials.IncludeNullKvList);
            var str4 = Joiner.On("&").WithKeyValueSeparator("=").UseForNull(s => "NullKeyFunc", s => "NullValueFunc").Join(OriginalMaterials.IncludeNullKvList);

            str3.ShouldBe("a=1&b=2&c=3&d=4&e=5&NullKey=NullValue");
            str4.ShouldBe("a=1&b=2&c=3&d=4&e=5&NullKeyFunc=NullValueFunc");
        }

        [Fact]
        public void MapToStringWithEmptyKvAndReplaceTest()
        {
            var str5 = Joiner.On("&").WithKeyValueSeparator("=").UseForNull("NullKey", "NullValue").Join(OriginalMaterials.IncludeEmptyKvList);
            var str6 = Joiner.On("&").WithKeyValueSeparator("=").UseForNull(s => "NullKeyFunc", s => "NullValueFunc").Join(OriginalMaterials.IncludeEmptyKvList);

            str5.ShouldBe("a=1&b=2&c=3&d=4&e=5&NullKey=NullValue");
            str6.ShouldBe("a=1&b=2&c=3&d=4&e=5&NullKeyFunc=NullValueFunc");
        }

        [Fact]
        public void MapToStringWithWhiteSpaceValueAndReplaceTest()
        {
            var str11 = Joiner.On("&").WithKeyValueSeparator("=").UseForNull("NullKey", "NullValue").Join(OriginalMaterials.IncludeWhiteSpaceValueList);
            var str21 = Joiner.On("&").WithKeyValueSeparator("=").UseForNull(s => "NullKeyFunc", s => "NullValueFunc").Join(OriginalMaterials.IncludeWhiteSpaceValueList);

            str11.ShouldBe("a=1&b=2&c=3&d=4&e=5&f=NullValue");
            str21.ShouldBe("a=1&b=2&c=3&d=4&e=5&f=NullValueFunc");
        }

        [Fact]
        public void MapToStringWithNullValueAndReplaceTest()
        {
            var str31 = Joiner.On("&").WithKeyValueSeparator("=").UseForNull("NullKey", "NullValue").Join(OriginalMaterials.IncludeNullValueList);
            var str41 = Joiner.On("&").WithKeyValueSeparator("=").UseForNull(s => "NullKeyFunc", s => "NullValueFunc").Join(OriginalMaterials.IncludeNullValueList);

            str31.ShouldBe("a=1&b=2&c=3&d=4&e=5&f=NullValue");
            str41.ShouldBe("a=1&b=2&c=3&d=4&e=5&f=NullValueFunc");
        }

        [Fact]
        public void MapToStringWithEmptyValueAndReplaceTest()
        {
            var str51 = Joiner.On("&").WithKeyValueSeparator("=").UseForNull("NullKey", "NullValue").Join(OriginalMaterials.IncludeEmptyValueList);
            var str61 = Joiner.On("&").WithKeyValueSeparator("=").UseForNull(s => "NullKeyFunc", s => "NullValueFunc").Join(OriginalMaterials.IncludeEmptyValueList);

            str51.ShouldBe("a=1&b=2&c=3&d=4&e=5&f=NullValue");
            str61.ShouldBe("a=1&b=2&c=3&d=4&e=5&f=NullValueFunc");
        }
    }
}
