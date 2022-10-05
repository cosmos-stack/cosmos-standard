using Cosmos.Net;

namespace CosmosStandardUT.NetUT;

[Trait("Net.IpV4UT", "Convert")]
public class IPV4Tests
{
    [Fact(DisplayName = "Convert IPV4 to UINT32 test")]
    public void ConvertIpv4ToUInt32Test()
    {
        var uint32a = IpConvert.ConvertIPv4ToUInt32("216.58.197.99");
        uint32a.ShouldBe(3627730275u);
    }

    [Fact(DisplayName = "Convert UINT32 to IPV4 test")]
    public void ConvertUInt32ToIpv4Test()
    {
        var ip = IpConvert.ConvertUInt32ToIPv4Str(3627730275u);
        ip.ShouldBe("216.58.197.99");
    }

    [Fact(DisplayName = "Convert IPV4 to INT64 test")]
    public void ConvertIpv4ToInt64Test()
    {
        var int64 = IpConvert.ConvertIPv4ToInt64("216.58.197.99");
        int64.ShouldBe(-667237021L);
    }

    [Fact(DisplayName = "Convert INT64 to IPV4 test")]
    public void ConvertInt64ToIpv4Test()
    {
        var ip = IpConvert.ConvertInt64ToIPv4Str(-667237021L);
        ip.ShouldBe("216.58.197.99");
    }
}