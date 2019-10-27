using System;

namespace Cosmos.Test.Serialization.XmlTest
{
    public class NiceModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public NiceType NiceType { get; set; }
        public int Count { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsValid { get; set; }
    }
}