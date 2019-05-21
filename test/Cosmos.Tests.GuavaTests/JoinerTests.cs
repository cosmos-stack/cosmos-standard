using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Guava;
using Shouldly;
using Xunit;

namespace Cosmos.Tests.GuavaTests
{
    public class JoinerTests
    {
        [Fact]
        public void BaseTest()
        {
            var originalList = new List<string> { "a", "b", "c", "d", "e" };
            var originalList2 = new List<string> { "a", "b", "c", "d", "e", "" };
            var originalList3 = new List<string> { "a", "b", "c", "d", "e", null };
            var originalList4 = new List<string> { "a", "b", "c", "d", "e", string.Empty };

            var str1 = Joiner.On(",").Join(originalList);
            str1.ShouldBe("a,b,c,d,e");

            var str2 = Joiner.On(",").Join(originalList2);
            str2.ShouldBe("a,b,c,d,e,");

            var str3 = Joiner.On(",").Join(originalList3);
            str3.ShouldBe("a,b,c,d,e,");

            var str4 = Joiner.On(",").Join(originalList4);
            str4.ShouldBe("a,b,c,d,e,");
        }

        [Fact]
        public void NullOrEmptyTest()
        {
            var originalList = new List<string> { "a", "b", "c", "", "d", "e" };
            var originalList2 = new List<string> { "a", "b", "c", null, "d", "e" };
            var originalList3 = new List<string> { "a", "b", "c", string.Empty, "d", "e" };

            var str1 = Joiner.On(",").SkipNulls().Join(originalList);
            str1.ShouldBe("a,b,c,d,e");

            var str2 = Joiner.On(",").SkipNulls().Join(originalList2);
            str2.ShouldBe("a,b,c,d,e");

            var str3 = Joiner.On(",").SkipNulls().Join(originalList3);
            str3.ShouldBe("a,b,c,d,e");
        }

        [Fact]
        public void NullAndReplaceTest()
        {
            var originalList = new List<string> { "a", "b", "c", "", "d", "e" };
            var originalList2 = new List<string> { "a", "b", "c", null, "d", "e" };
            var originalList3 = new List<string> { "a", "b", "c", string.Empty, "d", "e" };

            var str1 = Joiner.On(",").UseForNull("zzz").Join(originalList);
            str1.ShouldBe("a,b,c,zzz,d,e");

            var str2 = Joiner.On(",").UseForNull("zzz").SkipNulls().Join(originalList2);
            str2.ShouldBe("a,b,c,zzz,d,e");

            var str3 = Joiner.On(",").UseForNull("zzz").SkipNulls().Join(originalList3);
            str3.ShouldBe("a,b,c,zzz,d,e");
        }

        [Fact]
        public void KvpTest()
        {
            var originalList = new List<string> { "a", "1", "b", "2", "c", "3", "d", "4", "e", "5" };
            var originalList2 = new List<string> { "a", "1", "b", "2", "c", "3", "d", "4", "e" };

            var str1 = Joiner.On("&").WithKeyValueSeparator("=").Join(originalList);
            var str2 = Joiner.On("&").WithKeyValueSeparator("=").Join(originalList2);
            var str3 = Joiner.On("&").WithKeyValueSeparator("=").Join(originalList2, "d", "0");



            str1.ShouldBe("a=1&b=2&c=3&d=4&e=5");
            str2.ShouldBe("a=1&b=2&c=3&d=4&e=");
            str3.ShouldBe("a=1&b=2&c=3&d=4&e=0");
        }

        [Fact]
        public void KvpWithConverterTest()
        {
            var originalList3 = new List<int> { 1, 1, 2, 2, 3, 3, 4, 4, 5, 5 };
            var originalList4 = new List<int> { 1, 1, 2, 2, 3, 3, 4, 4, 5 };
            var converter = new Int32ToStringConverter();


            var str4 = Joiner.On("&").WithKeyValueSeparator("=").Join(originalList3, converter);
            var str5 = Joiner.On("&").WithKeyValueSeparator("=").Join(originalList4, converter);
            var str6 = Joiner.On("&").WithKeyValueSeparator("=").Join(originalList4, 9, 9, converter);



            str4.ShouldBe("1=1&2=2&3=3&4=4&5=5");
            str5.ShouldBe("1=1&2=2&3=3&4=4&5=0");
            str6.ShouldBe("1=1&2=2&3=3&4=4&5=9");

        }

