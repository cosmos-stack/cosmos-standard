using System;
using Cosmos.Exceptions;
using Xunit;

namespace Cosmos.Test {
    public class TryTests {

        private static Func<bool, Func<string, Func<string>>> _func = success => str => {
            if (success) {
                return () => str;
            } else {
                return () => throw new ArgumentNullException(nameof(str));
            }
        };

        [Theory]
        [InlineData(true, "9", 1)]
        [InlineData(true, "Alex", 4)]
        public void TrySuccess(bool success, string value, int length) {
            var @try = Try.Create(_func(success)(value));
            Assert.True(@try.IsSuccess);
            Assert.False(@try.IsFailure);
            Assert.Null(@try.Exception);

            var len = @try.Match(s => s.Length, ex => 0);
            Assert.Equal(length, len);

            var map = @try.Map(s => s.Length);
            Assert.Equal(length, map.Value);

            var recover = @try.Recover(ex => "Error");
            Assert.Equal(value, recover.Value);

            var select = @try.Select(str => str.Length);
            Assert.Equal(length, select.Value);
        }

        [Theory]
        [InlineData(false, "")]
        [InlineData(false, null)]
        public void TryFailure(bool failure, string value) {
            var @try = Try.Create(_func(failure)(value));
            Assert.False(@try.IsSuccess);
            Assert.True(@try.IsFailure);
            Assert.NotNull(@try.Exception);
            Assert.NotNull(@try.ExceptionAs<ArgumentNullException>());

            var len = @try.Match(s => s.Length, ex => 0);
            Assert.Equal(0, len);

            try {
                var map = @try.Map(s => s.Length);
            } catch (Exception ex) {
                Assert.NotNull(ex);
            }

            var recover = @try.Recover(ex => "Error");
            Assert.Equal("Error", recover.Value);
            
            var select = @try.Select(str => str.Length);
            Assert.NotNull(select.Exception);
        }
    }
}