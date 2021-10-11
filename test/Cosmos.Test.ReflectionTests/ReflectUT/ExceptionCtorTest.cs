using System;
using CosmosStack.Exceptions;
using Xunit;

namespace ReflectUT
{
    public class ExceptionCtorTest
    {
#if !NET451 && !NET452
        [Fact]
        public void CreateTest()
        {
            var fluent = ExceptionBuilder.Create<ArgumentNullException>()
                                         .ParamName(nameof(CreateTest))
                                         .Message("Create test");

            var fluException = fluent.Build();
            var refException = new ArgumentNullException(nameof(CreateTest), "Create test");

            Assert.Equal(fluException.Message, refException.Message);
            Assert.Equal(fluException.ParamName, refException.ParamName);
        }
#endif
    }
}