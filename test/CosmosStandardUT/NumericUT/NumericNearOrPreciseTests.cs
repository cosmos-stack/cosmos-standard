using Cosmos.Numeric;

namespace CosmosStandardUT.NumericUT
{
    [Trait("NumericUT","Numeric.NearOrPreciseEqual")]
    public class NumericNearOrPreciseTests
    {
        [Fact(DisplayName = "Numeric is zero value test")]
        public void IsZeroValueTest()
        {
            Numbers.IsZeroValue(0f).ShouldBeTrue();
            Numbers.IsZeroValue(+0f).ShouldBeTrue();
            Numbers.IsZeroValue(-0f).ShouldBeTrue();
            Numbers.IsZeroValue(0.1f).ShouldBeFalse();
            Numbers.IsZeroValue(0.01f).ShouldBeFalse();
            Numbers.IsZeroValue(0.001f).ShouldBeFalse();
            Numbers.IsZeroValue(0.0001f).ShouldBeFalse();
            Numbers.IsZeroValue(0.00001f).ShouldBeFalse();
            Numbers.IsZeroValue(0.000001f).ShouldBeFalse();
            Numbers.IsZeroValue(0.0000001f).ShouldBeFalse();
            Numbers.IsZeroValue(12f).ShouldBeFalse();
            
            
            Numbers.IsZeroValue(0d).ShouldBeTrue();
            Numbers.IsZeroValue(+0d).ShouldBeTrue();
            Numbers.IsZeroValue(-0d).ShouldBeTrue();
            Numbers.IsZeroValue(0.1d).ShouldBeFalse();
            Numbers.IsZeroValue(0.01d).ShouldBeFalse();
            Numbers.IsZeroValue(0.001d).ShouldBeFalse();
            Numbers.IsZeroValue(0.0001d).ShouldBeFalse();
            Numbers.IsZeroValue(0.00001d).ShouldBeFalse();
            Numbers.IsZeroValue(0.000001d).ShouldBeFalse();
            Numbers.IsZeroValue(0.0000001d).ShouldBeFalse();
            Numbers.IsZeroValue(12d).ShouldBeFalse();
        }

        [Fact(DisplayName = "Numeric is near zero value test")]
        public void IsNearZeroValueTest()
        {
            Numbers.IsNearZeroValue(0f).ShouldBeTrue();
            Numbers.IsNearZeroValue(+0f).ShouldBeTrue();
            Numbers.IsNearZeroValue(-0f).ShouldBeTrue();
            Numbers.IsNearZeroValue(0.1f).ShouldBeFalse();
            Numbers.IsNearZeroValue(0.01f).ShouldBeFalse();
            Numbers.IsNearZeroValue(0.001f).ShouldBeFalse(); //default precision is 0.001
            Numbers.IsNearZeroValue(0.0001f).ShouldBeTrue();
            Numbers.IsNearZeroValue(0.00001f).ShouldBeTrue();
            Numbers.IsNearZeroValue(0.000001f).ShouldBeTrue();
            Numbers.IsNearZeroValue(0.0000001f).ShouldBeTrue();
            Numbers.IsNearZeroValue(12f).ShouldBeFalse();
            
            
            Numbers.IsNearZeroValue(0d).ShouldBeTrue();
            Numbers.IsNearZeroValue(+0d).ShouldBeTrue();
            Numbers.IsNearZeroValue(-0d).ShouldBeTrue();
            Numbers.IsNearZeroValue(0.1d).ShouldBeFalse();
            Numbers.IsNearZeroValue(0.01d).ShouldBeFalse();
            Numbers.IsNearZeroValue(0.001d).ShouldBeFalse(); //default precision is 0.001
            Numbers.IsNearZeroValue(0.0001d).ShouldBeTrue();
            Numbers.IsNearZeroValue(0.00001d).ShouldBeTrue();
            Numbers.IsNearZeroValue(0.000001d).ShouldBeTrue();
            Numbers.IsNearZeroValue(0.0000001d).ShouldBeTrue();
            Numbers.IsNearZeroValue(12d).ShouldBeFalse();
        }

