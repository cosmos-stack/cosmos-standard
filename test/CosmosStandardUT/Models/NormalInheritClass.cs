namespace CosmosStandardUT.Models
{
    public class BaseLevelOne { }

    public abstract class AbstractLevelOne : IInterfaceZero { }

    public class BaseLevelTwo : BaseLevelOne { }

    public class BaseLevelThree<T> { }

    public class BaseLevelFour<T1, T2> : BaseLevelThree<T1> { }

    public interface IInterfaceZero { }

    public interface IInterfaceOne { }

    public interface IInterfaceTwo : IInterfaceOne { }

    public interface IInterfaceThree<T> { }

    public interface IInterfaceFour<T1, T2> : IInterfaceThree<T1>, IInterfaceTwo { }

    public class EntryClassOne : AbstractLevelOne, IInterfaceTwo { }

    public class EntryClassTwo : BaseLevelTwo, IInterfaceFour<int, string> { }

    public class EntryClassThree : BaseLevelFour<long, long> { }
    
    // entry1 --> abstract1 --> interface0
    //        --> interface2 --> interface1
    
    // entry2 --> base2 --> base1
    //        --> interface4[int,string] --> interface3[int]
    //                                   --> interface2 --> interface1
    
    // entry3 --> base4[long,long]-->base3[long]
}