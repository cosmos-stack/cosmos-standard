using System.Text;
using Cosmos.Conversions;
using CosmosStandardUT.Models;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.ConvUT
{
    public class CommonCastingTest2
    {
        [Fact]
        public void AnyToAny()
        {
            "1".CastTo<short>().ShouldBe((short) 1);
            "1".CastTo<ushort>().ShouldBe((ushort) 1);
            "1".CastTo<int>().ShouldBe(1);
            "1".CastTo<uint>().ShouldBe((uint) 1);
            "1".CastTo<long>().ShouldBe(1);
            "1".CastTo<ulong>().ShouldBe((ulong) 1);
            "1".CastTo<float>().ShouldBe(1F);
            "1".CastTo<double>().ShouldBe(1D);
            "1".CastTo<decimal>().ShouldBe(1M);

            "1".CastTo<NiceYou001>().ShouldBe(NiceYou001.A);
            "A".CastTo<NiceYou001>().ShouldBe(NiceYou001.A);
            NiceYou001.A.CastTo<int>().ShouldBe((int) NiceYou001.A);
            NiceYou001.A.CastTo<string>().ShouldBe("A");
            NiceYou001.A.CastTo<decimal>().ShouldBe(1M);


            "utf-8".CastTo(Encoding.ASCII).ShouldBe(Encoding.UTF8);
        }
    }
}