using System;
using Cosmos.Reflection;
using Cosmos.Test.ScannerTest0;

namespace Cosmos.Test.ScannerTestEntry
{
    public class DividedScanner : InstanceScanner<IAlexinea>
    {
        public DividedScanner()
        {
        }

        protected override Func<Type, bool> TypeFilter()
        {
            throw new NotImplementedException();
        }
    }
}
