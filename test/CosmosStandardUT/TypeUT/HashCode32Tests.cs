using System;
using Cosmos.Reflection;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.TypeUT
{
    [Trait("TypeUT", "HashCode32Tests")]
    public class HashCode32Tests
    {
        [Fact]
        public void Parsing()
        {
            Assert.False(HashCode32.TryParse(null, out HashCode32 hash));
            Assert.False(HashCode32.TryParse("", out hash));
            Assert.False(HashCode32.TryParse("123456789ABCDE", out hash));
            Assert.False(HashCode32.TryParse("Well, this isn't likely to work, is it?", out hash));
            Assert.False(HashCode32.TryParse("123456789abcdef01", out hash));
            Assert.Equal(hash, HashCode32.Zero);
            Assert.Equal(default(HashCode32), hash);
            Assert.True(HashCode32.TryParse("12ab34cd", out hash));
            Assert.Equal(hash, HashCode32.Parse("  12AB 3 4 CD  "));
            Assert.Equal(HashCode32.Parse("00000000"), HashCode32.Zero);
            Assert.Equal(hash.GetHashCode(), HashCode32.Parse("12ab34cd").GetHashCode());
            Assert.NotEqual(hash.GetHashCode(), HashCode32.Zero.GetHashCode());
            Assert.Equal(0, HashCode32.Zero.GetHashCode());
            Assert.Equal<ushort>(0x12ab, hash.UHash1);
            Assert.Equal<ushort>(0x34cd, hash.UHash2);
            Assert.Equal(0x12ab, hash.Hash1);
            Assert.Equal(0x34cd, hash.Hash2);
            Assert.Equal(hash, new HashCode32((ushort) 0x12ab, 0x34cd));
            Assert.Equal(hash, new HashCode32(0x12ab, 0x34cd));
            Assert.Equal(hash, HashCode32.Parse("0x12ab34cd"));
            Assert.Equal(hash, HashCode32.Parse("0x12ab34cd"));
            Assert.False(HashCode32.TryParse("x12ab34cd", out hash));
            Assert.False(HashCode32.TryParse("0xx12ab34cd", out hash));
            Assert.False(HashCode32.TryParse("12xb34cd", out hash));
        }

        [Fact]
        public void ArgumentNull()
        {
            Assert.Throws<ArgumentNullException>("s", () => HashCode32.Parse(null));
        }

        [Fact]
        public void BadFormat()
        {
            Assert.Throws<FormatException>(() => HashCode32.Parse("0123456780123457833943"));
        }

        [Fact]
        public void BadFormatHigh()
        {
            Assert.Throws<FormatException>(
                () => HashCode32.Parse(
                    "76544561234565434567654456012sdfafasjkl;fdsafdk1234565434561234565434567654456"));
        }

        [Fact]
        public void BadFormatLow()
        {
            Assert.Throws<FormatException>(
                () => HashCode32.Parse("0123456789f12323432343234324324323433232sdrtyrtyttytrty"));
        }

        [Fact]
        public void BadFormatDouble0X()
        {
            Assert.Throws<FormatException>(
                () => HashCode32.Parse("0x0x123456543456765445612345654345676544561234565434567654456"));
        }

        [Fact]
        public void BadFormatTooShort()
        {
            Assert.Throws<FormatException>(() => HashCode32.Parse(""));
        }

        [Fact]
        public void BadFormatTooShortPadded()
        {
            Assert.Throws<FormatException>(
                () => HashCode32.Parse("1234                                                            "));
        }

        [Fact]
        public void BadFormatTooShortHigh()
        {
            Assert.Throws<FormatException>(() => HashCode32.Parse(new string(' ', 32)));
        }

        [Fact]
        public void BadFormatTooShortLow()
        {
            Assert.Throws<FormatException>(
                () => HashCode32.Parse("0123456789abcdef01234                                        "));
        }

        [Fact]
        public void ToStringTests()
        {
            Assert.Equal(
                "12AB34CD", HashCode32.Parse("12ab34cd").ToString());
        }

        [Fact]
        public void EqualsObj()
        {
            Assert.Equal(HashCode32.Zero, (object) HashCode32.Zero);
            object boxed = HashCode32.Parse("01ab34cd");
            Assert.True(boxed.Equals(HashCode32.Parse("01AB34CD")));
            Assert.False(boxed.Equals(HashCode32.Zero));
            Assert.False(boxed.Equals("not a hash code"));
            Assert.True(
                Equals(
                    HashCode32.Parse("1 2 ab 3  4cd"),
                    HashCode32.Parse("12A  B 34C D      ")));
        }

        [Fact]
#pragma warning disable 1718 //Yes, I'm testing the obvious!
        public void EqualsOps()
        {
            Assert.True(HashCode32.Zero == HashCode32.Zero);
            Assert.True(
                HashCode32.Parse("12ab34cd")
             == HashCode32.Parse("12AB34CD"));
            Assert.False(HashCode32.Zero != HashCode32.Zero);
            Assert.False(
                HashCode32.Parse("12ab34cd")
             != HashCode32.Parse("12AB34CD"));
            Assert.True(HashCode32.Parse("12ab34cd") != HashCode32.Zero);
            Assert.False(HashCode32.Parse("12ab34cd") == HashCode32.Zero);
        }

        [Fact]
        public void OutputTest()
        {
            var hash = HashCode32.Parse("12ab34cd");

            hash.AsHexString(false).ShouldBe("12ab34cd");
            hash.AsHexString(true).ShouldBe("12AB34CD");

            hash.AsBinString(false).ShouldBe("10010101010110011010011001101");
            hash.AsBinString(true).ShouldBe("00010010101010110011010011001101");
        }
    }
}