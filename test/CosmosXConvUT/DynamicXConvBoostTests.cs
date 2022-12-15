using Cosmos.Conversions.Common.Core;
using CosmosXConvUT.Helpers;
using Shouldly;

namespace CosmosXConvUT;

public class DynamicXConvBoostTests : Prepare
{
    [Fact]
    public void BuildTest()
    {
        var builder = new XConvFuncBuilder<string, string>();

        var handler = builder.Build();

        handler.ShouldNotBeNull();

        var o = "123";
        var x = handler(o, "789", default, null);

        x.ShouldBe("123");
    }
}