        [Fact(DisplayName = "Numeric is near equals test")]
        public void IsNearEqualTest()
        {
            Numbers.IsNearEqual(1f, 1f, 0).ShouldBeTrue();
            Numbers.IsNearEqual(1f, 1.1f, 0.1).ShouldBeFalse();
            Numbers.IsNearEqual(1f, 1.01f, 0.1).ShouldBeTrue();
            Numbers.IsNearEqual(1f, 1.1f, 1).ShouldBeTrue();
            Numbers.IsNearEqual(1f, 1.1f, 0.001).ShouldBeFalse();
            Numbers.IsNearEqual(1f, 1.01f, 0.001).ShouldBeFalse();
            Numbers.IsNearEqual(1f, 1.001f, 0.001).ShouldBeFalse();
            Numbers.IsNearEqual(1f, 1.0001f, 0.001).ShouldBeTrue();
            Numbers.IsNearEqual(0.00001f, -0.00001f, 0.001).ShouldBeTrue();
            
            Numbers.IsNearEqual(1D, 1D, 0).ShouldBeTrue();
            Numbers.IsNearEqual(1D, 1.1D, 0.1).ShouldBeFalse();
            Numbers.IsNearEqual(1D, 1.01D, 0.1).ShouldBeTrue();
            Numbers.IsNearEqual(1D, 1.1D, 1).ShouldBeTrue();
            Numbers.IsNearEqual(1D, 1.1D, 0.001).ShouldBeFalse();
            Numbers.IsNearEqual(1D, 1.01D, 0.001).ShouldBeFalse();
            Numbers.IsNearEqual(1D, 1.001D, 0.001).ShouldBeTrue();
            Numbers.IsNearEqual(1D, 1.0001D, 0.001).ShouldBeTrue();
            Numbers.IsNearEqual(0.00001D, -0.00001D, 0.001).ShouldBeTrue();
            
            Numbers.IsNearEqual((decimal)1, (decimal)1, 0).ShouldBeTrue();
        }

        [Fact(DisplayName = "Numeric is relative near equals test")]
        public void IsRelativeNearEqualTest()
        {
            Numbers.IsRelativeNearEqual(1, 1, 0).ShouldBeTrue();
            Numbers.IsRelativeNearEqual(1, 1.1, 0).ShouldBeTrue();
            Numbers.IsRelativeNearEqual(1, 1.01, 0).ShouldBeTrue();
            Numbers.IsRelativeNearEqual(1, 1.11, 0).ShouldBeTrue();
            
            Numbers.IsRelativeNearEqual(1, 1, 1).ShouldBeTrue();
            Numbers.IsRelativeNearEqual(1, 1.1, 1).ShouldBeTrue();
            Numbers.IsRelativeNearEqual(1, 1.01, 1).ShouldBeTrue();
            Numbers.IsRelativeNearEqual(1, 1.11, 1).ShouldBeTrue();
            
            Numbers.IsRelativeNearEqual(1, 1, 2).ShouldBeTrue();
            Numbers.IsRelativeNearEqual(1, 1.01, 2).ShouldBeTrue();
            Numbers.IsRelativeNearEqual(1, 1.11, 2).ShouldBeTrue();
            Numbers.IsRelativeNearEqual(1, 1.111, 2).ShouldBeTrue();
            
            Numbers.IsRelativeNearEqual(1, 2, 0).ShouldBeFalse();
            Numbers.IsRelativeNearEqual(1, 2, 1).ShouldBeFalse();
            
            Numbers.IsRelativeNearEqual(89.9987, 90.0001, 3).ShouldBeFalse();
            Numbers.IsRelativeNearEqual(89.9987, 90.8989, 3).ShouldBeFalse();
            Numbers.IsRelativeNearEqual(89.9987, 89.9989, 3).ShouldBeTrue();
            
            Numbers.IsRelativeNearEqual(-89.9987, 90.0001, 3).ShouldBeFalse();
            Numbers.IsRelativeNearEqual(-89.9987, 90.8989, 3).ShouldBeFalse();
            Numbers.IsRelativeNearEqual(-89.9987, 89.9989, 3).ShouldBeFalse();
            
            Numbers.IsRelativeNearEqual(-89.9987, -90.0001, 3).ShouldBeFalse();
            Numbers.IsRelativeNearEqual(-89.9987, -90.8989, 3).ShouldBeFalse();
            Numbers.IsRelativeNearEqual(-89.9987, -89.9989, 3).ShouldBeTrue();
            
            Numbers.IsRelativeNearEqual(89.9987, 90.0001, 4).ShouldBeFalse();
            Numbers.IsRelativeNearEqual(89.9987, 90.8989, 4).ShouldBeFalse();
            Numbers.IsRelativeNearEqual(89.9987, 89.9989, 4).ShouldBeFalse();
            Numbers.IsRelativeNearEqual(89.9987, 89.99871, 4).ShouldBeTrue();
            Numbers.IsRelativeNearEqual(89.99871, 89.99871, 4).ShouldBeTrue();
            Numbers.IsRelativeNearEqual(89.998712, 89.998712, 4).ShouldBeTrue();
            
            Numbers.IsRelativeNearEqual(-89.9987, 90.0001, 4).ShouldBeFalse();
            Numbers.IsRelativeNearEqual(-89.9987, 90.8989, 4).ShouldBeFalse();
            Numbers.IsRelativeNearEqual(-89.9987, 89.9989, 4).ShouldBeFalse();
            Numbers.IsRelativeNearEqual(-89.9987, 89.99871, 4).ShouldBeFalse();
            Numbers.IsRelativeNearEqual(-89.99871, 89.99871, 4).ShouldBeFalse();
            Numbers.IsRelativeNearEqual(-89.998712, 89.998712, 4).ShouldBeFalse();
            
            Numbers.IsRelativeNearEqual(-89.9987, -90.0001, 4).ShouldBeFalse();
            Numbers.IsRelativeNearEqual(-89.9987, -90.8989, 4).ShouldBeFalse();
            Numbers.IsRelativeNearEqual(-89.9987, -89.9989, 4).ShouldBeFalse();
            Numbers.IsRelativeNearEqual(-89.9987, -89.99871, 4).ShouldBeTrue();
            Numbers.IsRelativeNearEqual(-89.99871, -89.99871, 4).ShouldBeTrue();
            Numbers.IsRelativeNearEqual(-89.998712, -89.998712, 4).ShouldBeTrue();
        }

