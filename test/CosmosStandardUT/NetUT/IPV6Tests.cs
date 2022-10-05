using Cosmos.Net;

namespace CosmosStandardUT.NetUT;

[Trait("Net.IpV6UT", "Convert")]
public class IPV6Tests
{
    [Fact(DisplayName = "Convert IPV6 to INT64 test")]
    public void ConvertIpv6ToInt64Test()
    {
        var int64 = IpConvert.ConvertIPv6ToInt64("2409:8754:2:1::d24c:4b55");
        int64.ShouldBe(2596755455002935297L);
    }

    [Fact(DisplayName = "Convert INT64 to IPV6 test")]
    public void ConvertInt64ToIpv6Test()
    {
        var ip = IpConvert.ConvertInt64ToIPv6(2596755455002935297L);
        ip.ToString().ShouldBe("2409:8754:2:1::");
    }

    [Fact(DisplayName = "Convert IPV6 to UINT64 test")]
    public void ConvertIpv6ToUInt64Test()
    {
        var uint64 = IpConvert.ConvertIPv6ToUInt64("2409:8754:2:1::d24c:4b55");
        uint64.ShouldBe(2596755458531150678UL);
    }

    // [Fact(DisplayName = "Convert UINT64 to IPV6 test")]
    // public void ConvertUInt64ToIpv6Test()
    // {
    //     var ip = IpConvert.ConvertUInt64ToIPv6(2596755458531150678UL);
    //     ip.ToString().ShouldBe("2409:8754:2:1::d24c:4b55");
    // }
}