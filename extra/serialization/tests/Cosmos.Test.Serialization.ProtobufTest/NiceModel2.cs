using System;
using System.Collections.Generic;
using ProtoBuf;

namespace Cosmos.Test.Serialization.ProtobufTest
{
    public class NiceModel2
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public NiceType NiceType { get; set; }
        public int Count { get; set; }
        public DateTimeOffset CreatedTime { get; set; }
        public Dictionary<Guid, NiceModel2> Kids { get; set; }
        public bool IsValid { get; set; }
    }

    public class SubModel : NiceModel2
    {
        public int SayId { get; set; }
    }
}