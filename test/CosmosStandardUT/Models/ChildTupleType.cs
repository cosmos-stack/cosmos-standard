﻿using System;

namespace CosmosStandardUT.Models;

public class ChildTupleType : Tuple<int, int>
{
    public ChildTupleType(int item1, int item2) : base(item1, item2) { }
}