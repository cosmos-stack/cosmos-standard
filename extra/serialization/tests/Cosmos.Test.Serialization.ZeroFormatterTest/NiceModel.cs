using System;
using ZeroFormatter;

namespace Cosmos.Test.Serialization.ZeroFormatterTest
{
    [ZeroFormattable]
    public class NiceModel
    {
        [Index(0)]
        public virtual Guid Id { get; set; }

        [Index(1)]
        public virtual string Name { get; set; }

        [Index(2)]
        public virtual NiceType NiceType { get; set; }

        [Index(3)]
        public virtual int Count { get; set; }

        [Index(4)]
        public virtual DateTime CreatedTime { get; set; }

        [Index(5)]
        public virtual bool IsValid { get; set; }
    }
}