        [Fact]
        public void KvpNullTest()
        {
            var originalList = new List<string> { "a", "1", "b", "2", "c", "3", "d", "4", "e", "5", "", "" };
            var originalList2 = new List<string> { "a", "1", "b", "2", "c", "3", "d", "4", "e", "5", null, null };
            var originalList3 = new List<string> { "a", "1", "b", "2", "c", "3", "d", "4", "e", "5", string.Empty, string.Empty };

            var str1 = Joiner.On("&").WithKeyValueSeparator("=").Join(originalList);
            var str2 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls().Join(originalList);
            var str3 = Joiner.On("&").WithKeyValueSeparator("=").Join(originalList2);
            var str4 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls().Join(originalList2);
            var str5 = Joiner.On("&").WithKeyValueSeparator("=").Join(originalList3);
            var str6 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls().Join(originalList3);

            str1.ShouldBe("a=1&b=2&c=3&d=4&e=5&=");
            str2.ShouldBe("a=1&b=2&c=3&d=4&e=5");
            str3.ShouldBe("a=1&b=2&c=3&d=4&e=5&=");
            str4.ShouldBe("a=1&b=2&c=3&d=4&e=5");
            str5.ShouldBe("a=1&b=2&c=3&d=4&e=5&=");
            str6.ShouldBe("a=1&b=2&c=3&d=4&e=5");
        }

