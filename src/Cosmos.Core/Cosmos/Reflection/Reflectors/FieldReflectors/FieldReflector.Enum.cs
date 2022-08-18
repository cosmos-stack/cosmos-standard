﻿using System.Reflection.Emit;

namespace Cosmos.Reflection.Reflectors;

public partial class FieldReflector : MemberReflector<FieldInfo>
{
    private class EnumFieldReflector : FieldReflector
    {
        public EnumFieldReflector(FieldInfo reflectionInfo) : base(reflectionInfo) { }

        protected override Func<object, object> CreateGetter()
        {
            var dynamicMethod = new DynamicMethod($"getter-{Guid.NewGuid()}", typeof(object), new[] { typeof(object) }, _reflectionInfo.Module, true);
            var ilGen = dynamicMethod.GetILGenerator();
            var value = _reflectionInfo.GetValue(null);
            ilGen.EmitConstant(value, _reflectionInfo.FieldType);
            ilGen.EmitConvertToObject(_reflectionInfo.FieldType);
            ilGen.Emit(OpCodes.Ret);
            return (Func<object, object>)dynamicMethod.CreateDelegate(typeof(Func<object, object>));
        }

        protected override Action<object, object> CreateSetter()
        {
            var dynamicMethod = new DynamicMethod($"setter-{Guid.NewGuid()}", typeof(void), new[] { typeof(object), typeof(object) }, _reflectionInfo.Module, true);
            var ilGen = dynamicMethod.GetILGenerator();
            ilGen.Emit(OpCodes.Ret);
            return (Action<object, object>)dynamicMethod.CreateDelegate(typeof(Action<object, object>));
        }

        public override object GetValue(object instance) => _getter(null);

        public override void SetValue(object instance, object value) => throw new FieldAccessException("Cannot set a constant field");

        public override object GetStaticValue() => _getter(null);

        public override void SetStaticValue(object value) => throw new FieldAccessException("Cannot set a constant field");
    }
}