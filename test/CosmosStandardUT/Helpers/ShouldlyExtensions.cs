// ReSharper disable once CheckNamespace

using Cosmos.Numeric;

namespace Shouldly;

public static class ShouldlyExtensions
{
    public static void ShouldBeNear(this double actual, double expected, double tolerance, string customMessage = null)
    {
        Numbers.IsNearEqual(actual, expected, tolerance).ShouldBeTrue();
    }

    public static void ShouldBeNear(this double? actual, double? expected, double tolerance, string customMessage = null)
    {
        Numbers.IsNearEqual(actual, expected, tolerance).ShouldBeTrue();
    }
}