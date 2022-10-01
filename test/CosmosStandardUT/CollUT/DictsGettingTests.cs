using System.Collections.Generic;
using Cosmos.Collections;

namespace CosmosStandardUT.CollUT;

[Trait("CollUT", "DictUT.Get")]
public class DictsGettingTests
{
    [Fact(DisplayName = "Get value from dictionary or returns given default value test")]
    public void GetOrDefaultFromDictionaryAndReturnGivenValueTest()
    {
        var dictionary = new Dictionary<int, int> {{1, 2}, {3, 4}, {5, 6}};

        var val1 = Dicts.GetValueOrDefault(dictionary, 1, 100);
        var val2 = Dicts.GetValueOrDefault(dictionary, 7, 8);

        val1.ShouldBe(2);
        val2.ShouldBe(8);
    }

    [Fact(DisplayName = "Get value from dictionary or returns system default value test")]
    public void GetOrDefaultFromDictionaryAndReturnSystemValueTest()
    {
        var dictionary = new Dictionary<int, int> {{1, 2}, {3, 4}, {5, 6}};

        var val1 = Dicts.GetValueOrDefault(dictionary, 1);
        var val2 = Dicts.GetValueOrDefault(dictionary, 7);

        val1.ShouldBe(2);
        val2.ShouldBe(default);
    }

    [Fact(DisplayName = "Get value from dictionary or returns calc value test")]
    public void GetOrDefaultFromDictionaryAndReturnCalcValueTest()
    {
        var dictionary = new Dictionary<int, int> {{1, 2}, {3, 4}, {5, 6}};

        var val1 = Dicts.GetValueOrDefault(dictionary, 1, k => k * 1000);
        var val2 = Dicts.GetValueOrDefault(dictionary, 7, k => k * 1000);

        val1.ShouldBe(2);
        val2.ShouldBe(7000);
    }

    [Fact(DisplayName = "Get value from readonly dictionary or returns given default value test")]
    public void GetOrDefaultFromReadOnlyDictionaryAndReturnGivenValueTest()
    {
        var dictionary = new Dictionary<int, int> {{1, 2}, {3, 4}, {5, 6}}.AsReadOnlyDictionary();

        var val1 = ReadOnlyDicts.GetValueOrDefault(dictionary, 1, 100);
        var val2 = ReadOnlyDicts.GetValueOrDefault(dictionary, 7, 8);

        val1.ShouldBe(2);
        val2.ShouldBe(8);
    }

    [Fact(DisplayName = "Get value from readonly dictionary or returns system default value test")]
    public void GetOrDefaultFromReadOnlyDictionaryAndReturnSystemValueTest()
    {
        var dictionary = new Dictionary<int, int> {{1, 2}, {3, 4}, {5, 6}}.AsReadOnlyDictionary();

        var val1 = ReadOnlyDicts.GetValueOrDefault(dictionary, 1);
        var val2 = ReadOnlyDicts.GetValueOrDefault(dictionary, 7);

        val1.ShouldBe(2);
        val2.ShouldBe(default);
    }

    [Fact(DisplayName = "Get value from readonly dictionary or returns calc value test")]
    public void GetOrDefaultFromReadOnlyDictionaryAndReturnCalcValueTest()
    {
        var dictionary = new Dictionary<int, int> {{1, 2}, {3, 4}, {5, 6}}.AsReadOnlyDictionary();

        var val1 = ReadOnlyDicts.GetValueOrDefault(dictionary, 1, k => k * 1000);
        var val2 = ReadOnlyDicts.GetValueOrDefault(dictionary, 7, k => k * 1000);

        val1.ShouldBe(2);
        val2.ShouldBe(7000);
    }

    [Fact(DisplayName = "Extension method for Get value from dictionary or returns given default value test")]
    public void ExtensionMethodForGetOrDefaultFromDictionaryAndReturnGivenValueTest()
    {
        var dictionary = new Dictionary<int, int> {{1, 2}, {3, 4}, {5, 6}};

        var val1 = dictionary.GetValueOrDefault(1, 100);
        var val2 = dictionary.GetValueOrDefault(7, 8);

        val1.ShouldBe(2);
        val2.ShouldBe(8);
    }

