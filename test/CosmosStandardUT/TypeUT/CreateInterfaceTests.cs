using Cosmos.Reflection;
using CosmosStandardUT.Models;

#if !NETFRAMEWORK
using System.Collections.Generic;
#endif

namespace CosmosStandardUT.TypeUT
{
    [Trait("TypeUT", "TypeVisit.CreateInstance")]
    public class CreateInterfaceTests
#if !NETFRAMEWORK
        : Prepare
#endif
    {
        [Fact(DisplayName = "Direct type create instance without any params test")]
        public void DirectTypeCreateInstanceWithoutParamsTest()
        {
            var instance = TypeVisit.CreateInstance(typeof(NormalWithAttrClass));

            instance.ShouldNotBeNull();
            instance.GetType().ShouldBe(typeof(NormalWithAttrClass));
        }

        [Fact(DisplayName = "Generic type create instance without any params test")]
        public void GenericTypeCreateInstanceWithoutParamsTest()
        {
            var instance = TypeVisit.CreateInstance<NormalWithAttrClass>();

            instance.ShouldNotBeNull();
            instance.GetType().ShouldBe(typeof(NormalWithAttrClass));
        }

        [Fact(DisplayName = "Direct type create instance with one params test")]
        public void DirectTypeCreateInstanceWithOneParamsTest()
        {
            var instance = TypeVisit.CreateInstance(typeof(NormalWithAttrClass), "test");

            instance.ShouldNotBeNull();
            instance.GetType().ShouldBe(typeof(NormalWithAttrClass));
            ((NormalWithAttrClass) instance).Nice.ShouldBe("test");
        }

        [Fact(DisplayName = "Generic type create instance with one params test")]
        public void GenericTypeCreateInstanceWithOneParamsTest()
        {
            var instance = TypeVisit.CreateInstance<NormalWithAttrClass>("test");

            instance.ShouldNotBeNull();
            instance.GetType().ShouldBe(typeof(NormalWithAttrClass));
            instance.Nice.ShouldBe("test");
        }

        [Fact(DisplayName = "Direct type create instance with two params test")]
        public void DirectTypeCreateInstanceWithTwoParamsTest()
        {
            var instance = TypeVisit.CreateInstance(typeof(NormalWithAttrClass), "test", 2);

            instance.ShouldNotBeNull();
            instance.GetType().ShouldBe(typeof(NormalWithAttrClass));
            ((NormalWithAttrClass) instance).Nice.ShouldBe("test");
            ((NormalWithAttrClass) instance).Index.ShouldBe(2);
        }

        [Fact(DisplayName = "Generic type create instance with two params test")]
        public void GenericTypeCreateInstanceWithTwoParamsTest()
        {
            var instance = TypeVisit.CreateInstance<NormalWithAttrClass>("test", 2);

            instance.ShouldNotBeNull();
            instance.GetType().ShouldBe(typeof(NormalWithAttrClass));
            instance.Nice.ShouldBe("test");
            instance.Index.ShouldBe(2);
        }

        [Fact(DisplayName = "Direct type create instance with two params with wrong sort test")]
        public void DirectTypeCreateInstanceWithTwoParamsWithWrongSortTest()
        {
            var instance = TypeVisit.CreateInstance(typeof(NormalWithAttrClass), 2, "test");

            instance.ShouldBeNull();
        }

        [Fact(DisplayName = "Generic type create instance with two params with wrong sort test")]
        public void GenericTypeCreateInstanceWithTwoParamsWithWrongSortTest()
        {
            var instance = TypeVisit.CreateInstance<NormalWithAttrClass>(2, "test");

            instance.ShouldBeNull();
        }

        [Fact(DisplayName = "Direct type create instance with declare generic type test")]
        public void DirectTypeCreateInstanceWithDeclareGenericTypeTest()
        {
            var instance1 = TypeVisit.CreateInstance<NormalWithAttrClass>(typeof(NormalWithAttrClass));
            var instance2 = TypeVisit.CreateInstance<NormalWithAttrClass>(typeof(NormalWithAttrClass), "test");
            var instance3 = TypeVisit.CreateInstance<NormalWithAttrClass>(typeof(NormalWithAttrClass), "test", 2);
            var instance4 = TypeVisit.CreateInstance<NormalWithAttrClass>(typeof(NormalWithAttrClass), 2, "test");

            instance1.ShouldNotBeNull();
            instance2.ShouldNotBeNull();
            instance3.ShouldNotBeNull();
            instance4.ShouldBeNull();
        }

        [Fact(DisplayName = "Extensions method type test")]
        public void ExtensionMethodTest()
        {
            var instance1 = typeof(NormalWithAttrClass).CreateInstance();
            var instance2 = typeof(NormalWithAttrClass).CreateInstance("test");
            var instance3 = typeof(NormalWithAttrClass).CreateInstance("test", 2);
            var instance4 = typeof(NormalWithAttrClass).CreateInstance(2, "test");

            instance1.ShouldNotBeNull();
            instance2.ShouldNotBeNull();
            instance3.ShouldNotBeNull();
            instance4.ShouldBeNull();

            var instance5 = typeof(NormalWithAttrClass).CreateInstance<NormalWithAttrClass>();
            var instance6 = typeof(NormalWithAttrClass).CreateInstance<NormalWithAttrClass>("test");
            var instance7 = typeof(NormalWithAttrClass).CreateInstance<NormalWithAttrClass>("test", 2);
            var instance8 = typeof(NormalWithAttrClass).CreateInstance<NormalWithAttrClass>(2, "test");

            instance5.ShouldNotBeNull();
            instance6.ShouldNotBeNull();
            instance7.ShouldNotBeNull();
            instance8.ShouldBeNull();
        }

#if !NETFRAMEWORK
        [Fact(DisplayName = "Direct type create instance with with dynamic ctor args test")]
        public void DirectTypeCreateInstanceWithDynamicParamsTest()
        {
            var paramsZero = new List<ArgumentDescriptor>();
            var paramsOne = new List<ArgumentDescriptor>
            {
                new("value", "test", typeof(string)),
            };
            var paramsTwo = new List<ArgumentDescriptor>
            {
                new("value", "test", typeof(string)),
                new("index", 1, typeof(int))
            };
            var paramsThree = new List<ArgumentDescriptor>
            {
                new("index", 1, typeof(int)),
                new("value", "test", typeof(string))
            };
            var paramsFour = new List<ArgumentDescriptor>
            {
                new("index", 1, typeof(int))
            };

            var instance0 = TypeVisit.CreateInstance(typeof(NormalWithAttrClass), paramsZero);
            var instance1 = TypeVisit.CreateInstance(typeof(NormalWithAttrClass), paramsOne);
            var instance2 = TypeVisit.CreateInstance(typeof(NormalWithAttrClass), paramsTwo);
            var instance3 = TypeVisit.CreateInstance(typeof(NormalWithAttrClass), paramsThree);
            var instance4 = TypeVisit.CreateInstance(typeof(NormalWithAttrClass), paramsFour);
            
            instance0.ShouldNotBeNull();
            instance1.ShouldNotBeNull();
            instance2.ShouldNotBeNull();
            instance3.ShouldNotBeNull();
            instance4.ShouldNotBeNull();

            ((NormalWithAttrClass) instance0).Nice.ShouldBeNullOrEmpty();
            ((NormalWithAttrClass) instance0).Index.ShouldBe(0);
            
            ((NormalWithAttrClass) instance1).Nice.ShouldBe("test");
            ((NormalWithAttrClass) instance1).Index.ShouldBe(0);

            ((NormalWithAttrClass) instance2).Nice.ShouldBe("test");
            ((NormalWithAttrClass) instance2).Index.ShouldBe(1);
            
            ((NormalWithAttrClass) instance3).Nice.ShouldBe("test");
            ((NormalWithAttrClass) instance3).Index.ShouldBe(1);
            
            ((NormalWithAttrClass) instance4).Nice.ShouldBeNullOrEmpty();
            ((NormalWithAttrClass) instance4).Index.ShouldBe(1);
        }

        [Fact(DisplayName = "Direct type create instance with with wrong dynamic ctor args test")]
        public void DirectTypeCreateInstanceWithWrongDynamicParamsTest()
        {
            var paramsFive = new List<ArgumentDescriptor>
            {
                new("indexZee", 1, typeof(int)),
                new("indexWuu", 'c', typeof(char))
            };
            
            var paramsSix = new List<ArgumentDescriptor>
            {
                new("index", 1, typeof(int)),
                new("index", 2, typeof(int)),
            };
            
            var paramsSeven = new List<ArgumentDescriptor>
            {
                new("index", "1", typeof(string)),
                new("value", 2, typeof(int)),
            };
            
            var instance5 = TypeVisit.CreateInstance(typeof(NormalWithAttrClass), paramsFive);
            var instance6 = TypeVisit.CreateInstance(typeof(NormalWithAttrClass), paramsSix);
            var instance7 = TypeVisit.CreateInstance(typeof(NormalWithAttrClass), paramsSeven);
            
            instance5.ShouldNotBeNull();
            instance6.ShouldNotBeNull();
            instance7.ShouldNotBeNull();

            ((NormalWithAttrClass) instance5).Nice.ShouldBeNullOrEmpty();
            ((NormalWithAttrClass) instance5).Index.ShouldBe(0);

            ((NormalWithAttrClass) instance6).Nice.ShouldBeNullOrEmpty();
            ((NormalWithAttrClass) instance6).Index.ShouldBe(2);

            ((NormalWithAttrClass) instance7).Nice.ShouldBeNullOrEmpty();
            ((NormalWithAttrClass) instance7).Index.ShouldBe(0);
        }
        
#endif
    }
}