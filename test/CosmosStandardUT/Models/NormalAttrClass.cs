using System;

namespace CosmosStandardUT.Models
{
    [ModelOne]
    [ModelOne]
    [ModelThree]
    public class NormalWithAttrClass
    {
        [ModelOne] [ModelTwo] public string Nice { get; set; }

        [ModelOne]
        [ModelTwo]
        public string Good;

        [ModelOne]
        [ModelTwo]
        public string GetAwesome()
        {
            return string.Empty;
        }

        [ModelOne]
        [ModelTwo]
        public NormalWithAttrClass() { }

        public NormalWithAttrClass([ModelTwo][ModelThree] string value)
        {
            Nice = value;
        }
    }

    public class NormalWithoutAttrClass
    {
        public string Nice { get; set; }

        public string Good;

        public string GetAwesome()
        {
            return string.Empty;
        }

        public NormalWithoutAttrClass() { }

        public NormalWithoutAttrClass(string value)
        {
            Nice = value;
        }
    }

    public class NormalWithAttrClassWrapper : NormalWithAttrClass
    {
        public NormalWithAttrClassWrapper() : base() { }

        public NormalWithAttrClassWrapper(string value) : base(value) { }
    }

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class ModelOneAttribute : Attribute { }

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = false)]
    public class ModelTwoAttribute : Attribute { }
    
    [AttributeUsage(AttributeTargets.All, AllowMultiple = true)]
    public class ModelThreeAttribute : Attribute { }
}