    [Fact(DisplayName = "Extension method for Get value from dictionary or returns system default value test")]
    public void ExtensionMethodForGetOrDefaultFromDictionaryAndReturnSystemValueTest()
    {
        var dictionary = new Dictionary<int, int> {{1, 2}, {3, 4}, {5, 6}};

        var val1 = dictionary.GetValueOrDefault(1);
        var val2 = dictionary.GetValueOrDefault(7);

        val1.ShouldBe(2);
        val2.ShouldBe(default);
    }

    [Fact(DisplayName = "Extension method for Get value from dictionary or returns calc value test")]
    public void ExtensionMethodForGetOrDefaultFromDictionaryAndReturnCalcValueTest()
    {
        var dictionary = new Dictionary<int, int> {{1, 2}, {3, 4}, {5, 6}};

        var val1 = dictionary.GetValueOrDefault(1, k => k * 1000);
        var val2 = dictionary.GetValueOrDefault(7, k => k * 1000);

        val1.ShouldBe(2);
        val2.ShouldBe(7000);
    }

    [Fact(DisplayName = "Get value from dictionary or returns given default value test")]
    public void GetOrDefaultFromDictionaryAndReturnGivenValueCascadingTest()
    {
        var dictionary1 = new Dictionary<int, int> {{1, 2}, {3, 4}};
        var dictionary2 = new Dictionary<int, int> {{5, 6}};
        var list = new List<Dictionary<int, int>> {dictionary1, dictionary2};

        var val1 = Dicts.GetValueOrDefaultCascading(list, 1, 100);
        var val2 = Dicts.GetValueOrDefaultCascading(list, 7, 8);

        val1.ShouldBe(2);
        val2.ShouldBe(8);
    }

    [Fact(DisplayName = "Get value from dictionary or returns system default value test")]
    public void GetOrDefaultFromDictionaryAndReturnSystemValueCascadingTest()
    {
        var dictionary1 = new Dictionary<int, int> {{1, 2}, {3, 4}};
        var dictionary2 = new Dictionary<int, int> {{5, 6}};
        var list = new List<Dictionary<int, int>> {dictionary1, dictionary2};

        var val1 = Dicts.GetValueOrDefaultCascading(list, 1);
        var val2 = Dicts.GetValueOrDefaultCascading(list, 7);

        val1.ShouldBe(2);
        val2.ShouldBe(default);
    }

    [Fact(DisplayName = "Try to Get value from dictionary or returns system default value test")]
    public void TryToGetOrDefaultFromDictionaryAndReturnSystemValueCascadingTest()
    {
        var dictionary1 = new Dictionary<int, int> {{1, 2}, {3, 4}};
        var dictionary2 = new Dictionary<int, int> {{5, 6}};
        var list = new List<Dictionary<int, int>> {dictionary1, dictionary2};

        var b1 = Dicts.TryGetValueCascading(list, 1, out var val1);
        var b2 = Dicts.TryGetValueCascading(list, 7, out var val2);

        b1.ShouldBeTrue();
        b2.ShouldBeFalse();
        val1.ShouldBe(2);
        val2.ShouldBe(default);
    }

    [Fact(DisplayName = "Get value from readonly dictionary or returns given default value test")]
    public void GetOrDefaultFromReadOnlyDictionaryAndReturnGivenValueCascadingTest()
    {
        var dictionary1 = new Dictionary<int, int> {{1, 2}, {3, 4}}.AsReadOnlyDictionary();
        var dictionary2 = new Dictionary<int, int> {{5, 6}}.AsReadOnlyDictionary();
        var list = new List<IReadOnlyDictionary<int, int>> {dictionary1, dictionary2};

        var val1 = ReadOnlyDicts.GetValueOrDefaultCascading(list, 1, 100);
        var val2 = ReadOnlyDicts.GetValueOrDefaultCascading(list, 7, 8);

        val1.ShouldBe(2);
        val2.ShouldBe(8);
    }