        [Fact(DisplayName = "Numeric is precise near equals test")]
        public void IsPreciseEqualTest()
        {
            Numbers.IsPreciseEqual(1f,1f).ShouldBeTrue();//0
            Numbers.IsPreciseEqual(1f,1.1f).ShouldBeFalse();//1
            Numbers.IsPreciseEqual(1f,1.01f).ShouldBeFalse();//2
            Numbers.IsPreciseEqual(1f,1.001f).ShouldBeFalse();//3
            Numbers.IsPreciseEqual(1f,1.0001f).ShouldBeFalse();//4
            Numbers.IsPreciseEqual(1f,1.00001f).ShouldBeFalse();//5
            Numbers.IsPreciseEqual(1f,1.000001f).ShouldBeFalse();//6
            Numbers.IsPreciseEqual(1f,1.0000001f).ShouldBeFalse();//7
            Numbers.IsPreciseEqual(1f,1.00000001f).ShouldBeTrue();//8
            Numbers.IsPreciseEqual(1f,1.000000001f).ShouldBeTrue();//9
            Numbers.IsPreciseEqual(1f,1.0000000001f).ShouldBeTrue();//10
            Numbers.IsPreciseEqual(1f,1.00000000001f).ShouldBeTrue();//11
            Numbers.IsPreciseEqual(1f,1.000000000001f).ShouldBeTrue();//12
            Numbers.IsPreciseEqual(1f,1.0000000000001f).ShouldBeTrue();//13
            
            Numbers.IsPreciseEqual(1f,1f,true).ShouldBeTrue();//0
            Numbers.IsPreciseEqual(1f,1.1f,true).ShouldBeFalse();//1
            Numbers.IsPreciseEqual(1f,1.01f,true).ShouldBeFalse();//2
            Numbers.IsPreciseEqual(1f,1.001f,true).ShouldBeFalse();//3
            Numbers.IsPreciseEqual(1f,1.0001f,true).ShouldBeFalse();//4
            Numbers.IsPreciseEqual(1f,1.00001f,true).ShouldBeFalse();//5
            Numbers.IsPreciseEqual(1f,1.000001f,true).ShouldBeFalse();//6
            Numbers.IsPreciseEqual(1f,1.0000001f,true).ShouldBeTrue();//7
            Numbers.IsPreciseEqual(1f,1.00000001f,true).ShouldBeTrue();//8
            Numbers.IsPreciseEqual(1f,1.000000001f,true).ShouldBeTrue();//9
            Numbers.IsPreciseEqual(1f,1.0000000001f,true).ShouldBeTrue();//10
            Numbers.IsPreciseEqual(1f,1.00000000001f,true).ShouldBeTrue();//11
            Numbers.IsPreciseEqual(1f,1.000000000001f,true).ShouldBeTrue();//12
            Numbers.IsPreciseEqual(1f,1.0000000000001f,true).ShouldBeTrue();//13
            
            Numbers.IsPreciseEqual((float?)1f,(float?)1f).ShouldBeTrue();//0
            Numbers.IsPreciseEqual((float?)1f,(float?)1.1f).ShouldBeFalse();//1
            Numbers.IsPreciseEqual((float?)1f,(float?)1.01f).ShouldBeFalse();//2
            Numbers.IsPreciseEqual((float?)1f,(float?)1.001f).ShouldBeFalse();//3
            Numbers.IsPreciseEqual((float?)1f,(float?)1.0001f).ShouldBeFalse();//4
            Numbers.IsPreciseEqual((float?)1f,(float?)1.00001f).ShouldBeFalse();//5
            Numbers.IsPreciseEqual((float?)1f,(float?)1.000001f).ShouldBeFalse();//6
            Numbers.IsPreciseEqual((float?)1f,(float?)1.0000001f).ShouldBeFalse();//7
            Numbers.IsPreciseEqual((float?)1f,(float?)1.00000001f).ShouldBeTrue();//8
            Numbers.IsPreciseEqual((float?)1f,(float?)1.000000001f).ShouldBeTrue();//9
            Numbers.IsPreciseEqual((float?)1f,(float?)1.0000000001f).ShouldBeTrue();//10
            Numbers.IsPreciseEqual((float?)1f,(float?)1.00000000001f).ShouldBeTrue();//11
            Numbers.IsPreciseEqual((float?)1f,(float?)1.000000000001f).ShouldBeTrue();//12
            Numbers.IsPreciseEqual((float?)1f,(float?)1.0000000000001f).ShouldBeTrue();//13
            
            Numbers.IsPreciseEqual((float?)1f,(float?)1f,true).ShouldBeTrue();//0
            Numbers.IsPreciseEqual((float?)1f,(float?)1.1f,true).ShouldBeFalse();//1
            Numbers.IsPreciseEqual((float?)1f,(float?)1.01f,true).ShouldBeFalse();//2
            Numbers.IsPreciseEqual((float?)1f,(float?)1.001f,true).ShouldBeFalse();//3
            Numbers.IsPreciseEqual((float?)1f,(float?)1.0001f,true).ShouldBeFalse();//4
            Numbers.IsPreciseEqual((float?)1f,(float?)1.00001f,true).ShouldBeFalse();//5
            Numbers.IsPreciseEqual((float?)1f,(float?)1.000001f,true).ShouldBeFalse();//6
            Numbers.IsPreciseEqual((float?)1f,(float?)1.0000001f,true).ShouldBeTrue();//7
            Numbers.IsPreciseEqual((float?)1f,(float?)1.00000001f,true).ShouldBeTrue();//8
            Numbers.IsPreciseEqual((float?)1f,(float?)1.000000001f,true).ShouldBeTrue();//9
            Numbers.IsPreciseEqual((float?)1f,(float?)1.0000000001f,true).ShouldBeTrue();//10
            Numbers.IsPreciseEqual((float?)1f,(float?)1.00000000001f,true).ShouldBeTrue();//11
            Numbers.IsPreciseEqual((float?)1f,(float?)1.000000000001f,true).ShouldBeTrue();//12
            Numbers.IsPreciseEqual((float?)1f,(float?)1.0000000000001f,true).ShouldBeTrue();//13
            
            Numbers.IsPreciseEqual(1D,1D).ShouldBeTrue();//0
            Numbers.IsPreciseEqual(1D,1.1D).ShouldBeFalse();//1
            Numbers.IsPreciseEqual(1D,1.01D).ShouldBeFalse();//2
            Numbers.IsPreciseEqual(1D,1.001D).ShouldBeFalse();//3
            Numbers.IsPreciseEqual(1D,1.0001D).ShouldBeFalse();//4
            Numbers.IsPreciseEqual(1D,1.00001D).ShouldBeFalse();//5
            Numbers.IsPreciseEqual(1D,1.000001D).ShouldBeFalse();//6
            Numbers.IsPreciseEqual(1D,1.0000001D).ShouldBeFalse();//7
            Numbers.IsPreciseEqual(1D,1.00000001D).ShouldBeFalse();//8
            Numbers.IsPreciseEqual(1D,1.000000001D).ShouldBeFalse();//9
            Numbers.IsPreciseEqual(1D,1.0000000001D).ShouldBeFalse();//10
            Numbers.IsPreciseEqual(1D,1.00000000001D).ShouldBeFalse();//11
            Numbers.IsPreciseEqual(1D,1.000000000001D).ShouldBeFalse();//12
            Numbers.IsPreciseEqual(1D,1.0000000000001D).ShouldBeFalse();//13
            Numbers.IsPreciseEqual(1D,1.00000000000001D).ShouldBeFalse();//14
            Numbers.IsPreciseEqual(1D,1.000000000000001D).ShouldBeFalse();//15
            Numbers.IsPreciseEqual(1D,1.0000000000000001D).ShouldBeTrue();//16
            Numbers.IsPreciseEqual(1D,1.00000000000000001D).ShouldBeTrue();//17
            Numbers.IsPreciseEqual(1D,1.000000000000000001D).ShouldBeTrue();//18
            Numbers.IsPreciseEqual(1D,1.0000000000000000001D).ShouldBeTrue();//19
            
            Numbers.IsPreciseEqual(1D,1D,true).ShouldBeTrue();//0
            Numbers.IsPreciseEqual(1D,1.1D,true).ShouldBeFalse();//1
            Numbers.IsPreciseEqual(1D,1.01D,true).ShouldBeFalse();//2
            Numbers.IsPreciseEqual(1D,1.001D,true).ShouldBeFalse();//3
            Numbers.IsPreciseEqual(1D,1.0001D,true).ShouldBeFalse();//4
            Numbers.IsPreciseEqual(1D,1.00001D,true).ShouldBeFalse();//5
            Numbers.IsPreciseEqual(1D,1.000001D,true).ShouldBeFalse();//6
            Numbers.IsPreciseEqual(1D,1.0000001D,true).ShouldBeFalse();//7
            Numbers.IsPreciseEqual(1D,1.00000001D,true).ShouldBeFalse();//8
            Numbers.IsPreciseEqual(1D,1.000000001D,true).ShouldBeFalse();//9
            Numbers.IsPreciseEqual(1D,1.0000000001D,true).ShouldBeFalse();//10
            Numbers.IsPreciseEqual(1D,1.00000000001D,true).ShouldBeFalse();//11
            Numbers.IsPreciseEqual(1D,1.000000000001D,true).ShouldBeFalse();//12
            Numbers.IsPreciseEqual(1D,1.0000000000001D,true).ShouldBeFalse();//13
            Numbers.IsPreciseEqual(1D,1.00000000000001D,true).ShouldBeFalse();//14
            Numbers.IsPreciseEqual(1D,1.000000000000001D,true).ShouldBeTrue();//15
            Numbers.IsPreciseEqual(1D,1.0000000000000001D,true).ShouldBeTrue();//16
            Numbers.IsPreciseEqual(1D,1.00000000000000001D,true).ShouldBeTrue();//17
            Numbers.IsPreciseEqual(1D,1.000000000000000001D,true).ShouldBeTrue();//18
            Numbers.IsPreciseEqual(1D,1.0000000000000000001D,true).ShouldBeTrue();//19
            
            Numbers.IsPreciseEqual((double?)1D,(double?)1D).ShouldBeTrue();//0
            Numbers.IsPreciseEqual((double?)1D,(double?)1.1D).ShouldBeFalse();//1
            Numbers.IsPreciseEqual((double?)1D,(double?)1.01D).ShouldBeFalse();//2
            Numbers.IsPreciseEqual((double?)1D,(double?)1.001D).ShouldBeFalse();//3
            Numbers.IsPreciseEqual((double?)1D,(double?)1.0001D).ShouldBeFalse();//4
            Numbers.IsPreciseEqual((double?)1D,(double?)1.00001D).ShouldBeFalse();//5
            Numbers.IsPreciseEqual((double?)1D,(double?)1.000001D).ShouldBeFalse();//6
            Numbers.IsPreciseEqual((double?)1D,(double?)1.0000001D).ShouldBeFalse();//7
            Numbers.IsPreciseEqual((double?)1D,(double?)1.00000001D).ShouldBeFalse();//8
            Numbers.IsPreciseEqual((double?)1D,(double?)1.000000001D).ShouldBeFalse();//9
            Numbers.IsPreciseEqual((double?)1D,(double?)1.0000000001D).ShouldBeFalse();//10
            Numbers.IsPreciseEqual((double?)1D,(double?)1.00000000001D).ShouldBeFalse();//11
            Numbers.IsPreciseEqual((double?)1D,(double?)1.000000000001D).ShouldBeFalse();//12
            Numbers.IsPreciseEqual((double?)1D,(double?)1.0000000000001D).ShouldBeFalse();//13
            Numbers.IsPreciseEqual((double?)1D,(double?)1.00000000000001D).ShouldBeFalse();//14
            Numbers.IsPreciseEqual((double?)1D,(double?)1.000000000000001D).ShouldBeFalse();//15
            Numbers.IsPreciseEqual((double?)1D,(double?)1.0000000000000001D).ShouldBeTrue();//16
            Numbers.IsPreciseEqual((double?)1D,(double?)1.00000000000000001D).ShouldBeTrue();//17
            Numbers.IsPreciseEqual((double?)1D,(double?)1.000000000000000001D).ShouldBeTrue();//18
            Numbers.IsPreciseEqual((double?)1D,(double?)1.0000000000000000001D).ShouldBeTrue();//19
            
            Numbers.IsPreciseEqual((double?)1D,(double?)1D,true).ShouldBeTrue();//0
            Numbers.IsPreciseEqual((double?)1D,(double?)1.1D,true).ShouldBeFalse();//1
            Numbers.IsPreciseEqual((double?)1D,(double?)1.01D,true).ShouldBeFalse();//2
            Numbers.IsPreciseEqual((double?)1D,(double?)1.001D,true).ShouldBeFalse();//3
            Numbers.IsPreciseEqual((double?)1D,(double?)1.0001D,true).ShouldBeFalse();//4
            Numbers.IsPreciseEqual((double?)1D,(double?)1.00001D,true).ShouldBeFalse();//5
            Numbers.IsPreciseEqual((double?)1D,(double?)1.000001D,true).ShouldBeFalse();//6
            Numbers.IsPreciseEqual((double?)1D,(double?)1.0000001D,true).ShouldBeFalse();//7
            Numbers.IsPreciseEqual((double?)1D,(double?)1.00000001D,true).ShouldBeFalse();//8
            Numbers.IsPreciseEqual((double?)1D,(double?)1.000000001D,true).ShouldBeFalse();//9
            Numbers.IsPreciseEqual((double?)1D,(double?)1.0000000001D,true).ShouldBeFalse();//10
            Numbers.IsPreciseEqual((double?)1D,(double?)1.00000000001D,true).ShouldBeFalse();//11
            Numbers.IsPreciseEqual((double?)1D,(double?)1.000000000001D,true).ShouldBeFalse();//12
            Numbers.IsPreciseEqual((double?)1D,(double?)1.0000000000001D,true).ShouldBeFalse();//13
            Numbers.IsPreciseEqual((double?)1D,(double?)1.00000000000001D,true).ShouldBeFalse();//14
            Numbers.IsPreciseEqual((double?)1D,(double?)1.000000000000001D,true).ShouldBeTrue();//15
            Numbers.IsPreciseEqual((double?)1D,(double?)1.0000000000000001D,true).ShouldBeTrue();//16
            Numbers.IsPreciseEqual((double?)1D,(double?)1.00000000000000001D,true).ShouldBeTrue();//17
            Numbers.IsPreciseEqual((double?)1D,(double?)1.000000000000000001D,true).ShouldBeTrue();//18
            Numbers.IsPreciseEqual((double?)1D,(double?)1.0000000000000000001D,true).ShouldBeTrue();//19
        }
    }
}