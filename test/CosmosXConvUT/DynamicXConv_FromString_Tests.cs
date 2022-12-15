using System;
using Cosmos.Conversions;
using Cosmos.Conversions.Common.Core;
using Cosmos.Conversions.ObjectMappingServices;
using CosmosXConvUT.Helpers;
using Shouldly;

namespace CosmosXConvUT;

public class DynamicXConv_FromString_Tests : Prepare
{
    public DynamicXConv_FromString_Tests()
    {
        _stringToStringHandler = new XConvFuncBuilder<string, string>().Build();
        _stringToIntHandler = new XConvFuncBuilder<string, int>().Build();
    }

    private readonly Func<string, string, CastingContext, IObjectMapper, string> _stringToStringHandler;
    private readonly Func<string, int, CastingContext, IObjectMapper, int> _stringToIntHandler;

    [Theory]
    [InlineData(null, null, null)]
    [InlineData(null, "", "")]
    [InlineData(null, "789", "789")]
    [InlineData("", "", "")]
    [InlineData("", "789", "")]
    [InlineData("", null, "")]
    [InlineData("123", "789", "123")]
    public void StringToStringTest(string originalString, string defaultString, string expectedString)
    {
        var targetString = _stringToStringHandler(originalString, defaultString, default, null);
        targetString.ShouldBe(expectedString);
    }

    [Theory]
    [InlineData(null, null, 0)]
    [InlineData(null, 1000, 1000)]
    [InlineData("100", 1000, 100)]
    [InlineData("100.0", 1000, 100)]
    [InlineData("100.1", 1000, 100)]
    [InlineData("abc.1", 1000, 1000)]
    public void StringToIntTest(string originalString, int defaultInt, int expectedInt)
    {
        var targetInt = _stringToIntHandler(originalString, defaultInt, default, null);
        targetInt.ShouldBe(expectedInt);
    }
}