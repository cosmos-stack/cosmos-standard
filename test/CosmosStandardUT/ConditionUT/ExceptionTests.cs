using System;
using Cosmos.Exceptions;
using Cosmos.Validation;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.ConditionUT
{
    [Trait("ConditionUT", "Exception")]
    public class ExceptionTests
    {
        [Fact(DisplayName = "Exceptions unwrap test")]
        public void ExceptionUnwrapTest()
        {
            var lv0 = new ArgumentNullException("name", "lv0");
            var lv1 = new InvalidOperationException("lv1", lv0);
            var lv2 = new ArgumentException("lv2", lv1);
            var lv3 = new ArgumentException("lv2", lv2);
            var lv4 = new ArgumentException("lv2", lv3);
            var lv5 = new ArgumentException("lv2", lv4);

            var lvA = lv5.Unwrap();
            var lvB = lv5.Unwrap(typeof(ArgumentNullException));
            var lvC = lv5.Unwrap<ArgumentNullException>();
            var lvD = lv5.Unwrap(typeof(InvalidOperationException));
            var lvE = lv5.Unwrap<InvalidOperationException>();
            
            lvA.ShouldNotBeNull();
            lvB.ShouldNotBeNull();
            lvC.ShouldNotBeNull();
            lvD.ShouldNotBeNull();
            lvE.ShouldNotBeNull();

            var message = @"lv0
Parameter name: name";
            
            lvA.Message.ShouldBe(message);
            lvB.Message.ShouldBe(message);
            lvC.Message.ShouldBe(message);
            lvD.Message.ShouldBe("lv1");
            lvE.Message.ShouldBe("lv1");
        }

        [Fact(DisplayName = "Exceptions unwrap string test")]
        public void ExceptionUnwrapStringTest()
        {
            var lv0 = new ArgumentNullException("name", "lv0");
            var lv1 = new InvalidOperationException("lv1", lv0);
            var lv2 = new ArgumentException("lv1", lv1);
            var lv3 = new ArgumentException("lv2", lv2);
            var lv4 = new ArgumentException("lv3", lv3);
            var lv5 = new ArgumentException("lv4", lv4);
            var lvZ = new ValidationException(1000, "lvZ", lv5);

            var lvA = lv5.ToUnwrappedString();
            var lvB = lv5.ToFullUnwrappedString();
            var lvC = lvZ.ToUnwrappedString();
            var lvD = lvZ.ToFullUnwrappedString();
            
            lvA.ShouldBe(lv0.Message);
            lvB.ShouldBe(lv0.Message);
            lvC.ShouldBe(lv0.Message);
            lvD.ShouldBe(@"lvZ
lv0
Parameter name: name");
        }

        [Fact(DisplayName = "Exceptions options creating test")]
        public void ExceptionOptionsCreatingTest()
        {
            var options = new ExceptionOptions();
            options.InnerException = new InvalidOperationException("invalid ops");
            options.ErrorCode = 1000;
            options.Flag = "TEST_ERR";
            var lvZ=new ValidationException(options);
            
            lvZ.InnerException.ShouldNotBeNull();
            lvZ.InnerException.Message.ShouldBe("invalid ops");
            lvZ.Code.ShouldBe(1000);
            lvZ.Flag.ShouldBe("TEST_ERR");
        }
    }
}