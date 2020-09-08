using System;
using Cosmos.Conversions;
using Cosmos.Date;
using Xunit;

namespace Cosmos.Test.Conversions {
    public class DatetimeConversionTest {
        [Theory]
        [InlineData("2017-02-10 10:10:10")]
        public void StringDatetimeTest(string datetime) {
            var dt = DateTimeConv.ToDateTime(datetime);

            Assert.Equal(2017, dt.Year);
            Assert.Equal(2, dt.Month);
            Assert.Equal(10, dt.Day);

            Assert.Equal(10, dt.Hour);
            Assert.Equal(10, dt.Minute);
            Assert.Equal(10, dt.Second);
        }

        [Theory]
        [InlineData("2017-02-10 10:10:10.011")]
        public void StringDatetimeWithMillisecondTest(string datetime) {
            var dt = DateTimeConv.ToDateTime(datetime);

            Assert.Equal(2017, dt.Year);
            Assert.Equal(2, dt.Month);
            Assert.Equal(10, dt.Day);

            Assert.Equal(10, dt.Hour);
            Assert.Equal(10, dt.Minute);
            Assert.Equal(10, dt.Second);
            Assert.Equal(11, dt.Millisecond);
        }

        [Theory]
        [InlineData("2017-01-01 00:00:00.001")]
        public void StringDefaultDatetimeTest(string datetime) {
            var def = new DateTime(2017, 1, 1, 0, 0, 0, 001);
            var dt = DateTimeConv.ToDateTime(datetime, def);

            Assert.Equal(def, dt);
        }

        [Theory]
        [InlineData("2017-02-30 10:10:10")]
        public void StringNullDefaultDatetimeTest(string datetime) {
            var dt = DateTimeConv.ToNullableDateTime(datetime);
            Assert.Equal(default, dt);
        }
    }
}