using System;
using System.Linq;
using System.Reflection;
using CosmosStack.Reflection;
using CosmosStandardUT.Models;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.TypeUT
{
    [Trait("TypeUT", "TypeReflections.GetDescription")]
    public class DescriptionGettingTests
    {
        public DescriptionGettingTests()
        {
            var members1 = EntryOne.GetMembers();
            var members2 = EntryTwo.GetMembers();
            var members3 = EntryThree.GetMembers();

            PropertyOne = members1.Single(s => s.Name == "PropertyOne") as PropertyInfo;
            PropertyTwo = members2.Single(s => s.Name == "PropertyTwo") as PropertyInfo;
            PropertyThree = members3.Single(s => s.Name == "PropertyThree") as PropertyInfo;

            FieldOne = members1.Single(s => s.Name == "FieldOne") as FieldInfo;
            FieldTwo = members2.Single(s => s.Name == "FieldTwo") as FieldInfo;
            FieldThree = members3.Single(s => s.Name == "FieldThree") as FieldInfo;

            MethodOne = members1.Single(s => s.Name == "MethodOne") as MethodInfo;
            MethodTwo = members2.Single(s => s.Name == "MethodTwo") as MethodInfo;
            MethodThree = members3.Single(s => s.Name == "MethodThree") as MethodInfo;

            ParameterOne = MethodOne!.GetParameters()[0];
            ParameterTwo = MethodTwo!.GetParameters()[0];
            ParameterThree = MethodThree!.GetParameters()[0];
        }

        public Type EntryOne = typeof(NormalDescriptionClass);
        public Type EntryTwo = typeof(NormalDescriptionOrClass);
        public Type EntryThree = typeof(NormalDisplayNameOrClass);
        public Type Wrapper = typeof(NormalDescriptionWrapper);

        public PropertyInfo PropertyOne;
        public PropertyInfo PropertyTwo;
        public PropertyInfo PropertyThree;

        public FieldInfo FieldOne;
        public FieldInfo FieldTwo;
        public FieldInfo FieldThree;

        public MethodInfo MethodOne;
        public MethodInfo MethodTwo;
        public MethodInfo MethodThree;

        public ParameterInfo ParameterOne;
        public ParameterInfo ParameterTwo;
        public ParameterInfo ParameterThree;

        [Fact(DisplayName = "Class-Level getting description test")]
        public void ClassLevelDescriptionGettingTest()
        {
            var desc1 = TypeReflections.GetDescription(EntryOne);
            var desc2 = TypeReflections.GetDescription(EntryTwo);
            var desc3 = TypeReflections.GetDescription(EntryThree);
            var desc4 = TypeReflections.GetDescription(Wrapper);
            var desc5 = TypeReflections.GetDescription(Wrapper, ReflectionOptions.Inherit);

            desc1.ShouldBe("NormalClassOne");
#if NETFRAMEWORK
            desc2.ShouldBe(EntryTwo.Name);
#else
            desc2.ShouldBe("NormalClassDisplayTwo");
#endif
            desc3.ShouldBe("NormalClassThree");
            desc4.ShouldBe(Wrapper.Name);
            desc5.ShouldBe("NormalClassOne");

            desc1 = TypeReflections.GetDescriptionOr(EntryOne, "OrMe");
            desc2 = TypeReflections.GetDescriptionOr(EntryTwo, "OrMe");
            desc3 = TypeReflections.GetDescriptionOr(EntryThree, "OrMe");
            desc4 = TypeReflections.GetDescriptionOr(Wrapper, "OrMe");
            desc5 = TypeReflections.GetDescriptionOr(Wrapper, "OrMe", ReflectionOptions.Inherit);

            desc1.ShouldBe("NormalClassOne");
#if NETFRAMEWORK
            desc2.ShouldBe("OrMe");
#else
            desc2.ShouldBe("NormalClassDisplayTwo");
#endif

            desc3.ShouldBe("NormalClassThree");
            desc4.ShouldBe("OrMe");
            desc5.ShouldBe("NormalClassOne");
        }

        [Fact(DisplayName = "Property-Level getting description test")]
        public void PropertyLevelDescriptionGettingTest()
        {
            var desc1 = TypeReflections.GetDescription(PropertyOne);
            var desc2 = TypeReflections.GetDescription(PropertyTwo);
            var desc3 = TypeReflections.GetDescription(PropertyThree);

            desc1.ShouldBe("PropertyOne");
            desc2.ShouldBe("PropertyDisplayTwo");
            desc3.ShouldBe("PropertyThree");

            desc1 = TypeReflections.GetDescriptionOr(PropertyOne, "OrMe");
            desc2 = TypeReflections.GetDescriptionOr(PropertyTwo, "OrMe");
            desc3 = TypeReflections.GetDescriptionOr(PropertyThree, "OrMe");

            desc1.ShouldBe("PropertyOne");
            desc2.ShouldBe("PropertyDisplayTwo");
            desc3.ShouldBe("PropertyThree");
        }

        [Fact(DisplayName = "Field-Level getting description test")]
        public void FieldLevelDescriptionGettingTest()
        {
            var desc1 = TypeReflections.GetDescription(FieldOne);
            var desc2 = TypeReflections.GetDescription(FieldTwo);
            var desc3 = TypeReflections.GetDescription(FieldThree);

            desc1.ShouldBe("FieldOne");
            desc2.ShouldBe("FieldDisplayTwo");
            desc3.ShouldBe("FieldThree");
            
            desc1 = TypeReflections.GetDescriptionOr(FieldOne, "OrMe");
            desc2 = TypeReflections.GetDescriptionOr(FieldTwo, "OrMe");
            desc3 = TypeReflections.GetDescriptionOr(FieldThree, "OrMe");

            desc1.ShouldBe("FieldOne");
            desc2.ShouldBe("FieldDisplayTwo");
            desc3.ShouldBe("FieldThree");
        }

        [Fact(DisplayName = "Method-Level getting description test")]
        public void MethodLevelDescriptionGettingTest()
        {
            var desc1 = TypeReflections.GetDescription(MethodOne);
            var desc2 = TypeReflections.GetDescription(MethodTwo);
            var desc3 = TypeReflections.GetDescription(MethodThree);

            desc1.ShouldBe("MethodOne");
            desc2.ShouldBe("MethodDisplayTwo");
            desc3.ShouldBe("MethodThree");
            
            desc1 = TypeReflections.GetDescriptionOr(MethodOne, "OrMe");
            desc2 = TypeReflections.GetDescriptionOr(MethodTwo, "OrMe");
            desc3 = TypeReflections.GetDescriptionOr(MethodThree, "OrMe");

            desc1.ShouldBe("MethodOne");
            desc2.ShouldBe("MethodDisplayTwo");
            desc3.ShouldBe("MethodThree");
        }

        [Fact(DisplayName = "Parameter-Level getting description test")]
        public void ParameterLevelDescriptionGettingTest()
        {
            var desc1 = TypeReflections.GetDescription(ParameterOne);
            var desc2 = TypeReflections.GetDescription(ParameterTwo);
            var desc3 = TypeReflections.GetDescription(ParameterThree);

            desc1.ShouldBe("ArgOne");
            desc2.ShouldBe("ParamDesc");
            desc3.ShouldBe("ArgThree");
            
            desc1 = TypeReflections.GetDescriptionOr(ParameterOne, "OrMe");
            desc2 = TypeReflections.GetDescriptionOr(ParameterTwo, "OrMe");
            desc3 = TypeReflections.GetDescriptionOr(ParameterThree, "OrMe");

            desc1.ShouldBe("ArgOne");
            desc2.ShouldBe("ParamDesc");
            desc3.ShouldBe("ArgThree");
        }
    }
}