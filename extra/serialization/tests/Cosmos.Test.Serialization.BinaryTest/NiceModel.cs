using System;

namespace Cosmos.Test.Serialization.BinaryTest
{
    [Serializable]
    public class NiceModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public NiceType NiceType { get; set; }
        public int Count { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public bool IsValid { get; set; }
    }
}