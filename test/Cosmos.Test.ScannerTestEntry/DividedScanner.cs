using System;
using System.Collections.Generic;
using System.Text;
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
