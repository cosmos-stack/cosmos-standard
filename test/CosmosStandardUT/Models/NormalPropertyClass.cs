namespace CosmosStandardUT.Models;

public class NormalPropertyClass
{
    public string PublicGetSet { get; set; }
        
    public string PublicGet { get; internal set; }
        
    public string PublicSet { internal get; set; }
        
    internal string InternalGetSet { get; set; }

    public string PublicField;
}