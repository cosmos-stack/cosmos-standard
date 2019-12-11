using System;

namespace Cosmos.Test.Serialization.SharpYaml {
    [Serializable]
    public class NiceModel {
        public string Id { get; set; }
        public string Name { get; set; }
        public NiceType NiceType { get; set; }
        public int Count { get; set; }
        public DateTime CreatedTime { get; set; }
        public bool IsValid { get; set; }
    }
}