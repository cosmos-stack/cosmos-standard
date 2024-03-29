﻿using System.Collections.Generic;
using Cosmos.Collections;

namespace CosmosStandardUT.CollUT;

[Trait("CollUT", "ArrayUT.To")]
public class ArrayToTests
{
    [Fact(DisplayName = "Arrays.ToArraySafety test")]
    public void ConvertToArraySafety()
    {
        var expectVal = new[] {"1", "2"};
        List<string> niceString = new List<string> {"1", "2"};
        IEnumerable<string> niceEnumerable = niceString;
        IReadOnlyList<string> niceReadOnly = niceString.AsReadOnly();
        string[] niceOneDimArray = {"1", "2"};
        Array niceArray = new[] {"1", "2"};
            
        var niceNull1 = Arrays.ToArraySafety((IEnumerable<string>) null);
        var niceNull2 = Arrays.ToArraySafety<string>((Array) null);
        var niceStringCopy = Arrays.ToArraySafety(niceString);
        var niceEnumerableCopy = Arrays.ToArraySafety(niceEnumerable);
        var niceReadOnlyCopy = Arrays.ToArraySafety(niceReadOnly);
        var niceOneDimArrayCopy = Arrays.ToArraySafety(niceOneDimArray);
        var niceArrayCopy = Arrays.ToArraySafety<string>(niceArray);

        niceNull1.ShouldNotBeNull();
        niceNull1.ShouldBeEmpty();
        niceNull2.ShouldNotBeNull();
        niceNull2.ShouldBeEmpty();
        niceStringCopy.ShouldNotBeNull();
        Assert.Equal(expectVal, niceStringCopy);
        niceEnumerableCopy.ShouldNotBeNull();
        Assert.Equal(expectVal, niceEnumerableCopy);
        niceReadOnlyCopy.ShouldNotBeNull();
        Assert.Equal(expectVal, niceReadOnlyCopy);
        niceOneDimArrayCopy.ShouldNotBeNull();
        Assert.Equal(expectVal, niceOneDimArrayCopy);
        niceArrayCopy.ShouldNotBeNull();
        Assert.Equal(expectVal, niceArrayCopy);
    }
}