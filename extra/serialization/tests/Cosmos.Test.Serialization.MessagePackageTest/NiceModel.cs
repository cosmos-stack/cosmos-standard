using System;
using MessagePack;

namespace Cosmos.Test.Serialization.MessagePackageTest
{
    [MessagePackObject]
    public class NiceModel
    {
        [Key(0)]
        public Guid Id { get; set; }

        [Key(1)]
        public string Name { get; set; }

        [Key(2)]
        public NiceType NiceType { get; set; }

        [Key(3)]
        public int Count { get; set; }

        [Key(4)]
        public DateTimeOffset CreatedTime { get; set; }

        [Key(5)]
        public bool IsValid { get; set; }
    }
}