using System;
using CosmosStack.Reflection;
using CosmosStandardUT.Models;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.TypeUT
{
    [Trait("TypeUT", "InterfaceDefined")]
    public class InterfaceDefinedTests
    {
        public Type ModelType = typeof(NormalInterfaceClass<string>);
        public Type InterfaceOne = typeof(IModelOne);
        public Type InterfaceTwo = typeof(IModelTwo);
        public Type InterfaceThree = typeof(IModelThree<string>);
        public Type InterfaceFour = typeof(IModelFour);
        public Type NotInterface = typeof(int);

        [Fact(DisplayName = "Direct Type interface defined test")]
        public void DirectTypeInterfaceDefinedTest()
        {
            TypeReflections.IsInterfaceDefined(ModelType, InterfaceOne).ShouldBeTrue();
            TypeReflections.IsInterfaceDefined(ModelType, InterfaceTwo).ShouldBeTrue();
            TypeReflections.IsInterfaceDefined(ModelType, InterfaceThree).ShouldBeTrue();
            TypeReflections.IsInterfaceDefined(ModelType, InterfaceFour).ShouldBeFalse();
            TypeReflections.IsInterfaceDefined(ModelType, NotInterface).ShouldBeFalse();

            Types.IsInterfaceDefined(ModelType, InterfaceOne).ShouldBeTrue();
            Types.IsInterfaceDefined(ModelType, InterfaceTwo).ShouldBeTrue();
            Types.IsInterfaceDefined(ModelType, InterfaceThree).ShouldBeTrue();
            Types.IsInterfaceDefined(ModelType, InterfaceFour).ShouldBeFalse();
            Types.IsInterfaceDefined(ModelType, NotInterface).ShouldBeFalse();
        }

        [Fact(DisplayName = "Generic Type interface defined test")]
        public void GenericTypeInterfaceDefinedTest()
        {
            TypeReflections.IsInterfaceDefined<IModelOne>(ModelType).ShouldBeTrue();
            TypeReflections.IsInterfaceDefined<IModelTwo>(ModelType).ShouldBeTrue();
            TypeReflections.IsInterfaceDefined<IModelThree<string>>(ModelType).ShouldBeTrue();
            TypeReflections.IsInterfaceDefined<IModelFour>(ModelType).ShouldBeFalse();
            TypeReflections.IsInterfaceDefined<int>(ModelType).ShouldBeFalse();

            Types.IsInterfaceDefined<IModelOne>(ModelType).ShouldBeTrue();
            Types.IsInterfaceDefined<IModelTwo>(ModelType).ShouldBeTrue();
            Types.IsInterfaceDefined<IModelThree<string>>(ModelType).ShouldBeTrue();
            Types.IsInterfaceDefined<IModelFour>(ModelType).ShouldBeFalse();
            Types.IsInterfaceDefined<int>(ModelType).ShouldBeFalse();

            Types.IsInterfaceDefined<NormalInterfaceClass<string>, IModelOne>().ShouldBeTrue();
            Types.IsInterfaceDefined<NormalInterfaceClass<string>, IModelTwo>().ShouldBeTrue();
            Types.IsInterfaceDefined<NormalInterfaceClass<string>, IModelThree<string>>().ShouldBeTrue();
            Types.IsInterfaceDefined<NormalInterfaceClass<string>, IModelFour>().ShouldBeFalse();
            Types.IsInterfaceDefined<NormalInterfaceClass<string>, int>().ShouldBeFalse();
        }

        [Fact(DisplayName = "Direct Type interface defined and ignore generic args test")]
        public void DirectTypeInterfaceDefinedIgnoreGenericArgsTest()
        {
            TypeReflections.IsInterfaceDefined(ModelType, InterfaceThree).ShouldBeTrue();
            TypeReflections.IsInterfaceDefined(ModelType, typeof(IModelThree<>)).ShouldBeFalse();
            TypeReflections.IsInterfaceDefined(ModelType, typeof(IModelThree<>), InterfaceOptions.IgnoreGenericArgs).ShouldBeTrue();
            TypeReflections.IsInterfaceDefined(ModelType, typeof(IModelThree<int>)).ShouldBeFalse();
            TypeReflections.IsInterfaceDefined(ModelType, typeof(IModelThree<int>), InterfaceOptions.IgnoreGenericArgs).ShouldBeTrue();

            Types.IsInterfaceDefined(ModelType, InterfaceThree).ShouldBeTrue();
            Types.IsInterfaceDefined(ModelType, typeof(IModelThree<>)).ShouldBeFalse();
            Types.IsInterfaceDefined(ModelType, typeof(IModelThree<>), InterfaceOptions.IgnoreGenericArgs).ShouldBeTrue();
            Types.IsInterfaceDefined(ModelType, typeof(IModelThree<int>)).ShouldBeFalse();
            Types.IsInterfaceDefined(ModelType, typeof(IModelThree<int>), InterfaceOptions.IgnoreGenericArgs).ShouldBeTrue();
        }

        [Fact(DisplayName = "Generic Type interface defined and ignore generic args test")]
        public void GenericTypeInterfaceDefinedIgnoreGenericArgsTest()
        {
            TypeReflections.IsInterfaceDefined<IModelThree<string>>(ModelType).ShouldBeTrue();
            TypeReflections.IsInterfaceDefined<IModelThree<int>>(ModelType).ShouldBeFalse();
            TypeReflections.IsInterfaceDefined<IModelThree<int>>(ModelType, InterfaceOptions.IgnoreGenericArgs).ShouldBeTrue();

            Types.IsInterfaceDefined<IModelThree<string>>(ModelType).ShouldBeTrue();
            Types.IsInterfaceDefined<IModelThree<int>>(ModelType).ShouldBeFalse();
            Types.IsInterfaceDefined<IModelThree<int>>(ModelType, InterfaceOptions.IgnoreGenericArgs).ShouldBeTrue();

            Types.IsInterfaceDefined<NormalInterfaceClass<string>, IModelThree<string>>().ShouldBeTrue();
            Types.IsInterfaceDefined<NormalInterfaceClass<string>, IModelThree<int>>().ShouldBeFalse();
            Types.IsInterfaceDefined<NormalInterfaceClass<string>, IModelThree<int>>(InterfaceOptions.IgnoreGenericArgs).ShouldBeTrue();
        }

        [Fact(DisplayName = "Object interface defined test")]
        public void ObjectInterfaceDefinedTest()
        {
            var model = new NormalInterfaceClass<string>();
            Types.IsInterfaceDefined<NormalInterfaceClass<string>, IModelOne>(model).ShouldBeTrue();
            Types.IsInterfaceDefined<NormalInterfaceClass<string>, IModelTwo>(model).ShouldBeTrue();
            Types.IsInterfaceDefined<NormalInterfaceClass<string>, IModelThree<string>>(model).ShouldBeTrue();
            Types.IsInterfaceDefined<NormalInterfaceClass<string>, IModelThree<int>>(model).ShouldBeFalse();
            Types.IsInterfaceDefined<NormalInterfaceClass<string>, IModelThree<int>>(model, InterfaceOptions.IgnoreGenericArgs).ShouldBeTrue();
        }
    }
}