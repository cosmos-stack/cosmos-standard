using System;
using System.Collections.Generic;
using System.Text;
using Cosmos.Test.ScannerTest1;
using Cosmos.Test.ScannerTest2;

namespace Cosmos.Test.ScannerTestEntry
{
    public class ComponentRiku
    {
        public virtual GenericRiku<Alex001> Alex001 { get; set; }
        public virtual GenericRiku<Alex002> Alex002 { get; set; }
        public virtual GenericRiku<Alex003> Alex003 { get; set; }
        public virtual GenericRiku<ImplementAlex004> Alex004 { get; set; }
        public virtual GenericRiku<ImplementAlex005> Alex005 { get; set; }
        public virtual GenericRiku<Lewis001> Lewis001 { get; set; }
        public virtual GenericRiku<Lewis002> Lewis002 { get; set; }
        public virtual GenericRiku<Lewis003> Lewis003 { get; set; }
        public virtual GenericRiku<ImplementLewis004> Lewis004 { get; set; }
        public virtual GenericRiku<ImplementLewis005> Lewis005 { get; set; }
    }
}
