using System;
using Cosmos.Reflection;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.TypeUT;

[Trait("TypeUT", "HashCode64Tests")]
public class HashCode64Tests
{
    [Fact]
    public void Parsing()
    {
        Assert.False(HashCode64.TryParse(null, out HashCode64 hash));
        Assert.False(HashCode64.TryParse("", out hash));
        Assert.False(HashCode64.TryParse("123456789ABCDE", out hash));
        Assert.False(HashCode64.TryParse("Well, this isn't likely to work, is it?", out hash));
        Assert.False(HashCode64.TryParse("123456789abcdef01", out hash));
        Assert.Equal(hash, HashCode64.Zero);
        Assert.Equal(default(HashCode64), hash);
        Assert.True(HashCode64.TryParse("1234abcd56789ef0", out hash));
        Assert.Equal(hash, HashCode64.Parse("  1234ABCD56789 EF0  "));
        Assert.Equal(HashCode64.Parse("0000000000000000"), HashCode64.Zero);
        Assert.Equal(hash.GetHashCode(), HashCode64.Parse("1234abcd56789ef0").GetHashCode());
        Assert.NotEqual(hash.GetHashCode(), HashCode64.Zero.GetHashCode());
        Assert.Equal(0, HashCode64.Zero.GetHashCode());
        Assert.Equal<uint>(0x1234abcd, hash.UHash1);
        Assert.Equal<uint>(0x56789ef0, hash.UHash2);
        Assert.Equal(0x1234abcd, hash.Hash1);
        Assert.Equal(0x56789ef0, hash.Hash2);
        Assert.Equal(hash, new HashCode64(0x1234abcdu, 0x56789ef0));
        Assert.Equal(hash, new HashCode64(0x1234abcd, 0x56789ef0));
        Assert.Equal(hash, HashCode64.Parse("0x1234abcd56789ef0"));
        Assert.Equal(hash, HashCode64.Parse("0x1234abcd56789ef0"));
        Assert.False(HashCode64.TryParse("x1234abcd56789ef0", out hash));
        Assert.False(HashCode64.TryParse("0xx1234abcd56789ef0", out hash));
        Assert.False(HashCode64.TryParse("1234xabcd6789ef0", out hash));
    }

    [Fact]
    public void ArgumentNull()
    {
        Assert.Throws<ArgumentNullException>("s", () => HashCode64.Parse(null));
    }

    [Fact]
    public void BadFormat()
    {
        Assert.Throws<FormatException>(() => HashCode64.Parse("0123456780123457833943"));
    }

    [Fact]
    public void BadFormatHigh()
    {
        Assert.Throws<FormatException>(
            () => HashCode64.Parse(
                "76544561234565434567654456012sdfafasjkl;fdsafdk1234565434561234565434567654456"));
    }

    [Fact]
    public void BadFormatLow()
    {
        Assert.Throws<FormatException>(
            () => HashCode64.Parse("0123456789f12323432343234324324323433232sdrtyrtyttytrty"));
    }

    [Fact]
    public void BadFormatDouble0X()
    {
        Assert.Throws<FormatException>(
            () => HashCode64.Parse("0x0x123456543456765445612345654345676544561234565434567654456"));
    }

    [Fact]
    public void BadFormatTooShort()
    {
        Assert.Throws<FormatException>(() => HashCode64.Parse(""));
    }

    [Fact]
    public void BadFormatTooShortPadded()
    {
        Assert.Throws<FormatException>(
            () => HashCode64.Parse("1234                                                            "));
    }

    [Fact]
    public void BadFormatTooShortHigh()
    {
        Assert.Throws<FormatException>(() => HashCode64.Parse(new string(' ', 32)));
    }

    [Fact]
    public void BadFormatTooShortLow()
    {
        Assert.Throws<FormatException>(
            () => HashCode64.Parse("0123456789abcdef01234                                        "));
    }

    [Fact]
    public void ToStringTests()
    {
        Assert.Equal(
            "01234ABCD56789EF", HashCode64.Parse("01234abcd56789ef").ToString());
    }

    [Fact]
    public void EqualsObj()
    {
        Assert.Equal(HashCode64.Zero, (object) HashCode64.Zero);
        object boxed = HashCode64.Parse("01234abcd56789ef");
        Assert.True(boxed.Equals(HashCode64.Parse("01234ABCD56789EF")));
        Assert.False(boxed.Equals(HashCode64.Zero));
        Assert.False(boxed.Equals("not a hash code"));
        Assert.True(
            Equals(
                HashCode64.Parse("fed c b a9876543210"),
                HashCode64.Parse("FE DCBA 98765 432 10      ")));
    }

    [Fact]
#pragma warning disable 1718 //Yes, I'm testing the obvious!
    public void EqualsOps()
    {
        Assert.True(HashCode64.Zero == HashCode64.Zero);
        Assert.True(
            HashCode64.Parse("01234abcd56789ef")
         == HashCode64.Parse("01234ABCD56789EF"));
        Assert.False(HashCode64.Zero != HashCode64.Zero);
        Assert.False(
            HashCode64.Parse("01234abcd56789ef")
         != HashCode64.Parse("01234ABCD56789EF"));
        Assert.True(HashCode64.Parse("01234abcd56789ef") != HashCode64.Zero);
        Assert.False(HashCode64.Parse("01234abcd56789ef") == HashCode64.Zero);
    }

    [Fact]
    public void OutputTest()
    {
        var hash = HashCode64.Parse("01234abcd56789ef");

        hash.GetHexString(false).ShouldBe("01234abcd56789ef");
        hash.GetHexString(true).ShouldBe("01234ABCD56789EF");

        hash.GetBinString(false).ShouldBe("100100011010010101011110011010101011001111000100111101111");
        hash.GetBinString(true).ShouldBe("0000000100100011010010101011110011010101011001111000100111101111");
    }
}