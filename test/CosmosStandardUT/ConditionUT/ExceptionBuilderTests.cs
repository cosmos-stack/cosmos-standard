using System;
using Cosmos.Exceptions;
using Cosmos.Validation;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.ConditionUT
{
    [Trait("ConditionUT", "ExceptionBuilder")]
    public class ExceptionBuilderTests: Prepare
    {
        [Fact(DisplayName = "Raise exception with message test")]
        public void RaiseExceptionWithMessageTest()
        {
            Assert.Throws<ArgumentException>(() => ExceptionBuilder.Raise<ArgumentException>(false));
            Assert.Throws<ArgumentException>(() => ExceptionBuilder.Raise<ArgumentException>(false));
            Assert.Throws<ArgumentNullException>(() => ExceptionBuilder.Raise<ArgumentException>(false,string.Empty));
            Assert.Throws<ArgumentNullException>(() => ExceptionBuilder.Raise<ArgumentException>(false, (string) null));
            Assert.Throws<ArgumentException>(() => ExceptionBuilder.Raise<ArgumentException>(false, "something is wrong"));
        }

        [Fact(DisplayName = "Raise exception with message and inner exception test")]
        public void RaiseExceptionWithMessageAndInnerTest()
        {
            var exception = new InvalidOperationException();
            //Assert.Throws<ArgumentNullException>(() => ExceptionBuilder.Raise<ArgumentException>(false, string.Empty, exception));
            //Assert.Throws<ArgumentNullException>(() => ExceptionBuilder.Raise<ArgumentException>(false, null, exception));
            Assert.Throws<ArgumentException>(() => ExceptionBuilder.Raise<ArgumentException>(false, "something is wrong", exception));
        }

        [Fact(DisplayName = "Raise exception with ExceptionOptions test")]
        public void RaiseExceptionWithOptions()
        {
            var options = new ExceptionOptions
            {
                InnerException = new InvalidOperationException("invalid ops"),
                ErrorCode = 1000,
                Flag = "TEST_ERR"
            };

            Assert.Throws<ArgumentNullException>(() => ExceptionBuilder.Raise<ValidationException>(false, (ExceptionOptions) null));
            Assert.Throws<ValidationException>(() => ExceptionBuilder.Raise<ValidationException>(false, options));
        }

#if !NET451 && !NET452
        [Fact(DisplayName = "Create exception by common exception builder test")]
        public void CommonCreateExceptionTest()
        {
            var ex0 = ExceptionBuilder.Create(typeof(ArgumentNullException))
                                     .ParamName("nice")
                                     .Build();

            ex0.ShouldNotBeNull();
            (ex0 is ArgumentNullException).ShouldBeTrue();
        }

        [Fact(DisplayName = "Create exception by fluent exception builder test")]
        public void GenericCreateExceptionTest()
        {
            var ex0 = ExceptionBuilder.Create<ArgumentNullException>()
                                      .ParamName("nice")
                                      .Build();
            
            ex0.ShouldNotBeNull();
        }

#endif
    }
}