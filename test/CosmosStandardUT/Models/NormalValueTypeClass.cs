using System;

namespace CosmosStandardUT.Models
{
    public class NormalValueTypeClass
    {
        public int Int16V1 { get; set; }
        public int Int16V2;
        public int? Int16V3 { get; set; }
        public int? Int16V4;
        
        public bool BooleanV1 { get; set; }
        public bool BooleanV2;
        
        public bool? BooleanV3 { get; set; }
        public bool? BooleanV4;
        
        public DateTime DateTimeV1 { get; set; }
        public DateTime DateTimeV2;
        
        public DateTime? DateTimeV3 { get; set; }
        public DateTime? DateTimeV4;
        
        public string Str { get; set; }
    }
}