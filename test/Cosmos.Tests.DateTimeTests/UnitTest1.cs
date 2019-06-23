using System;
using FluentDateTime;
using Shouldly;
using Xunit;

namespace Cosmos.Tests.DateTimeTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var dt = DateTime.Now;
            var d2 = dt.AddHours(25);
            var span = d2 - dt;
            span.Days.ShouldBe(1);
        }
    }
}
