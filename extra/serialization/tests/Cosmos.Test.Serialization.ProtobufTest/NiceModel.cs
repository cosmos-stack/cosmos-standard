using System;
using ProtoBuf;

namespace Cosmos.Test.Serialization.ProtobufTest {
    [ProtoContract]
    public class NiceModel {
        [ProtoMember(1)]
        public Guid Id { get; set; }

        [ProtoMember(2)]
        public string Name { get; set; }

        [ProtoMember(3)]
        public NiceType NiceType { get; set; }

        [ProtoMember(4)]
        public int Count { get; set; }

        [ProtoMember(6)]
        public DateTime CreatedTime { get; set; }

        [ProtoMember(7)]
        public bool IsValid { get; set; }
    }
}