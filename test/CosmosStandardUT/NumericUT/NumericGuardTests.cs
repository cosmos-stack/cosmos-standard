using Cosmos.Numeric;
using Cosmos.Validation;

namespace CosmosStandardUT.NumericUT
{
    [Trait("NumericUT", "NumericGuard")]
    public class NumericGuardTests
    {
        [Fact(DisplayName = "Numbers should be positive test")]
        public void NumberShouldBePositiveTest()
        {
            int number1 = 1;
            long number2 = 1L;
            float number3 = 1.1F;
            double number4 = 1.1D;
            decimal number5 = 1;

            NumericGuard.ShouldBePositive(number1, "number1");
            NumericGuard.ShouldBePositive(number2, "number2");
            NumericGuard.ShouldBePositive(number3, "number3");
            NumericGuard.ShouldBePositive(number4, "number4");
            NumericGuard.ShouldBePositive(number5, "number5");

            NumericGuard.ShouldBePositiveOrZero(number1, "number1");
            NumericGuard.ShouldBePositiveOrZero(number2, "number2");
            NumericGuard.ShouldBePositiveOrZero(number3, "number3");
            NumericGuard.ShouldBePositiveOrZero(number4, "number4");
            NumericGuard.ShouldBePositiveOrZero(number5, "number5");
            
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegative(number1, "number1"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegative(number2, "number2"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegative(number3, "number3"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegative(number4, "number4"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegative(number5, "number5"));
            
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegativeOrZero(number1, "number1"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegativeOrZero(number2, "number2"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegativeOrZero(number3, "number3"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegativeOrZero(number4, "number4"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegativeOrZero(number5, "number5"));

            number1 = 0;
            number2 = 0;
            number3 = 0;
            number4 = 0;
            number5 = 0;

            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositive(number1, "number1"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositive(number2, "number2"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositive(number3, "number3"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositive(number4, "number4"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositive(number5, "number5"));

            NumericGuard.ShouldBePositiveOrZero(number1, "number1");
            NumericGuard.ShouldBePositiveOrZero(number2, "number2");
            NumericGuard.ShouldBePositiveOrZero(number3, "number3");
            NumericGuard.ShouldBePositiveOrZero(number4, "number4");
            NumericGuard.ShouldBePositiveOrZero(number5, "number5");
            
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegative(number1, "number1"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegative(number2, "number2"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegative(number3, "number3"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegative(number4, "number4"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegative(number5, "number5"));

            NumericGuard.ShouldBeNegativeOrZero(number1, "number1");
            NumericGuard.ShouldBeNegativeOrZero(number2, "number2");
            NumericGuard.ShouldBeNegativeOrZero(number3, "number3");
            NumericGuard.ShouldBeNegativeOrZero(number4, "number4");
            NumericGuard.ShouldBeNegativeOrZero(number5, "number5");
            
            int? number11 = 1;
            long? number21 = 1L;
            float? number31 = 1.1F;
            double? number41 = 1.1D;
            decimal? number51 = 1;

            NumericGuard.ShouldBePositive(number11, "number11");
            NumericGuard.ShouldBePositive(number21, "number21");
            NumericGuard.ShouldBePositive(number31, "number31");
            NumericGuard.ShouldBePositive(number41, "number41");
            NumericGuard.ShouldBePositive(number51, "number51");

            NumericGuard.ShouldBePositiveOrZero(number11, "number11");
            NumericGuard.ShouldBePositiveOrZero(number21, "number21");
            NumericGuard.ShouldBePositiveOrZero(number31, "number31");
            NumericGuard.ShouldBePositiveOrZero(number41, "number41");
            NumericGuard.ShouldBePositiveOrZero(number51, "number51");
            
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegative(number11, "number11"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegative(number21, "number21"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegative(number31, "number31"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegative(number41, "number41"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegative(number51, "number51"));
            
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegativeOrZero(number11, "number11"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegativeOrZero(number21, "number21"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegativeOrZero(number31, "number31"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegativeOrZero(number41, "number41"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegativeOrZero(number51, "number51"));

            number11 = 0;
            number21 = 0;
            number31 = 0;
            number41 = 0;
            number51 = 0;

            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositive(number11, "number11"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositive(number21, "number21"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositive(number31, "number31"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositive(number41, "number41"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositive(number51, "number51"));

            NumericGuard.ShouldBePositiveOrZero(number11, "number11");
            NumericGuard.ShouldBePositiveOrZero(number21, "number21");
            NumericGuard.ShouldBePositiveOrZero(number31, "number31");
            NumericGuard.ShouldBePositiveOrZero(number41, "number41");
            NumericGuard.ShouldBePositiveOrZero(number51, "number51");
            
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegative(number11, "number11"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegative(number21, "number21"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegative(number31, "number31"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegative(number41, "number41"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegative(number51, "number51"));
            
            NumericGuard.ShouldBeNegativeOrZero(number11, "number11");
            NumericGuard.ShouldBeNegativeOrZero(number21, "number21");
            NumericGuard.ShouldBeNegativeOrZero(number31, "number31");
            NumericGuard.ShouldBeNegativeOrZero(number41, "number41");
            NumericGuard.ShouldBeNegativeOrZero(number51, "number51");
            
            number11 = null;
            number21 = null;
            number31 = null;
            number41 = null;
            number51 = null;

            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositive(number11, "number11"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositive(number21, "number21"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositive(number31, "number31"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositive(number41, "number41"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositive(number51, "number51"));

            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositiveOrZero(number11, "number11"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositiveOrZero(number21, "number21"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositiveOrZero(number31, "number31"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositiveOrZero(number41, "number41"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositiveOrZero(number51, "number51"));

            NumericGuard.ShouldBePositiveOrZero(number11, "number11", options: NumericMayOptions.IgnoreNullable);
            NumericGuard.ShouldBePositiveOrZero(number21, "number21", options: NumericMayOptions.IgnoreNullable);
            NumericGuard.ShouldBePositiveOrZero(number31, "number31", options: NumericMayOptions.IgnoreNullable);
            NumericGuard.ShouldBePositiveOrZero(number41, "number41", options: NumericMayOptions.IgnoreNullable);
            NumericGuard.ShouldBePositiveOrZero(number51, "number51", options: NumericMayOptions.IgnoreNullable);
            
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegative(number11, "number11"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegative(number21, "number21"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegative(number31, "number31"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegative(number41, "number41"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegative(number51, "number51"));
            
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegativeOrZero(number11, "number11"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegativeOrZero(number21, "number21"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegativeOrZero(number31, "number31"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegativeOrZero(number41, "number41"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegativeOrZero(number51, "number51"));
        }

        [Fact(DisplayName = "Numbers should be negative test")]
        public void NumberShouldBeNegativeTest()
        {
            int number1 = -1;
            long number2 = -1L;
            float number3 = -1.1F;
            double number4 = -1.1D;
            decimal number5 = -1;

            NumericGuard.ShouldBeNegative(number1, "number1");
            NumericGuard.ShouldBeNegative(number2, "number2");
            NumericGuard.ShouldBeNegative(number3, "number3");
            NumericGuard.ShouldBeNegative(number4, "number4");
            NumericGuard.ShouldBeNegative(number5, "number5");

            NumericGuard.ShouldBeNegativeOrZero(number1, "number1");
            NumericGuard.ShouldBeNegativeOrZero(number2, "number2");
            NumericGuard.ShouldBeNegativeOrZero(number3, "number3");
            NumericGuard.ShouldBeNegativeOrZero(number4, "number4");
            NumericGuard.ShouldBeNegativeOrZero(number5, "number5");
            
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositive(number1, "number1"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositive(number2, "number2"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositive(number3, "number3"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositive(number4, "number4"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositive(number5, "number5"));
            
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositiveOrZero(number1, "number1"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositiveOrZero(number2, "number2"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositiveOrZero(number3, "number3"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositiveOrZero(number4, "number4"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositiveOrZero(number5, "number5"));

            number1 = 0;
            number2 = 0;
            number3 = 0;
            number4 = 0;
            number5 = 0;

            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegative(number1, "number1"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegative(number2, "number2"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegative(number3, "number3"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegative(number4, "number4"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegative(number5, "number5"));

            NumericGuard.ShouldBeNegativeOrZero(number1, "number1");
            NumericGuard.ShouldBeNegativeOrZero(number2, "number2");
            NumericGuard.ShouldBeNegativeOrZero(number3, "number3");
            NumericGuard.ShouldBeNegativeOrZero(number4, "number4");
            NumericGuard.ShouldBeNegativeOrZero(number5, "number5");
            
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositive(number1, "number1"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositive(number2, "number2"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositive(number3, "number3"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositive(number4, "number4"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositive(number5, "number5"));
            
            NumericGuard.ShouldBePositiveOrZero(number1, "number1");
            NumericGuard.ShouldBePositiveOrZero(number2, "number2");
            NumericGuard.ShouldBePositiveOrZero(number3, "number3");
            NumericGuard.ShouldBePositiveOrZero(number4, "number4");
            NumericGuard.ShouldBePositiveOrZero(number5, "number5");
            
            int? number11 = -1;
            long? number21 = -1L;
            float? number31 = -1.1F;
            double? number41 = -1.1D;
            decimal? number51 = -1;

            NumericGuard.ShouldBeNegative(number11, "number11");
            NumericGuard.ShouldBeNegative(number21, "number21");
            NumericGuard.ShouldBeNegative(number31, "number31");
            NumericGuard.ShouldBeNegative(number41, "number41");
            NumericGuard.ShouldBeNegative(number51, "number51");

            NumericGuard.ShouldBeNegativeOrZero(number11, "number11");
            NumericGuard.ShouldBeNegativeOrZero(number21, "number21");
            NumericGuard.ShouldBeNegativeOrZero(number31, "number31");
            NumericGuard.ShouldBeNegativeOrZero(number41, "number41");
            NumericGuard.ShouldBeNegativeOrZero(number51, "number51");
            
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositive(number11, "number11"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositive(number21, "number21"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositive(number31, "number31"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositive(number41, "number41"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositive(number51, "number51"));
            
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositiveOrZero(number11, "number11"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositiveOrZero(number21, "number21"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositiveOrZero(number31, "number31"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositiveOrZero(number41, "number41"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositiveOrZero(number51, "number51"));

            number11 = 0;
            number21 = 0;
            number31 = 0;
            number41 = 0;
            number51 = 0;

            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegative(number11, "number11"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegative(number21, "number21"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegative(number31, "number31"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegative(number41, "number41"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegative(number51, "number51"));

            NumericGuard.ShouldBeNegativeOrZero(number11, "number11");
            NumericGuard.ShouldBeNegativeOrZero(number21, "number21");
            NumericGuard.ShouldBeNegativeOrZero(number31, "number31");
            NumericGuard.ShouldBeNegativeOrZero(number41, "number41");
            NumericGuard.ShouldBeNegativeOrZero(number51, "number51");
            
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositive(number11, "number11"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositive(number21, "number21"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositive(number31, "number31"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositive(number41, "number41"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositive(number51, "number51"));
            
            NumericGuard.ShouldBePositiveOrZero(number11, "number11");
            NumericGuard.ShouldBePositiveOrZero(number21, "number21");
            NumericGuard.ShouldBePositiveOrZero(number31, "number31");
            NumericGuard.ShouldBePositiveOrZero(number41, "number41");
            NumericGuard.ShouldBePositiveOrZero(number51, "number51");
            
            number11 = null;
            number21 = null;
            number31 = null;
            number41 = null;
            number51 = null;

            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegative(number11, "number11"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegative(number21, "number21"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegative(number31, "number31"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegative(number41, "number41"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegative(number51, "number51"));

            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegativeOrZero(number11, "number11"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegativeOrZero(number21, "number21"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegativeOrZero(number31, "number31"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegativeOrZero(number41, "number41"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBeNegativeOrZero(number51, "number51"));

            NumericGuard.ShouldBeNegativeOrZero(number11, "number11", options: NumericMayOptions.IgnoreNullable);
            NumericGuard.ShouldBeNegativeOrZero(number21, "number21", options: NumericMayOptions.IgnoreNullable);
            NumericGuard.ShouldBeNegativeOrZero(number31, "number31", options: NumericMayOptions.IgnoreNullable);
            NumericGuard.ShouldBeNegativeOrZero(number41, "number41", options: NumericMayOptions.IgnoreNullable);
            NumericGuard.ShouldBeNegativeOrZero(number51, "number51", options: NumericMayOptions.IgnoreNullable);
            
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositive(number11, "number11"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositive(number21, "number21"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositive(number31, "number31"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositive(number41, "number41"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositive(number51, "number51"));
            
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositiveOrZero(number11, "number11"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositiveOrZero(number21, "number21"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositiveOrZero(number31, "number31"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositiveOrZero(number41, "number41"));
            Assert.Throws<ValidationException>(() => NumericGuard.ShouldBePositiveOrZero(number51, "number51"));
        }
    }
}