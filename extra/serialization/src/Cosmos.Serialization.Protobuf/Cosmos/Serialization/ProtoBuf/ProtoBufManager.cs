using System;
using ProtoBuf.Meta;

namespace Cosmos.Serialization.ProtoBuf
{
    internal static class ProtoBufManager
    {
        private static readonly Lazy<RuntimeTypeModel> _model = new Lazy<RuntimeTypeModel>(CreateTypeModel);

        public static RuntimeTypeModel Model => _model.Value;

        private static RuntimeTypeModel CreateTypeModel()
        {
            var typeModel = TypeModel.Create();
            typeModel.UseImplicitZeroDefaults = false;
            return typeModel;
        }
    }
}