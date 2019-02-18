using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Test.ScannerTest0;

namespace Cosmos.Test.ScannerTestEntry
{
    public class GenericRiku<TAlexinea> where TAlexinea : class, IAlexinea, new()
    {
    }

    public abstract class AbstractGenericRiku<TAlexinea> where TAlexinea : class, IAlexinea, new() { }
}
