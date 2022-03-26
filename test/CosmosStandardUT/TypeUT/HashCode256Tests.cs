using Cosmos.Reflection;

namespace CosmosStandardUT.TypeUT
{
    [Trait("TypeUT", "HashCode256Tests")]
    public class HashCode256Tests
    {
        [Fact]
        public void Parsing()
        {
            Assert.False(HashCode256.TryParse(null, out HashCode256 hash));
            Assert.False(HashCode256.TryParse("", out hash));
            Assert.False(HashCode256.TryParse("123456789ABCDE", out hash));
            Assert.False(HashCode256.TryParse("Well, this isn't likely to work, is it?", out hash));
            Assert.False(HashCode256.TryParse("123456789abcdef01", out hash));
            Assert.Equal(hash, HashCode256.Zero);
            Assert.Equal(default(HashCode256), hash);
            Assert.True(HashCode256.TryParse("123456789abcdef00fedcba987654321123456789abcdef00fedcba987654321", out hash));
            Assert.Equal(hash, HashCode256.Parse("  123456789ABCD EF0  0fe DCB a98 765 4321   123456789AbcdeF0 0FED cbA 987 65 4321"));
            Assert.Equal(HashCode256.Parse("0000000000000000000000000000000000000000000000000000000000000000"), HashCode256.Zero);
            Assert.Equal(hash.GetHashCode(), HashCode256.Parse("123456789abcdef00fedcba987654321123456789abcdef00fedcba987654321").GetHashCode());
            Assert.NotEqual(hash.GetHashCode(), HashCode256.Zero.GetHashCode());
            Assert.Equal(0, HashCode256.Zero.GetHashCode());
            Assert.Equal<ulong>(0x123456789abcdef0, hash.UHash1);
            Assert.Equal<ulong>(0x0fedcba987654321, hash.UHash2);
            Assert.Equal<ulong>(0x123456789abcdef0, hash.UHash3);
            Assert.Equal<ulong>(0x0fedcba987654321, hash.UHash4);
            Assert.Equal(0x123456789abcdef0, hash.Hash1);
            Assert.Equal(0x0fedcba987654321, hash.Hash2);
            Assert.Equal(0x123456789abcdef0, hash.Hash3);
            Assert.Equal(0x0fedcba987654321, hash.Hash4);
            Assert.Equal(hash, new HashCode256(0x123456789abcdef0u, 0x0fedcba987654321, 0x123456789abcdef0u, 0x0fedcba987654321));
            Assert.Equal(hash, new HashCode256(0x123456789abcdef0, 0x0fedcba987654321, 0x123456789abcdef0, 0x0fedcba987654321));
            Assert.Equal(hash, HashCode256.Parse("0x123456789abcdef00fedcba987654321123456789abcdef00fedcba987654321"));
            Assert.Equal(hash, HashCode256.Parse("0x123456789abcdef00fedcba987654321123456789abcdef00fedcba987654321"));
            Assert.False(HashCode256.TryParse("x123456789abcdef00fedcba987654321123456789abcdef00fedcba987654321", out hash));
            Assert.False(HashCode256.TryParse("0xx123456789abcdef00fedcba987654321123456789abcdef00fedcba987654321", out hash));
            Assert.False(HashCode256.TryParse("1234x6789abcdef00fedcba987654321123456789abcdef00fedcba987654321", out hash));
        }

        [Fact]
        public void ArgumentNull()
        {
            Assert.Throws<ArgumentNullException>("s", () => HashCode256.Parse(null));
        }

        [Fact]
        public void BadFormat()
        {
            Assert.Throws<FormatException>(() => HashCode256.Parse("0123456780123457833943"));
        }

        [Fact]
        public void BadFormatHigh()
        {
            Assert.Throws<FormatException>(
                () => HashCode256.Parse(
                    "76544561234565434567654456012sdfafasjkl;fdsafdk1234565434561234565434567654456"));
        }

        [Fact]
        public void BadFormatLow()
        {
            Assert.Throws<FormatException>(
                () => HashCode256.Parse("0123456789f12323432343234324324323433232sdrtyrtyttytrty"));
        }

