using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CosmosStack.Collections;
using Shouldly;
using Xunit;

namespace CosmosStandardUT.ConvUT
{
    [Trait("ConvUT", "Dict")]
    public class DictConvTests
    {
        [Fact(DisplayName = "Dictionary Cast test")]
        public void CastOneDictToAnotherTest()
        {
            // from int-int to string-long
            var source = new Dictionary<int, int> {{1, 1}, {2, 2}, {3, 3}}.AsReadOnlyDictionary();
            var target = DictConv.Cast<int, int, int, dynamic>(source);

            target.ShouldNotBeNull();
            target.Count.ShouldBe(3);
        }

        [Fact(DisplayName = "Extension method for Dictionary Cast test")]
        public void ExtensionMethodForCastOneDictToAnotherTest()
        {
            // from int-int to string-long
            var source = new Dictionary<int, int> {{1, 1}, {2, 2}, {3, 3}}.AsReadOnlyDictionary();
            var target = source.Cast<int, int, int, dynamic>();

            target.ShouldNotBeNull();
            target.Count.ShouldBe(3);
        }

        [Fact(DisplayName = "Convert HashTable to Dictionary test")]
        public void ConvertHashtableToDictionaryTest()
        {
            var table = new Hashtable();
            table["Name"] = "Alex";
            table["Age"] = "10086";

            var dict = DictConv.ToDictionary<string, string>(table);

            dict.ShouldNotBeNull();
            dict.Count.ShouldBe(2);
        }

        [Fact(DisplayName = "Convert Key-Value pair to Dictionary test")]
        public void ConvertKvpToDictionaryTest()
        {
            var list = new List<KeyValuePair<string, string>>
            {
                new("Name", "Alex"),
                new("Age", "10086")
            };

            var dict = DictConv.ToDictionary(list);

            dict.ShouldNotBeNull();
            dict.Count.ShouldBe(2);
        }

        [Fact(DisplayName = "Convert Key-Value pair to Dictionary with equal comparer test")]
        public void ConvertKvpToDictionaryWithEqualComparerTest()
        {
            var list = new List<KeyValuePair<string, string>>
            {
                new("Name", "Alex"),
                new("Age", "10086")
            };

            var dict = DictConv.ToDictionary(list, EqualityComparer<string>.Default);

            dict.ShouldNotBeNull();
            dict.Count.ShouldBe(2);
        }

        [Fact(DisplayName = "Extension method for Convert HashTable to Dictionary test")]
        public void ExtensionMethodForConvertHashtableToDictionaryTest()
        {
            var table = new Hashtable();
            table["Name"] = "Alex";
            table["Age"] = "10086";

            var dict = table.ToDictionary<string, string>();

            dict.ShouldNotBeNull();
            dict.Count.ShouldBe(2);
        }

        [Fact(DisplayName = "Extension method for Convert Key-Value pair to Dictionary test")]
        public void ExtensionMethodForConvertKvpToDictionaryTest()
        {
            var list = new List<KeyValuePair<string, string>>
            {
                new("Name", "Alex"),
                new("Age", "10086")
            };

            var dict = list.ToDictionary();

            dict.ShouldNotBeNull();
            dict.Count.ShouldBe(2);
        }

        [Fact(DisplayName = "Extension method for Convert Key-Value pair to Dictionary with equal comparer test")]
        public void ExtensionMethodForConvertKvpToDictionaryWithEqualComparerTest()
        {
            var list = new List<KeyValuePair<string, string>>
            {
                new("Name", "Alex"),
                new("Age", "10086")
            };

            var dict = list.ToDictionary(EqualityComparer<string>.Default);

            dict.ShouldNotBeNull();
            dict.Count.ShouldBe(2);
        }

        [Fact(DisplayName = "Convert dictionary to Tuple list test")]
        public void ConvertDictionaryToTupleTest()
        {
            var source = new Dictionary<int, int> {{1, 1}, {2, 2}, {3, 3}};
            var tuple = DictConv.ToTuple(source).ToList();

            tuple.Count.ShouldBe(3);
        }

        [Fact(DisplayName = "Extension method for Convert dictionary to Tuple list test")]
        public void ExtensionMethodForConvertDictionaryToTupleTest()
        {
            var source = new Dictionary<int, int> {{1, 1}, {2, 2}, {3, 3}};
            var tuple = source.ToTuple().ToList();

            tuple.Count.ShouldBe(3);
        }

        [Fact(DisplayName = "Sort array by value test")]
        public void SortedArrayByValueTest()
        {
            var dictionary = new Dictionary<string, int> {{"Alex", 1}, {"Lewis", 2}, {"10086", 3}};

            var val = DictConv.ToSortedArrayByValue(dictionary);

            val.Count.ShouldBe(3);
            val[0].Key.ShouldBe("Alex");
            val[1].Key.ShouldBe("Lewis");
            val[2].Key.ShouldBe("10086");
        }

        [Fact(DisplayName = "Sort array by value desc test")]
        public void SortedArrayByValueDescTest()
        {
            var dictionary = new Dictionary<string, int> {{"Alex", 1}, {"Lewis", 2}, {"10086", 3}};

            var val = DictConv.ToSortedArrayByValue(dictionary, false);

            val.Count.ShouldBe(3);
            val[2].Key.ShouldBe("Alex");
            val[1].Key.ShouldBe("Lewis");
            val[0].Key.ShouldBe("10086");
        }

        [Fact(DisplayName = "Sort array by key test")]
        public void SortArrayByKeyTest()
        {
            var dictionary = new Dictionary<int, string> {{1, "Alex"}, {2, "Lewis"}, {3, "10086"}};

            var val = DictConv.ToSortedArrayByKey(dictionary);

            val.Count.ShouldBe(3);
            val[0].Value.ShouldBe("Alex");
            val[1].Value.ShouldBe("Lewis");
            val[2].Value.ShouldBe("10086");
        }

        [Fact(DisplayName = "Extension method for Sort array by value test")]
        public void ExtensionMethodForSortedArrayByValueTest()
        {
            var dictionary = new Dictionary<string, int> {{"Alex", 1}, {"Lewis", 2}, {"10086", 3}};

            var val = dictionary.ToSortedArrayByValue();

            val.Count.ShouldBe(3);
            val[0].Key.ShouldBe("Alex");
            val[1].Key.ShouldBe("Lewis");
            val[2].Key.ShouldBe("10086");
        }

        [Fact(DisplayName = "Extension method for Sort array by value desc test")]
        public void ExtensionMethodForSortedArrayByValueDescTest()
        {
            var dictionary = new Dictionary<string, int> {{"Alex", 1}, {"Lewis", 2}, {"10086", 3}};

            var val = dictionary.ToSortedArrayByValue(false);

            val.Count.ShouldBe(3);
            val[2].Key.ShouldBe("Alex");
            val[1].Key.ShouldBe("Lewis");
            val[0].Key.ShouldBe("10086");
        }

        [Fact(DisplayName = "Extension method for Sort array by key test")]
        public void ExtensionMethodForSortArrayByKeyTest()
        {
            var dictionary = new Dictionary<int, string> {{1, "Alex"}, {2, "Lewis"}, {3, "10086"}};

            var val = dictionary.ToSortedArrayByKey();

            val.Count.ShouldBe(3);
            val[0].Value.ShouldBe("Alex");
            val[1].Value.ShouldBe("Lewis");
            val[2].Value.ShouldBe("10086");
        }
    }
}