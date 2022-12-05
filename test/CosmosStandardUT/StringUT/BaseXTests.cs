using System.Text;
using Cosmos.Conversions;

namespace CosmosStandardUT.StringUT;

[Trait("ConvUT", "BaseX")]
public class BaseXTests
{
    [Fact(DisplayName = "Base32 string test")]
    public void Base32StringTest()
    {
        var baseVal = BaseConv.ToBase32String("Alex LEWIS");
        var originalVal = BaseConv.FromBase32String(baseVal);

        Assert.Equal("Alex LEWIS", originalVal);
    }

    [Fact(DisplayName = "Base32 byte[] test")]
    public void Base32BytesTest()
    {
        var byteArray = Encoding.UTF8.GetBytes("Alex LEWIS");
        var baseVal = BaseConv.ToBase32(byteArray);
        var originalByteArray = BaseConv.FromBase32(baseVal);
        var originalVal = Encoding.UTF8.GetString(originalByteArray);

        Assert.Equal("Alex LEWIS", originalVal);
    }

    [Fact(DisplayName = "Base64 string test")]
    public void Base64StringTest()
    {
        var baseVal = BaseConv.ToBase64String("Alex LEWIS");
        var originalVal = BaseConv.FromBase64String(baseVal);

        Assert.Equal("Alex LEWIS", originalVal);
    }

    [Fact(DisplayName = "Base64 byte[] test")]
    public void Base64BytesTest()
    {
        var byteArray = Encoding.UTF8.GetBytes("Alex LEWIS");
        var baseVal = BaseConv.ToBase64(byteArray);
        var originalByteArray = BaseConv.FromBase64(baseVal);
        var originalVal = Encoding.UTF8.GetString(originalByteArray);

        Assert.Equal("Alex LEWIS", originalVal);
    }

    [Fact(DisplayName = "Base91 string test")]
    public void Base91StringTest()
    {
        var baseVal = BaseConv.ToBase91String("Alex LEWIS");
        var originalVal = BaseConv.FromBase91String(baseVal);

        Assert.Equal("Alex LEWIS", originalVal);
    }

    [Fact(DisplayName = "Base91 byte[] test")]
    public void Base91BytesTest()
    {
        var byteArray = Encoding.UTF8.GetBytes("Alex LEWIS");
        var baseVal = BaseConv.ToBase91(byteArray);
        var originalByteArray = BaseConv.FromBase91(baseVal);
        var originalVal = Encoding.UTF8.GetString(originalByteArray);

        Assert.Equal("Alex LEWIS", originalVal);
    }

    [Fact(DisplayName = "Base256 string test")]
    public void Base256StringTest()
    {
        var baseVal = BaseConv.ToBase256String("Alex LEWIS");
        var originalVal = BaseConv.FromBase256String(baseVal);

        Assert.Equal("Alex LEWIS", originalVal);
    }

    [Fact(DisplayName = "Base256 byte[] test")]
    public void Base256BytesTest()
    {
        var byteArray = Encoding.UTF8.GetBytes("Alex LEWIS");
        var baseVal = BaseConv.ToBase256(byteArray);
        var originalByteArray = BaseConv.FromBase256(baseVal);
        var originalVal = Encoding.UTF8.GetString(originalByteArray);

        Assert.Equal("Alex LEWIS", originalVal);
    }

    [Fact(DisplayName = "ZBase32 string test")]
    public void ZBase32StringTest()
    {
        var baseVal = BaseConv.ToZBase32String("Alex LEWIS");
        var originalVal = BaseConv.FromZBase32String(baseVal);

        Assert.Equal("Alex LEWIS", originalVal);
    }

    [Fact(DisplayName = "ZBase32 byte[] test")]
    public void ZBase32BytesTest()
    {
        var byteArray = Encoding.UTF8.GetBytes("Alex LEWIS");
        var baseVal = BaseConv.ToZBase32(byteArray);
        var originalByteArray = BaseConv.FromZBase32(baseVal);
        var originalVal = Encoding.UTF8.GetString(originalByteArray);

        Assert.Equal("Alex LEWIS", originalVal);
    }

    [Fact(DisplayName = "Extension method for Base32 string test")]
    public void ExtensionMethodForBase32StringTest()
    {
        var baseVal = "Alex LEWIS".CastToBase32String();
        var originalVal = baseVal.CastFromBase32String();

        Assert.Equal("Alex LEWIS", originalVal);
    }

    [Fact(DisplayName = "Extension method for Base32 byte[] test")]
    public void ExtensionMethodForBase32BytesTest()
    {
        var byteArray = Encoding.UTF8.GetBytes("Alex LEWIS");
        var baseVal = byteArray.CastToBase32String();
        var originalVal = baseVal.CastFromBase32String();

        Assert.Equal("Alex LEWIS", originalVal);
    }

    [Fact(DisplayName = "Extension method for Base64 string test")]
    public void ExtensionMethodForBase64StringTest()
    {
        var baseVal = "Alex LEWIS".CastToBase64String();
        var originalVal = baseVal.CastFromBase64String();

        Assert.Equal("Alex LEWIS", originalVal);
    }

    [Fact(DisplayName = "Extension method for Base64 byte[] test")]
    public void ExtensionMethodForBase64BytesTest()
    {
        var byteArray = Encoding.UTF8.GetBytes("Alex LEWIS");
        var baseVal = byteArray.CastToBase64String();
        var originalVal = baseVal.CastFromBase64String();

        Assert.Equal("Alex LEWIS", originalVal);
    }

    [Fact(DisplayName = "Extension method for Base91 string test")]
    public void ExtensionMethodForBase91StringTest()
    {
        var baseVal = "Alex LEWIS".CastToBase91String();
        var originalVal = baseVal.CastFromBase91String();

        Assert.Equal("Alex LEWIS", originalVal);
    }

    [Fact(DisplayName = "Extension method for Base91 byte[] test")]
    public void ExtensionMethodForBase91BytesTest()
    {
        var byteArray = Encoding.UTF8.GetBytes("Alex LEWIS");
        var baseVal = byteArray.CastToBase91String();
        var originalVal = baseVal.CastFromBase91String();

        Assert.Equal("Alex LEWIS", originalVal);
    }

    [Fact(DisplayName = "Extension method for Base256 string test")]
    public void ExtensionMethodForBase256StringTest()
    {
        var baseVal = "Alex LEWIS".CastToBase256String();
        var originalVal = baseVal.CastFromBase256String();

        Assert.Equal("Alex LEWIS", originalVal);
    }

    [Fact(DisplayName = "Extension method for Base256 byte[] test")]
    public void ExtensionMethodForBase256BytesTest()
    {
        var byteArray = Encoding.UTF8.GetBytes("Alex LEWIS");
        var baseVal = byteArray.CastToBase256String();
        var originalVal = baseVal.CastFromBase256String();

        Assert.Equal("Alex LEWIS", originalVal);
    }

    [Fact(DisplayName = "Extension method for ZBase32 string test")]
    public void ExtensionMethodForZBase32StringTest()
    {
        var baseVal = "Alex LEWIS".CastToZBase32String();
        var originalVal = baseVal.CastFromZBase32String();

        Assert.Equal("Alex LEWIS", originalVal);
    }

    [Fact(DisplayName = "Extension method for ZBase32 byte[] test")]
    public void ExtensionMethodForZBase32BytesTest()
    {
        var byteArray = Encoding.UTF8.GetBytes("Alex LEWIS");
        var baseVal = byteArray.CastToZBase32String();
        var originalVal = baseVal.CastFromZBase32String();

        Assert.Equal("Alex LEWIS", originalVal);
    }
}