        [Fact]
        public void BadFormatDouble0X()
        {
            Assert.Throws<FormatException>(
                () => HashCode256.Parse("0x0x123456543456765445612345654345676544561234565434567654456"));
        }

        [Fact]
        public void BadFormatTooShort()
        {
            Assert.Throws<FormatException>(() => HashCode256.Parse(""));
        }

        [Fact]
        public void BadFormatTooShortPadded()
        {
            Assert.Throws<FormatException>(
                () => HashCode256.Parse("1234                                                            "));
        }

        [Fact]
        public void BadFormatTooShortHigh()
        {
            Assert.Throws<FormatException>(() => HashCode256.Parse(new string(' ', 64)));
        }

        [Fact]
        public void BadFormatTooShortLow()
        {
            Assert.Throws<FormatException>(
                () => HashCode256.Parse("0123456789abcdef01234                                        "));
        }

        [Fact]
        public void ToStringTests()
        {
            Assert.Equal(
                "0123456789ABCDEF0123456789ABCDEF0123456789ABCDEF0123456789ABCDEF", HashCode256.Parse("0123456789abcdef0123456789ABCDEF0123456789abcdef0123456789ABCDEF").ToString());
        }

        [Fact]
        public void EqualsObj()
        {
            Assert.Equal(HashCode256.Zero, (object) HashCode256.Zero);
            object boxed = HashCode256.Parse("0123456789abcdef0123456789ABCDEF0123456789abcdef0123456789ABCDEF");
            Assert.True(boxed.Equals(HashCode256.Parse("0123456789ABCDEF0123456789ABCDEF0123456789ABCDEF0123456789ABCDEF")));
            Assert.False(boxed.Equals(HashCode256.Zero));
            Assert.False(boxed.Equals("not a hash code"));
            Assert.True(
                Equals(
                    HashCode256.Parse("fed c b a9876543210 0123456789ABCDEF 0123456789ABCDEF0123456789ABCDEF"),
                    HashCode256.Parse("FE DCBA 98765 432 10 0123456789ABCD EF     0123456789ABCDEF0123456789ABCDEF    ")));
        }

        [Fact]
#pragma warning disable 1718 //Yes, I'm testing the obvious!
        public void EqualsOps()
        {
            Assert.True(HashCode256.Zero == HashCode256.Zero);
            Assert.True(
                HashCode256.Parse("0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef")
             == HashCode256.Parse("0123456789ABCDEF0123456789ABCDEF0123456789ABCDEF0123456789ABCDEF"));
            Assert.False(HashCode256.Zero != HashCode256.Zero);
            Assert.False(
                HashCode256.Parse("0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef")
             != HashCode256.Parse("0123456789ABCDEF0123456789ABCDEF0123456789ABCDEF0123456789ABCDEF"));
            Assert.True(HashCode256.Parse("0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef") != HashCode256.Zero);
            Assert.False(HashCode256.Parse("0123456789abcdef0123456789abcdef0123456789abcdef0123456789abcdef") == HashCode256.Zero);
        }

        [Fact]
        public void OutputTest()
        {
            var hash = HashCode256.Parse("123456789abcdef00fedcba987654321123456789abcdef00fedcba987654321");

            hash.GetHexString(false).ShouldBe("123456789abcdef00fedcba987654321123456789abcdef00fedcba987654321");
            hash.GetHexString(true).ShouldBe("123456789ABCDEF00FEDCBA987654321123456789ABCDEF00FEDCBA987654321");

            hash.GetBinString(false).ShouldBe("1001000110100010101100111100010011010101111001101111011110000000011111110110111001011101010011000011101100101010000110010000100010010001101000101011001111000100110101011110011011110111100000000111111101101110010111010100110000111011001010100001100100001");
            hash.GetBinString(true).ShouldBe("0001001000110100010101100111100010011010101111001101111011110000000011111110110111001011101010011000011101100101010000110010000100010010001101000101011001111000100110101011110011011110111100000000111111101101110010111010100110000111011001010100001100100001");
        }
    }
}