using Cosmos.Text;

namespace CosmosStandardUT.StringUT
{
    [Trait("StringUT","Strings.Empty")]
    public class StringEmptyTests
    {
        [Fact(DisplayName = "Avoid string as a null value test")]
        public void AvoidStringAsNullTest()
        {
            string a = "";
            string b = null;
            string c = "a";
            string d = " ";

            Strings.AvoidNull(a).ShouldBe("");
            Strings.AvoidNull(b).ShouldBeEmpty();
            Strings.AvoidNull(c).ShouldBe("a");
            Strings.AvoidNull(d).ShouldBe(" ");
        }

        [Fact(DisplayName = "Null value to empty string test")]
        public void NullToEmptyTest()
        {
            string a = "";
            string b = null;
            string c = "a";
            string d = " ";

            Strings.NullToEmpty(a).ShouldBe("");
            Strings.NullToEmpty(b).ShouldBeEmpty();
            Strings.NullToEmpty(c).ShouldBe("a");
            Strings.NullToEmpty(d).ShouldBe(" ");
        }

        [Fact(DisplayName = "Empty string to null value test")]
        public void EmptyToNullTest()
        {
            string a = "";
            string b = null;
            string c = "a";
            string d = " ";
            
            Strings.EmptyToNull(a).ShouldBeNull();
            Strings.EmptyToNull(b).ShouldBeNull();
            Strings.EmptyToNull(c).ShouldBe("a");
            Strings.EmptyToNull(d).ShouldBe(" ");
        }
    }
}