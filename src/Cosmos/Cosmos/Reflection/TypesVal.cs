using System;
using System.Collections.Generic;

namespace Cosmos.Reflection
{
    public class TypesVal
    {
        private readonly Type[] _types;

        private TypesVal(int size)
        {
            _types = new Type[size];
            Count = size;
        }
        
        public int Count { get; }
        
        public Type[] TypeArray {
            get
            {
                var array= new Type[Count];
                Array.Copy(_types,array,Count);
                return array;
            }
        }

        public IEnumerable<Type> Types => TypeArray;
        
        public Type this[int index]
        {
            get
            {
                if(index<0||index>=Count)
                    throw new ArgumentOutOfRangeException(nameof(index));
                return _types[index];
            }
        }

        public static TypesVal Create(params Type[] types)
        {
            if (types is null || types is {Length: <=0})
                return Empty;
            var val = new TypesVal(types.Length);
            Array.Copy(types, val._types, val.Count);
            return val;
        }

        public static TypesVal Empty { get; } = new(0);

        public bool IsEmpty() => Count == 0;
    }
}