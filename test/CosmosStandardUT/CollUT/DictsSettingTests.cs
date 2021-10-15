using System.Collections.Generic;
using CosmosStack.Collections;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.CollUT
{
    [Trait("CollUT", "DictUT.Set")]
    public class DictsSettingTests
    {
        [Fact(DisplayName = "Set value to a dictionary with key not exists test")]
        public void SetValueWithKeyNotExistsTest()
        {
            var dictionary = new Dictionary<int, int>();

            Dicts.SetValue(dictionary, 1, 100);

            dictionary.Count.ShouldBe(1);
            dictionary[1].ShouldBe(100);
        }

        [Fact(DisplayName = "Set value to a dictionary with key exists test")]
        public void SetValueWithKeyExistsTest()
        {
            var dictionary = new Dictionary<int, int> {{1, 1}};

            Dicts.SetValue(dictionary, 1, 100);

            dictionary.Count.ShouldBe(1);
            dictionary[1].ShouldBe(100);
        }

        [Fact(DisplayName = "Extension method for Set value to a dictionary with key not exists test")]
        public void ExtensionMethodForSetValueWithKeyNotExistsTest()
        {
            var dictionary = new Dictionary<int, int>();

            dictionary.SetValue(1, 100);

            dictionary.Count.ShouldBe(1);
            dictionary[1].ShouldBe(100);
        }

        [Fact(DisplayName = "Extension method for Set value to a dictionary with key exists test")]
        public void ExtensionMethodForSetValueWithKeyExistsTest()
        {
            var dictionary = new Dictionary<int, int> {{1, 1}};

            dictionary.SetValue(1, 100);

            dictionary.Count.ShouldBe(1);
            dictionary[1].ShouldBe(100);
        }
    }
}