    [Fact(DisplayName = "Get value from readonly dictionary or returns system default value test")]
    public void GetOrDefaultFromReadOnlyDictionaryAndReturnSystemValueCascadingTest()
    {
        var dictionary1 = new Dictionary<int, int> {{1, 2}, {3, 4}}.AsReadOnlyDictionary();
        var dictionary2 = new Dictionary<int, int> {{5, 6}}.AsReadOnlyDictionary();
        var list = new List<IReadOnlyDictionary<int, int>> {dictionary1, dictionary2};

        var val1 = ReadOnlyDicts.GetValueOrDefaultCascading(list, 1);
        var val2 = ReadOnlyDicts.GetValueOrDefaultCascading(list, 7);

        val1.ShouldBe(2);
        val2.ShouldBe(default);
    }

    [Fact(DisplayName = "Try to Get value from readonly dictionary or returns system default value test")]
    public void TryToGetOrDefaultFromReadOnlyDictionaryAndReturnSystemValueCascadingTest()
    {
        var dictionary1 = new Dictionary<int, int> {{1, 2}, {3, 4}}.AsReadOnlyDictionary();
        var dictionary2 = new Dictionary<int, int> {{5, 6}}.AsReadOnlyDictionary();
        var list = new List<IReadOnlyDictionary<int, int>> {dictionary1, dictionary2};

        var b1 = ReadOnlyDicts.TryGetValueCascading(list, 1, out var val1);
        var b2 = ReadOnlyDicts.TryGetValueCascading(list, 7, out var val2);

        b1.ShouldBeTrue();
        b2.ShouldBeFalse();
        val1.ShouldBe(2);
        val2.ShouldBe(default);
    }

    [Fact(DisplayName = "Extension method for Get value from dictionary or returns given default value test")]
    public void ExtensionMethodForGetOrDefaultFromDictionaryAndReturnGivenValueCascadingTest()
    {
        var dictionary1 = new Dictionary<int, int> {{1, 2}, {3, 4}};
        var dictionary2 = new Dictionary<int, int> {{5, 6}};
        var list = new List<Dictionary<int, int>> {dictionary1, dictionary2};

        var val1 = list.GetValueOrDefaultCascading(1, 100);
        var val2 = list.GetValueOrDefaultCascading(7, 8);

        val1.ShouldBe(2);
        val2.ShouldBe(8);
    }

    [Fact(DisplayName = "Extension method for Get value from dictionary or returns system default value test")]
    public void ExtensionMethodForGetOrDefaultFromDictionaryAndReturnSystemValueCascadingTest()
    {
        var dictionary1 = new Dictionary<int, int> {{1, 2}, {3, 4}};
        var dictionary2 = new Dictionary<int, int> {{5, 6}};
        var list = new List<Dictionary<int, int>> {dictionary1, dictionary2};

        var val1 = list.GetValueOrDefaultCascading(1);
        var val2 = list.GetValueOrDefaultCascading(7);

        val1.ShouldBe(2);
        val2.ShouldBe(default);
    }

    [Fact(DisplayName = "Extension method for Try to Get value from dictionary or returns system default value test")]
    public void ExtensionMethodForTryToGetOrDefaultFromDictionaryAndReturnSystemValueCascadingTest()
    {
        var dictionary1 = new Dictionary<int, int> {{1, 2}, {3, 4}};
        var dictionary2 = new Dictionary<int, int> {{5, 6}};
        var list = new List<Dictionary<int, int>> {dictionary1, dictionary2};

        var b1 = list.TryGetValueCascading(1, out var val1);
        var b2 = list.TryGetValueCascading(7, out var val2);

        b1.ShouldBeTrue();
        b2.ShouldBeFalse();
        val1.ShouldBe(2);
        val2.ShouldBe(default);
    }

