using System;
using Cosmos.Date;
using Cosmos.Text;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.ConvUT
{
    public class DateTimeCastTests
    {
        [Theory]
        [InlineData("1971-01-01 11:06:18", 1971, 1, 1, 11, 06, 18)]
        [InlineData("2020-01-01 11:06:18", 2020, 1, 1, 11, 06, 18)]
        [InlineData("5020-01-01 11:06:18", 5020, 1, 1, 11, 06, 18)]
        public void StringToDateTime(string str, int year, int month, int day, int hour, int minute, int second)
        {
            var expected = new DateTime(year, month, day, hour, minute, second);
            str.CastToDateTime().ShouldBe(expected);
        }

        [Theory]
        [InlineData("2020-01-41 11:06:18")]
        public void StringToDateTime_FailureAndDefault(string str)
        {
            var defaultVal = new DateTime(2020, 1, 1, 11, 06, 18);
            str.CastToDateTime(defaultVal).ShouldBe(defaultVal);
        }

        [Theory]
        [InlineData("1971-01-01", 1971, 1, 1)]
        [InlineData("2020-01-01", 2020, 1, 1)]
        [InlineData("5020-01-01", 5020, 1, 1)]
        public void StringToDateInfo(string str, int year, int month, int day)
        {
            var expected = new DateInfo(year, month, day);
            str.CastToDateInfo().ShouldBe(expected);
        }
    }
}