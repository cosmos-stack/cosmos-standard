using Cosmos.Date;
using Cosmos.Validation;

namespace CosmosStandardUT.DateTimeUT
{
    [Trait("DateTimeUT", "TimeSpanGuard")]
    public class TimeSpanGuardTests
    {
        [Fact(DisplayName = "Positive TimeSpan test")]
        public void PositiveTimeSpanTest()
        {
            var date = DateTime.Now;
            var a = date - date.AddDays(1); //negative
            var b = date - date; //zero
            var c = date - date.AddDays(-1); //positive

            Assert.Throws<ValidationException>(() => TimeSpanGuard.ShouldBePositive(a, "span-a"));
            Assert.Throws<ValidationException>(() => TimeSpanGuard.ShouldBePositive(b, "span-b"));
            TimeSpanGuard.ShouldBePositive(c, "span-c");

            Assert.Throws<ValidationException>(() => TimeSpanGuard.ShouldBePositiveOrZero(a, "span-a"));
            TimeSpanGuard.ShouldBePositiveOrZero(b, "span-b");
            TimeSpanGuard.ShouldBePositiveOrZero(c, "span-c");

            TimeSpan? a1 = a;
            TimeSpan? b1 = b;
            TimeSpan? c1 = c;

            Assert.Throws<ValidationException>(() => TimeSpanGuard.ShouldBePositive(a1, "span-a1"));
            Assert.Throws<ValidationException>(() => TimeSpanGuard.ShouldBePositive(b1, "span-b1"));
            TimeSpanGuard.ShouldBePositive(c1, "span-c1");

            Assert.Throws<ValidationException>(() => TimeSpanGuard.ShouldBePositiveOrZero(a1, "span-a1"));
            TimeSpanGuard.ShouldBePositiveOrZero(b1, "span-b1");
            TimeSpanGuard.ShouldBePositiveOrZero(c1, "span-c1");
        }

        [Fact(DisplayName = "Negative TimeSpan test")]
        public void NegativeTimeSpanTest()
        {
            var date = DateTime.Now;
            var a = date - date.AddDays(-1); //positive
            var b = date - date; //zero
            var c = date - date.AddDays(1); //negative

            Assert.Throws<ValidationException>(() => TimeSpanGuard.ShouldBeNegative(a, "span-a"));
            Assert.Throws<ValidationException>(() => TimeSpanGuard.ShouldBeNegative(b, "span-b"));
            TimeSpanGuard.ShouldBeNegative(c, "span-c");

            Assert.Throws<ValidationException>(() => TimeSpanGuard.ShouldBeNegativeOrZero(a, "span-a"));
            TimeSpanGuard.ShouldBeNegativeOrZero(b, "span-b");
            TimeSpanGuard.ShouldBeNegativeOrZero(c, "span-c");

            TimeSpan? a1 = a;
            TimeSpan? b1 = b;
            TimeSpan? c1 = c;

            Assert.Throws<ValidationException>(() => TimeSpanGuard.ShouldBeNegative(a1, "span-a1"));
            Assert.Throws<ValidationException>(() => TimeSpanGuard.ShouldBeNegative(b1, "span-b1"));
            TimeSpanGuard.ShouldBeNegative(c1, "span-c1");

            Assert.Throws<ValidationException>(() => TimeSpanGuard.ShouldBeNegativeOrZero(a1, "span-a1"));
            TimeSpanGuard.ShouldBeNegativeOrZero(b1, "span-b1");
            TimeSpanGuard.ShouldBeNegativeOrZero(c1, "span-c1");
            
        }
    }
}