    [Fact(DisplayName = "Get a value from dictionary or add it into dict test")]
    public void GetOrAddTest()
    {
        var dictionary = new Dictionary<int, int> {{1, 2}};

        dictionary.Count.ShouldBe(1);

        var val = Dicts.GetValueOrAdd(dictionary, 2, 3);
        val.ShouldBe(3);
        dictionary.Count.ShouldBe(2);

        var val2 = Dicts.GetValueOrAdd(dictionary, 2, 4);
        val2.ShouldBe(3);
        dictionary.Count.ShouldBe(2);
    }

    [Fact(DisplayName = "Get a value from dictionary or add it into dict with new value factory test")]
    public void GetOrAddWithNewValueFactoryTest()
    {
        var dictionary = new Dictionary<int, int> {{1, 2}};

        dictionary.Count.ShouldBe(1);

        var val = Dicts.GetValueOrAdd(dictionary, 2, k => 3);
        val.ShouldBe(3);
        dictionary.Count.ShouldBe(2);

        var val2 = Dicts.GetValueOrAdd(dictionary, 2, k => 4);
        val2.ShouldBe(3);
        dictionary.Count.ShouldBe(2);
    }

    [Fact(DisplayName = "Get a value from dictionary or create a new instance and add it into dict with new value factory test")]
    public void GetOrAddWithCreatingNewInstanceTest()
    {
        var dictionary = new Dictionary<int, int> {{1, 2}};

        dictionary.Count.ShouldBe(1);

        var val = Dicts.GetValueOrAddNewInstance(dictionary, 2);
        val.ShouldBe(0);
        dictionary.Count.ShouldBe(2);


        var val2 = Dicts.GetValueOrAddNewInstance(dictionary, 2);
        val2.ShouldBe(0);
        dictionary.Count.ShouldBe(2);

        var val3 = Dicts.GetValueOrAddNewInstance(dictionary, 1);
        val3.ShouldBe(2);
        dictionary.Count.ShouldBe(2);
    }

    [Fact(DisplayName = "Extension method for Get a value from dictionary or add it into dict test")]
    public void ExtensionMethodForGetOrAddTest()
    {
        var dictionary = new Dictionary<int, int> {{1, 2}};

        dictionary.Count.ShouldBe(1);

        var val = dictionary.GetValueOrAdd(2, 3);
        val.ShouldBe(3);
        dictionary.Count.ShouldBe(2);

        var val2 = dictionary.GetValueOrAdd(2, 4);
        val2.ShouldBe(3);
        dictionary.Count.ShouldBe(2);
    }

    [Fact(DisplayName = "Extension method for Get a value from dictionary or add it into dict with new value factory test")]
    public void ExtensionMethodForGetOrAddWithNewValueFactoryTest()
    {
        var dictionary = new Dictionary<int, int> {{1, 2}};

        dictionary.Count.ShouldBe(1);

        var val = dictionary.GetValueOrAdd(2, k => 3);
        val.ShouldBe(3);
        dictionary.Count.ShouldBe(2);

        var val2 = dictionary.GetValueOrAdd(2, k => 4);
        val2.ShouldBe(3);
        dictionary.Count.ShouldBe(2);
    }

    [Fact(DisplayName = "Extension method for Get a value from dictionary or create a new instance and add it into dict with new value factory test")]
    public void ExtensionMethodForGetOrAddWithCreatingNewInstanceTest()
    {
        var dictionary = new Dictionary<int, int> {{1, 2}};

        dictionary.Count.ShouldBe(1);

        var val = dictionary.GetValueOrAddNewInstance(2);
        val.ShouldBe(0);
        dictionary.Count.ShouldBe(2);


        var val2 = dictionary.GetValueOrAddNewInstance(2);
        val2.ShouldBe(0);
        dictionary.Count.ShouldBe(2);

        var val3 = dictionary.GetValueOrAddNewInstance(1);
        val3.ShouldBe(2);
        dictionary.Count.ShouldBe(2);
    }
}