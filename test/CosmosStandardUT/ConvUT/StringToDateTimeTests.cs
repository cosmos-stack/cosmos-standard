using System;
using CosmosStack.Date;
using CosmosStack.Text;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.ConvUT
{
    [Trait("ConvUT", "StringConv.DateTime")]
    public class StringToDateTimeTests
    {
        [Fact(DisplayName = "Casting null or empty to datetime test")]
        public void CastingNullOrEmptyStringToDateTimeTest()
        {
            ((string)null).CastToDateTime().ShouldBe(default);
            (string.Empty).CastToDateTime().ShouldBe(default);
            "".CastToDateTime().ShouldBe(default);

            var defaultVal = DateTime.Now;
            ((string)null).CastToDateTime(defaultVal).ShouldBe(defaultVal);
            (string.Empty).CastToDateTime(defaultVal).ShouldBe(defaultVal);
            "".CastToDateTime(defaultVal).ShouldBe(defaultVal);

            var utcDefaultVal = DateTime.UtcNow;
            ((string)null).CastToDateTime(utcDefaultVal).ShouldBe(utcDefaultVal);
            (string.Empty).CastToDateTime(utcDefaultVal).ShouldBe(utcDefaultVal);
            "".CastToDateTime(utcDefaultVal).ShouldBe(utcDefaultVal);
        }

        [Fact(DisplayName = "Casting valid string with date to datetime test")]
        public void CastingValidStringWithDateToDateTimeTest()
        {
            var date = DateTime.Today.ToString("yyyy-MM-dd");
            var today = DateTime.Today;
            date.CastToDateTime().ShouldBe(today);
        }

        [Fact(DisplayName = "Casting valid string with datetime to datetime test")]
        public void CastingValidStringWithDateTimeToDateTimeTest()
        {
            var date = $"{DateTime.Today:yyyy-MM-dd} 12:12:12";
            var now = DateTime.Today.SetTime(12, 12, 12);
            date.CastToDateTime().ShouldBe(now);
        }

        [Fact(DisplayName = "Casting invalid string to datetime test")]
        public void CastingInvalidStringToDateTimeTest()
        {
            "196-12-12".CastToDateTime().ShouldBe(new DateTime(196,12,12));
            "2000-13-12".CastToDateTime().ShouldBe(default);
            "2000-1-32".CastToDateTime().ShouldBe(default);
        }
        
        [Fact(DisplayName = "Casting null or empty to nullable datetime test")]
        public void CastingNullOrEmptyStringToNullableDateTimeTest()
        {
            ((string)null).CastToNullableDateTime().ShouldBeNull();
            (string.Empty).CastToNullableDateTime().ShouldBeNull();
            "".CastToNullableDateTime().ShouldBeNull();
        }

        [Fact(DisplayName = "Casting valid string with date to nullable datetime test")]
        public void CastingValidStringWithDateToNullableDateTimeTest()
        {
            var date = DateTime.Today.ToString("yyyy-MM-dd");
            DateTime? today = DateTime.Today;
            date.CastToNullableDateTime().ShouldBe(today);
        }

        [Fact(DisplayName = "Casting valid string with datetime to nullable datetime test")]
        public void CastingValidStringWithDateTimeToNullableDateTimeTest()
        {
            var date = $"{DateTime.Today:yyyy-MM-dd} 12:12:12";
            DateTime? now = DateTime.Today.SetTime(12, 12, 12);
            date.CastToNullableDateTime().ShouldBe(now);
        }

        [Fact(DisplayName = "Casting invalid string to nullable datetime test")]
        public void CastingInvalidStringToNullableDateTimeTest()
        {
            "196-12-12".CastToNullableDateTime().ShouldBe(new DateTime(196,12,12));
            "2000-13-12".CastToNullableDateTime().ShouldBeNull();
            "2000-1-32".CastToNullableDateTime().ShouldBeNull();
        }
        
        [Fact(DisplayName = "Casting null or empty to datetimeOffset test")]
        public void CastingNullOrEmptyStringToDateTimeOffsetTest()
        {
            ((string)null).CastToDateTimeOffset().ShouldBe(default);
            (string.Empty).CastToDateTimeOffset().ShouldBe(default);
            "".CastToDateTimeOffset().ShouldBe(default);

            var defaultVal = DateTimeOffset.Now;
            ((string)null).CastToDateTimeOffset(defaultVal).ShouldBe(defaultVal);
            (string.Empty).CastToDateTimeOffset(defaultVal).ShouldBe(defaultVal);
            "".CastToDateTimeOffset(defaultVal).ShouldBe(defaultVal);

            var utcDefaultVal = DateTimeOffset.UtcNow;
            ((string)null).CastToDateTimeOffset(utcDefaultVal).ShouldBe(utcDefaultVal);
            (string.Empty).CastToDateTimeOffset(utcDefaultVal).ShouldBe(utcDefaultVal);
            "".CastToDateTimeOffset(utcDefaultVal).ShouldBe(utcDefaultVal);
        }

        [Fact(DisplayName = "Casting valid string with date to datetimeOffset test")]
        public void CastingValidStringWithDateToDateTimeOffsetTest()
        {
            var date = DateTimeOffset.Now.ToString("yyyy-MM-dd");
            DateTimeOffset today = DateTimeOffset.Now.Date;
            date.CastToDateTimeOffset().ShouldBe(today);
        }

        [Fact(DisplayName = "Casting valid string with datetime to datetimeOffset test")]
        public void CastingValidStringWithDateTimeToDateTimeOffsetTest()
        {
            var date = $"{DateTimeOffset.Now:yyyy-MM-dd} 12:12:12";
            DateTimeOffset now = DateTimeOffset.Now.Date.SetTime(12, 12, 12);
            date.CastToDateTimeOffset().ShouldBe(now);
        }

        [Fact(DisplayName = "Casting invalid string to datetimeOffset test")]
        public void CastingInvalidStringToDateTimeOffsetTest()
        {
            "196-12-12".CastToDateTimeOffset().ShouldBe(new DateTime(196,12,12));
            "2000-13-12".CastToDateTimeOffset().ShouldBe(default);
            "2000-1-32".CastToDateTimeOffset().ShouldBe(default);
        }
        
        [Fact(DisplayName = "Casting null or empty to nullable datetimeOffset test")]
        public void CastingNullOrEmptyStringToNullableDateTimeOffsetTest()
        {
            ((string)null).CastToNullableDateTimeOffset().ShouldBeNull();
            (string.Empty).CastToNullableDateTimeOffset().ShouldBeNull();
            "".CastToNullableDateTimeOffset().ShouldBeNull();
        }

        [Fact(DisplayName = "Casting valid string with date to nullable datetimeOffset test")]
        public void CastingValidStringWithDateToNullableDateTimeOffsetTest()
        {
            var date = DateTimeOffset.Now.ToString("yyyy-MM-dd");
            DateTimeOffset? today = DateTimeOffset.Now.Date;
            date.CastToNullableDateTimeOffset().ShouldBe(today);
        }

        [Fact(DisplayName = "Casting valid string with datetime to nullable datetimeOffset test")]
        public void CastingValidStringWithDateTimeToNullableDateTimeOffsetTest()
        {
            var date = $"{DateTimeOffset.Now:yyyy-MM-dd} 12:12:12";
            DateTimeOffset? now = DateTimeOffset.Now.Date.SetTime(12, 12, 12);
            date.CastToNullableDateTimeOffset().ShouldBe(now);
        }

        [Fact(DisplayName = "Casting invalid string to nullable datetimeOffset test")]
        public void CastingInvalidStringToNullableDateTimeOffsetTest()
        {
            "196-12-12".CastToNullableDateTimeOffset().ShouldBe(new DateTime(196,12,12));
            "2000-13-12".CastToNullableDateTimeOffset().ShouldBeNull();
            "2000-1-32".CastToNullableDateTimeOffset().ShouldBeNull();
        }

        [Fact(DisplayName = "Casting null or empty to TimeSpan test")]
        public void CastingNullOrEmptyToSpanTest()
        {
            ((string)null).CastToTimeSpan().ShouldBe(default);
            string.Empty.CastToTimeSpan().ShouldBe(default);
            "".CastToTimeSpan().ShouldBe(default);
        }
        
        [Fact(DisplayName = "Casting valid string to TimeSpan test")]
        public void CastingValidStringToSpanTest()
        {
            var today = DateTime.Today;
            var now = DateTime.Now;
            var span = now - today;
            var spanStr = span.ToString("G");
            
            spanStr.CastToTimeSpan().ShouldBe(span);
        }

        [Fact(DisplayName = "Casting null or empty to nullable TimeSpan test")]
        public void CastingNullOrEmptyToNullableSpanTest()
        {
            ((string)null).CastToNullableTimeSpan().ShouldBeNull();
            string.Empty.CastToNullableTimeSpan().ShouldBeNull();
            "".CastToNullableTimeSpan().ShouldBeNull();
        }
        
        [Fact(DisplayName = "Casting valid string to nullable TimeSpan test")]
        public void CastingValidStringToNullableSpanTest()
        {
            var today = DateTime.Today;
            var now = DateTime.Now;
            var span = now - today;
            var spanStr = span.ToString("G");
            
            spanStr.CastToNullableTimeSpan().ShouldBe(span);
        }
    }
}