        [Fact]
        public void KvpValueNullTest()
        {
            var originalList = new List<string> { "a", "1", "b", "2", "c", "3", "d", "4", "e", "5", "", "" };
            var originalList2 = new List<string> { "a", "1", "b", "2", "c", "3", "d", "4", "e", "5", null, null };
            var originalList3 = new List<string> { "a", "1", "b", "2", "c", "3", "d", "4", "e", "5", string.Empty, string.Empty };
            var originalList4 = new List<string> { "a", "1", "b", "2", "c", "3", "d", "4", "e", "5", "f", "" };
            var originalList5 = new List<string> { "a", "1", "b", "2", "c", "3", "d", "4", "e", "5", "f", null };
            var originalList6 = new List<string> { "a", "1", "b", "2", "c", "3", "d", "4", "e", "5", "f", string.Empty };


            var str1 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls().Join(originalList);
            var str2 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls().Join(originalList2);
            var str3 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls().Join(originalList3);
            var str4 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls().Join(originalList4);
            var str5 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls().Join(originalList5);
            var str6 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls().Join(originalList6);

            var str11 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls().Join(originalList);
            var str21 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls().Join(originalList2);
            var str31 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls().Join(originalList3);
            var str41 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls().Join(originalList4);
            var str51 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls().Join(originalList5);
            var str61 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls().Join(originalList6);

            var str12 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenKeyIsNull).Join(originalList);
            var str22 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenKeyIsNull).Join(originalList2);
            var str32 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenKeyIsNull).Join(originalList3);
            var str42 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenKeyIsNull).Join(originalList4);
            var str52 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenKeyIsNull).Join(originalList5);
            var str62 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenKeyIsNull).Join(originalList6);

            var str13 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenValueIsNull).Join(originalList);
            var str23 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenValueIsNull).Join(originalList2);
            var str33 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenValueIsNull).Join(originalList3);
            var str43 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenValueIsNull).Join(originalList4);
            var str53 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenValueIsNull).Join(originalList5);
            var str63 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenValueIsNull).Join(originalList6);

            var str14 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenBoth).Join(originalList);
            var str24 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenBoth).Join(originalList2);
            var str34 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenBoth).Join(originalList3);
            var str44 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenBoth).Join(originalList4);
            var str54 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenBoth).Join(originalList5);
            var str64 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenBoth).Join(originalList6);

            var str15 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.Nothing).Join(originalList);
            var str25 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.Nothing).Join(originalList2);
            var str35 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.Nothing).Join(originalList3);
            var str45 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.Nothing).Join(originalList4);
            var str55 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.Nothing).Join(originalList5);
            var str65 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.Nothing).Join(originalList6);

            var str16 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenEither).Join(originalList);
            var str26 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenEither).Join(originalList2);
            var str36 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenEither).Join(originalList3);
            var str46 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenEither).Join(originalList4);
            var str56 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenEither).Join(originalList5);
            var str66 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls(SkipNullType.WhenEither).Join(originalList6);

            var str19 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls().Join(originalList);
            var str29 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls().Join(originalList2);
            var str39 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls().Join(originalList3);
            var str49 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls().Join(originalList4);
            var str59 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls().Join(originalList5);
            var str69 = Joiner.On("&").WithKeyValueSeparator("=").SkipNulls().Join(originalList6);

            str1.ShouldBe("a=1&b=2&c=3&d=4&e=5");
            str2.ShouldBe("a=1&b=2&c=3&d=4&e=5");
            str3.ShouldBe("a=1&b=2&c=3&d=4&e=5");
            str4.ShouldBe("a=1&b=2&c=3&d=4&e=5");
            str5.ShouldBe("a=1&b=2&c=3&d=4&e=5");
            str6.ShouldBe("a=1&b=2&c=3&d=4&e=5");

            str11.ShouldBe("a=1&b=2&c=3&d=4&e=5");
            str21.ShouldBe("a=1&b=2&c=3&d=4&e=5");
            str31.ShouldBe("a=1&b=2&c=3&d=4&e=5");
            str41.ShouldBe("a=1&b=2&c=3&d=4&e=5");
            str51.ShouldBe("a=1&b=2&c=3&d=4&e=5");
            str61.ShouldBe("a=1&b=2&c=3&d=4&e=5");


            str12.ShouldBe("a=1&b=2&c=3&d=4&e=5");
            str22.ShouldBe("a=1&b=2&c=3&d=4&e=5");
            str32.ShouldBe("a=1&b=2&c=3&d=4&e=5");
            str42.ShouldBe("a=1&b=2&c=3&d=4&e=5&f=");
            str52.ShouldBe("a=1&b=2&c=3&d=4&e=5&f=");
            str62.ShouldBe("a=1&b=2&c=3&d=4&e=5&f=");


            str13.ShouldBe("a=1&b=2&c=3&d=4&e=5");
            str23.ShouldBe("a=1&b=2&c=3&d=4&e=5");
            str33.ShouldBe("a=1&b=2&c=3&d=4&e=5");
            str43.ShouldBe("a=1&b=2&c=3&d=4&e=5");
            str53.ShouldBe("a=1&b=2&c=3&d=4&e=5");
            str63.ShouldBe("a=1&b=2&c=3&d=4&e=5");


            str14.ShouldBe("a=1&b=2&c=3&d=4&e=5");
            str24.ShouldBe("a=1&b=2&c=3&d=4&e=5");
            str34.ShouldBe("a=1&b=2&c=3&d=4&e=5");
            str44.ShouldBe("a=1&b=2&c=3&d=4&e=5");
            str54.ShouldBe("a=1&b=2&c=3&d=4&e=5");
            str64.ShouldBe("a=1&b=2&c=3&d=4&e=5");


            str15.ShouldBe("a=1&b=2&c=3&d=4&e=5&=");
            str25.ShouldBe("a=1&b=2&c=3&d=4&e=5&=");
            str35.ShouldBe("a=1&b=2&c=3&d=4&e=5&=");
            str45.ShouldBe("a=1&b=2&c=3&d=4&e=5&f=");
            str55.ShouldBe("a=1&b=2&c=3&d=4&e=5&f=");
            str65.ShouldBe("a=1&b=2&c=3&d=4&e=5&f=");


            str16.ShouldBe("a=1&b=2&c=3&d=4&e=5");
            str26.ShouldBe("a=1&b=2&c=3&d=4&e=5");
            str36.ShouldBe("a=1&b=2&c=3&d=4&e=5");
            str46.ShouldBe("a=1&b=2&c=3&d=4&e=5");
            str56.ShouldBe("a=1&b=2&c=3&d=4&e=5");
            str66.ShouldBe("a=1&b=2&c=3&d=4&e=5");

            str19.ShouldBe("a=1&b=2&c=3&d=4&e=5");
            str29.ShouldBe("a=1&b=2&c=3&d=4&e=5");
            str39.ShouldBe("a=1&b=2&c=3&d=4&e=5");
            str49.ShouldBe("a=1&b=2&c=3&d=4&e=5");
            str59.ShouldBe("a=1&b=2&c=3&d=4&e=5");
            str69.ShouldBe("a=1&b=2&c=3&d=4&e=5");
        }

        [Fact]
        public void KvpNullAndReplaceTest()
        {
            var originalList = new List<string> { "a", "1", "b", "2", "c", "3", "d", "4", "e", "5", "", "" };
            var originalList2 = new List<string> { "a", "1", "b", "2", "c", "3", "d", "4", "e", "5", null, null };
            var originalList3 = new List<string> { "a", "1", "b", "2", "c", "3", "d", "4", "e", "5", string.Empty, string.Empty };
            var originalList4 = new List<string> { "a", "1", "b", "2", "c", "3", "d", "4", "e", "5", "f", "" };
            var originalList5 = new List<string> { "a", "1", "b", "2", "c", "3", "d", "4", "e", "5", "f", null };
            var originalList6 = new List<string> { "a", "1", "b", "2", "c", "3", "d", "4", "e", "5", "f", string.Empty };

            var str1 = Joiner.On("&").WithKeyValueSeparator("=").UseForNull("NullKey", "NullValue").Join(originalList);
            var str2 = Joiner.On("&").WithKeyValueSeparator("=").UseForNull(s => "NullKeyFunc", s => "NullValueFunc").Join(originalList);
            var str3 = Joiner.On("&").WithKeyValueSeparator("=").UseForNull("NullKey", "NullValue").Join(originalList2);
            var str4 = Joiner.On("&").WithKeyValueSeparator("=").UseForNull(s => "NullKeyFunc", s => "NullValueFunc").Join(originalList2);
            var str5 = Joiner.On("&").WithKeyValueSeparator("=").UseForNull("NullKey", "NullValue").Join(originalList3);
            var str6 = Joiner.On("&").WithKeyValueSeparator("=").UseForNull(s => "NullKeyFunc", s => "NullValueFunc").Join(originalList3);


            var str11 = Joiner.On("&").WithKeyValueSeparator("=").UseForNull("NullKey", "NullValue").Join(originalList4);
            var str21 = Joiner.On("&").WithKeyValueSeparator("=").UseForNull(s => "NullKeyFunc", s => "NullValueFunc").Join(originalList4);
            var str31 = Joiner.On("&").WithKeyValueSeparator("=").UseForNull("NullKey", "NullValue").Join(originalList5);
            var str41 = Joiner.On("&").WithKeyValueSeparator("=").UseForNull(s => "NullKeyFunc", s => "NullValueFunc").Join(originalList5);
            var str51 = Joiner.On("&").WithKeyValueSeparator("=").UseForNull("NullKey", "NullValue").Join(originalList6);
            var str61 = Joiner.On("&").WithKeyValueSeparator("=").UseForNull(s => "NullKeyFunc", s => "NullValueFunc").Join(originalList6);

            str1.ShouldBe("a=1&b=2&c=3&d=4&e=5&NullKey=NullValue");
            str2.ShouldBe("a=1&b=2&c=3&d=4&e=5&NullKeyFunc=NullValueFunc");
            str3.ShouldBe("a=1&b=2&c=3&d=4&e=5&NullKey=NullValue");
            str4.ShouldBe("a=1&b=2&c=3&d=4&e=5&NullKeyFunc=NullValueFunc");
            str5.ShouldBe("a=1&b=2&c=3&d=4&e=5&NullKey=NullValue");
            str6.ShouldBe("a=1&b=2&c=3&d=4&e=5&NullKeyFunc=NullValueFunc");

            str11.ShouldBe("a=1&b=2&c=3&d=4&e=5&f=NullValue");
            str21.ShouldBe("a=1&b=2&c=3&d=4&e=5&f=NullValueFunc");
            str31.ShouldBe("a=1&b=2&c=3&d=4&e=5&f=NullValue");
            str41.ShouldBe("a=1&b=2&c=3&d=4&e=5&f=NullValueFunc");
            str51.ShouldBe("a=1&b=2&c=3&d=4&e=5&f=NullValue");
            str61.ShouldBe("a=1&b=2&c=3&d=4&e=5&f=NullValueFunc");
        }

        [Fact]
        public void KvpTupleTest()
        {
            var originalList = new List<(string, string)> { ("a", "1"), ("b", "2"), ("c", "3"), ("d", "4"), ("e", "5") };
            var originalList2 = new List<(string, string)> { ("a", "1"), ("b", "2"), ("c", "3"), ("d", "4"), ("e", "") };
            var originalList3 = new List<(string, string)> { ("a", "1"), ("b", "2"), ("c", "3"), ("d", "4"), ("e", string.Empty) };
            var originalList4 = new List<(string, string)> { ("a", "1"), ("b", "2"), ("c", "3"), ("d", "4"), ("e", null) };
            var originalList5 = new List<(string, string)> { ("a", "1"), ("b", "2"), ("c", "3"), ("d", "4"), ("", "") };
            var originalList6 = new List<(string, string)> { ("a", "1"), ("b", "2"), ("c", "3"), ("d", "4"), (string.Empty, string.Empty) };
            var originalList7 = new List<(string, string)> { ("a", "1"), ("b", "2"), ("c", "3"), ("d", "4"), (null, null) };

            var str1 = Joiner.On("&").WithKeyValueSeparator("=").FromTuple().Join(originalList);
            var str2 = Joiner.On("&").WithKeyValueSeparator("=").FromTuple().UseForNull<string, string>((t1, t2) => "NullKey", (t1, t2) => "NullValue").Join(originalList2);
            var str3 = Joiner.On("&").WithKeyValueSeparator("=").FromTuple().UseForNull<string, string>((t1, t2) => "NullKey", (t1, t2) => "NullValue").Join(originalList3);
            var str4 = Joiner.On("&").WithKeyValueSeparator("=").FromTuple().UseForNull<string, string>((t1, t2) => "NullKey", (t1, t2) => "NullValue").Join(originalList4);
            var str5 = Joiner.On("&").WithKeyValueSeparator("=").FromTuple().UseForNull<string, string>((t1, t2) => "NullKey", (t1, t2) => "NullValue").Join(originalList5);
            var str6 = Joiner.On("&").WithKeyValueSeparator("=").FromTuple().UseForNull<string, string>((t1, t2) => "NullKey", (t1, t2) => "NullValue").Join(originalList6);
            var str7 = Joiner.On("&").WithKeyValueSeparator("=").FromTuple().UseForNull<string, string>((t1, t2) => "NullKey", (t1, t2) => "NullValue").Join(originalList7);

            str1.ShouldBe("a=1&b=2&c=3&d=4&e=5");
            str2.ShouldBe("a=1&b=2&c=3&d=4&e=NullValue");
            str3.ShouldBe("a=1&b=2&c=3&d=4&e=NullValue");
            str4.ShouldBe("a=1&b=2&c=3&d=4&e=NullValue");
            str5.ShouldBe("a=1&b=2&c=3&d=4&NullKey=NullValue");
            str6.ShouldBe("a=1&b=2&c=3&d=4&NullKey=NullValue");
            str7.ShouldBe("a=1&b=2&c=3&d=4&NullKey=NullValue");
        }
    }

    public class Int32ToStringConverter : ITypeConverter<int, string>
    {
        public string To(int @from)
        {
            return $"{@from}";
        }
    }
}
